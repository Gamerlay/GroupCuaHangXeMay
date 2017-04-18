using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeMay_DTO
{
    public class XeTrongCuaHang
    {
        public string MaXe { get; set; }
        public string MaNhap { get; set; }
        public string MaXuat { get; set; }
        public string TenXe { get; set; }
        public int DonGiaNhap { get; set; }
        public int DonGiaXuat { get; set; }
        public XeTrongCuaHang(string maxe, string manhap, string maxuat, string tenxe, int dongianhap, int dongiaxuat)
        {
            MaXe = maxe;
            MaNhap = manhap;
            MaXuat = maxuat;
            TenXe = tenxe;
            DonGiaNhap = dongianhap;
            DonGiaXuat = dongiaxuat;
        }
    }
}
