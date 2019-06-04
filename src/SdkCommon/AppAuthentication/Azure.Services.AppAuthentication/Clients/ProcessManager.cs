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
    internal class ProcessManager : IProcessManager
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
        public Task<string> ExecuteAsync(Process process, CancellationToken cancellationToken)
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

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            // Used to kill the process if it does not respond for the given duration or respond to caller request cancellation
            using (var internalTokenSource = new CancellationTokenSource(_timeOutDuration))
            using (var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(internalTokenSource.Token, cancellationToken))
            {
                var internalTimeoutToken = internalTokenSource.Token;
                var externalCallerToken = cancellationToken;

                linkedTokenSource.Token.Register(() =>
                {
                    if (!tcs.Task.IsCompleted)
                    {
                        if (!process.HasExited)
                        {
                            process.Kill();
                        }

                        if (internalTimeoutToken.IsCancellationRequested)
                        {
                            tcs.TrySetException(new TimeoutException(TimeOutError));
                        }
                        else if (externalCallerToken.IsCancellationRequested)
                        {
                            tcs.TrySetException(new OperationCanceledException(externalCallerToken));
                        }
                    }
                });
            }

            return tcs.Task;
        }

    }
}