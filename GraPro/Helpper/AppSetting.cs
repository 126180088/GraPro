using Microsoft.Extensions.Configuration;

namespace GraPro.Helpper
{
    public static class AppSetting
    {
        private static IConfigurationSection _configurationSection = null;
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSetting(string key)
        {
            return _configurationSection.GetSection(key)?.Value;
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="section"></param>
        public static void SetAppSetting(IConfigurationSection section)
        {
            _configurationSection = section;
        }
    }
}
