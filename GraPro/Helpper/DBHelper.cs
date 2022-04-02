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
        public DataSet UserBool(string Account)
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT * FROM SYSUSER WHERE ACCOUNT = " + "'" + Account + "'";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            return dataSet;

        }

        //更新用户信息
        public bool UpdataUser(User user)
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"UPDATE SYSUSER SET UserName =" + "'" + user.UserName + "', " +
                "Password = " + "'" + user.Password + "', " +
                "Sex = " + "'" + user.Sex + "', " +
                "Birth = " + "'" + user.Birth + "', " +
                "Telephone = " + "'" + user.Telephone + "', " +
                "Email = " + "'" + user.Email + "' " +
                "Where Account = " + "'" + user.Account + "'";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            if (dataSet != null)
                return true;
            else
                return false;

        }


        public bool CreateStation(Station station)
        {
            MySqlConnection db = LineLn();

            //insert into 表名 values(value1,value2.....valuen)；

            string sqlCommdStr = @"INSERT INTO STATIONINFO ( StationName, StationDescribe, " +
                "StationRequire, Wages, CompanyName, CompanyAddress, CompanyDescribe, " +
                "CompanyEmail, CompanyTele, NeedNumber, STypeId, ITypeId ) VALUES ( " +
                "'"+ station.StationName + "', '" + station.StationDescribe + "', '" +
                station.StationRequire + "', " + station.Wages + ", '" + station.CompanyName + "', '" +
                station.CompanyAddress + "', '" + station.CompanyDescribe + "', '" +
                station.CompanyEmail + "', '" + station.CompanyTele + "', " + station.NeedNumber + ", " +
                station.STypeId + ", " + station.ITypeId + "); ";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            if (dataSet != null)
                return true;
            else
                return false;
        }

        //StypeInfo
        //查询岗位类型
        public DataSet StypeInfo()
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT * FROM  STATIONTYPE";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            return dataSet;

        }

        //StypeInfo
        //查询行业类型
        public DataSet ItypeInfo()
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT * FROM  INDUSTRYTYPE";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            return dataSet;

        }
    }
}
