using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GeneralLib.Logger
{
    public sealed class DebugLogger : AbstractLogger
    {
        public override LogLevel LogLevel { get; set; } = LogLevel.Trace;

        protected override void PrivateWrite(string fullMsg)
        {
            Debug.WriteLine(fullMsg);
        }
    }
}
