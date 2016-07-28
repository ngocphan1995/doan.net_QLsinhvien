using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_QLSV
{
    public partial class DangNhap : Form
    {

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Buoc 1: Cau hinh chuoi ket noi CSDL (Ket noi voi DB Loai 1)
            string SQLConnectString = @"server=DESKTOP-TNAI36E\SQLEXPRESS;uid=sa;pwd=Nthu_1995;database=D8CNPM";
            //Buoc 2: Khai bao doi tuong cua lop ket noi
            SqlConnection SQLConnectDB = new SqlConnection();
            //Buoc 3: Thiet lap thuoc chuoi ket noi voi bien cua chuoi ket doi da duoc cau hinh
            SQLConnectDB.ConnectionString = SQLConnectString;
            //Buoc 4: Mo ket noi
            SQLConnectDB.Open();
            //Buoc 5: Thao tac voi CSDL
            string SQLString = "select * from [tblUser] where TenDangNhap='" + txtTenDN.Text + "' and MatKhau='" + txtMatKhau.Text + "'";
            SqlCommand com = new SqlCommand(SQLString, SQLConnectDB);
            SqlDataAdapter adap = new SqlDataAdapter(com);
            //Do du lieu vao doi tuong DataTable
            DataSet ds = new DataSet();
            adap.Fill(ds);
            SQLConnectDB.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.Hide();
                (new Menu()).Show();
            }
            else
            {
                label4.Text = "Đăng nhập không thành công !";
            }          
        }
    }
}
