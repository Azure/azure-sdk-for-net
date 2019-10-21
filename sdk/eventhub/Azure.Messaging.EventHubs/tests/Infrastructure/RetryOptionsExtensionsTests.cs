// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="RetryOptionsExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class RetryOptionsExtensionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsModes()
        {
            var first = new RetryOptions { Mode = RetryMode.Exponential };
            var second = new RetryOptions { Mode = RetryMode.Fixed };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsMaximumRetries()
        {
            var first = new RetryOptions { MaximumRetries = 7 };
            var second = new RetryOptions { MaximumRetries = 99 };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsMaximumDelay()
        {
            var first = new RetryOptions { MaximumDelay = TimeSpan.FromSeconds(7) };
            var second = new RetryOptions { MaximumDelay = TimeSpan.FromSeconds(8) };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsDelay()
        {
            var first = new RetryOptions { Delay = TimeSpan.FromSeconds(7) };
            var second = new RetryOptions { Delay = TimeSpan.FromMinutes(1) };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsTryTimeout()
        {
            var first = new RetryOptions { TryTimeout = TimeSpan.FromSeconds(9) };
            var second = new RetryOptions { TryTimeout = TimeSpan.FromSeconds(8) };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsCustomPolicy()
        {
            var first = new RetryOptions { CustomRetryPolicy = Mock.Of<EventHubRetryPolicy>() };
            var second = new RetryOptions { CustomRetryPolicy = new BasicRetryPolicy(new RetryOptions()) };

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsEqualOptionSets()
        {
            var customPolicy = Mock.Of<EventHubRetryPolicy>();
            var first = new RetryOptions { CustomRetryPolicy = customPolicy };
            var second = new RetryOptions { CustomRetryPolicy = customPolicy };

            Assert.That(first.IsEquivalentTo(second), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsSameInstance()
        {
            var first = new RetryOptions
            {
                Mode = RetryMode.Fixed,
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromMinutes(3),
                Delay = TimeSpan.FromSeconds(4),
                TryTimeout = TimeSpan.Zero
            };

            Assert.That(first.IsEquivalentTo(first), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsTwoNulls()
        {
            Assert.That(((RetryOptions)null).IsEquivalentTo(null), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullInstance()
        {
            var first = new RetryOptions
            {
                Mode = RetryMode.Fixed,
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromMinutes(3),
                Delay = TimeSpan.FromSeconds(4),
                TryTimeout = TimeSpan.Zero
            };

            Assert.That(((RetryOptions)null).IsEquivalentTo(first), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="RetryOptionsExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullArgument()
        {
            var first = new RetryOptions
            {
                Mode = RetryMode.Fixed,
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromMinutes(3),
                Delay = TimeSpan.FromSeconds(4),
                TryTimeout = TimeSpan.Zero
            };

            Assert.That(first.IsEquivalentTo((RetryOptions)null), Is.False);
        }
    }
}
