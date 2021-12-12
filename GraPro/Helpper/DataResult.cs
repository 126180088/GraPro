using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT.MvcDemo.Models
{
    public class DataResult
    {
        /// <summary>
        /// 消息返回类
        /// </summary>
        public string Token { get; set; }

        public object Data { get; set; }

        public string Message { get; set; }

    }
}