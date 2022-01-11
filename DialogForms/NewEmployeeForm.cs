using HMM.DataModels;
using HMM.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMM.DialogForms
{
    public partial class NewEmployeeForm : Form
    {
        #region Variables & Properties
        List<EmployeeContract> myEmployeeContract;
        List<EmployeeType> myEmployeeType;
        List<Station> myStation;
        DataTable dtArea, dtBDPlace, dtDep;
        public Employee objEmployee = new Employee();
        public DataTable dtEmployees;
        public string szMode = "Add";
        public bool bActived = true;
        bool bNewImage = false;
        #endregion

        #region Form Events
        public NewEmployeeForm()
        {
            InitializeComponent();

        }

        private void NewEmployeeForm_Load(object sender, EventArgs e)
        {

            this.CenterToScreen();
            PrepareData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                objEmployee.FirstName = txtFirstName.Text.Trim();
                objEmployee.MiddleName = txtMiddleName.Text.Trim();
                objEmployee.LastName = txtLastName.Text.Trim();
                objEmployee.PhoneNumber = txtPhoneNmbr.Text.Trim();
               // objEmployee.Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
                objEmployee.Gender = cbbGender.SelectedValue.ToString();
                objEmployee.StationID = cbbStation.SelectedValue.ToString();
                objEmployee.Role = "1";
                objEmployee.Status = "1";
                objEmployee.Luong =txtLuong.Text.Trim();
                objEmployee.StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
                objEmployee.Address = txtAddress.Text.Trim();
                string employeeImage = "";

                if (szMode == "Add")
                {
                    //if (pictureBox1.ImageLocation != null && pictureBox1.ImageLocation != "")
                    //{
                    //    try
                    //    {
                    //        string path = Directory.GetCurrentDirectory() + @"\Image\";
                    //        //string sqlGetUID = String.Format("select max (uid) as uid from Employee");
                    //        //string szRet = InstanceManagement.SQLHelperInstance.ExecSQL_GetFirstValue(sqlGetUID);
                    //        string szRet = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetFirstValue("spGetMaxEmployeeID",
                    //            new System.Data.SqlClient.SqlParameter[] { });

                    //        long uid = long.Parse(szRet) + 1;
                    //        string filename = "E_" + uid.ToString() + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                    //        string filepath = path + filename;
                    //        FileInfo f1 = new FileInfo(pictureBox1.ImageLocation.ToString());
                    //        employeeImage = filepath + f1.Extension;
                    //    }
                    //    catch
                    //    {

                    //    }

                    //}

                   // objEmployee.EmployeeImage = employeeImage;
                    if (API.AddNewEmployee(objEmployee))
                    {
                        MessageBox.Show("Thêm dữ liệu thành công! ", "Thành công", MessageBoxButtons.OK);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu bị lỗi, xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK);
                        this.btnAdd.Focus();
                    }
                }
                else
                {
                    if (pictureBox1.ImageLocation != null && pictureBox1.ImageLocation != "")
                    {
                        try
                        {
                            FileInfo f1 = new FileInfo(pictureBox1.ImageLocation.ToString());
                            string path = Directory.GetCurrentDirectory() + @"\Image\";
                            string filename = "E_" + objEmployee.uid + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                            string filepath = path + filename;
                            if (bNewImage)
                            {
                                objEmployee.EmployeeImage = filepath + f1.Extension;
                                if (f1.Exists)
                                {
                                    if (!Directory.Exists(path))
                                    {
                                        Directory.CreateDirectory(path);
                                    }
                                    f1.CopyTo(string.Format("{0}{1}{2}", path, filename, f1.Extension));
                                }
                            }
                        }
                        catch
                        {
                            // MessageBox.Show("Hình nhân viên bị lỗi, vui lòng kiểm tra lại ", "Lỗi", MessageBoxButtons.OK);
                        }

                    }

                    if (API.EditEmployee(objEmployee))
                    {


                        MessageBox.Show("Chỉnh sửa dữ liệu thành công! ", "Thành công", MessageBoxButtons.OK);
                        bActived = false;
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa dữ liệu bị lỗi, xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK);
                        this.btnAdd.Focus();
                    }
                }

            }
        }
        private void btnPicture_Click(object sender, EventArgs e)
        {

            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.ShowDialog();

            openFileDialog1.Multiselect = false;
            foreach (String file in openFileDialog1.FileNames)
            {
                bNewImage = true;
                pictureBox1.ImageLocation = file;
            }

        }

        private void NewEmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bActived = false;
        }

        private void txtPhoneNmbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Business Logic

       
        private Boolean Validation()
        {
            bool bRet = true;
            string szIgnorePatern = (@"[!@#$%^&*()_+=\[{\]};:<>|./?,-1234567890]");
            string szPhonePatern = "[^0-9]";
            //if (txtLastName.Text.Length < 1 || Regex.IsMatch(txtLastName.Text.Trim(), szIgnorePatern))
            //{
            //    MessageBox.Show("Họ không hợp lệ.", "Lỗi", MessageBoxButtons.OK);
            //    this.txtLastName.Focus();
            //    return false;
            //}


            //if (txtMiddleName.Text.Length > 0 && Regex.IsMatch(txtMiddleName.Text.Trim(), szIgnorePatern))
            //{
            //    MessageBox.Show("Tên lót không hợp lệ.", "Lỗi", MessageBoxButtons.OK);
            //    this.txtMiddleName.Focus();
            //    return false;
            //}
            if (txtFirstName.Text.Length < 1 || Regex.IsMatch(txtFirstName.Text.Trim(), szIgnorePatern))
            {
                MessageBox.Show("Tên không hợp lệ.", "Lỗi", MessageBoxButtons.OK);
                this.txtFirstName.Focus();
                return false;
            }

            if (txtPhoneNmbr.Text.Length < 1 || Regex.IsMatch(txtPhoneNmbr.Text.Trim(), szPhonePatern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK);
                this.txtPhoneNmbr.Focus();
                return false;
            }
            if (txtLuong.Text.Length < 1 || Regex.IsMatch(txtLuong.Text.Trim(), szPhonePatern))
            {
                MessageBox.Show("Lương không hợp lệ.", "Lỗi", MessageBoxButtons.OK);
                this.txtLuong.Focus();
                return false;
            }
         
            //if (this.txtAreaCode.Text == string.Empty)
            //{
            //    MessageBox.Show("Thường trú không được bỏ trống", "Lỗi", MessageBoxButtons.OK);
            //    this.txtAreaCode.Focus();
            //    return false;
            //}

            //if (this.txtBdPlace.Text == string.Empty)
            //{
            //    MessageBox.Show("Nơi sinh không được bỏ trống", "Lỗi", MessageBoxButtons.OK);
            //    this.txtBdPlace.Focus();
            //    return false;
            //}
            //DateTime bday = dtpBirthday.Value;
            //DateTime today = DateTime.Today;
            //int age = today.Year - bday.Year;
            //if (age < 18)
            //{
            //    MessageBox.Show("Nhân viên chưa đủ tuổi.", "Lỗi", MessageBoxButtons.OK);
            //    this.dtpBirthday.Focus();
            //    return false;

            //}


            if (this.cbbGender.Text == string.Empty)
            {
                MessageBox.Show("Giới tính không được bỏ trống", "Lỗi", MessageBoxButtons.OK);
                this.cbbGender.Focus();
                return false;
            }

            if (dtpStartDate.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("Ngày bắt đầu làm việc không hợp lệ.", "Lỗi", MessageBoxButtons.OK);
                this.dtpStartDate.Focus();
                return false;

            }

            //if (dtpEndDate.Value.Date > DateTime.Today.Date)
            //{
            //    MessageBox.Show("Ngày nghỉ việc không hợp lệ.", "Lỗi", MessageBoxButtons.OK);
            //    this.dtpEndDate.Focus();
            //    return false;

            //}


           
            if (szMode == "Edit" &&  objEmployee.PhoneNumber == txtPhoneNmbr.Text.Trim())
            {
                return bRet;
            }
            else
            {
                int iRet = CheckValidEmployee();
                if (iRet == 1)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại.", "Lỗi", MessageBoxButtons.OK);
                    this.txtPhoneNmbr.Focus();
                    return false;
                }
                
            }
            return bRet;
        }
        private int CheckValidEmployee()
        {
            int iRet = 0;
            if (szMode == "Add")
            {
                DataRow[] rEmpByPhoneNmbr = dtEmployees.Select("SoDienThoai = '" + txtPhoneNmbr.Text.Trim() + "'");
                if (rEmpByPhoneNmbr.Length != 0)
                {
                    return iRet = 1;
                }
              
            }
            else
            {
                DataRow[] rTemp = dtEmployees.Select("SoDienThoai <> '" + objEmployee.PhoneNumber + "'");
                DataTable dtTemp = rTemp.CopyToDataTable();

                DataRow[] rEmpByPhoneNmbr = dtTemp.Select("SoDienThoai = '" + txtPhoneNmbr.Text.Trim() + "'");
                if (rEmpByPhoneNmbr.Length != 0)
                {
                    return iRet = 1;
                }

               // DataRow[] rTemp2 = dtEmployees.Select("EmployeeID <> '" + objEmployee.EmployeeID + "'");
              //  DataTable dtTemp2 = rTemp.CopyToDataTable();
               
            }
            return iRet;
        }
        private Boolean AddNewEmployee()
        {
            bool bRet = true;
            if (this.txtLastName.Text == string.Empty)
            {
                MessageBox.Show("Bảng số xe không được bỏ trống", "Lỗi", MessageBoxButtons.OK);
                this.txtLastName.Focus();
                return false;
            }
            if (this.txtMiddleName.Text == string.Empty)
            {
                MessageBox.Show("Số đăng ký không được bỏ trống", "Lỗi", MessageBoxButtons.OK);
                this.txtMiddleName.Focus();
                return false;
            }
            return bRet;
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void Reset()
        {
            this.cbbStation.SelectedIndex = 0;
            this.cbbGender.SelectedIndex = 0;
            this.txtLastName.Text = "";
            this.txtFirstName.Text = "";
            this.txtMiddleName.Text = "";
            this.txtPhoneNmbr.Text = "";
            //this.dtpBirthday.Value = DateTime.Now;
            this.dtpStartDate.Value = DateTime.Now;
        }
        private void PrepareData()
        {
            try
            {
                List<Gender> listGender = new List<Gender>();
                Gender Male = new Gender();
                Male.ID = "1";
                Male.Description = "Nam";
                Gender Female = new Gender();
                Female.ID = "2";
                Female.Description = "Nữ";

                listGender.Add(Male);
                listGender.Add(Female);


                cbbGender.DataSource = listGender;
                cbbGender.DisplayMember = "Description";
                cbbGender.ValueMember = "ID";


              

                myStation = API.GetStation;
                cbbStation.DataSource = myStation;
                cbbStation.DisplayMember = "StationName";
                cbbStation.ValueMember = "StationID";


              

                //dtpBirthday.Value = DateTime.Today;
                dtpStartDate.Value = DateTime.Today;
               
                //LoadDepartment();

                if (szMode == "Edit")
                {
                    txtMiddleName.Enabled = false;
                    //txtFirstName.Text = objEmployee.FirstName;
                    // txtMiddleName.Text = objEmployee.MiddleName;
                    txtFirstName.Text = objEmployee.LastName;
                    txtPhoneNmbr.Text = objEmployee.PhoneNumber;
                   // dtpBirthday.Value = DateTime.Parse(objEmployee.Birthday);
                    cbbGender.SelectedValue = objEmployee.Gender;
                    cbbStation.SelectedValue = objEmployee.StationID;
                    pictureBox1.ImageLocation = objEmployee.EmployeeImage;
                    txtLuong.Text = objEmployee.Luong;
                    txtAddress.Text = objEmployee.Address;
                    dtpStartDate.Value = DateTime.Parse(objEmployee.StartDate);
                    this.Text = "Chỉnh sửa thông tin nhân viên";
                    btnAdd.Text = "Chỉnh sửa";
                }
            }
            catch (Exception e)
            {

            }
        }
        #endregion
    }
}
