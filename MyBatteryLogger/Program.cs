using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace MyBatteryLogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = false;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createdNew);
            if(createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                Application.Run(new MyBatteryLoggerForm());
            }
            else
            {
                MaterialMessageBox.Show("이미 실행중입니다.", false);
                Application.Exit();
            }
        }
    }
}