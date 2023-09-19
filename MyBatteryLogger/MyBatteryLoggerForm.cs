using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using File = System.IO.File;

namespace MyBatteryLogger
{
    public interface IConfigHandler
    {
        long WriteConfig(string section, string key, string val, string filePath);
        int ReadConfig(string section, string key, string def, StringBuilder retVal, int size, string filePath);
    }

    public class ConfigHanler : IConfigHandler
    {
        /// <summary>
        /// 설정값 저장하기
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        /// 설정값 읽어들이기
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <param name="retVal"></param>
        /// <param name="size"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        
        public long WriteConfig(string section, string key, string val, string filePath)
        {
            return WritePrivateProfileString(section, key, val, filePath);
        }

        public int ReadConfig(string section, string key, string def, StringBuilder retVal, int size, string filePath)
        {
            return GetPrivateProfileString(section, key, def, retVal, size, filePath);
        }
    }
    
    public partial class MyBatteryLoggerForm : MetroForm
    {
        #region field
        private bool _working = false;
        
        private readonly IConfigHandler _configHandler = new ConfigHanler();
        private string[] configKeyArr = new[] { "AutoRun", "Minimalize" };
        
        private byte pastBatteryLifePercent = 255;
        private PowerLineStatus pastPowerLineStatus = PowerLineStatus.Unknown;
        private readonly Timer logTimer;
        private DateTime pastDateTime;

        // 저장 경로
        private static string logPath = string.Empty;
        private static string fullLogPath = string.Empty;
        private readonly string configPath = $"{Application.StartupPath}\\MyBatteryLogger_config.ini";
        private StreamWriter sw;

        private readonly NotifyIcon trayIcon = new NotifyIcon();
        private readonly ContextMenu trayMenu = new ContextMenu();
        #endregion

        public MyBatteryLoggerForm()
        {
            InitializeComponent();
            AllowResize = false;
            
            #region 트레이
            trayMenu.MenuItems.Add("열기",
                                   (sender, e) =>
                                   {
                                       trayIcon.Visible = false;
                                       Show();
                                   });
            trayMenu.MenuItems.Add("종료", btnClose_Click);
            trayIcon.Text = "MyBatteryLogger";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = false;
            trayIcon.MouseDoubleClick += (sender, e) =>
                                         {
                                             trayIcon.Visible = false;
                                             Show();
                                         };
            #endregion

            #region 로그 저장경로
            pastDateTime = DateTime.Today;
            logPath = $@"{Application.StartupPath}\log";
            fullLogPath = logPath + "\\" + $@"MyBatteryLogger_{DateTime.Now:yyyy-MM-dd}.log";

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            sw = new StreamWriter(fullLogPath, true, Encoding.UTF8);
            #endregion

            #region 설정파일 읽어들이기
            Dictionary<string, bool> configDic = ReadAllConfig();
            if (configDic == null)
            {
                InitConfig();
            }
            else
            {
                foreach (KeyValuePair<string, bool> VARIABLE in configDic)
                {
                    if (VARIABLE.Value)
                        ProcessConfig(VARIABLE.Key);
                }
            }
            #endregion

            #region event
            btnOpenLog.Click += BtnOpenLog_Click;
            btnClose.Click += btnClose_Click;
            ckbAutoRun.CheckedChanged += ckbAutoRun_CheckedChanged;
            ckbMinimalize.CheckedChanged += ckbMinimalize_CheckedChanged;
            #endregion

            #region logTimer
            logTimer = new Timer();
            logTimer.Interval = 1000;
            logTimer.Tick += logTimer_Tick;
            logTimer.Start();
            #endregion
        }

        #region 이벤트
        /// <summary>
        /// Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logTimer_Tick(object sender, EventArgs e)
        {
            logTimer.Stop();

            if (pastDateTime != DateTime.Today)
            {
                fullLogPath = logPath + "\\" + $"MyBatteryLogger_{DateTime.Today:yyyy-MM-dd}.log";
                sw.Dispose();
                sw = new StreamWriter(fullLogPath, true);
                pastDateTime = DateTime.Today;
            }

            PowerStatus ps = SystemInformation.PowerStatus;
            byte currentBatteryLifePercent = (byte)Math.Round(ps.BatteryLifePercent * 100);
            if (currentBatteryLifePercent != pastBatteryLifePercent || pastPowerLineStatus != ps.PowerLineStatus)
            {
                pastBatteryLifePercent = currentBatteryLifePercent;
                pastPowerLineStatus = ps.PowerLineStatus;

                WriteBatteryLog(pastBatteryLifePercent, pastPowerLineStatus.ToString());
                lblPrecentage.Text = $"남은 배터리 : {pastBatteryLifePercent}%, 전원선: {pastPowerLineStatus.ToString()}";

                ListViewItem item = new ListViewItem(new[] { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), pastBatteryLifePercent + "%", pastPowerLineStatus.ToString() });
                listView1.Items.Add(item);
                listView1.EnsureVisible(listView1.Items.Count - 1);
                if (listView1.Items.Count >= 200)
                    listView1.Items.RemoveAt(0);
            }

            logTimer.Start();
        }

        /// <summary>
        /// 로그 보기 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenLog_Click(object sender, EventArgs e)
        {
            Process.Start(fullLogPath);
        }

        /// <summary>
        /// 닫기 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            logTimer.Stop();
            DialogResult dr = MetroMessageBox.Show(this, "종료할까요?", "종료", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                logTimer.Dispose();
                Application.Exit();
            }
            else
            {
                logTimer.Start();
            }
        }

        /// <summary>
        /// 최소화 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHide_Click(object sender, EventArgs e)
        {
            Hide();
            trayIcon.Visible = true;
        }

        private void ckbAutoRun_CheckedChanged(object sender)
        {
            if (_working)
                MaterialMessageBox.Show("작업중");
            else
            {
                _working = true;
                
                SaveSpecificConfig("AutoRun", ckbAutoRun.Checked);
            
                if (ckbAutoRun.Checked)
                    SaveAutoRunShortcut();
                else
                    RemoveAutoRunShortcut();
                
                _working = false;
            }
        }

        private void ckbMinimalize_CheckedChanged(object sender)
        {
            if (_working)
                MaterialMessageBox.Show("작업중");
            else
            {
                _working = true;
                SaveSpecificConfig("Minimalize", ckbMinimalize.Checked);
                _working = false;
            }
        }
        #endregion

        #region 내부 메서드
        /// <summary>
        /// 파일에 기록
        /// </summary>
        /// <param name="batteryPercentage"></param>
        /// <param name="powerLineMsg"></param>
        private void WriteBatteryLog(int batteryPercentage, string powerLineMsg)
        {
            try
            {
                sw.WriteLine($"[{DateTime.Now,-24:yyyy-MM-dd HH:mm:ss}] - [배터리: {batteryPercentage,3}%] - [전원선: {powerLineMsg,-8}]");
                sw.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 설정값 읽어들이기
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, bool> ReadAllConfig()
        {
            Dictionary<string, bool> result = null;
            try
            {
                if (File.Exists(configPath))
                {
                    result = new Dictionary<string, bool>();
                    string[] configs = File.ReadAllLines(configPath, Encoding.UTF8);

                    foreach (string config in configs)
                    {
                        string[] splitedConfig = config.Split('=');
                        if (splitedConfig.Length != 2)
                            continue;

                        result.Add(splitedConfig[0].Trim(), splitedConfig[1].Trim().ToLower() == "true");
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString());
                Application.Exit();
            }

            return result;
        }

        /// <summary>
        /// 특정 설정값 읽어들이기
        /// </summary>
        /// <param name="key"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        private bool ReadSpecificConfig(string key, string section = "Settings")
        {
            StringBuilder sb = new StringBuilder(255);
            _configHandler.ReadConfig(section, key, "", sb, 255, configPath);

            return sb.ToString().Trim().ToLower().Equals("true");
        }

        private void SaveSpecificConfig(string key, bool value, string section = "Settings")
        {
            _configHandler.WriteConfig(section, key, value.ToString().ToLower(), configPath);
        }

        /// <summary>
        /// 설정값 파일을 초기화 합니다.
        /// </summary>
        private void InitConfig()
        {
            try
            {
                SaveSpecificConfig("AutoRun", false);
                SaveSpecificConfig("Minimalize", false);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// 설정값에 따라 처리합니다.
        /// </summary>
        /// <param name="configDic"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ProcessConfig(string key, string section = "Settings")
        {
            StringBuilder sb = new StringBuilder(255);
            _configHandler.ReadConfig(section, key, "", sb, 255, configPath);
            bool value = sb.ToString().ToLower().Equals("true");
            switch (key)
            {
                case "AutoRun":
                    if(value)
                    {
                        SaveAutoRunShortcut();
                        ckbAutoRun.Checked = true;
                    }
                    else
                        RemoveAutoRunShortcut();
                    break;
                case "Minimalize":
                    WindowState = FormWindowState.Minimized;
                    ckbMinimalize.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 바로가기를 Environment.SpecialFolder.Startup에 저장합니다.
        /// </summary>
        public void SaveAutoRunShortcut()
        {
            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "MyBatteryLogger.lnk");
            if(!File.Exists(shortcutPath))
            {
                WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshShortcut shortcut = shell.CreateShortcut(shortcutPath) as IWshRuntimeLibrary.IWshShortcut;
                
                if(shortcut!= null)
                {
                    shortcut.TargetPath = Application.ExecutablePath;
                    shortcut.WorkingDirectory = Application.StartupPath;
                    shortcut.Description = "배터리 로깅";
                    shortcut.IconLocation = Application.ExecutablePath;
                    shortcut.Save();
                }
            }
        }

        /// <summary>
        /// Environment.SpecialFolder.Startup에 바로가기가 있으면 삭제합니다.
        /// </summary>
        public void RemoveAutoRunShortcut()
        {
            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "MyBatteryLogger.lnk");
            if(File.Exists(shortcutPath))
                File.Delete(shortcutPath);
        }
        #endregion
    }
}