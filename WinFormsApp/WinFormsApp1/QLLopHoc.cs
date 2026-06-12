
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class QLLopHoc : UserControl
    {
        public QLLopHoc()
        {
            InitializeComponent();
        }

        private void QLSinhVien_Load(object sender, EventArgs e)
        {
            LoadLopHoc();
        }

        private void LoadLopHoc()
        {
            dataGridView1.Rows.Clear();

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT Id, MaLop, TenLop, GhiChu
                FROM LopHoc
                ORDER BY Id
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(
                    reader["Id"].ToString(),
                    reader["MaLop"].ToString(),
                    reader["TenLop"].ToString(),
                    reader["GhiChu"].ToString()
                );
            }

            label1.Text = $"Tổng: {dataGridView1.Rows.Count} lớp học";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string maLop = textBox1.Text.Trim();
            string tenLop = textBox2.Text.Trim();
            string ghiChu = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(maLop) || string.IsNullOrWhiteSpace(tenLop))
            {
                MessageBox.Show("Vui lòng nhập mã lớp và tên lớp.");
                return;
            }

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                INSERT INTO LopHoc (MaLop, TenLop, GhiChu)
                VALUES (@MaLop, @TenLop, @GhiChu)
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaLop", maLop);
            cmd.Parameters.AddWithValue("@TenLop", tenLop);
            cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm lớp học thành công.");

                ClearInput();
                LoadLopHoc();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thêm được lớp học.\nLỗi: " + ex.Message);
            }
        }

        private void btn_refesh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadLopHoc();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string keyword = textBox4.Text.Trim();

            dataGridView1.Rows.Clear();

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT Id, MaLop, TenLop, GhiChu
                FROM LopHoc
                WHERE CAST(Id AS NVARCHAR(20)) LIKE @Keyword
                   OR MaLop LIKE @Keyword
                   OR TenLop LIKE @Keyword
                ORDER BY Id
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(
                    reader["Id"].ToString(),
                    reader["MaLop"].ToString(),
                    reader["TenLop"].ToString(),
                    reader["GhiChu"].ToString()
                );
            }

            label1.Text = $"Tìm thấy: {dataGridView1.Rows.Count} lớp học";
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

            textBox1.Text = row.Cells[1].Value?.ToString();
            textBox2.Text = row.Cells[2].Value?.ToString();
            textBox3.Text = row.Cells[3].Value?.ToString();
        }

        private void ClearInput()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
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

        private void btn_viewSinhVien_Click(object? sender, EventArgs e)
        {
            string maLop = textBox5.Text.Trim();
            if (string.IsNullOrWhiteSpace(maLop))
        {
                MessageBox.Show("Vui lòng chọn lớp học cần xem danh sách sinh viên.");
                return;
            }

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT MaSV AS [Mã SV],
                       HoTen AS [Họ tên],
                       GioiTinh AS [Giới tính],
                       NgaySinh AS [Ngày sinh],
                       MaLop AS [Mã lớp]
                FROM SinhVien
                WHERE MaLop = @MaLop
                ORDER BY MaSV
            ";

            using SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@MaLop", maLop);

            DataTable table = new DataTable();
            adapter.Fill(table);

            using Form frm = new Form();
            frm.Text = $"Danh sách sinh viên lớp {maLop}";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Size = new Size(850, 500);

            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = table,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            Label lbl = new Label
        {
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = $"  Lớp {maLop}: {table.Rows.Count} sinh viên"
            };

            frm.Controls.Add(dgv);
            frm.Controls.Add(lbl);
            frm.ShowDialog(this);
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

            int.TryParse(row.Cells[0].Value?.ToString(), out _selectedId);
            textBox1.Text = row.Cells[0].Value?.ToString();
            textBox5.Text = row.Cells[1].Value?.ToString();
            textBox2.Text = row.Cells[2].Value?.ToString();
            textBox3.Text = row.Cells[3].Value?.ToString();
        }

        private void ClearInput()
        {
            _selectedId = 0;
            textBox1.Clear();
            textBox5.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dataGridView1.ClearSelection();
            textBox5.Focus();
        }

        }
    }
}