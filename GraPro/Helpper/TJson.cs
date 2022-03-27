using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Text;

namespace GraPro.Helpper
{
    public class TJson
    {
        /// <summary>
        /// dataset转Json
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DatasetToJson(System.Data.DataSet ds)
        {
            StringBuilder json = new StringBuilder();
            foreach (System.Data.DataTable dt in ds.Tables)
            {
                json.Append(DataTableToJson(dt));
                json.Append(",");
            }
            json.Remove(json.Length - 1, 1);
            return json.ToString();
        }

        /// <summary>
        /// table转json
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\""));
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }

    }
}