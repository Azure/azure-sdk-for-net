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

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DefaultFixedDelay(int count)
        {
            var strategy = Delay.CreateFixedDelay();
            TimeSpan total = TimeSpan.Zero;
            TimeSpan expected = TimeSpan.FromSeconds(0.8 * count);

            for (int i = 0; i < count; i++)
            {
                total += strategy.GetNextDelay(_mockResponse, i + 1, null, null);
            }

            Assert.That(total, Is.EqualTo(expected).Within(TimeSpan.FromSeconds(0.2 * count)));
        }
    }
}
