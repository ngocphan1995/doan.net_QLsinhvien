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
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Common;

namespace DOAN_QLSV
{

   
    public partial class Sinhvien : UserControl
    {
        private static Sinhvien _instance;
        public static Sinhvien Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Sinhvien();
                return _instance;
            }
        }
        public Sinhvien()
        {
            InitializeComponent();
        }

        //tạo một bảng tạm để chứa dữ liệu lấy từ file exel vào
        private DataTable oTbl = new DataTable();
        //mở file để lấy thông tin về file
        private string fileName;
        //method dọc du lieu tu exel vao table
        private void readExel()
        {
            fileName = txtFileName.Text;
            //kiểm tra xem dã chọn file hay chưa
            if (fileName == null)
            {
                MessageBox.Show("Bạn chưa chọn file !");

            }
            else
            {
                try
                {

                    OleDbCommand excelCommand = new OleDbCommand(); OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();

                    string excelConnStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fileName + "; Extended Properties =Excel 8.0;";

                    OleDbConnection excelConn = new OleDbConnection(excelConnStr);

                    excelConn.Open();

                    DataTable dtPatterns = new DataTable();
                    excelCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", excelConn);

                    excelDataAdapter.SelectCommand = excelCommand;

                    excelDataAdapter.Fill(dtPatterns);
                    excelConn.Close();
                    oTbl = dtPatterns;
                }
                catch
                {
                    // error
                }


            }
        }
        
        private void Sinhvien_Load(object sender, EventArgs e)
        {
            GridTempt.Visible = true;
            Load_data();
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
            DataGridViewCheckBoxColumn Xoa = new DataGridViewCheckBoxColumn();
            Xoa.Name = "Xoa";
            Xoa.HeaderText = "Chọn";
            dgSinhVien.Columns.Insert(0, Xoa);
            Xoa.Width = 50;

            Bitmap img = new Bitmap(@"E:\CNPM\DOAN_QLSV\DOAN_QLSV\img\edit.gif");
            DataGridViewImageColumn Sua = new DataGridViewImageColumn();
            Sua.Name = "Sua";
            Sua.HeaderText = "Sửa";
            Sua.Image = img;
            dgSinhVien.Columns.Insert(1, Sua);
            Sua.Width = 50;

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

        private void dgSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSinhVien.Rows[e.RowIndex].Cells[1].Selected)
            {
                txtMaSV.Text = dgSinhVien.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtHoTen.Text = dgSinhVien.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbLop.Text = dgSinhVien.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (dgSinhVien.Rows[e.RowIndex].Cells[5].Value.ToString().ToLower().Equals("Nam"))
                {
                    rdNam.Checked = true;
                }
                else if (dgSinhVien.Rows[e.RowIndex].Cells[5].Value.ToString().ToLower().Equals(null))
                {
                    rdNam.Checked = false;
                    rdNu.Checked = false;
                }
                else
                {
                    rdNu.Checked = true;
                }


                dateTimePicker1.Text = dgSinhVien.Rows[e.RowIndex].Cells["ngaysinh"].Value.ToString();

                txtQueQuan.Text = dgSinhVien.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtSoDienThoai.Text = dgSinhVien.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtMaSV.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (var conn = SQL.GetConnection())
            {

                SqlCommand sqlCmd = new SqlCommand("UpdateSV", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@MaSv", Int32.Parse(txtMaSV.Text));
                sqlCmd.Parameters.Add("@Ten", txtHoTen.Text);
                sqlCmd.Parameters.Add("@MaLop", Int32.Parse(cmbLop.SelectedValue.ToString()));
                sqlCmd.Parameters.Add("@NgaySinh", this.dateTimePicker1.Value.Date);
                sqlCmd.Parameters.Add("@quequan", txtQueQuan.Text);
                sqlCmd.Parameters.Add("@SDT", txtSoDienThoai.Text);

                if (rdNam.Checked)
                {
                    sqlCmd.Parameters.AddWithValue("@GioiTinh", true);
                }
                else
                    sqlCmd.Parameters.AddWithValue("@GioiTinh", false);
                sqlCmd.ExecuteNonQuery();
                conn.Close();
                txtMaSV.Text = "";
                txtHoTen.Text = "";
                dateTimePicker1.Text = "";
                txtQueQuan.Text = "";
                txtSoDienThoai.Text = "";
                MessageBox.Show("Cập Nhật Thành Công !");
                Load_data();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = (from row in dgSinhVien.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["Xoa"].Value) == true
                                                  select row).ToList();
            if (MessageBox.Show(string.Format("Do you want to delete {0} rows?", selectedRows.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    using (var con = SQL.GetConnection())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM SinhVien WHERE MaSv = @sinhvien", con))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@sinhvien", row.Cells["masv"].Value);

                                cmd.ExecuteNonQuery();
                                string message = "xóa thành công";
                                string caption = "Thông báo";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;

                                // Displays the MessageBox.

                                result = MessageBox.Show(message, caption, buttons);
                                Load_data();
                                // con.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            string message = "Bạn không được xóa sinh viên này ?";
                            string caption = "Thông báo";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;

                            // Displays the MessageBox.

                            result = MessageBox.Show(message, caption, buttons);
                            // System.Windows.Forms.Application.Exit();
                        }
                    }
                }

                //this.BindGrid();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            using (var conn = SQL.GetConnection())
            {

                SqlCommand sqlCmd = new SqlCommand("ThemSV", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Masv", Int32.Parse(txtMaSV.Text));
                sqlCmd.Parameters.Add("@Ten", txtHoTen.Text);
                sqlCmd.Parameters.Add("@MaLop", Int32.Parse(cmbLop.SelectedValue.ToString()));
                sqlCmd.Parameters.Add("@NgaySinh", this.dateTimePicker1.Value.Date);
                sqlCmd.Parameters.Add("@quequan", txtQueQuan.Text);
                sqlCmd.Parameters.Add("@SDT", txtSoDienThoai.Text);

                if (rdNam.Checked)
                {
                    sqlCmd.Parameters.AddWithValue("@GioiTinh", true);
                }
                else
                    sqlCmd.Parameters.AddWithValue("@GioiTinh", false);
                sqlCmd.ExecuteNonQuery();
                conn.Close();
                txtMaSV.Text = "";
                txtHoTen.Text = "";
                dateTimePicker1.Text = "";
                txtQueQuan.Text = "";
                txtSoDienThoai.Text = "";
                MessageBox.Show("Thêm Thành Công !");
                Load_data();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "";
            txtHoTen.Text = "";
            dateTimePicker1.Text = "";
            txtQueQuan.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            fdialog.Filter = "exel file | *.xls;*.xlsx";
            fdialog.FilterIndex = 1;//tro vao vi tri dau tien cua bo loc
            fdialog.RestoreDirectory = true;//nho duong dan cua lan chon truoc
            fdialog.Multiselect = false;//khong cho phep chon nhie file cung luc
            fdialog.Title = "Chọn file exel";//tiêu đề họp thoại
            if (fdialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fdialog.FileName;
                readExel();
                if (oTbl != null)
                {
                    GridTempt.DataSource = oTbl;
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu !");
            }
        }

        private void btnThemds_Click(object sender, EventArgs e)
        {
           

                for (int i = 0; i < GridTempt.Rows.Count - 1; i++)
                {
                    using (var conn = SQL.GetConnection())
                    {
                        SqlCommand sqlCmd = new SqlCommand("ThemSV", conn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@Masv", GridTempt.Rows[i].Cells["Masv"].Value);
                        sqlCmd.Parameters.Add("@Ten", GridTempt.Rows[i].Cells["HoTen"].Value);
                        sqlCmd.Parameters.Add("@MaLop", GridTempt.Rows[i].Cells["MaLop"].Value);
                        sqlCmd.Parameters.Add("@NgaySinh",GridTempt.Rows[i].Cells["NgaySinh"].Value);
                        sqlCmd.Parameters.Add("@QueQuan", GridTempt.Rows[i].Cells["QueQuan"].Value);
                        sqlCmd.Parameters.Add("@SDT", GridTempt.Rows[i].Cells["SDT"].Value.ToString());
                        sqlCmd.Parameters.Add("@GioiTinh", GridTempt.Rows[i].Cells["GioiTinh"].Value); //
                        sqlCmd.ExecuteNonQuery();
                        conn.Close();
                       
                    }
                }

                MessageBox.Show("Thêm Thành Công !");
                Load_data();
            
            
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }
        
        
    }
}
