// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.Utilities
{
    using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal class NetSdkTaskLogger
    {
        bool _isBuildEngineInitialized;
        ITask TaskInstance;
        TaskLoggingHelper NetSdkLogger;

        public bool OutputDebugTrace { get; set; }

        public NetSdkTaskLogger(ITask taskInstance, bool debugTrace)
        {
            _isBuildEngineInitialized = false;
            TaskInstance = taskInstance;
            OutputDebugTrace = debugTrace;
            NetSdkLogger = new TaskLoggingHelper(taskInstance);
        }

        public NetSdkTaskLogger(INetSdkTask taskInstance, bool debugTrace)
        {
            _isBuildEngineInitialized = false;
            TaskInstance = taskInstance;
            OutputDebugTrace = debugTrace;
            NetSdkLogger = new TaskLoggingHelper(taskInstance);
        }

        internal bool IsBuildEngineInitialized
        {
            get
            {
                if (this.TaskInstance.BuildEngine != null)
                {
                    _isBuildEngineInitialized = true;
                }

                return _isBuildEngineInitialized;
            }
        }

        #region Logging
        public void LogInfo(string messageToLog)
        {
            if (IsBuildEngineInitialized)
            {
                NetSdkLogger.LogMessage(messageToLog);
            }
            else
            {
                Debug.WriteLine(messageToLog);
            }
        }

        public void LogInfo<T>(IEnumerable<T> infoToLog) where T : class
        {
            LogInfo<T>(infoToLog, (i) => i.ToString());
        }

        public void LogInfo<T>(IEnumerable<T> infoToLog, Func<T, string> logDelegate)
        {
            foreach (var info in infoToLog)
            {
                LogInfo(logDelegate(info));
            }
        }

        public void LogInfo(string outputFormat, params string[] info)
        {
            LogInfo(string.Format(outputFormat, info));
        }

        public void LogException(Exception ex)
        {
            if (IsBuildEngineInitialized)
            {
                NetSdkLogger.LogErrorFromException(ex);
            }
            else
            {
                Debug.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public void LogException(Exception ex, bool showDetails)
        {
            if (IsBuildEngineInitialized)
            {
                NetSdkLogger.LogErrorFromException(ex, showDetails);
            }
            else
            {
                Debug.WriteLine(ex.ToString());                
                throw ex;
            }
        }

        public void LogError(string errorMessage)
        {
            if (IsBuildEngineInitialized)
            {
                NetSdkLogger.LogError(errorMessage);
            }
            else
            {
                Debug.WriteLine(errorMessage);
            }
        }
        #endregion

        #region Log Debug info
        public void LogDebugInfo(string debugInfo)
        {
            if (IsBuildEngineInitialized)
            {
                if (OutputDebugTrace == true)
                {
                    NetSdkLogger.LogMessage(debugInfo);
                }
            }
            else
            {
                Debug.WriteLine(debugInfo);
            }
        }

        public void LogDebugInfo(string logFormat, params string[] debugInfo)
        {
            LogDebugInfo(string.Format(logFormat, debugInfo));
        }

        public void LogDebugInfo(IEnumerable<Tuple<string, string, string>> tupCol)
        {
            string logFormat = "Tuple:{0}_{1}_{2}";
            foreach(Tuple<string, string, string> tup in tupCol)
            {
                LogDebugInfo(logFormat, tup.Item1, tup.Item2, tup.Item3);
            }
        }

        public void LogDebugInfo<T>(IEnumerable<T> infoToLog, Func<T, string> logDelegate)
        {
            foreach (var info in infoToLog)
            {
                LogDebugInfo(logDelegate(info));
            }
        }
        public void LogDebugInfo(IEnumerable<Tuple<string, string>> tupCol)
        {
            string logFormat = "Tuple:{0}_{1}";
            foreach (Tuple<string, string> tup in tupCol)
            {
                LogDebugInfo(logFormat, tup.Item1, tup.Item2);
            }
        }

        public void LogDebugInfo(Dictionary<string, string> col)
        {
            string logFormat = "KV:{0}_{1}";
            foreach (KeyValuePair<string, string> kv in col)
            {
                LogDebugInfo(logFormat, kv.Key, kv.Value);
            }
        }

        #endregion
    }
}
