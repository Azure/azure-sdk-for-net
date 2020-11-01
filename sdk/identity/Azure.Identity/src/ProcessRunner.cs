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
        private readonly TaskCompletionSource<bool> _processExitedCompletionSource;
        private readonly CancellationToken _cancellationToken;
        private readonly CancellationTokenSource _timeoutCts;
        private CancellationTokenRegistration _ctRegistration;
        private readonly StringBuilder _stdOutBuilder;
        private readonly StringBuilder _stdErrBuilder;
        private readonly TaskCompletionSource<string> _stdOutCompletionSource;
        private readonly TaskCompletionSource<string> _stdErrCompletionSource;

        public ProcessRunner(IProcess process, TimeSpan timeout, CancellationToken cancellationToken)
        {
            _process = process;
            _timeout = timeout;
            _processExitedCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            _stdOutBuilder = new StringBuilder();
            _stdErrBuilder = new StringBuilder();
            _stdOutCompletionSource = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
            _stdErrCompletionSource = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

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

        public async Task<string> RunAsync()
        {
            StartProcess();

            try
            {
                await _processExitedCompletionSource.Task.ConfigureAwait(false);
                var output = await _stdOutCompletionSource.Task.ConfigureAwait(false);
                await _stdErrCompletionSource.Task.ConfigureAwait(false);
                return output;
            }
            finally
            {
                DisposeProcess();
            }
        }

        public string Run()
        {
            StartProcess();
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            try
            {
                _processExitedCompletionSource.Task.GetAwaiter().GetResult();
                var output = _stdOutCompletionSource.Task.GetAwaiter().GetResult();
                _stdErrCompletionSource.Task.GetAwaiter().GetResult();
                return output;
            }
            finally
            {
                DisposeProcess();
            }
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        private void StartProcess()
        {
            if (TrySetCanceled() || _processExitedCompletionSource.Task.IsCompleted)
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
                _processExitedCompletionSource.TrySetResult(true);
            }
            else
            {
                _processExitedCompletionSource.TrySetResult(false);
            }
        }
        private void HandleStdErrDataReceived(object sender, DataReceivedEventArgsWrapper e)
        {
            if (e.Data is null)
            {
                var result = _stdErrBuilder.ToString();
                if (result.Length == 0)
                {
                    _stdErrCompletionSource.TrySetResult(result);
                }
                else
                {
                    _stdErrCompletionSource.TrySetException(new InvalidOperationException(result));
                }
            }
            else
            {
                _stdErrBuilder.Append(e.Data);
            }
        }

        private void HandleStdOutDataReceived(object sender, DataReceivedEventArgsWrapper e)
        {
            if (e.Data is null)
            {
                _stdOutCompletionSource.TrySetResult(_stdOutBuilder.ToString());
            }
            else
            {
                _stdOutBuilder.Append(e.Data);
            }
        }

        private void HandleCancel()
        {
            if (_processExitedCompletionSource.Task.IsCompleted)
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
                    _processExitedCompletionSource.TrySetException(ex);
                    return;
                }
            }

            TrySetCanceled();
        }

        private bool TrySetCanceled()
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _stdOutCompletionSource.TrySetCanceled(_cancellationToken);
                _stdErrCompletionSource.TrySetCanceled(_cancellationToken);
                _processExitedCompletionSource.TrySetCanceled(_cancellationToken);
            }

            return _cancellationToken.IsCancellationRequested;
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
