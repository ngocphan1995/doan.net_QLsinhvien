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
    public partial class TimKemSV : UserControl
    {
        private static TimKemSV _instance;
        public static TimKemSV Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TimKemSV();
                return _instance;
            }
        }
        public TimKemSV()
        {
            InitializeComponent();
        }

        private void TimKemSV_Load(object sender, EventArgs e)
        {
            Load_data();
            cmbtimkiem.SelectedIndexChanged -= cmbtimkiem_SelectedIndexChanged;
            var conn = SQL.GetConnection();
            SqlCommand sqlCmd = new SqlCommand("Select * from Lop", conn);
            SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            sqlAdap.Fill(dt);
            cmbtimkiem.DataSource = dt;
            cmbtimkiem.DisplayMember = "TenLop";
            cmbtimkiem.ValueMember = "MaLop";
            cmbtimkiem.SelectedIndexChanged += cmbtimkiem_SelectedIndexChanged;
        }
        void Load_data()
        {
            using (var conn = SQL.GetConnection())
            {
                //conn.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT MaSv,HoTen,TenLop,NgaySinh,Case GioiTinh  when '0' then N'Nữ' when '1' then N'Nam' end as GioiTinh,QueQuan,SDT FROM SinhVien,Lop where SinhVien.MaLop=Lop.MaLop", conn);
                DataTable table = new DataTable();
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                sqlAdap.Fill(table);
                dgSinhVien.DataSource = table;
                conn.Close();

            }
        }
        private void cmbtimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var conn = SQL.GetConnection())
            {
                //conn.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT MaSv,HoTen,TenLop,NgaySinh,Case GioiTinh  when '0' then N'Nữ' when '1' then N'Nam' end as GioiTinh,QueQuan,SDT FROM SinhVien,Lop where SinhVien.MaLop=Lop.MaLop and Lop.MaLop=" + cmbtimkiem.SelectedValue.ToString() + "", conn);
                DataTable table = new DataTable();
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                sqlAdap.Fill(table);
                dgSinhVien.DataSource = table;
                conn.Close();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var conn = SQL.GetConnection())
            {
                //conn.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT MaSv,HoTen,TenLop,NgaySinh,Case GioiTinh  when '0' then N'Nữ' when '1' then N'Nam' end as GioiTinh,QueQuan,SDT FROM SinhVien,Lop where SinhVien.MaLop=Lop.MaLop and HoTen like N'%" + textBox1.Text + "%'", conn);

                DataTable table = new DataTable();
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                sqlAdap.Fill(table);
                dgSinhVien.DataSource = table;
                conn.Close();

            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportToExcel excel = new ExportToExcel();
            // Lấy về nguồn dữ liệu cần Export là 1 DataTable         

            DataTable dt = (DataTable)dgSinhVien.DataSource;
            excel.Export(dt, "Danh sach", "Danh Sách Lớp");
        }
    }
}
