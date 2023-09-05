using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace MyBatteryLogger
{
    public enum RetrieveBatteryStatType
    {
        ALL = 0,
        BATTERY_LIFE_PERCENT = 1,
        BATTERY_CHARGE_STATUS = 2,
        BATTERY_FULL_LIFE_TIME = 3,
        BATTERY_LIFE_REMAINING = 4,
        POWER_LINE_STATUS = 5
    }

    public partial class MyBatteryLoggerForm : MetroForm
    {
        #region field
        private int pastBatteryLifePercent = -1;
        private PowerLineStatus pastPowerLineStatus = PowerLineStatus.Unknown;
        private readonly Timer logTimer;
        private readonly DateTime pastDateTime;

        // 저장 경로
        private static string fileName = string.Empty;
        private static string logPath = string.Empty;
        private static string fullPath = string.Empty;

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        #endregion

        public MyBatteryLoggerForm()
        {
            InitializeComponent();
            // Sianged += Resizntrols;

            #region 트레이
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("열기", (sender, e) =>
                                         {
                                             trayIcon.Visible = false;
                                             Show();
                                         });
            trayMenu.MenuItems.Add("종료", btnClose_Click);
            trayIcon = new NotifyIcon();
            trayIcon.Text= "MyBatteryLogger";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = false;
            trayIcon.Click += (sender, e) =>
                              {
                                  trayIcon.Visible = false;
                                  Show();
                              };
            #endregion
            
            #region 로그 저장경로
            pastDateTime = DateTime.Today;
            fileName = $@"MyBatteryLogger_{DateTime.Now:yyyy-MM-dd}.log";
            logPath = $@"{Application.StartupPath}\log";
            fullPath = logPath + "\\" + fileName;

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            #endregion

            #region event
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
            #endregion

            #region logTimer
            logTimer = new Timer();
            logTimer.Interval = 1000;
            logTimer.Tick += logTimer_Tick;
            logTimer.Start();
            #endregion
        }

        private void ResizeControls(object sender, EventArgs e) { }

        /// <summary>
        /// Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logTimer_Tick(object sender, EventArgs e)
        {
            logTimer.Stop();

            if (pastDateTime != DateTime.Today)
                fileName = $@"MyBatteryLogger_{DateTime.Now:yyyy-MM-dd}.log";

            PowerStatus ps = SystemInformation.PowerStatus;
            int currentBatteryLifePercent = (int)Math.Round(ps.BatteryLifePercent * 100);
            if (currentBatteryLifePercent != pastBatteryLifePercent || pastPowerLineStatus != ps.PowerLineStatus)
            {
                pastBatteryLifePercent = currentBatteryLifePercent;
                pastPowerLineStatus = ps.PowerLineStatus;

                WriteBatteryLog(pastBatteryLifePercent, pastPowerLineStatus.ToString());
                lblPrecentage.Text = $"남은 배터리 : {pastBatteryLifePercent}%, 전원선: {pastPowerLineStatus.ToString()}";
            }

            logTimer.Start();
        }

        /// <summary>
        /// 새로고침 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // logTimer.Start();

            Debug.WriteLine("Stopwatch.IsHighResolution: " + Stopwatch.IsHighResolution);
            Debug.WriteLine("Stopwatch.Frequency: " + Stopwatch.Frequency);
            Stopwatch sw = new Stopwatch();

            PowerStatus ps;
            BatteryChargeStatus psBatteryChargeStatus;
            PowerLineStatus powerStatus = PowerLineStatus.Unknown;
            float batteryLifePercent = 0f;
            int batteryFullLifetime = 0;
            int batteryLifeRemaining = 0;

            ps = SystemInformation.PowerStatus;
            psBatteryChargeStatus = ps.BatteryChargeStatus;
            batteryLifePercent = ps.BatteryLifePercent;
            powerStatus = ps.PowerLineStatus;
            batteryFullLifetime = ps.BatteryFullLifetime;
            batteryLifeRemaining = ps.BatteryLifeRemaining;
            int convertedFloat = 0;

            sw.Start();
            for (int i = 0; i < 1; i++)
            {
                convertedFloat = (int)Math.Round(batteryLifePercent * 100);
            }

            WriteBatteryLog(convertedFloat, powerStatus.ToString());
            sw.Stop();
            Debug.WriteLine("sw.ElapsedMilliseconds: " + sw.ElapsedMilliseconds);
            Debug.WriteLine("sw.Elapsed " + sw.Elapsed);

            #region 기존 새로고침 버튼
            // PowerStatus powerStatus = SystemInformation.PowerStatus;
            // lblPrecentage.Text = $"남은 배터리: {powerStatus.BatteryLifePercent * 100}%, 상태: {powerStatus.BatteryChargeStatus}";
            //
            // string query = "SELECT * FROM Win32_Battery";
            // ManagementObjectSearcher mos = new ManagementObjectSearcher(query);
            //
            // int count = 0;
            // lvMain.Items.Clear();
            // foreach (ManagementBaseObject mo in mos.Get())
            // {
            //     foreach (PropertyData propertyData in mo.Properties)
            //     {
            //         Console.WriteLine($"{count} - {propertyData.Name}: {propertyData.Value}");
            //         ListViewItem lvi = new ListViewItem(new string[] { propertyData.Name, propertyData.Value == null?string.Empty : propertyData.Value.ToString()});
            //         lvMain.Items.Add(lvi);
            //         if (propertyData.Name == "BatteryStatus")
            //         {
            //             lblDatetime.Text = $"남은 배터리: {powerStatus.BatteryLifePercent * 100}%, 상태: {propertyData.Value}";
            //         }
            //     }
            //     
            //     count++;
            // }
            #endregion
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

        private void WriteBatteryLog(int batteryPercentage, string powerLineMsg)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fullPath, true, Encoding.UTF8);
                sw.WriteLine($"[{DateTime.Now,-24:yyyy-MM-dd hh:mm:ss}] - [배터리: {batteryPercentage,3}%] - [전원선: {powerLineMsg,-8}]");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
    }
}