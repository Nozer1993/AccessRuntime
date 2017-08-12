using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessRuntime.Bin
{
    /// <summary>
    /// 配置文件节点未找到
    /// </summary>
    internal class ConnectionStringElementNotFindException:Exception
    {
        /// <summary>
        /// 配置文件节点未找到
        /// </summary>
        public ConnectionStringElementNotFindException()
        {

        }
        /// <summary>
        /// 配置文件节点未找到
        /// </summary>
        /// <param name="message">异常信息</param>
        public ConnectionStringElementNotFindException(string message):base(message)
        {
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="inner">异常类</param>
        public ConnectionStringElementNotFindException(string message, Exception inner)
        : base(message, inner)
        { }
    }
}
