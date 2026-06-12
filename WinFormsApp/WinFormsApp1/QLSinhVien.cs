using Microsoft.Data.SqlClient;
using System.Globalization;

namespace WinFormsApp1
{
    public partial class QLSinhVien : UserControl
    {
        private const int PageSize = 10;
        private int _currentPage = 1;
        private int _totalRecords = 0;
        private string _currentKeyword = string.Empty;
        private string _selectedMaSV = string.Empty;

        public QLSinhVien()
        {
            InitializeComponent();
            WireEvents();
            SetupGrid();
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
            LoadSinhVien(_currentKeyword, _currentPage);
        }

        private void LoadSinhVien(string keyword, int page)
        {
            dataGridView1.Rows.Clear();

            if (page < 1) page = 1;
            _currentKeyword = keyword.Trim();
            _totalRecords = CountSinhVien(_currentKeyword);

            int totalPages = GetTotalPages();
            if (page > totalPages) page = totalPages;
            _currentPage = page;

            int offset = (_currentPage - 1) * PageSize;

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT MaSV, HoTen, GioiTinh, NgaySinh, MaLop
                FROM SinhVien
                WHERE (@Keyword = ''
                       OR MaSV LIKE @LikeKeyword
                       OR HoTen LIKE @LikeKeyword
                       OR MaLop LIKE @LikeKeyword)
                ORDER BY MaSV
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Keyword", _currentKeyword);
            cmd.Parameters.AddWithValue("@LikeKeyword", "%" + _currentKeyword + "%");
            cmd.Parameters.AddWithValue("@Offset", offset);
            cmd.Parameters.AddWithValue("@PageSize", PageSize);

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

            UpdatePagingLabel();
        }

        private int CountSinhVien(string keyword)
        {
            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM SinhVien
                WHERE (@Keyword = ''
                       OR MaSV LIKE @LikeKeyword
                       OR HoTen LIKE @LikeKeyword
                       OR MaLop LIKE @LikeKeyword)
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Keyword", keyword);
            cmd.Parameters.AddWithValue("@LikeKeyword", "%" + keyword + "%");

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int GetTotalPages()
        {
            return Math.Max(1, (int)Math.Ceiling(_totalRecords / (double)PageSize));
        }

        private void UpdatePagingLabel()
        {
            label7.Text = $"Trang {_currentPage}/{GetTotalPages()} | {_totalRecords} bản ghi";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                textBox1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên sinh viên.");
                textBox2.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                comboBox1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp.");
                comboBox2.Focus();
                return false;
            }

            return true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

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
                _currentPage = GetTotalPages();
                LoadSinhVien(_currentKeyword, _currentPage);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thêm được sinh viên.\nLỗi: " + ex.Message);
            }
        }

        private void btn_update_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedMaSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa trong danh sách bên phải.");
                return;
        }

            if (!ValidateInput()) return;

            string maSVMoi = textBox1.Text.Trim();
            string hoTen = textBox2.Text.Trim();
            string gioiTinh = comboBox1.Text.Trim();
            DateTime ngaySinh = dateTimePicker1.Value.Date;
            string maLop = comboBox2.Text.Trim();

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                UPDATE SinhVien
                SET MaSV = @MaSVMoi,
                    HoTen = @HoTen,
                    GioiTinh = @GioiTinh,
                    NgaySinh = @NgaySinh,
                    MaLop = @MaLop
                WHERE MaSV = @MaSVCu
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSVMoi", maSVMoi);
            cmd.Parameters.AddWithValue("@HoTen", hoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
            cmd.Parameters.AddWithValue("@MaLop", maLop);
            cmd.Parameters.AddWithValue("@MaSVCu", _selectedMaSV);

            try
            {
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Sửa sinh viên thành công.");
                    _selectedMaSV = maSVMoi;
                    ClearInput();
                    LoadSinhVien(_currentKeyword, _currentPage);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên cần sửa.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không sửa được sinh viên.\nLỗi: " + ex.Message);
            }
        }

        private void btn_delete_Click(object? sender, EventArgs e)
            {
            string maSV = !string.IsNullOrWhiteSpace(_selectedMaSV) ? _selectedMaSV : textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa sinh viên [{maSV}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (confirm != DialogResult.Yes) return;

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);

            try
            {
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Xóa sinh viên thành công.");
                    ClearInput();
                    LoadSinhVien(_currentKeyword, _currentPage);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên cần xóa.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không xóa được sinh viên.\nLỗi: " + ex.Message);
            }
        }

        private void btn_refesh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadLopHoc();
            _currentKeyword = string.Empty;
            _currentPage = 1;
            LoadSinhVien();
        }

        private void btn_search_Click(object? sender, EventArgs e)
        {
            _currentPage = 1;
            LoadSinhVien(textBox3.Text.Trim(), _currentPage);
        }

        private void btn_first_Click(object? sender, EventArgs e)
        {
            LoadSinhVien(_currentKeyword, 1);
        }

        private void btn_previous_Click(object? sender, EventArgs e)
        {
            LoadSinhVien(_currentKeyword, _currentPage - 1);
        }

        private void btn_next_Click(object? sender, EventArgs e)
        {
            LoadSinhVien(_currentKeyword, _currentPage + 1);
        }

        private void btn_last_Click(object? sender, EventArgs e)
        {
            LoadSinhVien(_currentKeyword, GetTotalPages());
            }

        private void textBox3_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_search_Click(sender, e);
        }
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

            _selectedMaSV = row.Cells[0].Value?.ToString() ?? string.Empty;
            textBox1.Text = _selectedMaSV;
            textBox2.Text = row.Cells[1].Value?.ToString();
            comboBox1.Text = row.Cells[2].Value?.ToString();

            string ngaySinhText = row.Cells[3].Value?.ToString() ?? string.Empty;
            if (DateTime.TryParseExact(ngaySinhText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh)
                || DateTime.TryParse(ngaySinhText, out ngaySinh))
            {
                dateTimePicker1.Value = ngaySinh;
            }

            comboBox2.Text = row.Cells[4].Value?.ToString();
        }

        private void ClearInput()
        {
            _selectedMaSV = string.Empty;
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

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void qLSVToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void qLLHToolStripMenuItem_Click(object sender, EventArgs e) { }
        }

        private void qLSVToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qLLHToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }   
    }
}