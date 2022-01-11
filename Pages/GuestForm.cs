using HMM.DataModels;
using HMM.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMM.Pages
{
    public partial class GuestForm : CenteredForm
    {

        #region Variables & Properties
        DataTable dtDeparture, dtArrival, dtGuestInfo;
        GuestProfile objGuest = new GuestProfile();
        List<GuestTrip> objListGuestTrip = new List<GuestTrip>();
        int GuestTripID = 0;
        #endregion

        #region Form Events
        public GuestForm()
        {
            InitializeComponent();
        }
        private void GuestForm_Load(object sender, EventArgs e)
        {
            //ReloadCBBPhone();
            //ReloadCBBDeparture();
            //ReloadGridGuestTripByDate();
            //GuestTripID = InstanceManagement.SQLHelperInstance.SQLite_GetLastGuestTripID();
            //cbbPhoneNmbr.Focus();
        }
        private void cbbPhoneNmbr_TextChanged(object sender, EventArgs e)
        {
            var result = dtGuestInfo
                        .AsEnumerable()
                        .Where(myRow => myRow.Field<string>("PhoneNumber") == cbbPhoneNmbr.Text.ToString());

            if (result.Count() > 0)

            {
                DataTable tempTable = result.CopyToDataTable();
                txtFirstName.Text = tempTable.Rows[0]["FirstName"].ToString();
                txtLastName.Text = tempTable.Rows[0]["LastName"].ToString();
                txtAddress.Text = tempTable.Rows[0]["Address"].ToString();
            }
            else
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            InstanceManagement.ExportDataInstance.ExportToExcel(dgGuestTrip);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                GuestTripID += 1;
                objGuest.FirstName = txtFirstName.Text;
                objGuest.LastName = txtLastName.Text;
                objGuest.PhoneNumber = cbbPhoneNmbr.Text;
                objGuest.Address = txtAddress.Text;
                if (API.AddNewGuestLocal(objGuest, GuestTripID, cbbDeparture.SelectedValue.ToString(), cbbArrival.SelectedValue.ToString()))
                {
                    MessageBox.Show("Thêm dữ liệu thành công! ", "Thành công", MessageBoxButtons.OK);
                    //string[] row = new string[] { objGuest.LastName, objGuest.FirstName, objGuest.PhoneNumber,cbbDeparture.Text, cbbArrival.Text };
                    ReloadGridGuestTripByDate();
                    Reset();
                    //InstanceManagement.SQLHelperInstance.DataSync();
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu bị lỗi, xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK);
                    this.btnAdd.Focus();
                }
            }
        }
        #endregion

        #region Business Logic
        private void ReloadCBBPhone()
        {
            //cbbPhoneNmbr.DataSource = null;
            //dtGuestInfo = InstanceManagement.SQLHelperInstance.SQLite_GetAllGuestProfile();
            //cbbPhoneNmbr.DataSource = dtGuestInfo;
            //cbbPhoneNmbr.DisplayMember = dtGuestInfo.Columns["PhoneNumber"].ToString();
            //cbbPhoneNmbr.ValueMember = dtGuestInfo.Columns["PhoneNumber"].ToString();
            //cbbPhoneNmbr.Text = "";
            //cbbPhoneNmbr.Refresh();

        }
        private void ReloadCBBDeparture()
        {
            string strStation = System.Configuration.ConfigurationManager.AppSettings["Stations"].ToString();
            string[] stations = strStation.Split(',');
            dtDeparture = new DataTable();
            dtDeparture.Columns.Add(new DataColumn("StationID", typeof(string)));
            dtDeparture.Columns.Add(new DataColumn("StationName", typeof(string)));

            for (int i = 0; i < stations.Length; i++)
            {
                DataRow r = dtDeparture.NewRow();
                r["StationID"] = (i + 1).ToString();
                r["StationName"] = stations[i];
                dtDeparture.Rows.Add(r);
            }
            dtArrival = dtDeparture.Copy();
            cbbDeparture.DataSource = null;
            cbbDeparture.DataSource = dtDeparture;
            cbbDeparture.DisplayMember = dtDeparture.Columns["StationName"].ToString();
            cbbDeparture.ValueMember = dtDeparture.Columns["StationID"].ToString();
            cbbDeparture.SelectedIndex = 0;
            cbbDeparture.Refresh();
            cbbArrival.DataSource = null;
            cbbArrival.DataSource = dtArrival;
            cbbArrival.DisplayMember = dtArrival.Columns["StationName"].ToString();
            cbbArrival.ValueMember = dtArrival.Columns["StationID"].ToString();
            cbbArrival.SelectedIndex = 0;
            cbbArrival.Refresh();
        }
        private void ReloadGridGuestTripByDate()
        {
            dgGuestTrip.DataSource = null;
            objListGuestTrip = API.GetGuestTrip;
            dgGuestTrip.DataSource = objListGuestTrip;
            dgGuestTrip.Refresh();
            lbCount.Text = "Khách đi trong ngày (" + dgGuestTrip.Rows.Count.ToString() + ")";
        }

        private Boolean Validation()
        {
            bool bRet = true;
            if (this.cbbPhoneNmbr.Text == string.Empty)
            {
                MessageBox.Show("Số điện thoại không được bỏ trống", "Lỗi", MessageBoxButtons.OK);
                this.cbbPhoneNmbr.Focus();
                return false;
            }
            /*
            if (this.txtLastName.Text == string.Empty)
            {
                MessageBox.Show("Họ không được bỏ trống", "Lỗi", MessageBoxButtons.OK);
                this.txtLastName.Focus();
                return false;
            }

            if (this.txtFirstName.Text == string.Empty)
            {
                MessageBox.Show("Tên không được bỏ trống", "Lỗi", MessageBoxButtons.OK);
                this.txtFirstName.Focus();
                return false;
            }
            */
            if (this.cbbDeparture.Text == this.cbbArrival.Text)
            {
                MessageBox.Show("Điểm đi và điểm đến không được giống nhau", "Lỗi", MessageBoxButtons.OK);
                this.cbbDeparture.Focus();
                return false;
            }
            return bRet;
        }
        private void Reset()
        {
            cbbPhoneNmbr.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
        }
        #endregion
    }
}
