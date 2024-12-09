// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubsModelFactory" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubsModelFactoryTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.EventHubProperties" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EventHubPropertiesInitializesProperties()
        {
            var name = "fakename";
            var createdOn = new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero);
            var partitions = new[] { "0", "2", "4", "8" };
            var properties = EventHubsModelFactory.EventHubProperties(name, createdOn, partitions);

            Assert.That(properties, Is.Not.Null, "The properties should have been created.");
            Assert.That(properties.Name, Is.EqualTo(name), "The name should have been set.");
            Assert.That(properties.CreatedOn, Is.EqualTo(createdOn), "The creation date/time should have been set.");
            Assert.That(properties.PartitionIds, Is.EquivalentTo(partitions), "The partition identifiers should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.PartitionProperties" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void PartitionPropertiesInitializesProperties()
        {
            var eventHubName = "eventHubName";
            var partitionId = "0";
            var isEmpty = false;
            var beginningSequenceNumber = 123;
            var lastSequenceNumber = 9999;
            var lastOffset = "767";
            var lastEnqueuedTime = new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero);
            var properties = EventHubsModelFactory.PartitionProperties(eventHubName, partitionId, isEmpty, beginningSequenceNumber, lastSequenceNumber, lastOffset, lastEnqueuedTime);

            Assert.That(properties, Is.Not.Null, "The properties should have been created.");
            Assert.That(properties.EventHubName, Is.EqualTo(eventHubName), "The event hub name should have been set.");
            Assert.That(properties.Id, Is.EqualTo(partitionId), "The partition identifier should have been set.");
            Assert.That(properties.IsEmpty, Is.EqualTo(isEmpty), "The `is empty` flag should have been set.");
            Assert.That(properties.BeginningSequenceNumber, Is.EqualTo(beginningSequenceNumber), "The beginning sequence number should have been set.");
            Assert.That(properties.LastEnqueuedSequenceNumber, Is.EqualTo(lastSequenceNumber), "The last sequence number should have been set.");
            Assert.That(properties.LastEnqueuedOffsetString, Is.EqualTo(lastOffset), "The last offset should have been set.");
            Assert.That(properties.LastEnqueuedTime, Is.EqualTo(lastEnqueuedTime), "The last enqueue date/time should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.PartitionProperties" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void PartitionPublishingPropertiesInitializesProperties()
        {
            var isIdempotentPublishingEnabled = true;
            var producerGroupId = 675;
            var ownerLevel = (short)12;
            var lastPublishedSequenceNumber = 4;
            var properties = EventHubsModelFactory.PartitionPublishingProperties(isIdempotentPublishingEnabled, producerGroupId, ownerLevel, lastPublishedSequenceNumber);

            Assert.That(properties, Is.Not.Null, "The properties should have been created.");
            Assert.That(properties.IsIdempotentPublishingEnabled, Is.EqualTo(isIdempotentPublishingEnabled), "The idempotent publishing flag should have been set.");
            Assert.That(properties.ProducerGroupId, Is.EqualTo(producerGroupId), "The producer group should have been set.");
            Assert.That(properties.OwnerLevel, Is.EqualTo(ownerLevel), "The owner level should have been set.");
            Assert.That(properties.LastPublishedSequenceNumber, Is.EqualTo(lastPublishedSequenceNumber), "The last sequence number should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.LastEnqueuedEventProperties" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void LastEnqueuedEventPropertiesInitializesProperties()
        {
            var lastSequence = long.MaxValue - 100;
            var lastOffset = (long.MaxValue - 10).ToString();
            var lastEnqueued = new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero);
            var lastReceived = new DateTimeOffset(2012, 03, 04, 08, 0, 0, TimeSpan.Zero);
            var properties = EventHubsModelFactory.LastEnqueuedEventProperties(lastSequence, lastOffset, lastEnqueued, lastReceived);

            Assert.That(properties, Is.Not.Null, "The properties should have been created.");
            Assert.That(properties.SequenceNumber, Is.EqualTo(lastSequence), "The sequence number should have been set.");
            Assert.That(properties.OffsetString, Is.EqualTo(lastOffset), "The offset should have been set.");
            Assert.That(properties.EnqueuedTime, Is.EqualTo(lastEnqueued), "The enqueued date/time should have been set.");
            Assert.That(properties.LastReceivedTime, Is.EqualTo(lastReceived), "The last received date/time should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.PartitionContext" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void PartitionContextInitializesProperties()
        {
            var fakeDate = new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero);
            var fullyQualifiedNamespace = "fakeNamespace";
            var eventHubName = "fakeHub";
            var consumerGroup = "fakeConsumerGroup";
            var partition = "0";
            var properties = EventHubsModelFactory.LastEnqueuedEventProperties(465, "988", fakeDate, fakeDate);
            var context = EventHubsModelFactory.PartitionContext(fullyQualifiedNamespace, eventHubName, consumerGroup, partition, properties);

            Assert.That(context, Is.Not.Null, "The context should have been created.");
            Assert.That(context.FullyQualifiedNamespace, Is.EqualTo(fullyQualifiedNamespace), "The namespace should have been set.");
            Assert.That(context.EventHubName, Is.EqualTo(eventHubName), "The event hub name should have been set.");
            Assert.That(context.ConsumerGroup, Is.EqualTo(consumerGroup), "The consumer group should have been set.");
            Assert.That(context.PartitionId, Is.EqualTo(partition), "The partition should have been set.");
            Assert.That(context.ReadLastEnqueuedEventProperties(), Is.EqualTo(properties), "The last enqueued event properties should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.PartitionContext" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void PartitionContextDefaultsLastEnqueuedEventProperties()
        {
            var fullyQualifiedNamespace = "fakeNamespace";
            var eventHubName = "fakeHub";
            var consumerGroup = "fakeConsumerGroup";
            var partition = "0";
            var context = EventHubsModelFactory.PartitionContext(fullyQualifiedNamespace, eventHubName, consumerGroup, partition);

            Assert.That(context, Is.Not.Null, "The context should have been created.");
            Assert.That(context.FullyQualifiedNamespace, Is.EqualTo(fullyQualifiedNamespace), "The namespace should have been set.");
            Assert.That(context.EventHubName, Is.EqualTo(eventHubName), "The event hub name should have been set.");
            Assert.That(context.ConsumerGroup, Is.EqualTo(consumerGroup), "The consumer group should have been set.");
            Assert.That(context.PartitionId, Is.EqualTo(partition), "The partition should have been set.");
            Assert.That(context.ReadLastEnqueuedEventProperties(), Is.EqualTo(new LastEnqueuedEventProperties()), "Reading last enqueued event properties should return a default instance.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.EventData" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EventDataInitializesProperties()
        {
            var body = new BinaryData("Hello");
            var properties = new Dictionary<string, object> { { "id", 12 } };
            var systemProperties = new Dictionary<string, object> { { "custom", "sys-value" } };
            var sequenceNumber = long.MaxValue - 512;
            string offset = (long.MaxValue - 1024).ToString();
            var enqueueTime = new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero);
            var partitionKey = "omghai!";
            var eventData = EventHubsModelFactory.EventData(body, properties, systemProperties, partitionKey, sequenceNumber, offset, enqueueTime);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody.ToString(), Is.EqualTo(body.ToString()), "The event body should have been set.");
            Assert.That(eventData.Properties, Is.EquivalentTo(properties), "The properties should have been set.");
            Assert.That(eventData.SystemProperties, Is.EquivalentTo(systemProperties), "The system properties should have been set.");
            Assert.That(eventData.PartitionKey, Is.EqualTo(partitionKey), "The partition key should have been set.");
            Assert.That(eventData.SequenceNumber, Is.EqualTo(sequenceNumber), "The sequence number should have been set.");
            Assert.That(eventData.OffsetString, Is.EqualTo(offset), "The offset should have been set.");
            Assert.That(eventData.EnqueuedTime, Is.EqualTo(enqueueTime), "The sequence number should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.EventDataBatch" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EventDataBatchInitializesProperties()
        {
            var size = 1024;
            var store = new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) };
            var options = new CreateBatchOptions { MaximumSizeInBytes = 2048 };
            var batch = EventHubsModelFactory.EventDataBatch(size, store, options);

            Assert.That(batch, Is.Not.Null, "The batch should have been created.");
            Assert.That(batch.SizeInBytes, Is.EqualTo(size), "The batch size should have been set.");
            Assert.That(batch.MaximumSizeInBytes, Is.EqualTo(options.MaximumSizeInBytes), "The maximum batch size should have been set.");
            Assert.That(batch.Count, Is.EqualTo(store.Count), "The batch count should reflect the count of the backing store.");
            Assert.That(batch.AsReadOnlyCollection<AmqpMessage>().Count, Is.EqualTo(store.Count), "The batch enumerable should be populated with the same number of messages as the event store.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.EventDataBatch" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EventDataBatchRespectsTheTryAddCallback()
        {
            var eventLimit = 3;
            var converter = new AmqpMessageConverter();
            var store = new List<EventData>();
            var messages = new List<AmqpMessage>();
            var batch = EventHubsModelFactory.EventDataBatch(5, store, tryAddCallback: _ => store.Count < eventLimit);

            while (store.Count < eventLimit)
            {
                var eventData = new EventData(new BinaryData("Test"));
                Assert.That(() => batch.TryAdd(eventData), Is.True, $"The batch contains { store.Count } events; adding another should be permitted.");

                messages.Add(converter.CreateMessageFromEvent(eventData));
            }

            Assert.That(store.Count, Is.EqualTo(eventLimit), "The batch should be at its limit.");
            Assert.That(() => batch.TryAdd(new EventData(new BinaryData("Too many"))), Is.False, "The batch is full; it should not be possible to add a new event.");
            Assert.That(() => batch.TryAdd(new EventData(new BinaryData("Too many"))), Is.False, "The batch is full; a second attempt to add a new event should not succeed.");

            Assert.That(store.Count, Is.EqualTo(eventLimit), "The batch should be at its limit after the failed TryAdd attempts.");
            Assert.That(batch.AsReadOnlyCollection<AmqpMessage>().Count, Is.EqualTo(eventLimit), "The messages produced by the batch should match the limit.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsModelFactory.EventDataBatch" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EventDataBatchIsSafeToDispose()
        {
            var size = 1024;
            var store = new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) };
            var options = new CreateBatchOptions { MaximumSizeInBytes = 2048 };
            var batch = EventHubsModelFactory.EventDataBatch(size, store, options, _ => false);

            Assert.That(() => batch.Dispose(), Throws.Nothing);
        }
    }
}
