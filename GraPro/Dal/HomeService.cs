using System;
using System.Collections.Generic;
using GraPro.Helpper;
using GraPro.Models;
using GraPro.ResponseModel;
using MySql.Data.MySqlClient;

namespace GraPro.Dal
{
    public class HomeService
    {
        public DataResult GetToken(string UserName, string Password)
        {

            DataResult result = new DataResult();


            MySqlConnection cnn = new MySqlConnection();

            //cnn.ConnectionString = 

            //假设用户名为"admin"，密码为"123" 
            if (UserName == "admin" && Password == "123")
            {
                var payload = new Dictionary<string, object>
                {
                    { "id" , 1 },
                    { "role","管理员" },
                    { "username",UserName },
                    { "StartTime",DateTime.Now }
                };

                var Token = JwtHelp.SetJwtEncode(payload);


                return new Home_Response { data = new { Token = Token } };

            }
            else
            {

                return new Home_Response { status = 1, message = "false" };

            }

        }
    }
}
