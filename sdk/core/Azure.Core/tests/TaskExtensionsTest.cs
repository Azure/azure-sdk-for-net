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
        public void TaskExtensions_WithCancellationDefault()
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
        public void TaskExtensions_WithCancellationCompleted()
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = new ValueTask<int>(8).AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.AreEqual(8, awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_WithCancellationCanceled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = new ValueTask<int>(tcs.Task).AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_WithCancellationCanceledAfterContinuationScheduled()
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
        public void TaskExtensions_WithCancellationFailedAfterContinuationScheduled()
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
    }
}
