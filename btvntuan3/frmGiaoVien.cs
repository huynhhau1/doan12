using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btvntuan3
{
    public partial class frmGiaoVien : Form
    {
        public frmGiaoVien()
        {
            InitializeComponent();
        }
        DAO_GiaoVien gv = new DAO_GiaoVien();
        private void Load_GiaoVien(object sender, EventArgs e)
        {
            DataTable giaovien =gv.LoadGV();
            dgvgv.DataSource = giaovien;
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtmgv.Text))
            {
                MessageBox.Show("Bạn chưa nhập ID", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmgv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txttgv.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttgv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtquegv.Text))
            {
                MessageBox.Show("Bạn chưa nhập dia chi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtquegv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dpnsgv.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dpnsgv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtcmgv.Text))
            {
                MessageBox.Show("Bạn chưa nhập chứng minh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcmgv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtegv.Text))
            {
                MessageBox.Show("Bạn chưa nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtegv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtdtgv.Text))
            {
                MessageBox.Show("Bạn chưa nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdtgv.Focus();
                return false;
            }
            string dienthoai = @"^(0[1-9][0-9]{8})$";
            string email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Match ktdienthoai = Regex.Match(txtdtgv.Text, dienthoai);
            Match ktemail = Regex.Match(txtegv.Text, email);
            if (ktdienthoai.Success)
            {
                MessageBox.Show("Số điện thoại hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdtgv.Focus();
            }
            else
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdtgv.Focus();
                return false;
            }   
            if (ktemail.Success)
            {
                MessageBox.Show("email hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtegv.Focus();
            }
            else
            {
                MessageBox.Show("email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtegv.Focus();
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_GiaoVien dto = new DTO_GiaoVien(txtmgv.Text, txttgv.Text, txtquegv.Text, dpnsgv.Value, txtcmgv.Text, txtegv.Text, txtdtgv.Text);
                gv.ThemGV(dto);
                Load_GiaoVien(sender, e);
            }
        }

        private void dgvgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvgv.CurrentRow.Index;
            txtmgv.Text = dgvgv.Rows[i].Cells[0].Value.ToString();
            txttgv.Text = dgvgv.Rows[i].Cells[1].Value.ToString();
            txtquegv.Text = dgvgv.Rows[i].Cells[2].Value.ToString();
            dpnsgv.Text = dgvgv.Rows[i].Cells[3].Value.ToString();
            txtcmgv.Text = dgvgv.Rows[i].Cells[4].Value.ToString();
            txtegv.Text = dgvgv.Rows[i].Cells[5].Value.ToString();
            txtdtgv.Text = dgvgv.Rows[i].Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO_GiaoVien dto = new DTO_GiaoVien(txtmgv.Text, txttgv.Text, txtquegv.Text, dpnsgv.Value, txtcmgv.Text, txtegv.Text, txtdtgv.Text);
                gv.SuaGV(dto);
                Load_GiaoVien(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DTO_GiaoVien dto = new DTO_GiaoVien(txtmgv.Text, txttgv.Text, txtquegv.Text, dpnsgv.Value, txtcmgv.Text, txtegv.Text, txtdtgv.Text);
            gv.XoaGV(dto);
            Load_GiaoVien(sender, e);
        }
    }
}
