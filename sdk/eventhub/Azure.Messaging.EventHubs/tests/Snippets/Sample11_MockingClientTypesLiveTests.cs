// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample01_HelloWorld sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample11_MockingClientTypesLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task BatchingValidation()
        {
            #region Snippet:EventHubs_Sample11_Batching

            // Define the custom TryAdd callback. This allows for simple reasoning
            // when writing the test.
            var emptyBatch = EventHubsModelFactory.EventDataBatch(
                46,
                new List<EventData>(),
                new CreateBatchOptions() { },
                eventData =>
                {
                    return eventData.EventBody.ToString().Length > 10;
                });

            // Create a mock of the EventHubProducerClient
            var mockProducer = new Mock<EventHubProducerClient>();
            mockProducer.Setup(p => p.CreateBatchAsync(It.IsAny<CancellationToken>())).ReturnsAsync(emptyBatch);
            var producer = mockProducer.Object;

            // Attempt to add a mocked EventData instance with a string body larger than 10
            var largeEvent = EventHubsModelFactory.EventData(new BinaryData("This represents a very large Event"));

            using (var eventBatch = await producer.CreateBatchAsync())
            {
                // Validate the Application-defined EventBatcher method.
                // This method has TryAdd calls inside, as well as custom logic to
                // split events and attempt to add them to the batch again
            }
            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ThrottlingUsingProperties()
        {
            #region Snippet:EventHubs_Sample11_Throttling

            var partitions = new Dictionary<string, PartitionPublishingProperties>() {
                { "Multiple readers partitions", EventHubsModelFactory.PartitionPublishingProperties(false, null, null, null) },
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
            const int SmallBatchSize = 100;
            const int LargeBatchSize = 500;

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
            await Task.Delay(TimeSpan.FromMilliseconds(10));
        }

        // Mock classes

        #region Snippet:EventHubs_Sample11_Throttling
        private class SimpleConsumerMock : TransportConsumer
        {
            private List<EventData> _eventsToConsume;

            public SimpleConsumerMock(EventData lastEvent, List<EventData> eventsToConsume)
            {
                LastReceivedEvent = lastEvent;
                _eventsToConsume = eventsToConsume;
            }

            public override async Task<IReadOnlyList<EventData>> ReceiveAsync(int maximumMessageCount, TimeSpan? maximumWaitTime, CancellationToken cancellationToken)
            {
                var eventReturn = new List<EventData>();

                var eventData = _eventsToConsume.FirstOrDefault();
                _eventsToConsume.RemoveAt(0);
                eventReturn.Add(eventData);

                await Task.Delay(TimeSpan.FromMilliseconds(10), cancellationToken);

                return eventReturn.AsReadOnly();
            }

            public override Task CloseAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
        }
        #endregion

        // Fake helper methods for illustrative purposes
        private static List<EventData> EventSplitter(EventData eventData, long maxBatchSize)
        {
            var returnList = new List<EventData>();
            returnList.Add(new EventData(new BinaryData("smaller")));
            return returnList;
        }
    }
}
