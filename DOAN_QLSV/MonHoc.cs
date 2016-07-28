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
    public partial class MonHoc : UserControl
    {
        private static MonHoc _instance;
        public static MonHoc Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MonHoc();
                return _instance;
            }
        }
        public MonHoc()
        {
            InitializeComponent();
        }

        private void MonHoc_Load(object sender, EventArgs e)
        {
            Load_data();
            txtMaMH.Enabled = false;
            DSMH.Columns[0].HeaderText = "Mã môn";
            DSMH.Columns[0].Width = 100;
            DSMH.Columns[1].HeaderText = "Tên Môn";
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
        void Load_data()
        {

            using (var conn = SQL.GetConnection())
            {
             
                SqlCommand command = new SqlCommand("select * from MonHoc", conn);
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adap.Fill(dt);

                DSMH.DataSource = dt;
                conn.Close();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            using (var conn = SQL.GetConnection())
            {
             
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ThemMonHoc";
                command.Parameters.Add("@TenMH", txtTen.Text);
                command.Connection = conn;
                command.ExecuteNonQuery();

                conn.Close();
                txtTen.Text = "";
                Load_data();
            }
        }

        private void DSMH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DSMH.Rows[e.RowIndex].Cells[1].Selected)
            {
                txtMaMH.Text = DSMH.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTen.Text = DSMH.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMaMH.Enabled = false;
               
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {

                using (var conn = SQL.GetConnection())
                {
                   
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateMonHoc";
                    command.Parameters.Add("@MaMon", txtMaMH.Text);
                    command.Parameters.Add("@TenMon", txtTen.Text);
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                    conn.Close();
                    txtMaMH.Text = "";
                    txtTen.Text = "";
                    Load_data();
                }
            }
            catch
            {
                MessageBox.Show("Không Cập Nhật Thành Công !");
            }                           
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < DSMH.Rows.Count; i++)
                {
                    if (DSMH.Rows[i].Cells[1].Selected)
                    {
                        using (var conn = SQL.GetConnection())
                        {
                          
                            SqlCommand command = new SqlCommand();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "DeleteMonHoc";

                            command.Parameters.Add("@MaMon", SqlDbType.Int).Value = txtMaMH.Text.Trim();
                            command.Connection = conn;
                            command.ExecuteNonQuery();
                            Load_data();
                            conn.Close();
                        }
                    }
                }
            }
        }



    }
}
