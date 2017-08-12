using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessRuntime.Bin
{
    /// <summary>
    /// Access工具
    /// 注意：语句之间使用 /*go*/ 进行分割
    /// </summary>
    public static class AccessTool
    {
        /// <summary>
        /// 在Access数据库中执行sql语句
        /// </summary>
        /// <param name="sql">sql脚本</param>
        /// <param name="pwd">数据库密码（如果无密码则不填写此参数）</param>
        /// <returns>执行结果</returns>
        public static bool ExecuteSql(string sql,string pwd = null)
        {
            AccessUtils au = null;
            if (string.IsNullOrEmpty(pwd)) {
                au = new AccessUtils();
                string msg = null;
                if(au.ExecuteSql(sql, ref msg))
                {
                    return true;
                }
                else
                {
                    throw new AccessRuntimeException(msg);
                }
            }
            else
            {
                au = new AccessUtils(pwd, null);
                string msg = null;
                if(au.ExecuteSql(sql,ref msg))
                {
                    return true;
                }
                else
                {
                    throw new AccessRuntimeException(msg);
                }
            }
            
        }

        /// <summary>
        /// 在Access数据库中执行sql脚本
        /// </summary>
        /// <param name="sqlpath">sql脚本路径</param>
        /// <param name="pwd">数据库密码（如果无密码则不填写此参数）</param>
        /// <returns>执行结果</returns>
        public static bool ExecuteSqlByFile(string sqlpath,string pwd = null)
        {
            AccessUtils au = null;
            //判断密码是否填写
            if (string.IsNullOrEmpty(pwd))
            {
                au = new AccessUtils();
                string msg = null;
                if (au.ExecuteSqlByFile(sqlpath, ref msg))
                {
                    return true;
                }
                else
                {
                    throw new AccessRuntimeException(msg);
                }
            }
            else
            {
                au = new AccessUtils(pwd, null);
                string msg = null;
                if (au.ExecuteSqlByFile(sqlpath, ref msg))
                {
                    return true;
                }
                else
                {
                    throw new AccessRuntimeException(msg);
                }
            }
        }

        /// <summary>
        /// 在指定Access数据库中执行sql语句
        /// </summary>
        /// <param name="sql">sql脚本</param>
        /// <param name="dbpath">数据库所在路径</param>
        /// <param name="pwd">执行结果</param>
        /// <returns></returns>
        public static bool OnExecuteSql(string sql,string dbpath,string pwd = null)
        {
            AccessUtils au = null;
            if (string.IsNullOrEmpty(pwd))
            {
                au = new AccessUtils(dbpath);
                string msg = null;
                if (au.ExecuteSql(sql, ref msg))
                {
                    return true;
                }
                else
                {
                    throw new AccessRuntimeException(msg);
                }
            }
            else
            {
                au = new AccessUtils(pwd, dbpath);
                string msg = null;
                if (au.ExecuteSql(sql, ref msg))
                {
                    return true;
                }
                else
                {
                    throw new AccessRuntimeException(msg);
                }
            }

        }

        /// <summary>
        /// 在指定Access数据库中执行sql语句
        /// </summary>
        /// <param name="sqlpath">sql脚本路径</param>
        /// <param name="dbpath">数据库所在路径</param>
        /// <param name="pwd">执行结果</param>
        /// <returns></returns>
        public static bool OnExecuteSqlByFile(string sqlpath, string dbpath, string pwd = null)
        {
            AccessUtils au = null;
            //判断密码是否填写
            if (string.IsNullOrEmpty(pwd))
            {
                au = new AccessUtils(dbpath);
                string msg = null;
                if (au.ExecuteSqlByFile(sqlpath, ref msg))
                {
                    return true;
                }
                else
                {
                    throw new AccessRuntimeException(msg);
                }
            }
            else
            {
                au = new AccessUtils(pwd, dbpath);
                string msg = null;
                if (au.ExecuteSqlByFile(sqlpath, ref msg))
                {
                    return true;
                }
                else
                {
                    throw new AccessRuntimeException(msg);
                }
            }
        }
    }
}
