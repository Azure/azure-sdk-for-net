// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.EventHubs.Tests.Processor
{
    public class AsyncAutoResetEvent
    {
        readonly static Task<bool> CompletedTrueTask = Task.FromResult(true);
        readonly List<WaitTask> waiters;
        bool signaled;

        public AsyncAutoResetEvent(bool initialState)
        {
            this.signaled = initialState;
            this.waiters = new List<WaitTask>();
        }

        public Task<bool> WaitAsync(TimeSpan timeout)
        {
            lock (this.waiters)
            {
                if (this.signaled)
                {
                    this.signaled = false;
                    return CompletedTrueTask;
                }
                else
                {
                    var waiter = new WaitTask(this, timeout);
                    this.waiters.Add(waiter);
                    return waiter.Task;
                }
            }
        }

        public void Set()
        {
            WaitTask toRelease = null;
            lock (this.waiters)
            {
                if (this.waiters.Count > 0)
                {
                    toRelease = this.waiters[0];
                    this.waiters.RemoveAt(0);
                }
                else if (!this.signaled)
                {
                    this.signaled = true;
                }
            }

            if (toRelease != null)
            {
                toRelease.Set();
            }
        }

        class WaitTask : TaskCompletionSource<bool>
        {
            readonly AsyncAutoResetEvent asyncAutoResetEvent;
            readonly CancellationTokenSource cancellationTokenSource;

            public WaitTask(AsyncAutoResetEvent asyncAutoResetEvent, TimeSpan timeout)
            {
                this.asyncAutoResetEvent = asyncAutoResetEvent;

                if (timeout != TimeSpan.MaxValue && timeout != Timeout.InfiniteTimeSpan)
                {
                    this.cancellationTokenSource = new CancellationTokenSource(timeout);
                    this.cancellationTokenSource.Token.Register(s => CancellationCallback(s), this);
                }
            }

            public bool Set()
            {
                this.cancellationTokenSource?.Dispose();
                return this.TrySetResult(true);
            }

            static void CancellationCallback(object state)
            {
                var thisPtr = (WaitTask)state;
                thisPtr.cancellationTokenSource?.Dispose();

                bool removed;
                lock (thisPtr.asyncAutoResetEvent.waiters)
                {
                    removed = thisPtr.asyncAutoResetEvent.waiters.Remove(thisPtr);
                }

                if (removed)
                {
                    thisPtr.TrySetResult(false);
                }
            }
        }
    }
}
