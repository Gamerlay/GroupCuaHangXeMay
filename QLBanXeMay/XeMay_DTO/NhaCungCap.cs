using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeMay_DTO
{
    public class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public NhaCungCap(string mancc, string tenncc, string sdt, string diachi, string email)
        {
            MaNCC = mancc;
            TenNCC = tenncc;
            SDT = sdt;
            DiaChi = diachi;
            Email = email;
        }
    }
}
