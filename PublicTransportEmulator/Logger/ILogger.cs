using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportEmulator.Logger
{
    public interface ILogger
    {
        LogLevel LogLevel { get; set; }
        void Write(LogLevel logLevel, string msg);
        void Write(Exception exception);
    }

    public enum LogLevel
    {
        Error = 0,
        Warning = 1,
        Info = 2,
        Debug = 3,
        Trace = 4,
    }
}
