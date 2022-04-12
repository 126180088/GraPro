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

        /// <summary>
        /// 查询登录用户是否存在
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public DataSet UserBool(string Account)
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT * FROM SYSUSER WHERE ACCOUNT = " + "'" + Account + "'";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            db.Close();

            return dataSet;

        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

            db.Close();

            if (dataSet.Tables.Count == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加岗位
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public bool CreateStation(Station station)
        {
            MySqlConnection db = LineLn();

            //insert into 表名 values(value1,value2.....valuen)；

            string sqlCommdStr = @"INSERT INTO STATIONINFO ( StationName, StationDescribe, " +
                "StationRequire, Wages, CompanyName, CompanyAddress, CompanyDescribe, " +
                "CompanyEmail, CompanyTele, NeedNumber, STypeId, ITypeId ) VALUES ( " +
                "'" + station.StationName + "', '" + station.StationDescribe + "', '" +
                station.StationRequire + "', " + station.Wages + ", '" + station.CompanyName + "', '" +
                station.CompanyAddress + "', '" + station.CompanyDescribe + "', '" +
                station.CompanyEmail + "', '" + station.CompanyTele + "', " + station.NeedNumber + ", " +
                station.STypeId + ", " + station.ITypeId + "); ";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            db.Close();

            if (dataSet == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询岗位类型
        /// </summary>
        /// <returns></returns>
        public DataSet StypeInfo()
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT * FROM  STATIONTYPE";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            db.Close();

            return dataSet;

        }

        /// <summary>
        /// 查询行业类型
        /// </summary>
        /// <returns></returns>
        public DataSet ItypeInfo()
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT * FROM  INDUSTRYTYPE";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            db.Close();

            return dataSet;

        }

        /// <summary>
        /// 查询岗位信息
        /// </summary>
        /// <returns></returns>
        public DataSet StationInfo()
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT * FROM  STATIONINFO";

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            db.Close();

            return dataSet;

        }


        /// <summary>
        /// 发起就业申请
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public bool ApplicationPost(Application application)
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"UPDATE WORKAPPLICATION SET " +
               "CompanyName = " + "'" + application.CompanyName + "', " +
               "CompanyAddress = " + "'" + application.CompanyAddress + "', " +
               "StationName = " + "'" + application.StationName + "', " +
               "ITypeId = " + application.ITypeId + ", " +
               "STypeId = " + application.STypeId + ", " +
               "Wages = " + application.Wages + ", " +
               "UFile = " + "'" + application.UFile + "', " +
               "AResult = " + application.AResult +
               " Where UId = " + application.UId;

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            db.Close();

            if (dataSet.Tables.Count == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询就业申请
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public DataSet GetAppInfo(int UId)
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT * FROM  WORKAPPLICATION WHERE UId=" + UId;

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);



            if (dataSet.Tables[0].Rows.Count != 0)
            {
                db.Close();

                return dataSet;
            }
            else
            {
                string appCreat = @"INSERT INTO WORKAPPLICATION ( UId , AResult ) VALUES ( " + UId + ", 0 )";

                DataSet appdataSet = new DataSet();

                MySqlDataAdapter appcmd = new MySqlDataAdapter(appCreat, db);

                appcmd.Fill(appdataSet);

                db.Close();

                return appdataSet;
            }

        }

        /// <summary>
        /// 查询就业状态
        /// </summary>
        /// <returns></returns>
        public DataSet Status(int UId)
        {
            MySqlConnection db = LineLn();

            string sqlCommdStr = @"SELECT AResult FROM  WORKAPPLICATION WHERE UID = " + UId;

            DataSet dataSet = new DataSet();

            MySqlDataAdapter cmd = new MySqlDataAdapter(sqlCommdStr, db);

            cmd.Fill(dataSet);

            db.Close();

            return dataSet;

        }
    }
}
