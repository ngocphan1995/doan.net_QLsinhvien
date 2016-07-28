using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_QLSV
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSinhvien_Click(object sender, EventArgs e)
        {
            if (!component.Controls.Contains(QLSV.Instance))
            {
                component.Controls.Add(QLSV.Instance);
                QLSV.Instance.Dock = DockStyle.Fill;
                QLSV.Instance.BringToFront();
            }
            else QLSV.Instance.BringToFront();
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            if (!component.Controls.Contains(QLDiem.Instance))
            {
                component.Controls.Add(QLDiem.Instance);
                QLDiem.Instance.Dock = DockStyle.Fill;
                QLDiem.Instance.BringToFront();
            }
            else QLDiem.Instance.BringToFront();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMonhoc_Click(object sender, EventArgs e)
        {
            if (!component.Controls.Contains(MonHoc.Instance))
            {
                component.Controls.Add(MonHoc.Instance);
                MonHoc.Instance.Dock = DockStyle.Fill;
                MonHoc.Instance.BringToFront();
            }
            else MonHoc.Instance.BringToFront();
        }

        private void btnLich_Click(object sender, EventArgs e)
        {
            if (!component.Controls.Contains(Lich.Instance))
            {
                component.Controls.Add(Lich.Instance);
                Lich.Instance.Dock = DockStyle.Fill;
                Lich.Instance.BringToFront();
            }
            else Lich.Instance.BringToFront();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (!component.Controls.Contains(QLSV.Instance))
            {
                component.Controls.Add(QLSV.Instance);
                QLSV.Instance.Dock = DockStyle.Fill;
                QLSV.Instance.BringToFront();
            }
            else QLSV.Instance.BringToFront();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!component.Controls.Contains(User.Instance))
            {
                component.Controls.Add(User.Instance);
                User.Instance.Dock = DockStyle.Fill;
                User.Instance.BringToFront();
            }
            else User.Instance.BringToFront();
        }
    }
}
