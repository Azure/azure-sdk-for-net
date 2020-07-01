// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Tests
{
    public class TaskExtensionsTest
    {
        [Test]
        public async Task TaskExtensions_WaitWithCancellationDefault()
        {
            var tcs = new TaskCompletionSource<int>();
            var waitTask = Task.Run(() => tcs.Task.WaitWithCancellation(default));
            Assert.AreEqual(false, waitTask.IsCompleted);

            tcs.SetResult(8);
            var result = await waitTask;

            Assert.AreEqual(8, result);
        }

        [Test]
        public async Task TaskExtensions_WaitWithCancellationCompleted()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            tcs.SetResult(8);
            cts.Cancel();

            var result = await Task.Run(() => tcs.Task.WaitWithCancellation(cts.Token));
            Assert.AreEqual(8, result);
        }

        [Test]
        public void TaskExtensions_WaitWithCancellationCanceled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            Assert.Catch<OperationCanceledException>(() => tcs.Task.WaitWithCancellation(cts.Token));
        }

        [Test]
        public void TaskExtensions_WaitWithCancellationCanceledAfterWait()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var waitTask = Task.Run(() => tcs.Task.WaitWithCancellation(cts.Token));
            Assert.AreEqual(false, waitTask.IsCompleted);

            cts.Cancel();
            Assert.CatchAsync<OperationCanceledException>(async () => await waitTask);
        }

        [Test]
        public void TaskExtensions_WaitWithCancellationFailedAfterWait()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var waitTask = Task.Run(() => tcs.Task.WaitWithCancellation(cts.Token));
            Assert.AreEqual(false, waitTask.IsCompleted);

            tcs.SetException(new OperationCanceledException("Error"));
            Assert.CatchAsync<OperationCanceledException>(async () => await waitTask, "Error");
        }

        [Test]
        public void TaskExtensions_WithCancellationDefault()
        {
            var tcs = new TaskCompletionSource<int>();
            var awaiter = tcs.Task.AwaitWithCancellation(default).GetAwaiter();
            var continuationCalled = false;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() => continuationCalled = true);

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(false, continuationCalled);
            tcs.SetResult(8);

            Assert.AreEqual(true, continuationCalled);
            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.AreEqual(8, awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_WithCancellationCompleted()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            tcs.SetResult(8);
            cts.Cancel();

            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.AreEqual(8, awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_WithCancellationCanceled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_WithCancellationCanceledAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = false;

            Assert.AreEqual(false, awaiter.IsCompleted);
            awaiter.UnsafeOnCompleted(() => continuationCalled = true);

            Assert.AreEqual(false, awaiter.IsCompleted);
            Assert.AreEqual(false, continuationCalled);
            cts.Cancel();

            Assert.AreEqual(true, continuationCalled);
            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_WithCancellationFailedAfterContinuationScheduled()
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
    }
}
