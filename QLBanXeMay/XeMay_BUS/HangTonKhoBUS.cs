using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
using XeMay_DAO;

namespace XeMay_BUS
{
    public class HangTonKhoBUS
    {
        public List<HangTonKho> GetHangTonKho(string sql)
        {

            return new HangTonKhoDAO().GetHangTonKho(sql);

        }
        public int Add(HangTonKho emp)
        {
            //ktra rang buoc tự nhiên
            if (emp.Thang == 0 || emp.Nam == 0)
            {
                return -2; // khong thanh cong se return -2, thành công sẽ return 1 trong DataProvider
            }
            try
            {
                return (new HangTonKhoDAO().Add(emp));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
