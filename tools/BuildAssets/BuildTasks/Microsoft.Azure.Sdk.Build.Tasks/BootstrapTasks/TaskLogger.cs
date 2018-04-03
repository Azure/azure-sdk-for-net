// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Build.BootstrapTasks
{
    using Microsoft.Build.Utilities;
    using System.Diagnostics;
    using System;

    internal class TaskLogger : Task
    {
        private bool _isBuildEngineInitialized;

        private bool OutputDebugTrace { get; set; }

        public TaskLogger(bool debugTrace)
        {
            _isBuildEngineInitialized = false;
            OutputDebugTrace = debugTrace;
        }

        internal bool IsBuildEngineInitialized
        {
            get
            {
                if (this.BuildEngine != null)
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
                if(OutputDebugTrace)
                    Log.LogMessage(messageToLog);
            }
            else
            {
                Debug.WriteLine(messageToLog);
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
                Log.LogErrorFromException(ex);
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
                Log.LogError(errorMessage);
            }
            else
            {
                Debug.WriteLine(errorMessage);
            }
        }

        public override bool Execute()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
