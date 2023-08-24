using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using Timer = System.Timers.Timer;

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
        private System.Windows.Forms.Timer logTimer;
        private string logPath = string.Empty;
        #endregion
        
        public MyBatteryLoggerForm()
        {
            InitializeComponent();
            // SizeChanged += ResizeControls;
            #region event
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
            #endregion

            #region logTimer
            logTimer = new System.Windows.Forms.Timer();
            logTimer.Interval = 1000;
            logTimer.Tick += logTimer_Tick;
            #endregion

        }

        /// <summary>
        /// 배터리 상태 조회
        /// </summary>
        /// <returns></returns>
        private string RetrieveBatteryState(RetrieveBatteryStatType type)
        {
            PowerStatus ps = SystemInformation.PowerStatus;
            string result = string.Empty;
            
            switch (type)
            {
                case RetrieveBatteryStatType.ALL:
                    break;
                case RetrieveBatteryStatType.BATTERY_LIFE_PERCENT:
                    result = ( ps.BatteryLifePercent * 100 ).ToString("d%");
                    break;
                case RetrieveBatteryStatType.BATTERY_CHARGE_STATUS:
                    result = ps.BatteryChargeStatus == BatteryChargeStatus.Charging ? "충전중" : "방전중";
                    break;
                case RetrieveBatteryStatType.BATTERY_FULL_LIFE_TIME:
                    break;
                case RetrieveBatteryStatType.BATTERY_LIFE_REMAINING:
                    break;
                case RetrieveBatteryStatType.POWER_LINE_STATUS:
                    break;
            }

            return result;
        }
        
        private string GetBatteryVoltage()
        {
            
        }
        
        private void ResizeControls(object sender, EventArgs e)
        {
            
        }

        private void logTimer_Tick(object sender, EventArgs e)
        {
            logTimer.Stop();
            string content = string.Empty;
            
            
            logTimer.Start();
        }
        
        /// <summary>
        /// 새로고침 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PowerStatus powerStatus = SystemInformation.PowerStatus;
            lblPrecentage.Text = $"남은 배터리: {powerStatus.BatteryLifePercent * 100}%, 상태: {powerStatus.BatteryChargeStatus}";

            string query = "SELECT * FROM Win32_Battery";
            ManagementObjectSearcher mos = new ManagementObjectSearcher(query);

            int count = 0;
            lvMain.Items.Clear();
            foreach (ManagementBaseObject mo in mos.Get())
            {
                foreach (PropertyData propertyData in mo.Properties)
                {
                    Console.WriteLine($"{count} - {propertyData.Name}: {propertyData.Value}");
                    ListViewItem lvi = new ListViewItem(new string[] { propertyData.Name, propertyData.Value == null?string.Empty : propertyData.Value.ToString()});
                    lvMain.Items.Add(lvi);
                }
                
                count++;
            }
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
            
            if(dr == DialogResult.Yes)
            {
                Dispose();
            }
            else
            {
                logTimer.Start();
            }
        }
    }
}