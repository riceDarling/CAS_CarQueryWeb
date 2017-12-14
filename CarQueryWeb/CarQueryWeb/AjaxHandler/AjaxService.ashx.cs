using CarQueryWeb.MODEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using CarQueryWeb.DB;
using System.Linq;
using System.Reflection;
using System.Web.Services;
using CarQueryWeb;
using CarQueryWeb.Common;
using System.Globalization;
using System.Diagnostics;
using System.Threading;

/// <summary>
/// 此类主要用于存储ajax的请求接口
/// </summary>


namespace CarQueryWeb.AjaxHandler
{

    public class AjaxService : IHttpHandler
    {

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            Context = context;
            Context.Response.ContentType = "text/plain";
            Context.Response.Charset = "utf-8";
            String methodName = context.Request["method"];
            String name = context.Request["name"];
            Type type = this.GetType();
            MethodInfo method = null;
            try { method = type.GetMethod(methodName); } catch { }

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


        /// <summary>
        /// http请求对象
        /// </summary>
        private HttpRequest Request;

        /// <summary>
        /// 用来接收前端请求的对象
        /// </summary>
        private HttpContext Context;
        /// <summary>
        /// 返回给前端的对象
        /// </summary>
        private HttpResponse Response;

        private HttpServerUtility Server;

        /// <summary>
        /// http session对象
        /// </summary>
        private HttpSessionState Session;


        /// <summary>  
        /// json转为对象  
        /// </summary>  
        /// <typeparam name="ObjType"></typeparam>  
        /// <param name="JsonString"></param>  
        /// <returns></returns>  
        public static ObjType JsonStringToObjs<ObjType>(string JsonString) where ObjType : class
        {
            System.Web.Script.Serialization.JavaScriptSerializer jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            ObjType s = jsonSerializer.Deserialize<ObjType>(JsonString);
            return s;
        }


        /// <summary>
        /// json转为集合
        /// </summary>
        /// <typeparam name="ObjType"></typeparam>
        /// <param name="JsonString"></param>
        /// <returns></returns>
        public static List<ObjType> JsonStringToObjList<ObjType>(string JsonString) where ObjType : class
        {
            System.Web.Script.Serialization.JavaScriptSerializer jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<ObjType> s = jsonSerializer.Deserialize<List<ObjType>>(JsonString);
            return s;
        }

        /// <summary>
        /// 更新描点信息
        /// </summary>
        public void UpdateMapData()
        {
            string CUNITCODE = HttpContext.Current.Request["CUNITCODE"];
            string CMEMO = HttpContext.Current.Request["CMEMO"];
            string sql = "UPDATE TUNIT SET CMEMO='" + CMEMO + "' WHERE CUNITCODE='" + CUNITCODE + "'";
            int NUM = OracleHelper.ExecuteNonQuery(CommandType.Text, sql);
            string json = NUM.ToString();
            Context.Response.Write(json);
            
        }


        /// <summary>
        /// 获取检测站信息
        /// </summary>
        public void GetMapData()
        {
            
            string UnitName = HttpContext.Current.Request["CUNITNAME"];
            int pagenumber = 0, pagesize = 0;
            if (!string.IsNullOrEmpty(Context.Request.Form["pagenumber"]) && !string.IsNullOrEmpty(Context.Request.Form["pagesize"]))
            {

                pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                pagesize = int.Parse(Context.Request.Form["pagesize"]);
            }
            string where = "";

           
            if (!string.IsNullOrEmpty(UnitName))
            {
                where += " and CUNITNAME LIKE '%" + UnitName + "%'";
            }
            try
            {
                if ( pagesize == 0)
                {
                    string SQL = "SELECT CUNITCODE,CUNITNAME,ISLOCK,CDIRECTOR,CPHONE,CMEMO FROM TUNIT WHERE 1=1 and CMEMO is not null  ";
                    
                    DataTable dt = OracleHelper.ExecuteDataTable(CommandType.Text, SQL + where);
                    string json = JsonHelper.DataTableToJson(dt);
                    Context.Response.Write(json);
                }
                else
                {
                    string SQL = "SELECT NTEMP.*FROM(SELECT TEMP.*, ROWNUM RN FROM(SELECT * FROM TUNIT WHERE 1=1 " + where + " ORDER BY CUNITCODE) TEMP) NTEMP WHERE NTEMP.RN >= " + (pagenumber * pagesize) + " AND NTEMP.RN <=" + ((pagenumber + 1) * pagesize);
                    string sqlStr1 = " select count(1) from TUNIT ";
                    DataTable dt = OracleHelper.ExecuteDataTable(CommandType.Text, SQL);
                    int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                    string json = "{\"rows\":" + JsonHelper.DataTableToJson(dt) + ",\"total\":" + num + "}";
                    Context.Response.Write(json);
                }
            }
            catch
            {

            }
        }

        /// <summary>  
        /// 对象转为json  
        /// </summary>  
        /// <typeparam name="ObjType"></typeparam>  
        /// <param name="obj"></param>  
        /// <returns></returns>  
        public static string ObjToJsonString<ObjType>(ObjType obj) where ObjType : class
        {
            System.Web.Script.Serialization.JavaScriptSerializer jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string s = jsonSerializer.Serialize(obj);
            return s;
        }
        public void QueryJCZ()
        {
            try
            {
                string sqlStr = " select T.CUNITCODE UNITCODE,T.CUNITNAME UNITNAME,T.COUNTY AREACODE,DATA1.CDATANAME COUNTY from  TUNIT T,(SELECT NBASEDATAID,CDATANAME FROM TBASEDATA WHERE CDATATYPE='287') DATA1 WHERE DATA1.NBASEDATAID=T.COUNTY ";
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                if (ds != null)
                {
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + ds.Tables[0].Rows.Count + "}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0");
            }
        }
        /// <summary>
        /// 获取平台信息
        /// </summary>
        public void GetPingTaiInfo()
        {

            try
            {
                //string sqlStr = " select * from  CHECKRESULT where 1=1 ";
                string sqlStr = "SELECT * FROM (select T1.*,rownum rn from (select t.* from checkresult t where 1=1 ";
                string sqlStr1 = " select count(1) from  CHECKRESULT where 1=1 ";
                string sqlStr2 = " ";
                if (Context.Request.Form["license"] != null && Context.Request.Form["license"] != "")
                {
                    //sqlStr += " and LICENSE = '" + Context.Request.Form["license"] + "' ";
                    sqlStr1 += " and LICENSE = '" + Context.Request.Form["license"] + "' ";
                    sqlStr2 += " and t.LICENSE = '" + Context.Request.Form["license"] + "' ";
                }
                if (Context.Request.Form["checkmethod"] != null && Context.Request.Form["checkmethod"] != "")
                {
                    //sqlStr += " and CHECKMETHOD = '" + Context.Request.Form["checkmethod"] + "' ";
                    sqlStr1 += " and CHECKMETHOD = '" + Context.Request.Form["checkmethod"] + "' ";
                    sqlStr2 += " and t.CHECKMETHOD = '" + Context.Request.Form["checkmethod"] + "' ";
                }
                if (Context.Request.Form["checkresult"] != null && Context.Request.Form["checkresult"] != "")
                {
                    //sqlStr += " and CHECKRESULT='" + Context.Request.Form["checkresult"] + "' ";
                    sqlStr1 += " and CHECKRESULT='" + Context.Request.Form["checkresult"] + "' ";
                    sqlStr2 += " and t.CHECKRESULT='" + Context.Request.Form["checkresult"] + "' ";
                }
                if (Context.Request.Form["UnitName"] != null && Context.Request.Form["UnitName"] != "")
                {
                    if (Context.Request.Form["UnitName"].Length == 3)
                    {
                        //sqlStr += " and UnitCode='" + Context.Request.Form["UnitName"] + "' ";
                        sqlStr1 += " and UnitCode='" + Context.Request.Form["UnitName"] + "' ";
                        sqlStr2 += " and t.UnitCode='" + Context.Request.Form["UnitName"] + "' ";
                    }
                    else
                    {
                        //sqlStr += " and UnitName='" + Context.Request.Form["UnitName"] + "' ";
                        sqlStr1 += " and UnitName='" + Context.Request.Form["UnitName"] + "' ";
                        sqlStr2 += " and t.UnitName='" + Context.Request.Form["UnitName"] + "' ";
                    }

                }
                int pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                int pagesize = int.Parse(Context.Request.Form["pagesize"]);
                sqlStr += sqlStr2 + " order by checkdate desc ) T1) where rn<=" + (pagenumber + 1) * pagesize + " and rn>=" + pagenumber * pagesize;
                //sqlStr += " and ROWNUM<=" + (pagenumber + 1) * pagesize + " MINUS SELECT * FROM CHECKRESULT WHERE ROWNUM<=" + pagenumber * pagesize;
                //sqlStr += sqlStr2;

                if (Context.Request.Form["license"] != null && Context.Request.Form["license"] != "")
                {
                    sqlStr = "SELECT * FROM CHECKRESULT WHERE LICENSE='" + Context.Request.Form["license"] + "'";
                }

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + num + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
            }


        }
        /// <summary>
        /// 公告列表
        /// </summary>
        public void GGLB()
        {
            try
            {
                string sqlStr = " SELECT * from NOTICE where 1=1 ORDER BY STARTDATE DESC";
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                if (ds != null)
                {
                    string json = "";
                    if (ds != null)
                    {
                        json = JsonHelper.DataTableToJson(ds.Tables[0]);
                    }
                    System.Diagnostics.Debug.WriteLine("{\"rows\":[" + json + "],\"totals\":" + 0 + "}");
                    Context.Response.Write("{\"rows\":" + json + ",\"totals\":" + 0 + "}");
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"totals\":0");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"totals\":0");
            }
        }
        public void GetJianCeLiangTongJiShuJu()
        {
            string LastDate = HttpContext.Current.Request["LastDate"];

            string NextDate = HttpContext.Current.Request["NextDate"];
            string UnitCode = HttpContext.Current.Request["UnitCode"];
            string Format = HttpContext.Current.Request["Format"];
            string AreaSql = "SELECT CUNITNAME,CUNITCODE,COUNTY FROM TUNIT WHERE 1=1 ";
            DateTime Last = DateTime.Now;
            DateTime Next = DateTime.Now;
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();

            dtFormat.ShortDatePattern = Format;

            if (!string.IsNullOrEmpty(LastDate))
            {
                Last = Convert.ToDateTime(LastDate, dtFormat);
            }
            else
            {
                Last = Last.AddDays(-1);
            }
            if (!string.IsNullOrEmpty(NextDate))
            {
                Next = Convert.ToDateTime(NextDate, dtFormat);

            }
            else
            {
                Next = Next.AddDays(-1);
            }
            if (!string.IsNullOrEmpty(UnitCode))
            {

                if (UnitCode.Length == 3)
                {
                    AreaSql += " and CUNITCODE='" + UnitCode + "'";

                }
                else if (UnitCode.Length == 6)
                {
                    AreaSql += " and COUNTY='" + UnitCode + "'";
                }

            }
            DataTable AreaDt = OracleHelper.ExecuteDataTable(CommandType.Text, AreaSql);


            string sqlstr = "SELECT COUNT(1) FROM CHECKRESULT where 1=1 ";
            DateTime indexDate = Last;
            List<ReportCheckResult> list = new List<ReportCheckResult>();
            while (string.Compare(indexDate.ToString(Format), Next.ToString(Format)) != 1)
            {
                string dateWhere = " AND SUBSTR(CHECKDATE, 0, " + Format.Length + ")='" + indexDate.ToString(Format) + "'";
                for (int i = 0; i < AreaDt.Rows.Count; i++)
                {
                    ReportCheckResult model = new ReportCheckResult();
                    string where = " AND UnitCode='" + AreaDt.Rows[i]["CUNITCODE"] + "'" + dateWhere;
                    try
                    {


                        //model.CheckCount = Convert.ToInt32(OracleHelper.ExecuteScalar(CommandType.Text, sqlstr + where));
                        //Thread thread1 = new Thread(() =>
                        //{

                        model.Gas1Count = Convert.ToInt32(OracleHelper.ExecuteScalar(CommandType.Text, sqlstr + " AND CHECKMETHOD='B' " + where));
                        //    flag++;
                        //});
                        //thread1.IsBackground = true;
                        //thread1.Start();

                        //Thread thread2 = new Thread(() =>
                        //{
                        model.Gas1OKCount = Convert.ToInt32(OracleHelper.ExecuteScalar(CommandType.Text, sqlstr + " AND CHECKMETHOD='B' AND CHECKRESULT='1' " + where));
                        //    flag++;
                        //});
                        //thread2.IsBackground = true;
                        //thread2.Start();

                        //Thread thread3 = new Thread(() =>
                        //{
                        model.Gas2Count = Convert.ToInt32(OracleHelper.ExecuteScalar(CommandType.Text, sqlstr + " AND CHECKMETHOD='A' " + where));
                        //    flag++;
                        //});
                        //thread3.IsBackground = true;
                        //thread3.Start();


                        //Thread thread4 = new Thread(() =>
                        //{
                        model.Gas2OKCount = Convert.ToInt32(OracleHelper.ExecuteScalar(CommandType.Text, sqlstr + " AND CHECKMETHOD='A' AND CHECKRESULT='1' " + where));
                        //    flag++;
                        //});
                        //thread4.IsBackground = true;
                        //thread4.Start();
                        ////model.GasCount = model.Gas1Count + model.Gas2Count;
                        ////model.GasOKCount = model.Gas1OKCount + model.Gas2OKCount;
                        //Thread thread5 = new Thread(() =>
                        //{
                        model.Diesel1Count = Convert.ToInt32(OracleHelper.ExecuteScalar(CommandType.Text, sqlstr + " AND CHECKMETHOD='G' " + where));
                        //    flag++;
                        //});
                        //thread5.IsBackground = true;
                        //thread5.Start();


                        //Thread thread6 = new Thread(() =>
                        //{
                        model.Diesel1OKCount = Convert.ToInt32(OracleHelper.ExecuteScalar(CommandType.Text, sqlstr + " AND CHECKMETHOD='G' AND CHECKRESULT='1' " + where));
                        //    flag++;
                        //});
                        //thread6.IsBackground = true;
                        //thread6.Start();

                        //Thread thread7 = new Thread(() =>
                        //{
                        model.Diesel2Count = Convert.ToInt32(OracleHelper.ExecuteScalar(CommandType.Text, sqlstr + " AND CHECKMETHOD='F' " + where));
                        //    flag++;
                        //});
                        //thread7.IsBackground = true;
                        //thread7.Start();

                        //Thread thread8 = new Thread(() =>
                        //{
                        model.Diesel2OKCount = Convert.ToInt32(OracleHelper.ExecuteScalar(CommandType.Text, sqlstr + " AND CHECKMETHOD='F' AND CHECKRESULT='1' " + where));
                        //    flag++;
                        //});
                        //thread8.IsBackground = true;
                        //thread8.Start();
                        //model.DieselCount = model.Diesel1Count + model.Diesel2Count;
                        //model.DieselOKCount = model.Diesel1OKCount + model.Diesel2OKCount;


                        model.CheckDate = indexDate.ToString(Format);
                        model.AreaCode = AreaDt.Rows[i]["COUNTY"].ToString();
                        model.UnitName = AreaDt.Rows[i]["CUNITNAME"].ToString();
                        Debug.WriteLine(i);
                        list.Add(model);


                    }
                    catch (Exception E)
                    {

                    }


                }
                if (Format.Length == 4)
                {
                    indexDate = indexDate.AddYears(1);
                }
                else if (Format.Length == 7)
                {
                    indexDate = indexDate.AddMonths(1);
                }
                else if (Format.Length == 10)
                {
                    indexDate = indexDate.AddDays(1);

                }


            }

            ReportCheckResultALL all = new ReportCheckResultALL();
            all.rows = list;
            all.total = list.Count;
            string json = JsonHelper.JsonSerializer<ReportCheckResultALL>(all);
            Context.Response.Write(json);

        }
        public void GetChartData()
        {
            int gas1all = 0;
            int gas1ok = 0;
            int gas2all = 0;
            int gas2ok = 0;
            int diesel1all = 0;
            int diesel1ok = 0;
            int diesel2all = 0;
            int diesel2ok = 0;
            try
            {
                string lastdate = HttpContext.Current.Request["lastdate"];
                string nextdate = HttpContext.Current.Request["nextdate"];
                string UnitCode = HttpContext.Current.Request["UnitCode"];
                string sqlgas1 = " and CheckMethod='B'";
                string sqlgas2 = " and CheckMethod='A'";
                string sqldiesel1 = " and CheckMethod='G'";
                string sqldiesel2 = " and CheckMethod='F'";
                string sqlstr = "SELECT CHECKRESULT FROM CHECKRESULT where 1=1 ";
                string temp = " and checkdate>='" + lastdate + " 00:00:00" + "' and checkdate<= '" + nextdate + " 23:59:59'";
                if (!string.IsNullOrEmpty(UnitCode))
                {

                    if (UnitCode.Length == 3)
                    {
                        temp += " and UnitCode='" + UnitCode + "'";
                    }
                    else if (UnitCode.Length == 6)
                    {
                        temp += " and AreaCode='" + UnitCode + "'";
                    }


                }
                ArrayList dsgas1 = OracleHelper.GetAllData(sqlstr + sqlgas1 + temp);
                ArrayList dsgas2 = OracleHelper.GetAllData(sqlstr + sqlgas2 + temp);
                ArrayList dsdiesel1 = OracleHelper.GetAllData(sqlstr + sqldiesel1 + temp);
                ArrayList dsdiesel2 = OracleHelper.GetAllData(sqlstr + sqldiesel2 + temp);
                for (int i = 0; i < dsgas1.Count; i++)
                {
                    gas1all++;
                    Dictionary<String, String> result = (Dictionary<String, String>)dsgas1[i];
                    string value = "";
                    result.TryGetValue("CHECKRESULT", out value);
                    if (value.Equals("1"))
                    {
                        gas1ok++;
                    }
                }

                for (int i = 0; i < dsgas2.Count; i++)
                {
                    gas2all++;
                    Dictionary<String, String> result = (Dictionary<String, String>)dsgas2[i];
                    string value = "";
                    result.TryGetValue("CHECKRESULT", out value);
                    if (value.Equals("1"))
                    {
                        gas2ok++;
                    }
                }

                for (int i = 0; i < dsdiesel1.Count; i++)
                {
                    diesel1all++;
                    Dictionary<String, String> result = (Dictionary<String, String>)dsdiesel1[i];
                    string value = "";
                    result.TryGetValue("CHECKRESULT", out value);
                    if (value.Equals("1"))
                    {
                        diesel1ok++;
                    }
                }

                for (int i = 0; i < dsdiesel2.Count; i++)
                {
                    diesel2all++;
                    Dictionary<String, String> result = (Dictionary<String, String>)dsdiesel2[i];
                    string value = "";
                    result.TryGetValue("CHECKRESULT", out value);
                    if (value.Equals("1"))
                    {
                        diesel2ok++;
                    }
                }
                string aaa = " {\"gas1ok\": \"" + gas1ok + "\" ,\"gas1all\": \"" + gas1all + "\",\"gas2ok\": \"" + gas2ok + "\" ,\"gas2all\": \"" + gas2all + "\", \"diesel1all\": \"" + diesel1all + "\" ,\"diesel1ok\": \"" + diesel1ok + "\", \"diesel2all\": \"" + diesel2all + "\" ,\"diesel2ok\": \"" + diesel2ok + "\"}";
                Context.Response.Write(aaa);
            }
            catch (Exception e)
            {
                string aaa = " {\"gas1ok\": \"" + gas1ok + "\" ,\"gas1all\": \"" + gas1all + "\",\"gas2ok\": \"" + gas2ok + "\" ,\"gas2all\": \"" + gas2all + "\", \"diesel1all\": \"" + diesel1all + "\" ,\"diesel1ok\": \"" + diesel1ok + "\", \"diesel2all\": \"" + diesel2all + "\" ,\"diesel2ok\": \"" + diesel2ok + "\"}";

                Context.Response.Write(aaa);
            }
        }

        /// <summary>
        /// 获取数据反控信息
        /// </summary>
        public void GetShuJuFanKongInfo()
        {
            try
            {
                string sqlStr = " select * from  TUNIT where 1=1 ";
                string sqlStr1 = " select count(1) from  TUNIT where 1=1 ";
                string sqlStr2 = "";
                if (Context.Request.Form["cunitname"] != null && Context.Request.Form["cunitname"] != "")
                {
                    sqlStr += " and CUNITNAME = '" + Context.Request.Form["cunitname"] + "' ";
                    sqlStr1 += " and CUNITNAME = '" + Context.Request.Form["cunitname"] + "' ";
                    sqlStr2 += " and CUNITNAME = '" + Context.Request.Form["cunitname"] + "' ";
                }
                if (Context.Request.Form["UnitName"] != null && Context.Request.Form["UnitName"] != "")
                {
                    sqlStr += " and COUNTY = '" + Context.Request.Form["UnitName"] + "' ";
                    sqlStr1 += " and COUNTY = '" + Context.Request.Form["UnitName"] + "' ";
                    sqlStr2 += " and COUNTY = '" + Context.Request.Form["UnitName"] + "' ";
                }
                int pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                int pagesize = int.Parse(Context.Request.Form["pagesize"]);
                sqlStr += " and ROWNUM<=" + (pagenumber + 1) * pagesize + " MINUS SELECT * FROM TUNIT WHERE ROWNUM<=" + pagenumber * pagesize;
                sqlStr += sqlStr2;

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + num + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
            }
        }

        public void GetUser()
        {
            try
            {
                string sqlStr = " select * from  PT_USER where 1=1 ";

                string sqlStr2 = "";
                if (Context.Request.Form["name"] != null && Context.Request.Form["name"] != "")
                {
                    sqlStr += " and ID = '" + Context.Request.Form["name"] + "' ";

                    sqlStr2 += " and ID = '" + Context.Request.Form["name"] + "' ";
                }

                sqlStr += sqlStr2;

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                if (ds != null)
                {

                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + ds.Tables[0].Rows.Count + "}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0");
            }
        }
        /// <summary>
        /// 获取油汽分析信息
        /// </summary>
        public void YouQiFenXi()
        {
            try
            {
                string sqlStr = " select * from  JYQB where 1=1 ";
                string sqlStr1 = " select count(1) from  JYQB where 1=1 ";
                string sqlStr2 = "";
                if (Context.Request.Form["jyz"] != null && Context.Request.Form["jyz"] != "")
                {
                    sqlStr += " and JYZ = '" + Context.Request.Form["jyz"] + "' ";
                    sqlStr1 += " and JYZ = '" + Context.Request.Form["jyz"] + "' ";
                    sqlStr2 += " and JYZ = '" + Context.Request.Form["jyz"] + "' ";
                }

                int pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                int pagesize = int.Parse(Context.Request.Form["pagesize"]);
                sqlStr += " and ROWNUM<=" + (pagenumber + 1) * pagesize + " MINUS SELECT * FROM JYQB WHERE ROWNUM<=" + pagenumber * pagesize;
                sqlStr += sqlStr2;

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + num + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
            }
        }



        /// <summary>
        /// 获取车辆分析信息
        /// </summary>
        public void CheLiangFenXi()
        {
            try
            {
                string sqlStr = " select t.*,to_char(t.DREGISTER,'yyyy-mm-dd')  DREGISTERSS from  TVEHICLE t where 1=1 ";
                string sqlStr1 = " select count(1) from  TVEHICLE t where 1=1 ";
                string sqlStr2 = "";
                if (Context.Request.Form["CNUMBERPLATE"] != null && Context.Request.Form["CNUMBERPLATE"] != "")
                {
                    sqlStr += " and t.CNUMBERPLATE = '" + Context.Request.Form["CNUMBERPLATE"] + "' ";
                    sqlStr1 += " and t.CNUMBERPLATE = '" + Context.Request.Form["CNUMBERPLATE"] + "' ";
                    sqlStr2 += " and tt.CNUMBERPLATE = '" + Context.Request.Form["CNUMBERPLATE"] + "' ";
                }
                if (Context.Request.Form["CFUELTYPE"] != null && Context.Request.Form["CFUELTYPE"] != "")
                {
                    sqlStr += " and t.CFUELTYPE = '" + Context.Request.Form["CFUELTYPE"] + "' ";
                    sqlStr1 += " and t.CFUELTYPE = '" + Context.Request.Form["CFUELTYPE"] + "' ";
                    sqlStr2 += " and tt.CFUELTYPE = '" + Context.Request.Form["CFUELTYPE"] + "' ";
                }

                int pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                int pagesize = int.Parse(Context.Request.Form["pagesize"]);
                sqlStr += " and ROWNUM<=" + (pagenumber + 1) * pagesize + " MINUS SELECT tt.*,to_char(tt.DREGISTER,'yyyy-mm-dd,hh24:mi:ss') DREGISTERSS FROM TVEHICLE tt WHERE ROWNUM<=" + pagenumber * pagesize;
                sqlStr += sqlStr2;

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + num + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
            }
        }

        /// <summary>
        /// 获取新车分析信息
        /// </summary>
        public void XinCheFenXi()
        {
            try
            {
                string sqlStr = " SELECT CL.VIN,CL.XXGKBH,CL.VEHICLEMODEL,CX.FDJXH,CX.SB,CX.ZDZZL FROM NC_JDCCLXXB CL,NC_JDCCXXXB CX WHERE CX.VEHICLEMODEL=CL.VEHICLEMODEL ";
                string sqlStr1 = " select count(1) from  NC_JDCCLXXB  where 1=1 ";
                string sqlStr2 = "";
                if (Context.Request.Form["VIN"] != null && Context.Request.Form["VIN"] != "")
                {
                    sqlStr += " and VIN = '" + Context.Request.Form["VIN"] + "' ";
                    sqlStr1 += " and VIN = '" + Context.Request.Form["VIN"] + "' ";
                    sqlStr2 += " and VIN = '" + Context.Request.Form["VIN"] + "' ";
                }


                int pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                int pagesize = int.Parse(Context.Request.Form["pagesize"]);
                sqlStr += " and ROWNUM<=" + (pagenumber + 1) * pagesize + " MINUS SELECT CL.VIN,CL.XXGKBH,CL.VEHICLEMODEL,CX.FDJXH,CX.SB,CX.ZDZZL FROM NC_JDCCLXXB CL,NC_JDCCXXXB CX WHERE CX.VEHICLEMODEL=CL.VEHICLEMODEL AND ROWNUM<=" + pagenumber * pagesize;
                sqlStr += sqlStr2;

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + num + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
            }
        }

        /// <summary>
        /// 车辆维护
        /// </summary>
        public void GetVehicle()
        {
            try
            {
                string sqlStr = " select * from  TVEHICLE where 1=1 ";
                string sqlStr1 = " select count(1) from  TVEHICLE where 1=1 ";
                string sqlStr2 = "";
                if (Context.Request.Form["CNUMBERPLATE"] != null && Context.Request.Form["CNUMBERPLATE"] != "")
                {
                    sqlStr += " and CNUMBERPLATE = '" + Context.Request.Form["CNUMBERPLATE"] + "' ";
                    sqlStr1 += " and CNUMBERPLATE = '" + Context.Request.Form["CNUMBERPLATE"] + "' ";
                    sqlStr2 += " and CNUMBERPLATE = '" + Context.Request.Form["CNUMBERPLATE"] + "' ";
                }


                int pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                int pagesize = int.Parse(Context.Request.Form["pagesize"]);
                sqlStr += " and ROWNUM<=" + (pagenumber + 1) * pagesize + " MINUS SELECT * FROM TVEHICLE WHERE ROWNUM<=" + pagenumber * pagesize;
                sqlStr += sqlStr2;

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + num + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
            }
        }



        public void GetDataBase()
        {
            try
            {
                string sqlStr = " select * from  TBASEDATA where 1=1 ";
                string sqlStr1 = " select count(1) from  TBASEDATA where 1=1 ";
                string sqlStr2 = "";
                if (Context.Request.Form["NBASEDATAID"] != null && Context.Request.Form["NBASEDATAID"] != "")
                {
                    sqlStr += " and NBASEDATAID = '" + Context.Request.Form["NBASEDATAID"] + "' ";
                    sqlStr1 += " and NBASEDATAID = '" + Context.Request.Form["NBASEDATAID"] + "' ";
                    sqlStr2 += " and NBASEDATAID = '" + Context.Request.Form["NBASEDATAID"] + "' ";
                }
                if (Context.Request.Form["CDATATYPE"] != null && Context.Request.Form["CDATATYPE"] != "")
                {
                    sqlStr += " and CDATATYPE = '" + Context.Request.Form["CDATATYPE"] + "' ";
                    sqlStr1 += " and CDATATYPE = '" + Context.Request.Form["CDATATYPE"] + "' ";
                    sqlStr2 += " and CDATATYPE = '" + Context.Request.Form["CDATATYPE"] + "' ";
                }

                int pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                int pagesize = int.Parse(Context.Request.Form["pagesize"]);
                sqlStr += " and ROWNUM<=" + (pagenumber + 1) * pagesize + " MINUS SELECT * FROM TBASEDATA WHERE ROWNUM<=" + pagenumber * pagesize;
                sqlStr += sqlStr2;

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + num + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
            }
        }
        public void GetCheXing()
        {
            try
            {
                string sqlStr = " select * from  TVEHICLEMODEL where 1=1 ";
                string sqlStr1 = " select count(1) from  TVEHICLEMODEL where 1=1 ";
                string sqlStr2 = "";
                if (Context.Request.Form["CNAME"] != null && Context.Request.Form["CNAME"] != "")
                {
                    sqlStr += " and CNAME = '" + Context.Request.Form["CNAME"] + "' ";
                    sqlStr1 += " and CNAME = '" + Context.Request.Form["CNAME"] + "' ";
                    sqlStr2 += " and CNAME = '" + Context.Request.Form["CNAME"] + "' ";

                    if (Context.Request.Form["VEHICLEMODEL"] != null && Context.Request.Form["VEHICLEMODEL"] != "")
                    {
                        sqlStr += " and NVEHICLEMODELID = '" + Context.Request.Form["CNAME"] + Context.Request.Form["VEHICLEMODEL"] + "' ";
                        sqlStr1 += " and NVEHICLEMODELID = '" + Context.Request.Form["CNAME"] + Context.Request.Form["VEHICLEMODEL"] + "' ";
                        sqlStr2 += " and NVEHICLEMODELID = '" + Context.Request.Form["CNAME"] + Context.Request.Form["VEHICLEMODEL"] + "' ";
                    }
                }


                int pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                int pagesize = int.Parse(Context.Request.Form["pagesize"]);
                sqlStr += " and ROWNUM<=" + (pagenumber + 1) * pagesize + " MINUS SELECT * FROM TVEHICLEMODEL WHERE ROWNUM<=" + pagenumber * pagesize;
                sqlStr += sqlStr2;

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + num + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
            }
        }

        public void YaoGanFenXi()
        {
            try
            {
                string sqlStr = " select * from  MOVEENFORCE where 1=1 ";
                string sqlStr1 = " select count(1) from  MOVEENFORCE where 1=1 ";
                string sqlStr2 = "";
                if (Context.Request.Form["CNUMBERPLATE"] != null && Context.Request.Form["CNUMBERPLATE"] != "")
                {
                    sqlStr += " and CNUMBERPLATE = '" + Context.Request.Form["CNUMBERPLATE"] + "' ";
                    sqlStr1 += " and CNUMBERPLATE = '" + Context.Request.Form["CNUMBERPLATE"] + "' ";
                    sqlStr2 += " and CNUMBERPLATE = '" + Context.Request.Form["CNUMBERPLATE"] + "' ";
                }
                if (Context.Request.Form["CPLATETYPE"] != null && Context.Request.Form["CPLATETYPE"] != "")
                {
                    sqlStr += " and CPLATETYPE = '" + Context.Request.Form["CPLATETYPE"] + "' ";
                    sqlStr1 += " and CPLATETYPE = '" + Context.Request.Form["CPLATETYPE"] + "' ";
                    sqlStr2 += " and CPLATETYPE = '" + Context.Request.Form["CPLATETYPE"] + "' ";
                }
                if (Context.Request.Form["CHECKADDRESS"] != null && Context.Request.Form["CHECKADDRESS"] != "")
                {
                    sqlStr += " and CHECKADDRESS LIKE  '%" + Context.Request.Form["CHECKADDRESS"] + "%' ";
                    sqlStr1 += " and CHECKADDRESS LIKE '%" + Context.Request.Form["CHECKADDRESS"] + "%' ";
                    sqlStr2 += " and CHECKADDRESS LIKE '%" + Context.Request.Form["CHECKADDRESS"] + "%' ";
                }
                if (Context.Request.Form["CHECKTIME"] != null && Context.Request.Form["CHECKTIME"] != "")
                {
                    sqlStr += " and TO_CHAR(CHECKTIME,'YYYY-MM-DD') = '" + Context.Request.Form["CHECKTIME"] + "' ";
                    sqlStr1 += " and TO_CHAR(CHECKTIME,'YYYY-MM-DD') = '" + Context.Request.Form["CHECKTIME"] + "' ";
                    sqlStr2 += " and TO_CHAR(CHECKTIME,'YYYY-MM-DD') = '" + Context.Request.Form["CHECKTIME"] + "' ";
                }
                if (Context.Request.Form["EXESTANDARD"] != null && Context.Request.Form["EXESTANDARD"] != "")
                {
                    sqlStr += " and EXESTANDARD = '" + Context.Request.Form["EXESTANDARD"] + "' ";
                    sqlStr1 += " and EXESTANDARD = '" + Context.Request.Form["EXESTANDARD"] + "' ";
                    sqlStr2 += " and EXESTANDARD = '" + Context.Request.Form["EXESTANDARD"] + "' ";
                }
                if (Context.Request.Form["RESULTEVALUATE"] != null && Context.Request.Form["RESULTEVALUATE"] != "")
                {
                    sqlStr += " and RESULTEVALUATE = '" + Context.Request.Form["RESULTEVALUATE"] + "' ";
                    sqlStr1 += " and RESULTEVALUATE = '" + Context.Request.Form["RESULTEVALUATE"] + "' ";
                    sqlStr2 += " and RESULTEVALUATE = '" + Context.Request.Form["RESULTEVALUATE"] + "' ";
                }

                int pagenumber = int.Parse(Context.Request.Form["pagenumber"]) - 1;
                int pagesize = int.Parse(Context.Request.Form["pagesize"]);
                sqlStr += " and ROWNUM<=" + (pagenumber + 1) * pagesize + " MINUS SELECT * FROM MOVEENFORCE WHERE ROWNUM<=" + pagenumber * pagesize;
                sqlStr += sqlStr2;

                //DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT * FROM ("+sqlStr+") ORDER BY CHECKDATE DESC");
                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                int num = Convert.ToInt32(OracleHelper.ExecuteScalar(System.Data.CommandType.Text, sqlStr1));
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"total\":" + num + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
                }
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"total\":0,\"result\":\"0\"");
            }
        }



    }
}