// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class TaskExtensionsTest
    {
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
            using var continuationCalledEvent = new ManualResetEventSlim(false);
            var continuationCalled = 0;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() =>
            {
                Interlocked.Increment(ref continuationCalled);
                continuationCalledEvent.Set();
            });

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(0, continuationCalled);
            cts.Cancel();

            // The continuation is now scheduled asynchronously on the thread pool
            // to prevent StackOverflowException from deep synchronous call stacks.
            Assert.IsTrue(continuationCalledEvent.Wait(TimeSpan.FromSeconds(5)), "Continuation was not called within timeout");
            Assert.AreEqual(1, Volatile.Read(ref continuationCalled));
            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());

            tcs.SetResult(0);
            Assert.AreEqual(1, Volatile.Read(ref continuationCalled));
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
            using var continuationCalledEvent = new ManualResetEventSlim(false);
            var continuationCalled = 0;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() =>
            {
                Interlocked.Increment(ref continuationCalled);
                continuationCalledEvent.Set();
            });

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(0, continuationCalled);
            cts.Cancel();

            // The continuation is now scheduled asynchronously on the thread pool
            // to prevent StackOverflowException from deep synchronous call stacks.
            Assert.IsTrue(continuationCalledEvent.Wait(TimeSpan.FromSeconds(5)), "Continuation was not called within timeout");
            Assert.AreEqual(1, Volatile.Read(ref continuationCalled));
            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());

            tcs.SetResult(0);
            Assert.AreEqual(1, Volatile.Read(ref continuationCalled));
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

        [Test]
        public void TaskExtensions_CancellationDoesNotRunContinuationSynchronouslyOnCallerStack()
        {
            // Regression test for https://github.com/Azure/azure-sdk-for-net/issues/57412
            // Verifies that cancelling a token does not run AwaitWithCancellation continuations
            // synchronously on the CancellationTokenSource.Cancel() caller's stack, which would
            // cause StackOverflowException on constrained-stack environments.
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();

            int cancelThreadId = -1;
            int continuationThreadId = -1;
            using var continuationRanEvent = new ManualResetEventSlim(false);
            using var cancelCompletedEvent = new ManualResetEventSlim(false);

            awaiter.UnsafeOnCompleted(() =>
            {
                continuationThreadId = Environment.CurrentManagedThreadId;
                continuationRanEvent.Set();
            });

            var cancelThread = new Thread(() =>
            {
                cancelThreadId = Environment.CurrentManagedThreadId;
                cts.Cancel();
                cancelCompletedEvent.Set();
            });

            // Cancel on a dedicated thread; continuation should not run synchronously on that stack.
            cancelThread.Start();
            Assert.IsTrue(cancelCompletedEvent.Wait(TimeSpan.FromSeconds(5)), "Cancellation did not complete within timeout");
            cancelThread.Join();

            Assert.IsTrue(continuationRanEvent.Wait(TimeSpan.FromSeconds(5)), "Continuation was not called within timeout");

            // The continuation must have run on a different thread than the Cancel() caller's thread.
            Assert.AreNotEqual(cancelThreadId, continuationThreadId,
                "Continuation ran synchronously on the Cancel() caller's thread; this can cause StackOverflowException on constrained stacks");
        }

        [Test]
        public void TaskExtensions_CancellationContinuationProducesOperationCanceledException()
        {
            // End-to-end test: an async method awaiting AwaitWithCancellation should throw
            // OperationCanceledException when the token is cancelled, even with async scheduling.
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();

            async Task<int> AwaitWithCancellationAsync()
            {
                return await tcs.Task.AwaitWithCancellation(cts.Token);
            }

            var task = AwaitWithCancellationAsync();
            Assert.IsFalse(task.IsCompleted);

            cts.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await task);
        }

        [Test]
        public void TaskExtensions_NonGenericTask_CancellationDoesNotRunContinuationSynchronously()
        {
            // Same test as above but for the non-generic Task overload.
            var tcs = new TaskCompletionSource<bool>();
            var cts = new CancellationTokenSource();
            Task nonGenericTask = tcs.Task;
            var awaiter = nonGenericTask.AwaitWithCancellation(cts.Token).GetAwaiter();

            int cancelThreadId = -1;
            int continuationThreadId = -1;
            using var continuationRanEvent = new ManualResetEventSlim(false);
            using var cancelCompletedEvent = new ManualResetEventSlim(false);

            awaiter.UnsafeOnCompleted(() =>
            {
                continuationThreadId = Environment.CurrentManagedThreadId;
                continuationRanEvent.Set();
            });

            var cancelThread = new Thread(() =>
            {
                cancelThreadId = Environment.CurrentManagedThreadId;
                cts.Cancel();
                cancelCompletedEvent.Set();
            });

            cancelThread.Start();
            Assert.IsTrue(cancelCompletedEvent.Wait(TimeSpan.FromSeconds(5)), "Cancellation did not complete within timeout");
            cancelThread.Join();

            Assert.IsTrue(continuationRanEvent.Wait(TimeSpan.FromSeconds(5)), "Continuation was not called within timeout");
            Assert.AreNotEqual(cancelThreadId, continuationThreadId,
                "Continuation ran synchronously on the Cancel() caller's thread");
        }
    }
}
