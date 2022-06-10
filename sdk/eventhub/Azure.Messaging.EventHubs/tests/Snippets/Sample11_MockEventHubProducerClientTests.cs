// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample10_AzureEventSourceListener sample.
    /// </summary>
    ///
    [TestFixture]
    public class Sample11_MockEventHubProducerClientTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task EventDataBatch()
        {
            #region Snippet:EventHubs_Sample11_EventDataBatch

            // Collection of the events added to the batch

            var actualEvents = new List<EventData>() {
                EventHubsModelFactory.EventData(new BinaryData("Sample event body"))
            };

            // Mocking "almost full" event data batch corner case.
            // It won't accept new events of larger than the size of the available bytes

            var crateBatchOptions = new CreateBatchOptions() { MaximumSizeInBytes = 516 };
            var batchSizeBytes = 500;

            var almostFullBatch = EventHubsModelFactory.EventDataBatch(
                batchSizeBytes, // Accumulated batch size of all previously added events
                actualEvents, // New events to be added in this collection
                crateBatchOptions, // Batch options mocking MaximumSizeInBytes property
                eventData =>
                {
                    // Custom tryAddCallback function checking available bytes size in the bach
                    return eventData.Body.Length <= crateBatchOptions.MaximumSizeInBytes - batchSizeBytes;
                });

            var mockProducer = new Mock<EventHubProducerClient>();
            mockProducer.Setup(p => p.CreateBatchAsync(It.IsAny<CancellationToken>())).ReturnsAsync(almostFullBatch);

            var producer = mockProducer.Object;

            using var eventBatch = await producer.CreateBatchAsync();

            // Try to fit relatively large amount of the data in "almost full" batch

            var largeEventBody = new BinaryData("Sample large event body");
            var largeEventData = EventHubsModelFactory.EventData(largeEventBody);

            // Assert event won't fit

            Assert.IsFalse(eventBatch.TryAdd(largeEventData));
            Assert.That(actualEvents.Count, Is.EqualTo(1));

            // Try to fit smaller amount of the data in "almost full" batch

            var smallEventBody = new BinaryData("Small event body");
            var smallEventData = EventHubsModelFactory.EventData(smallEventBody);

            // Assert large event won't fit

            Assert.IsTrue(eventBatch.TryAdd(smallEventData));
            Assert.That(actualEvents.Count, Is.EqualTo(2));

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task PartitionPublishingProperties()
        {
            #region Snippet:EventHubs_Sample11_PartitionPublishingProperties

            var partitions = new Dictionary<string, PartitionPublishingProperties>() {
                // The owner level of the partition publishing properties is equal to null,
                // therefore we assume that this partition can be processed by multiple readers
                { "Multiple readers partitions", EventHubsModelFactory.PartitionPublishingProperties(false, null, null, null) },

                // The owner level of this partition is set to 42,
                // so we assume this partition's events are processed by an exlusive reader.
                { "Exclusive reader partition", EventHubsModelFactory.PartitionPublishingProperties(false, null, 42, null) } };

            var mockProducer = new Mock<EventHubProducerClient>();

            mockProducer.Setup(prod => prod.GetPartitionIdsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(partitions.Keys.ToArray());

            foreach (var partition in partitions)
            {
                mockProducer
                    .Setup(prod => prod.GetPartitionPublishingPropertiesAsync(partition.Key, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(partition.Value);
            }

            var producer = mockProducer.Object;
            const int SmallBatchSize = 69;
            const int LargeBatchSize = 420;

            foreach (var partition in partitions)
            {
                var publishingProperties = await producer.GetPartitionPublishingPropertiesAsync(partition.Key);

                // If the partition has owner level set - then it has exclusive reader.
                // For the partitions with the exclusive reader we want to send events in smaller batches.

                var eventsInBatchCount = publishingProperties.OwnerLevel.HasValue ? SmallBatchSize : LargeBatchSize;

                var eventsToSend = new List<EventData>();

                for (var index = 0; index < eventsInBatchCount; ++index)
                {
                    var eventBody = new BinaryData("Hello, Event Hubs!");
                    var eventData = new EventData(eventBody);

                    eventsToSend.Add(eventData);
                }

                await producer.SendAsync(eventsToSend, new SendEventOptions(partition.Key, string.Empty));
            }

            foreach (var partition in partitions)
            {
                // Verify that the batch with less events have been sent to the partition with exlusive reader (owner level set)

                mockProducer.Verify(prod => prod.SendAsync(
                    It.Is<List<EventData>>(evts => evts.Count == (partition.Value.OwnerLevel.HasValue ? SmallBatchSize : LargeBatchSize)),
                    It.Is<SendEventOptions>(opts => opts.PartitionId == partition.Key),
                    It.IsAny<CancellationToken>()), Times.Once);
            }

            #endregion
        }
    }
}
