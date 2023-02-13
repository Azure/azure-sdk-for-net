// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure.Messaging.WebPubSub.Clients;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class RetryPolicyTests
    {
        [Test]
        public void FixRetryModeTest()
        {
            var options = TestUtils.GetRetryOptions();
            options.Delay = TimeSpan.FromSeconds(5);
            options.Mode = Core.RetryMode.Fixed;
            options.MaxRetries = 5;
            var policy = new WebPubSubRetryPolicy(options);
            Assert.AreEqual(TimeSpan.FromSeconds(5), policy.NextRetryDelay(new RetryContext { RetryAttempt = 1 }));
            Assert.AreEqual(TimeSpan.FromSeconds(5), policy.NextRetryDelay(new RetryContext { RetryAttempt = 2 }));
            Assert.AreEqual(TimeSpan.FromSeconds(5), policy.NextRetryDelay(new RetryContext { RetryAttempt = 5 }));
            Assert.Null(policy.NextRetryDelay(new RetryContext { RetryAttempt = 6 }));
        }

        [Test]
        public void ExponentialRetryModeTest_CtorFailed()
        {
            var options = TestUtils.GetRetryOptions();
            options.Delay = TimeSpan.FromSeconds(5);
            options.MaxDelay = TimeSpan.FromSeconds(1);
            options.Mode = Core.RetryMode.Exponential;
            Assert.Throws<ArgumentException>(() => new WebPubSubRetryPolicy(options));
        }

        [Test]
        public void ExponentialRetryModeTest()
        {
            var options = TestUtils.GetRetryOptions();
            options.Delay = TimeSpan.FromSeconds(1);
            options.MaxDelay = TimeSpan.FromSeconds(14);
            options.Mode = Core.RetryMode.Exponential;
            options.MaxRetries = 7;
            var policy = new WebPubSubRetryPolicy(options);
            Assert.AreEqual(TimeSpan.FromSeconds(1), policy.NextRetryDelay(new RetryContext { RetryAttempt = 1 }));
            Assert.AreEqual(TimeSpan.FromSeconds(2), policy.NextRetryDelay(new RetryContext { RetryAttempt = 2 }));
            Assert.AreEqual(TimeSpan.FromSeconds(4), policy.NextRetryDelay(new RetryContext { RetryAttempt = 3 }));
            Assert.AreEqual(TimeSpan.FromSeconds(8), policy.NextRetryDelay(new RetryContext { RetryAttempt = 4 }));
            Assert.AreEqual(TimeSpan.FromSeconds(14), policy.NextRetryDelay(new RetryContext { RetryAttempt = 5 }));
            Assert.AreEqual(TimeSpan.FromSeconds(14), policy.NextRetryDelay(new RetryContext { RetryAttempt = 6 }));
            Assert.AreEqual(TimeSpan.FromSeconds(14), policy.NextRetryDelay(new RetryContext { RetryAttempt = 7 }));
            Assert.Null(policy.NextRetryDelay(new RetryContext { RetryAttempt = 8 }));
        }

        [Test]
        public void ExponentialRetryModeTest_BigNumber()
        {
            var options = TestUtils.GetRetryOptions();
            options.Delay = TimeSpan.FromTicks(long.MaxValue);
            options.MaxDelay = TimeSpan.FromTicks(long.MaxValue);
            options.Mode = Core.RetryMode.Exponential;
            options.MaxRetries = int.MaxValue;
            var policy = new WebPubSubRetryPolicy(options);
            Assert.AreEqual(TimeSpan.FromTicks(long.MaxValue), policy.NextRetryDelay(new RetryContext { RetryAttempt = 1 }));
            Assert.AreEqual(TimeSpan.FromTicks(long.MaxValue), policy.NextRetryDelay(new RetryContext { RetryAttempt = int.MaxValue }));
        }
    }
}
