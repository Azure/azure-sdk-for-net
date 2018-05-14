// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

//namespace Microsoft.WindowsAzure.Build.Tasks.ExecProcess
namespace Microsoft.Azure.Sdk.Build.ExecProcess
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Text;

    public class ShellExec
    {
        #region CONST
        const int DEFAULT_WAIT_TIMEOUT = 60000;  // 60 seconds default timeout
                                                 //const string COMMAND_ARGS = "push {0} -source {1} -ApiKey {2} -NonInteractive -Timeout {3}";

        const int E_FAIL = -2147467259;
        const int ERROR_FILE_NOT_FOUND = 2;
        #endregion
        
        #region Fields
        Process _shellProc;
        
        #endregion

        protected int LastExitCode { get; set; }

        protected Exception LastException { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Process ShellProcess
        {
            get
            {
                if (_shellProc == null)
                    _shellProc = new Process();

                return _shellProc;
            }
        }

        protected ShellExec()
        {
        }

        public ShellExec(string commandPath): this()
        {   
            ProcessStartInfo procInfo = new ProcessStartInfo(commandPath);
            procInfo.CreateNoWindow = true;
            procInfo.UseShellExecute = false;
            procInfo.RedirectStandardError = true;
            procInfo.RedirectStandardInput = true;
            procInfo.RedirectStandardOutput = true;
            ShellProcess.StartInfo = procInfo;
        }

        public virtual int ExecuteCommand(string args)
        {
            try
            {
                ShellProcess.StartInfo.Arguments = args;
                ShellProcess.Start();
                ShellProcess.WaitForExit(DEFAULT_WAIT_TIMEOUT);
                LastExitCode = ShellProcess.ExitCode;

                //if (ShellProcess.HasExited == false)
                //{
                //    //ShellProcess.Kill();
                //    ShellProcess.Close();
                //}
            }
            catch(Win32Exception win32Ex)
            {
                LastExitCode = win32Ex.ErrorCode;
                LastException = win32Ex;
            }
            catch(Exception ex)
            {
                LastExitCode = ex.HResult;
                LastException = ex;
            }

            return LastExitCode;
        }

        public virtual string GetError()
        {
            string error = ShellProcess.StandardError?.ReadToEnd();
            return error;
        }

        public virtual string GetOutput()
        {
            string output = ShellProcess.StandardOutput?.ReadToEnd();
            return output;
        }

        public virtual string AnalyzeExitCode(int exitCode = 9999)
        {
            StringBuilder sb = new StringBuilder();
            if (exitCode == 9999) exitCode = LastExitCode;
            
            if(LastException != null)
            {
                sb.AppendLine(LastException.ToString());                
            }
            else
            {
                if (exitCode != 0)
                {
                    sb.AppendLine(ShellProcess.StandardError?.ReadToEnd());
                }
                else
                {
                    sb.AppendLine(ShellProcess?.StandardOutput?.ReadToEnd());
                }
            }
            
            return sb.ToString();
        }
    }
}
