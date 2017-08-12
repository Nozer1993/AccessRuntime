using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace AccessRuntime.Bin
{
    /// <summary>
    /// Access工具类
    /// </summary>
    internal sealed class AccessUtils
    {
        /// <summary>
        /// access数据库连接字符串
        /// </summary>
        private  string accessConnectionString = string.Empty;
        /// <summary>
        /// access数据库连接对象
        /// </summary>
        private  OleDbConnection conn;
        /// <summary>
        /// access数据库命令对象
        /// </summary>
        private OleDbCommand comm;
        /// <summary>
        /// access数据库连接字符串
        /// </summary>
        public  string AccessConnectionString
        {
            get {
                if (!string.IsNullOrEmpty(accessConnectionString))
                    return accessConnectionString;
                else
                {
                    string connstr = ConfigurationManager.ConnectionStrings["AccessRuntimeConnectionString"].ConnectionString;
                    if (string.IsNullOrEmpty(connstr))
                        throw new ConnectionStringElementNotFindException("未找到或未设置AccessRuntimeConnectionString节点");
                    else
                        return connstr;
                }
            }
        }
        /// <summary>
        /// 初始化连接（有密码）
        /// </summary>
        /// <param name="filepath">可以为空，为空则调用配置文件</param>
        /// <param name="pwd">数据库密码</param>
        /// <example>
        /// public AccessUtils("123",null)
        /// </example>
        public AccessUtils(string pwd,string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                filepath = AccessConnectionString;
            }
            this.conn = new OleDbConnection(filepath + "; Jet OLEDB:Database Password=" + pwd);
            conn.Open();
        }

        /// <summary>
        /// 初始化连接（无密码）
        /// </summary>
        /// <param name="filepath"></param>
        /// <example>
        /// 1.public AccessUtils(filepath)
        /// 2.public AccessUtils()//不传递参数则调用配置文件
        /// </example>
        public AccessUtils(string filepath = null)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                filepath = AccessConnectionString;
            }
            this.conn = new OleDbConnection(filepath);
            conn.Open();
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql">需要执行的sql语句</param>
        public bool ExecuteSql(string sql, ref string errorMsg)
        {
            SetConnOpen();
            string[] sqls = serializeSql(sql);
            OleDbTransaction tran = conn.BeginTransaction();
            try
            {
                comm = new OleDbCommand();
                comm.Transaction = tran;
                comm.Connection = conn;
                foreach (string s in sqls)
                {
                    var temps = s.Trim().Replace("\r\n", "");
                    if (!string.IsNullOrEmpty(temps))
                    {
                        comm.CommandText = temps;
                        comm.ExecuteNonQuery();
                    }
                }
                tran.Commit();
                return true;
            }
            catch(Exception ex)
            {
                tran.Rollback();
                errorMsg = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 从sql脚本文件执行
        /// </summary>
        /// <param name="sqlFilePath">sql脚本文件的路径</param>
        /// <returns></returns>
        public bool ExecuteSqlByFile(string sqlFilePath,ref string errorMsg)
        {
            if(!File.Exists(sqlFilePath))
            {
                throw new FileNotFoundException("未找到该sql脚本，请检查路径是否错误");
            }

            string sourceSql = new StreamReader(sqlFilePath).ReadToEnd();
            string[] sqls = serializeSql(sourceSql);
            SetConnOpen();
            OleDbTransaction tran = conn.BeginTransaction();
            try
            {
                comm = new OleDbCommand();
                comm.Transaction = tran;
                comm.Connection = conn;
                foreach (string s in sqls)
                {
                    var temps = s.Trim().Replace("\r\n", "");
                    if (!string.IsNullOrEmpty(temps))
                    {
                        comm.CommandText = temps;
                        comm.ExecuteNonQuery();
                    }
                }
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                errorMsg = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 将sql脚本进行序列化
        /// </summary>
        /// <param name="sql">sql脚本</param>
        /// <returns></returns>
        private string[] serializeSql(string sql)
        {
            string[] ss = sql.Split(new string[1] { "/*go*/" }, StringSplitOptions.RemoveEmptyEntries);
            return ss;
        }
        /// <summary>
        /// 获取打开的连接
        /// </summary>
        private void SetConnOpen()
        {
            if (this.conn.State != ConnectionState.Open)
            {
                this.conn.Open();
            }
        }
    }
}
