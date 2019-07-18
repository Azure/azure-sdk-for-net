// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Compatibility;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneEventHubProducer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TrackOneComparerTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsDifferentBodies()
        {
            var trackOneEvent = new TrackOne.EventData(new byte[] { 0x22, 0x44 });
            var trackTwoEvent = new EventData(new byte[] { 0x11, 0x33 });

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsDifferentProperties()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            var trackTwoEvent = new EventData((byte[])body.Clone());

            trackOneEvent.Properties["test"] = "trackOne";
            trackTwoEvent.Properties["test"] = "trackTwo";

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsWhenOnePropertySetIsNull()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            var trackTwoEvent = new EventData((byte[])body.Clone());

            trackOneEvent.Properties = null;
            trackTwoEvent.Properties["test"] = "trackTwo";

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsDifferentSystemProperties()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            var trackTwoEvent = new EventData((byte[])body.Clone());

            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties["something"] = "trackOne";

            trackTwoEvent.SystemProperties = new EventData.SystemEventProperties();
            trackTwoEvent.SystemProperties["something"] = "trackTwo";

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsWhenOneSystemPropertySetIsNull()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            var trackTwoEvent = new EventData((byte[])body.Clone());

            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties["something"] = "trackOne";

            trackTwoEvent.SystemProperties = null;

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsEqualEvents()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            var trackTwoEvent = new EventData((byte[])body.Clone());

            trackOneEvent.Properties["test"] = "same";
            trackTwoEvent.Properties["test"] = "same";

            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties["something"] = "otherSame";

            trackTwoEvent.SystemProperties = new EventData.SystemEventProperties();
            trackTwoEvent.SystemProperties["something"] = "otherSame";

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventPositionEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventPositionEquivalentDetectsDifferentOffsets()
        {
            var trackOnePosition = TrackOne.EventPosition.FromOffset("12", false);
            var trackTwoPosition = EventPosition.FromOffset(12);

            Assert.That(TrackOneComparer.IsEventPositionEquivalent(trackOnePosition, trackTwoPosition), Is.False, "The offset for track two is inclusive; even the same base offset with non-inclusive is not equivalent.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventPositionEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventPositionEquivalentRecognizesSameOffsets()
        {
            var trackOnePosition = TrackOne.EventPosition.FromOffset("12", true);
            var trackTwoPosition = EventPosition.FromOffset(12);

            Assert.That(TrackOneComparer.IsEventPositionEquivalent(trackOnePosition, trackTwoPosition), Is.True, "The offset for track two is inclusive; the equivalent offset set as inclusive should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventPositionEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventPositionEquivalentDetectsDifferentSequence()
        {
            var trackOnePosition = TrackOne.EventPosition.FromSequenceNumber(54123);
            var trackTwoPosition = EventPosition.FromSequenceNumber(2);

            Assert.That(TrackOneComparer.IsEventPositionEquivalent(trackOnePosition, trackTwoPosition), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventPositionEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventPositionEquivalentRecognizesSameSequence()
        {
            var trackOnePosition = TrackOne.EventPosition.FromSequenceNumber(54123);
            var trackTwoPosition = EventPosition.FromSequenceNumber(54123);

            Assert.That(TrackOneComparer.IsEventPositionEquivalent(trackOnePosition, trackTwoPosition), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventPositionEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventPositionEquivalentDetectsDifferentEnqueueTime()
        {
            var enqueueTime = DateTimeOffset.Parse("2015-10-27T12:00:00Z");
            var trackOnePosition = TrackOne.EventPosition.FromEnqueuedTime(enqueueTime.UtcDateTime);
            var trackTwoPosition = EventPosition.FromEnqueuedTime(enqueueTime.AddDays(1));

            Assert.That(TrackOneComparer.IsEventPositionEquivalent(trackOnePosition, trackTwoPosition), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventPositionEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventPositionEquivalentRecognizesSameEnqueueTime()
        {
            var enqueueTime = DateTimeOffset.Parse("2015-10-27T12:00:00Z");
            var trackOnePosition = TrackOne.EventPosition.FromEnqueuedTime(enqueueTime.UtcDateTime);
            var trackTwoPosition = EventPosition.FromEnqueuedTime(enqueueTime);

            Assert.That(TrackOneComparer.IsEventPositionEquivalent(trackOnePosition, trackTwoPosition), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventPositionEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventPositionEquivalentRecognizesSameBeginning()
        {
            var trackOnePosition = TrackOne.EventPosition.FromStart();
            var trackTwoPosition = EventPosition.Earliest;

            Assert.That(TrackOneComparer.IsEventPositionEquivalent(trackOnePosition, trackTwoPosition), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventPositionEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventPositionEquivalentRecognizesSameEnding()
        {
            var trackOnePosition = TrackOne.EventPosition.FromEnd();
            var trackTwoPosition = EventPosition.Latest;

            Assert.That(TrackOneComparer.IsEventPositionEquivalent(trackOnePosition, trackTwoPosition), Is.True);
        }
    }
}
