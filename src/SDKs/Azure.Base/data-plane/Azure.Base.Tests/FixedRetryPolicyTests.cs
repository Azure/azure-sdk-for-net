// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Http.Pipeline;
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
        public async Task WaitsSameAmountEveryTime()
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

        protected override (HttpPipelinePolicy, AsyncGate<TimeSpan, object>) CreateRetryPolicy(int[] retriableCodes, Func<Exception, bool> exceptionFilter = null, int maxRetries = 3)
        {
            var policy = new FixedRetryPolicyMock(retriableCodes, exceptionFilter, maxRetries, TimeSpan.FromSeconds(3));
            return (policy, policy.DelayGate);
        }

        private class FixedRetryPolicyMock: FixedRetryPolicy
        {
            public AsyncGate<TimeSpan, object> DelayGate { get; } = new AsyncGate<TimeSpan, object>();

            public FixedRetryPolicyMock(int[] retriableCodes, Func<Exception, bool> shouldRetryException = null, int maxRetries = 3, TimeSpan delay = default) : base(retriableCodes, shouldRetryException, maxRetries, delay)
            {
            }

            internal override Task Delay(TimeSpan time, CancellationToken cancellationToken)
            {
                return DelayGate.WaitForRelease(time);
            }
        }
    }
}
