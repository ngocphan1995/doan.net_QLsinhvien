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
using System.Data.OleDb;
using xls = Microsoft.Office.Interop.Excel;//import thu vien Interop.exel vào để làm việc
using System.Data.Common;
namespace DOAN_QLSV
{
    public partial class Diem : UserControl
    {
        private static Diem _instance;
        public static Diem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Diem();
                return _instance;
            }
        }
        public Diem()
        {
            InitializeComponent();
        }
        //tạo một bảng tạm để chứa dữ liệu lấy từ file exel vào
        private DataTable oTbl=new DataTable();
        //mở file để lấy thông tin về file
        private string fileName;
        //method dọc du lieu tu exel vao table
        private void readExel(){
            fileName=txtFileName.Text;
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
        private void Diem_Load(object sender, EventArgs e)
        {
            DropDownListMH();
            //Load_data();
        }
        void Load_data()
        {
            using (var conn = SQL.GetConnection())
            {

                SqlCommand sqlCmd = new SqlCommand("SELECT * from Diem", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter sqlAdap = new SqlDataAdapter(sqlCmd);
                sqlAdap.Fill(dt);
                DSDiem.DataSource = dt;              
                conn.Close();
            }
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
                //cbtheloai.AutoPostBack = true;
                conn.Close();
                conn.Dispose();
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            //khi click vào nut brows thì sẽ mở ra hộp thoại
            OpenFileDialog fdialog=new OpenFileDialog();
            fdialog.Filter ="exel file | *.xls;*.xlsx";
            fdialog.FilterIndex=1;//tro vao vi tri dau tien cua bo loc
           // fdialog.RestoreDirectory=true;//nho duong dan cua lan chon truoc
            fdialog.Multiselect=false;//khong cho phep chon nhie file cung luc
            fdialog.Title="Chọn file exel";//tiêu đề họp thoại
            if(fdialog.ShowDialog()==DialogResult.OK){
                txtFileName.Text = fdialog.FileName;
                readExel();
                if (oTbl != null)
                {
                    DSDiem.DataSource = oTbl;
                }
            }
            else{
                MessageBox.Show("Không có dữ liệu !");
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = SQL.GetConnection())
                {

                    SqlCommand sqlCmd = new SqlCommand("ThemDiemSV", conn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@MaSv", txtMaSv.Text);
                    sqlCmd.Parameters.Add("@MaMon", cmbMH.SelectedValue);
                    sqlCmd.Parameters.Add("@DiemTP", txtDiemTP.Text);
                    sqlCmd.Parameters.Add("@DiemThi", txtDiemThi.Text);
                    sqlCmd.Parameters.Add("@NgayCapNhat", DateTime.Now);
                    sqlCmd.ExecuteNonQuery();
                    conn.Close();
                    txtMaSv.Text = "";
                    txtDiemTP.Text = "";
                    txtDiemThi.Text = "";

                    MessageBox.Show("Thêm Thành Công !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khóa bị trùng !");
            }
        }

        private void btnThemds_Click(object sender, EventArgs e)
        {
            try
            {
                
                    for (int i = 0; i < DSDiem.Rows.Count - 1; i++)
                    {
                        using (var conn = SQL.GetConnection())
                        {
                            SqlCommand sqlCmd = new SqlCommand("ThemDiemSV", conn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.Add("@MaSv", DSDiem.Rows[i].Cells["Masv"].Value);
                            sqlCmd.Parameters.Add("@MaMon", DSDiem.Rows[i].Cells["MaMon"].Value);
                            sqlCmd.Parameters.Add("@DiemTP", DSDiem.Rows[i].Cells["DiemTP"].Value);
                            sqlCmd.Parameters.Add("@DiemThi", DSDiem.Rows[i].Cells["DiemThi"].Value);
                            sqlCmd.Parameters.Add("@NgayCapNhat", DateTime.Now);
                            sqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }                    

                    MessageBox.Show("Thêm Thành Công !");
                           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khóa bị trùng !");
            }
        }

       
        
        
        
    }
}
