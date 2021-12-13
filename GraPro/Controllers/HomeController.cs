using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraPro.Dal;
using GraPro.Helpper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace GraPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 登陆
        /// </summary>
        [HttpGet]
        public IActionResult SignIn(int id)
        {
            return Ok("success");
        }

        /// <summary>
        /// 创建jwtToken
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
    }
}