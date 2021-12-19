using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraPro.Dal;
using GraPro.Helpper;
using GraPro.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace GraPro.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 登陆
        /// 账号密码获取Token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateToken(User user)
        {

            HomeService homeService = new HomeService();

            var result = homeService.GetToken(user.UserName, user.Password);

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