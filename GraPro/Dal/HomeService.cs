using System;
using System.Collections.Generic;
using System.Data;
using GraPro.Helpper;
using GraPro.Models;
using GraPro.ResponseModel;
using MySql.Data.MySqlClient;

namespace GraPro.Dal
{
    public class HomeService
    {
        /// <summary>
        /// 查询登录用户是否存在/登录
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataResult GetUser(string Account, string Password)
        {
            DBHelper dBHelper = new DBHelper();

            DataSet user = dBHelper.UserBool(Account);

            if (user.Tables[0].Rows.Count != 0)
            {
                string TurnPassword = user.Tables[0].Rows[0]["Password"].ToString();

                if (Password == TurnPassword)
                {
                    return new Home_Response { data = TJson.DatasetToJson(user) };
                }
                else
                {
                    //密码错误
                    return new Home_Response { status = 1, message = "false" };
                }

            }
            else
            {
                //账号不存在
                return new Home_Response { status = 1, message = "false" };
            }
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataResult Updata(User user)
        {
            DBHelper dBHelper = new DBHelper();

            if (dBHelper.UpdataUser(user))
                //更新成功
                return new Home_Response { status = 0, message = "true" };
            else
                //更新失败
                return new Home_Response { status = 1, message = "false" };
        }

        /// <summary>
        /// 发起就业申请
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public DataResult ApplicationPost(Application application)
        {
            DBHelper dBHelper = new DBHelper();

            if(dBHelper.ApplicationPost(application))
                //修改成功
                return new Home_Response { status = 0, message = "true" };
            else
                //修改失败
                return new Home_Response { status = 1, message = "false" };
        }

        /// <summary>
        /// 查询就业申请
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public DataResult GetAppInfo(int UId)
        {
            DBHelper dBHelper = new DBHelper();

            DataSet appinfo = dBHelper.GetAppInfo(UId);

            if (appinfo == null)
                return new Home_Response { data = appinfo };
            else
                return new Home_Response { data = TJson.DatasetToJson(appinfo) };
        }
    }
}
