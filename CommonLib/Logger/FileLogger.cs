using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonLib.Logger
{
    public sealed class FileLogger : AbstractLogger
    {
        /// <summary> По умолчанию сбрасывает в папку с приложением. </summary>
        public string PathToLogs { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs.txt");
        public override LogLevel LogLevel { get; set; } = LogLevel.Trace;

        protected override void PrivateWrite(string fullMsg)
        {
            using (var sw = new StreamWriter(PathToLogs, append: true))
                sw.WriteLine(fullMsg);
        }
    }
}
