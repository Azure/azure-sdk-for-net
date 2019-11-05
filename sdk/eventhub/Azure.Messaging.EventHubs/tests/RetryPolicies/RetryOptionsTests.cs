// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="RetryOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class RetryOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new RetryOptions
            {
                Mode = RetryMode.Fixed,
                MaximumRetries = 65,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromSeconds(2),
                TryTimeout = TimeSpan.FromSeconds(3),
                CustomRetryPolicy = Mock.Of<EventHubRetryPolicy>()
            };

            RetryOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.Mode, Is.EqualTo(options.Mode), "The mode of the clone should match.");
            Assert.That(clone.MaximumRetries, Is.EqualTo(options.MaximumRetries), "The maximum retry limit of the clone should match.");
            Assert.That(clone.Delay, Is.EqualTo(options.Delay), "The delay of the clone should match.");
            Assert.That(clone.MaximumDelay, Is.EqualTo(options.MaximumDelay), "The maximum delay of the clone should match.");
            Assert.That(clone.TryTimeout, Is.EqualTo(options.TryTimeout), "The per-try of the clone should match.");
            Assert.That(clone.CustomRetryPolicy, Is.SameAs(options.CustomRetryPolicy), "The custom retry policy should match.");
        }

        /// <summary>
        ///  Verifies that setting the <see cref="RetryOptions.MaximumRetries" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-9999)]
        [TestCase(101)]
        [TestCase(106)]
        [TestCase(1000)]
        public void MaximumRetriesIsValidated(int invalidValue)
        {
            var options = new RetryOptions();
            Assert.That(() => options.MaximumRetries = invalidValue, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///  Verifies that setting the <see cref="RetryOptions.Delay" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(-9999)]
        [TestCase(301)]
        [TestCase(306)]
        [TestCase(500)]
        public void DelayIsValidated(int seconds)
        {
            var options = new RetryOptions();
            var invalidValue = TimeSpan.FromSeconds(seconds);
            Assert.That(() => options.Delay = invalidValue, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///  Verifies that setting the <see cref="RetryOptions.MaximumDelay" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-9999)]
        public void MaximumDelayIsValidated(int seconds)
        {
            var options = new RetryOptions();
            var invalidValue = TimeSpan.FromSeconds(seconds);
            Assert.That(() => options.MaximumDelay = invalidValue, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///  Verifies that setting the <see cref="RetryOptions.TryTimeout" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-9999)]
        [TestCase(3601)]
        [TestCase(3605)]
        [TestCase(5000)]
        public void TryTimeoutIsValidated(int seconds)
        {
            var options = new RetryOptions();
            var invalidValue = TimeSpan.FromSeconds(seconds);
            Assert.That(() => options.TryTimeout = invalidValue, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToRetryPolicyWithoutCustomPolicyCreatesThePolicy()
        {
            var options = new RetryOptions
            {
                Mode = RetryMode.Fixed,
                MaximumRetries = 65,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromSeconds(2),
                TryTimeout = TimeSpan.FromSeconds(3),
                CustomRetryPolicy = null
            };

            var policy = options.ToRetryPolicy();
            Assert.That(policy, Is.Not.Null, "The policy should not be null.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The options should produce a basic retry policy.");
            Assert.That(((BasicRetryPolicy)policy).Options, Is.SameAs(options), "The options should have been used for the retry policy.");
            Assert.That(policy, Is.Not.SameAs(options.CustomRetryPolicy), "The custom retry policy should not have been used, since it was not populated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToRetryPolicyWithCustomPolicyUsesTheCustomPolicy()
        {
            var options = new RetryOptions
            {
                Mode = RetryMode.Fixed,
                MaximumRetries = 65,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromSeconds(2),
                TryTimeout = TimeSpan.FromSeconds(3),
                CustomRetryPolicy = Mock.Of<EventHubRetryPolicy>()
            };

            var policy = options.ToRetryPolicy();
            Assert.That(policy, Is.Not.Null, "The policy should not be null.");
            Assert.That(policy, Is.SameAs(options.CustomRetryPolicy), "The custom retry policy should have been used.");
            Assert.That(policy, Is.Not.InstanceOf<BasicRetryPolicy>(), "The default policy type should not have been generated.");
        }
    }
}
