using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;

namespace XeMay_DAO
{
    public class HangTonKhoDAO
    {
        private DataProvider dp;
        public HangTonKhoDAO()
        {
            dp = new DataProvider();
        }
        public List<HangTonKho> GetHangTonKho(string sql)
        {
            dp.connect();
            List<HangTonKho> list = new List<HangTonKho>();
            {
                int thang, nam, thoigiantonkho;
                string maxe;
                try
                {
                    SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        thang = dr.GetInt32(0);
                        nam = dr.GetInt32(1);
                        maxe = dr.GetString(2);
                        thoigiantonkho = dr.GetInt32(3);

                        HangTonKho em = new HangTonKho(thang, nam, maxe, thoigiantonkho);
                        list.Add(em);
                    }
                    dr.Close();
                    return list;
                }
                catch (SqlException ex)
                {

                    throw ex;
                }
                finally { dp.disconnect(); }



            }
        }
        public int Add(HangTonKho emp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@thang", emp.Thang));
            paras.Add(new SqlParameter("@nam", emp.Nam));
            paras.Add(new SqlParameter("@maxe", emp.MaXe));
            paras.Add(new SqlParameter("@thoigiantonkho", emp.ThoiGianTonKho));
            try
            {
                return (dp.ExcuteNonQuery("ThemHangTonKho", System.Data.CommandType.StoredProcedure, paras));
                // " ten thu tuc " , loại , danh sach 
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
