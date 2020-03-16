// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable. Disposing of _process and _ctRegistration / _timeoutCtRegistration fields from outside may result in _tcs being incomplete or process handle leak.
    internal sealed class ProcessRunner
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private readonly IProcess _process;
        private readonly TaskCompletionSource<string> _tcs;
        private readonly CancellationToken _cancellationToken;
        private readonly CancellationToken _timeoutCancellationToken;
        private readonly CancellationTokenSource _timeoutCts;
        private readonly CancellationTokenRegistration _ctRegistration;
        private readonly CancellationTokenRegistration _timeoutCtRegistration;

        public ProcessRunner(IProcess process, TimeSpan timeout, CancellationToken cancellationToken)
        {
            _process = process;
            _cancellationToken = cancellationToken;
            _tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

            _ctRegistration = cancellationToken.Register(HandleCancel, false);
            if (timeout.TotalMilliseconds >= 0)
            {
                _timeoutCts = new CancellationTokenSource();
                _timeoutCancellationToken = _timeoutCts.Token;
                _timeoutCtRegistration = _timeoutCts.Token.Register(HandleCancel, false);
                _timeoutCts.CancelAfter(timeout);
            }

            process.Exited += (o, e) => HandleExit();
        }

        public Task<string> RunAsync()
        {
            if (!TrySetCanceled() && !_tcs.Task.IsCompleted)
            {
                _process.Start();
            }

            return _tcs.Task;
        }

        public string Run()
        {
            if (!TrySetCanceled() && !_tcs.Task.IsCompleted)
            {
                _process.Start();
            }

#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            return _tcs.Task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        private bool TrySetCanceled() => TrySetCanceled(_timeoutCancellationToken) || TrySetCanceled(_cancellationToken);

        private void HandleExit()
        {
            if (_process.ExitCode == 0)
            {
                TrySetResult(_process.StandardOutput.ReadToEnd());
            }
            else
            {
                TrySetException(new InvalidOperationException(_process.StandardError.ReadToEnd()));
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

        private void TrySetResult(string result)
        {
            DisposeProcess();
            _tcs.TrySetResult(result);
        }

        private bool TrySetCanceled(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                DisposeProcess();
                _tcs.TrySetCanceled(cancellationToken);
            }

            return cancellationToken.IsCancellationRequested;
        }

        private void TrySetException(Exception exception)
        {
            DisposeProcess();
            _tcs.TrySetException(exception);
        }

        private void DisposeProcess()
        {
            _process.Dispose();
            _ctRegistration.Dispose();
            _timeoutCts?.Dispose();
            _timeoutCtRegistration.Dispose();
        }
    }
}
