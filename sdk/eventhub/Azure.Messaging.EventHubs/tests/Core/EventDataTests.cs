// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
        ///   Verifies functionality of the <see cref="EventData" /> constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDoesNotCreatePropertiesyDefault()
        {
            var eventData = new EventData(Array.Empty<byte>());

            Assert.That(GetPropertiesBackingStore(eventData), Is.Null, "The user properties should be created lazily.");
            Assert.That(eventData.SystemProperties, Is.SameAs(GetEmptySystemProperties()), "The system properties should be the static empty set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData" /> constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorHonorsPropertiesWhenPassed()
        {
            var properties = new Dictionary<string, object>();
            var systemProperties = (IReadOnlyDictionary<string, object>)new Dictionary<string, object>();

            var eventData = new EventData(
                eventBody: Array.Empty<byte>(),
                properties: properties,
                systemProperties: systemProperties);

            Assert.That(GetPropertiesBackingStore(eventData), Is.SameAs(properties), "The passed properties dictionary should have been used.");
            Assert.That(eventData.SystemProperties, Is.SameAs(systemProperties), "The system properties dictionary should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.Properties "/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ApplicationPropertiesDictionaryIsLazilyCreated()
        {
            var eventData = new EventData(Array.Empty<byte>());
            eventData.Properties.Add("test", "value");

            Assert.That(GetPropertiesBackingStore(eventData), Is.Not.Null, "The properties dictionary should have been crated on demand.");
            Assert.That(eventData.Properties.Count, Is.EqualTo(1), "The property that triggered creation should have been included in the set.");
        }

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
            Assert.That(streamData, Is.EqualTo(eventData.EventBody.ToArray()), "The body data and the data read from the stream should agree.");
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
        ///   Verifies functionality of the <see cref="EventData.CommitPublishingState "/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void CommitPublishingSequenceNumberTransitionsState()
        {
            var expectedSequence = 8675309;

            var eventData = new EventData(Array.Empty<byte>())
            {
                PendingPublishSequenceNumber = expectedSequence
            };

            Assert.That(eventData.PendingPublishSequenceNumber, Is.EqualTo(expectedSequence), "The pending sequence number should have been set.");

            eventData.CommitPublishingState();

            Assert.That(eventData.PublishedSequenceNumber, Is.EqualTo(expectedSequence), "The published sequence number should have been set.");
            Assert.That(eventData.PendingPublishSequenceNumber, Is.EqualTo(default(int?)), "The pending sequence number should have been cleared.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopyWhenPropertyDictionariesAreSet()
        {
            var sourceEvent = new EventData(
                new byte[] { 0x21, 0x22 },
                new Dictionary<string, object> { { "Test", 123 } },
                new Dictionary<string, object> { { "System", "Hello" } },
                33334444,
                666777,
                DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                "TestKey",
                111222,
                999888,
                DateTimeOffset.Parse("2012-03-04T09:00:00Z"),
                DateTimeOffset.Parse("2003-09-27T15:00:00Z"),
                787878,
                987654);

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
        public void CloneProducesACopyWhenPropertyDictionariesAreNotSet()
        {
            var sourceEvent = new EventData(
                new byte[] { 0x21, 0x22 },
                null,
                null,
                33334444,
                666777,
                DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                "TestKey",
                111222,
                999888,
                DateTimeOffset.Parse("2012-03-04T09:00:00Z"),
                DateTimeOffset.Parse("2003-09-27T15:00:00Z"),
                787878,
                987654);

            var clone = sourceEvent.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(GetPropertiesBackingStore(clone), Is.Null, "The user properties should be created lazily.");
            Assert.That(clone.SystemProperties, Is.SameAs(GetEmptySystemProperties()), "The system properties should be the static empty set.");
            Assert.That(clone.IsEquivalentTo(sourceEvent, false), Is.True, "The clone should be equivalent to the source event.");
            Assert.That(clone, Is.Not.SameAs(sourceEvent), "The clone should be a distinct reference.");
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
                new Dictionary<string, object> { { "Test", 123 } },
                new Dictionary<string, object> { { "System", "Hello" } },
                33334444,
                666777,
                DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                "TestKey",
                111222,
                999888,
                DateTimeOffset.Parse("2012-03-04T09:00:00Z"),
                DateTimeOffset.Parse("2003-09-27T15:00:00Z"),
                787878,
                987654);

            var clone = sourceEvent.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone.IsEquivalentTo(sourceEvent, true), Is.True, "The clone should be equivalent to the source event.");

            sourceEvent.Properties["Test"] = 999;
            sourceEvent.Properties.Add("New", "thing");
            Assert.That(clone.IsEquivalentTo(sourceEvent, true), Is.False, "The clone should no longer be equivalent to the source event; user properties were changed.");
        }

        /// <summary>
        ///   Retrieves the empty system properties dictionary from the Event Data
        ///   type, using its private field.
        /// </summary>
        ///
        /// <returns>The empty dictionary used as the default for the <see cref="EventData.SystemProperties" /> set.</returns>
        ///
        private static IReadOnlyDictionary<string, object> GetEmptySystemProperties() =>
            (IReadOnlyDictionary<string, object>)
                typeof(EventData)
                    .GetField("EmptySystemProperties", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);

        /// <summary>
        ///   Retrieves the backing store for the Properties dictionary from the Event Data
        ///   type, using its private field.
        /// </summary>
        ///
        /// <param name="eventData">The instance to read the field from.</param>
        ///
        /// <returns>The backing store for the <see cref="EventData.Properties" /> set.</returns>
        ///
        private static IReadOnlyDictionary<string, object> GetPropertiesBackingStore(EventData eventData) =>
            (IReadOnlyDictionary<string, object>)
                typeof(EventData)
                    .GetField("_properties", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(eventData);
    }
}
