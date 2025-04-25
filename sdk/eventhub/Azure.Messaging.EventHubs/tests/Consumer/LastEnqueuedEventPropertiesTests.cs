// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Consumer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="LastEnqueuedEventProperties" />
    ///   struct.
    /// </summary>
    ///
    [TestFixture]
    public class LastEnqueuedEventPropertiesTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="LastEnqueuedEventProperties "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void TheSameValuesAreEqual()
        {
            var now = DateTimeOffset.UtcNow;
            var first = new LastEnqueuedEventProperties(lastSequenceNumber: 123, lastOffsetString: "887", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);
            var second = new LastEnqueuedEventProperties(lastSequenceNumber: 123, lastOffsetString: "887", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);

            Assert.That(first.Equals((object)second), Is.True, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.True, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.True, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.False, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="LastEnqueuedEventProperties "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentOffsetsAreNotEqual()
        {
            var now = DateTimeOffset.UtcNow;
            var first = new LastEnqueuedEventProperties(lastSequenceNumber: 123, lastOffsetString: "999", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);
            var second = new LastEnqueuedEventProperties(lastSequenceNumber: 123, lastOffsetString: "888", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="LastEnqueuedEventProperties "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentEnqueueTimesAreNotEqual()
        {
            var now = DateTimeOffset.UtcNow;
            var first = new LastEnqueuedEventProperties(lastSequenceNumber: 123, lastOffsetString: "887", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);
            var second = new LastEnqueuedEventProperties(lastSequenceNumber: 123, lastOffsetString: "887", lastEnqueuedTime: DateTimeOffset.Parse("1974-12-09T21:30:00Z"), lastReceivedTime: now);

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="LastEnqueuedEventProperties "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentSequenceNumbersAreNotEqual()
        {
            var now = DateTimeOffset.UtcNow;
            var first = new LastEnqueuedEventProperties(lastSequenceNumber: 333, lastOffsetString: "887", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);
            var second = new LastEnqueuedEventProperties(lastSequenceNumber: 444, lastOffsetString: "887", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="LastEnqueuedEventProperties "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentLastReceiveTimesAreNotEqual()
        {
            var now = DateTimeOffset.UtcNow;
            var first = new LastEnqueuedEventProperties(lastSequenceNumber: 123, lastOffsetString: "887", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);
            var second = new LastEnqueuedEventProperties(lastSequenceNumber: 123, lastOffsetString: "887", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now.AddHours(1));

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="LastEnqueuedEventProperties.GetHashCode "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetHashCodeReturnsDifferentValuesForDifferentMembers()
        {
            var now = DateTimeOffset.UtcNow;
            var first = new LastEnqueuedEventProperties(lastSequenceNumber: 333, lastOffsetString: "888", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);
            var second = new LastEnqueuedEventProperties(lastSequenceNumber: 555, lastOffsetString: "777", lastEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastReceivedTime: now);

            Assert.That(first.GetHashCode(), Is.Not.EqualTo(second.GetHashCode()));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="LastEnqueuedEventProperties.ToString "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToStringReflectsTheState()
        {
            var offset = "123";
            var sequence = 778;
            var enqueued = DateTimeOffset.Now.AddHours(1);
            var received = DateTimeOffset.Now.AddHours(7);
            var properties = new LastEnqueuedEventProperties(sequence, offset, enqueued, received);
            var toStringValue = properties.ToString();

            Assert.That(toStringValue, Contains.Substring($"[{ offset }]"), "The offset should be represented.");
            Assert.That(toStringValue, Contains.Substring($"[{ sequence }]"), "The sequence number should be represented.");
            Assert.That(toStringValue, Contains.Substring($"[{ enqueued }]"), "The enqueued time should be represented.");
            Assert.That(toStringValue, Contains.Substring($"[{ received }]"), "The received time should be represented.");
        }
    }
}
