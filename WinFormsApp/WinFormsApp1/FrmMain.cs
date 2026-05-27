using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadUserControl(new QLSinhVien());
        }

        private void LoadUserControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLSinhVien());
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QLLopHoc());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    }
}