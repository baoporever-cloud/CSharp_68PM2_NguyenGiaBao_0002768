using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp1
{
    public partial class QLLopHoc : UserControl
    {
        private const int PageSize = 10;
        private int _currentPage = 1;
        private int _totalRecords = 0;
        private int _selectedId = 0;
        private string _currentKeyword = string.Empty;

        public QLLopHoc()
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
            button1.Click += btn_viewSinhVien_Click;
            button2.Click += btn_first_Click;
            button3.Click += btn_previous_Click;
            button4.Click += btn_next_Click;
            button5.Click += btn_last_Click;
            textBox4.KeyDown += textBox4_KeyDown;
        }

        private void SetupGrid()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            textBox1.ReadOnly = true;
        }

        private void QLSinhVien_Load(object sender, EventArgs e)
        {
            LoadLopHoc();
        }

        private void LoadLopHoc()
        {
            LoadLopHoc(_currentKeyword, _currentPage);
        }

        private void LoadLopHoc(string keyword, int page)
        {
            dataGridView1.Rows.Clear();

            if (page < 1) page = 1;
            _currentKeyword = keyword.Trim();
            _totalRecords = CountLopHoc(_currentKeyword);

            int totalPages = GetTotalPages();
            if (page > totalPages) page = totalPages;
            _currentPage = page;

            int offset = (_currentPage - 1) * PageSize;

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT Id, MaLop, TenLop, GhiChu
                FROM LopHoc
                WHERE (@Keyword = ''
                       OR CAST(Id AS NVARCHAR(20)) LIKE @LikeKeyword
                       OR MaLop LIKE @LikeKeyword
                       OR TenLop LIKE @LikeKeyword
                       OR ISNULL(GhiChu, '') LIKE @LikeKeyword)
                ORDER BY Id
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
                dataGridView1.Rows.Add(
                    reader["Id"].ToString(),
                    reader["MaLop"].ToString(),
                    reader["TenLop"].ToString(),
                    reader["GhiChu"].ToString()
                );
            }

            UpdatePagingLabel();
        }

        private int CountLopHoc(string keyword)
        {
            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM LopHoc
                WHERE (@Keyword = ''
                       OR CAST(Id AS NVARCHAR(20)) LIKE @LikeKeyword
                       OR MaLop LIKE @LikeKeyword
                       OR TenLop LIKE @LikeKeyword
                       OR ISNULL(GhiChu, '') LIKE @LikeKeyword)
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
            label1.Text = $"Trang {_currentPage}/{GetTotalPages()} | {_totalRecords} bản ghi";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp.");
                textBox5.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp.");
                textBox2.Focus();
                return false;
            }

            return true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maLop = textBox5.Text.Trim();
            string tenLop = textBox2.Text.Trim();
            string ghiChu = textBox3.Text.Trim();

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
                LoadLopHoc(_currentKeyword, GetTotalPages());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thêm được lớp học.\nLỗi: " + ex.Message);
            }
        }

        private void btn_update_Click(object? sender, EventArgs e)
        {
            if (_selectedId <= 0)
            {
                MessageBox.Show("Vui lòng chọn lớp học cần sửa trong danh sách bên phải.");
                return;
            }

            if (!ValidateInput()) return;

            string maLop = textBox5.Text.Trim();
            string tenLop = textBox2.Text.Trim();
            string ghiChu = textBox3.Text.Trim();

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = @"
                UPDATE LopHoc
                SET MaLop = @MaLop,
                    TenLop = @TenLop,
                    GhiChu = @GhiChu
                WHERE Id = @Id
            ";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaLop", maLop);
            cmd.Parameters.AddWithValue("@TenLop", tenLop);
            cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
            cmd.Parameters.AddWithValue("@Id", _selectedId);

            try
            {
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Sửa lớp học thành công.");
                    ClearInput();
                    LoadLopHoc(_currentKeyword, _currentPage);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp học cần sửa.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không sửa được lớp học.\nLỗi: " + ex.Message);
            }
        }

        private void btn_delete_Click(object? sender, EventArgs e)
        {
            if (_selectedId <= 0)
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xóa.");
                return;
            }

            string maLop = textBox5.Text.Trim();
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa lớp [{maLop}] không?\nNếu lớp đang có sinh viên, SQL Server có thể chặn do ràng buộc khóa ngoại.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            using SqlConnection conn = new SqlConnection(Db.ConnectionString);
            conn.Open();

            string sql = "DELETE FROM LopHoc WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", _selectedId);

            try
            {
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Xóa lớp học thành công.");
                    ClearInput();
                    LoadLopHoc(_currentKeyword, _currentPage);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp học cần xóa.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không xóa được lớp học.\nLỗi: " + ex.Message);
            }
        }

        private void btn_refesh_Click(object sender, EventArgs e)
        {
            ClearInput();
            _currentKeyword = string.Empty;
            _currentPage = 1;
            LoadLopHoc();
        }

        private void btn_search_Click(object? sender, EventArgs e)
        {
            _currentPage = 1;
            LoadLopHoc(textBox4.Text.Trim(), _currentPage);
        }

        private void btn_first_Click(object? sender, EventArgs e)
        {
            LoadLopHoc(_currentKeyword, 1);
        }

        private void btn_previous_Click(object? sender, EventArgs e)
        {
            LoadLopHoc(_currentKeyword, _currentPage - 1);
        }

        private void btn_next_Click(object? sender, EventArgs e)
        {
            LoadLopHoc(_currentKeyword, _currentPage + 1);
        }

        private void btn_last_Click(object? sender, EventArgs e)
        {
            LoadLopHoc(_currentKeyword, GetTotalPages());
        }

        private void textBox4_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_search_Click(sender, e);
            }
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

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void qLSVToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void qLLHToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void txt_date_Click(object sender, EventArgs e) { }
    }
}
