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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMM.Pages
{
    public partial class ChangePasswordForm : CenteredForm
    {

        #region Variables & Properties
        private string role;
        private int UID;

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
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string result = ChangeUserPassword(txtOldPassword.Text, txtPassword.Text, txtRepPassword.Text);

            if (result != "")
            {
                InstanceManagement.MainFormInstance.ShowError(result);
            }
            else
            {
                InstanceManagement.MainFormInstance.ShowInfo("Đổi mật khẩu thành công!");
                InstanceManagement.UserLoginInstance.Password = txtPassword.Text;
                txtOldPassword.Text = "";
                txtPassword.Text = "";
                txtRepPassword.Text = "";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnChange.PerformClick();
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //txtPassword.Text = "";
            //txtUserName.Text = "";
            txtOldPassword.Focus();

            this.Size = new Size(638, 307);
        }
        private void LoginForm_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region Business Logic

        private string ChangeUserPassword(string oldPwd, string newPwd, string repPwd)
        {
            //Check old password
            if (!oldPwd.Equals(InstanceManagement.UserLoginInstance.Password))
                return "Mật khẩu hiện tại không đúng!";
            //Check retype password
            if (!newPwd.Equals(repPwd))
                return "Mật khẩu mới nhập lại không giống!";

            //Change password on AD
            try
            {
                //using (var context = new PrincipalContext(ContextType.Domain))
                //{
                //    using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, InstanceManagement.UserLoginInstance.Username))
                //    {
                //        user.ChangePassword(oldPwd, newPwd);
                //        user.Save();
                //    }
                //}

                InstanceManagement.SQLHelperInstance.ExecStoreProcedure("spChangePassword", new SqlParameter[] {
                    new SqlParameter("@Username", InstanceManagement.UserLoginInstance.Username),
                    new SqlParameter("@Password", InstanceManagement.AccessGuard.ComputeSha256Hash(newPwd))
                });

            }
            catch (Exception ex)
            {
                return "Đổi mật khẩu thất bại!";
            }


            return "";//successful change

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
        #endregion

    }
}
