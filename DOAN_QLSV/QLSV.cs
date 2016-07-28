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
    public partial class QLSV : UserControl
    {
        private static QLSV _instance;
        public static QLSV Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QLSV();
                return _instance;
            }
        }
        public QLSV()
        {
            InitializeComponent();
        }

        private void danhSáchSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!contentSV.Controls.Contains(Sinhvien.Instance))
            {
                contentSV.Controls.Add(Sinhvien.Instance);
                Sinhvien.Instance.Dock = DockStyle.Fill;
                Sinhvien.Instance.BringToFront();
            }
            else Sinhvien.Instance.BringToFront();
        }

       

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!contentSV.Controls.Contains(TimKemSV.Instance))
            {
                contentSV.Controls.Add(TimKemSV.Instance);
                TimKemSV.Instance.Dock = DockStyle.Fill;
                TimKemSV.Instance.BringToFront();
            }
            else TimKemSV.Instance.BringToFront();
        }

        private void QLSV_Load(object sender, EventArgs e)
        {
            if (!contentSV.Controls.Contains(Sinhvien.Instance))
            {
                contentSV.Controls.Add(Sinhvien.Instance);
                Sinhvien.Instance.Dock = DockStyle.Fill;
                Sinhvien.Instance.BringToFront();
            }
            else Sinhvien.Instance.BringToFront();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!contentSV.Controls.Contains(ThongKeSV.Instance))
            {
                contentSV.Controls.Add(ThongKeSV.Instance);
                ThongKeSV.Instance.Dock = DockStyle.Fill;
                ThongKeSV.Instance.BringToFront();
            }
            else ThongKeSV.Instance.BringToFront();
        }
    }
}
