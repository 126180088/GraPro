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

        public DataResult Updata(User user)
        {
            DBHelper dBHelper = new DBHelper();

            if (dBHelper.UpdataUser(user))
                //修改成功
                return new Home_Response { status = 0, message = "true" };
            else
                //修改失败
                return new Home_Response { status = 1, message = "false" };
        }
    }
}
