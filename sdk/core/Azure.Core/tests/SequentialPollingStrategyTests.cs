// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.DelayStrategies
{
    internal class SequentialPollingStrategyTests
    {
        private static readonly MockResponse _mockResponse = new MockResponse(200);

        private static readonly int[] _expectedValues = new int[]
        {
            1,
            2,
            3,
            5,
            9,
            17,
            33,
            65,
            97,
            129
        };

        [Test]
        public void SequentialPollingFollowsExpectedSequence(
            [Values(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)] int retries)
        {
            var strategy = new SequentialDelayStrategy();
            var expected = TimeSpan.FromSeconds(_expectedValues[retries - 1]);
            TimeSpan actual = TimeSpan.Zero;
            for (int i = 0; i < retries; i++)
            {
                actual += strategy.GetNextDelay(_mockResponse, i + 1, default, new Dictionary<string, object>());
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
