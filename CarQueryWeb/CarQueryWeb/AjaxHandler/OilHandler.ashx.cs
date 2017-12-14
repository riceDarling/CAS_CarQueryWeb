using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;

namespace CarQueryWeb.AjaxHandler
{
    /// <summary>
    /// OilHandler 的摘要说明
    /// </summary>
    public class OilHandler : IHttpHandler, IRequiresSessionState
    {

        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        HttpContext RequestStr = null;
        public void ProcessRequest(HttpContext context)
        {
            RequestStr = context;
            RequestStr.Response.ContentType = "text/plain";
            RequestStr.Response.Charset = "utf-8";
            //String methodName = context.Request["method"];
            //String name = context.Request["name"];
            //Type type = this.GetType();
            //MethodInfo method=null;
            //try {  method = type.GetMethod(methodName); } catch { }

            //if (method == null)
            //{
            //    throw new Exception("method is null");
            //}

            //try
            //{
            //    method.Invoke(this, null);
            //}
            //catch { }
        }

        [WebMethod]
        public static void QueryJyqb(string date)
        {
            string result = "";

            string date1 = HttpContext.Current.Request["date"];

            //return result;
        }
    }
}