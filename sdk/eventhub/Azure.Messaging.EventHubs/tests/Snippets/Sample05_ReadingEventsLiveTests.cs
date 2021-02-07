// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample05_ReadingEvents sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample05_ReadingEventsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadAllPartitions()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadAllPartitions

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                int eventsRead = 0;
                int maximumEvents = 3;

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(cancellationSource.Token))
                {
                    string readFromPartition = partitionEvent.Partition.PartitionId;
                    byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

                    Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
                    eventsRead++;

                    if (eventsRead >= maximumEvents)
                    {
                        break;
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
                await consumer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadAllPartitionsWaitTime()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadAllPartitionsWaitTime

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

            try
            {
                int loopTicks = 0;
                int maximumTicks = 10;

                var options = new ReadEventOptions
                {
                   MaximumWaitTime = TimeSpan.FromSeconds(1)
                };

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(options))
                {
                    if (partitionEvent.Data != null)
                    {
                        string readFromPartition = partitionEvent.Partition.PartitionId;
                        byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

                        Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
                    }
                    else
                    {
                        Debug.WriteLine("Wait time elapsed; no event was available.");
                    }

                    loopTicks++;

                    if (loopTicks >= maximumTicks)
                    {
                        break;
                    }
                }
            }
            finally
            {
                await consumer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadAllPartitionsFromLatest()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadAllPartitionsFromLatest

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(
                    startReadingAtEarliestEvent: false,
                    cancellationToken: cancellationSource.Token))
                {
                    string readFromPartition = partitionEvent.Partition.PartitionId;
                    byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

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
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartition()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadPartition

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

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
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionWaitTime()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadPartitionWaitTime

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                EventPosition startingPosition = EventPosition.Earliest;

                int loopTicks = 0;
                int maximumTicks = 10;

                var options = new ReadEventOptions
                {
                   MaximumWaitTime = TimeSpan.FromSeconds(1)
                };

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
                    firstPartition,
                    startingPosition,
                    options))
                {
                    if (partitionEvent.Data != null)
                    {
                        string readFromPartition = partitionEvent.Partition.PartitionId;
                        byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

                        Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
                    }
                    else
                    {
                        Debug.WriteLine("Wait time elapsed; no event was available.");
                    }

                    loopTicks++;

                    if (loopTicks >= maximumTicks)
                    {
                        break;
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
                await consumer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionFromDate()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadPartitionFromDate

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                DateTimeOffset oneHourAgo = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(1));
                EventPosition startingPosition = EventPosition.FromEnqueuedTime(oneHourAgo);

                string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
                    firstPartition,
                    startingPosition,
                    cancellationSource.Token))
                {
                    string readFromPartition = partitionEvent.Partition.PartitionId;
                    byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

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
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionFromOffset()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadPartitionFromOffset

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                PartitionProperties properties = await consumer.GetPartitionPropertiesAsync(firstPartition, cancellationSource.Token);
                EventPosition startingPosition = EventPosition.FromOffset(properties.LastEnqueuedOffset);

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
                    firstPartition,
                    startingPosition,
                    cancellationSource.Token))
                {
                    string readFromPartition = partitionEvent.Partition.PartitionId;
                    byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

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
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionFromSequence()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadPartitionFromSequence

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                PartitionProperties properties = await consumer.GetPartitionPropertiesAsync(firstPartition, cancellationSource.Token);
                EventPosition startingPosition = EventPosition.FromSequenceNumber(properties.LastEnqueuedSequenceNumber);

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(
                    firstPartition,
                    startingPosition,
                    cancellationSource.Token))
                {
                    string readFromPartition = partitionEvent.Partition.PartitionId;
                    byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

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
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionTrackLastEnqueued()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadPartitionTrackLastEnqueued

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

            try
            {
                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                string firstPartition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                EventPosition startingPosition = EventPosition.Earliest;

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
                    LastEnqueuedEventProperties properties =
                        partitionEvent.Partition.ReadLastEnqueuedEventProperties();

                    Debug.WriteLine($"Partition: { partitionEvent.Partition.PartitionId }");
                    Debug.WriteLine($"\tThe last sequence number is: { properties.SequenceNumber }");
                    Debug.WriteLine($"\tThe last offset is: { properties.Offset }");
                    Debug.WriteLine($"\tThe last enqueued time is: { properties.EnqueuedTime }, in UTC.");
                    Debug.WriteLine($"\tThe information was updated at: { properties.LastReceivedTime }, in UTC.");
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
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionWithReceiver()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample05_ReadPartitionWithReceiver

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            string firstPartition;

            await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
            {
                firstPartition = (await producer.GetPartitionIdsAsync()).First();
            }

            var receiver = new PartitionReceiver(
                consumerGroup,
                firstPartition,
                EventPosition.Earliest,
                connectionString,
                eventHubName);

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

                    foreach (EventData eventData in eventBatch)
                    {
                        byte[] eventBodyBytes = eventData.EventBody.ToArray();
                        Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { firstPartition }");
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
    }
}
