using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using XeMay_DTO;
namespace XeMay_DAO
{
    public class NhanVienDAO
    {
        private DataProvider dp;
        public NhanVienDAO()
        {
            dp = new DataProvider();
        }
        public List<NhanVien> GetNhanVien(string sql)
        {
            dp.connect();
            List<NhanVien> list = new List<NhanVien>();
            {
                int luong;
                string manv, honv, tennv, chucvu, sdt, diachi, email, gioitinh;
                try
                {
                    SqlDataReader dr = dp.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        manv = dr.GetString(0);
                        honv = dr.GetString(1);
                        tennv = dr.GetString(2);
                        // ngaysinh = dr.GetString(3);
                        gioitinh = dr.GetString(4);
                        luong = dr.GetInt32(5);
                        chucvu = dr.GetString(6);
                        diachi = dr.GetString(7);
                        sdt = dr.GetString(8);
                        email = dr.GetString(9);

                        NhanVien em = new NhanVien(manv, honv, tennv, gioitinh, luong, chucvu, diachi, sdt, email);
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
        public int Add(NhanVien emp)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@manv", emp.MaNV));
            paras.Add(new SqlParameter("@honv", emp.HoNV));
            paras.Add(new SqlParameter("@tennv", emp.TenNV));
            //paras.Add(new SqlParameter("@ngaysinh", emp.Ngaysinh));
            paras.Add(new SqlParameter("@luong", emp.Luong));
            paras.Add(new SqlParameter("@chucvu", emp.ChucVu));
            paras.Add(new SqlParameter("@diachi", emp.DiaChi));
            paras.Add(new SqlParameter("@sdt", emp.SDT));
            paras.Add(new SqlParameter("@email", emp.Email));

            try
            {
                return (dp.ExcuteNonQuery("ThemNhanVien", System.Data.CommandType.StoredProcedure, paras));
                // " ten thu tuc " , loại , danh sach 
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}