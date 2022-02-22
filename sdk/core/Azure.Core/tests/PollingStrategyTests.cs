// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [Parallelizable]
    public class PollingStrategyTests
    {
        private static readonly Response defaultMockResponse = new MockResponse(202);

        [Test]
        public void TestExponentialPollingStrategy([Values(true, false)] bool retryAfter)
        {
            var intervals = new int[] { 1, 1, 1, 2, 4, 8, 16, 32 };
            var random = new Random();

            var strategy = new ExponentialDelayStrategy();
            foreach (var interval in intervals)
            {
                Assert.AreEqual(interval, strategy.GetNextDelay(mockDefaultResponse(retryAfter), TimeSpan.FromSeconds(random.Next(0, 64))).TotalSeconds);
            }

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(32, strategy.GetNextDelay(mockDefaultResponse(retryAfter), TimeSpan.FromSeconds(random.Next(0, 64))).TotalSeconds);
            }
        }

        [Test]
        public void TestConstantlPollingStrategy(
            [Values(true, false)] bool retryAfter,
            [Values(1, 2, 3)] int initial,
            [Values(1, 2, 3)] int suggest)
        {
            var strategy = new ConstantDelayStrategy();

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(Math.Max(initial, suggest), strategy.GetNextDelay(mockDefaultResponse(retryAfter), TimeSpan.FromSeconds(suggest)).TotalSeconds);
            }
        }

        //[Test]
        //public void TestZerolPollingStrategy(
        //    [Values(true, false)] bool retryAfter,
        //    [Values(1, 2, 3)] int suggest)
        //{
        //    var strategy = new ZeroPollingStrategy();

        //    for (int i = 0; i < 6; i++)
        //    {
        //        Assert.AreEqual(0, strategy.GetNextWait(mockDefaultResponse(retryAfter), TimeSpan.FromSeconds(suggest)).TotalSeconds);
        //    }
        //}

        [Test]
        public void TestRetryAfterPollingStrategyWithHeader(
            [Values(1, 2, 3)] int retryAfter,
            [Values(1, 2, 3)] int suggest)
        {
            var strategy = new RetryAfterDelayStrategy(new ConstantDelayStrategy());

            Assert.AreEqual(Math.Max(retryAfter, suggest), strategy.GetNextDelay(mockWithRetryAfter(retryAfter), TimeSpan.FromSeconds(suggest)).TotalSeconds);
        }

        [Test]
        public void TestRetryAfterPollingStrategyWithoutHeader(
            [Values(1, 2, 3)] int initial,
            [Values(1, 2, 3)] int suggest)
        {
            var strategy = new RetryAfterDelayStrategy(new ConstantDelayStrategy());

            Assert.AreEqual(Math.Max(initial, suggest), strategy.GetNextDelay(defaultMockResponse, TimeSpan.FromSeconds(suggest)).TotalSeconds);
        }

        private static Response mockDefaultResponse(bool retryAfter)
        {
            return retryAfter ? mockWithRetryAfter(2) : defaultMockResponse;
        }

        private static Response mockWithRetryAfter(int retryAfter)
        {
            var response = new MockResponse(202);
            response.AddHeader("retry-after", retryAfter.ToString());
            return response;
        }
    }
}
