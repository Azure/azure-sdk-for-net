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
using Azure.Core.Amqp;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Authorization;
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
                    var readState = await ReadEventsAsync(receiver, new HashSet<string> { singleEvent.MessageId }, cancellationSource.Token);

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
                    var readState = await ReadEventsAsync(receiver, new HashSet<string> { singleEvent.MessageId }, cancellationSource.Token);

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
                    var readState = await ReadEventsAsync(receiver, new HashSet<string> { singleEvent.MessageId }, cancellationSource.Token);

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
                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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

                var credential = new AzureNamedKeyCredential(EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
        public async Task ReceiverCanReadEventsUsingTheSasCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var options = new PartitionReceiverOptions();
                var resource = EventHubConnection.BuildConnectionSignatureAuthorizationResource(options.ConnectionOptions.TransportType, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName);
                var signature = new SharedAccessSignature(resource, EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
                var credential = new AzureSasCredential(signature.Value);
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential, options))
                {
                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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

                    var readTask = ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);

                    // Give the receiver a moment to ensure that it is established and then send events for it to read.

                    await Task.Delay(250);
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Await reading of the events and validate the resulting state.

                    var readState = await readTask;
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(sourceEvents.Count), "Only the source events should have been read.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
                    var expectedCount = sourceEvents.Count;
                    var expectedEvents = sourceEvents.Select(evt => evt.MessageId);

                    if (isInclusive)
                    {
                       ++expectedCount;
                       expectedEvents = expectedEvents.Concat(new[] { seedEvents.Last().MessageId });
                    }

                    var readState = await ReadEventsAsync(receiver, expectedEvents, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(expectedCount), "The wrong number of events was read for the value of the inclusive flag.");
                    Assert.That(readState.Events.Values.Any(readEvent => readEvent.Offset == lastOffset), Is.EqualTo(isInclusive), $"The event with offset [{ lastOffset }] was { ((isInclusive) ? "not" : "") } in the set of read events, which is inconsistent with the inclusive flag.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
                    var expectedCount = sourceEvents.Count;
                    var expectedEvents = sourceEvents.Select(evt => evt.MessageId);

                    if (isInclusive)
                    {
                       ++expectedCount;
                       expectedEvents = expectedEvents.Concat(new[] { seedEvents.Last().MessageId });
                    }

                    var readState = await ReadEventsAsync(receiver, expectedEvents, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(expectedCount), "The wrong number of events was read for the value of the inclusive flag.");
                    Assert.That(readState.Events.Values.Any(readEvent => readEvent.SequenceNumber == lastSequence), Is.EqualTo(isInclusive), $"The event with sequence number [{ lastSequence }] was { ((isInclusive) ? "not" : "") } in the set of read events, which is inconsistent with the inclusive flag.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
                    await Task.Delay(TimeSpan.FromSeconds(2));

                    lastEnqueuedTime = (await producer.GetPartitionPropertiesAsync(partition, cancellationSource.Token)).LastEnqueuedTime;
                    startingPosition = EventPosition.FromEnqueuedTime(lastEnqueuedTime);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                }

                // Read the events and validate the resulting state.

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, startingPosition, connectionString))
                {
                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The exact number of events returned by the service may vary due to clock skew and how reader is positioned; ensure that
                    // at least the expected source events were read and ignore any additional events.

                    Assert.That(readState.Events.Count, Is.AtLeast(sourceEvents.Count), "The number of events received should match.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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
                    var expectedEvents = sourceEvents.Select(evt => evt.MessageId);

                    var readState = await Task.WhenAll
                    (
                        ReadEventsAsync(customReceiver, expectedEvents, cancellationSource.Token),
                        ReadEventsAsync(defaultReceiver, expectedEvents, cancellationSource.Token)
                    );

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
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

                    var readState = await ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), readCancellation.Token, waitTime: TimeSpan.FromMilliseconds(250));
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

                    async Task<bool> closeAfterFewRead(ReadState state)
                    {
                        if (state.Events.Count >= 2)
                        {
                            await receiver.CloseAsync(cancellationSource.Token);
                            await Task.Yield();
                        }

                        return true;
                    }

                    var readTask = ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token, iterationCallback: closeAfterFewRead);

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
        public async Task ReceiverCannotReadWhenSharedConnectionIsClosed()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(100).ToList();

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var connection = new EventHubConnection(connectionString))
                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connection, LowPrefetchOptions))
                {
                    // Create a local function that will close the connection after five events have
                    // been read.  Because the close happens during the read loop, allow for a short
                    // delay to ensure that the state transition has been fully captured.

                    async Task<bool> closeAfterFewRead(ReadState state)
                    {
                        if (state.Events.Count >= 2)
                        {
                            await connection.CloseAsync(cancellationSource.Token);
                            await Task.Yield();
                        }

                        return true;
                    }

                    var readTask = ReadEventsAsync(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token, iterationCallback: closeAfterFewRead);

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
        public async Task ReceiversWithAnIdentityCanRead()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();

                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, new PartitionReceiverOptions { Identifier = "first" }))
                {
                    var monitor = MonitorReadingEvents(receiver,sourceEvents.Select(evt => evt.MessageId), cancellationSource.Token);

                    await Task.WhenAny(monitor.EndCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    var firstState = await monitor.ReadTask;
                    cancellationSource.Cancel();

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
                        Assert.That(firstState.Events.TryGetValue(sourceId, out var firstReadEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed by the receiver.");
                        Assert.That(sourceEvent.IsEquivalentTo(firstReadEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event for the receiver.");
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
        public async Task MultipleReceiversCanReadConcurrently()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();
                var partitions = await QueryPartitionsAsync(connectionString, cancellationSource.Token);

                await Task.WhenAll
                (
                    SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[0] }, cancellationSource.Token),
                    SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[1] }, cancellationSource.Token)
                );

                await using (var firstReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partitions[0], EventPosition.Earliest, connectionString, new PartitionReceiverOptions { Identifier = "first" }))
                await using (var secondReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partitions[1], EventPosition.Earliest, connectionString, new PartitionReceiverOptions { Identifier = "second" }))
                {
                    var expectedEvents = sourceEvents.Select(evt => evt.MessageId);
                    var firstMonitor = MonitorReadingEvents(firstReceiver, expectedEvents, cancellationSource.Token);
                    var secondMonitor = MonitorReadingEvents(secondReceiver, expectedEvents, cancellationSource.Token);

                    await Task.WhenAny(firstMonitor.EndCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    await Task.WhenAny(secondMonitor.EndCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    var firstState = await firstMonitor.ReadTask;
                    var secondState = await secondMonitor.ReadTask;
                    cancellationSource.Cancel();

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.MessageId;
                        Assert.That(firstState.Events.TryGetValue(sourceId, out var firstReadEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed by the first receiver.");
                        Assert.That(sourceEvent.IsEquivalentTo(firstReadEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event for the first receiver.");

                        Assert.That(secondState.Events.TryGetValue(sourceId, out var secondReadEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed by the second receiver.");
                        Assert.That(sourceEvent.IsEquivalentTo(secondReadEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event for the second receiver.");
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
                    var exclusiveMonitor = MonitorReadingEvents(exclusiveReceiver, null, cancellationSource.Token);
                    await Task.WhenAny(exclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    var nonExclusiveReadTask = ReadEventsAsync(nonExclusiveReceiver, null, cancellationSource.Token);
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
                    var expectedEvents = sourceEvents.Select(evt => evt.MessageId);

                    var higherMonitor = MonitorReadingEvents(higherReceiver, expectedEvents, cancellationSource.Token);
                    await Task.WhenAny(higherMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    var lowerReadTask = ReadEventsAsync(lowerReceiver, expectedEvents, cancellationSource.Token);
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
                    var expectedEvents = sourceEvents.Select(evt => evt.MessageId);
                    var higherMonitor = MonitorReadingEvents(higherReceiver, expectedEvents, cancellationSource.Token);
                    var lowerMonitor = MonitorReadingEvents(lowerReceiver, expectedEvents, cancellationSource.Token);

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

                    var expectedEvents = sourceEvents.Select(evt => evt.MessageId);
                    var higherMonitor = MonitorReadingEvents(higherReceiver, expectedEvents, cancellationSource.Token);
                    var lowerMonitor = MonitorReadingEvents(lowerReceiver, expectedEvents, cancellationSource.Token);

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
                var expectedEvents = sourceEvents.Select(evt => evt.MessageId);

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var nonExclusiveReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, LowPrefetchOptions))
                await using (var exclusiveReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, exclusiveOptions))
                {
                    // Start the non-exclusive read, waiting until at least some events were read before starting the exclusive reader.

                    var nonExclusiveMonitor = MonitorReadingEvents(nonExclusiveReceiver, expectedEvents, cancellationSource.Token);

                    await Task.WhenAny(nonExclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The non-exclusive reader has been confirmed to be active; start the exclusive level reader and validate that it supersedes the lower.

                    var exclusiveMonitor = MonitorReadingEvents(exclusiveReceiver, expectedEvents, cancellationSource.Token);
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
                        var sourceId = sourceEvent.MessageId;
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
                var expectedEvents = sourceEvents.Select(evt => evt.MessageId);

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var higherReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, higherOptions))
                await using (var lowerReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, lowerOptions))
                {
                    // Start the lower level read, waiting until at least some events were read before starting the higher reader.

                    var lowerMonitor = MonitorReadingEvents(lowerReceiver, expectedEvents, cancellationSource.Token);

                    await Task.WhenAny(lowerMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The lower reader has been confirmed to be active; start the higher level reader and validate that it supersedes the lower.

                    var higherMonitor = MonitorReadingEvents(higherReceiver, expectedEvents, cancellationSource.Token);
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
                        var sourceId = sourceEvent.MessageId;
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
                var expectedEvents = sourceEvents.Select(evt => evt.MessageId);
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

                    var nonExclusiveMonitor = MonitorReadingEvents(nonExclusiveReceiver, expectedEvents, cancellationSource.Token);

                    await Task.WhenAny(nonExclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The non-exclusive reader has been confirmed to be active; start the exclusive level reader and ensure that it is active so that
                    // both readers are confirmed to be running at the same time.

                    var exclusiveMonitor = MonitorReadingEvents(exclusiveReceiver, expectedEvents, cancellationSource.Token);

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
                var expectedEvents = sourceEvents.Select(evt => evt.MessageId);

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var nonExclusiveReceiver = new PartitionReceiver(scope.ConsumerGroups[0], partition, EventPosition.Earliest, connectionString, LowPrefetchOptions))
                await using (var exclusiveReceiver = new PartitionReceiver(scope.ConsumerGroups[1], partition, EventPosition.Earliest, connectionString, exclusiveOptions))
                {
                    // Start the non-exclusive read, waiting until at least some events were read before starting the exclusive reader.

                    var nonExclusiveMonitor = MonitorReadingEvents(nonExclusiveReceiver, expectedEvents, cancellationSource.Token);

                    await Task.WhenAny(nonExclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The non-exclusive reader has been confirmed to be active; start the exclusive level reader and ensure that it is active so that
                    // both readers are confirmed to be running at the same time.

                    var exclusiveMonitor = MonitorReadingEvents(exclusiveReceiver, expectedEvents, cancellationSource.Token);

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
                var expectedEvents = sourceEvents.Select(evt => evt.MessageId);

                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                await using (var higherReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, higherOptions))
                await using (var lowerReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, lowerOptions))
                {
                    // Start the lower level read, waiting until at least some events were read before starting the higher reader.

                    var lowerMonitor = MonitorReadingEvents(lowerReceiver, expectedEvents, cancellationSource.Token);

                    await Task.WhenAny(lowerMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The lower reader has been confirmed to be active; start the higher level reader and validate that it supersedes the lower for the partition.

                    using var higherCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token);

                    var higherMonitor = MonitorReadingEvents(higherReceiver, expectedEvents, higherCancellationSource.Token);
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

                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationSource.Token);
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
        public async Task ExclusiveReceiverDetectsAnotherExclusiveReaderWithSameLevel()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();

                // Seed the partition with events.

                await SendEventsAsync(connectionString, EventGenerator.CreateSmallEvents(250), new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                // Create the receivers and read concurrently in the background until the initial receiver recognizes the partition has been stolen.

                var batchSize = (LowPrefetchCount * 2);
                var receiverOptions = new PartitionReceiverOptions { OwnerLevel = 1, PrefetchCount = LowPrefetchCount };
                var capturedException = default(Exception);
                var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                await using var firstReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, receiverOptions);
                await using var secondReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, receiverOptions);

                var firstReceiverTask = Task.Run(async () =>
                {
                    while (!cancellationSource.IsCancellationRequested)
                    {
                        try
                        {
                            await firstReceiver.ReceiveBatchAsync(batchSize, TimeSpan.FromSeconds(10), cancellationSource.Token).ConfigureAwait(false);
                            await Task.Delay(TimeSpan.FromSeconds(0.5), cancellationSource.Token).ConfigureAwait(false);
                        }
                        catch (TaskCanceledException)
                        {
                            // This is expected; ignore.
                        }
                        catch (Exception ex)
                        {
                            capturedException = ex;
                            completionSource.TrySetResult(true);
                            break;
                        }
                    }
                });

                var secondReceiverTask = Task.Run(async () =>
                {
                    while (!cancellationSource.IsCancellationRequested)
                    {
                        try
                        {
                            await secondReceiver.ReceiveBatchAsync(batchSize, TimeSpan.FromSeconds(10), cancellationSource.Token).ConfigureAwait(false);
                        }
                        catch (TaskCanceledException)
                        {
                            // This is expected; ignore.
                        }
                        catch (EventHubsException ex) when (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
                        {
                            // Ignore this and allow the consumer to reassert ownership.
                        }
                    }
                });

                // Wait for the first receiver to set the completion source.

                await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

                cancellationSource.Cancel();

                // Validate the captured exception; it should indicate that a partition was stolen.

                Assert.That(capturedException, Is.Not.Null, "The contested read should have surfaced an exception.");
                Assert.That(capturedException, Is.TypeOf<EventHubsException>(), "The exception should be of the correct type.");
                Assert.That(((EventHubsException)capturedException).Reason, Is.EqualTo(EventHubsException.FailureReason.ConsumerDisconnected), "The contested read should have failed due to a stolen partition.");

                // Cleanup the receive tasks.

                await Task.WhenAll(firstReceiverTask, secondReceiverTask);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ExclusiveReceiverCanReassertOwnershipFromAnotherExclusiveReaderWithSameLevel()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();

                // Seed the partition with events.

                await SendEventsAsync(connectionString, EventGenerator.CreateSmallEvents(250), new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                // Create the receivers and read concurrently in the background until the initial receiver recognizes the partition has been stolen.

                var batchSize = (LowPrefetchCount * 2);
                var receiverOptions = new PartitionReceiverOptions { OwnerLevel = 1, PrefetchCount = LowPrefetchCount };
                var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var secondReceiverStolen = false;

                await using var firstReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, receiverOptions);
                await using var secondReceiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString, receiverOptions);

                var firstReceiverTask = Task.Run(async () =>
                {
                    while (!cancellationSource.IsCancellationRequested)
                    {
                        try
                        {
                            await firstReceiver.ReceiveBatchAsync(batchSize, TimeSpan.FromSeconds(10), cancellationSource.Token).ConfigureAwait(false);
                            await Task.Delay(TimeSpan.FromSeconds(0.5), cancellationSource.Token).ConfigureAwait(false);
                        }
                        catch (TaskCanceledException)
                        {
                            // This is expected; ignore.
                        }
                        catch (EventHubsException ex) when (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
                        {
                            // Once the consumer is disconnected, stop attempting to read.

                            completionSource.TrySetResult(true);
                            break;
                        }
                    }
                });

                var secondReceiverTask = Task.Run(async () =>
                {
                    while (!cancellationSource.IsCancellationRequested)
                    {
                        try
                        {
                            await secondReceiver.ReceiveBatchAsync(batchSize, TimeSpan.FromSeconds(10), cancellationSource.Token).ConfigureAwait(false);
                        }
                        catch (TaskCanceledException)
                        {
                            // This is expected; ignore.
                        }
                        catch (EventHubsException ex) when (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
                        {
                            // If the first consumer was already bumped, then  Ignore this and allow the consumer to reassert ownership.

                            if (completionSource.Task.IsCompleted)
                            {
                                Volatile.Write(ref secondReceiverStolen, true);
                                break;
                            }
                        }
                    }
                });

                // Wait for the first receiver to set the completion source.

                await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

                // Start reading with the first receiver again, which should reassert ownership and cause the second receiver to
                // disconnect.

                while (!cancellationSource.IsCancellationRequested)
                {
                    try
                    {
                        await firstReceiver.ReceiveBatchAsync(batchSize, TimeSpan.FromSeconds(10), cancellationSource.Token).ConfigureAwait(false);

                        if (Volatile.Read(ref secondReceiverStolen))
                        {
                           break;
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        // This is expected; ignore.
                    }
                    catch (EventHubsException ex) when (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
                    {
                        // Ignore this exception and let the receiver reassert ownership.
                    }
                }

                Assert.That(secondReceiverStolen, Is.True, "The second receiver should have acknowledged the loss of ownership.");
                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
                cancellationSource.Cancel();

                // Cleanup the receive tasks.

                await Task.WhenAll(firstReceiverTask, secondReceiverTask);
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

                    var readState = await ReadEventsAsync(receiver, null, readCancellation.Token, waitTime: waitTime);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The main cancellation token should not have been signaled.");

                    Assert.That(readState.Events.Count, Is.Zero, "No events should have been read from the empty partition.");
                    Assert.That(readState.EmptyCount, Is.AtLeast(minimumEmptyBatches), "The number of empty events read should be consistent with the requested wait time.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> can read a published
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadEventsWithAFullyPopulatedAmqpMessage()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 } }));
                var eventData = new EventData(message);

                // Header

                message.Header.DeliveryCount = 123;
                message.Header.Durable = true;
                message.Header.FirstAcquirer = true;
                message.Header.Priority = 1;
                message.Header.TimeToLive = TimeSpan.FromDays(2);

                // Properties

                message.Properties.AbsoluteExpiryTime = new DateTimeOffset(2015, 10, 27, 0, 0 ,0 ,0, TimeSpan.Zero);
                message.Properties.ContentEncoding = "utf-8";
                message.Properties.ContentType = "test/unit";
                message.Properties.CorrelationId = new AmqpMessageId("OU812");
                message.Properties.CreationTime = new DateTimeOffset(2012, 3, 4, 8, 0, 0, 0, TimeSpan.Zero);
                message.Properties.GroupId = "Red Squad";
                message.Properties.GroupSequence = 76;
                message.Properties.MessageId = new AmqpMessageId("Bob");
                message.Properties.ReplyTo = new AmqpAddress("1407 Graymalkin Lane");
                message.Properties.ReplyToGroupId = "Home";
                message.Properties.Subject = "You'll never believe this weight loss secret!";
                message.Properties.To = new AmqpAddress("http://some.server.com");
                message.Properties.UserId = new byte[] { 0x11, 0x22 };

                // Application Properties

                message.ApplicationProperties.Add("EventGenerator::Identifier", Guid.NewGuid().ToString());
                message.ApplicationProperties.Add("One", TimeSpan.FromMinutes(5));
                message.ApplicationProperties.Add("Two", 2);

                // Delivery Annotations

                message.DeliveryAnnotations.Add("Three", 3);
                message.DeliveryAnnotations.Add("Four", new DateTimeOffset(2015, 10, 27, 0, 0, 0, TimeSpan.Zero));

                // Message Annotations

                message.MessageAnnotations.Add("Five", 5);
                message.MessageAnnotations.Add("Six", 6.0f);

                // Footer

                message.Footer.Add("Seven", 7);
                message.Footer.Add("Eight", "8");

                // Publish the event and then read it back.

                await using var producer = new EventHubProducerClient(connectionString);
                await producer.SendAsync(new[] { eventData }, new SendEventOptions { PartitionId = partition });

                await using var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString);
                var readState = await ReadEventsAsync(receiver, new HashSet<string> { eventData.MessageId }, cancellationSource.Token);

                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                Assert.That(readState.Events.Count, Is.EqualTo(1), "A single event was sent.");
                cancellationSource.Cancel();

                // Validate the extended event attributes. Note that the header and delivery annotations are per-hop
                // values and should not be expected to round-trip.  A subset of the other sections are broker-owned
                // and should be expected to change.

                var readMessage = readState.Events.First().Value.GetRawAmqpMessage();

                Assert.That(readMessage.GetEventBody().ToArray(), Is.EquivalentTo(message.GetEventBody().ToArray()), "The data body should match.");
                Assert.That(readMessage.ApplicationProperties, Is.EquivalentTo(message.ApplicationProperties), "The application properties should match.");
                Assert.That(readMessage.Footer, Is.EquivalentTo(message.Footer), "The footer should match.");

                // Properties

                Assert.That(readMessage.Properties.AbsoluteExpiryTime, Is.EqualTo(readMessage.Properties.CreationTime + message.Header.TimeToLive), "The expiry time should be equal to the computed creation time plus the time to live.");
                Assert.That(readMessage.Properties.ContentEncoding, Is.EqualTo(message.Properties.ContentEncoding), "The content encoding should match.");
                Assert.That(readMessage.Properties.ContentType, Is.EqualTo(message.Properties.ContentType), "The content type should match.");
                Assert.That(readMessage.Properties.CorrelationId, Is.EqualTo(message.Properties.CorrelationId), "The correlation identifier should match.");
                Assert.That(readMessage.Properties.CreationTime, Is.EqualTo(readMessage.Properties.AbsoluteExpiryTime - message.Header.TimeToLive), "The creation time should be equal to the difference of the expiry time and time to live.");
                Assert.That(readMessage.Properties.GroupId, Is.EqualTo(message.Properties.GroupId), "The group identifier should match.");
                Assert.That(readMessage.Properties.GroupSequence, Is.EqualTo(message.Properties.GroupSequence), "The group sequence should match.");
                Assert.That(readMessage.Properties.MessageId, Is.EqualTo(message.Properties.MessageId), "The message identifier should match.");
                Assert.That(readMessage.Properties.ReplyTo, Is.EqualTo(message.Properties.ReplyTo), "The reply-to address should match.");
                Assert.That(readMessage.Properties.ReplyToGroupId, Is.EqualTo(message.Properties.ReplyToGroupId), "The reply-to group identifier should match.");
                Assert.That(readMessage.Properties.Subject, Is.EqualTo(message.Properties.Subject), "The subject should match.");
                Assert.That(readMessage.Properties.To, Is.EqualTo(message.Properties.To), "The to address should match.");
                Assert.That(readMessage.Properties.UserId.Value.ToArray(), Is.EquivalentTo(message.Properties.UserId.Value.ToArray()), "The user identifier should match.");

                // Message Annotations

                foreach (var key in message.MessageAnnotations.Keys)
                {
                    Assert.That(readMessage.MessageAnnotations.ContainsKey(key), $"The message annotation key [{ key }] should be present.");
                    Assert.That(readMessage.MessageAnnotations[key], Is.EqualTo(message.MessageAnnotations[key]), $"The message annotation [{ key }] should match the expected value.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> can read a published
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadEventsWithAValueBody()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                var value = new Dictionary<string, string> { { "key", "value" } };
                var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(value));
                var eventData = new EventData(message) { MessageId = Guid.NewGuid().ToString() };

                message.ApplicationProperties.Add("EventGenerator::Identifier", eventData.MessageId);

                // Publish the event and then read it back.

                await using var producer = new EventHubProducerClient(connectionString);
                await producer.SendAsync(new[] { eventData }, new SendEventOptions { PartitionId = partition });

                await using var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString);
                var readState = await ReadEventsAsync(receiver, new HashSet<string> { eventData.MessageId }, cancellationSource.Token);

                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                Assert.That(readState.Events.Count, Is.EqualTo(1), "A single event was sent.");
                cancellationSource.Cancel();

                // Validate the extended event attributes. Note that the header and delivery annotations are per-hop
                // values and should not be expected to round-trip.  A subset of the other sections are broker-owned
                // and should be expected to change.

                var readMessage = readState.Events.First().Value.GetRawAmqpMessage();

                Assert.That(readMessage.Body.TryGetValue(out var readValue), Is.True, "The message should have a value body.");
                Assert.That(readValue, Is.EquivalentTo(value), "The value body should match.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> can read a published
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReadEventsWithASequenceBody()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var partition = (await QueryPartitionsAsync(connectionString, cancellationSource.Token)).First();
                var value = new[] { new List<object> { "1", 2 } };
                var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromSequence(value));
                var eventData = new EventData(message) { MessageId = Guid.NewGuid().ToString() };

                message.ApplicationProperties.Add("EventGenerator::Identifier", eventData.MessageId);

                // Publish the event and then read it back.

                await using var producer = new EventHubProducerClient(connectionString);
                await producer.SendAsync(new[] { eventData }, new SendEventOptions { PartitionId = partition });

                await using var receiver = new PartitionReceiver(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString);
                var readState = await ReadEventsAsync(receiver, new HashSet<string> { eventData.MessageId }, cancellationSource.Token);

                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                Assert.That(readState.Events.Count, Is.EqualTo(1), "A single event was sent.");
                cancellationSource.Cancel();

                // Validate the extended event attributes. Note that the header and delivery annotations are per-hop
                // values and should not be expected to round-trip.  A subset of the other sections are broker-owned
                // and should be expected to change.

                var readMessage = readState.Events.First().Value.GetRawAmqpMessage();

                Assert.That(readMessage.Body.TryGetSequence(out var readValue), Is.True, "The message should have a value body.");
                Assert.That(value.Count, Is.EqualTo(1), "The source sequence should have one embedded list.");
                Assert.That(readValue.Count, Is.EqualTo(1), "The converted sequence should have one embedded list.");
                Assert.That(readValue.First(), Is.EquivalentTo(value.First()), "The sequence embedded list should match.");
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
        /// <param name="expectedEvents">The set of identifiers for the events expected to be read; when all events have been accounted for, reading will cease.  If <c>null</c>, reading will continue until canceled.</param>
        /// <param name="cancellationToken">The token used to signal cancellation of the read.</param>
        /// <param name="batchSize">The size to use when requesting the event batch; if not provided, a default will be assumed.</param>
        /// <param name="waitTime">The amount of time to wait for a full batch before processing events; if not provided, a default will be assumed.</param>
        /// <param name="iterationCallback">A callback function to invoke each tick of the loop, receiving the current read state and allowing forced termination.</param>
        ///
        /// <returns>The final state when reading has ceased.</returns>
        ///
        private async Task<ReadState> ReadEventsAsync(PartitionReceiver receiver,
                                                      IEnumerable<string> expectedEvents,
                                                      CancellationToken cancellationToken,
                                                      int? batchSize = default,
                                                      TimeSpan? waitTime = default,
                                                      Func<ReadState, Task<bool>> iterationCallback = default)
        {
            batchSize ??= 25;
            waitTime ??= TimeSpan.FromSeconds(1);

            var result = new ReadState(expectedEvents);
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

                        result.RemainingEvents?.Remove(eventData.MessageId);
                        result.Events.TryAdd(eventData.MessageId, eventData);

                        // If there's a callback registered per-tick, invoke it and respect its
                        // decision on whether iteration should continue.

                        if ((iterationCallback != null) && (!(await iterationCallback(result).ConfigureAwait(false))))
                        {
                            shouldReadNextEventBatch = false;
                        }

                        // If there are no events remaining, there's no need to continue
                        // reading, regardless of the callback result.

                        if ((result.RemainingEvents?.Count ?? 1) == 0)
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
        /// <param name="expectedEvents">The set of identifiers for the events expected to be read; when all events have been accounted for, reading will cease.  If <c>null</c>, reading will continue until canceled.</param>
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
                                                 IEnumerable<string> expectedEvents,
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

                if ((currentState.RemainingEvents?.Count ?? 1) == 0)
                {
                    monitor.EndCompletion.TrySetResult(true);
                }

                return Task.FromResult(true);
            }

            monitor.ReadTask = ReadEventsAsync(receiver, expectedEvents, cancellationToken, batchSize, waitTime, readCallback);
            return monitor;
        }

        /// <summary>
        ///   The results of reading events.
        /// </summary>
        ///
        private class ReadState
        {
            public readonly HashSet<string> RemainingEvents;
            public readonly ConcurrentDictionary<string, EventData> Events = new();
            public long EmptyCount = 0;

            public ReadState(IEnumerable<string> expectedEvents) =>
                RemainingEvents = (expectedEvents == null)
                    ? null
                    : new(expectedEvents);
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
