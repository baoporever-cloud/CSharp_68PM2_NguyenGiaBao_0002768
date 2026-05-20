namespace WinFormsApp1
{
    partial class FrmMain
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
            panelMenu = new Panel();
            btnDangXuat = new Button();
            btnLopHoc = new Button();
            btnSinhVien = new Button();
            label1 = new Label();
            panelContent = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ControlDark;
            panelMenu.Controls.Add(btnDangXuat);
            panelMenu.Controls.Add(btnLopHoc);
            panelMenu.Controls.Add(btnSinhVien);
            panelMenu.Controls.Add(label1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 450);
            panelMenu.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.FromArgb(120, 40, 40);
            btnDangXuat.Dock = DockStyle.Fill;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(0, 190);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(220, 260);
            btnDangXuat.TabIndex = 3;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnLopHoc
            // 
            btnLopHoc.BackColor = Color.FromArgb(45, 45, 65);
            btnLopHoc.Dock = DockStyle.Top;
            btnLopHoc.FlatAppearance.BorderSize = 0;
            btnLopHoc.FlatStyle = FlatStyle.Flat;
            btnLopHoc.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLopHoc.ForeColor = Color.White;
            btnLopHoc.Location = new Point(0, 135);
            btnLopHoc.Name = "btnLopHoc";
            btnLopHoc.Size = new Size(220, 55);
            btnLopHoc.TabIndex = 2;
            btnLopHoc.Text = "Quản lý lớp học";
            btnLopHoc.UseVisualStyleBackColor = false;
            btnLopHoc.Click += btnLopHoc_Click;
            // 
            // btnSinhVien
            // 
            btnSinhVien.BackColor = Color.FromArgb(45, 45, 65);
            btnSinhVien.Dock = DockStyle.Top;
            btnSinhVien.FlatAppearance.BorderSize = 0;
            btnSinhVien.FlatStyle = FlatStyle.Flat;
            btnSinhVien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSinhVien.ForeColor = Color.White;
            btnSinhVien.Location = new Point(0, 80);
            btnSinhVien.Name = "btnSinhVien";
            btnSinhVien.Size = new Size(220, 55);
            btnSinhVien.TabIndex = 1;
            btnSinhVien.Text = "Quản lý sinh viên";
            btnSinhVien.UseVisualStyleBackColor = false;
            btnSinhVien.Click += btnSinhVien_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.MaximumSize = new Size(0, 80);
            label1.MinimumSize = new Size(0, 80);
            label1.Name = "label1";
            label1.Size = new Size(157, 80);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(220, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(580, 450);
            panelContent.TabIndex = 1;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Quản lý sinh viên - lớp học";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Label label1;
        private Panel panelContent;
        private Button btnLopHoc;
        private Button btnSinhVien;
        private Button btnDangXuat;
    }
}