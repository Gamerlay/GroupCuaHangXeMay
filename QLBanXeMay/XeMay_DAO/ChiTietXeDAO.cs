using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;

namespace XeMay_DAO
{
    public class ChiTietXeDAO
    {
        private DataProvider dp;
        public ChiTietXeDAO()
        {
            dp = new DataProvider();
        }
        public List<ChiTietXe> GetChiTietXe(string sql)
        {
            dp.connect();
            List<ChiTietXe> list = new List<ChiTietXe>();
            {
                int trongluong, hopso, dungtichbinhxang, dungtichxilanh;
                string sokhung, somay, mausac, maxe;
                try
                {
                    SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        sokhung = dr.GetString(0);
                        somay = dr.GetString(1);
                        maxe = dr.GetString(2);
                        mausac = dr.GetString(3);
                        trongluong = dr.GetInt32(4);
                        hopso = dr.GetInt32(5);
                        dungtichbinhxang = dr.GetInt32(6);
                        dungtichxilanh = dr.GetInt32(7);

                        ChiTietXe em = new ChiTietXe(sokhung, somay, maxe, mausac, trongluong, hopso, dungtichbinhxang, dungtichxilanh);
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
        public int Add(ChiTietXe emp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@sokhung", emp.SoKhung));
            paras.Add(new SqlParameter("@somay", emp.SoMay));
            paras.Add(new SqlParameter("@maxe", emp.MaXe));
            paras.Add(new SqlParameter("@mausac", emp.MauSac));
            paras.Add(new SqlParameter("@trongluong", emp.TrongLuong));
            paras.Add(new SqlParameter("@hopso", emp.HopSo));
            paras.Add(new SqlParameter("@dungtichbinhxang", emp.DungTichBinhXang));
            paras.Add(new SqlParameter("@dungtichxilanh", emp.DungTichXiLanh));

            try
            {
                return (dp.ExcuteNonQuery("ThemChiTietXe", System.Data.CommandType.StoredProcedure, paras));
                // " ten thu tuc " , loại , danh sach 
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
