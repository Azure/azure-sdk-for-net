// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
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
        public async Task MockingEventDataBatch()
        {
            #region Snippet:EventHubs_Sample11_MockingEventDataBatch
            Mock<EventHubProducerClient> mockProducer = new Mock<EventHubProducerClient>();

            // This sets the value returned by the EventDataBatch when accessing the Size property
            // It does not impact TryAdd on the mocked batch
            long batchSizeInBytes = 500;

            // Events added to the batch will be added here, but altering the events in this list will not change the
            // events in the batch, since they are stored inside the batch as well
            List<EventData> backingList = new List<EventData>();

            // For illustrative purposes, this is the number of events that the batch will contain,
            // returning false from TryAdd for any additional calls.
            int batchCountThreshold = 3;

            EventDataBatch dataBatchMock = EventHubsModelFactory.EventDataBatch(
                    batchSizeBytes : batchSizeInBytes,
                    batchEventStore : backingList,
                    batchOptions : new CreateBatchOptions() { },
                    // The model factory allows the user to define a custom TryAdd callback, allowing
                    // control of what events the batch accepts.
                    eventData =>
                    {
                        int eventCount = backingList.Count();
                        return eventCount < batchCountThreshold;
                    });

            // Setting up a mock of the CreateBatchAsync method
            mockProducer
                .Setup(p => p.CreateBatchAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataBatchMock);

            // Mocking the SendAsync method so that it will throw an exception if the batch passed into send is
            // not the one we are expecting to send
            mockProducer
                .Setup(p => p.SendAsync(
                    It.Is<EventDataBatch>(sendBatch => sendBatch != dataBatchMock),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception("The batch published was not the expected batch."));

            EventHubProducerClient producer = mockProducer.Object;

            // Attempting to add events to the batch
            EventDataBatch batch = await producer.CreateBatchAsync();

            // Keep track of what events we successfully added to the batch
            List<EventData> sourceEvents = new List<EventData>();

            for (int i=0; i<3; i++)
            {
                var eventData = new EventData(eventBody: new BinaryData($"Sample-Event-{i}"));
                if (batch.TryAdd(eventData))
                {
                    // Track all of the events that were successfully added to the batch
                    sourceEvents.Add(eventData);
                }
            }

            // Illustrating the use of the try add callback
            EventData eventData4 = new EventData(eventBody: new BinaryData("Sample-Event-4-will-fail"));
            Assert.IsFalse(batch.TryAdd(eventData4));

            // Call SendAsync
            await producer.SendAsync(batch);

            // Using the mocked event producer to test that SendAsync was called once
            mockProducer
                .Verify(bp => bp.SendAsync(
                    It.IsAny<EventDataBatch>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            // Verify that the events in the batch match what the application expects
            foreach (EventData eventData in backingList)
            {
                Assert.IsTrue(sourceEvents.Contains(eventData));
            }
            Assert.AreEqual(backingList.Count, sourceEvents.Count);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MockingEventHubsProperties()
        {
            #region Snippet:EventHubs_Sample11_MockingEventHubProperties
            // Create a mock of the EventHubProducerClient
            Mock<EventHubProducerClient> mockProducer = new Mock<EventHubProducerClient>();

            // Define the set of partitions
            List<string> partitions = new List<string>(){ "0", "1" };

            // Mock the EventHubProperties using the model factory
            EventHubProperties eventHubProperties =
                EventHubsModelFactory.EventHubProperties(
                    name : "fakeEventHubName",
                    createdOn : DateTimeOffset.UtcNow, // arbitrary value
                    partitionIds : partitions.ToArray());

            // Setting up to return the mocked properties
            mockProducer
                .Setup(p => p.GetEventHubPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(eventHubProperties);

            // Setting up to return the mocked partition Ids.
            mockProducer
                .Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions.ToArray());

            EventHubProducerClient producer = mockProducer.Object;

            // Demonstrating accessing mocked EventHubProperties.
            EventHubProperties properties = await producer.GetEventHubPropertiesAsync();

            string eventHubName = properties.Name;
            Debug.WriteLine($"Sending Events to: {eventHubName}");
            #endregion
        }

        [Test]
        public void MockingBufferedProducer()
        {
            #region Snippet:EventHubs_Sample11_MockingBufferedProducer
            // Create a mock buffered producer
            Mock<EventHubBufferedProducerClient> bufferedProducerMock = new Mock<EventHubBufferedProducerClient>();

            // Define a failed handler for the mock
            Func<SendEventBatchFailedEventArgs, Task> sendFailed = new Func<SendEventBatchFailedEventArgs, Task>(async args =>
            {
                foreach (EventData eventData in args.EventBatch)
                {
                    if (eventData.Body.Length != 0)
                    {
                        await bufferedProducerMock.Object.EnqueueEventAsync(eventData);
                    }
                }
            });

            // Create a mock event to fail send
            EventData eventToEnqueue = EventHubsModelFactory.EventData(new BinaryData("Sample-Event"));
            List<EventData> eventList = new List<EventData>();
            eventList.Add(eventToEnqueue);

            // Create a set of args to send to the SendEventBatchFailedAsync handler
            SendEventBatchFailedEventArgs args = new SendEventBatchFailedEventArgs(eventList, new Exception(), "0", default);

            // Setup EnqueueEventAsync to always pass and return 1
            bufferedProducerMock
                .Setup(bp => bp.EnqueueEventAsync(
                    It.IsAny<EventData>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // Set up EnqueueEventsAsync to fail and call the defined fail handler using the
            // above created args
            bufferedProducerMock
                .Setup(bp => bp.EnqueueEventsAsync(
                    It.IsAny<List<EventData>>(),
                    It.IsAny<CancellationToken>()))
                .Callback(() => sendFailed(args));

            EventHubBufferedProducerClient bufferedProducer = bufferedProducerMock.Object;

            bufferedProducer.SendEventBatchFailedAsync += sendFailed;

            #endregion
        }

        [Test]
        public void BufferedProducerPartitionProps()
        {
            #region Snippet:EventHubs_Sample11_BufferedProducerPartitionProps

            // Create the buffered producer mock
            Mock<EventHubBufferedProducerClient> bufferedProducerMock = new Mock<EventHubBufferedProducerClient>();

            // Define the partitions and their properties
            Dictionary<string, PartitionProperties> partitions = new Dictionary<string, PartitionProperties>()
            {
                // Non-empty partition
                { "0", EventHubsModelFactory.PartitionProperties(
                    eventHubName : "eventhub-name",
                    partitionId : "0",
                    isEmpty : true,
                    beginningSequenceNumber: 1000,
                    lastSequenceNumber : 1100,
                    lastOffset : 500,
                    lastEnqueuedTime : DateTime.UtcNow) },

                // Empty partition
                { "1", EventHubsModelFactory.PartitionProperties(
                    eventHubName : "eventhub-name",
                    partitionId : "1",
                    isEmpty : false,
                    beginningSequenceNumber : 2000,
                    lastSequenceNumber : 2000,
                    lastOffset : 760,
                    lastEnqueuedTime : DateTime.UtcNow) }
            };

            // Set up partition Ids
            bufferedProducerMock
                .Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions.Keys.ToArray());

            // Set up partition properties
            foreach (var partition in partitions)
            {
                bufferedProducerMock
                    .Setup(p => p.GetPartitionPropertiesAsync(
                        partition.Key,
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(partition.Value);
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MockingConsumerClient()
        {
            #region Snippet:EventHubs_Sample11_MockingConsumerClient

            // Create a mock of the EventHubConsumerClient
            Mock<EventHubConsumerClient> mockConsumer = new Mock<EventHubConsumerClient>();

            List<EventData> receivedEvents = new List<EventData>();

            // Setting the TrackLastEnqueuedEventProperties flag to receive LastEnqueuedEventProperties
            // when reading events
            ReadEventOptions options = new ReadEventOptions
            {
                TrackLastEnqueuedEventProperties = true
            };

            // Create a mock of LastEnqueuedEventProperties using the model factory
            LastEnqueuedEventProperties lastEnqueueEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(
                lastSequenceNumber : default,
                lastOffset : default,
                lastEnqueuedTime : default,
                lastReceivedTime : default);

            // Create a mock of PartitionContext using the model factory
            PartitionContext partitionContext = EventHubsModelFactory.PartitionContext(
                partitionId : "0",
                lastEnqueuedEventProperties : lastEnqueueEventProperties);

            // Mock an EventData instance, different arguments can simulate different potential
            // outputs from the broker
            EventData eventData = EventHubsModelFactory.EventData(
                eventBody : new BinaryData("Sample-Event"),
                systemProperties : default,
                partitionKey : default,
                sequenceNumber : default,
                offset : default,
                enqueuedTime : default);

            // Create a mock of a partition event
            PartitionEvent samplePartitionEvent = new PartitionEvent(partitionContext, eventData);
            List<PartitionEvent> partitionEventList = new List<PartitionEvent>{ samplePartitionEvent };

            // Define a simple local method that returns an IAsyncEnumerable to use as the return for
            // ReadEventsAsync below.
            async IAsyncEnumerable<PartitionEvent> mockReturn(PartitionEvent samplePartitionEvent)
            {
                await Task.Yield();
                yield return samplePartitionEvent;
            }

            // Use this PartitionEvent to mock a return from the consumer, because ReadEvents returns an IAsyncEnumerable a separate
            // method is needed to properly set up this method. Return the partition event that includes the last enqueued event properties
            // if the tracking flag is set in the options.
            mockConsumer
                .Setup(c => c.ReadEventsAsync(
                    It.Is<ReadEventOptions>(opts => opts.TrackLastEnqueuedEventProperties),
                    It.IsAny<CancellationToken>()))
                .Returns(mockReturn(samplePartitionEvent));

            EventHubConsumerClient consumer = mockConsumer.Object;

            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync(options, cancellationTokenSource.Token))
            {
                Assert.AreEqual(receivedEvent.Data, eventData);
            }
            #endregion
        }

        [Test]
        public async Task PartitionReceiverMock()
        {
            #region Snippet:EventHubs_Sample11_PartitionReceiverMock

            // Create a mock of the PartitionReceiver
            Mock<PartitionReceiver> mockReceiver = new Mock<PartitionReceiver>();

            // Create a list of events to receive from the PartitionReceiver
            List<EventData> receivedEvents = new List<EventData>();

            for (int i=0; i<10; i++)
            {
                // Mocking an EventData instance, different arguments can simulate different potential
                // outputs from the broker
                EventData eventData = EventHubsModelFactory.EventData(
                    eventBody: new BinaryData($"Sample-Event-{i}"),
                    systemProperties: default,
                    partitionKey: "0",
                    sequenceNumber: default,
                    offset: default,
                    enqueuedTime: default);

                receivedEvents.Add(eventData);
            }

            // Setup the mock to receive the mocked data batch when ReceiveBatchAsync is called
            // on a given partition
            mockReceiver
                .Setup(r => r.ReceiveBatchAsync(
                    It.IsAny<int>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(receivedEvents);

            PartitionReceiver receiver = mockReceiver.Object;

            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            IEnumerable<EventData> receivedBatch = await receiver.ReceiveBatchAsync(
                maximumEventCount: 10,
                TimeSpan.FromSeconds(1),
                cancellationTokenSource.Token);

            #endregion
        }

        [Test]
        public async Task MockingEventProcessor()
        {
#region Snippet:EventHubs_Sample11_MockingEventProcessor

            // TestableCustomProcessor is a wrapper class around a CustomProcessor class that exposes
            // protected methods so that they can be tested
            Mock<TestableCustomProcessor> eventProcessorMock =
                new Mock<TestableCustomProcessor>(
                    5, //eventBatchMaximumCount
                    "consumerGroup",
                    "namespace",
                    "eventHub",
                    Mock.Of<TokenCredential>(),
                    new EventProcessorOptions())
                { CallBase = true };

            List<EventData> eventList = new List<EventData>()
            {
                new EventData(new BinaryData("Sample-Event-1")),
                new EventData(new BinaryData("Sample-Event-2")),
                new EventData(new BinaryData("Sample-Event-3"))
            };

            TestableCustomProcessor eventProcessor = eventProcessorMock.Object;

            // Call the wrapper method in order to reach proctected method within a custom processor
            // Using It.Is allows the test to set the PartitionId value, even though the setter is protected
            await eventProcessor.TestOnProcessingEventBatchAsync(eventList, new EventProcessorPartition());

#endregion
        }

#region Snippet:EventHubs_Sample11_CustomEventProcessor
        internal class CustomProcessor : EventProcessor<EventProcessorPartition>
#endregion
        {
            public CustomProcessor(int eventBatchMaximumCount,
                                        string consumerGroup,
                                        string fullyQualifiedNamespace,
                                        string eventHubName,
                                        TokenCredential credential,
                                        EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options) { }

            protected override async Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken = default)
            {
                await Task.Delay(1);
            }

            protected override Task OnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken = default) =>
                Task.CompletedTask;

            // Storage integration
            protected override Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken) =>
                throw new NotImplementedException();

            protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken) =>
                throw new NotImplementedException();

            protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) =>
                throw new NotImplementedException();
        }

#region Snippet:EventHubs_Sample11_TestCustomEventProcessor
        internal class TestableCustomProcessor : CustomProcessor
#endregion
        {
            public TestableCustomProcessor(int eventBatchMaximumCount,
                                        string consumerGroup,
                                        string fullyQualifiedNamespace,
                                        string eventHubName,
                                        TokenCredential credential,
                                        EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options) { }

            // Local event processing
            internal async Task TestOnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken = default) =>
                await OnProcessingEventBatchAsync(events, partition, cancellationToken);
        }
    }
}
