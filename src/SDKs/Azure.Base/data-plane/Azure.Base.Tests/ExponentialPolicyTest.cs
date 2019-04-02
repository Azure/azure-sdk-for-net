﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class ExponentialPolicyTest: RetryPolicyTestBase
    {
        [Test]
        public async Task WaitsBetweenRetries()
        {
            var policy = new ExponentialRetryPolicyMock(retriableCodes: new [] { 500 }, delay: TimeSpan.FromSeconds(1), maxDelay: TimeSpan.FromSeconds(10));
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            var delay = await policy.DelayGate.Cycle();
            AssertExponentialDelay(TimeSpan.FromSeconds(1), delay);

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task WaitsSameAmountEveryTime()
        {
            var policy = new ExponentialRetryPolicyMock(retriableCodes: new [] { 500 }, maxRetries: 4, delay: TimeSpan.FromSeconds(1), maxDelay: TimeSpan.FromSeconds(10));
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy);
            var expectedDelaysInSeconds = new int[] { 1, 2, 4, 8 };

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            for (int i = 0; i < 4; i++)
            {
                var delay = await policy.DelayGate.Cycle();
                AssertExponentialDelay(TimeSpan.FromSeconds(expectedDelaysInSeconds[i]), delay);

                await mockTransport.RequestGate.Cycle(new MockResponse(500));
            }

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(500, response.Status);
        }

        [Test]
        public async Task RespectsMaxDelay()
        {
            var policy = new ExponentialRetryPolicyMock(retriableCodes: new [] { 500 }, maxRetries: 6, delay: TimeSpan.FromSeconds(1), maxDelay: TimeSpan.FromSeconds(5));
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy);
            var expectedDelaysInSeconds = new int[] { 1, 2, 4, 5, 5, 5 };

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            for (int i = 0; i < 6; i++)
            {
                var delay = await policy.DelayGate.Cycle();
                AssertExponentialDelay(TimeSpan.FromSeconds(expectedDelaysInSeconds[i]), delay);

                await mockTransport.RequestGate.Cycle(new MockResponse(500));
            }

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(500, response.Status);
        }

        private void AssertExponentialDelay(TimeSpan expected, TimeSpan actual)
        {
            // Expect maximum 25% variance
            Assert.LessOrEqual(Math.Abs(expected.TotalMilliseconds / actual.TotalMilliseconds - 1), 0.25, "Expected {0} to be around {1}", actual, expected);
        }

        protected override (HttpPipelinePolicy, AsyncGate<TimeSpan, object>) CreateRetryPolicy(int[] retriableCodes, Func<Exception, bool> exceptionFilter = null, int maxRetries = 3)
        {
            var policy = new ExponentialRetryPolicyMock(retriableCodes, exceptionFilter, maxRetries, TimeSpan.FromSeconds(3), maxDelay: TimeSpan.MaxValue);
            return (policy, policy.DelayGate);
        }

        private class ExponentialRetryPolicyMock: ExponentialRetryPolicy
        {
            public AsyncGate<TimeSpan, object> DelayGate { get; } = new AsyncGate<TimeSpan, object>();

            public ExponentialRetryPolicyMock(int[] retriableCodes, Func<Exception, bool> shouldRetryException = null, int maxRetries = 3, TimeSpan delay = default, TimeSpan maxDelay = default)
                : base(retriableCodes, shouldRetryException, maxRetries, delay, maxDelay)
            {
            }

            internal override Task Delay(TimeSpan time, CancellationToken cancellationToken)
            {
                return DelayGate.WaitForRelease(time);
            }
        }
    }
}