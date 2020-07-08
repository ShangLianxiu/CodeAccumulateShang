using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace CodeAccumulateShang.DataTable转换
{
    public static class DataTable正反转换
    {
        /// <summary>
        /// IEnumerable转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable IEnumerableToDataTable<T>(this IEnumerable<T> items)
        {
            // Create the result table, and gather all properties of a T        
            DataTable table = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Add the properties as columns to the datatable
            foreach (var prop in props)
            {
                Type propType = prop.PropertyType;

                // Is it a nullable type? Get the underlying type 
                if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    propType = new NullableConverter(propType).UnderlyingType;

                table.Columns.Add(prop.Name, propType);
            }

            // Add the property values per T as rows to the datatable
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item, null);

                table.Rows.Add(values);
            }

            return table;
        }

        /// <summary>
        /// DataTable转换成Json
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string DataTableToJsonWithJsonNet(DataTable table)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }
    }
}
