using System.Reflection;
using System.Text;

namespace GraPro.Helpper
{
    public class TJson
    {
        /// <summary>
        /// 转换T为json
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="model">对象</param>
        /// <returns>json</returns>
        public string ConvertToJson<T>(T model)
        {
            //获取属性集合
            PropertyInfo[] properties = model.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            //遍历属性集合
            for (int i = 0, len = properties.Length; i < len; i++)
            {
                if (0 != i) sb.Append(",");
                sb.AppendFormat("\"{0}\":\"{1}\"",
                    properties[i].Name.ToLower(),//属性名作为 键
                    properties[i].GetValue(model, null).ToString());//属性值作为 值
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}