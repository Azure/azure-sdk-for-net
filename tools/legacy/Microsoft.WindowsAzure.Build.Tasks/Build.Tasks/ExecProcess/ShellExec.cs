// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Build.Tasks.ExecProcess
{
    public class ShellExec
    {
        #region CONST
        const int DEFAULT_WAIT_TIMEOUT = 30000;  // 30 seconds default timeout
        //const string COMMAND_ARGS = "push {0} -source {1} -ApiKey {2} -NonInteractive -Timeout {3}";
        #endregion


        #region Fields
        //Process _shellProc;
        
        #endregion

        protected int LastExitCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Process ShellProcess { get; protected set; }

        protected ShellExec()
        {
            ShellProcess = new Process();
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
                return LastExitCode;
            }
            finally
            {
                //ShellProcess.Close();
                //ShellProcess.Dispose();
                //_lazyProcess.Value.WaitForExit(DEFAULT_WAIT_TIMEOUT);
                //_lazyProcess.Value.Close();
                //_lazyProcess.Value.Dispose();
            }
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
            string finalOutput = string.Empty;
            if (exitCode == 9999) exitCode = LastExitCode;

            if (exitCode != 0)
            {
                finalOutput = ShellProcess.StandardError?.ReadToEnd();
            }
            else
            {
                finalOutput = ShellProcess.StandardOutput?.ReadToEnd();
            }

            return finalOutput;
        }
    }
}
