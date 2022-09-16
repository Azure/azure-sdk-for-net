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

            Mock<EventHubProducerClient> mockProducer = new();

            // This sets the value returned by the EventDataBatch when accessing the Size property,
            // it does not impact TryAdd on the mocked batch.

            long batchSizeInBytes = 500;

            // Events added to the batch will be added here, but altering the events in this list will not change the
            // events in the batch, since they are stored inside the batch as well.

            List<EventData> backingList = new();

            // For illustrative purposes, this is the number of events that the batch will contain,
            // returning false from TryAdd for any additional calls.

            int batchCountThreshold = 3;

            EventDataBatch dataBatchMock = EventHubsModelFactory.EventDataBatch(
                    batchSizeBytes : batchSizeInBytes,
                    batchEventStore : backingList,
                    batchOptions : new CreateBatchOptions(),
                    // The model factory allows the user to define a custom TryAdd callback, allowing
                    // control of what events the batch accepts.
                    eventData =>
                    {
                        int eventCount = backingList.Count();
                        return eventCount < batchCountThreshold;
                    });

            // This sets up a mock of the CreateBatchAsync method.

            mockProducer
                .Setup(p => p.CreateBatchAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataBatchMock);

            // Here we are mocking the SendAsync method so that it will throw an exception if the batch passed
            // into it is not the one we are expecting to send.

            mockProducer
                .Setup(p => p.SendAsync(
                    It.Is<EventDataBatch>(sendBatch => sendBatch != dataBatchMock),
                    It.IsAny<CancellationToken>()))
                .Throws(new Exception("The batch published was not the expected batch."));

            EventHubProducerClient producer = mockProducer.Object;

            // The rest of this snippet demonstrates how to use the mocked methods. This would be where
            // application methods can be called and tested.

            EventDataBatch batch = await producer.CreateBatchAsync();

            // This is creating a list of events to use in our test.

            List<EventData> sourceEvents = new();

            for (int index = 0; index < batchCountThreshold; index++)
            {
                var eventData = new EventData($"Sample-Event-{ index }");
                sourceEvents.Add(eventData);
            }

            // Here we are adding events to the batch. They should all be accepted.

            foreach (var eventData in sourceEvents)
            {
                Assert.True(batch.TryAdd(eventData));
            }

            // Since there area already batchCountThreshold number of events in the batch, this event will be
            // rejected from the batch.

            EventData eventData4 = new EventData("Sample-Event-4-will-fail");
            Assert.IsFalse(batch.TryAdd(eventData4));

            // For illustrative purposes we are calling SendAsync. This call would likely already be inside the application-
            // defined method being tested.

            await producer.SendAsync(batch);

            // This is demonstrating how to verify SendAsync was called once within the mocked producer client.

            mockProducer
                .Verify(bp => bp.SendAsync(
                    It.IsAny<EventDataBatch>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            // For illustrative purposes, check that the events in the batch match what the application expects
            // to have added.

            foreach (EventData eventData in backingList)
            {
                Assert.IsTrue(sourceEvents.Contains(eventData));
            }
            Assert.AreEqual(backingList.Count, sourceEvents.Count);

            #endregion
        }

        [Test]
        public async Task MockingBufferedProducer()
        {
            #region Snippet:EventHubs_Sample11_MockingBufferedProducer

            Mock<EventHubBufferedProducerClient> bufferedProducerMock = new();

            // For this scenario, set up EnqueueEventAsync to always pass and return 1.

            bufferedProducerMock
                .Setup(bp => bp.EnqueueEventAsync(
                    It.IsAny<EventData>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            EventHubBufferedProducerClient bufferedProducer = bufferedProducerMock.Object;

            // The following demonstrates how to use the mocked EnqueueEventAsync. This would be where application
            // methods can be called and tested.

            // This is an illustrative fail handler that can be added to the mock buffered producer.

            Func<SendEventBatchFailedEventArgs, Task> sendFailed = new(async args =>
            {
                foreach (EventData eventData in args.EventBatch)
                {
                    // Do more complex error handling here...

                    Debug.WriteLine($"Publishing failed for {args.EventBatch.Count} events.  Error: '{args.Exception.Message}'");
                    await Task.CompletedTask;
                }
            });

            bufferedProducer.SendEventBatchFailedAsync += sendFailed;

            // For illustrative purposes, enqueue a set of events to be published.

            int numOfEventsToEnqueue = 15;
            CancellationTokenSource cancellationTokenSource = new();

            for (int index = 0; index < numOfEventsToEnqueue; index++)
            {
                EventData eventToEnqueue = new(index.ToString());
                await bufferedProducer.EnqueueEventAsync(eventToEnqueue, cancellationTokenSource.Token);
            }

            // This demonstrates how to verify that EnqueueEventAsync was called the correct number of times,
            // with the expected arguments.

            for (int index = 0; index < numOfEventsToEnqueue; index++)
            {
                bufferedProducerMock
                    .Verify(bp => bp.EnqueueEventAsync(
                        It.Is<EventData>(e => (e.EventBody.ToString().Equals(index.ToString()))), // Check that enqueue was called on each expected event body
                        It.IsAny<CancellationToken>()));
            }

            // The following lines demonstrate how to test a fail handler by calling it directly. Testing fail and success handlers
            // does not require mocking.

            int numEventsInBatch = 12;
            List<EventData> eventsInBatch = new();

            for (int index = 0; index < numEventsInBatch; index++)
            {
                EventData eventToEnqueue = new(index.ToString());
                await bufferedProducer.EnqueueEventAsync(eventToEnqueue, cancellationTokenSource.Token);
            }

            SendEventBatchFailedEventArgs args = new SendEventBatchFailedEventArgs(eventsInBatch, new Exception(), "0", default);

            Assert.DoesNotThrowAsync(async () => await sendFailed(args));

            // The expected outcome of any application-specific complex processing can be asserted here.

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MockingProducerProperties()
        {
            #region Snippet:EventHubs_Sample11_MockingProducerProperties

            // The first part of this snippet demonstrates mocking EventHubProperties on
            // an EventHubProducerClient. This same method can be used with EventHubBufferedProducerClients
            // and EventHubConsumerClients as well.

            Mock<EventHubProducerClient> mockProducer = new();

            // Here we are defining the set of partitions we want for our testing scenario.

            List<string> producerPartitions = new() { "0", "1" };

            // Using the model factory, this call creates a mock of the EventHubProperties.

            EventHubProperties eventHubProperties =
                EventHubsModelFactory.EventHubProperties(
                    name: "fakeEventHubName",
                    createdOn: DateTimeOffset.UtcNow, // arbitrary value
                    partitionIds: producerPartitions.ToArray());

            // This sets up GetEventHubPropertiesAsync to return the mocked Event Hub properties above.

            mockProducer
                .Setup(p => p.GetEventHubPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(eventHubProperties);

            // This sets up GetPartitionIdsAsync to return the mocked partition Ids above.

            mockProducer
                .Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(producerPartitions.ToArray());

            EventHubProducerClient producer = mockProducer.Object;

            // Here we are demonstrating how to access the mocked EventHubProperties for illustrative
            // purposes.

            EventHubProperties properties = await producer.GetEventHubPropertiesAsync();
            string eventHubName = properties.Name;
            Debug.WriteLine($"Sending Events to: {eventHubName}");

            // The second part of this snippet demonstrates mocking PartitionProperties on an
            // EventHubBufferedProducerClient, which again can be done in the same way for the
            // EventHubProducerClient and EventHubConsumerClient types.

            Mock<EventHubBufferedProducerClient> bufferedProducerMock = new();

            // This creates the set of partitions to mock for this test, and mocks the PartitionProperty
            // instances using the model factory.

            Dictionary<string, PartitionProperties> partitionProperties = new()
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

            // This sets up GetPartitionIdsAsync to return the set of partition Ids mocked
            // above.

            bufferedProducerMock
                .Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitionProperties.Keys.ToArray());

            // This sets up GetPartitionPropertiesAsync to return the right PartitionProperties
            // mock for each partition Id input.

            foreach (KeyValuePair<string, PartitionProperties> partition in partitionProperties)
            {
                bufferedProducerMock
                    .Setup(p => p.GetPartitionPropertiesAsync(
                        partition.Key,
                        It.IsAny<CancellationToken>()))
                    .ReturnsAsync(partition.Value);
            }

            // The following demonstrates how to use the mocked partition Ids and PartitionProperties. This would be
            // where application code utilizing the mocked methods could be called and verified.

            EventHubBufferedProducerClient bufferedProducer = bufferedProducerMock.Object;

            CancellationTokenSource cancellationTokenSource = new();

            // This gets all the partition Ids and arbitrarily takes the first partition Id.

            string[] partitionIds = await bufferedProducer.GetPartitionIdsAsync(cancellationTokenSource.Token);
            string partitionId = partitionIds[0];

            // This gets the partition properties for the first partition Id.

            PartitionProperties firstPartitionProperties =
                await bufferedProducer.GetPartitionPropertiesAsync(partitionId, cancellationTokenSource.Token);

            string isPartitionEmpty = firstPartitionProperties.IsEmpty.ToString();

            Debug.WriteLine($"Sending Events to: {isPartitionEmpty}");
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

            Mock<EventHubConsumerClient> mockConsumer = new();

            // This creates a mock LastEnqueuedEventProperties using the model factory.

            LastEnqueuedEventProperties lastEnqueueEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(
                lastSequenceNumber : 1234,
                lastOffset : 234,
                lastEnqueuedTime : DateTimeOffset.Parse("1:24 AM"),
                lastReceivedTime : DateTimeOffset.Parse("1:26 AM"));

            // This creates a mock of PartitionContext using the model factory.

            PartitionContext partitionContext = EventHubsModelFactory.PartitionContext(
                partitionId : "0",
                lastEnqueuedEventProperties : lastEnqueueEventProperties);

            // This is a simple local method that returns an IAsyncEnumerable to use as the return for
            // ReadEventsAsync below, since IAsyncEnumerables cannot be created directly.

            async IAsyncEnumerable<PartitionEvent> mockReturn()
            {
                for (int index = 0; index < 3; index++)
                {
                    // This mocks an EventData instance using the model factory. Different arguments can mock different
                    // potential outputs from the broker.

                    EventData eventData = EventHubsModelFactory.EventData(
                        eventBody: new BinaryData($"Sample-Event-{ index }"),
                        systemProperties: new Dictionary<string, object>(), //arbitrary value
                        partitionKey: "sample-key",
                        sequenceNumber: 1000,
                        offset: 1500,
                        enqueuedTime: DateTimeOffset.Parse("11:36 PM"));

                    // This creates a mock PartitionEvent to return from the consumer client.

                    PartitionEvent samplePartitionEvent = new PartitionEvent(partitionContext, eventData);
                    List<PartitionEvent> partitionEventList = new List<PartitionEvent> { samplePartitionEvent };

                    // IAsyncEnumerable types can only be returned by async functions, use this no-op await statement to
                    // force the method to be async.

                    await Task.Yield();

                    // Yield statements allow methods to emit multiple outputs. In async methods this can be over time.

                    yield return samplePartitionEvent;
                }
            }

            // Use the method to mock a return from the consumer. We are setting up the method to return partition events that
            // include the last enqueued event properties if the tracking flag is set in the options.

            mockConsumer
                .Setup(c => c.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.Is<ReadEventOptions>(opts => opts.TrackLastEnqueuedEventProperties),
                    It.IsAny<CancellationToken>()))
                .Returns(mockReturn());

            // This sets up the consumer client to return a mocked set of partition Ids.

            string[] consumerPartitions = new string[] { "0", "1" };

            mockConsumer
                .Setup(p => p.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(consumerPartitions);

            // The following demonstrates how to use the mocked methods. This would be where application methods
            // can be called and tested.

            EventHubConsumerClient consumer = mockConsumer.Object;

            using CancellationTokenSource cancellationTokenSource = new();

            // Here we are setting the TrackLastEnqueuedEventProperties flag so that the EventHubConsumerClient receives
            // LastEnqueuedEventProperties when reading events.

            ReadEventOptions options = new()
            {
                TrackLastEnqueuedEventProperties = true
            };

            string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationTokenSource.Token)).First();
            EventPosition startingPosition = EventPosition.Earliest;

            await foreach (PartitionEvent receivedEvent in consumer.ReadEventsFromPartitionAsync(firstPartition, startingPosition, options, cancellationTokenSource.Token))
            {
                // This could be where application code is handling partition events.
            }

            // This is where applications can verify that the partition events output by the consumer client were handled as expected.
            #endregion
        }

        [Test]
        public async Task PartitionReceiverMock()
        {
            #region Snippet:EventHubs_Sample11_PartitionReceiverMock

            Mock<PartitionReceiver> mockReceiver = new();

            // ReceivedEvents is a list of events to use when mocking ReceiveBatchAsync within the PartitionReceiver.

            List<EventData> receivedEvents = new();

            for (int i=0; i<10; i++)
            {
                // Mocking an EventData instance, different arguments can simulate different potential
                // outputs from the broker
                EventData eventData = EventHubsModelFactory.EventData(
                    eventBody: new BinaryData($"Sample-Event-{i}"),
                    systemProperties: new Dictionary<string, object>(), //arbitrary value
                    partitionKey: $"sample-key-{i}",
                    sequenceNumber: 1234,
                    offset: 234,
                    enqueuedTime: DateTimeOffset.Parse("9:25 AM"));

                receivedEvents.Add(eventData);
            }

            // This sets up the mock to receive the list of events defined above when ReceiveBatchAsync is called
            // on a given partition.

            mockReceiver
                .Setup(r => r.ReceiveBatchAsync(
                    It.IsAny<int>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(receivedEvents);

            // The following demonstrates how to use the mocked methods. This would be where application code utilizing
            // the mocked methods could be called and verified.

            PartitionReceiver receiver = mockReceiver.Object;

            using CancellationTokenSource cancellationTokenSource = new();

            IEnumerable<EventData> receivedBatch = await receiver.ReceiveBatchAsync(
                maximumEventCount: 10,
                TimeSpan.FromSeconds(1),
                cancellationTokenSource.Token);

            #endregion
        }
    }
}
