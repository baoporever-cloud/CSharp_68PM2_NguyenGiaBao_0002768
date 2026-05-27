namespace WinFormsApp1
{
    partial class QLLopHoc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            textBox3 = new TextBox();
            comboBox2 = new ComboBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            txt_date = new Label();
            txt_name = new Label();
            txt_mssv = new Label();
            textBox4 = new TextBox();
            btn_search = new Button();
            label6 = new Label();
            btn_refesh = new Button();
            btn_delete = new Button();
            btn_update = new Button();
            btn_add = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox5 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(txt_date);
            groupBox1.Controls.Add(txt_name);
            groupBox1.Controls.Add(txt_mssv);
            groupBox1.Location = new Point(38, 71);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(532, 524);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin lớp học ";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(26, 445);
            textBox3.Margin = new Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(472, 31);
            textBox3.TabIndex = 9;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "68PM1", "68PM2" });
            comboBox2.Location = new Point(29, 638);
            comboBox2.Margin = new Padding(4, 5, 4, 5);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(472, 33);
            comboBox2.TabIndex = 8;
            comboBox2.Text = "68PM1";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(29, 318);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(472, 31);
            textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 117);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(472, 31);
            textBox1.TabIndex = 5;
            // 
            // txt_date
            // 
            txt_date.AutoSize = true;
            txt_date.Location = new Point(26, 393);
            txt_date.Margin = new Padding(4, 0, 4, 0);
            txt_date.Name = "txt_date";
            txt_date.Size = new Size(75, 25);
            txt_date.TabIndex = 2;
            txt_date.Text = "Ghi chú:";
            txt_date.Click += txt_date_Click;
            // 
            // txt_name
            // 
            txt_name.AutoSize = true;
            txt_name.Location = new Point(26, 263);
            txt_name.Margin = new Padding(4, 0, 4, 0);
            txt_name.Name = "txt_name";
            txt_name.Size = new Size(73, 25);
            txt_name.TabIndex = 1;
            txt_name.Text = "Tên lớp:";
            // 
            // txt_mssv
            // 
            txt_mssv.AutoSize = true;
            txt_mssv.Location = new Point(26, 69);
            txt_mssv.Margin = new Padding(4, 0, 4, 0);
            txt_mssv.Name = "txt_mssv";
            txt_mssv.Size = new Size(64, 25);
            txt_mssv.TabIndex = 0;
            txt_mssv.Text = "Mã ID:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(595, 99);
            textBox4.Margin = new Padding(4, 5, 4, 5);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(439, 31);
            textBox4.TabIndex = 13;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // btn_search
            // 
            btn_search.BackColor = Color.SlateGray;
            btn_search.FlatStyle = FlatStyle.Flat;
            btn_search.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_search.ForeColor = SystemColors.Control;
            btn_search.Location = new Point(1056, 99);
            btn_search.Margin = new Padding(4, 5, 4, 5);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(150, 66);
            btn_search.TabIndex = 12;
            btn_search.Text = "Tìm";
            btn_search.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(595, 60);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(312, 22);
            label6.TabIndex = 11;
            label6.Text = "Tìm kiếm (Mã ID/ Mã lớp/ Tên lớp)";
            label6.Click += label6_Click;
            // 
            // btn_refesh
            // 
            btn_refesh.BackColor = SystemColors.ScrollBar;
            btn_refesh.FlatStyle = FlatStyle.Flat;
            btn_refesh.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_refesh.ForeColor = SystemColors.Control;
            btn_refesh.Location = new Point(313, 727);
            btn_refesh.Margin = new Padding(4, 5, 4, 5);
            btn_refesh.Name = "btn_refesh";
            btn_refesh.Size = new Size(255, 75);
            btn_refesh.TabIndex = 17;
            btn_refesh.Text = "Làm mới";
            btn_refesh.UseVisualStyleBackColor = false;
            btn_refesh.Click += btn_refesh_Click;
            // 
            // btn_delete
            // 
            btn_delete.BackColor = Color.Crimson;
            btn_delete.FlatStyle = FlatStyle.Flat;
            btn_delete.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_delete.ForeColor = SystemColors.Control;
            btn_delete.Location = new Point(29, 727);
            btn_delete.Margin = new Padding(4, 5, 4, 5);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(254, 75);
            btn_delete.TabIndex = 16;
            btn_delete.Text = "Xóa";
            btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_update
            // 
            btn_update.BackColor = Color.SpringGreen;
            btn_update.FlatStyle = FlatStyle.Flat;
            btn_update.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_update.ForeColor = SystemColors.Control;
            btn_update.Location = new Point(313, 624);
            btn_update.Margin = new Padding(4, 5, 4, 5);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(255, 75);
            btn_update.TabIndex = 15;
            btn_update.Text = "Sửa";
            btn_update.UseVisualStyleBackColor = false;
            // 
            // btn_add
            // 
            btn_add.BackColor = Color.MediumTurquoise;
            btn_add.FlatStyle = FlatStyle.Flat;
            btn_add.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_add.ForeColor = SystemColors.Control;
            btn_add.Location = new Point(29, 624);
            btn_add.Margin = new Padding(4, 5, 4, 5);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(254, 75);
            btn_add.TabIndex = 14;
            btn_add.Text = "Thêm ";
            btn_add.UseVisualStyleBackColor = false;
            btn_add.Click += btn_add_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightPink;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(29, 849);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(539, 75);
            button1.TabIndex = 18;
            button1.Text = "Xem danh sách sinh viên";
            button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(595, 175);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RightToLeft = RightToLeft.No;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(657, 755);
            dataGridView1.TabIndex = 19;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Mã lớp";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Tên lớp";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Ghi chú";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(605, 951);
            button2.Name = "button2";
            button2.Size = new Size(95, 77);
            button2.TabIndex = 10;
            button2.Text = "<<";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(706, 951);
            button3.Name = "button3";
            button3.Size = new Size(95, 77);
            button3.TabIndex = 20;
            button3.Text = "<";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(1056, 951);
            button4.Name = "button4";
            button4.Size = new Size(95, 77);
            button4.TabIndex = 21;
            button4.Text = ">";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(1157, 951);
            button5.Name = "button5";
            button5.Size = new Size(95, 77);
            button5.TabIndex = 22;
            button5.Text = ">>";
            button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(840, 977);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(176, 25);
            label1.TabIndex = 24;
            label1.Text = "Trang 1/1 | 2 bản ghi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 172);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 10;
            label2.Text = "Mã lớp:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(26, 217);
            textBox5.Margin = new Padding(4, 5, 4, 5);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(472, 31);
            textBox5.TabIndex = 11;
            // 
            // QLLopHoc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(btn_refesh);
            Controls.Add(btn_delete);
            Controls.Add(btn_update);
            Controls.Add(btn_add);
            Controls.Add(textBox4);
            Controls.Add(btn_search);
            Controls.Add(label6);
            Controls.Add(groupBox1);
            Name = "QLLopHoc";
            Size = new Size(1346, 1053);
            Load += QLSinhVien_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }   
        #endregion
        private GroupBox groupBox1;
        private ComboBox comboBox2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label txt_date;
        private Label txt_name;
        private Label txt_mssv;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button btn_search;
        private Label label6;
        private Button btn_refesh;
        private Button btn_delete;
        private Button btn_update;
        private Button btn_add;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label1;
        private TextBox textBox5;
        private Label label2;
    }
}
