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
        /// <param name="station"></param>
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
        /// <param name="station"></param>
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
        /// <param name="station"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetIType()
        {

            StationService stationService = new StationService();

            var result = stationService.ItypeInfo();

            return Ok(result);
        }
    }
}
