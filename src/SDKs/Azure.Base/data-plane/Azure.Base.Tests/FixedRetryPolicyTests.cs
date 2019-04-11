// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Pipeline;
using Azure.Base.Pipeline.Policies;
using Azure.Base.Testing;
using Azure.Base.Tests.Testing;
using NUnit.Framework;

namespace Azure.Base.Tests
{
    public class FixedRetryPolicyTests: RetryPolicyTestBase
    {
        [Test]
        public async Task WaitsBetweenRetries()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new [] { 500 });
            var policy = new FixedRetryPolicyMock(delay: TimeSpan.FromSeconds(3));
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            var delay = await policy.DelayGate.Cycle();
            Assert.AreEqual(delay, TimeSpan.FromSeconds(3));

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task WaitsSameAmountEveryTime()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new [] { 500 });
            var policy = new FixedRetryPolicyMock(delay: TimeSpan.FromSeconds(3), maxRetries: 3);
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy, responseClassifier);

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

        protected override (HttpPipelinePolicy, AsyncGate<TimeSpan, object>) CreateRetryPolicy(int maxRetries = 3)
        {
            var policy = new FixedRetryPolicyMock(maxRetries, TimeSpan.FromSeconds(3));
            return (policy, policy.DelayGate);
        }

        private class FixedRetryPolicyMock: FixedRetryPolicy
        {
            public AsyncGate<TimeSpan, object> DelayGate { get; } = new AsyncGate<TimeSpan, object>();

            public FixedRetryPolicyMock(int maxRetries = 3, TimeSpan delay = default)
            {
                Delay = delay;
                MaxRetries = maxRetries;
            }

            internal override Task DelayAsync(TimeSpan time, CancellationToken cancellationToken)
            {
                return DelayGate.WaitForRelease(time);
            }
        }
    }
}
