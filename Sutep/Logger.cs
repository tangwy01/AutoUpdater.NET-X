using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Sutep
{
   public class Logger
    {
        private static readonly log4net.ILog log;
        static Logger()
        {
            // 初始化配置文件
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            if (File.Exists(configPath))
            {
                XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            }
            else
            {
                //if (HttpContext.Current != null)
                //{
                //    string rootPath = HttpContext.Current.Server.MapPath("bin");
                //    configPath = Path.Combine(rootPath, "log4net.config");
                //    log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configPath));
                //}
                //else
                //{
                //    log4net.Config.XmlConfigurator.Configure();
                //}
            }
            // 初始化记录类型
            log = LogManager.GetLogger(repository.Name, "NETCorelog4net");

            //ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            //XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            //ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");

            //log.Info("NETCorelog4net log");
            //log.Info("test log");
            //log.Error("error");
            //log.Info("linezero");
        }
        /// <summary>
        /// 自定义ILog对象
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>ILog</returns>
        public static log4net.ILog GetLogger(Type type)
        {
            return log4net.LogManager.GetLogger(type);
        }

        /// <summary>
        /// 错误
        /// </summary>
        public static void Error(string message)
        {
            if (log.IsErrorEnabled)
                log.Error(message);
        }

        /// <summary>
        /// 错误
        /// </summary>
        public static void Error(string message, Exception ex)
        {
            if (log.IsErrorEnabled)
                log.Error(message, ex);
        }
        /// <summary>
        /// 系统异常
        /// </summary>
        public static void SystemError(Exception ex)
        {
            if (log.IsErrorEnabled)
                log.Error("系统异常", ex);
        }

        /// <summary>
        /// 错误
        /// </summary>
        public static void ErrorFormat(string message, params object[] args)
        {
            if (log.IsErrorEnabled)
                log.ErrorFormat(message, args);
        }

        /// <summary>
        /// 调试
        /// </summary>
        public static void Debug(string message)
        {
            if (log.IsDebugEnabled)
                log.Debug(message);
        }

        /// <summary>
        /// 调试
        /// </summary>
        public static void Debug(string message, Exception ex)
        {
            if (log.IsDebugEnabled)
                log.Debug(message, ex);
        }

        /// <summary>
        /// 调试
        /// </summary>
        public static void DebugFormat(string message, params object[] args)
        {
            if (log.IsDebugEnabled)
                log.DebugFormat(message, args);
        }

        /// <summary>
        /// 消息
        /// </summary>
        public static void Info(string message)
        {
            if (log.IsInfoEnabled)
                log.Info(message);
        }

        /// <summary>
        /// 消息
        /// </summary>
        public static void Info(string message, Exception ex)
        {
            if (log.IsInfoEnabled)
                log.Info(message, ex);
        }

        /// <summary>
        /// 消息
        /// </summary>
        public static void InfoFormat(string message, params object[] args)
        {
            if (log.IsInfoEnabled)
                log.InfoFormat(message, args);
        }

        /// <summary>
        /// 警告
        /// </summary>
        public static void Warn(string message)
        {
            if (log.IsWarnEnabled)
                log.Warn(message);
        }

        /// <summary>
        /// 警告
        /// </summary>
        public static void Warn(string message, Exception ex)
        {
            if (log.IsWarnEnabled)
                log.Warn(message, ex);
        }

        /// <summary>
        /// 警告
        /// </summary>
        public static void WarnFormat(string message, params object[] args)
        {
            if (log.IsWarnEnabled)
                log.WarnFormat(message, args);
        }
    }
}
