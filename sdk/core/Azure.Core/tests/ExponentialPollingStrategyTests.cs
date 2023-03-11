// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.DelayStrategies
{
    internal class ExponentialPollingStrategyTests
    {
        private static readonly MockResponse _mockResponse = new MockResponse(200);

        [Test]
        public void WillIgnoreSuggest(
           [Values(90, 100, 120)] int suggest)
        {
            var strategy = new SequentialDelayStrategy();
            var expected = TimeSpan.FromSeconds(1);
            Assert.AreEqual(expected, strategy.GetNextDelay(_mockResponse, 1, TimeSpan.FromSeconds(suggest), default));
        }

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
        public void WillIgnoreSuggestMultipleIterations(
            [Values(1, 10, 100)] int suggestionInS,
            [Values(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)] int retries)
        {
            var strategy = new SequentialDelayStrategy();
            var suggestion = TimeSpan.FromSeconds(suggestionInS);
            var expected = TimeSpan.FromSeconds(_expectedValues[retries - 1]);
            TimeSpan actual = TimeSpan.Zero;
            for (int i = 0; i < retries; i++)
            {
                actual += strategy.GetNextDelay(_mockResponse, i + 1, suggestion, default);
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
