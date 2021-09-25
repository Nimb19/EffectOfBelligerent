using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportEmulator.Logger
{
    public sealed class MultiLogger : ILogger
    {
        public List<ILogger> Loggers { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Trace;

        public void Write(Exception exception)
        {
            foreach (var logger in Loggers)
            {
                logger.Write(exception);
            }
        }

        public void Write(LogLevel logLevel, string msg)
        {
            foreach (var logger in Loggers)
            {
                logger.Write(logLevel, msg);
            }
        }
    }
}
