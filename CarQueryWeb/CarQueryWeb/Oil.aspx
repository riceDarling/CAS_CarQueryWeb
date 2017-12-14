<%@ Page Language="C#" AutoEventWireup="true"  Inherits="CarQueryWeb.Oil" %>

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


    <script type="text/javascript">
        var queryParams = {
        };
        var JyqbQueryParams = {

        };
        $(document).ready(function () {
            var height = 300;
            $('#tabJyqb').bootstrapTable({
                url: 'CarQueryIndex.aspx/QueryJyqb',
                method: 'post',      //请求方式（*）  
                striped: true,      //是否显示行间隔色  
                cache: false,      //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）  
                pagination: false,     //是否显示分页（*）  
                sortable: false,      //是否启用排序  
                sortOrder: "asc",     //排序方式  
                queryParams: JyqbQueryParams,//传递参数（*）  
                pageNumber: 1,      //初始化加载第一页，默认第一页  
                pageSize: 20,      //每页的记录行数（*）  
                pageList: [20, 40, 60, 100],  //可供选择的每页的行数（*）  
                singleSelect: false,
                //search: true,      //是否显示表格搜索，此搜索是员工端搜索，不会进服务端  
                //strictSearch: true,  
                //showRefresh: true,     //是否显示刷新按钮  
                minimumCountColumns: 2,    //最少允许的列数  
                //clickToSelect: true,    //是否启用点击选中行  
                uniqueId: "",      //每一行的唯一标识，一般为主键列  
                //showToggle:false,     //是否显示详细视图和列表视图的切换按钮  
                height: height,
                columns: [
                    { title: '加油站名称 ', field: 'JYZ', align: 'center', width: '200', valign: 'middle' },
                    { title: '数据类型 ', field: 'SJLX', align: 'center', width: '100', valign: 'middle' },
                    { title: '检测时间', field: 'JCSJ', align: 'center', width: '200', valign: 'middle' },
                    { title: '加油机标识 ', field: 'JYJBS', align: 'center', width: '100', valign: 'middle' },
                    { title: '加油枪标识', field: 'JYQBS', align: 'center', width: '100', valign: 'middle'},
                    {    title: '气液比', field: 'QYB', align: 'center', width: '100', valign: 'middle'},
                    {   title: '油气流速', field: 'YQLS', align: 'center', width: '100', valign: 'middle'},
                    { title: '油气流量', field: 'YQLL', align: 'center', width: '100', valign: 'middle' },
                    { title: '燃油流速', field: 'RYLS', align: 'center', width: '100', valign: 'middle' }, 
                    { title: '加油流量', field: 'JYLL', align: 'center', width: '100', valign: 'middle' }, 
                    { title: '回收油气浓度', field: 'HSYQND', align: 'center', width: '100', valign: 'middle' }, 
                    { title: '回收油气温度', field: 'YQWDHSYQWD', align: 'center', width: '100', valign: 'middle' }
                    //, formatter: function (value, rowData, rowIndex) {}
                ],
                // sidePagination: "server", //服务端处理分页
                onLoadSuccess: function (rows) {  //加载成功时执行  
                    console.log(rows.d);
                    var result = eval("(" + rows.d + ")");
                    console.log(result);
                    $('#tabJyqb').bootstrapTable('load', result.rows);
                },
                onClickRow: function (row) {
                }
            });
            $('#tabBjb').bootstrapTable({
                url: 'CarQueryIndex.aspx/QueryBjb',
                method: 'post',      //请求方式（*）  
                striped: true,      //是否显示行间隔色  
                cache: false,      //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）  
                pagination: false,     //是否显示分页（*）  
                sortable: false,      //是否启用排序  
                sortOrder: "asc",     //排序方式  
                queryParams: queryParams,//传递参数（*）  
                pageNumber: 1,      //初始化加载第一页，默认第一页  
                pageSize: 20,      //每页的记录行数（*）  
                pageList: [20, 40, 60, 100],  //可供选择的每页的行数（*）  
                singleSelect: false,
                //search: true,      //是否显示表格搜索，此搜索是员工端搜索，不会进服务端  
                //strictSearch: true,  
                //showRefresh: true,     //是否显示刷新按钮  
                minimumCountColumns: 2,    //最少允许的列数  
                //clickToSelect: true,    //是否启用点击选中行  
                uniqueId: "",      //每一行的唯一标识，一般为主键列  
                //showToggle:false,     //是否显示详细视图和列表视图的切换按钮  
                height: height,
                columns: [
                    { title: '加油站名称 ', field: 'JYZMC', align: 'center', width: '200', valign: 'middle' },
                    { title: '检测时间 ', field: 'DATE', align: 'center', width: '200', valign: 'middle' },
                    { title: '报警类型', field: 'BJLX', align: 'center', width: '200', valign: 'middle' },
                    { title: '报警数据 ', field: 'BJSJ', align: 'center', width: '200', valign: 'middle' }
                    //, formatter: function (value, rowData, rowIndex) {}
                ],
                // sidePagination: "server", //服务端处理分页
                onLoadSuccess: function (rows) {  //加载成功时执行  
                    console.log(rows.d);
                    var result = eval("(" + rows.d + ")");
                    console.log(result);
                    $('#tabBjb').bootstrapTable('load', result.rows);
                },
                onClickRow: function (row) {
                }
            });
            $('#tabHjb').bootstrapTable({
                url: 'CarQueryIndex.aspx/QueryHjb',
                method: 'post',      //请求方式（*）  
                striped: true,      //是否显示行间隔色  
                cache: false,      //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）  
                pagination: false,     //是否显示分页（*）  
                sortable: false,      //是否启用排序  
                sortOrder: "asc",     //排序方式  
                queryParams: queryParams,//传递参数（*）  
                pageNumber: 1,      //初始化加载第一页，默认第一页  
                pageSize: 20,      //每页的记录行数（*）  
                pageList: [20, 40, 60, 100],  //可供选择的每页的行数（*）  
                singleSelect: false,
                //search: true,      //是否显示表格搜索，此搜索是员工端搜索，不会进服务端  
                //strictSearch: true,  
                //showRefresh: true,     //是否显示刷新按钮  
                minimumCountColumns: 2,    //最少允许的列数  
                //clickToSelect: true,    //是否启用点击选中行  
                uniqueId: "",      //每一行的唯一标识，一般为主键列  
                //showToggle:false,     //是否显示详细视图和列表视图的切换按钮  
                height: height,
                columns: [
                    { title: '加油站名称 ', field: 'JYZMC', align: 'center', width: '200', valign: 'middle' },
                    { title: '检测时间 ', field: 'JCSJ', align: 'center', width: '200', valign: 'middle' },
                    { title: '变量类型', field: 'BLLX', align: 'center', width: '200', valign: 'middle' },
                    { title: '数值 ', field: 'SZ', align: 'center', width: '200', valign: 'middle' }
                    //, formatter: function (value, rowData, rowIndex) {}
                ],
                // sidePagination: "server", //服务端处理分页
                onLoadSuccess: function (rows) {  //加载成功时执行  
                    console.log(rows.d);
                    var result = eval("(" + rows.d + ")");
                    console.log(result);
                    $('#tabHjb').bootstrapTable('load', result.rows);
                },
                onClickRow: function (row) {
                }
            });
        });

        function fresh() {
            JyqbQueryParams.date = $("#txtDateFirst").val();
            JyqbQueryParams.CheckName = $("#CheckName").val();
            JyqbQueryParams.JYQBS = $("#JYQBS").val();
            JyqbQueryParams.JYJBS = $("#JYJBS").val();
            queryParams.date = $("#txtDateFirst").val();
            queryParams.CheckName = $("#CheckName").val();
            $('#tabJyqb').bootstrapTable('refresh');

            $('#tabBjb').bootstrapTable('refresh');

            $('#tabHjb').bootstrapTable('refresh');
        }

    </script>
    <script src="js/DatePicker/WdatePicker.js"></script>

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
                    天津市加油站油气回收查询系统
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
                                <td class="field">加油站名称:&nbsp;&nbsp;</td>
                                <td class="content">
                                    <select id="CheckName" style="width: 200px;" class="selectbox">
                                        <option value="-1">全部</option>
                                        <%System.Data.DataSet dqDs = CarQueryWeb.DB.OracleHelper.ExecuteDataSet(System.Data.CommandType.Text,"SELECT DISTINCT DQ FROM JYZ_UNIT");
                                            if (dqDs!=null)
                                            {
                                                if (dqDs.Tables[0].Rows.Count>0)
                                                {
                                                    for (int i = 0; i < dqDs.Tables[0].Rows.Count; i++)
                                                    {
                                                        System.Data.DataRow dqDr = dqDs.Tables[0].Rows[i];
                                                        %>
                                        <optgroup label="<%=dqDr["DQ"] %>">
                                            <%
                                        System.Data.DataSet jyZDs = CarQueryWeb.DB.OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT DQ,JYZMC FROM JYZ_UNIT WHERE DQ='"+dqDr["DQ"]+"'");
                                        if (jyZDs != null)
                                        {
                                            if (jyZDs.Tables[0].Rows.Count > 0)
                                            {
                                                for (int j = 0; j < jyZDs.Tables[0].Rows.Count; j++)
                                                {
                                                    System.Data.DataRow jyZDr = jyZDs.Tables[0].Rows[j];
                                                            %>
                                            <option value="<%=jyZDr["JYZMC"] %>"><%=jyZDr["JYZMC"] %></option>
                                            <%
                                                }
                                            }
                                        }

                                                %>
                                        </optgroup>
                                        <%
                                                    }

                                                }
                                            }
                                            %>
                                        
                                        
                                    </select></td>
                                <td class="field">加油机标识:&nbsp;&nbsp;</td>
                                <td class="content">
                                    <select id="JYJBS" class="selectbox">
                                        <option value="-1">全部</option>
                                        <option value="0001">0001</option>
                                        <option value="0002">0002</option>
                                        <option value="0003">0003</option>
                                    </select></td>
                                <td class="field">是否报警:&nbsp;&nbsp;</td>
                                <td class="content">
                                    <select id="CheckMethod" class="selectbox">
                                        <option value="-1">全部</option>
                                        <option value="1">是</option>
                                        <option value="0">否</option>

                                    </select></td>
                                <td>&nbsp;&nbsp;
                                    <button onclick="fresh()" class="btn btn-default">查 询</button></td>
                            </tr>
                            <tr>
                                <td class="field">检测日期:&nbsp;&nbsp;</td>
                                <td>
                                    <input type="text" id="txtDateFirst" value="2017-10-16" name="txtDateFirst" onclick="WdatePicker()" /></td>
                                <td class="field">加油枪型号:&nbsp;&nbsp;</td>
                                <td class="content">
                                    <select id="JYQBS" class="selectbox">
                                        <option value="-1">全部</option>
                                        <option value="0001">0001</option>
                                        <option value="0002">0002</option>
                                        <option value="0003">0003</option>
                                    </select>
                                </td>
                                <td class="field">是否故障:&nbsp;&nbsp;</td>
                                <td class="content">
                                    <select id="zzz" class="selectbox">
                                        <option value="-1">全部</option>
                                        <option value="1">是</option>
                                        <option value="0">否</option>
                                    </select>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>

                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                加油枪数据
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="tabJyqb"></table>
                                </div>
                            </div>
                            <div class="panel-heading">
                                报警数据
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="tabBjb"></table>
                                </div>
                            </div>
                            <div class="panel-heading">
                                环境数据
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="tabHjb"></table>
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
