using GraPro.Models;
using GraPro.ResponseModel;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GraPro.Helpper
{
    public class JwtHelp
    {
        //私钥 web.config中配置
        //"GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        private static string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        //ConfigurationManager.AppSettings["PrivateToken"].ToString();

        /// <summary>
        /// 生成JwtToken
        /// </summary>
        /// <param name="payload">不敏感的用户数据</param>
        /// <returns></returns>
        public static string SetJwtEncode(Dictionary<string, object> payload)
        {

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);

            return token;
        }

        /// <summary>
        /// 根据jwtToken 获取实体
        /// </summary>
        /// <param name="token">jwtToken</param>
        /// <returns></returns>
        public static DataResult GetJwtDecode(string token)
        {

            TJson jwt = new TJson();

            Home_Response home_Response = new Home_Response();

            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                var algorithm = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                User userInfo = decoder.DecodeToObject<User>(token, secret, verify: true);//token为之前生成的字符串

                //DateTime endTime = DateTime.Parse(userInfo.StartTime).AddHours(1);
                DateTime endTime = userInfo.StartTime.AddHours(3);




                if (endTime > DateTime.Now)
                {

                    home_Response.data = userInfo ;

                }
                else
                {
                    home_Response.result = 1;
                    home_Response.message = "Token已过期";
                }

                return home_Response;
            }
            catch (Exception e)
            {

                home_Response.message = e.Message;

                home_Response.result = 1;

                return home_Response;
            }


        }
    }
}