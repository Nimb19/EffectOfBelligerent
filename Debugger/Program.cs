﻿using CommonLib;
using CommonLib.Logger;
using CommonLib.Models;
using System;
using System.Collections.Generic;

namespace Debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = CreateLogger();

            try
            {
                Start(logger);
                Environment.Exit(0);
            }
            catch (Exception exception)
            {
                logger.Write(exception);
                Environment.Exit(1);
            }
        }

        private static void Start(ILogger logger)
        {
            var map = new PyatigorskConfiguration()
                .CreatePyatigorskConfiguration();

            var emulator = new TransportEmulator(map, logger);
            emulator.StartEmulator();
        }

        private static ILogger CreateLogger()
        {
            return new MultiLogger()
            {
                Loggers = new List<ILogger>
                {
                    new FileLogger()
                },
                LogLevel = LogLevel.Debug,
            };
        }
    }
}
