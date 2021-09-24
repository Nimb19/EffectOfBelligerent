using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralLib.Logger
{
    public class ConsoleLogger : AbstractLogger
    {
        public override LogLevel LogLevel { get; set; } = LogLevel.Trace;

        protected override void PrivateWrite(string fullMsg)
        {
            Console.WriteLine(fullMsg);
        }
    }
}
