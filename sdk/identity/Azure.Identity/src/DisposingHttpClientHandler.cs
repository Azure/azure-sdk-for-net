// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// HTTP message handler that handles disposing itself only after in-flight requests complete.
    /// </summary>
    internal class DisposingHttpClientHandler : HttpClientHandler, IDisposable
    {
        private int _count;
        private TaskCompletionSource<Task> _zeroTcs =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public IDisposable StartSend()
        {
            var newCount = Interlocked.Increment(ref _count);
            if (newCount == 1)
            {
                // leaving zero -> ensure future waiters actually wait
                var tcs = Volatile.Read(ref _zeroTcs);
                if (tcs.Task.IsCompleted)
                {
                    Interlocked.CompareExchange(
                        ref _zeroTcs,
                        new TaskCompletionSource<Task>(TaskCreationOptions.RunContinuationsAsynchronously),
                        tcs);
                }
            }
            return new Releaser(this);
        }

        public void CompleteSend()
        {
            if (Interlocked.Decrement(ref _count) == 0)
            {
                Volatile.Read(ref _zeroTcs).TrySetResult(Task.CompletedTask);
            }
        }

        public Task WaitForOutstandingRequests() => Volatile.Read(ref _zeroTcs).Task;

        private sealed class Releaser : IDisposable
        {
            private DisposingHttpClientHandler _owner;
            public Releaser(DisposingHttpClientHandler owner) => _owner = owner;
            public void Dispose() { _owner?.CompleteSend(); _owner = null; }
        }
    }
}
