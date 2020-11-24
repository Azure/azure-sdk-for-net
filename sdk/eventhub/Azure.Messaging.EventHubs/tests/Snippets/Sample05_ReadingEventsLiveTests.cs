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
    [Ignore("Debugging Potential Hang")]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample05_ReadingEventsLiveTests
    {
        /// <summary>The active Event Hub resource scope for the test fixture.</summary>
        private EventHubScope _scope;

        /// <summary>The set of available consumer groups for tests to use.</summary>
        private Queue<string> _availableConsumerGroups = new Queue<string>();

        /// <summary>
        ///   Performs the tasks needed to initialize the test fixture.  This
        ///   method runs once for the entire fixture, prior to running any tests.
        /// </summary>
        ///
        [OneTimeSetUp]
        public async Task FixtureSetUp()
        {
            // Create a set of consumer groups to ensure that there aren't too
            // many concurrent readers when tests are executed concurrently.

            var testCount = GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(method => method.GetCustomAttribute(typeof(TestAttribute)) != null)
                .Count();

            var readersPerGroup = 5;
            var consumerGroupCount = Math.Ceiling((double)testCount / readersPerGroup);
            var consumerGroups = Enumerable.Range(0, (int)consumerGroupCount).Select(index => $"group{ index }");

            foreach (var group in consumerGroups)
            {
                for (var index = 0; index < readersPerGroup; ++index)
                {
                    _availableConsumerGroups.Enqueue(group);
                }
            }

            _scope = await EventHubScope.CreateAsync(2, consumerGroups);

            // Because some snippets assume events are present in the first partition, publish
            // a small set to satisfy the assumption.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _scope.EventHubName);

            var toPublish = Enumerable
                .Range(0, 5)
                .Select(index => new EventData(new BinaryData($"Event: { index }")));

            var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
            var options = new SendEventOptions { PartitionId = partition };

            await producer.SendAsync(toPublish, options);
        }

        /// <summary>
        ///   Performs the tasks needed to cleanup the test fixture after all
        ///   tests have run.  This method runs once for the entire fixture.
        /// </summary>
        ///
        [OneTimeTearDown]
        public async Task FixtureTearDown()
        {
            await _scope.DisposeAsync();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadAllPartitions()
        {
            #region Snippet:EventHubs_Sample05_ReadAllPartitions

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
            #region Snippet:EventHubs_Sample05_ReadAllPartitionsWaitTime

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
            #region Snippet:EventHubs_Sample05_ReadAllPartitionsFromLatest

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
            #region Snippet:EventHubs_Sample05_ReadPartition

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
            #region Snippet:EventHubs_Sample05_ReadPartitionWaitTime

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
            #region Snippet:EventHubs_Sample05_ReadPartitionFromDate

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
            #region Snippet:EventHubs_Sample05_ReadPartitionFromOffset

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
            #region Snippet:EventHubs_Sample05_ReadPartitionFromSequence

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
            #region Snippet:EventHubs_Sample05_ReadPartitionTrackLastEnqueued

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
            #region Snippet:EventHubs_Sample05_ReadPartitionWithReceiver

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ consumerGroup = _availableConsumerGroups.Dequeue();

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
