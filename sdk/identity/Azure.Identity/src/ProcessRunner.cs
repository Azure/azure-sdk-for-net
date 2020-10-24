// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable. Disposing of _process and _ctRegistration / _timeoutCtRegistration fields from outside may result in _tcs being incomplete or process handle leak.
    internal sealed class ProcessRunner
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private readonly IProcess _process;
        private readonly TimeSpan _timeout;
        private readonly TaskCompletionSource<string> _tcs;
        private readonly CancellationToken _cancellationToken;
        private readonly CancellationTokenSource _timeoutCts;
        private CancellationTokenRegistration _ctRegistration;
        private readonly StringBuilder _stdOutBuilder;
        private readonly StringBuilder _stdErrBuilder;

        public ProcessRunner(IProcess process, TimeSpan timeout, CancellationToken cancellationToken)
        {
            _process = process;
            _timeout = timeout;
            _tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
            _stdOutBuilder = new StringBuilder();
            _stdErrBuilder = new StringBuilder();

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

            _process.Exited += (o, e) => HandleExit();
            _process.OutputDataReceived += HandleStdOutDataReceived;
            _process.ErrorDataReceived += HandleStdErrDataReceived;


            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.RedirectStandardOutput = true;
            _process.StartInfo.RedirectStandardError = true;

            _timeoutCts?.CancelAfter(_timeout);

            _process.Start();
            _ctRegistration = _cancellationToken.Register(HandleCancel, false);
        }

        private void HandleExit()
        {
            if (_process.ExitCode == 0)
            {
                TrySetResult(_stdOutBuilder.ToString());
            }
            else
            {
                TrySetException(new InvalidOperationException(_stdErrBuilder.ToString()));
            }
        }
        private void HandleStdErrDataReceived(object sender, DataReceivedEventArgsWrapper e) => _stdErrBuilder.Append(e.Data);

        private void HandleStdOutDataReceived(object sender, DataReceivedEventArgsWrapper e) => _stdOutBuilder.Append(e.Data);

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

        private void TrySetResult(string result)
        {
            DisposeProcess();
            _tcs.TrySetResult(result);
        }

        private bool TrySetCanceled()
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                DisposeProcess();
                _tcs.TrySetCanceled(_cancellationToken);
            }

            return _cancellationToken.IsCancellationRequested;
        }

        private void TrySetException(Exception exception)
        {
            DisposeProcess();
            _tcs.TrySetException(exception);
        }

        private void DisposeProcess()
        {
            _process.OutputDataReceived -= HandleStdOutDataReceived;
            _process.ErrorDataReceived -= HandleStdErrDataReceived;

            _process.Dispose();
            _ctRegistration.Dispose();
            _timeoutCts?.Dispose();
        }
    }
}
