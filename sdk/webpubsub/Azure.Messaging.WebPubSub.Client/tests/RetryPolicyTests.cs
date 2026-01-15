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
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 1 }), Is.EqualTo(TimeSpan.FromSeconds(5)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 2 }), Is.EqualTo(TimeSpan.FromSeconds(5)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 5 }), Is.EqualTo(TimeSpan.FromSeconds(5)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 6 }), Is.Null);
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
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 1 }), Is.EqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 2 }), Is.EqualTo(TimeSpan.FromSeconds(2)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 3 }), Is.EqualTo(TimeSpan.FromSeconds(4)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 4 }), Is.EqualTo(TimeSpan.FromSeconds(8)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 5 }), Is.EqualTo(TimeSpan.FromSeconds(14)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 6 }), Is.EqualTo(TimeSpan.FromSeconds(14)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 7 }), Is.EqualTo(TimeSpan.FromSeconds(14)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 8 }), Is.Null);
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
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = 1 }), Is.EqualTo(TimeSpan.FromTicks(long.MaxValue)));
            Assert.That(policy.NextRetryDelay(new RetryContext { RetryAttempt = int.MaxValue }), Is.EqualTo(TimeSpan.FromTicks(long.MaxValue)));
        }
    }
}
