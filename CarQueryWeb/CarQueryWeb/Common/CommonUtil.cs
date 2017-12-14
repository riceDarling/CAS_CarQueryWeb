using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Configuration;
using CarQueryWeb.DB;

namespace CarQueryWeb.Common
{
    
    public class CommonUtil
    {
        public static DataTable GetSelectDataTable(String cdatatype)
        {
            String sql = "SELECT DISTINCT NBASEDATAID DID,CDATANAME DNAME FROM TBASEDATA WHERE CDATATYPE='" + cdatatype + "'";
            DataTable db = OracleHelper.ExecuteDataTable(CommandType.Text, sql);
            return db;
        }
        public static String GetValue(String cdatatype, String nbasedataid)
        {
            String result = "";
            String sql = "SELECT CDATANAME FROM TBASEDATA T "
                    + "WHERE T.CDATATYPE='"
                    + cdatatype + "' "
                    + "AND T.NBASEDATAID='"
                    + nbasedataid + "'";
            DataSet ds = OracleHelper.ExecuteDataSet(CommandType.Text, sql);
            if (ds == null)
            {
                return "";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                result = row["CDATANAME"].ToString();
            }
            return result;
        }
        /// <summary>
        /// 获取id对应的值
        /// </summary>
        /// <param name="cdatatype">类型</param>
        /// <param name="nbasedataid">ID</param>
        /// <returns></returns>
        public static String GetName(String cdatatype, String nbasedataid)
        {
            String result = "";
            String sql = "SELECT CDATANAME FROM TBASEDATA T "
                    + "WHERE T.CDATATYPE='"
                    + cdatatype + "' "
                    + "AND T.NBASEDATAID='"
                    + nbasedataid + "'";
            DataSet ds = OracleHelper.ExecuteDataSet(CommandType.Text, sql);
            if (ds == null)
            {
                return "";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                result = row["CDATANAME"].ToString();
            }
            return result;
        }

        /// <summary>
        /// 获取Value对应的id
        /// </summary>
        /// <param name="cdatatype"></param>
        /// <param name="nbasedataid"></param>
        /// <returns></returns>
        public static String GetId(String cdatatype, String cdataname)
        {
            String result = "";
            String sql = "SELECT NBASEDATAID FROM TBASEDATA T "
                    + "WHERE T.CDATATYPE='"
                    + cdatatype + "' "
                    + "AND T.CDATANAME='"
                    + cdataname + "'";
            DataSet ds = OracleHelper.ExecuteDataSet(CommandType.Text, sql);
            if (ds == null)
            {
                return "";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                result = row["NBASEDATAID"].ToString();
            }
            return result;
        }
        /// <summary>
        /// 获取制定类型的所有值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DataSet ReadTBaseData(string type)
        {
            string sqlStr = "select t.nbasedataid,t.cdataname from tbasedata t  where cdatatype='" + type + "' order by t.nbasedataid";
            return OracleHelper.ExecuteDataSet(CommandType.Text, sqlStr); ;
        }
        /// <summary>
        /// 判断值在数据字典中是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Exist(string id, string type)
        {
            string sqlStr = "select count(*) from tbasedata  where cdatatype='" + type + "' and nbasedataid='" + id + "'";
            try
            {
                return Convert.ToInt16(OracleHelper.ExecuteScalar(CommandType.Text, sqlStr)) > 0;
            }
            catch { return false; }
        }
        /// <summary>
        /// 获取序列值
        /// </summary>
        /// <param name="sequenceName"></param>
        /// <returns></returns>
        public static int GetNextValue(string sequenceName)
        {
            try
            {
                return int.Parse(OracleHelper.ExecuteScalar(CommandType.Text,"SELECT " + sequenceName + ".NEXTVAL FROM DUAL").ToString());
                //return _db.ExecuteScaler("SELECT " + sequenceName + ".NEXTVAL FROM DUAL");
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 填充字符串，满足数据库中字符大小
        /// </summary>
        /// <param name="originalString"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static string FullFillString(string originalString, int digit)
        {
            string maxCode = originalString;
            if (maxCode.Length > digit)
            {
                return "null";
            }
            else if (maxCode.Length == digit)
            {
                return maxCode;
            }
            else
            {
                int j = digit - maxCode.Length;
                for (int i = 0; i < j; i++)
                {
                    maxCode = "0" + maxCode;
                }
                return maxCode;
            }

        }
    }
}