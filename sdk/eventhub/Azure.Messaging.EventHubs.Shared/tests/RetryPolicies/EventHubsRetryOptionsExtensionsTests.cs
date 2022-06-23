// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubsRetryOptionsExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubsRetryOptionsExtensionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventHubsRetryOptions
            {
                Mode = EventHubsRetryMode.Fixed,
                MaximumRetries = 65,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromSeconds(2),
                TryTimeout = TimeSpan.FromSeconds(3),
                CustomRetryPolicy = Mock.Of<EventHubsRetryPolicy>()
            };

            EventHubsRetryOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.Mode, Is.EqualTo(options.Mode), "The mode of the clone should match.");
            Assert.That(clone.MaximumRetries, Is.EqualTo(options.MaximumRetries), "The maximum retry limit of the clone should match.");
            Assert.That(clone.Delay, Is.EqualTo(options.Delay), "The delay of the clone should match.");
            Assert.That(clone.MaximumDelay, Is.EqualTo(options.MaximumDelay), "The maximum delay of the clone should match.");
            Assert.That(clone.TryTimeout, Is.EqualTo(options.TryTimeout), "The per-try of the clone should match.");
            Assert.That(clone.CustomRetryPolicy, Is.SameAs(options.CustomRetryPolicy), "The custom retry policy should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToRetryPolicyWithoutCustomPolicyCreatesThePolicy()
        {
            var options = new EventHubsRetryOptions
            {
                Mode = EventHubsRetryMode.Fixed,
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
        ///   Verifies functionality of the <see cref="EventHubsRetryOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToRetryPolicyWithCustomPolicyUsesTheCustomPolicy()
        {
            var options = new EventHubsRetryOptions
            {
                Mode = EventHubsRetryMode.Fixed,
                MaximumRetries = 65,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromSeconds(2),
                TryTimeout = TimeSpan.FromSeconds(3),
                CustomRetryPolicy = Mock.Of<EventHubsRetryPolicy>()
            };

            var policy = options.ToRetryPolicy();
            Assert.That(policy, Is.Not.Null, "The policy should not be null.");
            Assert.That(policy, Is.SameAs(options.CustomRetryPolicy), "The custom retry policy should have been used.");
            Assert.That(policy, Is.Not.InstanceOf<BasicRetryPolicy>(), "The default policy type should not have been generated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsModes()
        {
            var first = new EventHubsRetryOptions { Mode = EventHubsRetryMode.Exponential };
            var second = new EventHubsRetryOptions { Mode = EventHubsRetryMode.Fixed };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsMaximumRetries()
        {
            var first = new EventHubsRetryOptions { MaximumRetries = 7 };
            var second = new EventHubsRetryOptions { MaximumRetries = 99 };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsMaximumDelay()
        {
            var first = new EventHubsRetryOptions { MaximumDelay = TimeSpan.FromSeconds(7) };
            var second = new EventHubsRetryOptions { MaximumDelay = TimeSpan.FromSeconds(8) };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsDelay()
        {
            var first = new EventHubsRetryOptions { Delay = TimeSpan.FromSeconds(7) };
            var second = new EventHubsRetryOptions { Delay = TimeSpan.FromMinutes(1) };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsTryTimeout()
        {
            var first = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(9) };
            var second = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(8) };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsCustomPolicy()
        {
            var first = new EventHubsRetryOptions { CustomRetryPolicy = Mock.Of<EventHubsRetryPolicy>() };
            var second = new EventHubsRetryOptions { CustomRetryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions()) };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsEqualOptionSets()
        {
            var customPolicy = Mock.Of<EventHubsRetryPolicy>();
            var first = new EventHubsRetryOptions { CustomRetryPolicy = customPolicy };
            var second = new EventHubsRetryOptions { CustomRetryPolicy = customPolicy };

            Assert.That(first.IsEquivalentTo(second), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsSameInstance()
        {
            var first = new EventHubsRetryOptions
            {
                Mode = EventHubsRetryMode.Fixed,
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromMinutes(3),
                Delay = TimeSpan.FromSeconds(4),
                TryTimeout = TimeSpan.Zero
            };

            Assert.That(first.IsEquivalentTo(first), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsTwoNulls()
        {
            Assert.That(((EventHubsRetryOptions)null).IsEquivalentTo(null), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullInstance()
        {
            var first = new EventHubsRetryOptions
            {
                Mode = EventHubsRetryMode.Fixed,
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromMinutes(3),
                Delay = TimeSpan.FromSeconds(4),
                TryTimeout = TimeSpan.Zero
            };

            Assert.That(((EventHubsRetryOptions)null).IsEquivalentTo(first), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsRetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullArgument()
        {
            var first = new EventHubsRetryOptions
            {
                Mode = EventHubsRetryMode.Fixed,
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromMinutes(3),
                Delay = TimeSpan.FromSeconds(4),
                TryTimeout = TimeSpan.Zero
            };

            Assert.That(first.IsEquivalentTo((EventHubsRetryOptions)null), Is.False);
        }
    }
}
