// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    public class RecordedTestBaseTests: RecordedTestBase
    {
        public RecordedTestBaseTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        public RecordedTestBaseTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            TestDiagnostics = false;
        }

        public override string AssetsJsonPath => null;

        [Test]
        [PlaybackOnly("Validates logic that only runs during the playback")]
        public async Task WaitForCompletionDoesntWaitDuringPlayback()
        {
            var client = InstrumentClient(new RecordedClient());

            var operation = await client.StartOperationAsync();

            var startTime = DateTimeOffset.Now;
            await operation.WaitForCompletionAsync();
            var timingPoint1 = DateTimeOffset.Now;

            await operation.WaitForCompletionAsync(TimeSpan.FromSeconds(10), default);
            var timingPoint2 = DateTimeOffset.Now;

            await operation.WaitForCompletionResponseAsync();
            var timingPoint3 = DateTimeOffset.Now;

            await operation.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(10), default);
            var timingPoint4 = DateTimeOffset.Now;

            Assert.That((timingPoint1 - startTime).TotalSeconds, Is.EqualTo(0).Within(0.3));
            Assert.That((timingPoint2 - timingPoint1).TotalSeconds, Is.EqualTo(0).Within(0.3));
            Assert.That((timingPoint3 - timingPoint2).TotalSeconds, Is.EqualTo(0).Within(0.3));
            Assert.That((timingPoint4 - timingPoint3).TotalSeconds, Is.EqualTo(0).Within(0.3));
        }

        [Test]
        [PlaybackOnly("Validates logic that only runs during the playback")]
        public async Task ThrowsForLowPollingIntervalInPlayback()
        {
            var client = InstrumentClient(new RecordedClient());

            var operation = await client.StartOperationAsync();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await operation.WaitForCompletionAsync(TimeSpan.FromSeconds(0.9), default));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await operation.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(0.9), default));
        }

        [Test]
        [LiveOnly]
        public async Task WaitForCompletionWaitsDuringLive()
        {
            var client = InstrumentClient(new RecordedClient());

            var operation = await client.StartOperationAsync();

            await operation.WaitForCompletionAsync();
            await operation.WaitForCompletionAsync(TimeSpan.FromSeconds(10), default);

            await operation.WaitForCompletionResponseAsync();
            await operation.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(10), default);

            var original = GetOriginal(operation);

            Assert.AreEqual(TimeSpan.MaxValue, original.WaitForCompletionCalls[0]);
            Assert.AreEqual(TimeSpan.FromSeconds(10), original.WaitForCompletionCalls[1]);

            Assert.AreEqual(TimeSpan.MaxValue, original.WaitForCompletionCalls[2]);
            Assert.AreEqual(TimeSpan.FromSeconds(10), original.WaitForCompletionCalls[3]);
        }

        [Test]
        public async Task WaitForCompletionErrorsArePropagated()
        {
            var client = InstrumentClient(new RecordedClient());

            var operation = await client.StartOperationAsync(true);

            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
        }

        public class RecordedClient
        {
            public virtual Task<CustomOperation> StartOperationAsync(bool throwOnWait = false)
            {
                return Task.FromResult(new CustomOperation(throwOnWait));
            }

            public virtual CustomOperation StartOperation(bool throwOnWait = false)
            {
                return new CustomOperation(throwOnWait);
            }
        }

        public class CustomOperation : Operation<int>
        {
            private readonly bool _throwOnWait;

            public CustomOperation(bool throwOnWait)
            {
                _throwOnWait = throwOnWait;
            }

            protected CustomOperation()
            {
            }

            public virtual List<TimeSpan?> WaitForCompletionCalls { get; } = new();
            public override string Id { get; }
            public override Response GetRawResponse()
            {
                return new MockResponse(200);
            }

            public override bool HasCompleted { get; } = true;
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            {
                if (_throwOnWait)
                {
                    throw new RequestFailedException(400, "Operation failed");
                }
                return new ValueTask<Response>(new MockResponse(20));
            }

            public override Response UpdateStatus(CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public override int Value { get; }
            public override bool HasValue { get; }
            public override ValueTask<Response<int>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            {
                return WaitForCompletionAsync(TimeSpan.MaxValue, cancellationToken);
            }

            public override ValueTask<Response<int>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            {
                WaitForCompletionCalls.Add(pollingInterval);
                if (_throwOnWait)
                {
                    throw new RequestFailedException(400, "Operation failed");
                }
                return new(Response.FromValue(0, new MockResponse(200)));
            }
        }
    }
}
