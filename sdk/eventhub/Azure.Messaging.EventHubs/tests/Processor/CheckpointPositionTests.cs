// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Processor;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="CheckpointPosition" />
    ///   struct.
    /// </summary>
    ///
    [TestFixture]
    public class CheckpointPositionTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesOffset(string offset)
        {
            if (offset == null)
            {
                Assert.That(() => new CheckpointPosition(offset), Throws.InstanceOf<ArgumentNullException>());
            }
            else
            {
                Assert.That(() => new CheckpointPosition(offset), Throws.InstanceOf<ArgumentException>());
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void TheSamePositionAreEqual()
        {
            var first = new CheckpointPosition("121");
            var second = new CheckpointPosition("121");

            Assert.That(first.Equals((object)second), Is.True, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.True, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.True, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.False, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition "/>
        ///   equality.
        /// </summary>
        [Test]
        public void TheSamePositionAreEqualWithSequenceNumber()
        {
            var first = new CheckpointPosition("44", 121);
            var second = new CheckpointPosition("44", 121);

            Assert.That(first.Equals((object)second), Is.True, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.True, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.True, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.False, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentPositionsAreNotEqual()
        {
            var first = new CheckpointPosition("10");
            var second = new CheckpointPosition("121");

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentPositionsAreNotEqualWithDifferentMembers()
        {
            var first = new CheckpointPosition("121");
            var second = new CheckpointPosition("121", 10);

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentPositionsAreNotEqualWithOffset()
        {
            var first = new CheckpointPosition("10");
            var second = new CheckpointPosition("121");

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition.GetHashCode "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetHashCodeReturnsDifferentValuesForDifferentMembers()
        {
            var first = new CheckpointPosition("10", 12);
            var second = new CheckpointPosition("121");

            Assert.That(first.GetHashCode(), Is.Not.EqualTo(second.GetHashCode()));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition.FromEvent(EventData) "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void FromEventSetsProperties()
        {
            var sequence = 4566;
            var eventData = new EventData(new BinaryData("Hello"), sequenceNumber: sequence, offset: "123");

            var checkpoint = CheckpointPosition.FromEvent(eventData);

            Assert.That(checkpoint.SequenceNumber, Is.EqualTo(sequence), "Sequence number should have been populated from the event.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition.ToString "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToStringReflectsTheState()
        {
            var offset = "121";
            var checkpoint = new CheckpointPosition(offset);

            Assert.That(checkpoint.ToString(), Contains.Substring($"[{offset}]"), "The offset should be represented.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition.ToString "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToStringReflectsTheStateWithSequenceNumber()
        {
            var offset = "121";
            var sequence = 10;
            var checkpoint = new CheckpointPosition(offset, sequence);

            Assert.That(checkpoint.ToString(), Contains.Substring($"[{offset}]"), "The offset should be represented.");
            Assert.That(checkpoint.ToString(), Contains.Substring($"[{sequence}]"), "The sequence number should be represented.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CheckpointPosition.ToString "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToStringReflectsTheStateFromEventData()
        {
            var offset = "400";
            var sequence = 121;
            var eventData = new EventData(new BinaryData("Hello"), sequenceNumber: sequence, offset: offset);

            var checkpoint = CheckpointPosition.FromEvent(eventData);

            Assert.That(checkpoint.ToString(), Contains.Substring($"[{sequence}]"), "The sequence should be represented.");
        }
    }
}
