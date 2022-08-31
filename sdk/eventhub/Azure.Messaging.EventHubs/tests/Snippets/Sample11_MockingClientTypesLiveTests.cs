// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample11_MockingClientTypes sample.
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
        public void BatchingValidation()
        {
            #region Snippet:EventHubs_Sample11_SimpleBatchingLogic_Test

            // Create a mock of the EventHubProducerClient
            var mockProducer = new Mock<EventHubProducerClient>();

            // The method we are testing uses the following two methods, so we will abstract those
            // out by setting up simple returns
            mockProducer.Setup(p => p.CreateBatchAsync(
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                EventHubsModelFactory.EventDataBatch(
                    46,
                    new List<EventData>(),
                    new CreateBatchOptions() { },
                    // Define the custom TryAdd callback. This allows for simple reasoning
                    // when writing the test.
                    eventData =>
                    {
                        return eventData.EventBody.ToString().Length < 10;
                    }));

            mockProducer.Setup(p => p.SendAsync(
                It.IsAny<EventDataBatch>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var producer = mockProducer.Object;

            // Attempt to send a mocked EventData instance with a string body larger than 10
            var largeEvent = EventHubsModelFactory.EventData(new BinaryData("This represents a very large Event"));

            // In this case we want to make sure that the method does not throw any exceptions
            Assert.DoesNotThrow(() => SendALargeEvent(producer, largeEvent));
            #endregion
        }

        #region Snippet:EventHubs_Sample11_SimpleBatchingLogic
        private async void SendALargeEvent(EventHubProducerClient producer, EventData eventData)
        {
            var eventBatch = await producer.CreateBatchAsync();
            var fitInBatch = eventBatch.TryAdd(eventData);

            if (!fitInBatch)
            {
                // EventSplitter is an application-specific method that splits a large event into
                // a list of smaller events that are smaller than the maximum size of the batch
                var smallerEvents = EventSplitter(eventData, eventBatch.MaximumSizeInBytes);

                foreach (var smallEvent in smallerEvents)
                {
                    if (!eventBatch.TryAdd(smallEvent))
                    {
                        await producer.SendAsync(eventBatch);
                        eventBatch = await producer.CreateBatchAsync();
                        var attemptTwo = eventBatch.TryAdd(smallEvent);
                        if (!attemptTwo)
                        {
                            throw new Exception($"The event could not be added.");
                        }
                    }
                }
            }

            // Send any lingering event batches

            if (eventBatch.Count != 0)
            {
                await producer.SendAsync(eventBatch);
            }

            // If no exceptions were thrown the event was successfully sent
        }
        #endregion

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void SimplePropertiesLogic()
        {
            #region Snippet:EventHubs_Sample11_PropertiesLogic_Test

            // Create a mock of the EventHubProducerClient
            var mockProducer = new Mock<EventHubProducerClient>();

            // Create a mock of the partitions and publishing properties
            var partitions = new Dictionary<string, PartitionPublishingProperties>()
            {
                { "0", EventHubsModelFactory.PartitionPublishingProperties(false, null, null, null) },
                { "1", EventHubsModelFactory.PartitionPublishingProperties(false, null, 42, null) }
            };

            var eventHubProperties = EventHubsModelFactory.EventHubProperties("fakeEventHub", DateTimeOffset.UtcNow, new string[] { "0", "1" });

            // The method we are testing uses the following two methods, so we will abstract those
            // out by setting up simple returns
            mockProducer.Setup(p => p.GetEventHubPropertiesAsync(
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(eventHubProperties);

            foreach (var partition in partitions)
            {
                mockProducer.Setup(p => p.GetPartitionPublishingPropertiesAsync(
                partition.Key,
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(partition.Value);
            }

            var producer = mockProducer.Object;

            // Attempt to send a mocked EventData instance with a string body larger than 10
            var generatedEvents = GenerateEvents(50);
            var smallBatchCount = 10;
            var largeBatchCount = 20;

            SendEventsToProspectivePartitions(producer, generatedEvents, smallBatchCount, largeBatchCount);

            foreach (var partition in partitions)
            {
                // Verify that the batch with less events have been sent to the partition with exlusive reader (owner level set)

                mockProducer.Verify(prod => prod.SendAsync(
                    It.Is<List<EventData>>(evts => evts.Count == (partition.Value.OwnerLevel.HasValue ? smallBatchCount : largeBatchCount)),
                    It.Is<SendEventOptions>(opts => opts.PartitionId == partition.Key),
                    It.IsAny<CancellationToken>()), Times.AtLeastOnce);
            }

            #endregion
        }

        #region EventHubs_Sample11_PropertiesLogic
        private async void SendEventsToProspectivePartitions(EventHubProducerClient producer, List<EventData> eventDataList, int smallBatchCount, int largeBatchCount)
        {
            var properties = await producer.GetEventHubPropertiesAsync();
            var partitionIds = properties.PartitionIds;

            var nextEventIndexToSend = 0;
            List<EventData> eventsToSend;
            foreach (var partitionId in partitionIds)
            {
                var publishingProperties = await producer.GetPartitionPublishingPropertiesAsync(partitionId);
                (eventsToSend, nextEventIndexToSend) = GetNextSetOfEvents(eventDataList, nextEventIndexToSend, publishingProperties.OwnerLevel, smallBatchCount, largeBatchCount);

                var options = new SendEventOptions
                {
                    PartitionId = partitionId
                };

                await producer.SendAsync(eventsToSend, options);
            }
        }
        #endregion

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ThrottlingConsumer()
        {
            #region Snippet:EventHubs_Sample11_ScaleDownConsumer_Test

            var consumerRunnerMock = new Mock<ConsumerRunner>() {  CallBase = true };
            var consumerRunner = consumerRunnerMock.Object;

            var transportConsumer = new PopulatedConsumerMock();
            var mockConnection = new MockConnection(() => transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, mockConnection);
            var receivedEvents = new List<EventData>();

            using var cancellation = new CancellationTokenSource();
            cancellation.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            try
            {
                await consumerRunner.RunConsumer(consumer, cancellation).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                // All events were read
            }

            consumerRunnerMock.Verify(cons => cons.NotifyScaleDownNeeded(), Times.AtLeastOnce);
            #endregion
        }

        internal class ConsumerRunner
        {
            private CancellationTokenSource ConsumerCancellationTokenSource;
            #region Snippet:EventHubs_Sample11_ScaleDownConsumer

            public virtual async Task RunConsumer(EventHubConsumerClient consumer, CancellationTokenSource cancellationTokenSource)
            {
                var consumeEvents = ConsumeEventsFromAssignedPartitions(consumer, cancellationTokenSource.Token);
                ConsumerCancellationTokenSource = cancellationTokenSource;

                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                    await CheckScaleDownConsumers(consumer).ConfigureAwait(false);
                }
                await consumeEvents.ConfigureAwait(false);
            }

            public virtual async Task ConsumeEventsFromAssignedPartitions(EventHubConsumerClient consumer, CancellationToken cancellationToken)
            {
                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(cancellationToken))
                {
                    ConsumeEvent(partitionEvent.Data);
                }
            }

            public virtual async Task CheckScaleDownConsumers(EventHubConsumerClient consumer)
            {
                var partitionIds = await consumer.GetPartitionIdsAsync();

                foreach (var partition in partitionIds)
                {
                    var partitionProperties = await consumer.GetPartitionPropertiesAsync(partition);

                    if (partitionProperties.IsEmpty)
                    {
                        NotifyScaleDownNeeded();
                    }
                }
            }
            #endregion
            public virtual void NotifyScaleDownNeeded()
            {
                ConsumerCancellationTokenSource.Cancel();
            }
        }

        #region Snippet:EventHubs_Sample11_ScaleDownConsumer_MockClasses
        private class PopulatedConsumerMock : TransportConsumer
        {
            private List<EventData> _eventsToConsume;

            public PopulatedConsumerMock()
            {
                _eventsToConsume = GenerateEvents(500);
            }

            public override async Task<IReadOnlyList<EventData>> ReceiveAsync(int maximumMessageCount, TimeSpan? maximumWaitTime, CancellationToken cancellationToken)
            {
                var eventReturn = new List<EventData>();

                // For simplicity, just return one event for consumption, the behavior of this method override is customizable depending on what needs to be tested
                var eventData = _eventsToConsume.FirstOrDefault();
                _eventsToConsume.RemoveAt(0);
                eventReturn.Add(eventData);

                await Task.Delay(100, cancellationToken);

                return eventReturn.AsReadOnly();
            }

            public override Task CloseAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        }

        private class MockConnection : EventHubConnection
        {
            public string[] PartitionIds = { "0", "1" };
            public List<PartitionProperties> PartitionProperties = new List<PartitionProperties>();
            public EventHubsRetryPolicy GetPartitionPropertiesInvokedWith = null;
            public Func<TransportConsumer> TransportConsumerFactory = () => Mock.Of<TransportConsumer>();
            public bool WasClosed = false;

            public MockConnection(Func<TransportConsumer> transportConsumerFactory)
                : base("fakeNamespace", "fakeEventHub", new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>()).Object)
            {
                TransportConsumerFactory = transportConsumerFactory;

                var partitionProperties0 = EventHubsModelFactory.PartitionProperties("fakeEventHub", "0", true, 0, 0, 0, DateTimeOffset.UtcNow);
                PartitionProperties.Add(partitionProperties0);

                var partitionProperties1 = EventHubsModelFactory.PartitionProperties("fakeEventHub", "1", true, 0, 0, 0, DateTimeOffset.UtcNow);
                PartitionProperties.Add(partitionProperties1);
            }

            internal override Task<EventHubProperties> GetPropertiesAsync(EventHubsRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default) => throw new NotImplementedException();

            internal override async Task<string[]> GetPartitionIdsAsync(EventHubsRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                await Task.Delay(1).ConfigureAwait(false);
                return PartitionIds;
            }

            internal override async Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                    EventHubsRetryPolicy retryPolicy,
                                                                                    CancellationToken cancellationToken = default)
            {
                await Task.Delay(1);
                if (partitionId == "0")
                {
                    return PartitionProperties.ElementAt(0);
                }

                if (partitionId == "1")
                {
                    return PartitionProperties.ElementAt(0);
                }

                else
                {
                    throw new Exception("Not a valid Partition Id");
                }
            }

            internal override TransportConsumer CreateTransportConsumer(string consumerGroup,
                                                                        string partitionId,
                                                                        string consumerIdentifier,
                                                                        EventPosition eventPosition,
                                                                        EventHubsRetryPolicy retryPolicy,
                                                                        bool trackLastEnqueuedEventProperties = true,
                                                                        bool invalidateConsumerWhenPartitionIsStolen = false,
                                                                        long? ownerLevel = default,
                                                                        uint? prefetchCount = default,
                                                                        long? prefetchSizeInBytes = default) => TransportConsumerFactory();

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace,
                                                                    string eventHubName,
                                                                    TimeSpan timeout,
                                                                    EventHubTokenCredential credential,
                                                                    EventHubConnectionOptions options)
            {
                var client = new Mock<TransportClient>();

                client
                    .Setup(client => client.ServiceEndpoint)
                    .Returns(new Uri($"amgp://{fullyQualifiedNamespace}.com/{eventHubName}"));

                return client.Object;
            }
        }
        #endregion

        // Partition receiver

        // processor client

        // event processor

        // buffered producer

        // include: last enqueued event properties, partition context

        // Fake helper methods for illustrative purposes
        private static List<EventData> EventSplitter(EventData eventData, long maxBatchSize)
        {
            var returnList = new List<EventData>();
            returnList.Add(new EventData(new BinaryData("smaller")));
            return returnList;
        }

        private static List<EventData> GenerateEvents(int numEvents)
        {
            var returnList = new List<EventData>();
            for (int i = 0; i < numEvents; i++)
            {
                returnList.Add(new EventData(new BinaryData($"sample-event-{i}")));
            }
            return returnList;
        }

        private static (List<EventData> EventDataList, int Index) GetNextSetOfEvents(List<EventData> eventData, int index, short? ownerLevel, int small, int large)
        {
            var eventCount = (ownerLevel.HasValue ? small : large);
            var endIndex = index + eventCount;
            var returnList = eventData.GetRange(index, eventCount);
            return (returnList, endIndex);
        }

        private static void ConsumeEvent(EventData eventData)
        {
        }
    }
}
