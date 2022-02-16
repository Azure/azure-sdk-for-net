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
        private static readonly Response mockPendingResponse = new MockResponse(202);

        [Test]
        public void TestExponentialPollingStrategy()
        {
            var intervals = new int[]{ 1, 1, 1, 2, 4, 8, 16, 32};

            var strategy = new ExponentialPollingStrategy();
            foreach (var interval in intervals)
            {
                Assert.AreEqual(interval, strategy.GetNextWait(mockPendingResponse).TotalSeconds);
            }

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(32, strategy.GetNextWait(mockPendingResponse).TotalSeconds);
            }
        }

        [Test]
        public void TestDefaultConstantlPollingStrategy()
        {
            var strategy = new ConstantPollingStrategy();

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(1, strategy.GetNextWait(mockPendingResponse).TotalSeconds);
            }
        }

        [TestCase(2)]
        [TestCase(3)]
        public void TestConstantlPollingStrategy(int interval)
        {
            var strategy = new ConstantPollingStrategy(TimeSpan.FromSeconds(interval));

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(interval, strategy.PollingInterval.TotalSeconds);
            }
        }
    }
}
