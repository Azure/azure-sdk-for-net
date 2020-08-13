// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Tests
{
    public class TaskExtensionsTest
    {
        [Test]
        public void TaskExtensions_TaskEnsureCompleted()
        {
            var task = Task.CompletedTask;
            task.EnsureCompleted();
        }

        [Test]
        public void TaskExtensions_TaskOfTEnsureCompleted()
        {
            var task = Task.FromResult(42);
            Assert.AreEqual(42, task.EnsureCompleted());
        }

        [Test]
        public void TaskExtensions_ValueTaskEnsureCompleted()
        {
            var task = new ValueTask();
            task.EnsureCompleted();
        }

        [Test]
        public void TaskExtensions_ValueTaskOfTEnsureCompleted()
        {
            var task = new ValueTask<int>(42);
            Assert.AreEqual(42, task.EnsureCompleted());
        }

        [Test]
        public async Task TaskExtensions_TaskEnsureCompleted_NotCompletedNoSyncContext()
        {
            var tcs = new TaskCompletionSource<int>();
            Task task = tcs.Task;
#if DEBUG
            Assert.Catch<InvalidOperationException>(() => task.EnsureCompleted());
            await Task.CompletedTask;
#else
            Task runningTask = Task.Run(() => task.EnsureCompleted());
            Assert.IsFalse(runningTask.IsCompleted);
            tcs.SetResult(0);
            await runningTask;
#endif
        }

        [Test]
        public async Task TaskExtensions_TaskOfTEnsureCompleted_NotCompletedNoSyncContext()
        {
            var tcs = new TaskCompletionSource<int>();
#if DEBUG
            Assert.Catch<InvalidOperationException>(() => tcs.Task.EnsureCompleted());
            await Task.CompletedTask;
#else
            Task<int> runningTask = Task.Run(() => tcs.Task.EnsureCompleted());
            Assert.IsFalse(runningTask.IsCompleted);
            tcs.SetResult(42);
            Assert.AreEqual(42, await runningTask);
#endif
        }

        [Test]
        public async Task TaskExtensions_ValueTaskEnsureCompleted_NotCompletedNoSyncContext()
        {
            var tcs = new TaskCompletionSource<int>();
            ValueTask task = new ValueTask(tcs.Task);
#if DEBUG
            Assert.Catch<InvalidOperationException>(() => task.EnsureCompleted());
            await Task.CompletedTask;
#else
            Task runningTask = Task.Run(() => task.EnsureCompleted());
            Assert.IsFalse(runningTask.IsCompleted);
            tcs.SetResult(0);
            await runningTask;
#endif
        }

        [Test]
        public async Task TaskExtensions_ValueTaskOfTEnsureCompleted_NotCompletedNoSyncContext()
        {
            var tcs = new TaskCompletionSource<int>();
            ValueTask<int> task = new ValueTask<int>(tcs.Task);
#if DEBUG
            Assert.Catch<InvalidOperationException>(() => task.EnsureCompleted());
            await Task.CompletedTask;
#else
            Task<int> runningTask = Task.Run(() => task.EnsureCompleted());
            Assert.IsFalse(runningTask.IsCompleted);
            tcs.SetResult(42);
            Assert.AreEqual(42, await runningTask);
#endif
        }

        [Test]
        public void TaskExtensions_TaskEnsureCompleted_NotCompletedInSyncContext()
        {
            using SingleThreadedSynchronizationContext syncContext = new SingleThreadedSynchronizationContext();
            var tcs = new TaskCompletionSource<int>();
            Task task = tcs.Task;

            syncContext.Post(t => { Assert.Catch<InvalidOperationException>(() => task.EnsureCompleted()); }, null);
        }

        [Test]
        public void TaskExtensions_TaskOfTEnsureCompleted_NotCompletedInSyncContext()
        {
            using SingleThreadedSynchronizationContext syncContext = new SingleThreadedSynchronizationContext();
            var tcs = new TaskCompletionSource<int>();

            syncContext.Post(t => { Assert.Catch<InvalidOperationException>(() => tcs.Task.EnsureCompleted()); }, null);
        }

        [Test]
        public void TaskExtensions_ValueTaskEnsureCompleted_NotCompletedInSyncContext()
        {
            using SingleThreadedSynchronizationContext syncContext = new SingleThreadedSynchronizationContext();
            var tcs = new TaskCompletionSource<int>();
            ValueTask task = new ValueTask(tcs.Task);

            syncContext.Post(t => { Assert.Catch<InvalidOperationException>(() => task.EnsureCompleted()); }, null);
        }

        [Test]
        public void TaskExtensions_ValueTaskOfTEnsureCompleted_NotCompletedInSyncContext()
        {
            using SingleThreadedSynchronizationContext syncContext = new SingleThreadedSynchronizationContext();
            var tcs = new TaskCompletionSource<int>();
            var task = new ValueTask<int>(tcs.Task);

            syncContext.Post(t => { Assert.Catch<InvalidOperationException>(() => task.EnsureCompleted()); }, null);
        }

        [Test]
        public void TaskExtensions_TaskWithCancellationDefault()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = 0;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() => continuationCalled++);

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(0, continuationCalled);
            tcs.SetResult(8);

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.AreEqual(1, continuationCalled);
            Assert.AreEqual(8, awaiter.GetResult());

            cts.Cancel();
            Assert.AreEqual(1, continuationCalled);
        }

        [Test]
        public void TaskExtensions_TaskWithCancellationCompleted()
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = Task.FromResult(8).AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.AreEqual(8, awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_TaskWithCancellationCanceled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_TaskWithCancellationCanceledAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = 0;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() => continuationCalled++);

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(0, continuationCalled);
            cts.Cancel();

            Assert.AreEqual(1, continuationCalled);
            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());

            tcs.SetResult(0);
            Assert.AreEqual(1, continuationCalled);
        }

        [Test]
        public void TaskExtensions_TaskWithCancellationFailedAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = false;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() => continuationCalled = true);

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(false, continuationCalled);
            tcs.SetException(new OperationCanceledException("Error"));

            Assert.AreEqual(true, continuationCalled);
            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult(), "Error");
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationDefault()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = new ValueTask<int>(tcs.Task).AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = 0;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() => continuationCalled++);

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(0, continuationCalled);
            tcs.SetResult(8);

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.AreEqual(1, continuationCalled);
            Assert.AreEqual(8, awaiter.GetResult());

            cts.Cancel();
            Assert.AreEqual(1, continuationCalled);
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationCompleted()
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = new ValueTask<int>(8).AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.AreEqual(8, awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationCanceled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = new ValueTask<int>(tcs.Task).AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationCanceledAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = new ValueTask<int>(tcs.Task).AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = 0;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() => continuationCalled++);

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(0, continuationCalled);
            cts.Cancel();

            Assert.AreEqual(1, continuationCalled);
            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());

            tcs.SetResult(0);
            Assert.AreEqual(1, continuationCalled);
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationFailedAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = new ValueTask<int>(tcs.Task).AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = false;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() => continuationCalled = true);

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(false, continuationCalled);
            tcs.SetException(new OperationCanceledException("Error"));

            Assert.AreEqual(true, continuationCalled);
            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult(), "Error");
        }

        private sealed class SingleThreadedSynchronizationContext : SynchronizationContext, IDisposable
        {
            private readonly Task _task;
            private readonly BlockingCollection<Action> _queue;
            private readonly ConcurrentQueue<Exception> _exceptions;

            public SingleThreadedSynchronizationContext()
            {
                _queue = new BlockingCollection<Action>();
                _exceptions = new ConcurrentQueue<Exception>();
                _task = Task.Run(RunLoop);
            }

            private void RunLoop()
            {
                try
                {
                    SetSynchronizationContext(this);
                    while (!_queue.IsCompleted)
                    {
                        Action action = _queue.Take();
                        try
                        {
                            action();
                        }
                        catch (Exception e)
                        {
                            _exceptions.Enqueue(e);
                        }
                    }
                }
                catch (InvalidOperationException) { }
                catch (OperationCanceledException) { }
                finally
                {
                    SetSynchronizationContext(null);
                }
            }

            public override void Post(SendOrPostCallback d, object state) => _queue.Add(() => d(state));

            public void Dispose()
            {
                _queue.CompleteAdding();
                _task.Wait();
            }

            public AggregateException Exceptions => new AggregateException(_exceptions);
        }
    }
}
