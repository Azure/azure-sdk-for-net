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
