namespace DOAN_QLSV
{
    partial class QLDiem
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nhậpĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điểmSinhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.content = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpĐiểmToolStripMenuItem,
            this.xemĐiểmToolStripMenuItem,
            this.điểmSinhViênToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nhậpĐiểmToolStripMenuItem
            // 
            this.nhậpĐiểmToolStripMenuItem.Name = "nhậpĐiểmToolStripMenuItem";
            this.nhậpĐiểmToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.nhậpĐiểmToolStripMenuItem.Text = "Nhập Điểm";
            this.nhậpĐiểmToolStripMenuItem.Click += new System.EventHandler(this.nhậpĐiểmToolStripMenuItem_Click);
            // 
            // xemĐiểmToolStripMenuItem
            // 
            this.xemĐiểmToolStripMenuItem.Name = "xemĐiểmToolStripMenuItem";
            this.xemĐiểmToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.xemĐiểmToolStripMenuItem.Text = "Cập Nhật Điểm";
            this.xemĐiểmToolStripMenuItem.Click += new System.EventHandler(this.xemĐiểmToolStripMenuItem_Click);
            // 
            // điểmSinhViênToolStripMenuItem
            // 
            this.điểmSinhViênToolStripMenuItem.Name = "điểmSinhViênToolStripMenuItem";
            this.điểmSinhViênToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.điểmSinhViênToolStripMenuItem.Text = "Điểm Sinh Viên";
            this.điểmSinhViênToolStripMenuItem.Click += new System.EventHandler(this.điểmSinhViênToolStripMenuItem_Click);
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(13, 38);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(884, 544);
            this.content.TabIndex = 1;
            // 
            // QLDiem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.content);
            this.Controls.Add(this.menuStrip1);
            this.Name = "QLDiem";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.QLDiem_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nhậpĐiểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemĐiểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem điểmSinhViênToolStripMenuItem;
        private System.Windows.Forms.Panel content;
    }
}
