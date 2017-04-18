using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
using XeMay_DAO;

namespace XeMay_BUS
{
    public class ChiTietXeBUS
    {
        public List<ChiTietXe> GetChiTietXe(string sql)
        {

            return new ChiTietXeDAO().GetChiTietXe(sql);

        }
        public int Add(ChiTietXe emp)
        {
            //ktra rang buoc tự nhiên
            if (emp.SoKhung == " " || emp.SoMay == " ")
            {
                return -2; // khong thanh cong se return -2, thành công sẽ return 1 trong DataProvider
            }
            //ktra rang buoc nghiep vu , trong nay có thể ktra đủ 18 tuổi k , có bằng cấp chưa ...
            try
            {
                return (new ChiTietXeDAO().Add(emp));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
