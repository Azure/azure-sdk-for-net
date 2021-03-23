// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="PartitionReceiver" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a dependency on live Azure services and may
    ///   incur costs for the associated Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class PartitionReceiverLiveTests
    {
        /// <summary>The value to use as the prefetch count for low-prefetch scenarios.</summary>
        private const int LowPrefetchCount = 5;

        /// <summary>A set of options for reading using a small prefetch buffer.</summary>
        private readonly PartitionReceiverOptions LowPrefetchOptions = new PartitionReceiverOptions { PrefetchCount = LowPrefetchCount };

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ReceiverWithNoOptionsCanRead(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString, new EventHubConnectionOptions { TransportType = transportType }))
                {
                    var partition = (await connection.GetPartitionIdsAsync(new EventHubsRetryOptions().ToRetryPolicy(), cancellationSource.Token)).First();

                    await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString))
                    {
                        Assert.That(async () => await ReadNothingAsync(receiver, cancellationSource.Token), Throws.Nothing);
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ReceiverWithOptionsCanRead(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var options = new PartitionReceiverOptions();
                options.RetryOptions.MaximumRetries = 7;
                options.ConnectionOptions.TransportType = transportType;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, options))
                {
                    Assert.That(async () => await ReadNothingAsync(receiver, cancellationSource.Token), Throws.Nothing);
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadSingleZeroLengthEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var singleEvent = EventGenerator.CreateEventFromBody(Array.Empty<byte>());

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, new EventData[] { singleEvent }, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString))
                {
                    var readState = await ReadEventsAsync(receiver, 1, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(1), "A single event was sent.");
                    Assert.That(readState.Events.Values.Single().IsEquivalentTo(singleEvent), "The single event did not match the corresponding read event.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadSingleEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var singleEvent = EventGenerator.CreateEvents(1).Single();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, new EventData[] { singleEvent }, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString))
                {
                    var readState = await ReadEventsAsync(receiver, 1, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(1), "A single event was sent.");
                    Assert.That(readState.Events.Values.Single().IsEquivalentTo(singleEvent), "The single event did not match the corresponding read event.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadSingleLargeEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var buffer = new byte[100000];
                new Random().NextBytes(buffer);

                var singleEvent = EventGenerator.CreateEventFromBody(buffer);
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, new EventData[] { singleEvent }, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString))
                {
                    var readState = await ReadEventsAsync(receiver, 1, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(1), "A single event was sent.");
                    Assert.That(readState.Events.Values.Single().IsEquivalentTo(singleEvent), "The single event did not match the corresponding read event.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadBatchOfZeroLengthEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var sourceEvents = Enumerable
                    .Range(0, 25)
                    .Select(index => EventGenerator.CreateEventFromBody(Array.Empty<byte>()))
                    .ToList();

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString))
                {
                    var readState = await ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadBatchOfEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString))
                {
                    var readState = await ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadBatchOfEventsWithPrefetchSize()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                var recieverOptions = new PartitionReceiverOptions
                {
                    PrefetchSizeInBytes = 64
                };

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, recieverOptions))
                {
                    var readState = await ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadEventsWithCustomProperties()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var sourceEvents = EventGenerator.CreateEvents(50)
                    .Select(current =>
                    {
                        current.Properties["Something"] = DateTimeOffset.UtcNow;
                        current.Properties["Other"] = Guid.NewGuid().ToString();

                        return current;
                    })
                    .ToList();

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString))
                {
                    var readState = await ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadEventsUsingAnIdentityCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var credential = EventHubsTestEnvironment.Instance.Credential;
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var readState = await ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadEventsUsingTheSharedKeyCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var credential = new EventHubsSharedAccessKeyCredential(EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var readState = await ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadFromEarliest()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString))
                {
                    var readState = await ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadFromLatest()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Latest, connectionString))
                {
                    // Send a set of seed events to the partition, which should not be read.

                    await SendEventsAsync(connectionString, EventGenerator.CreateEvents(50), new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Begin reading though no events have been published.  This is necessary to open the connection and
                    // ensure that the receiver is watching the partition.

                    var readTask = ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token);

                    // Give the receiver a moment to ensure that it is established and then send events for it to read.

                    await Task.Delay(250);
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Await reading of the events and validate the resulting state.

                    var readState = await readTask;
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(sourceEvents.Count), "Only the source events should have been read.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ReceiverCanReadFromOffset(bool isInclusive)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                var seedEvents = EventGenerator.CreateEvents(50).ToList();
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                // Seed the partition with a set of events prior to reading.  When the send call returns, all events were
                // accepted by the Event Hubs service and should be available in the partition.  Provide a minor delay to
                // allow for any latency within the service.
                //
                // Once sent, query the partition and determine the offset of the last enqueued event, then send the new set
                // of events that should appear after the starting position.

                long lastOffset;
                EventPosition startingPosition;

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    await SendEventsAsync(connectionString, seedEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                    await Task.Delay(250);

                    lastOffset = (await producer.GetPartitionPropertiesAsync(partition, cancellationSource.Token)).LastEnqueuedOffset;
                    startingPosition = EventPosition.FromOffset(lastOffset, isInclusive);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                }

                // Read the events and validate the resulting state.

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, startingPosition, connectionString))
                {
                    var expectedCount = (isInclusive) ? sourceEvents.Count + 1 : sourceEvents.Count;
                    var readState = await ReadEventsAsync(receiver, expectedCount, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(expectedCount), "The wrong number of events was read for the value of the inclusive flag.");
                    Assert.That(readState.Events.Values.Any(readEvent => readEvent.Offset == lastOffset), Is.EqualTo(isInclusive), $"The event with offset [{ lastOffset }] was { ((isInclusive) ? "not" : "") } in the set of read events, which is inconsistent with the inclusive flag.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ReceiverCanReadFromSequenceNumber(bool isInclusive)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                var seedEvents = EventGenerator.CreateEvents(50).ToList();
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                // Seed the partition with a set of events prior to reading.  When the send call returns, all events were
                // accepted by the Event Hubs service and should be available in the partition.  Provide a minor delay to
                // allow for any latency within the service.
                //
                // Once sent, query the partition and determine the offset of the last enqueued event, then send the new set
                // of events that should appear after the starting position.

                long lastSequence;
                EventPosition startingPosition;

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    await SendEventsAsync(connectionString, seedEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                    await Task.Delay(250);

                    lastSequence = (await producer.GetPartitionPropertiesAsync(partition, cancellationSource.Token)).LastEnqueuedSequenceNumber;
                    startingPosition = EventPosition.FromSequenceNumber(lastSequence, isInclusive);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                }

                // Read the events and validate the resulting state.

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, startingPosition, connectionString))
                {
                    var expectedCount = (isInclusive) ? sourceEvents.Count + 1 : sourceEvents.Count;
                    var readState = await ReadEventsAsync(receiver, expectedCount, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(expectedCount), "The wrong number of events was read for the value of the inclusive flag.");
                    Assert.That(readState.Events.Values.Any(readEvent => readEvent.SequenceNumber == lastSequence), Is.EqualTo(isInclusive), $"The event with sequence number [{ lastSequence }] was { ((isInclusive) ? "not" : "") } in the set of read events, which is inconsistent with the inclusive flag.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadFromEnqueuedTime()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                var seedEvents = EventGenerator.CreateEvents(50).ToList();
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                // Seed the partition with a set of events prior to reading.  When the send call returns, all events were
                // accepted by the Event Hubs service and should be available in the partition.  Provide a minor delay to
                // allow for any latency within the service.
                //
                // Once sent, query the partition and determine the offset of the last enqueued event, then send the new set
                // of events that should appear after the starting position.

                DateTimeOffset lastEnqueuedTime;
                EventPosition startingPosition;

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    await SendEventsAsync(connectionString, seedEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                    await Task.Delay(250);

                    lastEnqueuedTime = (await producer.GetPartitionPropertiesAsync(partition, cancellationSource.Token)).LastEnqueuedTime;
                    startingPosition = EventPosition.FromEnqueuedTime(lastEnqueuedTime);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                }

                // Read the events and validate the resulting state.

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, startingPosition, connectionString))
                {
                    var readState = await ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(sourceEvents.Count), "The number of events received should match.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadFromMultipleConsumerGroups()
        {
            var customConsumerGroup = "anotherConsumerGroup";

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1, new[] { customConsumerGroup }))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var customReceiver = new PartitionReceiver(customConsumerGroup, partition, EventPosition.Earliest, connectionString))
                await using (var defaultReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString))
                {
                    var readState = await Task.WhenAll
                    (
                        ReadEventsAsync(customReceiver, sourceEvents.Count, cancellationSource.Token),
                        ReadEventsAsync(defaultReceiver, sourceEvents.Count, cancellationSource.Token)
                    );

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState[0].Events.TryGetValue(sourceId, out var customReadEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed for the custom receiver group.");
                        Assert.That(sourceEvent.IsEquivalentTo(customReadEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event for the custom receiver group.");

                        Assert.That(readState[1].Events.TryGetValue(sourceId, out var defaultReadEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed for the default receiver group.");
                        Assert.That(sourceEvent.IsEquivalentTo(defaultReadEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event for the default receiver group.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReadFromInvalidConsumerGroup()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var invalidConsumerGroup = "ThisIsFake";
                var partition = (await QueryPartitionsAsync(EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName), cancellationSource.Token)).First();

                await using (var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                await using (var receiver = new PartitionReceiver(invalidConsumerGroup, partition, EventPosition.Earliest, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    var readTask = ReadNothingAsync(receiver, cancellationSource.Token);

                    Assert.That(async () => await readTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ResourceNotFound));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReadWithInvalidProxy()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var clientOptions = new PartitionReceiverOptions();
                clientOptions.RetryOptions.MaximumRetries = 0;
                clientOptions.RetryOptions.MaximumDelay = TimeSpan.FromMilliseconds(5);
                clientOptions.RetryOptions.TryTimeout = TimeSpan.FromSeconds(45);
                clientOptions.ConnectionOptions.Proxy = new WebProxy("http://1.2.3.4:9999");
                clientOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

                var partition = (await QueryPartitionsAsync(EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName), cancellationSource.Token)).First();

                await using (var invalidProxyReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName, clientOptions))
                {
                    // The sockets implementation in .NET Core on some platforms, such as Linux, does not trigger a specific socket exception and
                    // will, instead, hang indefinitely.  The try timeout is intentionally set to a value smaller than the cancellation token to
                    // invoke a timeout exception in these cases.

                    Assert.That(async () => await ReadNothingAsync(invalidProxyReceiver, cancellationSource.Token, iterationCount: 25), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReadAcrossPartitions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var credential = EventHubsTestEnvironment.Instance.Credential;
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                // Send events to the second partition, which should not be visible to the receiver.

                var partitions = await QueryPartitionsAsync(connectionString, cancellationSource.Token);
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[1] }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partitions[0], EventPosition.Earliest, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    // Attempt to read from the empty partition and verify that no events are observed.  Because no events are expected, the
                    // read operation will not naturally complete; limit the read to only a couple of seconds and trigger cancellation.

                    using var readCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token);
                    readCancellation.CancelAfter(TimeSpan.FromSeconds(15));

                    var readState = await ReadEventsAsync(receiver, sourceEvents.Count, readCancellation.Token, waitTime: TimeSpan.FromMilliseconds(250));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The main cancellation token should not have been signaled.");

                    Assert.That(readState.Events.Count, Is.Zero, "No events should have been read from the empty partition.");
                    Assert.That(readState.EmptyCount, Is.GreaterThan(0), "At least one empty receive should have occurred.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReadWhenClosed()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(100).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, LowPrefetchOptions))
                {
                    // Create a local function that will close the receiver after five events have
                    // been read.  Because the close happens during the read loop, allow for a short
                    // delay to ensure that the state transition has been fully captured.

                    async Task<bool> closeAfterFiveRead(ReadState state)
                    {
                        if (state.Events.Count >= 2)
                        {
                            await receiver.CloseAsync(cancellationSource.Token);
                            await Task.Yield();
                        }

                        return true;
                    }

                    var readTask = ReadEventsAsync(receiver, sourceEvents.Count, cancellationSource.Token, iterationCallback: closeAfterFiveRead);

                    Assert.That(async () => await readTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReadFromInvalidPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, "-1", EventPosition.Earliest, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    var readTask = ReadNothingAsync(receiver, cancellationSource.Token);

                    Assert.That(async () => await readTask, Throws.InstanceOf<ArgumentOutOfRangeException>());
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReadAsNonExclusiveWhenAnExclusiveReaderIsActive()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var exclusiveOptions = new PartitionReceiverOptions { OwnerLevel = 20, PrefetchCount = LowPrefetchCount };
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var exclusiveReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, exclusiveOptions))
                await using (var nonExclusiveReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, LowPrefetchOptions))
                {
                    var exclusiveMonitor = MonitorReadingEvents(exclusiveReceiver, int.MaxValue, cancellationSource.Token);
                    await Task.WhenAny(exclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    var nonExclusiveReadTask = ReadEventsAsync(nonExclusiveReceiver, int.MaxValue, cancellationSource.Token);
                    Assert.That(async () => await nonExclusiveReadTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected), "The non-exclusive read should be rejected.");
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    cancellationSource.Cancel();
                    await exclusiveMonitor.ReadTask;
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReadWithLowerOwnerLevelThanActiveReader()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = new PartitionReceiverOptions { OwnerLevel = 40, PrefetchCount = LowPrefetchCount };
                var lowerOptions = new PartitionReceiverOptions { OwnerLevel = 20, PrefetchCount = LowPrefetchCount };
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var higherReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, higherOptions))
                await using (var lowerReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, lowerOptions))
                {
                    var higherMonitor = MonitorReadingEvents(higherReceiver, int.MaxValue, cancellationSource.Token);
                    await Task.WhenAny(higherMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    var lowerReadTask = ReadEventsAsync(lowerReceiver, int.MaxValue, cancellationSource.Token);
                    Assert.That(async () => await lowerReadTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected), "The lower-level read should be rejected.");
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    cancellationSource.Cancel();
                    await higherMonitor.ReadTask;
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadFromMultiplePartitionsWithDifferentActiveOwnerLevels()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = new PartitionReceiverOptions { OwnerLevel = 40, PrefetchCount = LowPrefetchCount };
                var lowerOptions = new PartitionReceiverOptions { OwnerLevel = 20, PrefetchCount = LowPrefetchCount };
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();
                var partitions = await QueryPartitionsAsync(connectionString, cancellationSource.Token);

                // Send the same set of events to both partitions.

                await Task.WhenAll
                (
                    SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[0] }, cancellationSource.Token),
                    SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[1] }, cancellationSource.Token)
                );

                // Read from each partition, allowing the higher level operation to begin first.  Both read operations should be
                // successful and read all events from their respective partition.

                await using (var higherReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partitions[0], EventPosition.Earliest, connectionString, higherOptions))
                await using (var lowerReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partitions[1], EventPosition.Earliest, connectionString, lowerOptions))
                {
                    var higherMonitor = MonitorReadingEvents(higherReceiver, sourceEvents.Count, cancellationSource.Token);
                    var lowerMonitor = MonitorReadingEvents(lowerReceiver, sourceEvents.Count, cancellationSource.Token);

                    var readsCompleteTask = Task.WhenAll(higherMonitor.EndCompletion.Task, lowerMonitor.EndCompletion.Task);
                    await Task.WhenAny(readsCompleteTask, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    cancellationSource.Cancel();

                    var lowerResult = await lowerMonitor.ReadTask;
                    var higherResult = await higherMonitor.ReadTask;

                    Assert.That(higherResult.Events.Count, Is.EqualTo(sourceEvents.Count), "The higher reader should have read all events.");
                    Assert.That(lowerResult.Events.Count, Is.EqualTo(sourceEvents.Count), "The lower reader should have read all events.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadFromMultipleConsumerGroupsWithDifferentActiveOwnerLevels()
        {
            var ConsumerGroups = new[] { "customGroup", "customTwo" };

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1, ConsumerGroups))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = new PartitionReceiverOptions { OwnerLevel = 40, PrefetchCount = LowPrefetchCount };
                var lowerOptions = new PartitionReceiverOptions { OwnerLevel = 20, PrefetchCount = LowPrefetchCount };
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var higherReceiver = new PartitionReceiver(scope.ConsumerGroups[0], partition, EventPosition.Earliest, connectionString, higherOptions))
                await using (var lowerReceiver = new PartitionReceiver(scope.ConsumerGroups[1], partition, EventPosition.Earliest, connectionString, lowerOptions))
                {
                    // Read from each partition, allowing the higher level operation to begin first.  Both read operations should be
                    // successful and read all events from their respective partition.

                    var higherMonitor = MonitorReadingEvents(higherReceiver, sourceEvents.Count, cancellationSource.Token);
                    var lowerMonitor = MonitorReadingEvents(lowerReceiver, sourceEvents.Count, cancellationSource.Token);

                    var readsCompleteTask = Task.WhenAll(higherMonitor.EndCompletion.Task, lowerMonitor.EndCompletion.Task);
                    await Task.WhenAny(readsCompleteTask, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    cancellationSource.Cancel();

                    var lowerResult = await lowerMonitor.ReadTask;
                    var higherResult = await higherMonitor.ReadTask;

                    Assert.That(higherResult.Events.Count, Is.EqualTo(sourceEvents.Count), "The higher reader should have read all events.");
                    Assert.That(lowerResult.Events.Count, Is.EqualTo(sourceEvents.Count), "The lower reader should have read all events.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ExclusiveReceiverSupercedesNonExclusiveActiveReader()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var exclusiveOptions = new PartitionReceiverOptions { OwnerLevel = 20, PrefetchCount = LowPrefetchCount };
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var nonExclusiveReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, LowPrefetchOptions))
                await using (var exclusiveReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, exclusiveOptions))
                {
                    // Start the non-exclusive read, waiting until at least some events were read before starting the exclusive reader.

                    var nonExclusiveMonitor = MonitorReadingEvents(nonExclusiveReceiver, sourceEvents.Count, cancellationSource.Token);

                    await Task.WhenAny(nonExclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The non-exclusive reader has been confirmed to be active; start the exclusive level reader and validate that it supersedes the lower.

                    var exclusiveMonitor = MonitorReadingEvents(exclusiveReceiver, sourceEvents.Count, cancellationSource.Token);
                    await Task.WhenAny(exclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(async () => await nonExclusiveMonitor.ReadTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected), "The lower-level read should be rejected.");

                    // Wait for the exclusive reader to finish reading events and signal for cancellation to stop it.

                    await Task.WhenAny(exclusiveMonitor.EndCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    cancellationSource.Cancel();

                    var readState = await exclusiveMonitor.ReadTask;

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverWithHigherOwnerLevelSupercedesActiveReader()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = new PartitionReceiverOptions { OwnerLevel = 40, PrefetchCount = LowPrefetchCount };
                var lowerOptions = new PartitionReceiverOptions { OwnerLevel = 20, PrefetchCount = LowPrefetchCount };
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var higherReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, higherOptions))
                await using (var lowerReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, lowerOptions))
                {
                    // Start the lower level read, waiting until at least some events were read before starting the higher reader.

                    var lowerMonitor = MonitorReadingEvents(lowerReceiver, sourceEvents.Count, cancellationSource.Token);

                    await Task.WhenAny(lowerMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The lower reader has been confirmed to be active; start the higher level reader and validate that it supersedes the lower.

                    var higherMonitor = MonitorReadingEvents(higherReceiver, sourceEvents.Count, cancellationSource.Token);
                    await Task.WhenAny(higherMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(async () => await lowerMonitor.ReadTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected), "The lower-level read should be rejected.");

                    // Wait for the higher reader to finish reading events and signal for cancellation.

                    await Task.WhenAny(higherMonitor.EndCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    cancellationSource.Cancel();

                    var readState = await higherMonitor.ReadTask;

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed.");
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ExclusiveReceiverDoesNotSupercedNonExclusiveActiveReaderOnAnotherPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var exclusiveOptions = new PartitionReceiverOptions { OwnerLevel = 20, PrefetchCount = LowPrefetchCount };
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();
                var partitions = await QueryPartitionsAsync(connectionString, cancellationSource.Token);

                // Send the same set of events to both partitions.

                await Task.WhenAll
                (
                    SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[0] }, cancellationSource.Token),
                    SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[1] }, cancellationSource.Token)
                );

                await using (var nonExclusiveReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partitions[0], EventPosition.Earliest, connectionString, LowPrefetchOptions))
                await using (var exclusiveReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partitions[1], EventPosition.Earliest, connectionString, exclusiveOptions))
                {
                    // Start the non-exclusive read, waiting until at least some events were read before starting the exclusive reader.

                    var nonExclusiveMonitor = MonitorReadingEvents(nonExclusiveReceiver, sourceEvents.Count, cancellationSource.Token);

                    await Task.WhenAny(nonExclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The non-exclusive reader has been confirmed to be active; start the exclusive level reader and ensure that it is active so that
                    // both readers are confirmed to be running at the same time.

                    var exclusiveMonitor = MonitorReadingEvents(exclusiveReceiver, sourceEvents.Count, cancellationSource.Token);

                    await Task.WhenAny(exclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // Wait for both readers to complete and then signal for cancellation.

                    var completionTasks = Task.WhenAll(nonExclusiveMonitor.EndCompletion.Task, exclusiveMonitor.EndCompletion.Task);
                    await Task.WhenAny(completionTasks, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    cancellationSource.Cancel();

                    var nonExclusiveResult = await nonExclusiveMonitor.ReadTask;
                    var exclusiveResult = await exclusiveMonitor.ReadTask;

                    Assert.That(nonExclusiveResult.Events.Count, Is.EqualTo(sourceEvents.Count), "The non-exclusive reader should have read all events.");
                    Assert.That(exclusiveResult.Events.Count, Is.EqualTo(sourceEvents.Count), "The exclusive reader should have read all events.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ExclusiveReceiverDoesNotSupercedNonExclusiveActiveReaderOnAnotherConsumerGroup()
        {
            var ConsumerGroups = new[] { "customGroup", "customTwo" };

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1, ConsumerGroups))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var exclusiveOptions = new PartitionReceiverOptions { OwnerLevel = 20, PrefetchCount = LowPrefetchCount };
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var nonExclusiveReceiver = new PartitionReceiver(scope.ConsumerGroups[0], partition, EventPosition.Earliest, connectionString, LowPrefetchOptions))
                await using (var exclusiveReceiver = new PartitionReceiver(scope.ConsumerGroups[1], partition, EventPosition.Earliest, connectionString, exclusiveOptions))
                {
                    // Start the non-exclusive read, waiting until at least some events were read before starting the exclusive reader.

                    var nonExclusiveMonitor = MonitorReadingEvents(nonExclusiveReceiver, sourceEvents.Count, cancellationSource.Token);

                    await Task.WhenAny(nonExclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The non-exclusive reader has been confirmed to be active; start the exclusive level reader and ensure that it is active so that
                    // both readers are confirmed to be running at the same time.

                    var exclusiveMonitor = MonitorReadingEvents(exclusiveReceiver, sourceEvents.Count, cancellationSource.Token);

                    await Task.WhenAny(exclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // Wait for both readers to complete and then signal for cancellation.

                    var completionTasks = Task.WhenAll(nonExclusiveMonitor.EndCompletion.Task, exclusiveMonitor.EndCompletion.Task);
                    await Task.WhenAny(completionTasks, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    cancellationSource.Cancel();

                    var nonExclusiveResult = await nonExclusiveMonitor.ReadTask;
                    var exclusiveResult = await exclusiveMonitor.ReadTask;

                    Assert.That(nonExclusiveResult.Events.Count, Is.EqualTo(sourceEvents.Count), "The non-exclusive reader should have read all events.");
                    Assert.That(exclusiveResult.Events.Count, Is.EqualTo(sourceEvents.Count), "The exclusive reader should have read all events.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverIsNotCompromisedByBeingSupercededByAnotherReaderWithHigherLevel()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = new PartitionReceiverOptions { OwnerLevel = 40, PrefetchCount = LowPrefetchCount };
                var lowerOptions = new PartitionReceiverOptions { OwnerLevel = 20, PrefetchCount = LowPrefetchCount };
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var higherReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, higherOptions))
                await using (var lowerReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, lowerOptions))
                {
                    // Start the lower level read, waiting until at least some events were read before starting the higher reader.

                    var lowerMonitor = MonitorReadingEvents(lowerReceiver, int.MaxValue, cancellationSource.Token);

                    await Task.WhenAny(lowerMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The lower reader has been confirmed to be active; start the higher level reader and validate that it supersedes the lower for the partition.

                    using var higherCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token);

                    var higherMonitor = MonitorReadingEvents(higherReceiver, int.MaxValue, higherCancellationSource.Token);
                    await Task.WhenAny(higherMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(async () => await lowerMonitor.ReadTask, Throws.Exception, "The lower-level read should be rejected.");

                    // Cancel the higher level read and then close the receiver.

                    higherCancellationSource.Cancel();

                    await higherMonitor.ReadTask;
                    await higherReceiver.CloseAsync(cancellationSource.Token);

                    // Because the lower reader was able to read an indeterminate number of events before it was superseded,
                    // there's no way to deterministically predict how many events it can read when restarted.  Validate only that
                    // the reader is able to read without error.

                    await Task.Delay(250);
                    Assert.That(async () => await ReadNothingAsync(lowerReceiver, cancellationSource.Token), Throws.Nothing, "The lower receiver should have been able to read after the higher was closed.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverRespectsTheWaitTimeWhenReading()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    var waitTime = TimeSpan.FromMilliseconds(100);
                    var desiredEmptyBatches = 10;
                    var minimumEmptyBatches = 5;

                    var readTime = TimeSpan
                        .FromMilliseconds(waitTime.TotalMilliseconds * desiredEmptyBatches)
                        .Add(TimeSpan.FromSeconds(10));

                    // Attempt to read from the empty partition and verify that no events are observed.  Because no events are expected, the
                    // read operation will not naturally complete; limit the read to only a couple of seconds and trigger cancellation.

                    using var readCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token);
                    readCancellation.CancelAfter(readTime);

                    var readState = await ReadEventsAsync(receiver, int.MaxValue, readCancellation.Token, waitTime: waitTime);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The main cancellation token should not have been signaled.");

                    Assert.That(readState.Events.Count, Is.Zero, "No events should have been read from the empty partition.");
                    Assert.That(readState.EmptyCount, Is.AtLeast(minimumEmptyBatches), "The number of empty events read should be consistent with the requested wait time.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ReceiverCanRetrievePartitionProperties(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var receiverOptions = new PartitionReceiverOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, receiverOptions))
                {
                    var partitionProperties = await receiver.GetPartitionPropertiesAsync(cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    Assert.That(partitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");
                    Assert.That(partitionProperties.Id, Is.EqualTo(partition), "The partition identifier should match.");
                    Assert.That(partitionProperties.EventHubName, Is.EqualTo(scope.EventHubName).Using((IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase), "The Event Hub path should match.");
                    Assert.That(partitionProperties.BeginningSequenceNumber, Is.Not.EqualTo(default(long)), "The beginning sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedSequenceNumber, Is.Not.EqualTo(default(long)), "The last sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedOffset, Is.Not.EqualTo(default(long)), "The last offset should have been populated.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotRetrievePartitionPropertiesWhenConnectionIsClosed()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var connection = new EventHubConnection(connectionString);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connection))
                {
                    Assert.That(async () => await receiver.GetPartitionPropertiesAsync(cancellationSource.Token), Throws.Nothing);

                    await connection.CloseAsync(cancellationSource.Token);

                    Assert.That(async () => await receiver.GetPartitionPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotRetrieveMetadataWithInvalidProxy()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();

                var invalidProxyOptions = new PartitionReceiverOptions();
                invalidProxyOptions.RetryOptions.MaximumRetries = 0;
                invalidProxyOptions.RetryOptions.MaximumDelay = TimeSpan.FromMilliseconds(5);
                invalidProxyOptions.RetryOptions.TryTimeout = TimeSpan.FromSeconds(45);
                invalidProxyOptions.ConnectionOptions.Proxy = new WebProxy("http://1.2.3.4:9999");
                invalidProxyOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, invalidProxyOptions))
                {
                    // The sockets implementation in .NET Core on some platforms, such as Linux, does not trigger a specific socket exception and
                    // will, instead, hang indefinitely.  The try timeout is intentionally set to a value smaller than the cancellation token to
                    // invoke a timeout exception in these cases.

                    Assert.That(async () => await receiver.GetPartitionPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }
            }
        }

        /// <summary>
        ///   Reads the list of partition identifiers for an Event Hub instance.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use when creating the producer.</param>
        /// <param name="cancellationToken">The token used to signal a cancellation request.</param>
        ///
        /// <returns>The set of partition identifiers.</returns>
        ///
        private async Task<string[]> QueryPartitionsAsync(string connectionString,
                                                          CancellationToken cancellationToken = default)
        {
            await using (var producer = new EventHubProducerClient(connectionString))
            {
                return await producer.GetPartitionIdsAsync(cancellationToken);
            }
        }

        /// <summary>
        ///   Sends a set of events using a new producer to do so.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use when creating the producer.</param>
        /// <param name="sourceEvents">The set of events to send.</param>
        /// <param name="batchOptions">The set of options to apply when creating batches.</param>
        /// <param name="cancellationToken">The token used to signal a cancellation request.</param>
        ///
        /// <returns>The count of events that were sent.</returns>
        ///
        private async Task<int> SendEventsAsync(string connectionString,
                                                IEnumerable<EventData> sourceEvents,
                                                CreateBatchOptions batchOptions = default,
                                                CancellationToken cancellationToken = default)
        {
            var sentCount = 0;

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var batch in (await EventGenerator.BuildBatchesAsync(sourceEvents, producer, batchOptions, cancellationToken)))
                {
                    await producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);

                    sentCount += batch.Count;
                    batch.Dispose();
                }
            }

            return sentCount;
        }

        /// <summary>
        ///   Iterates multiple requests to read event batches, ignoring any events returned.
        /// </summary>
        ///
        /// <param name="receiver">The receiver to use for reading.</param>
        /// <param name="cancellationToken">The token used to signal cancellation of the read.</param>
        /// <param name="iterationCount">The number of iterations to perform.</param>
        /// <param name="batchSize">The size to use when requesting the event batch; if not provided, a default will be assumed.</param>
        /// <param name="waitTime">The amount of time to wait for a full batch before processing events; if not provided, a default will be assumed.</param>
        ///
        private async Task ReadNothingAsync(PartitionReceiver receiver,
                                            CancellationToken cancellationToken,
                                            int iterationCount = 5,
                                            int batchSize = 25,
                                            TimeSpan? waitTime = default)
        {
            waitTime ??= TimeSpan.FromMilliseconds(200);

            try
            {
                while ((--iterationCount >= 0) && (!cancellationToken.IsCancellationRequested))
                {
                    await receiver.ReceiveBatchAsync(batchSize, waitTime.Value, cancellationToken).ConfigureAwait(false);
                    await Task.Delay(50);
                }
            }
            catch (TaskCanceledException)
            {
                // The test should assert on the cancellation token; treat this as
                // expected and don't bubble.
            }
        }

        /// <summary>
        ///   Reads the events from a given position, tracking the operation.
        /// </summary>
        ///
        /// <param name="receiver">The receiver to use for reading.</param>
        /// <param name="expectedEventCount">The expected count of events; when this number of events has been read, reading will cease.</param>
        /// <param name="cancellationToken">The token used to signal cancellation of the read.</param>
        /// <param name="batchSize">The size to use when requesting the event batch; if not provided, a default will be assumed.</param>
        /// <param name="waitTime">The amount of time to wait for a full batch before processing events; if not provided, a default will be assumed.</param>
        /// <param name="iterationCallback">A callback function to invoke each tick of the loop, receiving the current read state and allowing forced termination.</param>
        ///
        /// <returns>The final state when reading has ceased.</returns>
        ///
        private async Task<ReadState> ReadEventsAsync(PartitionReceiver receiver,
                                                      int expectedEventCount,
                                                      CancellationToken cancellationToken,
                                                      int? batchSize = default,
                                                      TimeSpan? waitTime = default,
                                                      Func<ReadState, Task<bool>> iterationCallback = default)
        {
            batchSize ??= Math.Min(expectedEventCount, 25);
            waitTime ??= TimeSpan.FromSeconds(1);

            var result = new ReadState();
            var shouldReadNextEventBatch = true;

            IEnumerable<EventData> batch;
            bool batchHasEvents;

            try
            {
                while ((shouldReadNextEventBatch) && (!cancellationToken.IsCancellationRequested))
                {
                    batch = await receiver.ReceiveBatchAsync(batchSize.Value, waitTime.Value, cancellationToken).ConfigureAwait(false);
                    batchHasEvents = false;

                    foreach (var eventData in batch)
                    {
                        batchHasEvents = true;

                        var eventId = eventData.Properties[EventGenerator.IdPropertyName].ToString();

                        if ((result.Events.TryAdd(eventId, eventData)) && (result.Events.Count >= expectedEventCount))
                        {
                            shouldReadNextEventBatch = false;
                        }

                        // If there's a callback registered per-tick, invoke it and respect its
                        // decision on whether iteration should continue.

                        if ((iterationCallback != null) && (!(await iterationCallback(result).ConfigureAwait(false))))
                        {
                            shouldReadNextEventBatch = false;
                        }
                    }

                    if (!batchHasEvents)
                    {
                        ++result.EmptyCount;
                    }
                }
            }
            catch (TaskCanceledException)
            {
                // The test should assert on the cancellation token; treat this as
                // expected and don't bubble.
            }

            return result;
        }

        /// <summary>
        ///   Begins reading events from a given position, monitoring the status of the operation.
        /// </summary>
        ///
        /// <param name="receiver">The receiver to use for reading.</param>
        /// <param name="expectedEventCount">The expected count of events; when this number of events has been read, reading will cease.</param>
        /// <param name="cancellationToken">The token used to signal cancellation of the read.</param>
        /// <param name="batchSize">The size to use when requesting the event batch; if not provided, a default will be assumed.</param>
        /// <param name="waitTime">The amount of time to wait for a full batch before processing events; if not provided, a default will be assumed.</param>
        ///
        /// <returns>The set of monitoring primitives to observe the status of the read.</returns>
        ///
        /// <remarks>
        ///   The read operation will not terminate without cancellation; when the <paramref name="expectedEventCount" /> has been reached,
        ///   the <see cref="ReadMonitor.EndCompletion" /> will be signaled but the operation will be allowed to continue.
        /// </remarks>
        ///
        private ReadMonitor MonitorReadingEvents(PartitionReceiver receiver,
                                                 int expectedEventCount,
                                                 CancellationToken cancellationToken,
                                                 int? batchSize = default,
                                                 TimeSpan? waitTime = default)
        {
            var monitor = new ReadMonitor();

            Task<bool> readCallback(ReadState currentState)
            {
                if (currentState.Events.Count >= 1)
                {
                    monitor.StartCompletion.TrySetResult(true);
                }

                if (currentState.Events.Count >= expectedEventCount)
                {
                    monitor.EndCompletion.TrySetResult(true);
                }

                return Task.FromResult(true);
            }

            monitor.ReadTask = ReadEventsAsync(receiver, int.MaxValue, cancellationToken, batchSize, waitTime, readCallback);
            return monitor;
        }

        /// <summary>
        ///   The results of reading events.
        /// </summary>
        ///
        private class ReadState
        {
            public readonly ConcurrentDictionary<string, EventData> Events = new ConcurrentDictionary<string, EventData>();
            public long EmptyCount = 0;
        }

        /// <summary>
        ///   The set of primitives for monitoring the reading of events.
        /// </summary>
        ///
        private class ReadMonitor
        {
            public readonly TaskCompletionSource<bool> StartCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            public readonly TaskCompletionSource<bool> EndCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            public Task<ReadState> ReadTask;
        }
    }
}
