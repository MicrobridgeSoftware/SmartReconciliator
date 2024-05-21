using ApplicationSecurity;
using ApplicationSecurity.SecurityUtils;
using ApplicationSecurity.UI.Forms;
using SmartReconciliator.Adjustment;
using SmartReconciliator.ApplicationUtil;
using SmartReconciliator.Export;
using SmartReconciliator.FileAmendment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace SmartReconciliator
{
    public partial class MainWindow : Telerik.WinControls.UI.RadForm
    {
        CurrentUserCredentials _credentials = new CurrentUserCredentials();
        ContractorManagementEntities dbContext = new ContractorManagementEntities();
        private SystemSecurityConfiguration _securityConfig;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            lblUser.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblTime.Text = string.Empty;

            mnuLogOut.Click += new EventHandler(PerformLogOut);
            munExit.Click += new EventHandler(PerformExit);

            _securityConfig = dbContext.SystemSecurityConfigurations.AsNoTracking().FirstOrDefault();

            bgwTheme.RunWorkerAsync();

            UserLoginForm _login = new UserLoginForm(_credentials);
            _login.ShowDialog();
            
            //int _userValueCount = _credentials._userCredentials().Count;

            //if (_userValueCount == 0)
            //{
            //    mnuSecurity.Enabled = false;
            //    mnuTransaction.Enabled = false;
            //    mnuMaintenance.Enabled = false;
            //    mnuReport.Enabled = false;
            //    return;
            //}

            lblUser.Text = "Currently Logged in : " + _credentials.getFirstName() + " " + _credentials.getLastName();
            lblDate.Text = "Date Logged in : " + DateTime.Today.ToLongDateString();
            lblTime.Text = "Time Logged in : " + DateTime.Now.ToShortTimeString();

            ApplicationSecurityConstants._activeUser = _credentials._loggedInUserName();
                      
            using (ContractorManagementEntities DBContext = new ContractorManagementEntities())
            {
                var _getUserImage = DBContext.SystemUserSettings.Where(x => x.UserName.Trim() == ApplicationSecurityConstants._activeUser).FirstOrDefault();

                if (_getUserImage != null)
                {
                    Bitmap bmp2;
                    var bytes2 = (byte[])_getUserImage.MdiParentImage;
                    MemoryStream ms2 = new MemoryStream(bytes2);
                    bmp2 = new Bitmap(ms2);
                    this.BackgroundImage = bmp2;

                    ms2.Flush();
                    ms2.Dispose();
                }
            }

            //EnableUserControls();

            timerAutoLogOut.Enabled = true;
        }

        private void mnuFileImport_Click(object sender, EventArgs e)
        {
            FrmFileImport fileImport = new FrmFileImport();
            fileImport.MdiParent = this;
            fileImport.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                return;
            }

            //using (AttendanceManagerEntities DBContext2 = new AttendanceManagerEntities())
            //{
            //    if (ApplicationSecurityConstants._activeUser != null)
            //    {
            //        var _updateUserLoginStatus = DBContext2.SystemUsers.Where(x => x.UserName == ApplicationSecurityConstants._activeUser).FirstOrDefault();

            //        if (_updateUserLoginStatus != null)
            //        {
            //            _updateUserLoginStatus.CurrentlyLoggedIn = false;
            //            DBContext2.SaveChanges();
            //        }
            //    }
            //}

            //dbContext.Dispose();
            memoryManagement.FlushMemory();
        }

        private void mnuExport_Click(object sender, EventArgs e)
        {
            FrmGenerateBill generateBill = new FrmGenerateBill();
            generateBill.MdiParent = this;
            generateBill.Show();
        }

        private void bgwTheme_DoWork(object sender, DoWorkEventArgs e)
        {
            var themefiles = Directory.GetFiles(System.Windows.Forms.Application.StartupPath, "Telerik.WinControls.Themes.*.dll");

            foreach (var theme in themefiles)
            {
                var themeAssembly = Assembly.LoadFile(theme);

                var themeType = themeAssembly.GetTypes().Where(_themes => typeof(RadThemeComponentBase).IsAssignableFrom(_themes)).FirstOrDefault();

                if (themeType != null)
                {
                    RadThemeComponentBase themeObject = (RadThemeComponentBase)Activator.CreateInstance(themeType);

                    if (themeObject != null)
                    {
                        themeObject.Load();
                    }
                }
            }
        }

        private void bgwTheme_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var _themeList = ThemeRepository.AvailableThemeNames.ToList();
            string _defaultThemeName = string.Empty;

            if (_themeList.Count > 0)
            {
                //RadDropDownListElement comboBoxElement = new RadDropDownListElement();
                themeDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(themeDropDownList_SelectedIndexChanged);

                themeDropDownList.Items.Add("Default");

                foreach (var _theme in _themeList)
                    themeDropDownList.Items.Add(_theme);

                themeDropDownList.MinSize = new Size(200, 20);
                //this.radStatusStrip1.Items.Add(comboBoxElement);

                _defaultThemeName = "Default";
                themeDropDownList.SelectedIndex = themeDropDownList.Items.IndexOf(themeDropDownList.Items.First(x => x.Text == _defaultThemeName));
            }
            //ddlTheme.DataSource = themeList;

            //string _defaultThemeName = "Default";
            //comboBoxElement.SelectedIndex = comboBoxElement.Items.IndexOf(comboBoxElement.Items.First(x => x.Text == _defaultThemeName));
            memoryManagement.FlushMemory();
        }

        private void btnBackground_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";

            if (openFileDialog.ShowDialog(this.Parent) == DialogResult.OK)
            {
                byte[] data;
                Bitmap bmp;

                string fileName = openFileDialog.FileName;

                FileStream fs = File.OpenRead(fileName);
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);

                MemoryStream ms = new MemoryStream(data);
                bmp = new Bitmap(ms);
                this.BackgroundImage = bmp;

                DialogResult _defaultImage = RadMessageBox.Show("Do you want to continuously use this image as your Wallpaper?",
                                             Application.ProductName, MessageBoxButtons.YesNo);

                if (_defaultImage == System.Windows.Forms.DialogResult.Yes)
                {
                    using (ContractorManagementEntities dbContext = new ContractorManagementEntities())
                    {
                        var _userImage = dbContext.SystemUserSettings.Where(x => x.UserName.Trim() == ApplicationSecurityConstants._activeUser).FirstOrDefault();

                        if (_userImage == null)
                        {
                            SystemUserSetting _saveBackgroundImage = new SystemUserSetting();
                            _saveBackgroundImage.MdiParentImage = data;
                            _saveBackgroundImage.UserName = ApplicationSecurityConstants._activeUser;
                            dbContext.SystemUserSettings.Add(_saveBackgroundImage);
                        }
                        else
                        {
                            _userImage.MdiParentImage = data;
                        }

                        dbContext.SaveChanges();
                    }
                }
            }
        }

        private void PerformExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PerformLogOut(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblUser.Text))
                return;
            
            PerformApplicationLogOut();
        }

        private void timerAutoLogOut_Tick(object sender, EventArgs e)
        {
            if (_securityConfig != null && _securityConfig.EnableAutoLogOut == true)
            {
                int autoLogoutTimeInSeconds = _securityConfig.AutoLogOutMinutes * 60;
                uint lastInputTime = EnvironmentUtils.GetLastInputTime();

                if (ApplicationSecurityConstants._activeUser != null && lastInputTime >= autoLogoutTimeInSeconds)
                    PerformApplicationLogOut();
            }
        }

        private void PerformApplicationLogOut()
        {
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name != "MainWindow")
                    Application.OpenForms[index].Close();
            }

            lblUser.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblTime.Text = string.Empty;

            using (ContractorManagementEntities DBContexT = new ContractorManagementEntities())
            {
                if (ApplicationSecurityConstants._activeUser != null)
                {
                    var _updateUserLoginStatus = DBContexT.SystemUsers.Where(x => x.UserName == ApplicationSecurityConstants._activeUser).FirstOrDefault();

                    if (_updateUserLoginStatus != null)
                    {
                        _updateUserLoginStatus.CurrentlyLoggedIn = false;
                        DBContexT.SaveChanges();
                    }
                }
            }

            this.BackgroundImage = null;

            timerAutoLogOut.Enabled = false;

            _credentials = new CurrentUserCredentials();

            memoryManagement.FlushMemory();

            UserLoginForm _login = new UserLoginForm(_credentials);
            _login.ShowDialog();

            //int _userValueCount = _credentials._userCredentials().Count;

            //if (_userValueCount == 0)
            //{
            //    mnuSecurity.Enabled = false;
            //    mnuTransaction.Enabled = false;
            //    mnuMaintenance.Enabled = false;
            //    mnuReport.Enabled = false;
            //    return;
            //}

            lblUser.Text = "Currently Logged in : " + _credentials.getFirstName() + " " + _credentials.getLastName();
            lblDate.Text = "Date Logged in : " + DateTime.Today.ToLongDateString();
            lblTime.Text = "Time Logged in : " + DateTime.Now.ToShortTimeString();

            ApplicationSecurityConstants._activeUser = _credentials._loggedInUserName();

            GetUserSettingsForLogin();

            //EnableUserControls();

            timerAutoLogOut.Enabled = true;
        }

        private void themeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RadDropDownListElement _element = sender as RadDropDownListElement;

            string strTheme = _element.Text;

            Theme theme = ThemeResolutionService.GetTheme(strTheme);

            if (theme != null && ApplicationSecurityConstants._activeUser != null)
            {
                ThemeResolutionService.ApplicationThemeName = theme.Name;
            }
        }

        private void GetUserSettingsForLogin()
        {
            if (_credentials.getAccountConfig() == true)
            {
                using (ContractorManagementEntities DB = new ContractorManagementEntities())
                {
                    DateTime _accountExpDate = (DateTime)DB.SystemUserViews.Where(x => x.UserName.Trim() == ApplicationSecurityConstants._activeUser)
                                                                           .Select(x => x.AccountExpirationDate).First();
                }
            }

            if (_credentials.getImageData() != null)
            {
                Bitmap bmp;
                var bytes = (byte[])_credentials.getImageData();
                MemoryStream ms = new MemoryStream(bytes);
                bmp = new Bitmap(ms);

                ms.Flush();
                ms.Dispose();
            }

            using (ContractorManagementEntities DBContext = new ContractorManagementEntities())
            {
                var _getUserImage = DBContext.SystemUserSettings.Where(x => x.UserName.Trim() == ApplicationSecurityConstants._activeUser).FirstOrDefault();

                if (_getUserImage != null)
                {
                    Bitmap bmp2;
                    var bytes2 = (byte[])_getUserImage.MdiParentImage;
                    MemoryStream ms2 = new MemoryStream(bytes2);
                    bmp2 = new Bitmap(ms2);
                    this.BackgroundImage = bmp2;

                    ms2.Flush();
                    ms2.Dispose();
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            SystemUserForm _addSysUser = new SystemUserForm();
            _addSysUser.MdiParent = this;
            _addSysUser.Show();
        }

        private void mnuAmend_Click(object sender, EventArgs e)
        {
            FrmRemoveImport removeImport = new FrmRemoveImport();
            removeImport.MdiParent = this;
            removeImport.Show();
        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            FrmTransactionAdjustment adjustment = new FrmTransactionAdjustment();
            adjustment.MdiParent = this;
            adjustment.Show();
        }
    }
}