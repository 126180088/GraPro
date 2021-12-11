using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}