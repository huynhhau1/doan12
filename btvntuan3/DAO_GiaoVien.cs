using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btvntuan3
{
    public  class DAO_GiaoVien
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConStr);
        public DataTable LoadGV()
        {
            try
            {
                conn.Open();
                string sql = string.Format("select * from GiaoVien");
                SqlDataAdapter apt = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                apt.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        public void ThemGV(DTO_GiaoVien gv)
        {
            try
            {
                conn.Open();
                string sql = string.Format("insert into GiaoVien(IdGV,TenGV,QuequanGV,NgaysinhGV,CmndGV,EmailGV,SdtGV)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",gv.IdGV,gv.TenGV, gv.QuequanGV, gv.NgaysinhGV, gv.CmndGV, gv.Email, gv.SdtGV);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("them thanh cong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("them that bai" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void SuaGV(DTO_GiaoVien gv)
        {
            try
            {
                conn.Open();
                string sql = string.Format("update GiaoVien set TenGV ='{0}',QuequanGV='{1}',NgaysinhGV='{2}',CmndGV='{3}',EmailGV='{4}',SdtGV='{5}' where IdGV='{6}'", gv.TenGV, gv.QuequanGV, gv.NgaysinhGV, gv.CmndGV, gv.Email, gv.SdtGV, gv.IdGV);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("sua thanh cong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("sua that bai" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void XoaGV(DTO_GiaoVien gv)
        {
            try
            {
                conn.Open();
                string sql = string.Format("delete from GiaoVien Where IdGV= '{0}'", gv.IdGV);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("xoa thanh cong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("xoa that bai" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
