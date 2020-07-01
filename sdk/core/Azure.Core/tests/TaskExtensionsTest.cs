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
            var awaiter = tcs.Task.WithCancellation(default).GetAwaiter();
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

            var awaiter = tcs.Task.WithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.AreEqual(8, awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_WithCancellationCanceled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var awaiter = tcs.Task.WithCancellation(cts.Token).GetAwaiter();

            Assert.AreEqual(true, awaiter.IsCompleted);
            Assert.Catch<OperationCanceledException>(() => awaiter.GetResult());
        }

        [Test]
        public void TaskExtensions_WithCancellationCanceledAfterContinuationScheduled()
        {
            var tcs = new TaskCompletionSource<int>();
            var cts = new CancellationTokenSource();
            var awaiter = tcs.Task.WithCancellation(cts.Token).GetAwaiter();
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
    }
}
