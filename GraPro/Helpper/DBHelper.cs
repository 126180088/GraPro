using GraPro.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace GraPro.Helpper
{
    public class DBHelper
    {

        

        //声明一个MySqlConnection来控制数据的连接
        MySqlConnection con;

        public MySqlConnection LineLn()
        {
            string conn = AppSetting.GetAppSetting("conn");

            if (con == null)
            {
                con = new MySqlConnection(conn);
            }


            con.Open();

            return con;
        }

        //查询登录用户是否存在
        public object GetUser()
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT * FROM USER_INFO";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            return dataSet.Tables[0].Rows[0];

        }
    }
}
