namespace SmartReconciliator
{
    partial class MainWindow
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.lblUser = new Telerik.WinControls.UI.RadLabelElement();
            this.commandBarSeparator4 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.lblDate = new Telerik.WinControls.UI.RadLabelElement();
            this.commandBarSeparator5 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.lblTime = new Telerik.WinControls.UI.RadLabelElement();
            this.mnuFileImport = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuAmend = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuExport = new Telerik.WinControls.UI.RadMenuItem();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarSplitButton1 = new Telerik.WinControls.UI.CommandBarSplitButton();
            this.mnuLogOut = new Telerik.WinControls.UI.RadMenuItem();
            this.munExit = new Telerik.WinControls.UI.RadMenuItem();
            this.btnBackground = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.commandBarButton2 = new Telerik.WinControls.UI.CommandBarButton();
            this.btnAdjustment = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnAddUser = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
            this.themeDropDownList = new Telerik.WinControls.UI.CommandBarDropDownList();
            this.timerAutoLogOut = new System.Windows.Forms.Timer(this.components);
            this.bgwTheme = new System.ComponentModel.BackgroundWorker();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.lblUser,
            this.commandBarSeparator4,
            this.lblDate,
            this.commandBarSeparator5,
            this.lblTime});
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 323);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(633, 26);
            this.radStatusStrip1.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.radStatusStrip1.SetSpring(this.lblUser, false);
            this.lblUser.Text = "radLabelElement1";
            this.lblUser.TextWrap = true;
            // 
            // commandBarSeparator4
            // 
            this.commandBarSeparator4.Name = "commandBarSeparator4";
            this.radStatusStrip1.SetSpring(this.commandBarSeparator4, false);
            this.commandBarSeparator4.VisibleInOverflowMenu = false;
            // 
            // lblDate
            // 
            this.lblDate.Name = "lblDate";
            this.radStatusStrip1.SetSpring(this.lblDate, false);
            this.lblDate.Text = "radLabelElement1";
            this.lblDate.TextWrap = true;
            // 
            // commandBarSeparator5
            // 
            this.commandBarSeparator5.Name = "commandBarSeparator5";
            this.radStatusStrip1.SetSpring(this.commandBarSeparator5, false);
            this.commandBarSeparator5.VisibleInOverflowMenu = false;
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.radStatusStrip1.SetSpring(this.lblTime, false);
            this.lblTime.Text = "radLabelElement1";
            this.lblTime.TextWrap = true;
            // 
            // mnuFileImport
            // 
            this.mnuFileImport.Name = "mnuFileImport";
            this.mnuFileImport.Text = "File Import";
            this.mnuFileImport.Click += new System.EventHandler(this.mnuFileImport_Click);
            // 
            // mnuAmend
            // 
            this.mnuAmend.Name = "mnuAmend";
            this.mnuAmend.Text = "Amend Import";
            this.mnuAmend.Click += new System.EventHandler(this.mnuAmend_Click);
            // 
            // mnuExport
            // 
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Text = "Generate Invoice";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 20);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(633, 65);
            this.radCommandBar1.TabIndex = 3;
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Name = "commandBarRowElement1";
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarSplitButton1,
            this.btnBackground,
            this.commandBarSeparator1,
            this.commandBarButton2,
            this.btnAdjustment,
            this.commandBarSeparator2,
            this.btnAddUser,
            this.commandBarSeparator3,
            this.commandBarLabel1,
            this.themeDropDownList});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // commandBarSplitButton1
            // 
            this.commandBarSplitButton1.DefaultItem = null;
            this.commandBarSplitButton1.DisplayName = "commandBarSplitButton1";
            this.commandBarSplitButton1.Image = global::SmartReconciliator.Properties.Resources.home;
            this.commandBarSplitButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuLogOut,
            this.munExit});
            this.commandBarSplitButton1.Name = "commandBarSplitButton1";
            this.commandBarSplitButton1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.commandBarSplitButton1.Text = "commandBarSplitButton1";
            // 
            // mnuLogOut
            // 
            this.mnuLogOut.Name = "mnuLogOut";
            this.mnuLogOut.Text = "Log Out";
            // 
            // munExit
            // 
            this.munExit.Name = "munExit";
            this.munExit.Text = "Exit";
            // 
            // btnBackground
            // 
            this.btnBackground.DisplayName = "commandBarButton1";
            this.btnBackground.Image = global::SmartReconciliator.Properties.Resources.Apps_background_icon;
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnBackground.Text = "commandBarButton1";
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // commandBarButton2
            // 
            this.commandBarButton2.DisplayName = "commandBarButton2";
            this.commandBarButton2.Image = global::SmartReconciliator.Properties.Resources.old_openofficeorg_calc;
            this.commandBarButton2.Name = "commandBarButton2";
            this.commandBarButton2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.commandBarButton2.Text = "commandBarButton2";
            // 
            // btnAdjustment
            // 
            this.btnAdjustment.DisplayName = "commandBarButton4";
            this.btnAdjustment.Image = global::SmartReconciliator.Properties.Resources.Apps_system_software_update_icon;
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnAdjustment.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAdjustment.Text = "commandBarButton4";
            this.btnAdjustment.Click += new System.EventHandler(this.btnAdjustment_Click);
            // 
            // commandBarSeparator2
            // 
            this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
            this.commandBarSeparator2.Name = "commandBarSeparator2";
            this.commandBarSeparator2.VisibleInOverflowMenu = false;
            // 
            // btnAddUser
            // 
            this.btnAddUser.DisplayName = "commandBarButton3";
            this.btnAddUser.Image = global::SmartReconciliator.Properties.Resources.iconfinder_user_group_new_23632;
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAddUser.Text = "commandBarButton3";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // commandBarSeparator3
            // 
            this.commandBarSeparator3.DisplayName = "commandBarSeparator3";
            this.commandBarSeparator3.Name = "commandBarSeparator3";
            this.commandBarSeparator3.VisibleInOverflowMenu = false;
            // 
            // commandBarLabel1
            // 
            this.commandBarLabel1.DisplayName = "commandBarLabel1";
            this.commandBarLabel1.Name = "commandBarLabel1";
            this.commandBarLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.commandBarLabel1.Text = "Application GUI Styling";
            // 
            // themeDropDownList
            // 
            this.themeDropDownList.DisplayName = "commandBarDropDownList1";
            this.themeDropDownList.DropDownAnimationEnabled = true;
            this.themeDropDownList.MaxDropDownItems = 0;
            this.themeDropDownList.Name = "themeDropDownList";
            this.themeDropDownList.Text = "";
            this.themeDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.themeDropDownList_SelectedIndexChanged);
            // 
            // timerAutoLogOut
            // 
            this.timerAutoLogOut.Interval = 1000;
            this.timerAutoLogOut.Tick += new System.EventHandler(this.timerAutoLogOut_Tick);
            // 
            // bgwTheme
            // 
            this.bgwTheme.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTheme_DoWork);
            this.bgwTheme.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTheme_RunWorkerCompleted);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 349);
            // 
            // radMenu1
            // 
            this.radMenu1.DropDownAnimationEnabled = true;
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuFileImport,
            this.mnuAmend,
            this.mnuExport});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(633, 20);
            this.radMenu1.TabIndex = 2;
            this.Controls.Add(this.radCommandBar1);
            this.Controls.Add(this.radMenu1);
            this.Controls.Add(this.radStatusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainWindow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "SMART Reconciliator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadMenuItem mnuFileImport;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarSplitButton commandBarSplitButton1;
        private Telerik.WinControls.UI.CommandBarButton btnBackground;
        private Telerik.WinControls.UI.RadMenuItem mnuAmend;
        private Telerik.WinControls.UI.RadMenuItem mnuExport;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
        private Telerik.WinControls.UI.CommandBarDropDownList themeDropDownList;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton2;
        private Telerik.WinControls.UI.CommandBarButton btnAddUser;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarButton btnAdjustment;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
        private System.Windows.Forms.Timer timerAutoLogOut;
        private Telerik.WinControls.UI.RadLabelElement lblUser;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator4;
        private Telerik.WinControls.UI.RadLabelElement lblDate;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator5;
        private Telerik.WinControls.UI.RadLabelElement lblTime;
        private System.ComponentModel.BackgroundWorker bgwTheme;
        private Telerik.WinControls.UI.RadMenuItem mnuLogOut;
        private Telerik.WinControls.UI.RadMenuItem munExit;
        private Telerik.WinControls.UI.RadMenu radMenu1;
    }
}
