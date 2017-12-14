using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace CarQueryWeb.AjaxHandler
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler
    {

        HttpContext RequestStr = null;
        public void ProcessRequest(HttpContext context)
        {
            RequestStr = context;
            RequestStr.Response.ContentType = "text/plain";
            RequestStr.Response.Charset = "utf-8";
            String methodName = RequestStr.Request["method"];
            String name = context.Request["name"];
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(methodName);

            if (method == null)
            {
                throw new Exception("method is null");
            }

            try
            {
                method.Invoke(this, null);
            }
            catch { }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public void UserLogin()
        {
            try
            {
                string username = HttpUtility.UrlDecode(RequestStr.Request.Form["UserName"]);
                string pwd = HttpUtility.UrlDecode((RequestStr.Request.Form["UserPwd"]));
                string Remember = HttpUtility.UrlDecode((RequestStr.Request.Form["Remember"]));
                bool flag = CheckUser(username, pwd);
                if (flag)
                {
                    HttpCookie cookie = new HttpCookie("USER_COOKIE");
                    if (Remember.Equals("checked"))
                    {
                        //所有的验证信息检测之后，如果用户选择的记住密码，则将用户名和密码写入Cookie里面保存起来。
                        cookie.Values.Add("UserName", username);
                        cookie.Values.Add("Password", pwd);
                        //这里是设置Cookie的过期时间，这里设置一个星期的时间，过了一个星期之后状态保持自动清空。
                        cookie.Expires = System.DateTime.Now.AddDays(7.0);
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        if (cookie != null)
                        {
                            //如果用户没有选择记住密码，那么立即将Cookie里面的信息情况，并且设置状态保持立即过期。
                            RequestStr.Response.Cookies["USER_COOKIE"].Expires = DateTime.Now.AddDays(-1);
                        }
                    }
                    HttpRequest request = HttpContext.Current.Request;
                    string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(result)) { result = request.ServerVariables["REMOTE_ADDR"]; }
                    if (string.IsNullOrEmpty(result)) { result = request.UserHostAddress; }
                    if (string.IsNullOrEmpty(result)) { result = "0.0.0.0"; }
                    MODEL.LoginLog log = new MODEL.LoginLog();
                    log.ID = username;
                    log.LoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.IPAddress= HttpContext.Current.Request.UserHostAddress;
                    log.State = "正常登录";
                    log.Address = "天津市环保局";
                    Common.XMLHelper.WriteLoginLog("log.xml",new List<MODEL.LoginLog>());
                    RequestStr.Response.Write(Success("登陆成功！"));
                }
                else
                {
                    RequestStr.Response.Write(Failure("登陆失败，用户名或密码错误！"));
                }

        
            }
            catch
            {
                RequestStr.Response.Write(Failure("登录异常！"));
            }

        }
        public string Success(string str)
        {
            return "{\"code\":\"200\", \"message\":\"" + str + "\"}";
        }
        public string Failure(string str)
        {
            return "{\"code\":\"300\", \"message\":\"" + str + "\"}";
        }

        public bool CheckUser(string strUserName, string strPassWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select psn.PSN_ID,psn.PSN_ACCOUNT,psn.PSN_PWD,psn.PSN_NAME,psn.PSN_DESC,psn.PSN_UNITCODE");
            strSql.Append(" FROM TB_USER psn ");
            if (strUserName != "" && strPassWord != "")
            {
                strSql.Append(" where psn.IsDeleted = 0 and PSN_DUTYID='"+Constant.UnitCode+"' and psn.PSN_ACCOUNT='" + strUserName + "' and psn.PSN_PWD='" + strPassWord + "'");
            }
            DataSet ds = DB.OracleHelper.ExecuteDataSet(CommandType.Text,strSql.ToString());
            if (ds!=null)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}