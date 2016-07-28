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
    public partial class Lich : UserControl
    {
        private static Lich _instance;
        public static Lich Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Lich();
                return _instance;
            }
        }
        public Lich()
        {
            InitializeComponent();
        }

        private void Lich_Load(object sender, EventArgs e)
        {
            Load_Data();
            txtMalich.Enabled = false;
            DSLich.Columns[0].HeaderText = "Mã Lịch";
            DSLich.Columns[0].Width = 50;
            DSLich.Columns[1].HeaderText = "Nội Dung";
            DSLich.Columns[1].Width = 200;
            DSLich.Columns[2].HeaderText = "Begintime";
            DSLich.Columns[3].Width = 80;
            DSLich.Columns[4].HeaderText = "Endtime";
            DSLich.Columns[4].Width = 80;
            DSLich.Columns[5].HeaderText = "Tiêu Đề";
            DSLich.Columns[5].Width = 80;
            DataGridViewCheckBoxColumn Xoa = new DataGridViewCheckBoxColumn();
            Xoa.Name = "Xoa";
            Xoa.HeaderText = "Xóa";
            DSLich.Columns.Insert(0, Xoa);
            Xoa.Width = 50;

            Bitmap img = new Bitmap(@"E:\CNPM\DOAN_QLSV\DOAN_QLSV\img\edit.gif");
            DataGridViewImageColumn Sua = new DataGridViewImageColumn();
            Sua.Name = "Sua";
            Sua.HeaderText = "Sửa";
            Sua.Image = img;
            DSLich.Columns.Insert(1, Sua);
            Sua.Width = 50;
        }
        void Load_Data()
        {
            using (var conn = SQL.GetConnection())
            {
              
                SqlCommand command = new SqlCommand("select * from LichThi", conn);
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adap.Fill(dt);

                DSLich.DataSource = dt;
                conn.Close();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            using (var conn = SQL.GetConnection())
            {
               
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "them_lich";

                command.Parameters.Add("@tieude", txtTieude.Text) ;
                command.Parameters.Add("@noidung", txtNoidung.Text);
                command.Parameters.Add("@thoigianbatdau", txtNgaybd.Text);
                command.Parameters.Add("@thoigianketthuc", txtNgaykt.Text) ;
                command.Parameters.Add("@diachi", txtDiadiem.Text);

                command.Connection = conn;
                command.ExecuteNonQuery();
                
                txtMalich.Text = "";
                txtTieude.Text = "";
                txtNoidung.Text = "";
                txtNgaybd.Text = "";
                txtNgaykt.Text = "";
                txtDiadiem.Text = "";

                Load_Data();
                conn.Close();
            }
        }

        private void DSLich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DSLich.Rows[e.RowIndex].Cells[1].Selected)
            {
                txtMalich.Text = DSLich.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNoidung.Text = DSLich.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtNgaybd.Text = DSLich.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNgaykt.Text = DSLich.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtDiadiem.Text = DSLich.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtTieude.Text = DSLich.Rows[e.RowIndex].Cells[7].Value.ToString();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DSLich.Rows.Count; i++)
            {
                if (DSLich.Rows[i].Cells[0].Selected)
                {
                    using (var conn = SQL.GetConnection())
                    {
                       
                        SqlCommand command = new SqlCommand();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "UpdateLichThi";

                        command.Parameters.Add("@malich", txtMalich.Text);
                        command.Parameters.Add("@tieude", txtTieude.Text);
                        command.Parameters.Add("@noidung", txtNoidung.Text);
                        command.Parameters.Add("@thoigianbatdau", txtNgaybd.Text);
                        command.Parameters.Add("@thoigianketthuc", txtNgaykt.Text);
                        command.Parameters.Add("@diachi", txtDiadiem.Text);

                        command.Connection = conn;
                        command.ExecuteNonQuery();

                        txtMalich.Text = "";
                        txtTieude.Text = "";
                        txtNoidung.Text = "";
                        txtNgaybd.Text = "";
                        txtNgaykt.Text = "";
                        txtDiadiem.Text = "";
                        
                        Load_Data();
                        conn.Close();
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < DSLich.Rows.Count; i++)
                {
                    if (DSLich.Rows[i].Cells[1].Selected)
                    {
                        using (var conn = SQL.GetConnection())
                        {

                            conn.Open();
                            SqlCommand command = new SqlCommand();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "DeleteLichThi";

                            command.Parameters.Add("@malich", txtMalich.Text);

                            command.Connection = conn;
                            command.ExecuteNonQuery();

                            txtMalich.Text = "";
                            txtTieude.Text = "";
                            txtNoidung.Text = "";
                            txtNgaybd.Text = "";
                            txtNgaykt.Text = "";
                            txtDiadiem.Text = "";                           
                            Load_Data();
                            conn.Close();
                        }
                    }
                }
            }
        }
    }
}
