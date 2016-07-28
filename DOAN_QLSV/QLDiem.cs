using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_QLSV
{
    public partial class QLDiem : UserControl
    {
        private static QLDiem _instance;
        public static QLDiem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QLDiem();
                return _instance;
            }
        }
        public QLDiem()
        {
            InitializeComponent();
        }

        private void nhậpĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!content.Controls.Contains(Diem.Instance))
            {
                content.Controls.Add(Diem.Instance);
                Diem.Instance.Dock = DockStyle.Fill;
                Diem.Instance.BringToFront();
            }
            else Diem.Instance.BringToFront();
        }

        private void xemĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!content.Controls.Contains(XemDiem.Instance))
            {
                content.Controls.Add(XemDiem.Instance);
                XemDiem.Instance.Dock = DockStyle.Fill;
                XemDiem.Instance.BringToFront();
            }
            else XemDiem.Instance.BringToFront();
        }

        private void điểmSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!content.Controls.Contains(DiemSV.Instance))
            {
                content.Controls.Add(DiemSV.Instance);
                DiemSV.Instance.Dock = DockStyle.Fill;
                DiemSV.Instance.BringToFront();
            }
            else DiemSV.Instance.BringToFront();
        }

        private void QLDiem_Load(object sender, EventArgs e)
        {
            if (!content.Controls.Contains(Diem.Instance))
            {
                content.Controls.Add(Diem.Instance);
                Diem.Instance.Dock = DockStyle.Fill;
                Diem.Instance.BringToFront();
            }
            else Diem.Instance.BringToFront();
        }
    }
}
