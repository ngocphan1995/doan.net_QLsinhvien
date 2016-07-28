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
    public partial class DiemSV : UserControl
    {
        private static DiemSV _instance;
        public static DiemSV Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DiemSV();
                return _instance;
            }
        }
        public DiemSV()
        {
            InitializeComponent();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            using (var conn = SQL.GetConnection())
            {

                SqlCommand sqlCmd = new SqlCommand("SELECT SinhVien.HoTen,MonHoc.TenMon,DiemTP,DiemThi,DiemTongKet,NgayCapNhat from Diem,MonHoc,SinhVien where SinhVien.Masv=Diem.Masv and MonHoc.MaMon=Diem.MaMon and Diem.Masv='" + txtMasv.Text+ "'", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                sqlAdap.Fill(dt);
                DSDiem.DataSource = dt;
                conn.Close();
            }
            DiemTB();
        }

        private void DiemSV_Load(object sender, EventArgs e)
        {
            Load_data(); 
        }
        void Load_data()
        {

            using (var conn = SQL.GetConnection())
            {
                
                SqlCommand sqlCmd = new SqlCommand("SELECT SinhVien.HoTen,MonHoc.TenMon,DiemTP,DiemThi,DiemTongKet,NgayCapNhat from Diem,MonHoc,SinhVien where SinhVien.Masv=Diem.Masv and MonHoc.MaMon=Diem.MaMon ", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                sqlAdap.Fill(dt);
                DSDiem.DataSource = dt;
                conn.Close();
            }
        }
        void DiemTB()
        {
            int sum = DSDiem.Rows.Count - 1;
            float s = 0;
            for (int i = 0; i < DSDiem.Rows.Count - 1; i++)
            {
                s = s + float.Parse(DSDiem.Rows[i].Cells["DiemTongKet"].Value.ToString());                
            }
            float diem = s / sum;
            lbTichLuy.Text = diem.ToString();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExportToExcel excel = new ExportToExcel();
            // Lấy về nguồn dữ liệu cần Export là 1 DataTable         
                     
            DataTable dt = (DataTable) DSDiem.DataSource;
            excel.Export(dt, "Danh sach", "Bảng Điểm");
        }


    }
}
