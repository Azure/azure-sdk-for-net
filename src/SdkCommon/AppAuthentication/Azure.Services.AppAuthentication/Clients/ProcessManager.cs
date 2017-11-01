// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Invokes a process and returns the result from the standard output or error streams.
    /// This is used to invoke az account get-access-token to get a token for local development. 
    /// </summary>
    class ProcessManager : IProcessManager
    {
        // Timeout used such that if process does not respond in this time, it is killed. 
        private readonly TimeSpan _timeOutDuration = TimeSpan.FromSeconds(20);

        // Error when process took too long. 
        private const string TimeOutError = "Process took too long to return the token.";

        /// <summary>
        /// Execute the given process and return the result. 
        /// </summary>
        /// <param name="process">The process to execute</param>
        /// <returns>Returns the process output from the standard output stream.</returns>
        public Task<string> ExecuteAsync(Process process)
        {
            var tcs = new TaskCompletionSource<string>();
            StringBuilder output = new StringBuilder();
            StringBuilder error = new StringBuilder();

            process.EnableRaisingEvents = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            process.OutputDataReceived += (sender, e) => {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    output.AppendLine(e.Data);
                }
            };

            process.ErrorDataReceived += (sender, e) => {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    error.AppendLine(e.Data);
                }
            };

            // If process exits, set the result
            process.Exited += (sender, args) =>
            {
                bool success = process.ExitCode == 0;

                if (success)
                {
                    tcs.TrySetResult(output.ToString());
                }
                else
                {
                    tcs.TrySetException(new Exception(error.ToString()));
                }
            };

            // Used to kill the process if it doesn not respond for the given duration. 
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(_timeOutDuration);

            CancellationToken cancellationToken = cancellationTokenSource.Token;

            cancellationToken.Register(() =>
            {
                if (!tcs.Task.IsCompleted)
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                    }

                    tcs.TrySetException(new TimeoutException(TimeOutError));
                }
            });
            
            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return tcs.Task;
        }
        
    }
}
