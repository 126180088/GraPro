﻿using GraPro.Helpper;
using GraPro.Models;
using GraPro.ResponseModel;
using System.Data;

namespace GraPro.Dal
{
    public class StationService
    {
        /// <summary>
        /// 添加岗位
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public DataResult CreateStation(Station station)
        {
            DBHelper dBHelper = new DBHelper();

            if (dBHelper.CreateStation(station))
                //创建成功
                return new Home_Response { status = 0, message = "true" };
            else
                //创建失败
                return new Home_Response { status = 1, message = "false" };
        }

        /// <summary>
        /// 查询岗位类型
        /// </summary>
        /// <returns></returns>
        public DataResult StypeInfo()
        {
            DBHelper dBHelper = new DBHelper();

            DataSet data = dBHelper.StypeInfo();

            string jsondata = TJson.DatasetToJson(data);

                //创建成功
            return new Home_Response { data = jsondata };
        }

        /// <summary>
        /// 查询行业类型
        /// </summary>
        /// <returns></returns>
        public DataResult ItypeInfo()
        {
            DBHelper dBHelper = new DBHelper();

            DataSet data = dBHelper.ItypeInfo();

            string jsondata = TJson.DatasetToJson(data);

            //创建成功
            return new Home_Response { data = jsondata };
        }

        /// <summary>
        /// 查询岗位信息
        /// </summary>
        /// <returns></returns>
        public DataResult StationInfo()
        {
            DBHelper dBHelper = new DBHelper();

            DataSet data = dBHelper.StationInfo();

            string stationinfo = TJson.DatasetToJson(data);

            //创建成功
            return new Home_Response { data = stationinfo };
        }
    }
}
