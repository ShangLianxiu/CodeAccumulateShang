using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CodeAccumulateShang.DataTable转换
{
    /// <summary>
    /// 生成一个DataTable
    /// </summary>
    public class 生成一个DataTable
    {
        #region[创建DataTable]
        /// <summary>
        /// 创建一个都是String类型的DataTable
        /// </summary>
        /// <param name="columnNameList">列名列表</param>
        /// <returns></returns>
        public DataTable CreateDataTableString(List<string> columnNameList)
        {
            try
            {
                DataTable table = new DataTable();
                foreach (var item in columnNameList)
                {
                    table.Columns.Add(item, Type.GetType("System.String"));
                }
                return table;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 创建任何类型的DataTable
        /// </summary>
        /// <param name="columnNameAndTypeList">偶数是列表名(0,2,4,6...)，奇数是列表类型(1,3,5,7...)</param>
        /// <returns></returns>
        public DataTable CreateDataTableAll(List<string> columnNameAndTypeList)
        {
            try
            {
                DataTable table = new DataTable();

                //列表满足个数是偶数
                if (columnNameAndTypeList.Count > 0 && columnNameAndTypeList.Count % 2 == 0)
                {
                    for (int i = 0; i < columnNameAndTypeList.Count; i += 2)
                    {
                        table.Columns.Add(columnNameAndTypeList[i], Type.GetType(columnNameAndTypeList[i + 1]));
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
