namespace DOAN_QLSV
{
    partial class DiemSV
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
            this.btnLoc = new System.Windows.Forms.Button();
            this.txtMasv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DSDiem = new System.Windows.Forms.DataGridView();
            this.lbdiem = new System.Windows.Forms.Label();
            this.lbTichLuy = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DSDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(398, 37);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(74, 31);
            this.btnLoc.TabIndex = 110;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // txtMasv
            // 
            this.txtMasv.Location = new System.Drawing.Point(132, 42);
            this.txtMasv.Name = "txtMasv";
            this.txtMasv.Size = new System.Drawing.Size(224, 20);
            this.txtMasv.TabIndex = 109;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(44, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "Mã Sinh Viên";
            // 
            // DSDiem
            // 
            this.DSDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DSDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DSDiem.Location = new System.Drawing.Point(0, 128);
            this.DSDiem.Name = "DSDiem";
            this.DSDiem.Size = new System.Drawing.Size(824, 287);
            this.DSDiem.TabIndex = 111;
            // 
            // lbdiem
            // 
            this.lbdiem.AutoSize = true;
            this.lbdiem.Location = new System.Drawing.Point(129, 97);
            this.lbdiem.Name = "lbdiem";
            this.lbdiem.Size = new System.Drawing.Size(62, 13);
            this.lbdiem.TabIndex = 112;
            this.lbdiem.Text = "Điểm Tổng:";
            // 
            // lbTichLuy
            // 
            this.lbTichLuy.AutoSize = true;
            this.lbTichLuy.ForeColor = System.Drawing.Color.Red;
            this.lbTichLuy.Location = new System.Drawing.Point(203, 97);
            this.lbTichLuy.Name = "lbTichLuy";
            this.lbTichLuy.Size = new System.Drawing.Size(13, 13);
            this.lbTichLuy.TabIndex = 113;
            this.lbTichLuy.Text = "0";
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnXuat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnXuat.FlatAppearance.BorderSize = 0;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(686, 91);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(74, 31);
            this.btnXuat.TabIndex = 114;
            this.btnXuat.Text = "Xuất File";
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // DiemSV
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.lbTichLuy);
            this.Controls.Add(this.lbdiem);
            this.Controls.Add(this.DSDiem);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.txtMasv);
            this.Controls.Add(this.label2);
            this.Name = "DiemSV";
            this.Size = new System.Drawing.Size(848, 433);
            this.Load += new System.EventHandler(this.DiemSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txtMasv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DSDiem;
        private System.Windows.Forms.Label lbdiem;
        private System.Windows.Forms.Label lbTichLuy;
        private System.Windows.Forms.Button btnXuat;
    }
}
