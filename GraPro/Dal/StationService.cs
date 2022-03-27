using GraPro.Helpper;
using GraPro.Models;
using GraPro.ResponseModel;
using System.Data;

namespace GraPro.Dal
{
    public class StationService
    {
        public DataResult CreateStation(Station station)
        {
            DBHelper dBHelper = new DBHelper();

            if (dBHelper.CreateStation(station))
                //创建成功
                return new Home_Response { status = 0, message = "true" };
            else
                //创建失败
                return new Home_Response { status = 1, message = "false" };
        }
        public DataResult StypeInfo()
        {
            DBHelper dBHelper = new DBHelper();

            DataSet data = dBHelper.StypeInfo();

            string jsondata = TJson.DatasetToJson(data);

                //创建成功
            return new Home_Response { data = jsondata };
        }

        public DataResult ItypeInfo()
        {
            DBHelper dBHelper = new DBHelper();

            DataSet data = dBHelper.ItypeInfo();

            string jsondata = TJson.DatasetToJson(data);

            //创建成功
            return new Home_Response { data = jsondata };
        }
    }
}
