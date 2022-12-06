// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.DelayStrategies
{
    internal class ConstantDelayStrategyTests
    {
        private static readonly MockResponse _mockResponse = new MockResponse(200);

        [Test]
        public void WillHonorSuggest(
           [Values(90, 100, 120)] int suggest)
        {
            var strategy = new ConstantDelayStrategy();
            var expected = TimeSpan.FromSeconds(suggest);
            Assert.AreEqual(expected, strategy.GetNextDelay(_mockResponse, TimeSpan.FromSeconds(suggest)));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DefaultShouldUseOneSecond(int count)
        {
            var strategy = new ConstantDelayStrategy();
            TimeSpan total = TimeSpan.Zero;
            TimeSpan expected = TimeSpan.FromSeconds(count);

            for (int i=0; i < count; i++)
            {
                total += strategy.GetNextDelay(_mockResponse, null);
            }

            Assert.AreEqual(expected, total);
        }
    }
}
