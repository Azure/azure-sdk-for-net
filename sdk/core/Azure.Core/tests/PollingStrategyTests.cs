// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [Parallelizable]
    public class PollingStrategyTests
    {
        [Test]
        public void TestExponentialPollingStrategy()
        {
            var strategy = new ExponentialPollingStrategy();
            for (int i = 0, j = 1; i < 6; i++, j *= 2)
            {
                Assert.AreEqual(j, strategy.PollingInterval.TotalSeconds);
            }

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(32, strategy.PollingInterval.TotalSeconds);
            }
        }

        [Test]
        public void TestDefaultConstantlPollingStrategy()
        {
            var strategy = new ConstantPollingStrategy();

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(1, strategy.PollingInterval.TotalSeconds);
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
