using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btvntuan3
{
    public class DTO_HocSinh
    {
        public int IdHS;
        public string TenHS;
        public string QuequanHS;
        public DateTime NgaysinhHS;
        public string CmndHS;
        public string EmailHS;
        public string SdtHS;       
        public DTO_HocSinh() { }
        public DTO_HocSinh(int idHS, string tenHS, string quequanHS, DateTime ngaysinhHS, string cmndHS, string emailHS, string sdtHS)
        {
            IdHS = idHS;
            TenHS = tenHS;
            QuequanHS = quequanHS;
            NgaysinhHS = ngaysinhHS;
            CmndHS = cmndHS;
            EmailHS = emailHS;
            SdtHS = sdtHS;
        }
    }
}
