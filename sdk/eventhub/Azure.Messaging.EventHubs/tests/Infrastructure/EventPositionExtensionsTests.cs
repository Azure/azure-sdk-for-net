// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventPositionExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventPositionExtensionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventPositionExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsOffset()
        {
            var first = EventPosition.FromOffset(42);
            var second = EventPosition.FromOffset(1975);

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPositionExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsEnqueuedTime()
        {
            var first = EventPosition.FromEnqueuedTime(DateTimeOffset.UtcNow);
            var second = EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("1975-04-04T00:00:00Z"));

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPositionExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsSequenceNumber()
        {
            var first = EventPosition.FromSequenceNumber(42);
            var second = EventPosition.FromSequenceNumber(1975);

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPositionExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsInclusivity()
        {
            var first = EventPosition.FromSequenceNumber(42, true);
            var second = EventPosition.FromSequenceNumber(42, false);

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPositionExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsEqualEventPositions()
        {
            var first = EventPosition.FromOffset(1975);
            var second = EventPosition.FromOffset(1975);

            Assert.That(first.IsEquivalentTo(second), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPositionExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsSameInstance()
        {
            var first = EventPosition.FromOffset(1975);

            Assert.That(first.IsEquivalentTo(first), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPositionExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsTwoNulls()
        {
            Assert.That(((EventPosition)null).IsEquivalentTo(null), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPositionExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullInstance()
        {
            var first = EventPosition.FromOffset(1975);

            Assert.That(((EventPosition)null).IsEquivalentTo(first), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPositionExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullArgument()
        {
            var first = EventPosition.FromOffset(1975);

            Assert.That(first.IsEquivalentTo(null), Is.False);
        }
    }
}
