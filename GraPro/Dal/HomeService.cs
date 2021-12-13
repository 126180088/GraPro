using System;
using System.Collections.Generic;
using GraPro.Helpper;
using GraPro.Models;
using GraPro.ResponseModel;

namespace GraPro.Dal
{
    public class HomeService
    {
        public DataResult GetToken(string UserName, string Pwd)
        {

            DataResult result = new DataResult();

            //假设用户名为"admin"，密码为"123" 
            if (UserName == "admin" && Pwd == "123")
            {
                var payload = new Dictionary<string, object>
                {
                    { "username",UserName },
                    { "pwd", Pwd }
                };

                var Token = JwtHelp.SetJwtEncode(payload);


                return new Home_Response { data = Token, result = 0, message = "success" };

            }
            else
            {

                return new Home_Response { data = string.Empty, result = 1, message = "false" };

            }

        }
    }
}
