// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Core.TestFramework
{
    public class AsyncGate<TIn, TOut>
    {
        private readonly object _sync = new object();
        private TaskCompletionSource<TIn> _signal = new TaskCompletionSource<TIn>(TaskCreationOptions.RunContinuationsAsynchronously);
        private TaskCompletionSource<TOut> _release = new TaskCompletionSource<TOut>(TaskCreationOptions.RunContinuationsAsynchronously);

        // Called by tests
        public async Task<TIn> Cycle(TOut value = default)
        {
            TIn signal = await WaitForSignal();
            Release(value);
            return signal;
        }

        // Called by tests
        public async Task<TIn> CycleWithException(Exception exception)
        {
            TIn signal = await WaitForSignal();
            ReleaseWithException(exception);
            return signal;
        }

        private async Task<TIn> WaitForSignal()
        {
            return await _signal.Task.TimeoutAfterDefault();
        }

        private void Release(TOut value = default)
        {
            lock (_sync)
            {
                Reset().SetResult(value);
            }
        }

        private void ReleaseWithException(Exception exception)
        {
            lock (_sync)
            {
                Reset().SetException(exception);
            }
        }

        private TaskCompletionSource<TOut> Reset()
        {
            lock (_sync)
            {
                if (!_signal.Task.IsCompleted)
                {
                    throw new InvalidOperationException("No await call to release");
                }

                TaskCompletionSource<TOut> releaseTaskCompletionSource = _release;
                _release = new TaskCompletionSource<TOut>(TaskCreationOptions.RunContinuationsAsynchronously);
                _signal = new TaskCompletionSource<TIn>(TaskCreationOptions.RunContinuationsAsynchronously);
                return releaseTaskCompletionSource;
            }
        }

        // Called by types
        public Task<TOut> WaitForRelease(TIn value = default)
        {
            lock (_sync)
            {
                _signal.SetResult(value);
                return _release.Task.TimeoutAfterDefault();
            }
        }
    }
}
