using CarQueryWeb.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarQueryWeb
{
    public partial class Login : System.Web.UI.Page
    {
        public string username = "", password = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        
            if (!IsPostBack)
            {
                //读取保存的Cookie信息
                HttpCookie cookies = Request.Cookies["USER_COOKIE"];
                if (cookies != null)
                {
                    //如果Cookie不为空，则将Cookie里面的用户名和密码读取出来赋值给前台的文本框。
                    username = cookies["UserName"];
                    password = cookies["Password"];
                    //这里依然把记住密码的选项给选中。
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), Guid.NewGuid().ToString(), "$(\"#remember\").attr(\"checked\",\"checked\");", true);
                }
            }
        }




    }
}