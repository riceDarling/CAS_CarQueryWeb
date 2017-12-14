<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarWarnList.aspx.cs" Inherits="CarQueryWeb.CarWarnList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>天津市机动车排污检控中心监控平台</title>
    <!-- Bootstrap Styles-->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/bootstrap-table.min.css" rel="stylesheet" />
    <!-- FontAwesome Styles-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- Custom Styles-->
    <link href="assets/css/custom-styles.css" rel="stylesheet" />
    <link href="assets/css/select2.min.css" rel="stylesheet" />
    <link href="assets/css/checkbox3.min.css" rel="stylesheet" />
    <link href="css/query.css" rel="stylesheet" />


    <script src="assets/js/jquery-2.2.1.min.js"></script>
    <!-- Bootstrap Js -->
    <script src="assets/js/colResizable-1.6.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/bootstrap-table.js"></script>
    <script src="assets/js/bootstrap-table-zh-CN.js"></script>
    <script src="assets/js/bootstrap-table-fixed-columns.js"></script>

    <!-- Metis Menu Js -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <script src="assets/js/select2.full.min.js"></script>


  
    <script src="js/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        var queryParams = {};
        var somecol = [{
            title: '检测机构', field: 'UnitName', align: 'center', width: '200', valign: 'middle'
        },
        { title: '车牌号码', field: 'CNUMBERPLATE', align: 'center', width: '200', valign: 'middle' },
        { title: '车主/单位', field: 'CUSER', align: 'center', width: '200', valign: 'middle' },
        {
            title: '检测结果', field: 'CISPASS', align: 'center', width: '100', valign: 'middle', formatter: function (value, rowData, rowIndex) {
                if (value == '1') {
                    return "合格";
                }
                return "不合格";
            }
        },
        {
            title: '车辆类型', field: 'VehicleModel', align: 'center', width: '100', valign: 'middle', formatter: function (value, rowData, rowIndex) {
                if (value == '0') {
                    return "汽油车";
                }
                return "柴油车";
            }
        },
        {
            title: '检测方法', field: 'CheckMethod', align: 'center', width: '100', valign: 'middle', formatter: function (value, rowData, rowIndex) {
                if (value == 'B') {
                    return "稳态";
                }
                else if (value == 'A') {
                    return "双怠速";
                }
                else if (value == 'G') {
                    return "加载减速";
                }
                else if (value == 'F') {
                    return "不透光";
                }
            }
        }, { title: '地址', field: 'CADDRESS', align: 'center', width: '500', valign: 'middle' }];
        var tempcolumns = [
            
            { title: '值1', field: 'V1', align: 'center', width: '100', valign: 'middle' },
            { title: '值2', field: 'V2', align: 'center', width: '100', valign: 'middle' },
            { title: '值3', field: 'V3', align: 'center', width: '100', valign: 'middle' },
            { title: '值4', field: 'V4', align: 'center', width: '100', valign: 'middle' },
            { title: '值5', field: 'V5', align: 'center', width: '100', valign: 'middle' },
            { title: '值6', field: 'V6', align: 'center', width: '100', valign: 'middle' }
            //,
            //{ title: 'ASM5025CO', field: 'V1', align: 'center', width: '100', valign: 'middle' },
            //{ title: 'ASM2540CO', field: 'V2', align: 'center', width: '100', valign: 'middle' },
            //{ title: 'ASM5025HC', field: 'V3', align: 'center', width: '100', valign: 'middle' },
            //{ title: 'ASM2540HC', field: 'V4', align: 'center', width: '100', valign: 'middle' },
            //{ title: 'ASM5025NO', field: 'V5', align: 'center', width: '100', valign: 'middle' },
            //{ title: 'ASM2540NO', field: 'V6', align: 'center', width: '100', valign: 'middle' },
            //,
            ////{ title: 'ASM2540NO', field: 'V6', align: 'center', width: '100', valign: 'middle', },
            //{ title: 'K100', field: 'V1', align: 'center', width: '100', valign: 'middle'},
            //{ title: 'K90', field: 'V2', align: 'center', width: '100', valign: 'middle'},
            //{ title: 'K80', field: 'V3', align: 'center', width: '100', valign: 'middle' },
            //{ title: 'NPOWER', field: 'V4', align: 'center', width: '100', valign: 'middle' },
            ////{ title: 'ASM5025NO', field: 'V5', align: 'center', width: '100', valign: 'middle' },
            ////{ title: 'ASM2540NO', field: 'V6', align: 'center', width: '100', valign: 'middle', },
            //{ title: '第一次', field: 'V1', align: 'center', width: '100', valign: 'middle'},
            //{ title: '第二次', field: 'V2', align: 'center', width: '100', valign: 'middle'},
            //{ title: '第三次', field: 'V3', align: 'center', width: '100', valign: 'middle'},
            ////{ title: 'ASM2540HC', field: 'V4', align: 'center', width: '100', valign: 'middle' },
            ////{ title: 'ASM5025NO', field: 'V5', align: 'center', width: '100', valign: 'middle' },
            ////{ title: 'ASM2540NO', field: 'V6', align: 'center', width: '100', valign: 'middle', },
            //{ title: '地址', field: 'CADDRESS', align: 'center', width: '500', valign: 'middle' }
        ];
        var columns = somecol.concat(tempcolumns);
        $(document).ready(function loadTable() {
            var height = $(window).height() - 195;

            //var CheckMethodValue = $("#CheckMethod").val();
            $('#tabmenu').bootstrapTable({
                url: './CarQueryIndex.aspx/GetWarnCarList',
                method: 'post',      //请求方式（*）
                striped: true,      //是否显示行间隔色
                cache: false,      //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
                pagination: true,     //是否显示分页（*）
                sortable: false,      //是否启用排序
                sortOrder: "asc",     //排序方式
                queryParams: queryParams,//传递参数（*）
                pageNumber: 1,      //初始化加载第一页，默认第一页
                pageSize: 20,      //每页的记录行数（*）
                pageList: [10, 20, 40, 60, 100],  //可供选择的每页的行数（*）
                singleSelect: false,
                pagination: true,
                //search: true,      //是否显示表格搜索，此搜索是员工端搜索，不会进服务端
                //strictSearch: true,
                //showRefresh: true,     //是否显示刷新按钮
                minimumCountColumns: 2,    //最少允许的列数
                //clickToSelect: true,    //是否启用点击选中行
                //uniqueId: "",      //每一行的唯一标识，一般为主键列
                //showToggle:false,     //是否显示详细视图和列表视图的切换按钮
                height: height,
                columns: columns,
                // sidePagination: "server", //服务端处理分页
                onLoadSuccess: function (rows) {  //加载成功时执行
                    var result = eval("(" + rows.d + ")");
                    $('#tabmenu').bootstrapTable('load', result.rows);
                },
                onClickRow: function (row) {
                    //$.ajax({
                    //    type: 'post',
                    //    url: 'CarQueryIndex.aspx/getcfacecheck?CFACECHECKID='+row.CFACECHECKID,
                    //    contentType: "application/json; charset=utf-8",
                    //    dataType: "json",
                    //    success: function (data) {
                    //        var temp = eval("("+data.d+")");
                    //        if (temp.message == "success") {
                    //            window.location.href = temp.url;
                    //        }
                    //    },
                    //    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //        alert("需要更新数据库");
                    //        /*alert(XMLHttpRequest.status);
                    //        alert(XMLHttpRequest.readyState);
                    //        alert(textStatus);*/
                    //    }
                    //});

                    var dateStr = row.CheckDate.replace(/-/g, "");
                    //var urlStr = "http://" + row.IPAddress + ":8801/report/VideoPrintScreen/" + dateStr + "/" + row.CFACECHECKID + "/1.avi";
                    var urlStr = "CarCheckVideo.aspx?IPAddress=" + row.IPAddress + "&CheckDate=" + dateStr + "&OutLookId=" + row.CFACECHECKID + "&CheckMethod=" + row.CheckMethod;
                    //alert(urlStr);
                    window.location.href = urlStr;
                }
            });
        });
        function fresh() {
            queryParams.UnitCode = $("#CheckName").val();
            queryParams.date = $("#txtDateFirst").val();
            //queryParams.VehicleModel = $("#VehicleModel").val();
            queryParams.CheckMethod = $("#CheckMethod").val();
            //queryParams.CheckResult = $("#CheckResult").val();
            var CheckMethodValue = $("#CheckMethod").val();
            if (CheckMethodValue == "B") {
                tempcolumns = [
                    { title: 'ASM5025CO', field: 'V1', align: 'center', width: '100', valign: 'middle' },
                    { title: 'ASM2540CO', field: 'V2', align: 'center', width: '100', valign: 'middle' },
                    { title: 'ASM5025HC', field: 'V3', align: 'center', width: '100', valign: 'middle' },
                    { title: 'ASM2540HC', field: 'V4', align: 'center', width: '100', valign: 'middle' },
                    { title: 'ASM5025NO', field: 'V5', align: 'center', width: '100', valign: 'middle' },
                    { title: 'ASM2540NO', field: 'V6', align: 'center', width: '100', valign: 'middle' }
                ];
            } else if (CheckMethodValue=="A") {
                tempcolumns = [
                    { title: '过量空气指数', field: 'V1', align: 'center', width: '100', valign: 'middle' },
                    { title: 'LOWCO', field: 'V2', align: 'center', width: '100', valign: 'middle' },
                    { title: 'LOWHC', field: 'V3', align: 'center', width: '100', valign: 'middle' },
                    { title: 'HIGHCO', field: 'V4', align: 'center', width: '100', valign: 'middle' },
                    { title: 'HIGHHC', field: 'V5', align: 'center', width: '100', valign: 'middle' }
                ];
            } else if (CheckMethodValue=="G"){
                tempcolumns = [
                    { title: 'K100', field: 'V1', align: 'center', width: '100', valign: 'middle' },
                    { title: 'K90', field: 'V2', align: 'center', width: '100', valign: 'middle' },
                    { title: 'K80', field: 'V3', align: 'center', width: '100', valign: 'middle' },
                    { title: 'NPOWER', field: 'V4', align: 'center', width: '100', valign: 'middle' }
                ];
            } else if (CheckMethodValue=="F"){
                tempcolumns = [
                    { title: '第一次', field: 'V1', align: 'center', width: '100', valign: 'middle' },
                    { title: '第二次', field: 'V2', align: 'center', width: '100', valign: 'middle' },
                    { title: '第三次', field: 'V3', align: 'center', width: '100', valign: 'middle' }
                ];
            } else if(CheckMethodValue=="-1"){
                tempcolumns = [
                    { title: '值1', field: 'V1', align: 'center', width: '100', valign: 'middle' },
                    { title: '值2', field: 'V2', align: 'center', width: '100', valign: 'middle' },
                    { title: '值3', field: 'V3', align: 'center', width: '100', valign: 'middle' },
                    { title: '值4', field: 'V4', align: 'center', width: '100', valign: 'middle' },
                    { title: '值5', field: 'V5', align: 'center', width: '100', valign: 'middle' },
                    { title: '值6', field: 'V6', align: 'center', width: '100', valign: 'middle' }
                ];
            } else {
                tempcolumns = [];
            }
            //$('#tabmenu').bootstrapTable('refresh', queryParams);
            columns = somecol.concat(tempcolumns);
            $('#tabmenu').bootstrapTable(
                "refreshOptions",
                {
                    //url: path + "/api/peopledataInfo/getPeopleInfoList", // 获取数据的地址  
                    columns: columns

                }
            );
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
                <a class="navbar-brand" style="font-size: 17px;" href="CarQueryIndex.aspx"><strong><i class="icon fa fa-truck fa-2x"></i></strong></a>

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
                <br />
                <ol class="breadcrumb">
                    <li><a href="#">天津市环保局</a></li>
                </ol>

            </div>
            <div id="page-inner">
                <div class="panel-body">
                    <div style="margin: 0 auto;" class="col-md-12 col-sm-12">
                        <table class="query-table">
                            <tr>
                                <td class="field">检测机构:&nbsp;&nbsp;</td>
                                <td class="content">
                                    <select id="CheckName" style="width: 200px;" class="selectbox">
                                        <option value="-1">全部</option>
                                        <%
                                            System.Data.DataTable AreaDataTable = CarQueryWeb.DB.OracleHelper.ExecuteDataTable(System.Data.CommandType.Text, "SELECT DISTINCT T.COUNTY AREACODE,DATA1.CDATANAME AREANAME FROM TUNIT T,(SELECT NBASEDATAID,CDATANAME FROM TBASEDATA WHERE CDATATYPE='287') DATA1 WHERE DATA1.NBASEDATAID=T.COUNTY");
                                            if (AreaDataTable != null)
                                            {
                                                for (int i = 0; i < AreaDataTable.Rows.Count; i++)
                                                {
                                                    System.Data.DataRow Areadr = AreaDataTable.Rows[i];
                                        %>
                                        <optgroup label="<%=Areadr["AREANAME"] %>">
                                            <%
                                                System.Data.DataTable UnitDataTable = CarQueryWeb.DB.OracleHelper.ExecuteDataTable(System.Data.CommandType.Text, "SELECT T.CUNITCODE UNITCODE,T.CUNITNAME UNITNAME,T.CIPADDRESS IPADDRESS,DATA1.CDATANAME AREANAME FROM TUNIT T,(SELECT NBASEDATAID,CDATANAME FROM TBASEDATA WHERE CDATATYPE='287') DATA1 WHERE DATA1.NBASEDATAID=T.COUNTY AND DATA1.NBASEDATAID='" + Areadr["AREACODE"].ToString() + "'");
                                                if (UnitDataTable != null)
                                                {
                                            %>
                                            <option value="<%=Areadr["AREACODE"] %>"><%=Areadr["AREANAME"] %></option>
                                            <%
                                                for (int j = 0; j < UnitDataTable.Rows.Count; j++)
                                                {
                                                    System.Data.DataRow Unitdr = UnitDataTable.Rows[j];
                                            %>
                                            <option value="<%=Unitdr["UNITCODE"] %>"><%=Unitdr["UNITNAME"] %></option>
                                            <%
                                                    }
                                                }
                                            %>
                                            <%
                                                    }
                                                }

                                            %>
                                        </optgroup>
                                    </select></td>
                               <td class="field">检测日期:&nbsp;&nbsp;</td>
                                <td>
                                    <input type="text" id="txtDateFirst" value="2017-07-09" name="txtDateFirst" onclick="WdatePicker()" /></td>
                                <td class="field">检测方法:&nbsp;&nbsp;</td>
                                <td class="content">
                                    <select id="CheckMethod" class="selectbox">
                                        <option value="-1">全部</option>
                                        <%
                                            System.Data.DataTable CheckMethodDataTable = CarQueryWeb.Common.CommonUtil.GetSelectDataTable("46");
                                            if (CheckMethodDataTable != null)
                                            {
                                                for (int i = 0; i < CheckMethodDataTable.Rows.Count; i++)
                                                {
                                                    System.Data.DataRow CheckMethoddr = CheckMethodDataTable.Rows[i];
                                        %>
                                        <option value="<%=CheckMethoddr["DID"] %>"><%=CheckMethoddr["DNAME"] %></option>
                                        <%
                                                }
                                            }
                                        %>
                                    </select></td>
                                <td>&nbsp;&nbsp;
                                    <button onclick="fresh()" class="btn btn-default">搜 索</button></td>
                            </tr>
                            
                        </table>
                    </div>

                </div>

                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                详细数据
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <%--<iframe name="mainFrame" id="mainFrame" style="width: 100%; height: 1000px;" frameborder="no" border="0" 
                    marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes" src="CheckResult/gasresult.html"></iframe>--%>
                                    <table id="tabmenu"></table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                

                <footer>
                    <p>Copyright &copy; 2016.Company name All rights reserved.环保局检测数据统计</p>
                </footer>
            </div>

            <!-- /. PAGE INNER  -->

        </div>
        <!-- /. PAGE WRAPPER  -->
    </div>

    <script src="js/common.js" type="text/javascript"></script>
</body>
</html>
