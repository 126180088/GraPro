using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraPro.Dal;
using GraPro.Helpper;
using GraPro.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace GraPro.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 登陆
        /// 账号密码获取Token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateToken(string username, string pwd)
        {

            HomeService homeService = new HomeService();

            var result = homeService.GetToken(username, pwd);

            return Ok(result);
        }

        //[HttpPost]
        //public ActionResult ToToken(string token)
        //{

        //    var result = JwtHelp.GetJwtDecode(token);

        //    return Ok(result);
        //}
    }
}