// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using Azure.Base.Testing;
using NUnit.Framework;

namespace Azure.Base.Tests
{
    public class FixedRetryPolicyTests
    {
        [Test]
        public async Task WaitsBetweenRetries()
        {
            var policy = new FixedRetryPolicyMock(retriableCodes: new [] { 500 }, delay: TimeSpan.FromSeconds(3));
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            var delay = await policy.DelayGate.Cycle();
            Assert.AreEqual(delay, TimeSpan.FromSeconds(3));

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task DoesNotExceedRetryCount()
        {
            var policy = new FixedRetryPolicyMock(retriableCodes: new [] { 500 }, delay: TimeSpan.FromSeconds(3), maxRetries: 3);
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            for (int i = 0; i < 3; i++)
            {
                var delay = await policy.DelayGate.Cycle();
                Assert.AreEqual(delay, TimeSpan.FromSeconds(3));

                await mockTransport.RequestGate.Cycle(new MockResponse(500));
            }

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(500, response.Status);
        }

        [Test]
        public async Task OnlyRetriesRetriebleCodes()
        {
            var policy = new FixedRetryPolicyMock(retriableCodes: new [] { 500 }, delay: TimeSpan.FromSeconds(3), maxRetries: 3);
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            var delay = await policy.DelayGate.Cycle();
            Assert.AreEqual(delay, TimeSpan.FromSeconds(3));

            await mockTransport.RequestGate.Cycle(new MockResponse(501));

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(501, response.Status);
        }

        [Test]
        public async Task RetriesOnException()
        {
            var policy = new FixedRetryPolicyMock(retriableCodes: new [] { 500 }, delay: TimeSpan.FromSeconds(3));
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy);

            await mockTransport.RequestGate.CycleWithException(new InvalidOperationException());

            var delay = await policy.DelayGate.Cycle();
            Assert.AreEqual(delay, TimeSpan.FromSeconds(3));

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task RethrowsAggregateExceptionAfterMaxRetryCount()
        {
            var policy = new FixedRetryPolicyMock(retriableCodes: new [] { 500 }, delay: TimeSpan.FromSeconds(3), maxRetries: 3);
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy);
            var exceptions = new List<Exception>();

            exceptions.Add(new InvalidOperationException());
            await mockTransport.RequestGate.CycleWithException(exceptions.Last());

            for (int i = 0; i < 3; i++)
            {
                var delay = await policy.DelayGate.Cycle();
                Assert.AreEqual(delay, TimeSpan.FromSeconds(3));

                exceptions.Add(new InvalidOperationException());
                await mockTransport.RequestGate.CycleWithException(exceptions.Last());
            }

            var exception = Assert.ThrowsAsync<AggregateException>(async () => await task.TimeoutAfterDefault());
            StringAssert.StartsWith("Retry failed after 4 tries.", exception.Message);
            CollectionAssert.AreEqual(exceptions, exception.InnerExceptions);
        }

        [Test]
        public void DoesntMutateOriginalArray()
        {
            var codes = new[] { 1, 500, 0 };
            _ = new FixedRetryPolicyMock(retriableCodes: codes);

            CollectionAssert.AreEqual(new[] {1, 500, 0}, codes);
        }

        private static Task<Response> SendRequest(MockTransport mockTransport, FixedRetryPolicyMock policy)
        {
            var options = new HttpPipelineOptions(mockTransport);
            options.RetryPolicy = policy;

            var pipeline = options.Build(typeof(FixedRetryPolicyTests).Assembly);

            var httpPipelineRequest = pipeline.CreateRequest();
            httpPipelineRequest.SetRequestLine(HttpVerb.Get, new Uri("http://example.com/"));

            return pipeline.SendRequestAsync(httpPipelineRequest, CancellationToken.None);
        }

        private class FixedRetryPolicyMock: FixedPolicy
        {
            public AsyncGate<TimeSpan, object> DelayGate { get; } = new AsyncGate<TimeSpan, object>();

            public FixedRetryPolicyMock(int[] retriableCodes, int maxRetries = 3, TimeSpan delay = default) : base(retriableCodes, maxRetries, delay)
            {
            }

            protected override Task Delay(TimeSpan time, CancellationToken cancellationToken)
            {
                return DelayGate.WaitForRelease(time);
            }
        }
    }
}
