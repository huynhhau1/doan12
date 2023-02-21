using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Drawing;

namespace btvntuan3
{
     public class DAO_HocSinh
     {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConStr);
        public DataTable LoadHS()
        {
            try
            {
                conn.Open();
                string sql = string.Format("select * from HocSinh");
                SqlDataAdapter apt = new SqlDataAdapter(sql,conn);
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
        public void ThemHS(DTO_HocSinh hs)
        {
            try
            {
                conn.Open();
                string sql = string.Format("insert into HocSinh(IdHS,TenHS,QuequanHS,NgaysinhHS,CmndHS,EmailHS,SdtHS)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",hs.IdHS,hs.TenHS,hs.QuequanHS,hs.NgaysinhHS,hs.CmndHS,hs.EmailHS,hs.SdtHS);
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
        public void SuaHS(DTO_HocSinh hs)
        {
            try
            {
                conn.Open();
                string sql = string.Format("update HocSinh set TenHS ='{0}',QuequanHS='{1}',NgaysinhHS='{2}',CmndHS='{3}',EmailHS='{4}',SdtHS='{5}' where IdHS='{6}'",hs.TenHS,hs.QuequanHS,hs.NgaysinhHS,hs.CmndHS,hs.EmailHS,hs.SdtHS,hs.IdHS); 
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
        public void XoaHS(DTO_HocSinh hs)
        {
            try
            {
                conn.Open();
                string sql = string.Format("delete from HocSinh Where IdHS= '{0}'",hs.IdHS);
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
