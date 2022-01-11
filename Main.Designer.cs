
using HMM.UserControls;

namespace HMM
{
    partial class Main
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripUserlogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.Separator = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDatetime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new HMM.UserControls.DBFlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new HMM.UserControls.PanelDoubleBuffered();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnVehicle = new System.Windows.Forms.Button();
            this.btnDriver = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnPurchaseTicket = new System.Windows.Forms.Button();
            this.btnGuestAssignment = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnCentralPoint = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus,
            this.toolStripStatusLabel3,
            this.toolStripRole,
            this.toolStripStatusLabel1,
            this.toolStripUserlogin,
            this.Separator,
            this.toolStripDatetime,
            this.toolStripStatusLabel2,
            this.toolStripNotification});
            this.statusStrip1.Location = new System.Drawing.Point(0, 934);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1699, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(94, 20);
            this.toolStripStatus.Text = "Build version";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(1546, 20);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // toolStripRole
            // 
            this.toolStripRole.BackColor = System.Drawing.Color.Transparent;
            this.toolStripRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.toolStripRole.ForeColor = System.Drawing.Color.Brown;
            this.toolStripRole.Name = "toolStripRole";
            this.toolStripRole.Size = new System.Drawing.Size(0, 20);
            this.toolStripRole.Click += new System.EventHandler(this.toolStripRole_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripUserlogin
            // 
            this.toolStripUserlogin.BackColor = System.Drawing.Color.Transparent;
            this.toolStripUserlogin.Name = "toolStripUserlogin";
            this.toolStripUserlogin.Size = new System.Drawing.Size(0, 20);
            // 
            // Separator
            // 
            this.Separator.BackColor = System.Drawing.Color.Transparent;
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(13, 20);
            this.Separator.Text = "|";
            // 
            // toolStripDatetime
            // 
            this.toolStripDatetime.BackColor = System.Drawing.Color.Transparent;
            this.toolStripDatetime.Name = "toolStripDatetime";
            this.toolStripDatetime.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripNotification
            // 
            this.toolStripNotification.BackColor = System.Drawing.Color.Transparent;
            this.toolStripNotification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripNotification.ForeColor = System.Drawing.Color.Red;
            this.toolStripNotification.Name = "toolStripNotification";
            this.toolStripNotification.Size = new System.Drawing.Size(81, 20);
            this.toolStripNotification.Text = "Thông báo";
            this.toolStripNotification.Visible = false;
            this.toolStripNotification.Click += new System.EventHandler(this.toolStripNotification_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnMinimize);
            this.panel2.Controls.Add(this.pbTitle);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1699, 59);
            this.panel2.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Gray;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1276, 18);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(37, 28);
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gray;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1364, 18);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbError
            // 
            this.lbError.BackColor = System.Drawing.Color.White;
            this.lbError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(237, 59);
            this.lbError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(1462, 42);
            this.lbError.TabIndex = 0;
            this.lbError.Text = "Error";
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.btnCustomer);
            this.flowLayoutPanel1.Controls.Add(this.btnVehicle);
            this.flowLayoutPanel1.Controls.Add(this.btnDriver);
            this.flowLayoutPanel1.Controls.Add(this.btnEmployee);
            this.flowLayoutPanel1.Controls.Add(this.btnSchedule);
            this.flowLayoutPanel1.Controls.Add(this.btnPurchaseTicket);
            this.flowLayoutPanel1.Controls.Add(this.btnGuestAssignment);
            this.flowLayoutPanel1.Controls.Add(this.btnInventory);
            this.flowLayoutPanel1.Controls.Add(this.btnCentralPoint);
            this.flowLayoutPanel1.Controls.Add(this.btnLogout);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 59);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(237, 875);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::HMM.Properties.Resources.background2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(237, 101);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1462, 833);
            this.panel1.TabIndex = 3;
            // 
            // btnCustomer
            // 
            this.btnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnCustomer.Image = global::HMM.Properties.Resources.khachang;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCustomer.Location = new System.Drawing.Point(4, 36);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(225, 81);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Khách hàng";
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Visible = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnWorkstation_Click);
            // 
            // btnVehicle
            // 
            this.btnVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnVehicle.FlatAppearance.BorderSize = 0;
            this.btnVehicle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicle.ForeColor = System.Drawing.Color.Black;
            this.btnVehicle.Image = global::HMM.Properties.Resources.phuong_tien;
            this.btnVehicle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVehicle.Location = new System.Drawing.Point(4, 125);
            this.btnVehicle.Margin = new System.Windows.Forms.Padding(4);
            this.btnVehicle.Name = "btnVehicle";
            this.btnVehicle.Size = new System.Drawing.Size(225, 81);
            this.btnVehicle.TabIndex = 1;
            this.btnVehicle.Text = "Phương tiện";
            this.btnVehicle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVehicle.UseVisualStyleBackColor = false;
            this.btnVehicle.Click += new System.EventHandler(this.btnCounter_Click);
            // 
            // btnDriver
            // 
            this.btnDriver.FlatAppearance.BorderSize = 0;
            this.btnDriver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDriver.ForeColor = System.Drawing.Color.Black;
            this.btnDriver.Image = global::HMM.Properties.Resources.nhanvienlaixe;
            this.btnDriver.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDriver.Location = new System.Drawing.Point(4, 214);
            this.btnDriver.Margin = new System.Windows.Forms.Padding(4);
            this.btnDriver.Name = "btnDriver";
            this.btnDriver.Size = new System.Drawing.Size(225, 81);
            this.btnDriver.TabIndex = 2;
            this.btnDriver.Text = "Tài xế lái xe";
            this.btnDriver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDriver.UseVisualStyleBackColor = true;
            this.btnDriver.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.FlatAppearance.BorderSize = 0;
            this.btnEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.Color.Black;
            this.btnEmployee.Image = global::HMM.Properties.Resources.nhanvien;
            this.btnEmployee.Location = new System.Drawing.Point(4, 303);
            this.btnEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(225, 81);
            this.btnEmployee.TabIndex = 3;
            this.btnEmployee.Text = "Nhân viên";
            this.btnEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnShift_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.ForeColor = System.Drawing.Color.Black;
            this.btnSchedule.Image = global::HMM.Properties.Resources.lichtrinhxe;
            this.btnSchedule.Location = new System.Drawing.Point(4, 392);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(225, 81);
            this.btnSchedule.TabIndex = 4;
            this.btnSchedule.Text = "Lịch trình xe";
            this.btnSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnPatron_Click);
            // 
            // btnPurchaseTicket
            // 
            this.btnPurchaseTicket.FlatAppearance.BorderSize = 0;
            this.btnPurchaseTicket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnPurchaseTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchaseTicket.ForeColor = System.Drawing.Color.Black;
            this.btnPurchaseTicket.Image = global::HMM.Properties.Resources.banve;
            this.btnPurchaseTicket.Location = new System.Drawing.Point(4, 481);
            this.btnPurchaseTicket.Margin = new System.Windows.Forms.Padding(4);
            this.btnPurchaseTicket.Name = "btnPurchaseTicket";
            this.btnPurchaseTicket.Size = new System.Drawing.Size(225, 81);
            this.btnPurchaseTicket.TabIndex = 8;
            this.btnPurchaseTicket.Text = "Bán vé xe";
            this.btnPurchaseTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPurchaseTicket.UseVisualStyleBackColor = true;
            this.btnPurchaseTicket.Click += new System.EventHandler(this.btnTradingday_Click);
            // 
            // btnGuestAssignment
            // 
            this.btnGuestAssignment.Enabled = false;
            this.btnGuestAssignment.FlatAppearance.BorderSize = 0;
            this.btnGuestAssignment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnGuestAssignment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuestAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuestAssignment.ForeColor = System.Drawing.Color.Black;
            this.btnGuestAssignment.Image = global::HMM.Properties.Resources.users;
            this.btnGuestAssignment.Location = new System.Drawing.Point(4, 570);
            this.btnGuestAssignment.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuestAssignment.Name = "btnGuestAssignment";
            this.btnGuestAssignment.Size = new System.Drawing.Size(225, 81);
            this.btnGuestAssignment.TabIndex = 6;
            this.btnGuestAssignment.Text = "Xếp khách";
            this.btnGuestAssignment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuestAssignment.UseVisualStyleBackColor = true;
            this.btnGuestAssignment.Visible = false;
            this.btnGuestAssignment.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.Black;
            this.btnInventory.Image = global::HMM.Properties.Resources.tool;
            this.btnInventory.Location = new System.Drawing.Point(4, 659);
            this.btnInventory.Margin = new System.Windows.Forms.Padding(4);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(225, 81);
            this.btnInventory.TabIndex = 9;
            this.btnInventory.Text = "Vật tư";
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnCentralPoint
            // 
            this.btnCentralPoint.FlatAppearance.BorderSize = 0;
            this.btnCentralPoint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnCentralPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCentralPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCentralPoint.ForeColor = System.Drawing.Color.Black;
            this.btnCentralPoint.Image = global::HMM.Properties.Resources.phuong_tien;
            this.btnCentralPoint.Location = new System.Drawing.Point(4, 748);
            this.btnCentralPoint.Margin = new System.Windows.Forms.Padding(4);
            this.btnCentralPoint.Name = "btnCentralPoint";
            this.btnCentralPoint.Size = new System.Drawing.Size(225, 81);
            this.btnCentralPoint.TabIndex = 11;
            this.btnCentralPoint.Text = "Trạm giữa";
            this.btnCentralPoint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCentralPoint.UseVisualStyleBackColor = true;
            this.btnCentralPoint.Click += new System.EventHandler(this.btnCentralPoint_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Image = global::HMM.Properties.Resources.logout_red;
            this.btnLogout.Location = new System.Drawing.Point(4, 837);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(225, 81);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.Text = "Log out";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Visible = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pbTitle
            // 
            this.pbTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTitle.Image = global::HMM.Properties.Resources.Picture1;
            this.pbTitle.Location = new System.Drawing.Point(569, 5);
            this.pbTitle.Margin = new System.Windows.Forms.Padding(4);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(461, 50);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTitle.TabIndex = 3;
            this.pbTitle.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HMM.Properties.Resources.logo4040;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(16, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1699, 960);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toan Thang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToanThangAdminForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDatetime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripUserlogin;
        private System.Windows.Forms.ToolStripStatusLabel Separator;
        private System.Windows.Forms.Panel panel2;
        private DBFlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnVehicle;
        private System.Windows.Forms.Button btnDriver;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnSchedule;
        private PanelDoubleBuffered panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btnPurchaseTicket;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Button btnGuestAssignment;
        private System.Windows.Forms.ToolStripStatusLabel toolStripRole;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnCentralPoint;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ToolStripStatusLabel toolStripNotification;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}