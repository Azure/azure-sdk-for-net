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

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            awaiter.UnsafeOnCompleted(() => continuationCalled++);

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            Assert.That(continuationCalled, Is.EqualTo(0));
            tcs.SetResult(8);

            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.That(continuationCalled, Is.EqualTo(1));
            Assert.That(awaiter.GetResult(), Is.EqualTo(8));

            cts.Cancel();
            Assert.That(continuationCalled, Is.EqualTo(1));
        }

        [Test]
        public void TaskExtensions_TaskWithCancellationCompleted()
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = Task.FromResult(8).AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.That(awaiter.GetResult(), Is.EqualTo(8));
        }

        [Test]
        public void TaskExtensions_TaskWithCancellationCanceled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_TaskWithCancellationCanceledAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = 0;

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            awaiter.UnsafeOnCompleted(() => continuationCalled++);

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            Assert.That(continuationCalled, Is.EqualTo(0));
            cts.Cancel();

            Assert.That(continuationCalled, Is.EqualTo(1));
            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());

            tcs.SetResult(0);
            Assert.That(continuationCalled, Is.EqualTo(1));
        }

        [Test]
        public void TaskExtensions_TaskWithCancellationFailedAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = tcs.Task.AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = false;

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            awaiter.UnsafeOnCompleted(() => continuationCalled = true);

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            Assert.That(continuationCalled, Is.EqualTo(false));
            tcs.SetException(new OperationCanceledException("Error"));

            Assert.That(continuationCalled, Is.EqualTo(true));
            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult(), "Error");
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationDefault()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = new ValueTask<int>(tcs.Task).AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = 0;

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            awaiter.UnsafeOnCompleted(() => continuationCalled++);

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            Assert.That(continuationCalled, Is.EqualTo(0));
            tcs.SetResult(8);

            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.That(continuationCalled, Is.EqualTo(1));
            Assert.That(awaiter.GetResult(), Is.EqualTo(8));

            cts.Cancel();
            Assert.That(continuationCalled, Is.EqualTo(1));
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationCompleted()
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = new ValueTask<int>(8).AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.That(awaiter.GetResult(), Is.EqualTo(8));
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationCanceled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = new ValueTask<int>(tcs.Task).AwaitWithCancellation(cts.Token).GetAwaiter();

            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationCanceledAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = new ValueTask<int>(tcs.Task).AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = 0;

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            awaiter.UnsafeOnCompleted(() => continuationCalled++);

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            Assert.That(continuationCalled, Is.EqualTo(0));
            cts.Cancel();

            Assert.That(continuationCalled, Is.EqualTo(1));
            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());

            tcs.SetResult(0);
            Assert.That(continuationCalled, Is.EqualTo(1));
        }

        [Test]
        public void TaskExtensions_ValueTaskWithCancellationFailedAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = new ValueTask<int>(tcs.Task).AwaitWithCancellation(cts.Token).GetAwaiter();
            var continuationCalled = false;

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            awaiter.UnsafeOnCompleted(() => continuationCalled = true);

            Assert.That(awaiter.IsCompleted, Is.EqualTo(false));
            Assert.That(continuationCalled, Is.EqualTo(false));
            tcs.SetException(new OperationCanceledException("Error"));

            Assert.That(continuationCalled, Is.EqualTo(true));
            Assert.That(awaiter.IsCompleted, Is.EqualTo(true));
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult(), "Error");
        }
    }
}
