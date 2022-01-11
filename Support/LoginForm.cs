using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace HMM.Pages
{
    public partial class LoginForm : CenteredForm
    {
        #region Variables & Properties
        private string role;
        private int UID;
        private string stationName;
        private int CentralPointID;


        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        // Test harness.
        // If you incorporate this code into a DLL, be sure to demand FullTrust.
        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        #endregion

        #region Form Events
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (CheckUserExist(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
            {

                SafeTokenHandle safeTokenHandle;
                try
                {
                    string userName, domainName, password;

                    userName = txtUserName.Text;
                    password = txtPassword.Text;

                    const int LOGON32_PROVIDER_DEFAULT = 0;
                    //This parameter causes LogonUser to create a primary token.
                    const int LOGON32_LOGON_INTERACTIVE = 2;

                    // Call LogonUser to obtain a handle to an access token.
                    //Tri: temp comment login logic
                    InstanceManagement.UserLoginInstance.Status = true;
                    InstanceManagement.UserLoginInstance.Username = userName;
                    InstanceManagement.UserLoginInstance.Password = password;
                    InstanceManagement.UserLoginInstance.Role = role;
                    InstanceManagement.UserLoginInstance.UID = UID;
                    InstanceManagement.UserLoginInstance.StationName = stationName;
                    InstanceManagement.UserLoginInstance.CentralPointID = CentralPointID;

                    InstanceManagement.MainFormInstance.ClearError(null, null);
                    InstanceManagement.MainFormInstance.EndLogin();
                    InstanceManagement.MainFormInstance.LoginSuccessful();
                    //bool returnValue = LogonUser(userName, Def.Domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out safeTokenHandle);

                    //if (false == returnValue)
                    //{
                    //    int ret = Marshal.GetLastWin32Error();
                    //    InstanceManagement.MainFormInstance.ShowError("Login failed!");
                    //    InstanceManagement.UserLoginInstance.Status = false;
                    //}
                    //else
                    ////{
                    ////    InstanceManagement.safeTokenHandle = safeTokenHandle;
                    ////    InstanceManagement.WindowsIdentity = new WindowsIdentity(safeTokenHandle.DangerousGetHandle());
                    ////    InstanceManagement.ImpersonationContext = InstanceManagement.WindowsIdentity.Impersonate();

                    ////    InstanceManagement.UserLoginInstance.Status = true;
                    ////    InstanceManagement.UserLoginInstance.Username = userName;
                    ////    InstanceManagement.UserLoginInstance.Password = password;
                    ////    InstanceManagement.UserLoginInstance.Role = role;
                    ////    InstanceManagement.UserLoginInstance.UID = UID;

                    ////    InstanceManagement.MainFormInstance.ClearError(null, null);
                    ////    InstanceManagement.MainFormInstance.EndLogin();
                    ////    InstanceManagement.MainFormInstance.LoginSuccessful();

                    ////    InstanceManagement.ActivityLoggerInstance.WriteLog(4, 0, "", "", "User: " + userName + " logged in", "0");
                    ////    this.Hide();
                    ////}

                    //    using (safeTokenHandle)
                    //    {
                    //        Console.WriteLine("Before impersonation: " + WindowsIdentity.GetCurrent().Name);
                    //        using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    //        {
                    //            using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                    //            {
                    //                Console.WriteLine("After impersonation: " + WindowsIdentity.GetCurrent().Name);
                    //                this.Hide(); 
                    //                //Form1 f = new Form1();
                    //                //f.Username = txtUserName.Text;
                    //                //f.ShowDialog();
                    //                InstanceManagement.UserLoginInstance.Status = true;
                    //                InstanceManagement.UserLoginInstance.Username = userName;
                    //                InstanceManagement.UserLoginInstance.Password = password;
                    //                InstanceManagement.UserLoginInstance.Role = role;
                    //                InstanceManagement.UserLoginInstance.UID = UID;

                    //                InstanceManagement.MainFormInstance.ClearError(null, null);
                    //                InstanceManagement.MainFormInstance.EndLogin();
                    //                InstanceManagement.MainFormInstance.LoginSuccessful();

                    //                InstanceManagement.ActivityLoggerInstance.WriteLog(4, 0, "", "", "User: " + userName + " logged in", "0");

                    //            }
                    //        }
                    //        Console.WriteLine("After closing the context: " + WindowsIdentity.GetCurrent().Name);
                    //    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred. " + ex.Message);
                }
            }
            else
            {
                InstanceManagement.ActivityLoggerInstance.WriteLog(4, 0, "", "", "Try to login by user: " + txtUserName.Text + " but not successful", "0");
                InstanceManagement.MainFormInstance.ShowError("Lỗi đăng nhập ! Sai tên đăng nhập hoặc mật khẩu!");
            }

            Cursor = Cursors.Arrow;
        }

        public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private SafeTokenHandle() : base(true)
            {
            }

            [DllImport("kernel32.dll")]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr handle);

            protected override bool ReleaseHandle()
            {
                return CloseHandle(handle);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnLogin.PerformClick();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //txtPassword.Text = "";
            //txtUserName.Text = "";
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region Business Logic
        private bool CheckUserExist(string loginName, string password)
        {

            try
            {

                var hashPwd = InstanceManagement.AccessGuard.ComputeSha256Hash(password);

                //Temporary check local login for first Passenger Managemeny function deployment
                /*string storedPwd = System.Configuration.ConfigurationManager.AppSettings[loginName];
                if (hashPwd == storedPwd)
                {
                    UID = 1;
                    role = ((int)Constants.Def.RolesEnum.Admin).ToString();
                }
                else
                    UID = 0; //access denied
                */

                DataTable dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spLogin", new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@UserName", loginName), new SqlParameter("@Password", hashPwd) });

                if (dt.Rows.Count > 0)
                {
                    UID = int.Parse(dt.Rows[0]["UserID"].ToString());
                    role = dt.Rows[0]["RuleID"].ToString();
                    stationName = "Trạm " + dt.Rows[0]["StationName"].ToString();
                   // var cID = int.TryParse(Convert.ToString(dt.Rows[0]["CentralPointID"]), out CentralPointID);
                }
                else
                    return false;


                if (UID == 0)
                    return false;   //User is deactived

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion
    }
}
