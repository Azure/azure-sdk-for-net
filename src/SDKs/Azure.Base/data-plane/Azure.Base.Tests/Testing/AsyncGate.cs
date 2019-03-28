// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Base.Tests.Testing
{
    public class AsyncGate<TIn, TOut>
    {
        private TaskCompletionSource<TIn> _signalTaskCompletionSource = new TaskCompletionSource<TIn>(TaskCreationOptions.RunContinuationsAsynchronously);
        private TaskCompletionSource<TOut> _releaseTaskCompletionSource = new TaskCompletionSource<TOut>(TaskCreationOptions.RunContinuationsAsynchronously);

        public async Task<TIn> WaitForSignal()
        {
            return await _signalTaskCompletionSource.Task.TimeoutAfterDefault();
        }

        public async Task<TIn> Cycle(TOut value = default)
        {
            var signal = await WaitForSignal();
            Release(value);
            return signal;
        }

        public async Task<TIn> CycleWithException(Exception exception)
        {
            var signal = await WaitForSignal();
            ReleaseWithException(exception);
            return signal;
        }

        public void Release(TOut value = default)
        {
            Reset().SetResult(value);
        }

        public void ReleaseWithException(Exception exception)
        {
            Reset().SetException(exception);
        }

        private TaskCompletionSource<TOut> Reset()
        {
            if (!_signalTaskCompletionSource.Task.IsCompleted)
            {
                throw new InvalidOperationException("No await call to release");
            }

            var releaseTaskCompletionSource = _releaseTaskCompletionSource;
            _releaseTaskCompletionSource = new TaskCompletionSource<TOut>(TaskCreationOptions.RunContinuationsAsynchronously);
            _signalTaskCompletionSource = new TaskCompletionSource<TIn>(TaskCreationOptions.RunContinuationsAsynchronously);
            return releaseTaskCompletionSource;
        }

        public async Task<TOut> WaitForRelease(TIn value = default)
        {
            _signalTaskCompletionSource.SetResult(value);
            return await _releaseTaskCompletionSource.Task.TimeoutAfter(TimeSpan.FromSeconds(10));
        }
    }
}