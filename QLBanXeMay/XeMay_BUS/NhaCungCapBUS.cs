using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
using XeMay_DAO;

namespace XeMay_BUS
{
    public class NhaCungCapBUS
    {
        public List<NhaCungCap> GetNhaCungCap(string sql)
        {

            return new NhaCungCapDAO().GetNhaCungCap(sql);

        }
        public int Add(NhaCungCap emp)
        {
            //ktra rang buoc tự nhiên
            if (emp.MaNCC == "")
            {
                return -2; // khong thanh cong se return -2, thành công sẽ return 1 trong DataProvider
            }
            try
            {
                return (new NhaCungCapDAO().Add(emp));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}

