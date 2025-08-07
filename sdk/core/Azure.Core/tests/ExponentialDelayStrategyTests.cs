// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ExponentialDelayStrategyTests
    {
        [Test]
        public void ExponentialDelayIsWithinBoundsOfJitter()
        {
            var initialDelay = TimeSpan.FromSeconds(1);
            var strategy = DelayStrategy.CreateExponentialDelayStrategy(initialDelay, maxDelay: TimeSpan.MaxValue);
            var response = new MockResponse(400);
            for (int retryNumber = 1; retryNumber <= 30; retryNumber++)
            {
                AssertDelay(initialDelay, strategy.GetNextDelay(response, retryNumber), retryNumber);
            }
        }

        [Test]
        public void ExponentialDelayRespectsMaxValue()
        {
            var initialDelay = TimeSpan.FromSeconds(1);
            var maxDelay = TimeSpan.FromSeconds(10);
            var strategy = DelayStrategy.CreateExponentialDelayStrategy(initialDelay, maxDelay: maxDelay);
            var response = new MockResponse(400);
            var delay = strategy.GetNextDelay(response, 30);
            Assert.LessOrEqual(delay.TotalMilliseconds, maxDelay.TotalMilliseconds);
        }

        [Test]
        public void ExponentialDelayMillisecondsCanExceedMaxInt()
        {
            var initialDelay = TimeSpan.FromSeconds(1);
            var strategy = DelayStrategy.CreateExponentialDelayStrategy(initialDelay, maxDelay: TimeSpan.MaxValue);
            var response = new MockResponse(400);
            AssertDelay(initialDelay, strategy.GetNextDelay(response, 30), 30);
        }

        private static void AssertDelay(TimeSpan initialDelay, TimeSpan currentDelay, int retryNumber, TimeSpan? maxDelay = default)
        {
            var max = maxDelay ?? TimeSpan.MaxValue;
            Assert.GreaterOrEqual(
                currentDelay.TotalMilliseconds,
                Math.Pow((1 - DelayStrategy.DefaultJitterFactor), retryNumber) * (1 << (retryNumber - 1)) * initialDelay.TotalMilliseconds);
            Assert.LessOrEqual(
                currentDelay.TotalMilliseconds,
                Math.Min(max.TotalMilliseconds, Math.Pow(1 + DelayStrategy.DefaultJitterFactor, retryNumber) * (1 << (retryNumber - 1)) * initialDelay.TotalMilliseconds));
        }
    }
}
