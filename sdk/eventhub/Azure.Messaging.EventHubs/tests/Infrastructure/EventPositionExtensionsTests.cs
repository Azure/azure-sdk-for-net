// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

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
        ///   Provides test cases for the equality tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> IsEquivalentToDetectsEqualEventPositionsCases()
        {
            var date = DateTimeOffset.Parse("1975-04-04T00:00:00Z");

            yield return new object[] { EventPosition.Earliest, EventPosition.Earliest };
            yield return new object[] { EventPosition.Latest, EventPosition.Latest };
            yield return new object[] { EventPosition.FromOffset(1975), EventPosition.FromOffset(1975) };
            yield return new object[] { EventPosition.FromSequenceNumber(42), EventPosition.FromSequenceNumber(42) };
            yield return new object[] { EventPosition.FromEnqueuedTime(date), EventPosition.FromEnqueuedTime(date) };
        }

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
        [TestCaseSource(nameof(IsEquivalentToDetectsEqualEventPositionsCases))]
        public void IsEquivalentToDetectsEqualEventPositions(EventPosition first, EventPosition second)
        {
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
