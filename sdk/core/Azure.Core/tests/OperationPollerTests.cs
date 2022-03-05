// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.DelayStrategies
{
    internal class OperationPollerTests
    {
        [Test]
        public void ShouldDefaultToConstantFallback()
        {
            OperationPoller poller = new OperationPoller();
            var delayStrategy = poller.GetType().GetField("_delayStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(poller);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(typeof(RetryAfterDelayStrategy), delayStrategy.GetType());

            var fallbackStrategy = delayStrategy.GetType().GetField("_fallbackStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(delayStrategy);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(typeof(ConstantDelayStrategy), fallbackStrategy.GetType());
        }

        [Test]
        public void CanOverrideFallbackStrategy()
        {
            ExponentialDelayStrategy exponentialDelayStrategy = new ExponentialDelayStrategy();
            OperationPoller poller = new OperationPoller(exponentialDelayStrategy);
            var delayStrategy = poller.GetType().GetField("_delayStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(poller);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(typeof(RetryAfterDelayStrategy), delayStrategy.GetType());

            var fallbackStrategy = delayStrategy.GetType().GetField("_fallbackStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(delayStrategy);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(exponentialDelayStrategy, fallbackStrategy);
        }
    }
}
