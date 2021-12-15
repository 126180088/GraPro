using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace GraPro.Helpper
{
    public class DataResult
    {
        public DataResult()
        {
            data = string.Empty;
            result = 0;
            message = "success";
        }

        /// <summary>
        /// 消息返回类
        /// </summary>
        public object data { get; set; }

        public int result { get; set; }

        public string message { get; set; }

    }
}