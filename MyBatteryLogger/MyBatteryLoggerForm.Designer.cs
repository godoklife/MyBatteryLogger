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
            this.btnHide = new ReaLTaiizor.Controls.MetroButton();
            this.listView1 = new ReaLTaiizor.Controls.MaterialListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ckbAutoRun = new ReaLTaiizor.Controls.MetroCheckBox();
            this.ckbMinimalize = new ReaLTaiizor.Controls.MetroCheckBox();
            this.SuspendLayout();
            this.metroStyleManager1.CustomTheme = null;
            this.metroStyleManager1.OwnerForm = this;
            this.metroStyleManager1.Style = ReaLTaiizor.Enum.Metro.Style.Dark;
            this.metroStyleManager1.ThemeAuthor = "Taiizor";
            this.metroStyleManager1.ThemeName = "MetroDark";
            this.lblPrecentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPrecentage.IsDerivedStyle = true;
            this.lblPrecentage.Location = new System.Drawing.Point(15, 70);
            this.lblPrecentage.Name = "lblPrecentage";
            this.lblPrecentage.Size = new System.Drawing.Size(370, 23);
            this.lblPrecentage.Style = ReaLTaiizor.Enum.Metro.Style.Dark;
            this.lblPrecentage.StyleManager = this.metroStyleManager1;
            this.lblPrecentage.TabIndex = 0;
            this.lblPrecentage.Text = "metroLabel1";
            this.lblPrecentage.ThemeAuthor = "Taiizor";
            this.lblPrecentage.ThemeName = "MetroDark";
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
            this.btnRefresh.Style = ReaLTaiizor.Enum.Metro.Style.Dark;
            this.btnRefresh.StyleManager = this.metroStyleManager1;
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.ThemeAuthor = "Taiizor";
            this.btnRefresh.ThemeName = "MetroDark";
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
            this.btnClose.Style = ReaLTaiizor.Enum.Metro.Style.Dark;
            this.btnClose.StyleManager = this.metroStyleManager1;
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "닫기";
            this.btnClose.ThemeAuthor = "Taiizor";
            this.btnClose.ThemeName = "MetroDark";
            this.btnHide.DisabledBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 120 ) ) ) ), ( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnHide.DisabledBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 120 ) ) ) ), ( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnHide.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnHide.HoverBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 95 ) ) ) ), ( (int)( ( (byte)( 207 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.btnHide.HoverColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 95 ) ) ) ), ( (int)( ( (byte)( 207 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.btnHide.HoverTextColor = System.Drawing.Color.White;
            this.btnHide.IsDerivedStyle = true;
            this.btnHide.Location = new System.Drawing.Point(150, 425);
            this.btnHide.Name = "btnHide";
            this.btnHide.NormalBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnHide.NormalColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.btnHide.NormalTextColor = System.Drawing.Color.White;
            this.btnHide.PressBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 35 ) ) ) ), ( (int)( ( (byte)( 147 ) ) ) ), ( (int)( ( (byte)( 195 ) ) ) ));
            this.btnHide.PressColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 35 ) ) ) ), ( (int)( ( (byte)( 147 ) ) ) ), ( (int)( ( (byte)( 195 ) ) ) ));
            this.btnHide.PressTextColor = System.Drawing.Color.White;
            this.btnHide.Size = new System.Drawing.Size(100, 40);
            this.btnHide.Style = ReaLTaiizor.Enum.Metro.Style.Dark;
            this.btnHide.StyleManager = this.metroStyleManager1;
            this.btnHide.TabIndex = 5;
            this.btnHide.Text = "최소화";
            this.btnHide.ThemeAuthor = "Taiizor";
            this.btnHide.ThemeName = "MetroDark";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            this.listView1.AutoSizeTable = false;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeader1, this.columnHeader2, this.columnHeader3 });
            this.listView1.Depth = 0;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(15, 96);
            this.listView1.MinimumSize = new System.Drawing.Size(200, 100);
            this.listView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listView1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(370, 263);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 140;
            this.columnHeader2.Text = "Batt";
            this.columnHeader2.Width = 70;
            this.columnHeader3.Text = "PowerLine";
            this.columnHeader3.Width = 160;
            this.ckbAutoRun.BackColor = System.Drawing.Color.Transparent;
            this.ckbAutoRun.BackgroundColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 30 ) ) ) ), ( (int)( ( (byte)( 30 ) ) ) ), ( (int)( ( (byte)( 30 ) ) ) ));
            this.ckbAutoRun.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 155 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ));
            this.ckbAutoRun.Checked = false;
            this.ckbAutoRun.CheckSignColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.ckbAutoRun.CheckState = ReaLTaiizor.Enum.Metro.CheckState.Unchecked;
            this.ckbAutoRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckbAutoRun.DisabledBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 85 ) ) ) ), ( (int)( ( (byte)( 85 ) ) ) ), ( (int)( ( (byte)( 85 ) ) ) ));
            this.ckbAutoRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ckbAutoRun.IsDerivedStyle = true;
            this.ckbAutoRun.Location = new System.Drawing.Point(15, 365);
            this.ckbAutoRun.Name = "ckbAutoRun";
            this.ckbAutoRun.SignStyle = ReaLTaiizor.Enum.Metro.SignStyle.Sign;
            this.ckbAutoRun.Size = new System.Drawing.Size(125, 16);
            this.ckbAutoRun.Style = ReaLTaiizor.Enum.Metro.Style.Dark;
            this.ckbAutoRun.StyleManager = this.metroStyleManager1;
            this.ckbAutoRun.TabIndex = 7;
            this.ckbAutoRun.Text = "부팅시 자동실행";
            this.ckbAutoRun.ThemeAuthor = "Taiizor";
            this.ckbAutoRun.ThemeName = "MetroDark";
            this.ckbMinimalize.BackColor = System.Drawing.Color.Transparent;
            this.ckbMinimalize.BackgroundColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 30 ) ) ) ), ( (int)( ( (byte)( 30 ) ) ) ), ( (int)( ( (byte)( 30 ) ) ) ));
            this.ckbMinimalize.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 155 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ));
            this.ckbMinimalize.Checked = false;
            this.ckbMinimalize.CheckSignColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 65 ) ) ) ), ( (int)( ( (byte)( 177 ) ) ) ), ( (int)( ( (byte)( 225 ) ) ) ));
            this.ckbMinimalize.CheckState = ReaLTaiizor.Enum.Metro.CheckState.Unchecked;
            this.ckbMinimalize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckbMinimalize.DisabledBorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 85 ) ) ) ), ( (int)( ( (byte)( 85 ) ) ) ), ( (int)( ( (byte)( 85 ) ) ) ));
            this.ckbMinimalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ckbMinimalize.IsDerivedStyle = true;
            this.ckbMinimalize.Location = new System.Drawing.Point(150, 365);
            this.ckbMinimalize.Name = "ckbMinimalize";
            this.ckbMinimalize.SignStyle = ReaLTaiizor.Enum.Metro.SignStyle.Sign;
            this.ckbMinimalize.Size = new System.Drawing.Size(125, 16);
            this.ckbMinimalize.Style = ReaLTaiizor.Enum.Metro.Style.Dark;
            this.ckbMinimalize.StyleManager = this.metroStyleManager1;
            this.ckbMinimalize.TabIndex = 8;
            this.ckbMinimalize.Text = "실행시 최소화";
            this.ckbMinimalize.ThemeAuthor = "Taiizor";
            this.ckbMinimalize.ThemeName = "MetroDark";
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 30 ) ) ) ), ( (int)( ( (byte)( 30 ) ) ) ), ( (int)( ( (byte)( 30 ) ) ) ));
            this.ClientSize = new System.Drawing.Size(400, 480);
            this.Controls.Add(this.ckbMinimalize);
            this.Controls.Add(this.ckbAutoRun);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblPrecentage);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MyBatteryLoggerForm";
            this.Style = ReaLTaiizor.Enum.Metro.Style.Dark;
            this.StyleManager = this.metroStyleManager1;
            this.Text = "MyBatteryLogger";
            this.TextColor = System.Drawing.Color.White;
            this.ThemeName = "MetroDark";
            this.ResumeLayout(false);
        }

        private ReaLTaiizor.Controls.MetroCheckBox ckbAutoRun;
        private ReaLTaiizor.Controls.MetroCheckBox ckbMinimalize;

        private System.Windows.Forms.ColumnHeader columnHeader3;

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

        private ReaLTaiizor.Controls.MaterialListView listView1;

        private ReaLTaiizor.Controls.MetroButton btnHide;

        private ReaLTaiizor.Controls.MetroLabel lblPrecentage;
        private ReaLTaiizor.Controls.MetroButton btnRefresh;
        private ReaLTaiizor.Controls.MetroButton btnClose;

        private ReaLTaiizor.Manager.MetroStyleManager metroStyleManager1;
        #endregion
    }
}