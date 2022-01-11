using HMM.Pages;
using HMM.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace HMM
{
    public partial class Main : Form
    {
       
        #region Variables & Properties
        Timer timerClock;
        Timer showInfoClock;
        Timer dataSyncClock;
        LoginForm tabLoginForm;
        bool isBusy = false;
        PopupNotifier TicketNotifier;
        string notificationID = "0";
        clsNotification noti;
        DataTable dtNotification;
        int numofNo;

        #endregion

        #region Form Events
        public Main()
        {
            InitializeComponent();
            //tabControlMain.Appearance = TabAppearance.FlatButtons;
            //tabControlMain.ItemSize = new Size(0, 1);
            //tabControlMain.SizeMode = TabSizeMode.Fixed;
            //this.panel1.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (noti != null)
                noti.Dispose();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

            //timerClock = new Timer();
            //timerClock.Interval = 1000;
            //timerClock.Tick += new EventHandler(ShowClock);
            //timerClock.Start();

            //dataSyncClock = new Timer();
            //dataSyncClock.Interval = 1000 * 60 * 30; // 30 minutes
            //dataSyncClock.Tick += new EventHandler(SyncData);
            //dataSyncClock.Start();

            ClearError(null, null);

            GetAppVersion();

            ShowLogin();
            //init notification
            //initNotification();
        }
        private void ShowLoginInfo()
        {
            //this.toolStripDatetime.Text = DateTime.Now.ToString(); -> No need to show clock, show station name instead


            //check user logged in and show user name
            if (InstanceManagement.UserLoginInstance.Status == true)
            {
                toolStripUserlogin.Text = InstanceManagement.UserLoginInstance.Username;
                toolStripRole.Text = "Đổi mật khẩu";
                this.toolStripDatetime.Text = InstanceManagement.UserLoginInstance.StationName;
            }
            else
            {
                toolStripUserlogin.Text = "";
                toolStripRole.Text = "";
                this.toolStripDatetime.Text = "";
            }
        }

        private void SyncData(object sender, EventArgs e)
        {
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(SyncDataThread);
            System.Threading.Thread t = new System.Threading.Thread(ts);
            t.Start();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ToanThangAdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerClock != null)
                timerClock.Stop();
            if (dataSyncClock != null)
                dataSyncClock.Stop();
            if (showInfoClock != null)
                showInfoClock.Stop();

            //new System.Threading.Thread(() => {
            //    //CallAgent.OnCallEventHandler -= OnCallEvent;
            //    CallAgent.StopAgent();
            //}).Start();


        }
        #endregion

        #region Business Logic

        //For faster render without blinking background
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        public void SyncDataThread()
        {
            //if (API.PingHost("103.9.159.154"))
             //   InstanceManagement.SQLHelperInstance.DataSync();
        }

        public void ShowError(string errorText)
        {
            this.lbError.Text = errorText;
            this.lbError.ForeColor = Color.Red;
            StartInfoClock();
        }

        public void ShowInfo(string errorText)
        {
            this.lbError.Text = errorText;
            this.lbError.ForeColor = Color.LightSkyBlue;
            StartInfoClock();
        }

        public void StartInfoClock()
        {
            //if (showInfoClock != null)
            //    showInfoClock.Stop();

            //showInfoClock = new Timer();
            //showInfoClock.Interval = 3000;
            //showInfoClock.Tick += new EventHandler(ClearError);
            //showInfoClock.Start();
        }

        public void ClearError(object sender, EventArgs e)
        {
            this.lbError.Text = "";

        }

        private void GetAppVersion()
        {
            //System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            //toolStripStatus.Text = "Build " + fvi.FileVersion;
            //toolStripStatus.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            try
            {
                string path = Directory.GetCurrentDirectory();
                var fileStream = new FileStream(path + "\\Version.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    toolStripStatus.Text = "Version " + streamReader.ReadToEnd();
                }
            }
            catch
            {

            }
        }
        private void AddChildForm(Form f)
        {
            //remove current showing form first
            foreach (Control ctl in this.panel1.Controls)
            {
                if (ctl is Form)
                {
                    this.panel1.Controls.Remove(ctl);
                    ctl.Dispose();
                    (ctl as Form).Close();
                }
            }
            panel1.Refresh();
            //add by Doc Ly
            //GC.Collect();
            //End
            //add child form
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //objForm.Dock = DockStyle.Fill;
            f.BringToFront();

            f.Show();
        }

        private void ToogleFunctionForUserPermission()
        {
            string userName = InstanceManagement.UserLoginInstance.Username;

            if (InstanceManagement.UserLoginInstance.Role.Equals("1"))
            {
                btnVehicle.Enabled = false;
                btnCustomer.Enabled = false;
                btnDriver.Enabled = false;
                btnEmployee.Enabled = true;
                btnSchedule.Enabled = false;
                btnPurchaseTicket.Enabled = false;
                btnInventory.Enabled = false;
                btnCentralPoint.Enabled = false;
                btnLogout.Visible = true;
            }

            
        }

        private void ResetButtonStatus()
        {
            foreach (Control c in flowLayoutPanel1.Controls)
                if (c is Button)
                {
                    c.Enabled = true;
                    c.BackColor = Color.Transparent;
                }

            ShowLoginInfo();

        }

        private void ResetButtonBackColor()
        {
            foreach (Control c in flowLayoutPanel1.Controls)
                if (c is Button)
                {
                    c.BackColor = Color.Transparent;
                }
        }


        #region Login------------------------------------------------------------------------------------------------------

        public void EndLogin()
        {
            if (tabLoginForm != null)
            {
                panel1.Controls.Remove(tabLoginForm);
                tabLoginForm.Close();
                ResetButtonStatus();
            }

        }

        public void ShowLogin()
        {
            //remove login form incase it already attached
            EndLogin();

            tabLoginForm = new LoginForm();

            AddChildForm(tabLoginForm);
        }

        public void LoginSuccessful()
        {
            btnInventory.Show();
            ShowInfo("Xin chào " + InstanceManagement.UserLoginInstance.Username + "!");
            ToogleFunctionForUserPermission();
            ShowLoginInfo();
            //add by Doc Ly: load dtnotification
            //loadNotification();

        }

        public bool VerifyLoginStatus()
        {
            if (InstanceManagement.UserLoginInstance.Status == false)
            {
                ShowError("Vui lòng đăng nhập!");
                ShowLogin();
                return false;
            }
            else
                return true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            InstanceManagement.ActivityLoggerInstance.WriteLog(4, 0, "", "", "User: " + InstanceManagement.UserLoginInstance.Username + " logged out", "0");

            //InstanceManagement.UserLoginInstance.Reset();
            //InstanceManagement.ImpersonationContext.Dispose();
            //InstanceManagement.safeTokenHandle.Close();
            //InstanceManagement.WindowsIdentity.Dispose();

            InstanceManagement.UserLoginInstance.Status = false;
            InstanceManagement.AccessGuard.Reset();

            this.btnLogout.Hide();
            ShowLogin();
        }




        #endregion --------------------------------------------------------------------------------------------------------

        #region Workstations ----------------------------------------------------------------------------------------------
        private void btnWorkstation_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            try
            {
                if (VerifyLoginStatus())
                {
                    //do stuffs
                    GuestForm ws = new GuestForm();
                    AddChildForm(ws);
                    ResetButtonBackColor();
                    btnCustomer.BackColor = Color.Silver;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error");
            }
            EnableControl(true);

        }

        #endregion --------------------------------------------------------------------------------------------------------

        #region Counter -------------------------------------------------------------------------------------------
        private void btnCounter_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            try
            {
                if (VerifyLoginStatus())
                {
                    //do stuffs
                    //VerhicleForm cf = new VerhicleForm();
                    //AddChildForm(cf);
                    //ResetButtonBackColor();
                    //btnVehicle.BackColor = Color.Silver;
                }
                //var process = Process.GetCurrentProcess();
                //var count = process.HandleCount;
                //MessageBox.Show("số handle: " + count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error");
            }
            EnableControl(true);
            //TicketNotifier.ContentText = "test";
            //TicketNotifier.TitleText = "Thông báo";
            //TicketNotifier.Popup();
        }

        #endregion

        #region Users ---------------------------------------------------------------------------------------------
        private void btnUser_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            try
            {
                if (VerifyLoginStatus())
                {
                    //do stuffs
                    //DriverForm uf = new DriverForm();
                    //AddChildForm(uf);
                    //ResetButtonBackColor();
                    //btnDriver.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error");
            }
            EnableControl(true);
        }
        #endregion

        #region Shift ---------------------------------------------------------------------------------------------
        private void btnShift_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            Application.DoEvents();
            try
            {
                if (VerifyLoginStatus())
                {
                    //do stuffs
                    EmployeeForm sf = new EmployeeForm();
                    AddChildForm(sf);
                    ResetButtonBackColor();
                    btnEmployee.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error");
            }
            EnableControl(true);
        }
        #endregion

        #region Trading Day ----------------------------------------------------------------------------------
        private void btnTradingday_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            try
            {
                if (VerifyLoginStatus())
                {
                    //do stuffs
                    //PurchaseTicketForm lm = new PurchaseTicketForm();
                    //AddChildForm(lm);

                    //ResetButtonBackColor();
                    //btnPurchaseTicket.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error");
            }
            //System.Threading.Thread.Sleep(1000);
            EnableControl(true);
        }
        #endregion

        #region Reports ------------------------------------------------------------------------------
        private void btnReport_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            try
            {
                if (VerifyLoginStatus())
                {
                    //do stuffs
                    //GuestAssignmentForm rf = new GuestAssignmentForm();
                    //AddChildForm(rf);
                    //ResetButtonBackColor();
                    //btnGuestAssignment.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error");
            }
            EnableControl(true);
        }
        #endregion

        #region Patron --------------------------------------------------------------------------------------------
        private void btnPatron_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            try
            {
                if (VerifyLoginStatus())
                {
                    //do stuffs
                    //ScheduleForm pf = new ScheduleForm();
                    //AddChildForm(pf);
                    //ResetButtonBackColor();
                    //btnSchedule.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error");
            }
            //System.Threading.Thread.Sleep(1000);
            EnableControl(true);
        }
        #endregion

        #region Change Password -------------------------------------------------------------------------------
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpf = new ChangePasswordForm();
            AddChildForm(cpf);

        }
        #endregion

        #region Inventory -------------------------------------------
        private void btnInventory_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            try
            {
                if (VerifyLoginStatus())
                {
                    //InventoryForm ivf = new InventoryForm();
                    //AddChildForm(ivf);
                    //ResetButtonBackColor();
                    //btnInventory.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error");
            }
            EnableControl(true);
        }
        #endregion

        #endregion

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripRole_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpf = new ChangePasswordForm();
            cpf.ShowDialog();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Handle != null)
            {
                BeginInvoke(new MethodInvoker(ChangeSize));
            }
        }
        protected void ChangeSize()
        {
            //if (this.WindowState == FormWindowState.Normal)
            {
                this.Invalidate(true);
                this.Update();
                foreach (Control c in this.Controls)
                {
                    c.Invalidate(true);
                    c.Update();
                }

            }



            this.btnClose.Left = this.Right - this.btnClose.Width - 10;
            this.pbTitle.Left = (this.Width - this.pbTitle.Width) / 2;


            this.btnMinimize.Left = this.btnClose.Left - 40;
            this.btnMinimize.Top = this.btnClose.Top;
        }

        //code by Doc Ly
        private void EnableControl(bool isEnable)
        {
            try
            {
                //foreach (Control c in flowLayoutPanel1.Controls)
                //    if (c is Button)
                //    {
                //        c.Enabled = isEnable;
                //    }
                Cursor = isEnable ? Cursors.Default : Cursors.WaitCursor;
                //if (isEnable)
                //{
                //    Cursor.Show();
                //}
                //else Cursor.Hide();
                this.Enabled = isEnable;
            }
            catch
            { }
        }

        private void btnCentralPoint_Click(object sender, EventArgs e)
        {
            try
            {
                EnableControl(false);
                try
                {
                    if (VerifyLoginStatus())
                    {
                        //var ivf = new CentralPointForm();
                        //AddChildForm(ivf);
                        //ResetButtonBackColor();
                        //btnCentralPoint.BackColor = Color.Silver;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Error");
                }
                EnableControl(true);
                //var ivf = new CentralPointForm();
                //ivf.ShowDialog();
                //ivf.Dispose();
            }
            catch (Exception ex)
            { }
        }

        private void toolStripNotification_Click(object sender, EventArgs e)
        {
            try
            {
                //var frm = new TicketNotificationForm();
                //var CurrentFrm = panel1.Controls.OfType<Form>().FirstOrDefault();
                //frm.CurrentFormIsPurchase = (CurrentFrm != null && CurrentFrm is PurchaseTicketForm);
                //frm.ShowDialog();
                //toolStripNotification.Text = string.Format("Thông báo ({0})", frm.numofNo);
                //if (CurrentFrm is PurchaseTicketForm && !string.IsNullOrEmpty(frm.ticketID))
                //    ((PurchaseTicketForm)CurrentFrm).getTicketOfGuest(frm.ticketID, frm.guestPhone);
                //frm.Dispose();

            }
            catch (Exception ex)
            {
            }
        }

        private void initNotification()
        {
            try
            {
                TicketNotifier = new PopupNotifier();
                TicketNotifier.Delay = 5000;
                TicketNotifier.AnimationInterval = 1000;
                TicketNotifier.AnimationDuration = 2;
                TicketNotifier.Scroll = true;
                //TicketNotifier.Image = Properties.Resources.iconfinder_notifications_active_64;
                //sql dependency
                var query = "SELECT [ID],[MainContent] FROM [dbo].[TicketNotification]";
                //var contr = @"Data Source=" + ConfigurationManager.AppSettings["server"] + ";Initial Catalog=HMMNGT;User Id=sa; Password=Passgidayt@;";
                noti = new clsNotification(showNotification, query, InstanceManagement.SQLHelperInstance.ConnectionString);
                noti.loadData();
            }
            catch (Exception ex)
            {
            }
        }

        private void TicketNotifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (notificationID != "0")
                {
                    API.UpdateTicketNotificationRead(notificationID);
                    notificationID = "0";
                    TicketNotifier.Hide();
                    toolStripNotification.Text = string.Format("Thông báo ({0})", numofNo - 1);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void loadNotification()
        {
            try
            {
                dtNotification = API.GetTicketNotification();
                numofNo = dtNotification.Rows.Count;
                toolStripNotification.Text = String.Format("Thông báo ({0})", numofNo);
            }
            catch (Exception ex)
            {
            }
        }

        private void showNotification()
        {
            try
            {
                var dtNewNotification = API.GetTicketNotification();
                numofNo = dtNewNotification.Rows.Count;
                if (numofNo > 0)
                {
                    var noID = dtNewNotification.Rows[0]["ID"].ToString();
                    var existNo = dtNotification.AsEnumerable().FirstOrDefault(f => f["ID"].ToString() == noID);
                    if (existNo != null)
                        return;
                    notificationID = noID;
                    TicketNotifier.TitleText = "Thông báo";
                    TicketNotifier.ContentText = dtNewNotification.Rows[0]["MainContent"].ToString();
                    TicketNotifier.Click += TicketNotifier_Click;
                    toolStripNotification.Text = string.Format("Thông báo ({0})", numofNo);
                    this.Invoke((MethodInvoker)delegate
                    {
                        TicketNotifier.Popup();
                    });
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
