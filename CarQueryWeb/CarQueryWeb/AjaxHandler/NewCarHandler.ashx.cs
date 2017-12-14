using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using CarQueryWeb.DB;
using System.Data;
using CarQueryWeb.report;
using CarQueryWeb.Common;

namespace CarQueryWeb.AjaxHandler
{
    /// <summary>
    /// OilHandler 的摘要说明
    /// </summary>
    public class NewCarHandler : IHttpHandler
    {


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        HttpContext Context = null;
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

        public void VINQuery()
        {
            try
            {
                string VIN = HttpUtility.UrlDecode(Context.Request["VIN"]);
                string sqlStr = "SELECT CL.VIN,CL.VEHICLEMODEL,CL.BRAND,CL.QCFL,CX.FUELTYPE,CX.FDJXH,CX.ZDZZL,CX.STANDARD FROM NC_JDCCLXXB CL,NC_JDCCXXXB CX WHERE CL.VEHICLEMODEL=CX.VEHICLEMODEL AND CL.VIN='" + VIN + "'";

                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"totals\":" + ds.Tables[0].Rows.Count + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"totals\":0,\"result\":\"0\"");
                }

                //Context.Response.Write(Failure("无结果，请前往行政许可中心审核"));
            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"totals\":0,\"result\":\"0\"");
            }
            //return result;
        }
        public void VehicleModelQuery()
        {
            try
            {
                string VehicleModel = HttpUtility.UrlDecode(Context.Request["VehicleModel"]);

                string sqlStr = "SELECT CX.FUELTYPE,CX.FDJXH,CX.ZDZZL,CX.STANDARD,CX.VEHICLEMODEL FROM NC_JDCCXXXB CX WHERE CX.VEHICLEMODEL='" + VehicleModel + "'";


                DataSet ds = OracleHelper.ExecuteDataSet(System.Data.CommandType.Text, sqlStr);
                if (ds != null)
                {
                    string result = "0";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = "1";
                    }
                    string json = "{\"rows\":" + JsonHelper.ToJson(ds.Tables[0]) + ",\"totals\":" + ds.Tables[0].Rows.Count + ",\"result\":\"" + result + "\"}";
                    System.Diagnostics.Debug.WriteLine(json);
                    Context.Response.Write(json);
                    //Context.Response.End();
                }
                else
                {
                    Context.Response.Write("{\"rows\":[],\"totals\":0,\"result\":\"0\"");
                }

            }
            catch (Exception e)
            {
                Context.Response.Write("{\"rows\":[],\"totals\":0,\"result\":\"0\"");
            }
            //return result;
        }

        public void VINInsert()
        {
            {
                try
                {
                    string VIN = HttpUtility.UrlDecode(Context.Request["VIN"]);
                    string VehicleKind = HttpUtility.UrlDecode(Context.Request["VehicleKind"]);
                    string VehicleModel = HttpUtility.UrlDecode(Context.Request["VehicleModel"]);
                    string VehicleModelNo = HttpUtility.UrlDecode(Context.Request["VehicleModelNo"]);
                    string User = HttpUtility.UrlDecode(Context.Request["User"]);
                    string Phone = HttpUtility.UrlDecode(Context.Request["Phone"]);
                    string Address = HttpUtility.UrlDecode(Context.Request["Address"]);
                    string USERID = VIN+Common.CommonUtil.FullFillString(Common.CommonUtil.GetNextValue("SEQ_NC_USER_USERID").ToString(),13) ;

                    using (Oracle.ManagedDataAccess.Client.OracleTransaction tran = OracleHelper.GetOracleTransaction(OracleHelper.GetOracleConnection()))
                    {
                        int result = 0;
                        try
                        {
                            string sqlStrVehicle = "INSERT INTO NC_JDCCLXXB(VIN,QCFL,BRAND,VEHICLEMODEL) VALUES('"+VIN+"','"+ VehicleKind + "','"+ VehicleModel + "','"+ VehicleModelNo + "')";
                            result+=OracleHelper.ExecuteNonQuery(tran,CommandType.Text, sqlStrVehicle);
                            string sqlStrUser = "INSERT INTO NC_USER(USERID,USERNAME,PHONE,ADDRESS,VIN,VEHICLEMODEL,\"DATE\",RESULT) VALUES('"+USERID+"','"+User+"','"+Phone+"','"+Address+"','"+VIN+"','"+VehicleModelNo+"',TO_DATE('"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ "','YYYY-MM-DD HH24:MI:SS'),'" + "1"+"')";
                            result+=OracleHelper.ExecuteNonQuery(tran,CommandType.Text, sqlStrUser);
                            tran.Commit();
                            Context.Response.Write(Success("录入成功"));
                        }
                        catch(Exception e)
                        {
                            tran.Rollback();
                            if (result==0)
                            {
                                Context.Response.Write(Failure("车架号已存在"));
                            }
                            else if(result==1)
                            {
                                Context.Response.Write(Failure("用户已存在"));
                            }
                            else
                            {
                                Context.Response.Write(Failure("未知错误"));
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Context.Response.Write(Failure("未知错误！"));
                }
            }
        }
        public void GenerateReprot()
        {
            {
                try
                {
                    string VIN = HttpUtility.UrlDecode(Context.Request["VIN"]);
                    string XXGKBH = HttpUtility.UrlDecode(Context.Request["XXGKBH"]);
                    string str = "SELECT * FROM NC_JDCCLXXB WHERE VIN='"+VIN+"'";
                    DataSet ds= OracleHelper.ExecuteDataSet(CommandType.Text,str);
                    string oldXXGKBH = "";
                    if (ds!=null)
                    {
                        if (ds.Tables[0].Rows.Count>0)
                        {
                            oldXXGKBH = ds.Tables[0].Rows[0]["XXGKBH"].ToString();
                        }
                    }
                    string code = string.IsNullOrEmpty(oldXXGKBH) ? XXGKBH : oldXXGKBH;
                    try
                    {
                        QRCode.CreateCode(code, Context.Server.MapPath("~"));
                    }
                    catch
                    {

                    }


                    if (string.IsNullOrEmpty(oldXXGKBH))
                    {
                        string sqlStr = "UPDATE NC_JDCCLXXB SET XXGKBH='" + XXGKBH + "' WHERE VIN='" + VIN + "'";
                        int result = 0;
                        int.TryParse(OracleHelper.ExecuteNonQuery(CommandType.Text, sqlStr).ToString(), out result);
                        if (result > 0)
                        {
                            Context.Response.Write(Success("生成成功"));
                        }
                        else
                        {
                            Context.Response.Write(Failure("生成失败"));
                        }
                    }
                    else
                    {
                        Context.Response.Write(SuccessHasOld(oldXXGKBH));
                    }
                    
                   
                }
                catch (Exception e)
                {
                    Context.Response.Write(Failure("未知错误！"));
                }
            }
        } public void QueryReport()
        {
            {
                try
                {
                    string VIN = HttpUtility.UrlDecode(Context.Request["VIN"]);
                    string sqlStr = "SELECT XXGKBH FROM NC_JDCCLXXB WHERE VIN='"+VIN+"'";
                    DataTable dt = OracleHelper.ExecuteDataTable(CommandType.Text, sqlStr);
                    if (dt.Rows.Count>0)
                    {
                        Context.Response.Write(Success(dt.Rows[0]["XXGKBH"].ToString()));
                    }
                    else
                    {
                        Context.Response.Write(Failure("无报告单"));
                    }
                   
                }
                catch (Exception e)
                {
                    Context.Response.Write(Failure("未知错误！"));
                }
            }
        }
        public string SuccessHasOld(string str)
        {
            return "{\"code\":\"2\", \"message\":\"" + str + "\"}";
        }
        public string Success(string str)
        {
            return "{\"code\":\"1\", \"message\":\"" + str + "\"}";
        }
        public string Failure(string str)
        {
            return "{\"code\":\"0\", \"message\":\"" + str + "\"}";
        }

    }
}