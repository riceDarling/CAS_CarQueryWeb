using CarQueryWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CarQueryWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            /*Exception objErr = Server.GetLastError().GetBaseException();
            //记录出现错误的IP地址
            string strIP = Request.UserHostAddress;
            string err = "Ip【" + strIP + "】" + Environment.NewLine + "Error in【" + Request.Url.ToString() + "  Medth:" + objErr.TargetSite +
                               "】" + Environment.NewLine + "Error Message【" + objErr.Message.ToString() + "】";
            //记录错误
            GenerateLog.WriteError(err);*/
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}