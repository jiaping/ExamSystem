#define LOGCALIBURNMESSAGGE
using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace JP.ExamSystem.SetQuestion
{
    [Export(typeof(Logger))]
    public class Logger
    {
        public Logger()
        {
#if LOGCALIBURNMESSAGGE
            //设置caliburn的日志代理，通过代理记录到log4net中
            LogManager.GetLog = type => CaliburnLogInstance;
#endif
            //Caliburn.Micro.LogManager.GetLog = type => CaliburnLogInstance;
        }

        //设置caliburn的日志代理，通过代理记录到log4net中
        static readonly ILog CaliburnLogInstance = new CaliburnLogHelper();

/*
        /// <summary>
        /// log4net日志
        /// </summary>
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger("Lygl");
        public log4net.ILog Log
        {
            get
            {
                return _log;
            }
        }
        */


        private class CaliburnLogHelper : ILog
        {

            /// Logs the message as info.
            /// </summary>
            /// <param name="format">A formatted message.</param>
            /// <param name="args">Parameters to be injected into the formatted message.</param>
            void ILog.Info(string format, params object[] args)
            {
               // _log.InfoFormat(format, args);
                //IoC.Get<Logger>().Log.InfoFormat(format, args);
                Console.WriteLine(string.Format(format,args));
            }
            /// <summary>
            /// Logs the message as a warning.
            /// </summary>
            /// <param name="format">A formatted message.</param>
            /// <param name="args">Parameters to be injected into the formatted message.</param>
            void ILog.Warn(string format, params object[] args)
            {
                //_log.WarnFormat(format, args);
                Console.WriteLine(string.Format(format, args));
            }
            /// <summary>
            /// Logs the exception.
            /// </summary>
            /// <param name="exception">The exception.</param>
            void ILog.Error(Exception exception)
            {
                //_log.Error("Caliburn Framework Error:", exception);
                Console.WriteLine(exception.ToString());
            }
        }
    }
}
