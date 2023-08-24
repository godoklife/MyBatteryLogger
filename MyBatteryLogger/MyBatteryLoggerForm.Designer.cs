using System.Windows.Forms;

namespace MyBatteryLogger
{
    partial class MyBatteryLoggerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroStyleManager1 = new ReaLTaiizor.Manager.MetroStyleManager();
            this.lblPrecentage = new ReaLTaiizor.Controls.MetroLabel();
            this.btnRefresh = new ReaLTaiizor.Controls.MetroButton();
            this.btnClose = new ReaLTaiizor.Controls.MetroButton();
            this.lblDatetime = new ReaLTaiizor.Controls.MetroLabel();
            this.lvMain = new ReaLTaiizor.Controls.MaterialListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.CustomTheme = null;
            this.metroStyleManager1.OwnerForm = this;
            this.metroStyleManager1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.metroStyleManager1.ThemeAuthor = "Taiizor";
            this.metroStyleManager1.ThemeName = "MetroLight";
            // 
            // lblPrecentage
            // 
            this.lblPrecentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPrecentage.IsDerivedStyle = true;
            this.lblPrecentage.Location = new System.Drawing.Point(15, 107);
            this.lblPrecentage.Name = "lblPrecentage";
            this.lblPrecentage.Size = new System.Drawing.Size(231, 23);
            this.lblPrecentage.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.lblPrecentage.StyleManager = this.metroStyleManager1;
            this.lblPrecentage.TabIndex = 0;
            this.lblPrecentage.Text = "metroLabel1";
            this.lblPrecentage.ThemeAuthor = "Taiizor";
            this.lblPrecentage.ThemeName = "MetroLight";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisabledBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 120 ) ) ) ), ( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnRefresh.DisabledBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 120 ) ) ) ), ( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnRefresh.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRefresh.HoverBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 95 ) ) ) ), ( (int)( ( (byte)( 207 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.btnRefresh.HoverColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 95 ) ) ) ), ( (int)( ( (byte)( 207 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.btnRefresh.HoverTextColor = System.Drawing.Color.White;
            this.btnRefresh.IsDerivedStyle = true;
            this.btnRefresh.Location = new System.Drawing.Point(15, 425);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NormalBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnRefresh.NormalColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnRefresh.NormalTextColor = System.Drawing.Color.White;
            this.btnRefresh.PressBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 35 ) ) ) ), ( (int)( ( (byte)( 147 ) ) ) ), ( (int)( ( (byte)( 195 ) ) ) ));
            this.btnRefresh.PressColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 35 ) ) ) ), ( (int)( ( (byte)( 147 ) ) ) ), ( (int)( ( (byte)( 195 ) ) ) ));
            this.btnRefresh.PressTextColor = System.Drawing.Color.White;
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.btnRefresh.StyleManager = this.metroStyleManager1;
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.ThemeAuthor = "Taiizor";
            this.btnRefresh.ThemeName = "MetroLight";
            // 
            // btnClose
            // 
            this.btnClose.DisabledBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 120 ) ) ) ), ( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnClose.DisabledBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 120 ) ) ) ), ( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnClose.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClose.HoverBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 95 ) ) ) ), ( (int)( ( (byte)( 207 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.btnClose.HoverColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 95 ) ) ) ), ( (int)( ( (byte)( 207 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.btnClose.HoverTextColor = System.Drawing.Color.White;
            this.btnClose.IsDerivedStyle = true;
            this.btnClose.Location = new System.Drawing.Point(285, 425);
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnClose.NormalColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnClose.NormalTextColor = System.Drawing.Color.White;
            this.btnClose.PressBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 35 ) ) ) ), ( (int)( ( (byte)( 147 ) ) ) ), ( (int)( ( (byte)( 195 ) ) ) ));
            this.btnClose.PressColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 35 ) ) ) ), ( (int)( ( (byte)( 147 ) ) ) ), ( (int)( ( (byte)( 195 ) ) ) ));
            this.btnClose.PressTextColor = System.Drawing.Color.White;
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.btnClose.StyleManager = this.metroStyleManager1;
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "닫기";
            this.btnClose.ThemeAuthor = "Taiizor";
            this.btnClose.ThemeName = "MetroLight";
            // 
            // lblDatetime
            // 
            this.lblDatetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDatetime.IsDerivedStyle = true;
            this.lblDatetime.Location = new System.Drawing.Point(15, 130);
            this.lblDatetime.Name = "lblDatetime";
            this.lblDatetime.Size = new System.Drawing.Size(231, 23);
            this.lblDatetime.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.lblDatetime.StyleManager = this.metroStyleManager1;
            this.lblDatetime.TabIndex = 3;
            this.lblDatetime.Text = "metroLabel2";
            this.lblDatetime.ThemeAuthor = "Taiizor";
            this.lblDatetime.ThemeName = "MetroLight";
            // 
            // lvMain
            // 
            this.lvMain.AutoSizeTable = false;
            this.lvMain.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.lvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeader1, this.columnHeader2 });
            this.lvMain.Depth = 0;
            this.lvMain.FullRowSelect = true;
            this.lvMain.HideSelection = false;
            this.lvMain.Location = new System.Drawing.Point(15, 166);
            this.lvMain.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvMain.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvMain.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.lvMain.Name = "lvMain";
            this.lvMain.OwnerDraw = true;
            this.lvMain.Size = new System.Drawing.Size(370, 253);
            this.lvMain.TabIndex = 4;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 185;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 185;
            // 
            // MyBatteryLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 480);
            this.Controls.Add(this.lvMain);
            this.Controls.Add(this.lblDatetime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblPrecentage);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MyBatteryLoggerForm";
            this.StyleManager = this.metroStyleManager1;
            this.Text = "MyBatteryLogger";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

        private ReaLTaiizor.Controls.MaterialListView lvMain;

        private ReaLTaiizor.Controls.MetroLabel lblPrecentage;
        private ReaLTaiizor.Controls.MetroButton btnRefresh;
        private ReaLTaiizor.Controls.MetroButton btnClose;
        private ReaLTaiizor.Controls.MetroLabel lblDatetime;

        private ReaLTaiizor.Manager.MetroStyleManager metroStyleManager1;
        #endregion
    }
}