// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventData" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventDataTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.BodyAsStream "/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void BodyAsStreamReturnsTheBody()
        {
            var eventData = new EventData(new byte[] { 0x11, 0x22, 0x65, 0x78 });

            using var eventDataStream = eventData.BodyAsStream;
            using var bodyStream = new MemoryStream();
            eventDataStream.CopyTo(bodyStream);

            var streamData = bodyStream.ToArray();
            Assert.That(streamData, Is.Not.Null, "There should have been data in the stream.");
            Assert.That(streamData, Is.EqualTo(eventData.Body.ToArray()), "The body data and the data read from the stream should agree.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.BodyAsStream "/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void BodyAsStreamAllowsAnEmptyBody()
        {
            var eventData = new EventData(Array.Empty<byte>());

            using var eventDataStream = eventData.BodyAsStream;
            using var bodyStream = new MemoryStream();
            eventDataStream.CopyTo(bodyStream);

            var streamData = bodyStream.ToArray();
            Assert.That(streamData, Is.Not.Null, "There should have been data in the stream.");
            Assert.That(streamData.Length, Is.EqualTo(0), "The stream should have contained no data.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var sourceEvent = new EventData(
                new byte[] { 0x21, 0x22 },
                new Dictionary<string, object> { {"Test", 123 } },
                new Dictionary<string, object> { { "System", "Hello" }},
                33334444,
                666777,
                DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                "TestKey",
                111222,
                999888,
                DateTimeOffset.Parse("2012-03-04T09:00:00Z"),
                DateTimeOffset.Parse("2003-09-27T15:00:00Z"));

            var clone = sourceEvent.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone.IsEquivalentTo(sourceEvent, true), Is.True, "The clone should be equivalent to the source event.");
            Assert.That(clone, Is.Not.SameAs(sourceEvent), "The clone should be a distinct reference.");
            Assert.That(object.ReferenceEquals(clone.Properties, sourceEvent.Properties), Is.False, "The clone's property bag should be a distinct reference.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneIsolatesPropertyChanges()
        {
            var sourceEvent = new EventData(
                new byte[] { 0x21, 0x22 },
                new Dictionary<string, object> { {"Test", 123 } },
                new Dictionary<string, object> { { "System", "Hello" }},
                33334444,
                666777,
                DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                "TestKey",
                111222,
                999888,
                DateTimeOffset.Parse("2012-03-04T09:00:00Z"),
                DateTimeOffset.Parse("2003-09-27T15:00:00Z"));

            var clone = sourceEvent.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone.IsEquivalentTo(sourceEvent, true), Is.True, "The clone should be equivalent to the source event.");

            sourceEvent.Properties["Test"] = 999;
            sourceEvent.Properties.Add("New", "thing");
            Assert.That(clone.IsEquivalentTo(sourceEvent, true), Is.False, "The clone should no longer be equivalent to the source event; user properties were changed.");
        }
    }
}
