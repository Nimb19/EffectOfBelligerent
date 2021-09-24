using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralLib.Logger
{
    public abstract class AbstractLogger : ILogger
    {
        public virtual LogLevel LogLevel { get; set; } = LogLevel.Trace;

        protected abstract void PrivateWrite(string fullMsg);

        public virtual void Write(LogLevel logLevel, string msg)
        {
            if (LogLevel >= logLevel)
            {
                var fullMasg = $"{DateTime.Now} [{logLevel.ToString().ToUpper()}] {msg}";
                PrivateWrite(fullMasg);
            }
        }

        public virtual void Write(Exception exception)
        {
            Write(LogLevel.Error, $"{exception.Message} ({exception.InnerException}).{Environment.NewLine}{exception.StackTrace}");
        }

        public override string ToString()
        {
            return $"Logger={this.GetType().Name}: LogLevel={LogLevel}";
        }
    }
}
