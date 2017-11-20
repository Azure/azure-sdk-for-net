using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Utilities;
using System.Diagnostics;
using Microsoft.Build.Framework;
using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;

namespace Microsoft.Azure.Sdk.Build.Tasks.Utilities
{
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
                if (OutputDebugTrace)
                {
                    NetSdkLogger.LogMessage(messageToLog);
                }
            }
            else
            {
                Debug.WriteLine(messageToLog);
            }
        }

        public void LogInfo<T>(IEnumerable<T> infoToLog) where T:class
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
    }
}
