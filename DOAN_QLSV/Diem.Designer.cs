namespace DOAN_QLSV
{
    partial class Diem
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
            this.lbTong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaSv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiemTP = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.labThongbao = new System.Windows.Forms.Label();
            this.DSDiem = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiemThi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMH = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnThemds = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DSDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTong
            // 
            this.lbTong.AutoSize = true;
            this.lbTong.Location = new System.Drawing.Point(166, 372);
            this.lbTong.Name = "lbTong";
            this.lbTong.Size = new System.Drawing.Size(0, 13);
            this.lbTong.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(61, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Mã Sinh Viên";
            // 
            // txtMaSv
            // 
            this.txtMaSv.Location = new System.Drawing.Point(166, 26);
            this.txtMaSv.Name = "txtMaSv";
            this.txtMaSv.Size = new System.Drawing.Size(224, 20);
            this.txtMaSv.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(80, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Môn Học";
            // 
            // txtDiemTP
            // 
            this.txtDiemTP.Location = new System.Drawing.Point(167, 79);
            this.txtDiemTP.Name = "txtDiemTP";
            this.txtDiemTP.Size = new System.Drawing.Size(224, 20);
            this.txtDiemTP.TabIndex = 66;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(169, 149);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(66, 31);
            this.btnThem.TabIndex = 67;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // labThongbao
            // 
            this.labThongbao.AutoSize = true;
            this.labThongbao.ForeColor = System.Drawing.Color.Red;
            this.labThongbao.Location = new System.Drawing.Point(434, 167);
            this.labThongbao.Name = "labThongbao";
            this.labThongbao.Size = new System.Drawing.Size(0, 13);
            this.labThongbao.TabIndex = 70;
            // 
            // DSDiem
            // 
            this.DSDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DSDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DSDiem.Location = new System.Drawing.Point(12, 201);
            this.DSDiem.Name = "DSDiem";
            this.DSDiem.Size = new System.Drawing.Size(773, 322);
            this.DSDiem.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(38, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Điểm Thành Phần";
            // 
            // txtDiemThi
            // 
            this.txtDiemThi.Location = new System.Drawing.Point(169, 105);
            this.txtDiemThi.Name = "txtDiemThi";
            this.txtDiemThi.Size = new System.Drawing.Size(224, 20);
            this.txtDiemThi.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(80, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "Điểm Thi";
            // 
            // cmbMH
            // 
            this.cmbMH.FormattingEnabled = true;
            this.cmbMH.Location = new System.Drawing.Point(166, 52);
            this.cmbMH.Name = "cmbMH";
            this.cmbMH.Size = new System.Drawing.Size(206, 21);
            this.cmbMH.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(489, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 21);
            this.label1.TabIndex = 79;
            this.label1.Text = "Chọn Tệp Tải Lên";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(470, 38);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(224, 20);
            this.txtFileName.TabIndex = 80;
            // 
            // btnChon
            // 
            this.btnChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnChon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnChon.FlatAppearance.BorderSize = 0;
            this.btnChon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChon.ForeColor = System.Drawing.Color.White;
            this.btnChon.Location = new System.Drawing.Point(710, 38);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(66, 35);
            this.btnChon.TabIndex = 81;
            this.btnChon.Text = "Chọn...";
            this.btnChon.UseVisualStyleBackColor = false;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnThemds
            // 
            this.btnThemds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnThemds.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnThemds.FlatAppearance.BorderSize = 0;
            this.btnThemds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemds.ForeColor = System.Drawing.Color.White;
            this.btnThemds.Location = new System.Drawing.Point(483, 71);
            this.btnThemds.Name = "btnThemds";
            this.btnThemds.Size = new System.Drawing.Size(99, 35);
            this.btnThemds.TabIndex = 82;
            this.btnThemds.Text = "Thêm Cả Danh Sách";
            this.btnThemds.UseVisualStyleBackColor = false;
            this.btnThemds.Click += new System.EventHandler(this.btnThemds_Click);
            // 
            // Diem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnThemds);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMH);
            this.Controls.Add(this.lbTong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDiemThi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DSDiem);
            this.Controls.Add(this.labThongbao);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDiemTP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaSv);
            this.Controls.Add(this.label2);
            this.Name = "Diem";
            this.Size = new System.Drawing.Size(800, 544);
            this.Load += new System.EventHandler(this.Diem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaSv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiemTP;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label labThongbao;
        private System.Windows.Forms.DataGridView DSDiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiemThi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnThemds;


    }
}
