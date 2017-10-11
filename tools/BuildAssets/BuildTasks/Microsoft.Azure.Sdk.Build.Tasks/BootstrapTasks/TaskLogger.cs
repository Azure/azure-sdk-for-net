namespace Microsoft.Azure.Build.BootstrapTasks
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System.Diagnostics;
    using System;

    internal class TaskLogger : Task
    {
        private bool _isBuildEngineInitialized;

        public TaskLogger()
        {
            _isBuildEngineInitialized = false;
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
