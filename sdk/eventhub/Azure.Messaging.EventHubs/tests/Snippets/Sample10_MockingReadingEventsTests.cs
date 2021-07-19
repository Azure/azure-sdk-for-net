// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    [TestFixture]
    public class Sample10_MockingReadingEventsTests
    {
        /// <summary>
        ///   Performs basic unit test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MockingReadEventsFromPartition()
        {
            #region Snippet:EventHubs_Sample10_MockingReadEventsFromPartition

            var mockEventHubConsumerClient = new Mock<EventHubConsumerClient>();
            var mockPartitionId = "sample partition id";

            mockEventHubConsumerClient
                .Setup(c => c.ReadEventsFromPartitionAsync(It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<CancellationToken>()))
                .Returns(GetMockEventsFromPartition(mockPartitionId));

            var consumer = mockEventHubConsumerClient.Object;
            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                EventPosition startingPosition = EventPosition.Earliest;

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
                    mockPartitionId,
                    startingPosition,
                    cancellationSource.Token))
                {
                    string readFromPartition = partitionEvent.Partition.PartitionId;
                    ReadOnlyMemory<byte> eventBodyBytes = partitionEvent.Data.EventBody.ToMemory();
                }
            }
            catch (TaskCanceledException)
            {
                // This is expected if the cancellation token is
                // signaled.
            }
            finally
            {
                await consumer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic unit test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MockingReadEventsFromPartition_WithLastEnqueuedEventProperties()
        {
            #region Snippet:EventHubs_Sample10_MockingReadEventsFromPartitionWithLastEnqueuedEventProperties

            var mockEventHubConsumerClient = new Mock<EventHubConsumerClient>();
            var mockPartitionId = "sample partition id";
            var lastSequence = long.MaxValue - 100;
            var lastOffset = long.MaxValue - 10;
            var fakeDate = new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero);

            // creating last enqued event properties
            var mockLastEnqueuedEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(lastSequence, lastOffset, fakeDate, fakeDate);

            mockEventHubConsumerClient
                .Setup(c => c.ReadEventsFromPartitionAsync(It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<CancellationToken>()))
                .Returns(GetMockEventsFromPartition(mockPartitionId,mockLastEnqueuedEventProperties));

            var consumer = mockEventHubConsumerClient.Object;
            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                EventPosition startingPosition = EventPosition.Earliest;

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
                    mockPartitionId,
                    startingPosition,
                    cancellationSource.Token))
                {
                    string readFromPartition = partitionEvent.Partition.PartitionId;
                    ReadOnlyMemory<byte> eventBodyBytes = partitionEvent.Data.EventBody.ToMemory();
                    var readLastEnqueuedEventProperties = partitionEvent.Partition.ReadLastEnqueuedEventProperties();
                }
            }
            catch (TaskCanceledException)
            {
                // This is expected if the cancellation token is
                // signaled.
            }
            finally
            {
                await consumer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic unit test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MockingReadPartitionWithReceiver()
        {
            #region Snippet:EventHubs_Sample10_MockingReadPartitionWithReceiver

            var mockEventHubPartitionReceiver = new Mock<PartitionReceiver>();

            // generating mock batch data
            var mockBatchData = new List<EventData>();
            var properties = new Dictionary<string, object> { { "id", 12 } };
            var systemProperties = new Dictionary<string, object> { { "custom", "sys-value" } };
            for (int index = 0; index < 5; ++index)
            {
                var eventBody = new BinaryData($"This is an example event body #{index}");
                mockBatchData.Add(EventHubsModelFactory.EventData(eventBody, properties, systemProperties));
            }

            mockEventHubPartitionReceiver
                .Setup(r => r.ReceiveBatchAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockBatchData)
                .Verifiable();

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            var receiver = mockEventHubPartitionReceiver.Object;
            try
            {
                while (!cancellationSource.IsCancellationRequested)
                {
                    int batchSize = 50;
                    TimeSpan waitTime = TimeSpan.FromSeconds(1);

                    IEnumerable<EventData> eventBatch = await receiver.ReceiveBatchAsync(
                        batchSize,
                        waitTime,
                        cancellationSource.Token);

                    // if needed we can assert the received batch data;
                    // the received batch data would match the mocked batch data we generated above
                }
            }
            catch (TaskCanceledException)
            {
                // This is expected if the cancellation token is
                // signaled.
            }
            finally
            {
                await receiver.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic unit test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MockingEventHubMetaData()
        {
            #region Snippet:EventHubs_Sample10_MockingEventHubMetaData

            var mockEventHubConsumerClient = new Mock<EventHubConsumerClient>();
            var mockEventHubName = "<< NAME OF THE EVENT HUB >>";
            var mockPartitionId = "<< Event Hub Partion Id >>";
            var lastSequence = long.MaxValue - 100;
            var lastOffset = long.MaxValue - 10;
            var fakeDate = new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero);

            // creating last enqued event properties
            var mockLastEnqueuedEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(lastSequence, lastOffset, fakeDate, fakeDate);

            // creating event hub properties
            var mockEventHubProperties = EventHubsModelFactory.EventHubProperties(mockEventHubName, fakeDate, new string[] { mockPartitionId });

            // creating partition properties
            var mockPartitionProperties = EventHubsModelFactory.PartitionProperties(mockEventHubName, mockPartitionId, false, lastSequence, lastSequence, lastOffset, fakeDate);

            // creating partition publishing properties
            var mockPartitionPublishingProperties = EventHubsModelFactory.PartitionPublishingProperties(true, 675, (short)12, 4);

            mockEventHubConsumerClient
                .Setup(c => c.ReadEventsFromPartitionAsync(It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<ReadEventOptions>(),It.IsAny<CancellationToken>()))
                .Returns(GetMockEventsFromPartition(mockPartitionId,mockLastEnqueuedEventProperties))
                .Verifiable();

            mockEventHubConsumerClient
                .Setup(c => c.GetEventHubPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockEventHubProperties);

            mockEventHubConsumerClient
                .Setup(c => c.GetPartitionPropertiesAsync(mockPartitionId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockPartitionProperties);

            var consumer = mockEventHubConsumerClient.Object;

            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                // get partition properties
                // the fetched partition properties will match the mock partition properties we generated above
                PartitionProperties partitionProperties = await consumer.GetPartitionPropertiesAsync(mockPartitionId, cancellationSource.Token);

                EventPosition startingPosition = EventPosition.FromOffset(partitionProperties.LastEnqueuedOffset);

                var options = new ReadEventOptions
                {
                    TrackLastEnqueuedEventProperties = true
                };

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
                    mockPartitionId,
                    startingPosition,
                    options,
                    cancellationSource.Token))
                {
                    // read last enqued event properties
                    // the fetched last enqueued event properties will match the mock last enqueued event properties we generated above
                    LastEnqueuedEventProperties properties =
                        partitionEvent.Partition.ReadLastEnqueuedEventProperties();
                }

                // get event hub properties
                // the fetched event hub properties will match the mock event hub properties we generated above
                var eventHubProperties = await consumer.GetEventHubPropertiesAsync(CancellationToken.None);
            }
            catch (TaskCanceledException)
            {
                // This is expected if the cancellation token is
                // signaled.
            }
            finally
            {
                await consumer.CloseAsync();
            }

            mockEventHubConsumerClient.VerifyAll();

            #endregion
        }

        private async IAsyncEnumerable<PartitionEvent> GetMockEventsFromPartition(string partitionId)
        {
            // we are using this as we dont have an async operation in our test
            await Task.Yield();

            var partitionContext = EventHubsModelFactory.PartitionContext(partitionId);

            yield return new PartitionEvent(partitionContext, new EventData("one"));
            yield return new PartitionEvent(partitionContext, new EventData("two"));
        }

        private async IAsyncEnumerable<PartitionEvent> GetMockEventsFromPartition(string partitionId,LastEnqueuedEventProperties lastEnqueuedEventProperties)
        {
            // we are using this as we dont have an async operation in our test
            await Task.Yield();

            var partitionContext = EventHubsModelFactory.PartitionContext(partitionId, lastEnqueuedEventProperties);

            yield return new PartitionEvent(partitionContext, new EventData("one"));
            yield return new PartitionEvent(partitionContext, new EventData("two"));
        }
    }
}
