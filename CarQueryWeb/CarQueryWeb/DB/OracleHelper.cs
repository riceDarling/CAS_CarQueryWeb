using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CarQueryWeb.DB
{
    public class OracleHelper
    {
        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 协议：默认TCP
        /// </summary>
        public static string PROTOCOL = "TCP";
        /// <summary>
        /// 主机地址：默认171.0.0.132
        /// </summary>
        public static readonly string HOST = System.Configuration.ConfigurationManager.ConnectionStrings["XEBusiness"].ConnectionString;
        /// <summary>
        /// 端口号：默认1521
        /// </summary>
        public static string PORT = "1521";
        /// <summary>
        /// TNS服务名：默认TESTDB
        /// </summary>
        public static string SERVICE_NAME = "XE";
        /// <summary>
        /// 用户名：默认NQ_MON
        /// </summary>
        public static string USER_ID = "business";
        /// <summary>
        /// 密码：默认NQ_MON
        /// </summary>
        public static string PASSWORD = "hbjjdczxbusiness";

        /// <summary>
        /// 初始化工具类中各项属性
        /// </summary>
        /// <param name="PTC">协议：默认TCP</param>
        /// <param name="HST">主机地址：默认171.0.0.132</param>
        /// <param name="PRT">端口号：默认1521</param>
        /// <param name="SRV">TNS服务名：默认TESTDB</param>
        /// <param name="UID">用户名：默认NQ_MON</param>
        /// <param name="PWD">密码：默认NQ_MON</param>
        public static void InitializeConfig(
            string PTC = "TCP",
            string HST = "171.0.0.132",
            string PRT = "1521",
            string SRV = "TESTDB",
            string UID = "NQ_MON",
            string PWD = "NQ_MON")
        {
            PROTOCOL = PTC;
            //HOST = HST;
            PORT = PRT;
            SERVICE_NAME = SRV;
            USER_ID = UID;
            PASSWORD = PWD;
        }

        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <param name="PROTOCOL">协议</param>
        /// <param name="HOST">主机地址</param>
        /// <param name="PORT">端口号</param>
        /// <param name="SERVICE_NAME">TNS服务名</param>
        /// <param name="USER_ID">用户名</param>
        /// <param name="PASSWORD">登录口令</param>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return string.Format(
                "DATA SOURCE=                   " +
                "    (DESCRIPTION=              " +
                "        (ADDRESS_LIST=         " +
                "            (ADDRESS=          " +
                "                (PROTOCOL={0}) " +
                "                (HOST={1})     " +
                "                (PORT={2})     " +
                "            )                  " +
                "        )                      " +
                "        (CONNECT_DATA=         " +
                "            (SERVICE_NAME={3}) " +
                "        )                      " +
                "    );                         " +
                "PERSIST SECURITY INFO=TRUE;    " +
                "USER ID={4};                   " +
                "PASSWORD={5}                   ",
                PROTOCOL, HOST, PORT, SERVICE_NAME, USER_ID, PASSWORD);
        }

        /// <summary>
        /// 增删改操作使用此方法(单条SQL文)
        /// </summary>
        /// <param name="cmdType">命令类型（sql语句或者存储过程）</param>
        /// <param name="cmdText">要执行的sql语句或者存储过程名称</param>
        /// <param name="commandParameters">执行所需的一些参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            // 创建一个OracleCommand
            OracleCommand cmd = new OracleCommand();
            //创建一个OracleConnection
            using (OracleConnection connection = new OracleConnection(GetConnectionString()))
            {
                connection.Open();
                using (OracleTransaction trans = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        //调用静态方法PrepareCommand完成赋值操作
                        PrepareCommand(cmd, connection, trans, cmdType, cmdText, commandParameters);
                        //执行命令返回
                        int val = cmd.ExecuteNonQuery();
                        trans.Commit();
                        //清空参数
                        cmd.Parameters.Clear();
                        return val;
                    }
                    catch
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                    return -1;
                }
            }
        }

        /// <summary>
        /// 增删改操作使用此方法（需要一个存在的事务参数）
        /// </summary>
        /// <param name="trans">一个存在的事务</param>
        /// <param name="commandType">命令类型（sql或者存储过程）</param>
        /// <param name="commandText">sql语句或者存储过程名称</param>
        /// <param name="commandParameters">命令所需参数数组</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(OracleTransaction trans, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            // 创建一个OracleCommand
            OracleCommand cmd = new OracleCommand();
            //调用静态方法PrepareCommand完成赋值操作
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            //执行命令返回
            int val = cmd.ExecuteNonQuery();
            //清空参数
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 增删改操作使用此方法（需要一个存在的连接）
        /// </summary> 
        /// <param name="conn">一个存在的OracleConnection参数</param>
        /// <param name="commandType">命令类型（sql或者存储过程）</param>
        /// <param name="commandText">sql语句或者存储过程名称</param>
        /// <param name="commandParameters">命令所需参数数组</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(OracleConnection connection, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            // 创建一个OracleCommand
            OracleCommand cmd = new OracleCommand();
            //调用静态方法PrepareCommand完成赋值操作
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            //执行命令返回
            int val = cmd.ExecuteNonQuery();
            //清空参数
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行语句返回的是单行单列的结果 
        /// </summary>
        /// <param name="commandType">命令类型（sql或者存储过程）</param>
        /// <param name="commandText">sql语句或者存储过程名称</param>
        /// <param name="commandParameters">命令所需参数数组</param>
        /// <returns>返回是第一行第一列的结果（object类型）请使用Covert.to进行类型转换</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            // 创建一个OracleCommand
            OracleCommand cmd = new OracleCommand();
            // 创建一个OracleConnection
            using (OracleConnection conn = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    //调用静态方法PrepareCommand完成赋值操作
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    //执行查询
                    object val = cmd.ExecuteScalar();
                    //清空参数
                    cmd.Parameters.Clear();
                    return val;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        ///    <summary>
        ///    执行语句返回的是单行单列的结果（有指定的事务参数）
        ///    </summary>
        ///    <param name="transaction">一个存在的事务参数</param>
        ///    <param name="commandType">命令类型（sql或者存储过程）</param>
        ///    <param name="commandText">sql语句或者存储过程名称</param>
        ///    <param name="commandParameters">命令所需参数数组</param>
        ///    <returns>返回是第一行第一列的结果（object类型）请使用Covert.to进行类型转换</returns>
        public static object ExecuteScalar(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
        {
            //如果传入的事务是空值，抛出异常
            if (transaction == null)
                throw new ArgumentNullException("transaction");
            //如果传入的事务无连接，抛出异常（无连接，说明传入的事务参数是已经提交过或者回滚了的事务）
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked    or commited, please    provide    an open    transaction.", "transaction");
            // 创建一个OracleCommand
            OracleCommand cmd = new OracleCommand();
            //调用静态方法PrepareCommand完成赋值操作
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            //执行查询
            object retval = cmd.ExecuteScalar();
            //清空参数
            cmd.Parameters.Clear();
            return retval;

        }

        /// <summary>  
        /// 执行数据库查询操作,返回DataSet类型的结果集  
        /// </summary>  
        /// <param name="cmdType">命令的类型</param>
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前查询操作返回的DataSet类型的结果集</returns>  
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(GetConnectionString());
            DataSet ds = null;
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;
                ds = new DataSet();
                adapter.Fill(ds);
                cmd.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return ds;
        }

        /// <summary>  
        /// 执行数据库查询操作,返回DataTable类型的结果集  
        /// </summary>  
        /// <param name="cmdType">命令的类型</param>
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="cmdParms">命令参数集合</param>  
        /// <returns>当前查询操作返回的DataTable类型的结果集</returns>  
        public static DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(GetConnectionString());
            DataTable dt = null;
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;
                dt = new DataTable();
                adapter.Fill(dt);
                cmd.Parameters.Clear();
            }
            catch
            {
                //throw;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return dt;
        }

        /// <summary>
        /// 取得一个Oracle连接
        /// </summary>
        /// <param name="open">是否打开，默认关闭</param>
        /// <returns></returns>
        public static OracleConnection GetOracleConnection(bool open = false)
        {
            OracleConnection conn = new OracleConnection(GetConnectionString());
            if (open && conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;

        }

        /// <summary>
        /// 取得事务对象
        /// </summary>
        /// <param name="conn">连接</param>
        /// <returns></returns>
        public static OracleTransaction GetOracleTransaction(OracleConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            OracleTransaction trans = conn.BeginTransaction();
            return trans;
        }

        /// <summary>
        /// 一个静态的预处理函数
        /// </summary>
        /// <param name="cmd">存在的OracleCommand对象</param>
        /// <param name="conn">存在的OracleConnection对象</param>
        /// <param name="trans">存在的OracleTransaction对象</param>
        /// <param name="cmdType">命令类型（sql或者存在过程）</param>
        /// <param name="cmdText">sql语句或者存储过程名称</param>
        /// <param name="commandParameters">Parameters for the command</param>
        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] commandParameters)
        {

            //如果连接未打开，先打开连接
            if (conn.State != ConnectionState.Open)
                conn.Open();

            //未要执行的命令设置参数
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            //如果传入了事务，需要将命令绑定到指定的事务上去
            if (trans != null)
                cmd.Transaction = trans;

            //将传入的参数信息赋值给命令参数
            if (commandParameters != null)
            {
                cmd.Parameters.AddRange(commandParameters);
            }
        }

        public static ArrayList GetAllData(String sql)
        {
            ArrayList total = new ArrayList();
            DataTable dt = OracleHelper.ExecuteDataTable(CommandType.Text, sql, null);
            if (dt == null || dt.Rows.Count == 0)
            {
            }
            else
            {
                string[] listfield = GetColumnsByDataTable(dt);
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    Dictionary<String, String> al = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);
                    DataRow dr = dt.Rows[n];
                    for (int i = 0; i < listfield.Length; i++)
                    {
                        String field = listfield[i];
                        object val = dr[field];
                        al[field] = Convert.ToString(val);
                    }
                    total.Add(al);
                }
            }
            return total;
        }

        //public static Dictionary<String, String> GetOneData(String sql, String[] listfield)
        //{
        //    Dictionary<String, String> al = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);
        //    DataTable dt = GetAllData(sql);
        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //    }
        //    else
        //    {
        //        DataRow dr = dt.Rows[0];
        //        for (int i = 0; i < listfield.Length; i++)
        //        {
        //            String field = listfield[i];
        //            object val = dr[field];
        //            al[field] = Convert.ToString(val);
        //        }
        //    }
        //    return al;
        //}

        public static Dictionary<String, String> GetOneData(String sql)
        {
            Dictionary<String, String> al = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);
            DataTable dt = OracleHelper.ExecuteDataTable(CommandType.Text, sql, null);
            if (dt == null || dt.Rows.Count == 0)
            {
            }
            else
            {
                string[] listfield = GetColumnsByDataTable(dt);
                DataRow dr = dt.Rows[0];
                for (int i = 0; i < listfield.Length; i++)
                {
                    String field = listfield[i];
                    object val = dr[field];
                    al[field] = Convert.ToString(val);
                }
            }
            return al;
        }

        private static string[] GetColumnsByDataTable(DataTable dt)
        {
            string[] strColumns = null;
            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                strColumns = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strColumns[i] = dt.Columns[i].ColumnName.ToString().ToLower();
                }
            }
            return strColumns;
        }
    }
}
