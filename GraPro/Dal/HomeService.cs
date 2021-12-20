using System;
using System.Collections.Generic;
using GraPro.Helpper;
using GraPro.Models;
using GraPro.ResponseModel;

namespace GraPro.Dal
{
    public class HomeService
    {
        public DataResult GetToken(string UserName, string Password)
        {

            DataResult result = new DataResult();

            //假设用户名为"admin"，密码为"123" 
            if (UserName == "admin" && Password == "123")
            {
                var payload = new Dictionary<string, object>
                {
                    { "id" , 1 },
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
