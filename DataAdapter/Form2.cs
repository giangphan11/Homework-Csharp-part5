using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataAdapter
{
    public partial class Form2 : Form
    {
        SqlConnection connection = null;
        SqlDataAdapter adapter = null;
        string strConnection = "Server=GIANGPHAN; Database=QuanLySanPham; User=sa; Password=20061998";
        public Form2()
        {
            InitializeComponent();
        }
        private void hienThiDanhMuc()
        {
            try
            {
                if (connection == null)
                    connection = new SqlConnection(strConnection);
                adapter = new SqlDataAdapter("select * from DanhMuc", connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                gvDanhMuc.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNapDanhMuc_Click(object sender, EventArgs e)
        {
            hienThiDanhMuc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection == null)
                    connection = new SqlConnection(strConnection);
                adapter = new SqlDataAdapter("select * from DanhMuc", connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet,"tblDanhMuc");
                DataRow row = dataSet.Tables["tblDanhMuc"].NewRow();
                row[0] = txtMa.Text;
                row[1] = txtTen.Text;
                dataSet.Tables["tblDanhMuc"].Rows.Add(row);
                int kq = adapter.Update(dataSet.Tables["tblDanhMuc"]);
                if (kq > 0)
                {
                    gvDanhMuc.DataSource = dataSet.Tables["tblDanhMuc"];
                    MessageBox.Show("Thêm danh mục thành công !");
                }
                else
                {
                    MessageBox.Show("Thêm danh mục thất bại !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
