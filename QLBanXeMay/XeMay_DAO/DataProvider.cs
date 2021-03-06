﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace XeMay_DAO
{
    public class DataProvider
    {
        string str = "";
        SqlConnection cn;
        public DataProvider()
        {
            str = " Server =.; Database = QLXeMay ; Integrated Security = true";
            cn = new SqlConnection(str);
        }
        public void connect()
        {

            if (cn != null && cn.State != ConnectionState.Open)
            {
                cn.Open();
            }


        }
        public void disconnect()
        {
            if (cn != null && cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
        }
        public SqlDataReader ExecuteReader(string sql)
        {

            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
        public int ExcuteNonQuery(string sql, CommandType type, List<SqlParameter> paras) // truyen vao 1 list chứa những cột trong bảng
        {
            connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type; // do chưa pit truyen vao bang select hay store producer
                if (paras != null)
                {
                    foreach (SqlParameter para in paras)
                    {
                        cmd.Parameters.Add(para);
                    }
                }
                cmd.ExecuteNonQuery();
                return 1;

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally { disconnect(); }
        }
    }
}