using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CarQueryWeb.Common
{
    public class StringUtil
    {
        public static string Replace(string str)
        {
            return Regex.Replace(str, @"[/n/r]", "");
        }
        public static string CutString(object content, int num)
        {
            if (content.ToString().Length > num - 2)
            {
                return content.ToString().Substring(0, num - 2) + "...";
            }
            else
            {
                return content.ToString();
            }
        }

        /// <summary>
        /// 填充字符串，满足数据库中字符大小
        /// </summary>
        /// <param name="originalString"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static string FullFillString(string originalString, int digit)
        {
            string maxCode = originalString;
            if (maxCode.Length > digit)
            {
                return "null";
            }
            else if (maxCode.Length == digit)
            {
                return maxCode;
            }
            else
            {
                int j = digit - maxCode.Length;
                for (int i = 0; i < j; i++)
                {
                    maxCode = "0" + maxCode;
                }
                return maxCode;
            }

        }
    }
    
}