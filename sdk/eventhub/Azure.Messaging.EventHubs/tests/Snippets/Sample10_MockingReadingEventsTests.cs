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
        public async Task ReadPartition()
        {
            #region Snippet:EventHubs_Sample05_MockingEventHubConsumer

            var mockEventHubConsumerClient = new Mock<EventHubConsumerClient>();
            var mockPartitionId = "sample partition id";

            mockEventHubConsumerClient
                .Setup(c => c.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new string[] { mockPartitionId });
            mockEventHubConsumerClient
                .Setup(c => c.ReadEventsFromPartitionAsync(It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<CancellationToken>()))
                .Returns(GetMockEventsFromPartition(mockPartitionId));

            var consumer = mockEventHubConsumerClient.Object;
            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                EventPosition startingPosition = EventPosition.Earliest;

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
                    firstPartition,
                    startingPosition,
                    cancellationSource.Token))
                {
                    string readFromPartition = partitionEvent.Partition.PartitionId;
                    ReadOnlyMemory<byte> eventBodyBytes = partitionEvent.Data.EventBody.ToMemory();

                    Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
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
        public async Task ReadPartitionWithReceiver()
        {
            #region Snippet:EventHubs_Sample10_MockingReadPartitionWithReceiver

            var mockEventHubProducerClient = new Mock<EventHubProducerClient>();
            mockEventHubProducerClient
                .Setup(c => c.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new string[1] { "sample id" });

            var mockEventHubPartitionReceiver = new Mock<PartitionReceiver>();
            var mockBatchData = GenerateBatchData();
            mockEventHubPartitionReceiver
                .Setup(r => r.ReceiveBatchAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockBatchData)
                .Verifiable();

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            string firstPartition;

            await using (var producer = mockEventHubProducerClient.Object)
            {
                firstPartition = (await producer.GetPartitionIdsAsync()).First();
            }

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

                    //do we need assertion like this?
                    for (var index = 0; index < mockBatchData.Count(); ++index)
                    {
                        Assert.AreEqual(mockBatchData.ElementAt(index).EventBody.ToString(), eventBatch.ElementAt(index).EventBody.ToString());
                    }
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
        public async Task ReadPartitionTrackLastEnqueued()
        {
            #region Snippet:EventHubs_Sample10_MockingEventHubMetaData

            var mockEventHubConsumerClient = new Mock<EventHubConsumerClient>();
            var mockEventHubName = "<< NAME OF THE EVENT HUB >>";
            var mockPartitionId = "<< Event Hub Partion Id >>";
            var lastSequence = long.MaxValue - 100;
            var lastOffset = long.MaxValue - 10;
            var fakeDate = new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero);

            // creating last enqued event properties
            var mockLastEnquedEventProperties = EventHubsModelFactory.LastEnqueuedEventProperties(lastSequence,lastOffset, fakeDate, fakeDate);

            // creating event hub properties
            var mockEventHubProperties = EventHubsModelFactory.EventHubProperties(mockEventHubName, fakeDate, new string[] { mockPartitionId });

            // creating partition properties
            var mockPartitionProperties = EventHubsModelFactory.PartitionProperties(mockEventHubName, mockPartitionId, false, lastSequence, lastSequence, lastOffset, fakeDate);

            // creating partition publishing properties
            var mockPartitionPublishingProperties = EventHubsModelFactory.PartitionPublishingProperties(true, 675, (short)12, 4);

            mockEventHubConsumerClient
                .Setup(c => c.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new string[] { mockPartitionId });

            mockEventHubConsumerClient
                .Setup(c => c.ReadEventsFromPartitionAsync(It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<ReadEventOptions>(),It.IsAny<CancellationToken>()))
                .Returns(GetMockEventsFromPartition(mockPartitionId,mockLastEnquedEventProperties))
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

                string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                // get partition properties
                PartitionProperties partitionProperties = await consumer.GetPartitionPropertiesAsync(firstPartition, cancellationSource.Token);

                // assert partition properties
                Assert.IsNotNull(partitionProperties);
                Assert.AreEqual(mockPartitionProperties.EventHubName, partitionProperties.EventHubName);
                Assert.AreEqual(mockPartitionProperties.Id, partitionProperties.Id);
                Assert.AreEqual(mockPartitionProperties.BeginningSequenceNumber, partitionProperties.BeginningSequenceNumber);
                Assert.AreEqual(mockPartitionProperties.LastEnqueuedSequenceNumber, partitionProperties.LastEnqueuedSequenceNumber);
                Assert.AreEqual(mockPartitionProperties.LastEnqueuedOffset, partitionProperties.LastEnqueuedOffset);
                Assert.AreEqual(mockPartitionProperties.LastEnqueuedTime, partitionProperties.LastEnqueuedTime);
                Assert.AreEqual(mockPartitionProperties.IsEmpty, partitionProperties.IsEmpty);

                EventPosition startingPosition = EventPosition.FromOffset(partitionProperties.LastEnqueuedOffset);

                var options = new ReadEventOptions
                {
                    TrackLastEnqueuedEventProperties = true
                };

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
                    firstPartition,
                    startingPosition,
                    options,
                    cancellationSource.Token))
                {
                    // read last enqued event properties
                    LastEnqueuedEventProperties properties =
                        partitionEvent.Partition.ReadLastEnqueuedEventProperties();

                    // asserting last enqued event properties
                    Assert.IsNotNull(properties);
                    Assert.AreEqual(mockPartitionId, partitionEvent.Partition.PartitionId);
                    Assert.AreEqual(lastSequence, properties.SequenceNumber);
                    Assert.AreEqual(lastOffset, properties.Offset);
                    Assert.AreEqual(fakeDate, properties.EnqueuedTime);
                    Assert.AreEqual(fakeDate, properties.LastReceivedTime);
                }

                // get event hub properties
                var eventHubProperties = await consumer.GetEventHubPropertiesAsync(CancellationToken.None);

                // assert event hub properties
                Assert.IsNotNull(eventHubProperties);
                Assert.AreEqual(mockEventHubProperties.Name, eventHubProperties.Name);
                Assert.AreEqual(mockEventHubProperties.PartitionIds, eventHubProperties.PartitionIds);
                Assert.AreEqual(mockEventHubProperties.CreatedOn, eventHubProperties.CreatedOn);

                // assert partition publishing properties
                Assert.IsNotNull(mockPartitionPublishingProperties);
                Assert.IsTrue(mockPartitionPublishingProperties.IsIdempotentPublishingEnabled);
                Assert.AreEqual(675,mockPartitionPublishingProperties.ProducerGroupId);
                Assert.AreEqual((short)12,mockPartitionPublishingProperties.OwnerLevel);
                Assert.AreEqual(4, mockPartitionPublishingProperties.LastPublishedSequenceNumber);
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

        private IEnumerable<EventData> GenerateBatchData()
        {
            var generatedBatchData = new List<EventData>();
            var properties = new Dictionary<string, object> { { "id", 12 } };
            var systemProperties = new Dictionary<string, object> { { "custom", "sys-value" } };

            for (int index = 0; index < 5; ++index)
            {
                var eventBody = new BinaryData($"This is an example event body #{index}");
                generatedBatchData.Add(EventHubsModelFactory.EventData(eventBody, properties, systemProperties));
            }

            return generatedBatchData;
        }

        private async IAsyncEnumerable<PartitionEvent> GetMockEventsFromPartition(string partitionId,LastEnqueuedEventProperties lastEnqueuedEventProperties = default)
        {
            // we are using this as we dont have an async operation in our test
            await Task.Yield();

            var partitionContext = EventHubsModelFactory.PartitionContext(partitionId, lastEnqueuedEventProperties);
            var eventBody = new BinaryData("This is an example event body");
            var properties = new Dictionary<string, object> { { "id", 12 } };
            var systemProperties = new Dictionary<string, object> { { "custom", "sys-value" } };
            var eventData = EventHubsModelFactory.EventData(eventBody, properties, systemProperties);

            yield return new PartitionEvent(partitionContext, eventData);
        }
    }
}
