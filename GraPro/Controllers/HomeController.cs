using GraPro.Dal;
using GraPro.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace GraPro.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginIn(User user)
        {

            HomeService homeService = new HomeService();

            var result = homeService.GetUser(user.UserName, user.Password);

            return Ok(result);
        }

        /// <summary>
        /// 更新个人信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdataInfo(User user)
        {
            HomeService homeService = new HomeService();

            var result = homeService.Updata(user);

            return Ok(result);
        }

    }
}