using GraPro.Dal;
using GraPro.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace GraPro.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StationController : Controller
    {
        /// <summary>
        /// 添加岗位
        /// </summary>
        /// <param name="Station"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StationAdd(Station station)
        {

            StationService stationService = new StationService();

            var result = stationService.CreateStation(station);

            return Ok(result);
        }

        /// <summary>
        /// 查询岗位类型
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSType()
        {

            StationService stationService = new StationService();

            var result = stationService.StypeInfo();

            return Ok(result);
        }

        /// <summary>
        /// 查询行业类型
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetIType()
        {

            StationService stationService = new StationService();

            var result = stationService.ItypeInfo();

            return Ok(result);
        }

        /// <summary>
        /// 查询岗位信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetStation()
        {

            StationService stationService = new StationService();

            var result = stationService.StationInfo();

            return Ok(result);
        }

        /// <summary>
        /// 查询就业状态
        /// </summary>
        /// <param name="AppInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AppStatus(AppInfo appInfo)
        {

            StationService stationService = new StationService();

            var result = stationService.Status(appInfo.UId);

            return Ok(result);
        }

        /// <summary>
        /// 就业申请审批
        /// </summary>
        /// <param name="AppInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AppCheck(AppResult appResult)
        {

            StationService stationService = new StationService();

            var result = stationService.Check(appResult);

            return Ok(result);
        }
    }
}
