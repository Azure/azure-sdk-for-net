// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Azure.Core.Amqp;
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
        public void ConstructorDoesNotCreatePropertiesByDefault()
        {
            var eventData = new EventData(new BinaryData(Array.Empty<byte>()));

            Assert.That(eventData.GetRawAmqpMessage().HasSection(AmqpMessageSection.ApplicationProperties), Is.False, "The user properties should be created lazily.");
            Assert.That(GetSystemPropertiesBackingStore(eventData), Is.Null, "The system properties should be the static empty set.");
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
                eventBody: new BinaryData(Array.Empty<byte>()),
                properties: properties,
                systemProperties: systemProperties);

            Assert.That(eventData.Properties, Is.EquivalentTo(properties), "The passed properties dictionary should have been used.");
            Assert.That(eventData.SystemProperties, Is.SameAs(systemProperties), "The system properties dictionary should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.Properties "/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void SystemPropertiesDictionaryIsLazilyCreated()
        {
            var eventData = new EventData(new BinaryData(Array.Empty<byte>()));
            eventData.SystemProperties.ContainsKey("fake");

            Assert.That(GetSystemPropertiesBackingStore(eventData), Is.Not.Null, "The system properties dictionary should have been crated on demand.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData" />
        ///   mutable properties.
        /// </summary>
        ///
        [Test]
        public void ReadingUnpopulatedMutablePropertiesDoesNotCreateTheSection()
        {
            var amqpMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));
            var eventData = new EventData(amqpMessage);

            Assert.That(eventData.MessageId, Is.Null, "The message identifier should not be populated.");
            Assert.That(amqpMessage.HasSection(AmqpMessageSection.Properties), Is.False, "Reading the message identifier should not create the section.");

            Assert.That(eventData.CorrelationId, Is.Null, "The correlation identifier should not be populated.");
            Assert.That(amqpMessage.HasSection(AmqpMessageSection.Properties), Is.False, "Reading the correlation identifier should not create the section.");

            Assert.That(eventData.ContentType, Is.Null, "The content type should not be populated.");
            Assert.That(amqpMessage.HasSection(AmqpMessageSection.Properties), Is.False, "Reading the content type should not create the section.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData" />
        ///   mutable properties.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void DefaultingUnpopulatedMutablePropertiesDoesNotCreateTheSection(string defaultValue)
        {
            var amqpMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));
            var eventData = new EventData(amqpMessage);

            eventData.MessageId = null;
            Assert.That(amqpMessage.HasSection(AmqpMessageSection.Properties), Is.False, "Setting an empty value for the message identifier should not create the section.");
            Assert.That(eventData.MessageId, Is.Null, "The message identifier should not be populated.");

            eventData.CorrelationId = null;
            Assert.That(amqpMessage.HasSection(AmqpMessageSection.Properties), Is.False, "Setting an empty value for the correlation identifier should not create the section.");
            Assert.That(eventData.CorrelationId, Is.Null, "The correlation identifier should not be populated.");

            eventData.ContentType = null;
            Assert.That(amqpMessage.HasSection(AmqpMessageSection.Properties), Is.False, "Setting an empty value for the content type should not create the section.");
            Assert.That(eventData.ContentType, Is.Null, "The content type should not be populated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData" />
        ///   mutable properties.
        /// </summary>
        ///
        [Test]
        public void MutablePropertySettersPopulateTheAmqpMessage()
        {
            var messageId = "message-id-value";
            var correlationId = "correlation-id-value";
            var contentType = "text/content-type";
            var amqpMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));
            var eventData = new EventData(amqpMessage);

            eventData.MessageId = messageId;
            Assert.That(amqpMessage.Properties.MessageId.ToString(), Is.EqualTo(messageId), "The AMQP message identifier should match.");

            eventData.CorrelationId = correlationId;
            Assert.That(amqpMessage.Properties.CorrelationId.ToString(), Is.EqualTo(correlationId), "The AMQP message correlation identifier should match.");

            eventData.ContentType = contentType;
            Assert.That(amqpMessage.Properties.ContentType, Is.EqualTo(contentType), "The AMQP message content type should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData" />
        ///   properties not related to idempotent publishing state.
        /// </summary>
        ///
        [Test]
        public void NonIdempotentStatePropertyAccessorsDeferToTheAmqpMessage()
        {
            var sequenceNumber = 123L;
            var offset = "456L";
            var enqueueTime = new DateTimeOffset(2015, 10, 27, 00, 00, 00, TimeSpan.Zero);
            var partitionKey = "fake-key";
            var lastSequence = 321L;
            var lastOffset = "654L";
            var lastEnqueue = new DateTimeOffset(2012, 03, 04, 08, 00, 00, TimeSpan.Zero);
            var lastRetrieve = new DateTimeOffset(2020, 01, 01, 05, 15, 37, TimeSpan.Zero);
            var message = CreateFullyPopulatedAmqpMessage(sequenceNumber, lastSequence, offset, lastOffset, partitionKey, enqueueTime, lastEnqueue, lastRetrieve);
            var eventData = new EventData(message);

            Assert.That(message.Body.TryGetData(out var messageBody), Is.True, "The message body should have been read.");
            Assert.That(eventData.EventBody.ToArray(), Is.EquivalentTo(messageBody.First().ToArray()), "The message body should match.");
            Assert.That(eventData.Properties, Is.EquivalentTo(message.ApplicationProperties), "The application properties should match.");
            Assert.That(eventData.OffsetString, Is.EqualTo(offset), "The offset should match.");
            Assert.That(eventData.SequenceNumber, Is.EqualTo(sequenceNumber), "The sequence number should match.");
            Assert.That(eventData.EnqueuedTime, Is.EqualTo(enqueueTime), "The enqueued time should match.");
            Assert.That(eventData.PartitionKey, Is.EqualTo(partitionKey), "The partition key should match.");
            Assert.That(eventData.LastPartitionOffset, Is.EqualTo(lastOffset), "The last offset should match.");
            Assert.That(eventData.LastPartitionSequenceNumber, Is.EqualTo(lastSequence), "The last sequence number should match.");
            Assert.That(eventData.LastPartitionEnqueuedTime, Is.EqualTo(lastEnqueue), "The last enqueued time should match.");
            Assert.That(eventData.LastPartitionPropertiesRetrievalTime, Is.EqualTo(lastRetrieve), "The last retrieval time should match.");
            Assert.That(eventData.MessageId, Is.EqualTo(message.Properties.MessageId.ToString()), "The message identifier should match.");
            Assert.That(eventData.CorrelationId, Is.EqualTo(message.Properties.CorrelationId.ToString()), "The correlation identifier should match.");
            Assert.That(eventData.ContentType, Is.EqualTo(message.Properties.ContentType), "The content type should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventData.BodyAsStream "/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void BodyAsStreamReturnsTheBody()
        {
            var eventData = new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x65, 0x78 }));

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
            var eventData = new EventData(new BinaryData(Array.Empty<byte>()));

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

            var eventData = new EventData(new BinaryData(Array.Empty<byte>()))
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
                new BinaryData(new byte[] { 0x21, 0x22 }),
                new Dictionary<string, object> { { "Test", 123 } },
                new Dictionary<string, object> { { "System", "Hello" } },
                33334444,
                "666777",
                DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                "TestKey",
                111222,
                "999888",
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
                new BinaryData(new byte[] { 0x21, 0x22 }),
                null,
                null,
                33334444,
                "666777",
                DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                "TestKey",
                111222,
                "999888",
                DateTimeOffset.Parse("2012-03-04T09:00:00Z"),
                DateTimeOffset.Parse("2003-09-27T15:00:00Z"),
                787878,
                987654);

            var clone = sourceEvent.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
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
                new BinaryData(new byte[] { 0x21, 0x22 }),
                new Dictionary<string, object> { { "Test", 123 } },
                new Dictionary<string, object> { { "System", "Hello" } },
                33334444,
                "666777",
                DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                "TestKey",
                111222,
                "999888",
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
        ///   Creates a fully populated message with a consistent set of
        ///   test data and the specified set of system properties.
        /// </summary>
        ///
        /// <param name="sequenceNumber">The sequence number of the event; if null, this will not be populated.</param>
        /// <param name="lastSequenceNumber">The sequence number that was last enqueued in the partition; if null, this will not be populated.</param>
        /// <param name="offset">The offset of the event; if null, this will not be populated.</param>
        /// <param name="lastOffset">The offset that was last enqueued in the partition; if null, this will not be populated.</param>
        /// <param name="partitionKey">The partition key of the event; if null, this will not be populated.</param>
        /// <param name="enqueueTime">The time that the event was enqueued in the partition; if null, this will not be populated.</param>
        /// <param name="lastEnqueueTime">The time that an event was last enqueued in the partition; if null, this will not be populated.</param>
        /// <param name="lastRetrieveTime">The time that the information about the last event enqueued in the partition was reported; if null, this will not be populated.</param>
        ///
        /// <returns>The populated message.</returns>
        ///
        private static AmqpAnnotatedMessage CreateFullyPopulatedAmqpMessage(long sequenceNumber,
                                                                            long lastSequenceNumber,
                                                                            string offset,
                                                                            string lastOffset,
                                                                            string partitionKey,
                                                                            DateTimeOffset enqueueTime,
                                                                            DateTimeOffset lastEnqueueTime,
                                                                            DateTimeOffset lastRetrieveTime)
        {
            var body = AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x65, 0x66, 0x67, 0x68 } });
            var message = new AmqpAnnotatedMessage(body);

            // Header

            message.Header.DeliveryCount = 99;
            message.Header.Durable = true;
            message.Header.FirstAcquirer = true;
            message.Header.Priority = 123;
            message.Header.TimeToLive = TimeSpan.FromSeconds(10);

            // Properties

            message.Properties.AbsoluteExpiryTime = new DateTimeOffset(2015, 10, 27, 00, 00, 00, TimeSpan.Zero);
            message.Properties.ContentEncoding = "fake";
            message.Properties.ContentType = "test/unit";
            message.Properties.CorrelationId = new AmqpMessageId("red-5");
            message.Properties.CreationTime = new DateTimeOffset(2012, 03, 04, 08, 00, 00, 00, TimeSpan.Zero);
            message.Properties.GroupId = "mine!";
            message.Properties.GroupSequence = 555;
            message.Properties.MessageId = new AmqpMessageId("red-leader");
            message.Properties.ReplyTo = new AmqpAddress("amqps://some.namespace.com");
            message.Properties.ReplyToGroupId = "not-mine!";
            message.Properties.Subject = "We tried to copy an AMQP message.  You won't believe what happened next!";
            message.Properties.To = new AmqpAddress("https://some.url.com");
            message.Properties.UserId = new byte[] { 0x11, 0x22 };

            // Application Properties

            message.ApplicationProperties.Add("first", 1);
            message.ApplicationProperties.Add("second", "two");

            // Message Annotations

            message.MessageAnnotations.Add(AmqpProperty.SequenceNumber.ToString(), sequenceNumber);
            message.MessageAnnotations.Add(AmqpProperty.Offset.ToString(), offset);
            message.MessageAnnotations.Add(AmqpProperty.EnqueuedTime.ToString(), enqueueTime);
            message.MessageAnnotations.Add(AmqpProperty.PartitionKey.ToString(), partitionKey);

            // Delivery annotations

            message.DeliveryAnnotations.Add(AmqpProperty.PartitionLastEnqueuedSequenceNumber.ToString(), lastSequenceNumber);
            message.DeliveryAnnotations.Add(AmqpProperty.PartitionLastEnqueuedOffset.ToString(), lastOffset);
            message.DeliveryAnnotations.Add(AmqpProperty.PartitionLastEnqueuedTimeUtc.ToString(), lastEnqueueTime);
            message.DeliveryAnnotations.Add(AmqpProperty.LastPartitionPropertiesRetrievalTimeUtc.ToString(), lastRetrieveTime);

            return message;
        }

        /// <summary>
        ///   Retrieves the backing store for the System Properties dictionary from the Event Data
        ///   type, using its private field.
        /// </summary>
        ///
        /// <param name="eventData">The instance to read the field from.</param>
        ///
        /// <returns>The backing store for the <see cref="EventData.SystemProperties" /> set.</returns>
        ///
        private static IReadOnlyDictionary<string, object> GetSystemPropertiesBackingStore(EventData eventData) =>
            (IReadOnlyDictionary<string, object>)
                typeof(EventData)
                    .GetField("_systemProperties", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(eventData);
    }
}
