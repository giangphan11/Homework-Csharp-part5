using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HocDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Contact> dsContact = new List<Contact>();
            dsContact.Add(new Contact() { Id = 1, Ten = "Nguyễn Thị Hạnh", Phone = "0932332322" });
            dsContact.Add(new Contact() { Id = 2, Ten = "Trần Văn Phúc", Phone = "09323323221" });
            dsContact.Add(new Contact() { Id = 3, Ten = "Tô Văn Giải", Phone = "0932332312" });
            dsContact.Add(new Contact() { Id = 4, Ten = "Trần Như Thoát", Phone = "09323323453" });
            dsContact.Add(new Contact() { Id = 5, Ten = "Lô Long Lanh", Phone = "0932332353" });
            dsContact.Add(new Contact() { Id = 6, Ten = "Trần Ánh Sáng", Phone = "09323323532" });
            gvContact.DataSource = dsContact;
        }

        private void gvContact_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = gvContact.Rows[e.RowIndex];
                string ten = row.Cells[1].Value+"";
                MessageBox.Show(ten);
            }
            */
                
            
        }

        private void gvContact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = gvContact.Rows[e.RowIndex];
                string ten = row.Cells[1].Value + "";
                MessageBox.Show(ten);
            }
        }
    }
}
