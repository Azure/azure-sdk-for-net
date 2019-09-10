// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public void IsEventDataEquivalentDetectsDifferentSystemPropertiesWithTypedMember()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var trackTwoOffset = 27;
            var trackTwoSystemProperties = new Dictionary<string, object>();

            var trackTwoEvent = new EventData(
                eventBody: (byte[])body.Clone(),
                offset: trackTwoOffset,
                systemProperties: trackTwoSystemProperties);

            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties[TrackOne.ClientConstants.OffsetName] = "4";

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsDifferentSystemPropertiesWithMissingTypedMember()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var trackTwoSystemProperties = new Dictionary<string, object>();

            var trackTwoEvent = new EventData(
                eventBody: (byte[])body.Clone(),
                systemProperties: trackTwoSystemProperties);

            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties[TrackOne.ClientConstants.OffsetName] = "4";

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsDifferentSystemPropertiesWithMapMember()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var propertyName = "Something";
            var trackTwoSystemProperties = new Dictionary<string, object>();

            var trackTwoEvent = new EventData(
                eventBody: (byte[])body.Clone(),
                systemProperties: trackTwoSystemProperties);

            trackTwoSystemProperties[propertyName] = nameof(trackTwoSystemProperties);

            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties[propertyName] = nameof(trackOneEvent);

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneComparer.IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsDifferentSystemPropertiesMismatchedMembers()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var propertyValue = "one";
            var trackTwoSystemProperties = new Dictionary<string, object>();

            var trackTwoEvent = new EventData(
                eventBody: (byte[])body.Clone(),
                systemProperties: trackTwoSystemProperties);

            trackTwoSystemProperties["two"] = propertyValue;

            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties["one"] = propertyValue;

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

            var trackTwoEvent = new EventData(
                eventBody: (byte[])body.Clone(),
                systemProperties: null);

            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties["something"] = "trackOne";

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsWhenLastSequenceNumberDiffers()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var offset = 27;
            var trackTwoSystemProperties = new Dictionary<string, object>();

            var trackTwoEvent = new EventData(
                eventBody: (byte[])body.Clone(),
                offset: offset,
                systemProperties: trackTwoSystemProperties,
                lastPartitionSequenceNumber: 9765551212,
                lastPartitionOffset: 54321,
                lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T00:00:00Z"));

            trackTwoEvent.Properties["test"] = "same";

            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            trackOneEvent.Properties["test"] = trackTwoEvent.Properties["test"];
            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties[TrackOne.ClientConstants.OffsetName] = offset.ToString();
            trackOneEvent.LastEnqueuedOffset = trackTwoEvent.LastPartitionOffset.ToString();
            trackOneEvent.LastSequenceNumber = 1;
            trackOneEvent.LastEnqueuedTime = trackTwoEvent.LastPartitionEnqueuedTime.Value.UtcDateTime;

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsWhenLastOffsetDiffers()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var offset = 27;
            var trackTwoSystemProperties = new Dictionary<string, object>();

            var trackTwoEvent = new EventData(
                eventBody: (byte[])body.Clone(),
                offset: offset,
                systemProperties: trackTwoSystemProperties,
                lastPartitionSequenceNumber: 9765551212,
                lastPartitionOffset: 54321,
                lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T00:00:00Z"));

            trackTwoEvent.Properties["test"] = "same";

            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            trackOneEvent.Properties["test"] = trackTwoEvent.Properties["test"];
            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties[TrackOne.ClientConstants.OffsetName] = offset.ToString();
            trackOneEvent.LastEnqueuedOffset = "1";
            trackOneEvent.LastSequenceNumber = trackTwoEvent.LastPartitionSequenceNumber.Value;;
            trackOneEvent.LastEnqueuedTime = trackTwoEvent.LastPartitionEnqueuedTime.Value.UtcDateTime;

            Assert.That(TrackOneComparer.IsEventDataEquivalent(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IsEventDataEquivalent" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEventDataEquivalentDetectsWhenLastEnqueuedTimeDiffers()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var offset = 27;
            var trackTwoSystemProperties = new Dictionary<string, object>();

            var trackTwoEvent = new EventData(
                eventBody: (byte[])body.Clone(),
                offset: offset,
                systemProperties: trackTwoSystemProperties,
                lastPartitionSequenceNumber: 9765551212,
                lastPartitionOffset: 54321,
                lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T00:00:00Z"));

            trackTwoEvent.Properties["test"] = "same";

            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            trackOneEvent.Properties["test"] = trackTwoEvent.Properties["test"];
            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties[TrackOne.ClientConstants.OffsetName] = offset.ToString();
            trackOneEvent.LastEnqueuedOffset = trackTwoEvent.LastPartitionOffset.ToString();
            trackOneEvent.LastSequenceNumber = trackTwoEvent.LastPartitionSequenceNumber.Value;;
            trackOneEvent.LastEnqueuedTime = DateTime.Parse("2012-03-04T08:46:00Z").ToUniversalTime();

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
            var offset = 27;
            var trackTwoSystemProperties = new Dictionary<string, object>();

            var trackTwoEvent = new EventData(
                eventBody: (byte[])body.Clone(),
                offset: offset,
                systemProperties: trackTwoSystemProperties,
                lastPartitionSequenceNumber: 9765551212,
                lastPartitionOffset: 54321,
                lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T00:00:00Z"));

            trackTwoEvent.Properties["test"] = "same";

            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            trackOneEvent.Properties["test"] = trackTwoEvent.Properties["test"];
            trackOneEvent.SystemProperties = new TrackOne.EventData.SystemPropertiesCollection();
            trackOneEvent.SystemProperties[TrackOne.ClientConstants.OffsetName] = offset.ToString();
            trackOneEvent.LastEnqueuedOffset = trackTwoEvent.LastPartitionOffset.ToString();
            trackOneEvent.LastSequenceNumber = trackTwoEvent.LastPartitionSequenceNumber.Value;
            trackOneEvent.LastEnqueuedTime = trackTwoEvent.LastPartitionEnqueuedTime.Value.UtcDateTime;

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
