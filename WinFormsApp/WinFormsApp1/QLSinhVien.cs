using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class QLSinhVien : UserControl
    {
        public QLSinhVien()
        {
            InitializeComponent();
        }

        private void WireEvents()
        {
            btn_update.Click += btn_update_Click;
            btn_delete.Click += btn_delete_Click;
            btn_search.Click += btn_search_Click;
            button1.Click += btn_first_Click;
            button2.Click += btn_previous_Click;
            button3.Click += btn_next_Click;
            button4.Click += btn_last_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;
            textBox3.KeyDown += textBox3_KeyDown;
        }

        private void SetupGrid()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void QLSinhVien_Load(object sender, EventArgs e)
        {
            LoadLopHoc();
            LoadSinhVien();
        }

        private void LoadLopHoc()
        {
            comboBox2.Items.Clear();

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = "SELECT MaLop FROM LopHoc ORDER BY MaLop";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox2.Items.Add(reader["MaLop"].ToString());
            }

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        private void LoadSinhVien()
        {
            dataGridView1.Rows.Clear();

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT MaSV, HoTen, GioiTinh, NgaySinh, MaLop
                FROM SinhVien
                ORDER BY MaSV
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime ngaySinh = Convert.ToDateTime(reader["NgaySinh"]);

                dataGridView1.Rows.Add(
                    reader["MaSV"].ToString(),
                    reader["HoTen"].ToString(),
                    reader["GioiTinh"].ToString(),
                    ngaySinh.ToString("dd/MM/yyyy"),
                    reader["MaLop"].ToString()
                );
            }

            label7.Text = $"Tổng: {dataGridView1.Rows.Count} sinh viên";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string maSV = textBox1.Text.Trim();
            string hoTen = textBox2.Text.Trim();
            string gioiTinh = comboBox1.Text.Trim();
            DateTime ngaySinh = dateTimePicker1.Value.Date;
            string maLop = comboBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên và họ tên.");
                return;
            }

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                INSERT INTO SinhVien (MaSV, HoTen, GioiTinh, NgaySinh, MaLop)
                VALUES (@MaSV, @HoTen, @GioiTinh, @NgaySinh, @MaLop)
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);
            cmd.Parameters.AddWithValue("@HoTen", hoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
            cmd.Parameters.AddWithValue("@MaLop", maLop);

            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm sinh viên thành công.");

                ClearInput();
                LoadSinhVien();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thêm được sinh viên.\nLỗi: " + ex.Message);
            }
        }

        private void btn_refesh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadLopHoc();
            LoadSinhVien();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string keyword = textBox3.Text.Trim();

            dataGridView1.Rows.Clear();

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT MaSV, HoTen, GioiTinh, NgaySinh, MaLop
                FROM SinhVien
                WHERE MaSV LIKE @Keyword
                   OR HoTen LIKE @Keyword
                   OR MaLop LIKE @Keyword
                ORDER BY MaSV
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime ngaySinh = Convert.ToDateTime(reader["NgaySinh"]);

                dataGridView1.Rows.Add(
                    reader["MaSV"].ToString(),
                    reader["HoTen"].ToString(),
                    reader["GioiTinh"].ToString(),
                    ngaySinh.ToString("dd/MM/yyyy"),
                    reader["MaLop"].ToString()
                );
            }

            label7.Text = $"Tìm thấy: {dataGridView1.Rows.Count} sinh viên";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FillInputFromGrid(e.RowIndex);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillInputFromGrid(e.RowIndex);
        }

        private void FillInputFromGrid(int rowIndex)
        {
            if (rowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            if (row.IsNewRow) return;

            textBox1.Text = row.Cells[0].Value?.ToString();
            textBox2.Text = row.Cells[1].Value?.ToString();
            comboBox1.Text = row.Cells[2].Value?.ToString();

            if (DateTime.TryParse(row.Cells[3].Value?.ToString(), out DateTime ngaySinh))
            {
                dateTimePicker1.Value = ngaySinh;
            }

            comboBox2.Text = row.Cells[4].Value?.ToString();
        }

        private void ClearInput()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            comboBox1.Text = "Nam";

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

            dateTimePicker1.Value = DateTime.Now;
            dataGridView1.ClearSelection();
            textBox1.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void qLSVToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qLLHToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }   
    }
}