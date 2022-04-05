using GraPro.Dal;
using GraPro.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult LoginIn(Account account)
        {

            HomeService homeService = new HomeService();

            var result = homeService.GetUser(account.account, account.password);

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

        /// <summary>
        /// 提交就业申请
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostApplication(Application application)
        {
            HomeService homeService = new HomeService();

            var result = homeService.ApplicationPost(application);

            return Ok(result);
        }

        /// <summary>
        /// 查询就业申请
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ApplicationInfo(AppInfo appInfo)
        {
            HomeService homeService = new HomeService();

            var result = homeService.GetAppInfo(appInfo.UId);

            return Ok(result);
        }
    }
}