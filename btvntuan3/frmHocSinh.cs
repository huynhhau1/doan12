using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace btvntuan3
{
    public partial class frmHocSinh : Form
    {
        public frmHocSinh()
        {
            InitializeComponent();

        }
        DAO_HocSinh hs = new DAO_HocSinh();
        private void Load_HocSinh(object sender, EventArgs e)
        {
            DataTable hocsinh = hs.LoadHS();
            dgvhs.DataSource = hocsinh;
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txidhs.Text))
            {
                MessageBox.Show("Bạn chưa nhập ID", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txidhs.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtths.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtths.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtquehs.Text))
            {
                MessageBox.Show("Bạn chưa nhập dia chi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtquehs.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dpnshs.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dpnshs.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtcmhs.Text))
            {
                MessageBox.Show("Bạn chưa nhập chứng minh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcmhs.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtehs.Text))
            {
                MessageBox.Show("Bạn chưa nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtehs.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtdths.Text))
            {
                MessageBox.Show("Bạn chưa nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdths.Focus();
                return false;
            }
            string dienthoai = @"^(0[1-9][0-9]{8})$";
            string email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Match ktdienthoai = Regex.Match(txtdths.Text, dienthoai);
            Match ktemail = Regex.Match(txtehs.Text,email);
            if (ktdienthoai.Success)
            {
                MessageBox.Show("Số điện thoại hợp lệ","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdths.Focus();
            }
            else
            {
                MessageBox.Show("Số điện thoại không hợp lệ","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdths.Focus();
                return false;
            }
            if (ktemail.Success)
            {
                MessageBox.Show("email hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtehs.Focus();
            }
            else
            {
                MessageBox.Show("email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtehs.Focus();
                return false;
            }
            return true;
        }
        private void Them(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_HocSinh dto = new DTO_HocSinh(int.Parse(txidhs.Text), txtths.Text, txtquehs.Text, dpnshs.Value, txtcmhs.Text, txtehs.Text, txtdths.Text);
                hs.ThemHS(dto);
                Load_HocSinh(sender, e);
            }
        }
        private void dgvhs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvhs.CurrentRow.Index;
            txidhs.Text = dgvhs.Rows[i].Cells[0].Value.ToString();
            txtths.Text = dgvhs.Rows[i].Cells[1].Value.ToString();
            txtquehs.Text = dgvhs.Rows[i].Cells[2].Value.ToString();
            dpnshs.Text = dgvhs.Rows[i].Cells[3].Value.ToString();
            txtcmhs.Text = dgvhs.Rows[i].Cells[4].Value.ToString();
            txtehs.Text = dgvhs.Rows[i].Cells[5].Value.ToString();
            txtdths.Text = dgvhs.Rows[i].Cells[6].Value.ToString();
        }
        private void Sua(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_HocSinh dto = new DTO_HocSinh(int.Parse(txidhs.Text), txtths.Text, txtquehs.Text, dpnshs.Value, txtcmhs.Text, txtehs.Text, txtdths.Text);
                hs.SuaHS(dto);
                Load_HocSinh(sender, e);
            }
        }
        private void Xoa(object sender, EventArgs e)
        {
            DTO_HocSinh dto = new DTO_HocSinh(int.Parse(txidhs.Text), txtths.Text, txtquehs.Text, dpnshs.Value, txtcmhs.Text, txtehs.Text, txtdths.Text);
            hs.XoaHS(dto);
            Load_HocSinh(sender, e);
        }
    }     
}
