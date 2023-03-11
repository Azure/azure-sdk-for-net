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
            var strategy = new FixedDelayStrategy();
            var expected = TimeSpan.FromSeconds(suggest);
            Assert.AreEqual(expected, strategy.GetNextDelay(_mockResponse, 1, TimeSpan.FromSeconds(suggest), null));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DefaultShouldUseOneSecond(int count)
        {
            var strategy = new FixedDelayStrategy();
            TimeSpan total = TimeSpan.Zero;
            TimeSpan expected = TimeSpan.FromSeconds(count);

            for (int i=0; i < count; i++)
            {
                total += strategy.GetNextDelay(_mockResponse, i + 1, null, null);
            }

            Assert.AreEqual(expected, total);
        }
    }
}
