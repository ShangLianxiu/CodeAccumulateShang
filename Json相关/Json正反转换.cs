using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CodeAccumulateShang.Json相关
{
    public class Json正反转换
    {
        /// <summary>
        /// DataTable转换成Json
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public string DataTableToJsonWithJsonNet(DataTable table)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }
    }
}
