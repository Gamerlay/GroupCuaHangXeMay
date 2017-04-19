using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;

namespace XeMay_DAO
{
    public class KhachHangDAO
    {
        private DataProvider dp;
        public KhachHangDAO()
        {
            dp = new DataProvider();
        }
        public List<KhachHang> GetKhachHang(string sql)
        {
            dp.connect();
            List<KhachHang> list = new List<KhachHang>();
            {
                string makh, hokh, tenkh, gioitinh, sdt, diachi, email;
                try
                {
                    SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        makh = dr.GetString(0);
                        hokh = dr.GetString(1);
                        tenkh = dr.GetString(2);
                        // ngaysinh = dr.GetString(3);
                        gioitinh = dr.GetString(4);
                        diachi = dr.GetString(5);
                        sdt = dr.GetString(6);
                        email = dr.GetString(7);

                        KhachHang em = new KhachHang(makh, hokh, tenkh, gioitinh, sdt, diachi, email);
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
        public int Add(KhachHang emp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@makh", emp.MaKH));
            paras.Add(new SqlParameter("@hokh", emp.HoKH));
            paras.Add(new SqlParameter("@tenkh", emp.TenKH));
            //paras.Add(new SqlParameter("@ngaysinh", emp.Ngaysinh));
            paras.Add(new SqlParameter("@gioitinh",emp.GioiTinh));
            paras.Add(new SqlParameter("@sdt", emp.SDT));
            paras.Add(new SqlParameter("@diachi", emp.DiaChi));
            paras.Add(new SqlParameter("@email", emp.Email));

            try
            {
                return (dp.ExcuteNonQuery("ThemKhachHang", System.Data.CommandType.StoredProcedure, paras));
                // " ten thu tuc " , loại , danh sach 
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
