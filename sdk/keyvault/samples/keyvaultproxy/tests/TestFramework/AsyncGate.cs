// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Core.TestFramework
{
    public class AsyncGate<TIn, TOut>
    {
        private readonly object _sync = new object();
        private TaskCompletionSource<TIn> _signalTaskCompletionSource = new TaskCompletionSource<TIn>(TaskCreationOptions.RunContinuationsAsynchronously);
        private TaskCompletionSource<TOut> _releaseTaskCompletionSource = new TaskCompletionSource<TOut>(TaskCreationOptions.RunContinuationsAsynchronously);

        public async Task<TIn> WaitForSignal()
        {
            return await _signalTaskCompletionSource.Task.TimeoutAfterDefault();
        }

        public async Task<TIn> Cycle(TOut value = default)
        {
            TIn signal = await WaitForSignal();
            Release(value);
            return signal;
        }

        public async Task<TIn> CycleWithException(Exception exception)
        {
            TIn signal = await WaitForSignal();
            ReleaseWithException(exception);
            return signal;
        }

        public void Release(TOut value = default)
        {
            lock (_sync)
            {
                Reset().SetResult(value);
            }
        }

        public void ReleaseWithException(Exception exception)
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
                if (!_signalTaskCompletionSource.Task.IsCompleted)
                {
                    throw new InvalidOperationException("No await call to release");
                }

                TaskCompletionSource<TOut> releaseTaskCompletionSource = _releaseTaskCompletionSource;
                _releaseTaskCompletionSource = new TaskCompletionSource<TOut>(TaskCreationOptions.RunContinuationsAsynchronously);
                _signalTaskCompletionSource = new TaskCompletionSource<TIn>(TaskCreationOptions.RunContinuationsAsynchronously);
                return releaseTaskCompletionSource;
            }
        }

        public Task<TOut> WaitForRelease(TIn value = default)
        {
            lock (_sync)
            {
                _signalTaskCompletionSource.SetResult(value);
                return _releaseTaskCompletionSource.Task.TimeoutAfterDefault();
            }
        }
    }
}
