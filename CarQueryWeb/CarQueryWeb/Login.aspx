<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CarQueryWeb.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>天津市机动车排污检控中心监控平台</title>
    <meta name="generator" content="MShtml 8.00.6001.18783" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <style type="text/css">
        .download {
            margin: 20px 33px 10px;
            *margin-bottom: 30px;
            padding: 5px;
            border-radius: 3px;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            background: #e6e6e6;
            border: 1px dashed #df0031;
            font-size: 14px;
            font-family: Comic Sans MS;
            font-weight: bolder;
            color: #555;
        }

            .download a {
                padding-left: 5px;
                font-size: 14px;
                font-weight: normal;
                color: #555;
                text-decoration: none;
                letter-spacing: 1px;
            }

                .download a:hover {
                    text-decoration: underline;
                    color: #36F;
                }

            .download span {
                float: right;
            }
    </style>
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/store.min.js"></script>
    <script type="text/javascript" src="js/placeholder.js"></script>
    <script type="text/javascript">
        function btnLoginClick() {
            var user = $("#name").val();
            var pwd = $("#password").val();
            var rem = $("#remember").attr("checked");
            if (user.length == 0) {
                alert("请输入登录名！");
                return false;
            }

            if (pwd.length == 0) {
                alert("请输入密码！");
                return false;
            }

            var data = {
                UserName: encodeURIComponent(user),
                UserPwd: encodeURIComponent(pwd),
                Remember: encodeURIComponent(rem),
                method: "UserLogin"
            };

            //$.ajax({
            //    url: 'http://ip.taobao.com/service/getIpInfo.php?ip=192.168.43.8',
            //    type: 'GET',
            //    dataType: 'json',
            //    timeout: 10000,  //设定超时  
            //    cache: false,   //禁用缓存  
            //    error: function (xml) {
            //        alert("网络连接错误!");
            //    },
            //    success: function (xml) {
            //    }
            //});
            $.ajax({
                url: 'xml/user.xml',
                type: 'GET',
                dataType: 'xml',
                timeout: 10000,  //设定超时  
                cache: false,   //禁用缓存  
                error: function (xml) {
                    alert("网络连接错误!");
                },
                success: function (xml) {
                    $(xml).find("user").each(function (i) {
                        var self = $(this);
                        var name = self.attr("name");  //获取节点的属性  
                        var password = self.attr("password");
                        if (name == user && password == pwd) {
                            store.set('dengluzhanghao', user); 
                            if (eval('(' + store.get(user) + ')') != undefined || eval('(' + store.get(user) + ')') != null) {
                                //objc = eval('(' + store.get(user) + ')').bianhao.split(',');
                                window.location.href = 'index/index.html';
                                //for (var c = 0; c < 10; c++) {
                                //    if (objc[ c ] == 1) {
                                //        location.href = "CarQueryIndex.aspx";
                                //        break;
                                //    }
                                //    if (objc[c] == 2) {
                                //        location.href = "CarQueryList.aspx";break;
                                //    }
                                //    if (objc[c] == 3) {
                                //        location.href = "CarWarnList.aspx";break;
                                //    }
                                //    if (objc[c] == 4) {
                                //        location.href = "Oil.aspx";break;
                                //    }
                                //    if (objc[c] == 5) {
                                //        location.href = "newcar/NewCarQuery.aspx";break;
                                //    }
                                //    if (objc[c] == 6) {
                                //        location.href = "newcar/NewCarInsert.aspx";break;
                                //    }
                                //    if (objc[c] == 7) {
                                //        location.href = "newcar/CarWeiHu.html";break;
                                //    }
                                //    if (objc[c] == 8) {
                                //        location.href = "newcar/GetInfo.html";break;
                                //    }
                                //    if (objc[c] == 9) {
                                //        location.href = "newcar/LoginLog.html";break;
                                //    }
                                //    if (objc[c] == 10) {
                                //        location.href = "newcar/Authority.html";break;
                                //    }
                                //}
                            }
                            else {
                                //var objc = self.attr("authority").split(',');
                                window.location.href = 'index/index.html';
                                //for (var c = 0; c < objc.length; c++) {
                                //    if (objc[c] == 1) {
                                //        location.href = "CarQueryIndex.aspx"; break;
                                //    }
                                //    if (objc[c] == 2) {
                                //        location.href = "CarQueryList.aspx"; break;
                                //    }
                                //    if (objc[c] == 3) {
                                //        location.href = "CarWarnList.aspx"; break;
                                //    }
                                //    if (objc[c] == 4) {
                                //        location.href = "Oil.aspx"; break;
                                //    }
                                //    if (objc[c] == 5) {
                                //        location.href = "newcar/NewCarQuery.aspx"; break;
                                //    }
                                //    if (objc[c] == 6) {
                                //        location.href = "newcar/NewCarInsert.aspx"; break;
                                //    }
                                //    if (objc[c] == 7) {
                                //        location.href = "newcar/CarWeiHu.html"; break;
                                //    }
                                //    if (objc[c] == 8) {
                                //        location.href = "newcar/GetInfo.html"; break;
                                //    }
                                //    if (objc[c] == 9) {
                                //        location.href = "newcar/LoginLog.html"; break;
                                //    }
                                //    if (objc[c] == 10) {
                                //        location.href = "newcar/Authority.html"; break;
                                //    }
                                //}
                            }
                            return false;
                        } else {
                           // alert(i+ "," + $(xml).find("user").length);
                            if ($(xml).find("user").length == i+1) {
                                alert("用户名或密码错误");
                            }
                        }
                       

                    });
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="header" style="text-align: center; font-weight: bold; font-size: 36px;">天津市机动车排污检控中心监管系统</div>
            <div class="content">
                <div class="title hide">管理登录</div>
                <form name="login" action="#" method="post">
                    <fieldset>
                        <div class="input">
                            <input class="input_all name" name="name" id="name" value="<%=username %>" placeholder="用户名" type="text" onfocus="this.className='input_all name_now';" onblur="this.className='input_all name'" maxlength="24" />
                        </div>
                        <div class="input">
                            <input class="input_all password" name="password" value="<%=password %>" id="password" type="password" placeholder="密码" onfocus="this.className='input_all password_now';" onblur="this.className='input_all password'" maxlength="24" />
                        </div>
                        <div class="checkbox">
                            <input type="checkbox" name="remember" id="remember" /><label for="remember"><span>记住密码</span></label>
                        </div>
                        <div class="enter">
                            <input class="button hide" id="btnLogin" type="button" value="登录" onclick="btnLoginClick()" />
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
    </form>
</body>
</html>





