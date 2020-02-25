// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal static class ProcessService
    {
        public static async ValueTask<string> RunProcessAsync(ProcessStartInfo startInfo, TimeSpan timeout, CancellationToken cancellationToken)
        {
            using AsyncProcessHandler handler = StartProcess(startInfo, timeout, cancellationToken);
            return await handler.WaitAsync().ConfigureAwait(false);
        }

        public static string RunProcess(ProcessStartInfo startInfo, TimeSpan timeout, CancellationToken cancellationToken)
        {
            using AsyncProcessHandler handler = StartProcess(startInfo, timeout, cancellationToken);
            return handler.Wait();
        }

        private static AsyncProcessHandler StartProcess(ProcessStartInfo processStartInfo, TimeSpan timeout, CancellationToken cancellationToken)
        {
            var process = new Process
            {
                StartInfo = processStartInfo,
                EnableRaisingEvents = true
            };

            var handler = new AsyncProcessHandler(process, timeout, cancellationToken);
            if (handler.IsCancellationRequested)
            {
                handler.Cancel();
            }
            else
            {
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }

            return handler;
        }

        private class AsyncProcessHandler : IDisposable
        {
            private readonly Process _process;
            private readonly StringBuilder _output;
            private readonly StringBuilder _error;
            private readonly TaskCompletionSource<string> _tcs;
            private readonly CancellationToken _cancellationToken;
            private readonly CancellationTokenSource _timeoutCts;
            private readonly CancellationTokenRegistration _ctRegistration;
            private readonly CancellationTokenRegistration _timeoutCtRegistration;

            public bool IsCancellationRequested => _cancellationToken.IsCancellationRequested || _timeoutCts != null && _timeoutCts.IsCancellationRequested;

            public AsyncProcessHandler(Process process, TimeSpan timeout, CancellationToken cancellationToken)
            {
                _process = process;
                _cancellationToken = cancellationToken;
                _output = new StringBuilder();
                _error = new StringBuilder();
                _tcs = new TaskCompletionSource<string>();

                _ctRegistration = cancellationToken.Register(QueueHandleCancel);
                if (timeout.TotalMilliseconds >= 0)
                {
                    _timeoutCts = new CancellationTokenSource();
                    _timeoutCtRegistration = _timeoutCts.Token.Register(QueueHandleCancel);
                    _timeoutCts.CancelAfter(timeout);
                }

                process.OutputDataReceived += (o, e) => ProcessDataReceived(e, _output);
                process.ErrorDataReceived += (o, e) => ProcessDataReceived(e, _error);
                process.Exited += (o, e) => HandleExit();
            }

            public Task<string> WaitAsync() => _tcs.Task;
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            public string Wait() => _tcs.Task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

            public void Cancel()
            {
                if (_timeoutCts != null && _timeoutCts.IsCancellationRequested)
                {
                    _tcs.TrySetCanceled(_timeoutCts.Token);
                }
                else if (_cancellationToken.IsCancellationRequested)
                {
                    _tcs.TrySetCanceled(_cancellationToken);
                }
            }

            private static void ProcessDataReceived(DataReceivedEventArgs args, StringBuilder stringBuilder)
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    stringBuilder.AppendLine(args.Data);
                }
            }

            private void HandleExit()
            {
                if (_process.ExitCode == 0)
                {
                    _tcs.TrySetResult(_output.ToString());
                }
                else
                {
                    _tcs.TrySetException(new InvalidOperationException(_error.ToString()));
                }
            }

            private void QueueHandleCancel()
            {
                if (!_tcs.Task.IsCompleted)
                {
                    ThreadPool.QueueUserWorkItem(HandleCancel);
                }
            }

            private void HandleCancel(object state)
            {
                if (_tcs.Task.IsCompleted)
                {
                    return;
                }

                if (!_process.HasExited)
                {
                    _process.Kill();
                }

                Cancel();
            }

            public void Dispose()
            {
                _process.Dispose();
                _ctRegistration.Dispose();
                _timeoutCts?.Dispose();
                _timeoutCtRegistration.Dispose();
            }
        }
    }
}
