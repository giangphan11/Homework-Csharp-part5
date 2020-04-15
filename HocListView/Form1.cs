using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HocListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.Ma = 3;
            contact.Ten = "Giang";
            contact.Phone = "0962818571";

            ListViewItem item = new ListViewItem("3");
           
            item.SubItems.Add(contact.Ten);
            item.SubItems.Add(contact.Phone);
            lvContact.Items.Add(item);
        }

        private void lvContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvContact.SelectedItems.Count > 0)
            {
                ListViewItem item = lvContact.SelectedItems[0];
                Contact ct = new Contact();
                ct.Ma =Int32.Parse( item.SubItems[0].Text);
                ct.Ten = item.SubItems[1].Text;
                ct.Phone = item.SubItems[2].Text;

                txtMa.Text = ct.Ma + "";
                txtTen.Text = ct.Ten;
                txtPhone.Text = ct.Phone;
            }
        }

        private void lvContact_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != -1)
            {
                ColumnHeader column = lvContact.Columns[e.Column];
                MessageBox.Show("Bạn chọn colum: " + column.Text);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(txtMa.Text);
            item.SubItems.Add(txtTen.Text);
            item.SubItems.Add(txtPhone.Text);
            lvContact.Items.Add(item);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvContact.SelectedItems.Count > 0)
            {
                ListViewItem item = lvContact.SelectedItems[0];
                lvContact.Items.Remove(item);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvContact.SelectedItems.Count > 0)
            {
                ListViewItem item = lvContact.SelectedItems[0];
                item.SubItems[0].Text = txtMa.Text;
                item.SubItems[1].Text = txtTen.Text;
                item.SubItems[2].Text = txtPhone.Text;
            }
        }
    }
}
