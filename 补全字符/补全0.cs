using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAccumulateShang.补全字符
{
    public class 补全0
    {
        /// <summary>
        /// 右对齐此实例中的字符，在左边用空格或指定的 Unicode 字符填充以达到指定的总长度。
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="strlen">结果字符串中的字符数，等于原始字符数加上任何其他填充字符。</param>
        /// <param name="addstr">Unicode 填充字符，默认值为空格</param>
        /// <returns>字符型</returns>
        /// <remarks>20170413新增</remarks>
        public string PadLeft(string str, int strlen, string addstr = " ")
        {
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding("gb2312");
            byte[] bytes = chs.GetBytes(str);
            int addlen = strlen - bytes.Length;
            string ret = "";
            if (addlen <= 0)
            {
                ret = chs.GetString(bytes, 0, strlen);
            }
            else
            {
                for (int i = 1; i <= addlen; i++)
                {
                    ret += addstr;
                }
                ret += str;
            }
            return ret;
        }
    }
}
