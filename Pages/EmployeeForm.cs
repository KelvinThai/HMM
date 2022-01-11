using HMM.Constants;
using HMM.DataModels;
using HMM.DialogForms;
using HMM.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMM.Pages
{
    public partial class EmployeeForm : CenteredForm
    {
        #region Variables & Properties
        DataTable dt;
        DataTable dtEmployees;
        DataTable dtDep;
        NewEmployeeForm NVHForm;
        List<int> listShowVType = new List<int>();
        List<int> listHideVType = new List<int>();

        #endregion

        #region Form Events
        public EmployeeForm()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NVHForm = new NewEmployeeForm();
            NVHForm.dtEmployees = dtEmployees;
            NVHForm.szMode = "Add";
            NVHForm.ShowDialog();
            do
            {
                Application.DoEvents();
            }
            while (NVHForm.bActived);

            ReloadEmployeeTable();
           // cbbDepartment.SelectedIndex = dtDep.Rows.Count - 1;
            txtSearch_TextChanged(sender, e);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            dt = (DataTable)dgEmployee.DataSource;
            Employee objEmployee = new Employee();
            SqlParameter[] sqlParams;
            for (int i = 0; i < dgEmployee.Rows.Count; i++)
            {
                if (dgEmployee.Rows[i].Selected)
                {
                    //listDel.Add((int)dgEmployee.Rows[i].Cells["ID"].Value);
                    objEmployee = InstanceManagement.ToObject<Employee>(dt.Rows[i]);

                    objEmployee.Address = dt.Rows[i]["DiaChi"].ToString();
                    objEmployee.LastName=dt.Rows[i]["HoVaTen"].ToString();
                    objEmployee.PhoneNumber=dt.Rows[i]["SoDienThoai"].ToString();
                    objEmployee.Gender = dt.Rows[i]["GenderString"].ToString().Equals("Nam")?"1":"2";
                    objEmployee.StartDate=dt.Rows[i]["NgayVaoLam"].ToString();
                    objEmployee.StationID=dt.Rows[i]["MaTram"].ToString();
                    objEmployee.uid= dt.Rows[i]["MaNhanVien"].ToString();
                    objEmployee.Luong= dt.Rows[i]["Luong"].ToString();
                }
            }

            NVHForm = new NewEmployeeForm();
            NVHForm.szMode = "Edit";
            NVHForm.objEmployee = objEmployee;
            NVHForm.dtEmployees = dtEmployees;
            NVHForm.ShowDialog();
            do
            {
                Application.DoEvents();
            }
            while (NVHForm.bActived);

            ReloadEmployeeTable();
            //cbbDepartment.SelectedIndex = dtDep.Rows.Count - 1;
            txtSearch_TextChanged(sender, e);
        }
        private void btnOpenClose_Click(object sender, EventArgs e)
        {
        }

        private void dgCounters_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
        }

        private void dgCounters_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Chức năng đang được hoàn thiện?", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            if (MessageBox.Show("Xóa dữ liệu đã chọn ?", "Xóa dữ liệu", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlParameter[] sqlParams;
                for (int i = 0; i < dgEmployee.Rows.Count; i++)
                {
                    if (dgEmployee.Rows[i].Selected)
                    {
                        sqlParams = new SqlParameter[] { new SqlParameter("@MaNhanVien", (int)dgEmployee.Rows[i].Cells["MaNhanVien"].Value) };
                        InstanceManagement.SQLHelperInstance.ExecStoreProcedure("spDeleteEmployee", sqlParams);
                    }
                }
                ReloadEmployeeTable();
               // cbbDepartment.SelectedIndex = dtDep.Rows.Count - 1;
                txtSearch_TextChanged(sender, e);
                InstanceManagement.MainFormInstance.ShowInfo("Xóa dữ liệu thành công !");
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            //Check permission from Access Guard
            if (!InstanceManagement.UserLoginInstance.Role.Equals("1"))
            {
                btnAdd.Visible = false;
                btnModify.Visible = false;
                btnDelete.Visible = false;
                btnAddDriverComment.Visible = false;
            }

            ReloadEmployeeTable();
            dtEmployees = dt.Copy();
            //LoadDepartment();
        }
        private void LoadDepartment()
        {
            cbbDepartment.DataSource = null;

            dtDep = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetDepartment", new System.Data.SqlClient.SqlParameter[] { });
            DataRow row;
            row = dtDep.NewRow();
            row["ID"] = 0;
            row["Description"] = "Tất cả";
            dtDep.Rows.Add(row);
            cbbDepartment.DataSource = dtDep;
            cbbDepartment.ValueMember = "ID";
            cbbDepartment.DisplayMember = "Description";
            cbbDepartment.SelectedIndex = dtDep.Rows.Count - 1;
            cbbDepartment.Refresh();
        }
        private void dgEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //click on button Xoa
            if (dgEmployee.CurrentCell.FormattedValue.ToString() == "Xóa")
            {
                if (MessageBox.Show("Xóa dữ liệu đã chọn ?", "Xóa dữ liệu", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    SqlParameter[] sqlParams;
                    for (int i = 0; i < dgEmployee.Rows.Count; i++)
                    {
                        if (dgEmployee.Rows[i].Selected)
                        {
                            sqlParams = new SqlParameter[] { new SqlParameter("@EmployeeID", (int)dgEmployee.Rows[i].Cells["uid"].Value) };
                            InstanceManagement.SQLHelperInstance.ExecStoreProcedure("spDeleteEmployee", sqlParams);
                        }
                    }
                    ReloadEmployeeTable();
                    cbbDepartment.SelectedIndex = dtDep.Rows.Count - 1;
                    txtSearch_TextChanged(sender, e);
                    InstanceManagement.MainFormInstance.ShowInfo("Xóa dữ liệu thành công !");
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           

            //if (txtSearch.Text.Trim() != "")
            //{
                dgEmployee.DataSource = null;
                dgEmployee.Columns.Clear();
                DataRow[] drs = dt.Select(string.Format("HoVaTen like '%{0}%' or SoDienThoai like '%{0}%'", txtSearch.Text));
                if (drs.Length > 0)
                {
                    DataTable dtFilter = drs.CopyToDataTable();
                    dgEmployee.DataSource = dtFilter;
                }
         //   }
          
           

           // if (dgEmployee.DataSource != null)
           //     AddExtendedColumnsToEmployee();

            lbEmployee.Text = "Danh sách các nhân viên (" + dgEmployee.Rows.Count.ToString() + ")";
            dgEmployee.Refresh();
        }

        private void cbbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    dgEmployee.DataSource = dt;

            //    if ((int)cbbDepartment.SelectedValue == 0)
            //    {
            //        (dgEmployee.DataSource as DataTable).DefaultView.RowFilter = string.Format("Status = 1");
            //    }
            //    else
            //    {
            //        (dgEmployee.DataSource as DataTable).DefaultView.RowFilter = string.Format("Status = 1 AND DepartmentID =" + cbbDepartment.SelectedValue.ToString());
            //    }

            //    txtSearch_TextChanged(sender, e);

            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            InstanceManagement.ExportDataInstance.ExportToExcel(dgEmployee);
        }

        private void dgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

              //  LoadEmpComments(dgEmployee.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString());
            }
        }
        private void btnAddDriverComment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được hoàn thiện?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //string input = Interaction.InputBox("Thêm ghi chú về nhân viên này", "Thêm ghi chú", "", -1, -1);
            //if (input.Trim() != "")
            //{
            //    InstanceManagement.SQLHelperInstance.ExecStoreProcedure("spAddEmployeeComment", new SqlParameter[]
            //    {
            //            new SqlParameter("EmployeeID", dgEmployee.SelectedRows[0].Cells["uid"].Value.ToString()),
            //            new SqlParameter("Comment", input.Trim()),
            //            new SqlParameter("CommentedBy", InstanceManagement.UserLoginInstance.UID)
            //    });
            //    LoadEmpComments(dgEmployee.SelectedRows[0].Cells["uid"].Value.ToString());
            //}
        }
        #endregion

        #region Business Logic
        public void LoadEmpComments(string EmpID)
        {
            DataTable dtComment = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetEmployeeComment", new SqlParameter[] { new SqlParameter("EmployeeID", EmpID) });
            dgEmplComments.DataSource = null;
            dgEmplComments.DataSource = dtComment;

            // dgEmplComments.Columns["EmployeeID"].HeaderText = "Mã nhân viên";
            dgEmplComments.Columns["Comment"].HeaderText = "Ghi chú";
            dgEmplComments.Columns["CommentedBy"].HeaderText = "Người tạo";
            dgEmplComments.Columns["CommentTime"].HeaderText = "Thời gian tạo";

        }
        private void Reload_dgEmployee()
        {

            dgEmployee.Refresh();
        }
        private void AddExtendedColumnsToEmployee()
        {
            DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn();
            (dgEmployee.DataSource as DataTable).DefaultView.RowFilter = string.Format("Status = 1");

            btnDel.Text = "Xóa";
            btnDel.UseColumnTextForButtonValue = true;
            btnDel.Name = "btnDel";

            dgEmployee.Columns.Add(btnDel);
            for (int i = 0; i < dgEmployee.Rows.Count; i++)
            {
                dgEmployee.Rows[i].Cells["btnDel"].Value = "Xóa";
            }
            API.TranslationHeader(dgEmployee, "EmployeeForm");
        }
        private void ReloadEmployeeTable()
        {
            dgEmployee.DataSource = null;
            dgEmployee.Columns.Clear();

            dt = InstanceManagement.SQLHelperInstance.ExecStoreProcedure_GetDataTable("spGetEmployee", new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@uid", "0") });

            dgEmployee.DataSource = dt;

           // AddExtendedColumnsToEmployee();
            dgEmployee.Refresh();

            lbEmployee.Text = "Danh sách các nhân viên (" + dgEmployee.Rows.Count.ToString() + ")";
        }
        #endregion  
    }
}
