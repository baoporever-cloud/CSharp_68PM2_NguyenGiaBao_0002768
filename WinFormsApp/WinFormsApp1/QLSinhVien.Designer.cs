
namespace WinFormsApp1
{
    partial class QLSinhVien
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
            groupBox1 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            txt_class = new Label();
            txt_gender = new Label();
            txt_date = new Label();
            txt_name = new Label();
            txt_mssv = new Label();
            btn_add = new Button();
            btn_update = new Button();
            btn_refesh = new Button();
            btn_delete = new Button();
            label6 = new Label();
            btn_search = new Button();
            textBox3 = new TextBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label7 = new Label();
            colorDialog1 = new ColorDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(txt_class);
            groupBox1.Controls.Add(txt_gender);
            groupBox1.Controls.Add(txt_date);
            groupBox1.Controls.Add(txt_name);
            groupBox1.Controls.Add(txt_mssv);
            groupBox1.Location = new Point(24, 42);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(539, 697);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sinh viên ";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(29, 375);
            dateTimePicker1.Margin = new Padding(4, 5, 4, 5);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(472, 31);
            dateTimePicker1.TabIndex = 9;
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
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            comboBox1.Location = new Point(29, 512);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(472, 33);
            comboBox1.TabIndex = 7;
            comboBox1.Text = "Nam";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(29, 244);
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
            // txt_class
            // 
            txt_class.AutoSize = true;
            txt_class.Location = new Point(25, 580);
            txt_class.Margin = new Padding(4, 0, 4, 0);
            txt_class.Name = "txt_class";
            txt_class.Size = new Size(46, 25);
            txt_class.TabIndex = 4;
            txt_class.Text = "Lớp:";
            // 
            // txt_gender
            // 
            txt_gender.AutoSize = true;
            txt_gender.Location = new Point(25, 456);
            txt_gender.Margin = new Padding(4, 0, 4, 0);
            txt_gender.Name = "txt_gender";
            txt_gender.Size = new Size(86, 25);
            txt_gender.TabIndex = 3;
            txt_gender.Text = "Giới Sinh:";
            // 
            // txt_date
            // 
            txt_date.AutoSize = true;
            txt_date.Location = new Point(25, 323);
            txt_date.Margin = new Padding(4, 0, 4, 0);
            txt_date.Name = "txt_date";
            txt_date.Size = new Size(97, 25);
            txt_date.TabIndex = 2;
            txt_date.Text = "Ngày Sinh:";
            // 
            // txt_name
            // 
            txt_name.AutoSize = true;
            txt_name.Location = new Point(25, 195);
            txt_name.Margin = new Padding(4, 0, 4, 0);
            txt_name.Name = "txt_name";
            txt_name.Size = new Size(93, 25);
            txt_name.TabIndex = 1;
            txt_name.Text = "Họ và tên:";
            // 
            // txt_mssv
            // 
            txt_mssv.AutoSize = true;
            txt_mssv.Location = new Point(25, 67);
            txt_mssv.Margin = new Padding(4, 0, 4, 0);
            txt_mssv.Name = "txt_mssv";
            txt_mssv.Size = new Size(119, 25);
            txt_mssv.TabIndex = 0;
            txt_mssv.Text = "Mã Sinh Viên:";
            // 
            // btn_add
            // 
            btn_add.BackColor = Color.MediumTurquoise;
            btn_add.FlatStyle = FlatStyle.Flat;
            btn_add.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_add.ForeColor = SystemColors.Control;
            btn_add.Location = new Point(24, 765);
            btn_add.Margin = new Padding(4, 5, 4, 5);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(254, 75);
            btn_add.TabIndex = 3;
            btn_add.Text = "Thêm ";
            btn_add.UseVisualStyleBackColor = false;
            btn_add.Click += btn_add_Click;
            // 
            // btn_update
            // 
            btn_update.BackColor = Color.SpringGreen;
            btn_update.FlatStyle = FlatStyle.Flat;
            btn_update.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_update.ForeColor = SystemColors.Control;
            btn_update.Location = new Point(308, 765);
            btn_update.Margin = new Padding(4, 5, 4, 5);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(255, 75);
            btn_update.TabIndex = 4;
            btn_update.Text = "Sửa";
            btn_update.UseVisualStyleBackColor = false;
            // 
            // btn_refesh
            // 
            btn_refesh.BackColor = SystemColors.ScrollBar;
            btn_refesh.FlatStyle = FlatStyle.Flat;
            btn_refesh.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_refesh.ForeColor = SystemColors.Control;
            btn_refesh.Location = new Point(308, 868);
            btn_refesh.Margin = new Padding(4, 5, 4, 5);
            btn_refesh.Name = "btn_refesh";
            btn_refesh.Size = new Size(255, 75);
            btn_refesh.TabIndex = 6;
            btn_refesh.Text = "Làm mới";
            btn_refesh.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            btn_delete.BackColor = Color.Crimson;
            btn_delete.FlatStyle = FlatStyle.Flat;
            btn_delete.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_delete.ForeColor = SystemColors.Control;
            btn_delete.Location = new Point(24, 868);
            btn_delete.Margin = new Padding(4, 5, 4, 5);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(254, 75);
            btn_delete.TabIndex = 5;
            btn_delete.Text = "Xóa";
            btn_delete.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(581, 51);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(254, 22);
            label6.TabIndex = 7;
            label6.Text = "Tìm kiếm (Tên/Mã SV/ Lớp)";
            label6.Click += label6_Click;
            // 
            // btn_search
            // 
            btn_search.BackColor = Color.SlateGray;
            btn_search.FlatStyle = FlatStyle.Flat;
            btn_search.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_search.ForeColor = SystemColors.Control;
            btn_search.Location = new Point(1059, 109);
            btn_search.Margin = new Padding(4, 5, 4, 5);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(150, 66);
            btn_search.TabIndex = 8;
            btn_search.Text = "Tìm";
            btn_search.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(585, 109);
            textBox3.Margin = new Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(439, 31);
            textBox3.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(581, 185);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RightToLeft = RightToLeft.No;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(929, 639);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã SV";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Họ và Tên";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Giới Tính ";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Ngày Sinh";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Lớp";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(638, 850);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(110, 83);
            button1.TabIndex = 12;
            button1.Text = "<<";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(773, 850);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(110, 83);
            button2.TabIndex = 13;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(1218, 850);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(110, 83);
            button3.TabIndex = 14;
            button3.Text = ">";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(1364, 850);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(110, 83);
            button4.TabIndex = 15;
            button4.Text = ">>";
            button4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(983, 878);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(176, 25);
            label7.TabIndex = 16;
            label7.Text = "Trang 1/1 | 3 bản ghi";
            label7.Click += label7_Click;
            // 
            // QLSinhVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox3);
            Controls.Add(btn_search);
            Controls.Add(label6);
            Controls.Add(btn_refesh);
            Controls.Add(btn_delete);
            Controls.Add(btn_update);
            Controls.Add(btn_add);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "QLSinhVien";
            Size = new Size(1599, 1096);
            Load += QLSinhVien_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txt_class;
        private System.Windows.Forms.Label txt_gender;
        private System.Windows.Forms.Label txt_date;
        private System.Windows.Forms.Label txt_name;
        private System.Windows.Forms.Label txt_mssv;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_refesh;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private ColorDialog colorDialog1;
    }
}