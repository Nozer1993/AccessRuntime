using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessRuntime.Bin
{
    /// <summary>
    /// AccessRuntime异常
    /// </summary>
    public class AccessRuntimeException:Exception
    {
        /// <summary>
        /// 配置文件节点未找到
        /// </summary>
        public AccessRuntimeException()
        {

        }
        /// <summary>
        /// 配置文件节点未找到
        /// </summary>
        /// <param name="message">异常信息</param>
        public AccessRuntimeException(string message):base(message)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="inner">异常类</param>
        public AccessRuntimeException(string message, Exception inner)
        : base(message, inner)
        { }
    }
}
