// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            var mockProducer = new Mock<EventHubProducerClient>();

            // This sets the value returned by the EventDataBatch when accessing the Size property
            // It does not impact TryAdd on the mocked batch
            var batchSizeInBytes = 500;

            // Events added to the batch will be added here, but altering the events in this list will not change the
            // events in the batch, since they are stored inside the batch as well
            var backingList = new List<EventData>();

            // For illustrative purposes allow the batch to hold 3 events before
            // returning false.
            var batchCountThreshold = 3;

            var dataBatchMock = EventHubsModelFactory.EventDataBatch(
                    batchSizeBytes : batchSizeInBytes,
                    batchEventStore : backingList,
                    batchOptions : new CreateBatchOptions() { },
                    // The model factory allows the user to define a custom TryAdd callback, making
                    // it easy to test specific scenarios
                    eventData =>
                    {
                        var numElements = backingList.Count();
                        return numElements < batchCountThreshold;
                    });

            // Setting up a mock of the CreateBatchAsync method
            mockProducer.Setup(p => p.CreateBatchAsync(
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataBatchMock);

            // Mocking the SendAsync method so that it will throw an exception if the batch passed into send is
            // not the one we are expecting to send
            mockProducer.Setup(p => p.SendAsync(
                It.Is<EventDataBatch>(sendBatch => sendBatch != dataBatchMock),
                It.IsAny<CancellationToken>()))
                .Throws(new Exception("The batch published was not the expected batch."));

            var producer = mockProducer.Object;

            // Attempting to add events to the batch
            var batch = await producer.CreateBatchAsync();
            var eventList = new List<EventData>();

            for (int i=0; i<4; i++)
            {
                var eventData = new EventData(eventBody: new BinaryData($"Sample-Event-{i}"));
                if (batch.TryAdd(eventData))
                {
                    // Track all of the events that were successfully added to the batch
                    eventList.Add(eventData);
                }
            }

            // Illustrating the use of the try add callback
            var eventData4 = new EventData(eventBody: new BinaryData("Sample-Event-4-will-fail"));
            Assert.IsFalse(batch.TryAdd(eventData4));

            // Call SendAsync
            await producer.SendAsync(batch);

            // Using the mocked event producer to test that SendAsync was called once
            mockProducer.Verify(bp =>
            bp.SendAsync(
                It.IsAny<EventDataBatch>(),
                It.IsAny<CancellationToken>()),Times.Once);

            // Verify that the events in the batch match what the application expects
            foreach (var eventData in backingList)
            {
                Assert.IsTrue(eventList.Contains(eventData));
            }
            Assert.AreEqual(backingList.Count, eventList.Count);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void MockingEventHubsProperties()
        {
            #region Snippet:EventHubs_Sample11_MockingEventHubProperties
            // Create a mock of the EventHubProducerClient
            var mockProducer = new Mock<EventHubProducerClient>();

            // Define the set of partitions and publishing properties to use for testing
            var partitions = new Dictionary<string, PartitionPublishingProperties>()
            {
                // Partition with PartitionId 0
                { "0", EventHubsModelFactory.PartitionPublishingProperties(
                    isIdempotentPublishingEnabled : false,
                    producerGroupId : null,
                    ownerLevel : null, // Has no reader ownership - anyone can read
                    lastPublishedSequenceNumber: null) },

                // Partition with PartitionId 1
                { "1", EventHubsModelFactory.PartitionPublishingProperties(
                    isIdempotentPublishingEnabled : false,
                    producerGroupId : null,
                    ownerLevel : 42, // Reader ownership is high - exclusive reader
                    lastPublishedSequenceNumber : null) }
            };

            // Mock the EventHubProperties using the model factory
            var eventHubProperties =
                EventHubsModelFactory.EventHubProperties(
                    name : "fakeEventHubName",
                    createdOn : DateTimeOffset.UtcNow, // arbitrary value
                    partitionIds : partitions.Keys.ToArray());

            // Setting up to return the mocked properties
            mockProducer.Setup(p => p.GetEventHubPropertiesAsync(
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(eventHubProperties);

            // Setting up to return the mocked partition ids
            mockProducer.Setup(p => p.GetPartitionIdsAsync(
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions.Keys.ToArray());

            foreach (var partition in partitions)
            {
                // Setting up to return the mocked properties for each partition input
                mockProducer.Setup(p => p.GetPartitionPublishingPropertiesAsync(
                partition.Key,
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(partition.Value);
            }

            var producer = mockProducer.Object;

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void MockingConsumerClient()
        {
            #region Snippet:EventHubs_Sample11_MockingConsumerClient

            // Create a mock of the EventHubConsumerClient
            var mockConsumer = new Mock<EventHubConsumerClient>();

            var receivedEvents = new List<EventData>();
            var cancellationTokenSource = new CancellationTokenSource();

            // Create a mock of LastEnqueuedEventProperties using the model factory, these can
            // be set depending on the scenario that is important for the application
            var lastEnqueueEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(
                lastSequenceNumber : default,
                lastOffset : default,
                lastEnqueuedTime : default,
                lastReceivedTime : default);

            // Create a mock of PartitionContext using the model factory
            var partitionContext = EventHubsModelFactory.PartitionContext(
                partitionId : "0",
                lastEnqueuedEventProperties : lastEnqueueEventProperties);

            // Mock an EventData instance, different arguments can simulate different potential
            // outputs from the broker
            var eventData = EventHubsModelFactory.EventData(
                eventBody : new BinaryData("Sample-Event"),
                systemProperties : default,
                partitionKey : default,
                sequenceNumber : default,
                offset : default,
                enqueuedTime : default);

            // Create a mock of a partition event
            var samplePartitionEvent = new PartitionEvent(partitionContext, eventData);
            var partitionEventList = new List<PartitionEvent>(new PartitionEvent[] { samplePartitionEvent });

            // Define a simple local method that returns an IAsyncEnumerable to use as the return for
            // ReadEventsAsync above
            async IAsyncEnumerable<PartitionEvent> mockReturn(PartitionEvent samplePartitionEvent)
            {
                await Task.CompletedTask;
                yield return samplePartitionEvent;
            }

            // Use this PartitionEvent to mock a return from the consumer, because ReadEvents returns an IAsyncEnumerable a separate
            // method is needed to properly set up this method
            mockConsumer.Setup(
                c => c.ReadEventsAsync(
                It.IsAny<CancellationToken>())).Returns(mockReturn(samplePartitionEvent));

            var consumer = mockConsumer.Object;
        }

        #endregion

        [Test]
        public void PartitionReceiverMock()
        {
#region Snippet:EventHubs_Sample11_PartitionReceiverMock

            // Create a mock of the PartitionReceiver
            var mockReceiver = new Mock<PartitionReceiver>();

            // This sets the value returned by the EventDataBatch when accessing the Size property
            // It does not impact TryAdd on the mocked batch
            var batchSizeInBytes = 500;

            // Events added to the batch will be added here, but altering the events in this list will not change the
            // events in the batch, since they are stored inside the batch as well
            var backingList = new List<EventData>();

            // Create a mock of an EventDataBatch for the receiver to return
            var dataBatchMock = EventHubsModelFactory.EventDataBatch(
                    batchSizeBytes: batchSizeInBytes,
                    batchEventStore: backingList,
                    batchOptions: new CreateBatchOptions() { },
                    // The model factory allows the user to define a custom TryAdd callback, making
                    // it easy to test specific scenarios
                    eventData =>
                    {
                        var numElements = backingList.Count();
                        return numElements < 10;
                    });

            var batchList = new List<EventDataBatch>
            {
                dataBatchMock
            };

            // Setup the mock to receive the mocked data batch when ReceiveBatchAsync is called
            mockReceiver.Setup(
                r => r.ReceiveBatchAsync(
                    It.IsAny<int>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(backingList.ToArray());

            var receiver = mockReceiver.Object;

#endregion
        }

        [Test]
        public void MockingBufferedProducer()
        {
#region Snippet:EventHubs_Sample11_MockingBufferedProducer
            // Create a mock buffered producer
            var bufferedProducerMock = new Mock<EventHubBufferedProducerClient>();

            // Define a failed handler for the mock
            var sendFailed = new Func<SendEventBatchFailedEventArgs, Task>(async args =>
            {
                foreach (var eventData in args.EventBatch)
                {
                    if (eventData.Body.Length != 0)
                    {
                        await bufferedProducerMock.Object.EnqueueEventAsync(eventData);
                    }
                }
            });

            // Create a mock event to fail send
            var eventToEnqueue = EventHubsModelFactory.EventData(new BinaryData("Sample-Event"));
            var eventList = new List<EventData>();
            eventList.Add(eventToEnqueue);

            // Create a set of args to send to the SendEventBatchFailedAsync handler
            var args = new SendEventBatchFailedEventArgs(eventList, new Exception(), "0", default);

            // Setup EnqueueEventAsync to always pass and return 1
            bufferedProducerMock.Setup(bp => bp.EnqueueEventAsync(
                It.IsAny<EventData>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Set up EnqueueEventsAsync to fail and call the defined fail handler using the
            // above created args
            bufferedProducerMock.Setup(bp => bp.EnqueueEventsAsync(
                It.IsAny<List<EventData>>(),
                It.IsAny<CancellationToken>())).Callback(() => sendFailed(args));

            var bufferedProducer = bufferedProducerMock.Object;

            bufferedProducer.SendEventBatchFailedAsync += sendFailed;

#endregion
        }

        [Test]
        public void BufferedProducerPartitionProps()
        {
            #region Snippet:EventHubs_Sample11_BufferedProducerPartitionProps

            // Create the buffered producer mock
            var bufferedProducerMock = new Mock<EventHubBufferedProducerClient>();

            // Define the partitions and their properties
            var partitions = new Dictionary<string, PartitionProperties>()
            {
                // Non-empty partition
                { "0", EventHubsModelFactory.PartitionProperties("eventhub-name", "0", true, 1000, 1100, 500, DateTime.UtcNow) },
                // Empty partition
                { "1", EventHubsModelFactory.PartitionProperties("eventhub-name", "1", false, 2000, 2000, 760, DateTime.UtcNow) }
            };

            // Set up partition Ids
            bufferedProducerMock.Setup(
                p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions.Keys.ToArray());

            // Set up partition properties
            foreach (var partition in partitions)
            {
                bufferedProducerMock.Setup(
                p => p.GetPartitionPropertiesAsync(
                    partition.Key,
                    It.IsAny<CancellationToken>()))
                    .ReturnsAsync(partition.Value);
            }

            #endregion
        }

        [Test]
        public async Task MockingEventProcessor()
        {
#region Snippet:EventHubs_Sample11_MockingEventProcessor

            // TestableCustomProcessor is a wrapper class around a CustomProcessor class that exposes
            // protected methods so that they can be tested
            var eventProcessorMock =
                new Mock<TestableCustomProcessor>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions))
                { CallBase = true };

            var testEvents = new[] {
                EventHubsModelFactory.EventData(new BinaryData("Sample-Event-1")),
                EventHubsModelFactory.EventData(new BinaryData("Sample-Event-2")),
                EventHubsModelFactory.EventData(new BinaryData("Sample-Event-3")),
                EventHubsModelFactory.EventData(new BinaryData("Sample-Event-4")),
            };

            var eventList = new List<EventData>(testEvents);

            var eventProcessor = eventProcessorMock.Object;

            // Call the wrapper method in order to reach proctected method within a custom processor
            // Using It.Is allows the test to set the PartitionId value, even though the setter is protected
            await eventProcessor.TestOnProcessingEventBatchAsync(eventList, It.Is<EventProcessorPartition>(value => value.PartitionId == "0"));

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
    }
}
