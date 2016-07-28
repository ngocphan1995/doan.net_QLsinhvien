using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DOAN_QLSV
{
    public partial class ThongKeSV : UserControl
    {

        private static ThongKeSV _instance;
        public static ThongKeSV Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ThongKeSV();
                return _instance;
            }
        }
        public ThongKeSV()
        {
            InitializeComponent();
        }
        void DropDownListLop()
        {
            using (var conn = SQL.GetConnection())
            {
                SqlCommand sqlCmd = new SqlCommand("Select * from Lop", conn);
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                sqlAdap.Fill(dt);
                cmbThongTin.DataSource = dt;
                cmbThongTin.DisplayMember = "TenLop";
                cmbThongTin.ValueMember = "MaLop";

                //cbtheloai.AutoPostBack = true;
                conn.Close();
                conn.Dispose();
            }
        }
        private void ThongKeSV_Load(object sender, EventArgs e)
        {
            DropDownListLop();
            DataTable dtblDataSource = new DataTable();
            dtblDataSource.Columns.Add("DisplayMember");


            dtblDataSource.Rows.Add("Lớp");
            dtblDataSource.Rows.Add("Giới Tính");


            cmbThongKe.Items.Clear();
            cmbThongKe.DataSource = dtblDataSource;
            cmbThongKe.DisplayMember = "DisplayMember";
            cmbThongKe.ValueMember = "DisplayMember";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var conn = SQL.GetConnection();
            if (cmbThongKe.SelectedValue.ToString() == "Lớp")
            {
                String str = "select count(*) as SoSinhVien from SinhVien where MaLop=" + cmbThongTin.SelectedValue.ToString() + " group by MaLop";
                SqlCommand com = new SqlCommand(str, conn);
                SqlDataReader reader = com.ExecuteReader();

                reader.Read();
                label4.Text = "Số sinh viên của lớp là:" + reader["SoSinhVien"].ToString();


                reader.Close();
                conn.Close();
            }
            if (cmbThongKe.SelectedValue.ToString() == "Giới Tính")
            {
                String str = "select count(*) as SoSinhVien from SinhVien where GioiTinh='" + cmbThongTin.SelectedValue.ToString() + "'";
                SqlCommand com = new SqlCommand(str, conn);
                SqlDataReader reader = com.ExecuteReader();

                reader.Read();
                label4.Text = "Số sinh viên có giới tính vừa nhập là:" + reader["SoSinhVien"].ToString();


                reader.Close();
                conn.Close();
            }
        }

        private void cmbThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThongKe.SelectedValue.ToString() == "Lớp")
            {
                //combox thong tin
                var conn = SQL.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("Select * from Lop", conn);
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                sqlAdap.Fill(dt);
                cmbThongTin.DataSource = dt;
                cmbThongTin.DisplayMember = "TenLop";
                cmbThongTin.ValueMember = "MaLop";

                //xau bao cao





            }
            if (cmbThongKe.SelectedValue.ToString() == "Giới Tính")
            {
                DataTable dtblDataSource = new DataTable();
                dtblDataSource.Columns.Add("DisplayMember");
                dtblDataSource.Columns.Add("ValueMember");


                dtblDataSource.Rows.Add("Nam", "True");
                dtblDataSource.Rows.Add("Nữ", "False");


                //cmbThongTin.Items.Clear();
                cmbThongTin.DataSource = dtblDataSource;
                cmbThongTin.DisplayMember = "DisplayMember";
                cmbThongTin.ValueMember = "ValueMember";
            }
        }
    }
}
