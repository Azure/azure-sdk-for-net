// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
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
        public void MockingEventDataBatch()
        {
            #region Snippet:EventHubs_Sample11_MockingEventDataBatch
            var mockProducer = new Mock<EventHubProducerClient>();

            var createBatchOptions = new CreateBatchOptions() { MaximumSizeInBytes = 516 };
            var batchSizeInBytes = 500;

            // Setting up a mock of the CreateBatchAsync method
            mockProducer.Setup(p => p.CreateBatchAsync(
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                EventHubsModelFactory.EventDataBatch(
                    46,
                    new List<EventData>(),
                    new CreateBatchOptions() { },
                    // The model factory allows the user to define a custom TryAdd callback, making
                    // it easy to test specific scenarios
                    eventData =>
                    {
                        return eventData.Body.Length > createBatchOptions.MaximumSizeInBytes - batchSizeInBytes;
                    }));

            // Mocking the SendAsync method so that it will always pass
            mockProducer.Setup(p => p.SendAsync(
                It.IsAny<EventDataBatch>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var producer = mockProducer.Object;

            // Mocking EventData instances for send
            var eventDataBody = new BinaryData("Sample large event body");
            var eventData = EventHubsModelFactory.EventData(eventDataBody);

            // Using the mocked event producer to test that SendAsync was never called
            mockProducer.Verify(bp =>
            bp.SendAsync(
                It.IsAny<EventDataBatch>(),
                It.IsAny<CancellationToken>()),Times.Never);

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

            var mockProducer = new Mock<EventHubProducerClient>();

            // Define the set of partitions and publishing properties to use for testing
            var partitions = new Dictionary<string, PartitionPublishingProperties>()
            {
                // Has no reader ownership - no OwnerLevel
                { "0", EventHubsModelFactory.PartitionPublishingProperties(false, null, null, null) },
                // Has an exclusive reader - OwnerLevel is high
                { "1", EventHubsModelFactory.PartitionPublishingProperties(false, null, 42, null) }
            };

            // Mock the EventHubProperties using the model factory
            var eventHubProperties =
                EventHubsModelFactory.EventHubProperties(
                    "fakeEventHubName", // arbitrary value
                    DateTimeOffset.UtcNow, // arbitrary value
                    partitions.Keys.ToArray());

            // Mocking GetEventHubPropertiesAsync, GetPartitionIdsAsync and GetPartitionPublishingPropertiesAsync
            // (for each partition), using the partitions and properties defined above
            mockProducer.Setup(p => p.GetEventHubPropertiesAsync(
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(eventHubProperties);

            mockProducer.Setup(p => p.GetPartitionIdsAsync(
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions.Keys.ToArray());

            foreach (var partition in partitions)
            {
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

            // Create a mock of LastEnqueuedEventProperties using the model factory
            var lastEnqueueEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(
                default,
                default,
                default, // TODO
                default);

            // Create a mock of PartitionContext using the model factory
            var partitionContext = EventHubsModelFactory.PartitionContext(
                "0",
                lastEnqueueEventProperties);

            var eventData = EventHubsModelFactory.EventData(new BinaryData("Sample-Event"));

            // Create a mock of a partition event using the PartitionContext and EventData
            // instances created above
            var samplePartitionEvent = new PartitionEvent(partitionContext, eventData);
            var partitionEventList = new List<PartitionEvent>();
            partitionEventList.Add(samplePartitionEvent);

            // Use this PartitionEvent to mock a return from the consumer
            mockConsumer.Setup(c =>
            c.ReadEventsAsync(
                It.IsAny<CancellationToken>()))
                .Returns((IAsyncEnumerable<PartitionEvent>)partitionEventList);

            var consumer = mockConsumer.Object;

            #endregion
        }

        [Test]
        public void PartitionReceiverMock()
        {
            #region Snippet:EventHubs_Sample11_PartitionReceiverMock

            // Create a mock of the PartitionReceiver
            var mockReceiver = new Mock<PartitionReceiver>();
            var emptyEventBatch = new List<EventData>();

            // Setup the mock to receive an empty batch when ReceiveBatchAsync is called
            mockReceiver.Setup(
                r => r.ReceiveBatchAsync(
                    It.IsAny<int>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(emptyEventBatch);

            var receiver = mockReceiver.Object;

            #endregion
        }

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

        public void MockingEventProcessor()
        {
            #region Snippet:EventHubs_Sample11_MockingEventProcessor

            // Example checkpoints store

            var checkpoints = new List<long>();

            const int EventsBeforeCheckpoint = 5;
            const int CheckpointsCount = 5;

            // Example handler uses event's SequenceNumber to decide when to checkpoint

            void processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    // Process the event here...

                    if (args.Data.SequenceNumber % EventsBeforeCheckpoint == 0)
                    {
                        checkpoints.Add(args.Data.Offset);
                    }
                }
                catch
                {
                    // Handle the exception...
                }
            }

            var partitionContext = EventHubsModelFactory.PartitionContext("0");

            // Fire (EventsBeforeCheckpoint * CheckpointsCount) number of the events

            for (int eventCount = 1; eventCount <= EventsBeforeCheckpoint * CheckpointsCount; eventCount++)
            {
                // EventData method allows to mock ALL those read-only properties
                // passed over to the event handler in the ProcessEventArgs argument

                var eventData = EventHubsModelFactory.EventData(
                    new BinaryData("This is a sample event body"),
                    null, // The custom event properties can be mocked,
                    null, // as well as the Event Hub's system properties,
                    null, // and the Partition Key.
                    eventCount, // For this demonstration we mock the partition's Sequence Number,
                    eventCount + (1000 * eventCount + new Random().Next(50, 500))); // and the Offset

                var eventArgs = new ProcessEventArgs(
                    partitionContext,
                    eventData,
                    // Do nothing as we use custom checkpoints store
                    _ => Task.CompletedTask);

                // Execute the handler

                processEventHandler(eventArgs);
            }

            // Verify the number of persisted checkpoints

            Assert.IsTrue(checkpoints.Count == CheckpointsCount);

            #endregion
        }
    }
}
