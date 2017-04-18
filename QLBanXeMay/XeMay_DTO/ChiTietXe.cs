
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeMay_DTO
{
    public class ChiTietXe
    {
        public string SoKhung { get; set; }
        public string SoMay { get; set; }
        public string MauSac { get; set; }
        public string MaXe { get; set; }
        public int TrongLuong { get; set; }
        public int HopSo { get; set; }
        public int DungTichBinhXang { get; set; }
        public int DungTichXiLanh { get; set; }
        public ChiTietXe(string sokhung, string somay, string maxe, string mausac, int trongluong, int hopso, int dungtichbinhxang, int dungtichxilanh)
        {
            SoKhung = sokhung;
            SoMay = somay;
            MaXe = maxe;
            MauSac = mausac;
            TrongLuong = trongluong;
            HopSo = hopso;
            DungTichBinhXang = dungtichbinhxang;
            DungTichXiLanh = dungtichxilanh;
        }
    }
}
