using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;

namespace CarQueryWeb.Common
{
    public abstract class GenerateLog
    {
        public static readonly string LogFile = HttpContext.Current.Server.MapPath(Constant.Log);
        
        /// <summary>
        /// 用于将错误信息输出到txt文件
        /// </summary>
        /// <param name="errorMessage">错误详细信息</param>
        public static void WriteError(string errorMessage)
        {
            try
            {
                if (!Directory.Exists(LogFile))
                {
                    Directory.CreateDirectory(LogFile);
                }
                string path = Path.Combine(LogFile,DateTime.Today.ToString("yyyyMMdd") + ".log"); ;
                
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                using(FileStream fs=new FileStream(path,FileMode.Append,FileAccess.Write,FileShare.ReadWrite))
                {
                    UTF8Encoding utf8 = new UTF8Encoding(); // Create a UTF-8 encoding. 
                    StringBuilder sb = new StringBuilder();
                    sb.Append("\r\nLog Entry : \r\n");//CultureInfo.InvariantCulture
                    sb.Append(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "\r\n");
                    sb.Append(errorMessage + "\r\n");
                    sb.Append("________________________________________________________\r\n");
                    string EnUserid = utf8.GetString(utf8.GetBytes(sb.ToString()));
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(fs, Encoding.UTF8))
                    {
                        file.WriteLine(EnUserid);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }
    }
}