using MySql.Data.MySqlClient;
using System.Configuration;

namespace GraPro.Helpper
{
    public static class DBHelper
    {
        //声明一个私有的构造方法，让外部无法调用这个类的构造方法
        private  DBHelper()
        {
            string conn = AppSetting.GetAppSetting("conn");

            //声明一个MySqlConnection来控制数据的连接
            MySqlConnection con = new MySqlConnection();
        }

        //创建静态的方法，  创建此类唯一的对象
        public static DBHelper MysqlConfig()
        {
                
            return con;
        }
    }
}
