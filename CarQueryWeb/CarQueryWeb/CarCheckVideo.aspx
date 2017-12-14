<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarCheckVideo.aspx.cs" Inherits="CarQueryWeb.CarCheckVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>天津市机动车排污检控中心监控平台</title>
    <!-- Bootstrap Styles-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FontAwesome Styles-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- Custom Styles-->
    <link href="assets/css/custom-styles.css" rel="stylesheet" />
    <!-- Google Fonts-->
    <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />


    <!-- JS Scripts-->
    <!-- jQuery Js -->
    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- Bootstrap Js -->
    <script src="assets/js/bootstrap.min.js"></script>

    <!-- Metis Menu Js -->
    <script src="assets/js/jquery.metisMenu.js"></script>


    <!-- Morris Chart Js -->
    <script type="text/javascript">
        function videodown(url) {
            window.location.href = url;
        }
    </script>
</head>
<body>
    <div id="wrapper">
        <nav class="navbar navbar-default top-navbar" role="navigation">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" style="font-size: 17px;" href=""><strong><i class="icon fa fa-truck fa-2x"></i></strong></a>

                <div id="sideNav" href="">
                    <i class="fa fa-bars icon"></i>
                </div>
                <div style="float: left; vertical-align: middle; font-size: 24px; margin-left: 10px; margin-top: 10px;">
                    天津市环保局尾气检测数据统计系统
                </div>
            </div>

        </nav>
        <!--/. NAV TOP  -->
        <nav class="navbar-default navbar-side" role="navigation">
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu">

                  
                 
                </ul>

            </div>

        </nav>
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper">
            <div class="header">
                <h1 class="page-header">
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#">天津市环保局</a></li>
                </ol>

            </div>
            <div id="page-inner">

            
                <div class="row">
                    <div class="col-md-12">
                    </div>
                </div>

               <div class="row">
            <div>
                <% 
                    string CheckDate = Request.QueryString["CheckDate"];
                    string OutLookId=Request.QueryString["OutLookId"];
                    string IPAddress=Request.QueryString["IPAddress"];
                    string CheckMethod=Request.QueryString["CheckMethod"];
                    string url = "#";
                    if (!string.IsNullOrEmpty(IPAddress))
                    {
                        
                        if(!string.IsNullOrEmpty(CheckDate)&&!string.IsNullOrEmpty(OutLookId)){
                           url = "http://"+IPAddress+":8801/report/"+Constant.VideoUrl + "/" + CheckDate + "/" + OutLookId +"/";
                        }
                    }
                    string frontVideoUrl = url+ "1.avi";
                    
                    string behindVideoUrl = url + "2.avi";
                    
                    string pathUrl1 = "", pathUrl2 = "", pathUrl3 = "", pathUrl4 = "", pathUrl5 = "", pathUrl6 = "";
                    if (CheckMethod.Equals("B"))//稳态
                    {
                        pathUrl1 = url + "start5025photo_1.bmp";
                        
                        pathUrl2 = url + "start5025photo_2.bmp";
                        
                        pathUrl3 = url + "start2540photo_1.bmp";
                        
                        pathUrl4 = url + "start2540photo_2.bmp";
                        
                    }
                    else if(CheckMethod.Equals("G"))//加载减速
                    {
                        pathUrl1 = url + "startk80photo_1.bmp";
                        
                        pathUrl2 = url + "startk80photo_2.bmp";
                        
                        pathUrl3 = url + "startk90photo_1.bmp";
                        
                        pathUrl4 = url + "startk90photo_2.bmp";
                        
                        pathUrl5 = url + "startk100photo_1.bmp";
                        
                        pathUrl6 = url + "startk100photo_2.bmp";
                        
                    }
                    string[,] arrayPhoto = new string[,]{
                        {pathUrl1, pathUrl2},
                        {pathUrl3, pathUrl4},
                        {pathUrl5, pathUrl6}
                    };



                %>
                <label>视频下载：</label>
                <a href="<%=frontVideoUrl %>" onclick="videodown('<%=frontVideoUrl %>')">前置录像</a>&nbsp;&nbsp;&nbsp;
                <a href="<%=behindVideoUrl %>" onclick="videodown('<%=behindVideoUrl %>')">后置录像</a>
            </div>
            <div style="height: 10px;"></div>
            <table class="imggrp">
                <%for(int i=0;i<3;i++){
                %><tr>
                    <%
                                  for (int j = 0; j < 2;j++ )
                      {
                    %><td><%
                          if(!string.IsNullOrEmpty(arrayPhoto[i,j])){
                    %>
                        <img alt="无图片" src="<%=arrayPhoto[i,j] %>" />
                        <%
                          }%>
                    </td>
                    <%}%>
                </tr>
                <%
                  }%>
            </table>

        </div>

                <div class="row"><input style="font-size:25px;width:70px;height:50px;" type="button" value="返回" onclick="window.history.back()" /></div>
            </div>
            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  -->
    </div>
    <!-- /. WRAPPER  -->
    <script src="js/common.js" type="text/javascript"></script>
</body>
</html>
