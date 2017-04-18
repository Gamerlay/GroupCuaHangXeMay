using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeMay_DTO
{
    public class HangTonKho
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaXe { get; set; }
        public int ThoiGianTonKho { get; set; }
        public HangTonKho(int thang, int nam, string maxe, int thoigiantonkho)
        {
            Thang = thang;
            Nam = nam;
            MaXe = maxe;
            ThoiGianTonKho = thoigiantonkho;
        }
    }
}
