// ----------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Microsoft.DataPipeline.TestFramework.Logging
{
    public static class AdfTestLogger
    {
        private static readonly object LogLock = new object();
        private static readonly object ResultLogLock = new object();

        static AdfTestLogger()
        {
            EnableConsoleOutput = false;
        }

        /// <summary>
        /// Enable logger write logging information directly to console for console apps.
        /// Default: False
        /// </summary>
        public static bool EnableConsoleOutput { get; set; }

        public static void Log(TraceEventType logType, string message)
        {
            if (logType == TraceEventType.Error)
            {
                LogError(message);
            }
            else if (logType == TraceEventType.Information)
            {
                LogInformation(message);
            }
            else if (logType == TraceEventType.Warning)
            {
                LogWarning(message);
            }
            else if (logType == TraceEventType.Verbose)
            {
                LogVerbose(message);
            }
            else
            {
                Console.WriteLine("Progress: [Info] " + message);
                WriteToLog(message);
            }
        }

        public static void Log(TraceEventType logType, string message, params object[] args)
        {
            if (logType == TraceEventType.Error)
            {
                LogError(message, args);
            }
            else if (logType == TraceEventType.Information)
            {
                LogInformation(message, args);
            }
            else if (logType == TraceEventType.Warning)
            {
                LogWarning(message, args);
            }
            else if (logType == TraceEventType.Verbose)
            {
                LogVerbose(message, args);
            }
            else
            {
                Console.WriteLine("Progress: [Info] " + message);
                WriteToLog(message);
            }
        }

        public static void LogInformation(string message)
        {
            Console.WriteLine("Progress: [Info] " + message);
            WriteToLog(message);
        }

        public static void LogInformation(string format, params object[] args)
        {
            LogInformation(string.Format(CultureInfo.InvariantCulture, format, args));
        }

        public static void LogError(string message)
        {
            Console.WriteLine("Progress: [Err] " + message);
            WriteToLog(String.Format(CultureInfo.InvariantCulture, "Error: {0}", message));
        }

        public static void LogError(string format, params object[] args)
        {
            LogError(string.Format(CultureInfo.InvariantCulture, format, args));
        }

        public static void LogWarning(string message)
        {
            Console.WriteLine("Progress: [Warn] " + message);
            WriteToLog(String.Format(CultureInfo.InvariantCulture, "Warning: {0}", message));
        }

        public static void LogWarning(string format, params object[] args)
        {
            LogWarning(string.Format(CultureInfo.InvariantCulture, format, args));
        }

        public static void LogVerbose(string message)
        {
            Console.WriteLine("Progress: [Info] " + message);
            WriteToLog(message);
        }

        public static void LogVerbose(string format, params object[] args)
        {
            LogVerbose(string.Format(CultureInfo.InvariantCulture, format, args));
        }

        public static void LogToFile(string resultFileName, params object[] args)
        {
            LogToFile(resultFileName, String.Join(",", args));
        }

        public static void LogToFile(string resultFileName, object arg)
        {
            lock (ResultLogLock)
            {
                using (StreamWriter outputFile = new StreamWriter(resultFileName, true))
                {
                    string logStr = arg.ToString();
                    LogInformation(logStr);
                    outputFile.WriteLineAsync(logStr);
                }
            }
        }
        
        public static void LogStrToFile(string resultFileName, string formatString, params object[] args)
        {
            LogToFile(resultFileName, String.Format(CultureInfo.InvariantCulture,formatString, args));
        }

        private static void WriteToLog(string message)
        {
            lock (LogLock)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    string outputString = string.Concat(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), " - ", message);
                    Trace.WriteLine(outputString);
                    if (EnableConsoleOutput)
                    {
                        Console.WriteLine(outputString);
                    }
                    int retry = 0;
                    bool result = false;
                    while (!result && retry < 20)
                    {
                        try
                        {
                            using (StreamWriter logFile = new StreamWriter("MdpTestLog.log", true))
                            {
                                logFile.WriteLine(outputString + (retry > 0 ? " Logging took " + retry + " retries." : ""));    
                            }
                            result = true;
                        }
                        catch (IOException)
                        {
                            Thread.Sleep(500);
                            retry++;
                        }
                    }
                }
            }
        }
    }
}