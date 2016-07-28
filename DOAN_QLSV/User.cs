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
    public partial class User : UserControl
    {
        private static User _instance;
        public static User Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new User();
                return _instance;
            }
        }
        public User()
        {
            InitializeComponent();
        }
        void Load_data()
        {
            

            using (var conn = SQL.GetConnection())
            {

                SqlCommand command = new SqlCommand("select * from tblUser", conn);
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adap.Fill(dt);
                DSMH.DataSource = dt;
                conn.Close();
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            DataTable dtblDataSource = new DataTable();
            dtblDataSource.Columns.Add("DisplayMember");


            dtblDataSource.Rows.Add("Admin");
            dtblDataSource.Rows.Add("Quản Trị Viên");


            //comboBox1.Items.Clear();
            comboBox1.DataSource = dtblDataSource;
            comboBox1.DisplayMember = "DisplayMember";
            comboBox1.ValueMember = "DisplayMember";

            Load_data();
            DSMH.Columns[0].HeaderText = "ID";
            DSMH.Columns[0].Width = 100;
            DSMH.Columns[1].HeaderText = "Tên Đăng Nhập";
            DSMH.Columns[1].Width = 200;
            DSMH.Columns[1].HeaderText = "Mật Khẩu";
            DSMH.Columns[1].Width = 200;
            DSMH.Columns[1].HeaderText = "Phân Quyền";
            DSMH.Columns[1].Width = 200;
            DataGridViewCheckBoxColumn Xoa = new DataGridViewCheckBoxColumn();
            Xoa.Name = "Xoa";
            Xoa.HeaderText = "Xóa";
            DSMH.Columns.Insert(0, Xoa);
            Xoa.Width = 50;

            Bitmap img = new Bitmap(@"E:\CNPM\DOAN_QLSV\DOAN_QLSV\img\edit.gif");
            DataGridViewImageColumn Sua = new DataGridViewImageColumn();
            Sua.Name = "Sua";
            Sua.HeaderText = "Sửa";
            Sua.Image = img;
            DSMH.Columns.Insert(1, Sua);
            Sua.Width = 50;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            using (var conn = SQL.GetConnection())
            {

                SqlCommand sqlCmd = new SqlCommand("them_user", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@tendn", txtMaMH.Text);
                sqlCmd.Parameters.Add("@matkhau", txtTen.Text);
                sqlCmd.Parameters.Add("@phanquyen", comboBox1.SelectedValue.ToString());
               
               

                sqlCmd.ExecuteNonQuery();
                conn.Close();
                txtMaMH.Text = "";
                txtTen.Text = "";
                MessageBox.Show("Thêm Thành Công !");
                Load_data();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var conn = SQL.GetConnection())
            {

                SqlCommand sqlCmd = new SqlCommand("update_user ", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@tendn", txtMaMH.Text);
                sqlCmd.Parameters.Add("@matkhau", txtTen.Text);
                sqlCmd.Parameters.Add("@phanquyen", comboBox1.SelectedValue.ToString());
                sqlCmd.Parameters.Add("@id", textBox1.Text);
               

                sqlCmd.ExecuteNonQuery();
                conn.Close();
                txtMaMH.Text = "";
                txtTen.Text = "";
                MessageBox.Show("Thêm Thành Công !");
                Load_data();
            }
        }

        private void DSMH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DSMH.Rows[e.RowIndex].Cells[1].Selected)
            {
                textBox1.Text = DSMH.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtMaMH.Text = DSMH.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTen.Text = DSMH.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox1.Text = DSMH.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DSMH.Rows.Count; i++)
            {

                if (DSMH.Rows[i].Cells[0].Selected)
                {
                    var con = SQL.GetConnection();
                    

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM tblUser where id=@id", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        if (DSMH.Rows[i].Cells[3].Value.ToString() == "thuvp") MessageBox.Show("Bạn Không Được Xóa Tài Khoản Này !");
                        else
                        { 
                        cmd.Parameters.AddWithValue("@id", DSMH.Rows[i].Cells[2].Value);

                        cmd.ExecuteNonQuery();
                        string message = "xóa thành công";
                        string caption = "Thông báo";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(message, caption, buttons);
                        }
                        Load_data();
                        // con.Close();
                    }

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaMH.Text = "";
            txtTen.Text = "";
            textBox1.Text = "";
        }
    }
}
