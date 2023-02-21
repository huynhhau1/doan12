using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvntuan3
{
    public  class DTO_GiaoVien
    {
        public string IdGV;
        public string TenGV;
        public string QuequanGV;
        public DateTime NgaysinhGV;
        public string CmndGV;
        public string Email;
        public string SdtGV;
        public DTO_GiaoVien() { }
        public DTO_GiaoVien(string idGV, string tenGV, string quequanGV, DateTime ngaysinhGV, string cmndGV, string email, string sdtGV)
        {
            IdGV = idGV;
            TenGV = tenGV;
            QuequanGV = quequanGV;
            NgaysinhGV = ngaysinhGV;
            CmndGV = cmndGV;
            Email = email;
            SdtGV = sdtGV;
        }
    }
}
