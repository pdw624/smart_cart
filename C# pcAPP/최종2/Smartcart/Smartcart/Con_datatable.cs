﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Smartcart
{
    class Con_datatable
    {
        public static string constring1 = "datasource=localhost; username=root; password=apmsetup; database=smartcart; charset=utf8;";
        MySqlConnection conn = new MySqlConnection();
        private string sConnString = "";
        public void ConnectDB()
        {
            try
            {
                sConnString = constring1;
            }
            catch
            {

            }
            if (conn.State.ToString().Equals("Closed"))
            {
                conn.ConnectionString = sConnString;
                conn.Open();
            }
        }

        public void CloseDB()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public DataTable GetDBTable(string sql)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            DataTable dataTable = new DataTable();
            DataTable dt = dataTable;
            adapter.Fill(dt);
            return dt;
        }

    }
}
