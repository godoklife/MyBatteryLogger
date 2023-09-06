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
    public partial class MyBatteryLoggerForm : MetroForm
    {
        #region field
        private int pastBatteryLifePercent = -1;
        private PowerLineStatus pastPowerLineStatus = PowerLineStatus.Unknown;
        private readonly Timer logTimer;
        private DateTime pastDateTime;

        // 저장 경로
        private static string logPath = string.Empty;
        private static string fullPath = string.Empty;
        private StreamWriter sw;

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        #endregion

        public MyBatteryLoggerForm()
        {
            InitializeComponent();
            AllowResize = false;

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
            trayIcon.MouseDoubleClick += (sender, e) =>
                              {
                                  trayIcon.Visible = false;
                                  Show();
                              };
            #endregion
            
            #region 로그 저장경로
            pastDateTime = DateTime.Today;
            logPath = $@"{Application.StartupPath}\log";
            fullPath = logPath + "\\" + $@"MyBatteryLogger_{DateTime.Now:yyyy-MM-dd}.log";
            
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            sw = new StreamWriter(fullPath, true, Encoding.UTF8);
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

        private void ResizeControls(object sender, EventArgs e)
        {
            // 창의 크기가 변경되면, 내부 컨트롤들의 크기도 조절해야 할듯?
        }

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
                fullPath = logPath+"\\"+ $"MyBatteryLogger_{DateTime.Today:yyyy-MM-dd}.log";
                sw.Dispose();
                sw = new StreamWriter(fullPath, true);
                pastDateTime = DateTime.Today;
            }

            PowerStatus ps = SystemInformation.PowerStatus;
            int currentBatteryLifePercent = (int)Math.Round(ps.BatteryLifePercent * 100);
            // if (currentBatteryLifePercent != pastBatteryLifePercent || pastPowerLineStatus != ps.PowerLineStatus)
            {
                pastBatteryLifePercent = currentBatteryLifePercent;
                pastPowerLineStatus = ps.PowerLineStatus;

                WriteBatteryLog(pastBatteryLifePercent, pastPowerLineStatus.ToString());
                lblPrecentage.Text = $"남은 배터리 : {pastBatteryLifePercent}%, 전원선: {pastPowerLineStatus.ToString()}";

                ListViewItem item = new ListViewItem(new[] { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), pastBatteryLifePercent + "%", pastPowerLineStatus.ToString() });
                listView1.Items.Add(item);
                listView1.EnsureVisible(listView1.Items.Count-1);
                if (listView1.Items.Count >= 200)
                    listView1.Items.RemoveAt(0);
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
            MaterialMessageBox.Show("짜잔", false);
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
    }
}