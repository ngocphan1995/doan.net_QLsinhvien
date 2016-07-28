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
    public partial class XemDiem : UserControl
    {
        private static XemDiem _instance;
        public static XemDiem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new XemDiem();
                return _instance;
            }
        }
        public XemDiem()
        {
            InitializeComponent();
        }

        private void XemDiem_Load(object sender, EventArgs e)
        {
            DropDownListMH();
            DropDownListLop();
            Load_data();
            Diem();
            DSDiem.Columns[0].HeaderText = "Mã sinh viên";
            DSDiem.Columns[0].Width = 100;
            DSDiem.Columns[1].HeaderText = "Môn Học";
            DSDiem.Columns[1].Width = 100;
            DSDiem.Columns[2].HeaderText = "Mã Môn";
            DSDiem.Columns[2].Width = 50;
            DSDiem.Columns[3].HeaderText = "Điểm TP";
            DSDiem.Columns[3].Width = 50;
            DSDiem.Columns[4].HeaderText = "Điểm Thi";
            DSDiem.Columns[4].Width = 50;
            DSDiem.Columns[5].HeaderText = "Điểm Tổng Kêt";
            DSDiem.Columns[5].Width = 50;
            DSDiem.Columns[6].HeaderText = "Ngày Cập Nhật";
            DSDiem.Columns[6].Width = 100;
            DataGridViewCheckBoxColumn Xoa = new DataGridViewCheckBoxColumn();
            Xoa.Name = "Xoa";
            Xoa.HeaderText = "Xóa";
            DSDiem.Columns.Insert(0, Xoa);
            Xoa.Width = 50;

            Bitmap img = new Bitmap(@"E:\CNPM\DOAN_QLSV\DOAN_QLSV\img\edit.gif");
            DataGridViewImageColumn Sua = new DataGridViewImageColumn();
            Sua.Name = "Sua";
            Sua.HeaderText = "Sửa";
            Sua.Image = img;
            DSDiem.Columns.Insert(1, Sua);
            Sua.Width = 50;

        }
        void DropDownListMH()
        {
            using (var conn = SQL.GetConnection())
            {
                SqlCommand sqlCmd = new SqlCommand("Select * from MonHoc", conn);
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                sqlAdap.Fill(dt);
                cmbMH.DataSource = dt;
                cmbMH.DisplayMember = "TenMon";
                cmbMH.ValueMember = "MaMon";

                cmbMonHoc.DataSource = dt;
                cmbMonHoc.DisplayMember = "TenMon";
                cmbMonHoc.ValueMember = "MaMon";
                //cbtheloai.AutoPostBack = true;
                conn.Close();
                conn.Dispose();
            }
        }
        void DropDownListLop()
        {
            using (var conn = SQL.GetConnection())
            {
                SqlCommand sqlCmd = new SqlCommand("Select * from Lop", conn);
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                sqlAdap.Fill(dt);
                cmbLop.DataSource = dt;
                cmbLop.DisplayMember = "TenLop";
                cmbLop.ValueMember = "MaLop";
                
                //cbtheloai.AutoPostBack = true;
                conn.Close();
                conn.Dispose();
            }
        }

        
        void Load_data()
        {
            
            using (var conn = SQL.GetConnection())
            {
                string MaMon = cmbMonHoc.SelectedValue.ToString();
                string Lop = cmbLop.SelectedValue.ToString();
                SqlCommand sqlCmd = new SqlCommand("SELECT Diem.Masv,MonHoc.TenMon,MonHoc.MaMon,DiemTP,DiemThi,DiemTongKet,NgayCapNhat from Diem,MonHoc,SinhVien where MonHoc.MaMon=Diem.MaMon and SinhVien.Masv=Diem.Masv and Diem.MaMon='"+ MaMon +"' and SinhVien.MaLop='"+ Lop +"' ", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                sqlAdap.Fill(dt);
                DSDiem.DataSource = dt;
                conn.Close();
            }
        }

        private void DSDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DSDiem.Rows[e.RowIndex].Cells[1].Selected)
            {
                txtMasv.Text = DSDiem.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbMH.SelectedItem = DSDiem.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDTP.Text = DSDiem.Rows[e.RowIndex].Cells[5].Value.ToString();           
               
                txtDThi.Text = DSDiem.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtMasv.Enabled = false;
                cmbMH.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = SQL.GetConnection())
                {

                    SqlCommand sqlCmd = new SqlCommand("UpdateDiem", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@MaSv", txtMasv.Text);
                    sqlCmd.Parameters.Add("@MaMon", cmbMH.SelectedValue);
                    sqlCmd.Parameters.Add("@DiemTP", txtDTP.Text);
                    sqlCmd.Parameters.Add("@DiemThi", txtDThi.Text);
                    sqlCmd.Parameters.Add("@NgayCapNhat", DateTime.Now);
                    sqlCmd.ExecuteNonQuery();
                    conn.Close();
                    txtMasv.Enabled = true;
                    cmbMH.Enabled = true;
                    txtDTP.Text = "";
                    txtDThi.Text = "";

                    MessageBox.Show("Sửa thành công.");
                }
                Load_data();
                Diem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < DSDiem.Rows.Count; i++)
            {

                if (DSDiem.Rows[i].Cells[0].Selected)
                {
                    var conn = SQL.GetConnection();
                    SqlCommand sqlCmd = new SqlCommand("DeleteDiem", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@MaSv", DSDiem.Rows[i].Cells[2].Value);
                    sqlCmd.Parameters.Add("@MaMon", DSDiem.Rows[i].Cells[4].Value);
                    sqlCmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Xóa thành công");
                    Load_data();
                    Diem();
                }
            }
           
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            Load_data();
            Diem();
        }
        void Diem()
        {
            int sum = 0;
            int gioi = 0; int kha = 0;
            int tb = 0;
            int kem = 0;
            sum = DSDiem.Rows.Count - 1;
            lbsum.Text = sum.ToString();
            for (int i = 0; i < DSDiem.Rows.Count - 1; i++)
            {
                if (float.Parse(DSDiem.Rows[i].Cells["DiemTongKet"].Value.ToString()) >= 8) gioi++;
                if (float.Parse(DSDiem.Rows[i].Cells["DiemTongKet"].Value.ToString()) < 8 && float.Parse(DSDiem.Rows[i].Cells["DiemTongKet"].Value.ToString()) >= 6.5) kha++;
                if (float.Parse(DSDiem.Rows[i].Cells["DiemTongKet"].Value.ToString()) < 6.5 && float.Parse(DSDiem.Rows[i].Cells["DiemTongKet"].Value.ToString()) >= 4.0) tb++;
                if (float.Parse(DSDiem.Rows[i].Cells["DiemTongKet"].Value.ToString()) < 4.0) kem++;
            }
            lbYeu.Text = kem.ToString();
            lbKha.Text = kha.ToString();
            lbgioi.Text = gioi.ToString();
            lbTb.Text = tb.ToString();
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
