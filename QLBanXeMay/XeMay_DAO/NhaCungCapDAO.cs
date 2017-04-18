using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;

namespace XeMay_DAO
{
    public class NhaCungCapDAO
    {
        private DataProvider dp;
        public NhaCungCapDAO()
        {
            dp = new DataProvider();
        }
        public List<NhaCungCap> GetNhaCungCap(string sql)
        {
            dp.connect();
            List<NhaCungCap> list = new List<NhaCungCap>();
            {
                string mancc, tencc, sdt, diachi, email;
                try
                {
                    SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        mancc = dr.GetString(0);
                        tencc = dr.GetString(1);
                        sdt = dr.GetString(2);
                        diachi = dr.GetString(3);
                        email = dr.GetString(4);

                        NhaCungCap em = new NhaCungCap(mancc, tencc, sdt, diachi, email);
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
        public int Add(NhaCungCap emp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@mancc", emp.MaNCC));
            paras.Add(new SqlParameter("@tenncc", emp.TenNCC));
            paras.Add(new SqlParameter("@sdt", emp.SDT));
            paras.Add(new SqlParameter("@diachi", emp.DiaChi));
            paras.Add(new SqlParameter("@email", emp.Email));

            try
            {
                return (dp.ExcuteNonQuery("ThemNhaCungCap", System.Data.CommandType.StoredProcedure, paras));
                // " ten thu tuc " , loại , danh sach 
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
