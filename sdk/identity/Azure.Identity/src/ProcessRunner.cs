// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal sealed class ProcessRunner : IDisposable
    {
        private readonly IProcess _process;
        private readonly TimeSpan _timeout;
        private readonly TaskCompletionSource<string> _tcs;
        private readonly TaskCompletionSource<ICollection<string>> _outputTcs;
        private readonly TaskCompletionSource<ICollection<string>> _errorTcs;
        private readonly ICollection<string> _outputData;
        private readonly ICollection<string> _errorData;
        private readonly bool _redirectStandardInput;

        private readonly CancellationToken _cancellationToken;
        private readonly CancellationTokenSource _timeoutCts;
        private CancellationTokenRegistration _ctRegistration;
        private bool _logPII;
        public int ExitCode => _process.ExitCode;

        public ProcessRunner(IProcess process, TimeSpan timeout, bool logPII, CancellationToken cancellationToken)
            : this(process, timeout, logPII, false, cancellationToken)
        { }

        public ProcessRunner(IProcess process, TimeSpan timeout, bool logPII, bool redirectStandardInput, CancellationToken cancellationToken)
        {
            _logPII = logPII;
            _process = process;
            _timeout = timeout;
            _redirectStandardInput = redirectStandardInput;

            if (_logPII)
            {
                AzureIdentityEventSource.Singleton.ProcessRunnerInformational($"Running process `{process.StartInfo.FileName}' with arguments {string.Join(", ", process.StartInfo.Arguments)}");
            }

            _outputData = new List<string>();
            _errorData = new List<string>();
            _outputTcs = new TaskCompletionSource<ICollection<string>>(TaskCreationOptions.RunContinuationsAsynchronously);
            _errorTcs = new TaskCompletionSource<ICollection<string>>(TaskCreationOptions.RunContinuationsAsynchronously);
            _tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

            if (timeout.TotalMilliseconds >= 0)
            {
                _timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                _cancellationToken = _timeoutCts.Token;
            }
            else
            {
                _cancellationToken = cancellationToken;
            }
        }

        public Task<string> RunAsync()
        {
            StartProcess();
            return _tcs.Task;
        }

        public string Run()
        {
            StartProcess();
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            return _tcs.Task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        private void StartProcess()
        {
            if (TrySetCanceled() || _tcs.Task.IsCompleted)
            {
                return;
            }

            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.RedirectStandardOutput = true;
            _process.StartInfo.RedirectStandardError = true;
            _process.StartInfo.RedirectStandardInput = _redirectStandardInput;

            _process.OutputDataReceived += (sender, args) => OnDataReceived(args, _outputData, _outputTcs);
            _process.ErrorDataReceived += (sender, args) => OnDataReceived(args, _errorData, _errorTcs);
            _process.Exited += (o, e) => _ = HandleExitAsync();

            _timeoutCts?.CancelAfter(_timeout);

            if (!_process.Start())
            {
                TrySetException(new InvalidOperationException($"Failed to start process '{_process.StartInfo.FileName}'"));
            }

            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
            _ctRegistration = _cancellationToken.Register(HandleCancel, false);

            if (_redirectStandardInput)
            {
                try
                {
                    _process.StandardInput.Close();
                }
                catch (Exception ex)
                {
                    if (_logPII)
                    {
                        AzureIdentityEventSource.Singleton.ProcessRunnerError($"Failed to close StandardInput: {ex}");
                    }
                }
            }
        }

        private async ValueTask HandleExitAsync()
        {
            if (_process.ExitCode == 0)
            {
                ICollection<string> output = await _outputTcs.Task.ConfigureAwait(false);
                TrySetResult(string.Join(Environment.NewLine, output));
            }
            else
            {
                ICollection<string> error = await _errorTcs.Task.ConfigureAwait(false);
                TrySetException(new InvalidOperationException(string.Join(Environment.NewLine, error)));
            }
        }

        private void HandleCancel()
        {
            if (_tcs.Task.IsCompleted)
            {
                return;
            }

            if (!_process.HasExited)
            {
                try
                {
                    _process.Kill();
                }
                catch (Exception ex)
                {
                    TrySetException(ex);
                    return;
                }
            }

            TrySetCanceled();
        }

        private static void OnDataReceived(DataReceivedEventArgs args, ICollection<string> data, TaskCompletionSource<ICollection<string>> tcs)
        {
            if (args.Data != null)
            {
                data.Add(args.Data);
            }
            else
            {
                tcs.SetResult(data);
            }
        }

        private void TrySetResult(string result)
        {
            _tcs.TrySetResult(result);
        }

        private bool TrySetCanceled()
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _tcs.TrySetCanceled(_cancellationToken);
            }

            return _cancellationToken.IsCancellationRequested;
        }

        private void TrySetException(Exception exception)
        {
            if (_logPII)
            {
                AzureIdentityEventSource.Singleton.ProcessRunnerError(exception.ToString());
            }
            _tcs.TrySetException(exception);
        }

        public void Dispose()
        {
            _tcs.TrySetCanceled();
            _process.Dispose();
            _ctRegistration.Dispose();
            _timeoutCts?.Dispose();
        }
    }
}
