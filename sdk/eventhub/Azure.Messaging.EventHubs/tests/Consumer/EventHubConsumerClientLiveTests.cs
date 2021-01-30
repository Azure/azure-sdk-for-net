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
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventHubConsumerClient" />
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
    public class EventHubConsumerClientLiveTests
    {
        /// <summary>The value to use as the prefetch count for low-prefetch scenarios.</summary>
        private const int LowPrefetchCount = 5;

        /// <summary>The default set of options for reading, allowing an infinite wait time.</summary>
        private readonly ReadEventOptions DefaultReadOptions = new ReadEventOptions { MaximumWaitTime = null };

        /// <summary>A set of options for reading using a small prefetch buffer.</summary>
        private readonly ReadEventOptions LowPrefetchReadOptions = new ReadEventOptions { PrefetchCount = LowPrefetchCount };
        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ConsumerWithNoOptionsCanRead(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
               cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString, new EventHubConnectionOptions { TransportType = transportType }))
                {
                    var partition = (await connection.GetPartitionIdsAsync(new EventHubsRetryOptions().ToRetryPolicy(), cancellationSource.Token)).First();

                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    {
                        Assert.That(async () => await ReadNothingAsync(consumer, partition, cancellationSource.Token, EventPosition.Latest), Throws.Nothing);
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ConsumerWithOptionsCanRead(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var options = new EventHubConsumerClientOptions();
                options.RetryOptions.MaximumRetries = 7;
                options.ConnectionOptions.TransportType = transportType;

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName, options))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    Assert.That(async () => await ReadNothingAsync(consumer, partition, cancellationSource.Token, EventPosition.Latest), Throws.Nothing);
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadSingleZeroLengthEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var singleEvent = EventGenerator.CreateEventFromBody(Array.Empty<byte>());

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, new EventData[] { singleEvent }, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, 1, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(1), "A single event was sent.");
                    Assert.That(readState.Events.Values.Single().Data.IsEquivalentTo(singleEvent), "The single event did not match the corresponding read event.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadSingleEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var singleEvent = EventGenerator.CreateEvents(1).Single();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, new EventData[] { singleEvent }, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, 1, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(1), "A single event was sent.");
                    Assert.That(readState.Events.Values.Single().Data.IsEquivalentTo(singleEvent), "The single event did not match the corresponding read event.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadSingleLargeEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var buffer = new byte[100000];
                new Random().NextBytes(buffer);

                var singleEvent = EventGenerator.CreateEventFromBody(buffer);
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, new EventData[] { singleEvent }, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, 1, cancellationSource.Token);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(1), "A single event was sent.");
                    Assert.That(readState.Events.Values.Single().Data.IsEquivalentTo(singleEvent), "The single event did not match the corresponding read event.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadBatchOfZeroLengthEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                var sourceEvents = Enumerable
                    .Range(0, 25)
                    .Select(index => EventGenerator.CreateEventFromBody(Array.Empty<byte>()))
                    .ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadBatchOfEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadBatchOfEventsWithCustomPrefetchAndBatchCounts()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readOptions = new ReadEventOptions { PrefetchCount = 150, CacheEventCount = 50 };
                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: readOptions);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadBatchOfEventsWithCustomPrefetchAndBatchCountsAndPrefetchSize()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readOptions = new ReadEventOptions { PrefetchCount = 150, CacheEventCount = 50,  PrefetchSizeInBytes = 128 };
                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: readOptions);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadEventsWithPrefetchDisabled()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readOptions = new ReadEventOptions { PrefetchCount = 0 };
                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: readOptions);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadEventsWithCustomProperties()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                var sourceEvents = EventGenerator.CreateEvents(50)
                    .Select(current =>
                    {
                        current.Properties["Something"] = DateTimeOffset.UtcNow;
                        current.Properties["Other"] = Guid.NewGuid().ToString();

                        return current;
                    })
                    .ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadEventsUsingAnIdentityCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var credential = EventHubsTestEnvironment.Instance.Credential;
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadEventsUsingTheSharedKeyCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var credential = new EventHubsSharedAccessKeyCredential(EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromEarliest()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token, EventPosition.Earliest);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromLatest()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    // Send a set of seed events to the partition, which should not be read.

                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, EventGenerator.CreateEvents(50), new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Begin reading though no events have been published.  This is necessary to open the connection and
                    // ensure that the consumer is watching the partition.

                    var readTask = ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token, EventPosition.Latest);

                    // Give the consumer a moment to ensure that it is established and then send events for it to read.

                    await Task.Delay(250);
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Await reading of the events and validate the resulting state.

                    var readState = await readTask;
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(sourceEvents.Count), "Only the source events should have been read.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ConsumerCanReadFromOffset(bool isInclusive)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var seedEvents = EventGenerator.CreateEvents(50).ToList();
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    // Seed the partition with a set of events prior to reading.  When the send call returns, all events were
                    // accepted by the Event Hubs service and should be available in the partition.  Provide a minor delay to
                    // allow for any latency within the service.

                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();

                    await SendEventsAsync(connectionString, seedEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                    await Task.Delay(250);

                    // Query the partition and determine the offset of the last enqueued event, then send the new set
                    // of events that should appear after the starting position.

                    var lastOffset = (await consumer.GetPartitionPropertiesAsync(partition, cancellationSource.Token)).LastEnqueuedOffset;
                    var startingPosition = EventPosition.FromOffset(lastOffset, isInclusive);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var expectedCount = (isInclusive) ? sourceEvents.Count + 1 : sourceEvents.Count;
                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, expectedCount, cancellationSource.Token, startingPosition);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(expectedCount), "The wrong number of events was read for the value of the inclusive flag.");
                    Assert.That(readState.Events.Values.Any(readEvent => readEvent.Data.Offset == lastOffset), Is.EqualTo(isInclusive), $"The event with offset [{ lastOffset }] was { ((isInclusive) ? "not" : "") } in the set of read events, which is inconsistent with the inclusive flag.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ConsumerCanReadFromSequenceNumber(bool isInclusive)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var seedEvents = EventGenerator.CreateEvents(50).ToList();
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    // Seed the partition with a set of events prior to reading.  When the send call returns, all events were
                    // accepted by the Event Hubs service and should be available in the partition.  Provide a minor delay to
                    // allow for any latency within the service.

                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();

                    await SendEventsAsync(connectionString, seedEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                    await Task.Delay(250);

                    // Query the partition and determine the offset of the last enqueued event, then send the new set
                    // of events that should appear after the starting position.

                    var lastSequence = (await consumer.GetPartitionPropertiesAsync(partition, cancellationSource.Token)).LastEnqueuedSequenceNumber;
                    var startingPosition = EventPosition.FromSequenceNumber(lastSequence, isInclusive);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var expectedCount = (isInclusive) ? sourceEvents.Count + 1 : sourceEvents.Count;
                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, expectedCount, cancellationSource.Token, startingPosition);

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(expectedCount), "The wrong number of events was read for the value of the inclusive flag.");
                    Assert.That(readState.Events.Values.Any(readEvent => readEvent.Data.SequenceNumber == lastSequence), Is.EqualTo(isInclusive), $"The event with sequence number [{ lastSequence }] was { ((isInclusive) ? "not" : "") } in the set of read events, which is inconsistent with the inclusive flag.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromEnqueuedTime()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var seedEvents = EventGenerator.CreateEvents(50).ToList();
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    // Seed the partition with a set of events prior to reading.  When the send call returns, all events were
                    // accepted by the Event Hubs service and should be available in the partition.  Provide a minor delay to
                    // allow for any latency within the service.

                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();

                    await SendEventsAsync(connectionString, seedEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);
                    await Task.Delay(250);

                    // Query the partition and determine the offset of the last enqueued event, then send the new set
                    // of events that should appear after the starting position.

                    var lastEnqueuedTime = (await consumer.GetPartitionPropertiesAsync(partition, cancellationSource.Token)).LastEnqueuedTime;
                    var startingPosition = EventPosition.FromEnqueuedTime(lastEnqueuedTime);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token, startingPosition);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(sourceEvents.Count), "The number of events received should match.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromMultipleConsumerGroups()
        {
            var customConsumerGroup = "anotherConsumerGroup";

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1, new[] { customConsumerGroup }))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                await using (var customConsumer = new EventHubConsumerClient(customConsumerGroup, connectionString))
                await using (var defaultConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await defaultConsumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await Task.WhenAll
                    (
                        ReadEventsFromPartitionAsync(customConsumer, partition, sourceEvents.Count, cancellationSource.Token),
                        ReadEventsFromPartitionAsync(defaultConsumer, partition, sourceEvents.Count, cancellationSource.Token)
                    );

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState[0].Events.TryGetValue(sourceId, out var customReadEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed for the custom consumer group." );
                        Assert.That(sourceEvent.IsEquivalentTo(customReadEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event for the custom consumer group.");

                        Assert.That(readState[1].Events.TryGetValue(sourceId, out var defaultReadEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed for the default consumer group." );
                        Assert.That(sourceEvent.IsEquivalentTo(defaultReadEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event for the default consumer group.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReadAcrossPartitions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var credential = EventHubsTestEnvironment.Instance.Credential;
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var partitions = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).ToArray();
                    var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[0] }, cancellationSource.Token);

                    // Attempt to read from the empty partition and verify that no events are observed.  Because no events are expected, the
                    // read operation will not naturally complete; limit the read to only a couple of seconds and trigger cancellation.

                    using var readCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token);
                    readCancellation.CancelAfter(TimeSpan.FromSeconds(5));

                    var readState = await ReadEventsFromPartitionAsync(consumer, partitions[1], sourceEvents.Count, readCancellation.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The main cancellation token should not have been signaled.");

                    Assert.That(readState.Events.Count, Is.Zero, "No events should have been read from the empty partition.");
                    Assert.That(readState.EmptyCount, Is.Zero, "No empty ticks should have occurred.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReadWhenClosed()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Create a local function that will close the consumer after five events have
                    // been read.  Because the close happens in the middle of iteration, allow for a short
                    // delay to ensure that the state transition has been fully captured.

                    async Task<bool> closeAfterRead(ReadState state)
                    {
                        if (state.Events.Count >= 2)
                        {
                            await consumer.CloseAsync(cancellationSource.Token);
                            await Task.Yield();
                        }

                        return true;
                    }

                    var readTask = ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: LowPrefetchReadOptions, iterationCallback: closeAfterRead);

                    Assert.That(async () => await readTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReadFromInvalidPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
               cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    var invalidPartition = "-1";
                    var readTask = ReadNothingAsync(consumer, invalidPartition, cancellationSource.Token);

                    Assert.That(async () => await readTask, Throws.InstanceOf<ArgumentOutOfRangeException>());
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReadFromInvalidConsumerGroup()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
               cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var invalidConsumerGroup = "ThisIsFake";

                await using (var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                await using (var consumer = new EventHubConsumerClient(invalidConsumerGroup, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    var readTask = ReadNothingAsync(consumer, partition, cancellationSource.Token);

                    Assert.That(async () => await readTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ResourceNotFound));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReadWithInvalidProxy()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var clientOptions = new EventHubConsumerClientOptions();
                clientOptions.RetryOptions.MaximumRetries = 0;
                clientOptions.RetryOptions.MaximumDelay = TimeSpan.FromMilliseconds(5);
                clientOptions.RetryOptions.TryTimeout = TimeSpan.FromSeconds(45);
                clientOptions.ConnectionOptions.Proxy = new WebProxy("http://1.2.3.4:9999");
                clientOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

                await using (var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                await using (var invalidProxyConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName, clientOptions))
                {
                    var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();

                    // The sockets implementation in .NET Core on some platforms, such as Linux, does not trigger a specific socket exception and
                    // will, instead, hang indefinitely.  The try timeout is intentionally set to a value smaller than the cancellation token to
                    // invoke a timeout exception in these cases.

                    Assert.That(async () => await ReadNothingAsync(invalidProxyConsumer, partition, cancellationSource.Token, iterationCount: 25), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReadAsNonExclusiveWhenAnExclusiveReaderIsActive()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var exclusiveOptions = DefaultReadOptions.Clone();
                exclusiveOptions.PrefetchCount = LowPrefetchCount;
                exclusiveOptions.OwnerLevel = 20;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    var exclusiveMonitor = MonitorReadingEventsFromPartition(consumer, partition, int.MaxValue, cancellationSource.Token, readOptions: exclusiveOptions);
                    await Task.WhenAny(exclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    var nonExclusiveReadTask = ReadEventsFromPartitionAsync(consumer, partition, int.MaxValue, cancellationSource.Token, readOptions: LowPrefetchReadOptions);
                    Assert.That(async () => await nonExclusiveReadTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected), "The non-exclusive read should be rejected.");
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    cancellationSource.Cancel();
                    await exclusiveMonitor.ReadTask;
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReadWithLowerOwnerLevelThanActiveReader()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = DefaultReadOptions.Clone();
                higherOptions.PrefetchCount = LowPrefetchCount;
                higherOptions.OwnerLevel = 40;

                var lowerOptions = DefaultReadOptions.Clone();
                lowerOptions.PrefetchCount = LowPrefetchCount;
                lowerOptions.OwnerLevel = 20;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    var higherMonitor = MonitorReadingEventsFromPartition(consumer, partition, int.MaxValue, cancellationSource.Token, readOptions: higherOptions);
                    await Task.WhenAny(higherMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    var lowerReadTask = ReadEventsFromPartitionAsync(consumer, partition, int.MaxValue, cancellationSource.Token, readOptions: lowerOptions);
                    Assert.That(async () => await lowerReadTask, Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected), "The lower-level read should be rejected.");
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    cancellationSource.Cancel();
                    await higherMonitor.ReadTask;
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromMultiplePartitionsWithDifferentActiveOwnerLevels()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = DefaultReadOptions.Clone();
                higherOptions.PrefetchCount = LowPrefetchCount;
                higherOptions.OwnerLevel = 40;

                var lowerOptions = DefaultReadOptions.Clone();
                lowerOptions.PrefetchCount = LowPrefetchCount;
                lowerOptions.OwnerLevel = 20;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitions = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).Take(2).ToArray();

                    // Send the same set of events to both partitions.

                    await Task.WhenAll
                    (
                        SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[0] }, cancellationSource.Token),
                        SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[1] }, cancellationSource.Token)
                    );

                    // Read from each partition, allowing the higher level operation to begin first.  Both read operations should be
                    // successful and read all events from their respective partition.

                    var higherMonitor = MonitorReadingEventsFromPartition(consumer, partitions[0], sourceEvents.Count, cancellationSource.Token, readOptions: higherOptions);
                    var lowerMonitor = MonitorReadingEventsFromPartition(consumer, partitions[1], sourceEvents.Count, cancellationSource.Token, readOptions: lowerOptions);

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
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromMultipleConsumerGroupsWithDifferentActiveOwnerLevels()
        {
            var consumerGroups = new[] { "customGroup", "customTwo" };

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1, consumerGroups))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = DefaultReadOptions.Clone();
                higherOptions.PrefetchCount = LowPrefetchCount;
                higherOptions.OwnerLevel = 40;

                var lowerOptions = DefaultReadOptions.Clone();
                lowerOptions.PrefetchCount = LowPrefetchCount;
                lowerOptions.OwnerLevel = 20;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(100).ToList();

                await using (var firstGroupConsumer = new EventHubConsumerClient(scope.ConsumerGroups[0], connectionString))
                await using (var secondGroupConsumer = new EventHubConsumerClient(scope.ConsumerGroups[1], connectionString))
                {
                    var partition = (await firstGroupConsumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Read from each partition, allowing the higher level operation to begin first.  Both read operations should be
                    // successful and read all events from their respective partition.

                    var higherMonitor = MonitorReadingEventsFromPartition(firstGroupConsumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: higherOptions);
                    var lowerMonitor = MonitorReadingEventsFromPartition(secondGroupConsumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: lowerOptions);

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
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ExclusiveConsumerSupercedesNonExclusiveActiveReader()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var exclusiveOptions = DefaultReadOptions.Clone();
                exclusiveOptions.PrefetchCount = LowPrefetchCount;
                exclusiveOptions.OwnerLevel = 20;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Start the non-exclusive read, waiting until at least some events were read before starting the exclusive reader.

                    var nonExclusiveMonitor = MonitorReadingEventsFromPartition(consumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: LowPrefetchReadOptions);

                    await Task.WhenAny(nonExclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The non-exclusive reader has been confirmed to be active; start the exclusive level reader and validate that it supersedes the lower.

                    var exclusiveMonitor = MonitorReadingEventsFromPartition(consumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: exclusiveOptions);
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
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerWithHigherOwnerLevelSupercedesActiveReader()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = DefaultReadOptions.Clone();
                higherOptions.PrefetchCount = LowPrefetchCount;
                higherOptions.OwnerLevel = 40;

                var lowerOptions = DefaultReadOptions.Clone();
                higherOptions.PrefetchCount = LowPrefetchCount;
                lowerOptions.OwnerLevel = 20;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Start the lower level read, waiting until at least some events were read before starting the higher reader.

                    var lowerMonitor = MonitorReadingEventsFromPartition(consumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: lowerOptions);

                    await Task.WhenAny(lowerMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The lower reader has been confirmed to be active; start the higher level reader and validate that it supersedes the lower.

                    var higherMonitor = MonitorReadingEventsFromPartition(consumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: higherOptions);
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
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ExclusiveConsumerDoesNotSupercedNonExclusiveActiveReaderOnAnotherPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var exclusiveOptions = DefaultReadOptions.Clone();
                exclusiveOptions.PrefetchCount = LowPrefetchCount;
                exclusiveOptions.OwnerLevel = 20;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitions = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).Take(2).ToArray();

                    // Send the same set of events to both partitions.

                    await Task.WhenAll
                    (
                        SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[0] }, cancellationSource.Token),
                        SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[1] }, cancellationSource.Token)
                    );

                    // Start the non-exclusive read, waiting until at least some events were read before starting the exclusive reader.

                    var nonExclusiveMonitor = MonitorReadingEventsFromPartition(consumer, partitions[0], sourceEvents.Count, cancellationSource.Token, readOptions: LowPrefetchReadOptions);

                    await Task.WhenAny(nonExclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The non-exclusive reader has been confirmed to be active; start the exclusive level reader and ensure that it is active so that
                    // both readers are confirmed to be running at the same time.

                    var exclusiveMonitor = MonitorReadingEventsFromPartition(consumer, partitions[1], sourceEvents.Count, cancellationSource.Token, readOptions: exclusiveOptions);

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
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ExclusiveConsumerDoesNotSupercedNonExclusiveActiveReaderOnAnotherConsumerGroup()
        {
            var consumerGroups = new[] { "customGroup", "customTwo" };

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1, consumerGroups))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var exclusiveOptions = DefaultReadOptions.Clone();
                exclusiveOptions.PrefetchCount = LowPrefetchCount;
                exclusiveOptions.OwnerLevel = 20;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                await using (var nonExclusiveConsumer = new EventHubConsumerClient(scope.ConsumerGroups[0], connectionString))
                await using (var exclusiveConsumer = new EventHubConsumerClient(scope.ConsumerGroups[1], connectionString))
                {
                    var partition = (await exclusiveConsumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Start the non-exclusive read, waiting until at least some events were read before starting the exclusive reader.

                    var nonExclusiveMonitor = MonitorReadingEventsFromPartition(nonExclusiveConsumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: LowPrefetchReadOptions);

                    await Task.WhenAny(nonExclusiveMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The non-exclusive reader has been confirmed to be active; start the exclusive level reader and ensure that it is active so that
                    // both readers are confirmed to be running at the same time.

                    var exclusiveMonitor = MonitorReadingEventsFromPartition(exclusiveConsumer, partition, sourceEvents.Count, cancellationSource.Token, readOptions: exclusiveOptions);

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
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerIsNotCompromisedByFailureToReadFromInvalidPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(50).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    await SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                    // Attempt to read from an invalid partition and confirm failure.

                    Assert.That(async () => await ReadNothingAsync(consumer, "-1", cancellationSource.Token), Throws.Exception);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // Read from the valid partition and confirm operation is not impacted.

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerIsNotCompromisedByBeingSupercededByAnotherReaderWithHigherLevel()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var higherOptions = DefaultReadOptions.Clone();
                higherOptions.PrefetchCount = LowPrefetchCount;
                higherOptions.OwnerLevel = 40;

                var lowerOptions = DefaultReadOptions.Clone();
                lowerOptions.PrefetchCount = LowPrefetchCount;
                lowerOptions.OwnerLevel = 20;

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateSmallEvents(200).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitions = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).Take(2).ToArray();

                    // Send the same set of events to both partitions.

                    await Task.WhenAll
                    (
                        SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[0] }, cancellationSource.Token),
                        SendEventsAsync(connectionString, sourceEvents, new CreateBatchOptions { PartitionId = partitions[1] }, cancellationSource.Token)
                    );

                    // Start the lower level read, waiting until at least some events were read before starting the higher reader.

                    var lowerMonitor = MonitorReadingEventsFromPartition(consumer, partitions[0], sourceEvents.Count, cancellationSource.Token, readOptions: lowerOptions);

                    await Task.WhenAny(lowerMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    // The lower reader has been confirmed to be active; start the higher level reader and validate that it supersedes the lower for the partition.

                    var higherMonitor = MonitorReadingEventsFromPartition(consumer, partitions[0], sourceEvents.Count, cancellationSource.Token, readOptions: higherOptions);
                    await Task.WhenAny(higherMonitor.StartCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(async () => await lowerMonitor.ReadTask, Throws.Exception, "The lower-level read should be rejected.");

                    // The consumer should be able to read events from another partition after being superseded.  Start a new reader for the other partition,
                    // using the same lower level.  Wait for both readers to complete and then signal for cancellation.

                    await Task.Delay(250);
                    var lowerReadState = await ReadEventsFromPartitionAsync(consumer, partitions[1], sourceEvents.Count, cancellationSource.Token, readOptions: lowerOptions);

                    await Task.WhenAny(higherMonitor.EndCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    cancellationSource.Cancel();

                    var higherReadState = await higherMonitor.ReadTask;

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(higherReadState.Events.TryGetValue(sourceId, out var higherEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed by the higher reader." );
                        Assert.That(sourceEvent.IsEquivalentTo(higherEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event for the higher reader.");

                        Assert.That(lowerReadState.Events.TryGetValue(sourceId, out var lowerEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed by the lower reader." );
                        Assert.That(sourceEvent.IsEquivalentTo(lowerEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event for the lower reader.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerRespectsTheWaitTimeWhenReading()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                    var options = new ReadEventOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(100) };
                    var desiredEmptyEvents = 10;
                    var minimumEmptyEvents = 5;

                    var readTime = TimeSpan
                        .FromMilliseconds(options.MaximumWaitTime.Value.TotalMilliseconds * desiredEmptyEvents)
                        .Add(TimeSpan.FromSeconds(10));

                    // Attempt to read from the empty partition and verify that no events are observed.  Because no events are expected, the
                    // read operation will not naturally complete; limit the read to only a couple of seconds and trigger cancellation.

                    using var readCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token);
                    readCancellation.CancelAfter(readTime);

                    var readState = await ReadEventsFromPartitionAsync(consumer, partition, int.MaxValue, readCancellation.Token, readOptions: options);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The main cancellation token should not have been signaled.");

                    Assert.That(readState.Events.Count, Is.Zero, "No events should have been read from the empty partition.");
                    Assert.That(readState.EmptyCount, Is.AtLeast(minimumEmptyEvents), "The number of empty events read should be consistent with the requested wait time.");
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ConsumerCanQueryEventHubProperties(EventHubsTransportType transportType)
        {
            var partitionCount = 4;
            var clientOptions = new EventHubConsumerClientOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitionCount))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName, clientOptions))
                {
                    var properties = await consumer.GetEventHubPropertiesAsync(cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.Name, Is.EqualTo(scope.EventHubName), "The property Event Hub name should match the scope.");
                    Assert.That(properties.PartitionIds.Length, Is.EqualTo(partitionCount), "The properties should have the requested number of partitions.");
                    Assert.That(properties.CreatedOn, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(60)), "The Event Hub should have been created just about now.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ConsumerCanQueryPartitionProperties(EventHubsTransportType transportType)
        {
            var partitionCount = 1;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitionCount))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var clientOptions = new EventHubConsumerClientOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, scope.EventHubName, clientOptions))
                {
                    var properties = await consumer.GetEventHubPropertiesAsync();
                    var partition = properties.PartitionIds.First();

                    var partitionProperties = await consumer.GetPartitionPropertiesAsync(partition, cancellationSource.Token);
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
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ConnectionTransportPartitionIdsMatchPartitionProperties()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    var properties = await consumer.GetEventHubPropertiesAsync(cancellationSource.Token);
                    var partitions = await consumer.GetPartitionIdsAsync(cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.PartitionIds, Is.Not.Null, "A set of partition identifiers for the properties should have been returned.");
                    Assert.That(partitions, Is.Not.Null, "A set of partition identifiers should have been returned.");
                    Assert.That(partitions, Is.EquivalentTo(properties.PartitionIds), "The partition identifiers returned directly should match those returned with properties.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotRetrieveMetadataWhenClosed()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();

                    Assert.That(async () => await consumer.GetEventHubPropertiesAsync(cancellationSource.Token), Throws.Nothing);
                    Assert.That(async () => await consumer.GetPartitionPropertiesAsync(partition, cancellationSource.Token), Throws.Nothing);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    await consumer.CloseAsync();
                    await Task.Delay(TimeSpan.FromSeconds(5));

                    Assert.That(async () => await consumer.GetPartitionIdsAsync(cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(async () => await consumer.GetEventHubPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(async () => await consumer.GetPartitionPropertiesAsync(partition, cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase("XYZ")]
        [TestCase("-1")]
        [TestCase("1000")]
        [TestCase("-")]
        public async Task ConsumerCannotRetrievePartitionPropertiesWithInvalidPartitionId(string invalidPartition)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName))
                {
                    Assert.That(async () => await consumer.GetPartitionPropertiesAsync(invalidPartition, cancellationSource.Token), Throws.TypeOf<ArgumentOutOfRangeException>());
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotRetrieveMetadataWithInvalidProxy()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                var invalidProxyOptions = new EventHubConsumerClientOptions();
                invalidProxyOptions.RetryOptions.MaximumRetries = 0;
                invalidProxyOptions.RetryOptions.MaximumDelay = TimeSpan.FromMilliseconds(5);
                invalidProxyOptions.RetryOptions.TryTimeout = TimeSpan.FromSeconds(45);
                invalidProxyOptions.ConnectionOptions.Proxy = new WebProxy("http://1.2.3.4:9999");
                invalidProxyOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                await using (var invalidProxyConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, invalidProxyOptions))
                {
                    var partition = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).First();

                    // The sockets implementation in .NET Core on some platforms, such as Linux, does not trigger a specific socket exception and
                    // will, instead, hang indefinitely.  The try timeout is intentionally set to a value smaller than the cancellation token to
                    // invoke a timeout exception in these cases.

                    Assert.That(async () => await invalidProxyConsumer.GetPartitionIdsAsync(cancellationSource.Token), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(async () => await invalidProxyConsumer.GetEventHubPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(async () => await invalidProxyConsumer.GetPartitionPropertiesAsync(partition, cancellationSource.Token), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromAllPartitions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitions = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).ToArray();

                    var sendCount = await SendEventsToAllPartitionsAsync(connectionString, sourceEvents, partitions, cancellationSource.Token);
                    Assert.That(sendCount, Is.EqualTo(sourceEvents.Count), "All of the events should have been sent.");

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromAllPartitionsAsync(consumer, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromAllPartitionsWithCustomPrefetchAndBatchCount()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitions = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).ToArray();

                    var sendCount = await SendEventsToAllPartitionsAsync(connectionString, sourceEvents, partitions, cancellationSource.Token);
                    Assert.That(sendCount, Is.EqualTo(sourceEvents.Count), "All of the events should have been sent.");

                    // Read the events and validate the resulting state.

                    var readOptions = new ReadEventOptions { PrefetchCount = 50, CacheEventCount = 50 };
                    var readState = await ReadEventsFromAllPartitionsAsync(consumer, sourceEvents.Count, cancellationSource.Token, readOptions: readOptions);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromAllPartitionsUsingAnIdentityCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var credential = EventHubsTestEnvironment.Instance.Credential;
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                    var partitions = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).ToArray();

                    var sendCount = await SendEventsToAllPartitionsAsync(connectionString, sourceEvents, partitions, cancellationSource.Token);
                    Assert.That(sendCount, Is.EqualTo(sourceEvents.Count), "All of the events should have been sent.");

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromAllPartitionsAsync(consumer, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromAllPartitionsUsingTheSharedKeyCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var credential = new EventHubsSharedAccessKeyCredential(EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                    var partitions = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).ToArray();

                    var sendCount = await SendEventsToAllPartitionsAsync(connectionString, sourceEvents, partitions, cancellationSource.Token);
                    Assert.That(sendCount, Is.EqualTo(sourceEvents.Count), "All of the events should have been sent.");

                    // Read the events and validate the resulting state.

                    var readState = await ReadEventsFromAllPartitionsAsync(consumer, sourceEvents.Count, cancellationSource.Token);
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromAllPartitionsStartingWithLatest()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var sourceEvents = EventGenerator.CreateEvents(100).ToList();

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    // Send a set of seed events, which should not be read.

                    var partitions = (await consumer.GetPartitionIdsAsync(cancellationSource.Token)).ToArray();
                    await SendEventsToAllPartitionsAsync(connectionString, EventGenerator.CreateEvents(50), partitions, cancellationSource.Token);

                    // Begin reading though no events have been published.  This is necessary to open the connection and
                    // ensure that the consumer is watching the partition.

                    var readTask = ReadEventsFromAllPartitionsAsync(consumer, sourceEvents.Count, cancellationSource.Token, startFromEarliest: false);

                    // Give the consumer a moment to ensure that it is established and then send events for it to read.

                    await Task.Delay(250);
                    await SendEventsToAllPartitionsAsync(connectionString, sourceEvents, partitions, cancellationSource.Token);

                    // Read the events and validate the resulting state.

                    var readState = await readTask;
                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
                    Assert.That(readState.Events.Count, Is.EqualTo(sourceEvents.Count), "Only the source events should have been read.");

                    foreach (var sourceEvent in sourceEvents)
                    {
                        var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                        Assert.That(readState.Events.TryGetValue(sourceId, out var readEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
                        Assert.That(sourceEvent.IsEquivalentTo(readEvent.Data), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
                    }
                }

                cancellationSource.Cancel();
            }
        }

        /// <summary>
        ///   Reads the events from a given position, tracking the operation.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to use for reading.</param>
        /// <param name="partition">The identifier of the partition to read from.</param>
        /// <param name="expectedEventCount">The expected count of events; when this number of events has been read, reading will cease.</param>
        /// <param name="cancellationToken">The token used to signal cancellation of the read.</param>
        /// <param name="startingPosition">The position in the partition to start reading from.</param>
        /// <param name="readOptions">The options to apply when reading.</param>
        /// <param name="iterationCallback">A callback function to invoke each tick of the loop, receiving the current read state and allowing forced termination.</param>
        ///
        /// <returns>The final state when reading has ceased.</returns>
        ///
        private async Task<ReadState> ReadEventsFromPartitionAsync(EventHubConsumerClient consumer,
                                                                   string partition,
                                                                   int expectedEventCount,
                                                                   CancellationToken cancellationToken,
                                                                   EventPosition? startingPosition = default,
                                                                   ReadEventOptions readOptions = default,
                                                                   Func<ReadState, Task<bool>> iterationCallback = default)
        {
            readOptions ??= DefaultReadOptions;
            startingPosition ??= EventPosition.Earliest;

            var result = new ReadState();
            var shouldKeepReading = true;

            try
            {
                var readAwaitable = consumer.ReadEventsFromPartitionAsync(partition, startingPosition.Value, readOptions, cancellationToken).ConfigureAwait(false);

                await foreach (var partitionEvent in readAwaitable)
                {
                    // Track the events as they are read.

                    if (partitionEvent.Data == null)
                    {
                        ++result.EmptyCount;
                    }
                    else
                    {
                        var eventId = partitionEvent.Data.Properties[EventGenerator.IdPropertyName].ToString();

                        if ((result.Events.TryAdd(eventId, partitionEvent)) && (result.Events.Count >= expectedEventCount))
                        {
                            shouldKeepReading = false;
                        }
                    }

                    // If there's a callback registered per-tick, invoke it and respect its
                    // decision on whether iteration should continue.

                    if ((iterationCallback != null) && (!(await iterationCallback(result).ConfigureAwait(false))))
                    {
                        shouldKeepReading = false;
                    }

                    if (!shouldKeepReading)
                    {
                        break;
                    }
                }

                // Delay for a moment before returning the results to ensure that cleanup has registered
                // with the service and the associated link is no longer alive.

                await Task.Delay(250).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                // The test should assert on the cancellation token; treat this as
                // expected and don't bubble.
            }

            return result;
        }

        /// <summary>
        ///   Reads the events across all partitions from a given position, tracking the operation.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to use for reading.</param>
        /// <param name="expectedEventCount">The expected count of events; when this number of events has been read, reading will cease.</param>
        /// <param name="cancellationToken">The token used to signal cancellation of the read.</param>
        /// <param name="startFromEarliest"><c>true</c> to start reading from the earliest position; otherwise, <c>false</c>.</param>
        /// <param name="readOptions">The options to apply when reading.</param>
        /// <param name="iterationCallback">A callback function to invoke each tick of the loop, receiving the current read state and allowing forced termination.</param>
        ///
        /// <returns>The final state when reading has ceased.</returns>
        ///
        private async Task<ReadState> ReadEventsFromAllPartitionsAsync(EventHubConsumerClient consumer,
                                                                       int expectedEventCount,
                                                                       CancellationToken cancellationToken,
                                                                       bool startFromEarliest = true,
                                                                       ReadEventOptions readOptions = default,
                                                                       Func<ReadState, Task<bool>> iterationCallback = default)
        {
            readOptions ??= DefaultReadOptions;

            var result = new ReadState();

            try
            {
                var readAwaitable = consumer.ReadEventsAsync(startFromEarliest, readOptions, cancellationToken).ConfigureAwait(false);

                await foreach (var partitionEvent in readAwaitable)
                {
                    // Track the events as they are read.

                    if (partitionEvent.Data == null)
                    {
                        ++result.EmptyCount;
                    }
                    else
                    {
                        var eventId = partitionEvent.Data.Properties[EventGenerator.IdPropertyName].ToString();

                        if ((result.Events.TryAdd(eventId, partitionEvent)) && (result.Events.Count >= expectedEventCount))
                        {
                            break;
                        }
                    }

                    // If there's a callback registered per-tick, invoke it and respect its
                    // decision on whether iteration should continue.

                    if ((iterationCallback != null) && (!(await iterationCallback(result).ConfigureAwait(false))))
                    {
                        break;
                    }
                }

                // Delay for a moment before returning the results to ensure that cleanup has registered
                // with the service and the associated link is no longer alive.

                await Task.Delay(250).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                // The test should assert on the cancellation token; treat this as
                // expected and don't bubble.
            }

            return result;
        }

        /// <summary>
        ///   Iterates a partition for the given consumer a small number of times, ignoring the events.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to use for reading.</param>
        /// <param name="partition">The identifier of the partition to read from.</param>
        /// <param name="cancellationToken">The token used to signal cancellation of the read.</param>
        /// <param name="startingPosition">The position in the partition to start reading from.</param>
        /// <param name="iterationCount">The number of iterations to perform.</param>
        /// <param name="readOptions">The options to apply when reading.</param>
        ///
        private async Task ReadNothingAsync(EventHubConsumerClient consumer,
                                            string partition,
                                            CancellationToken cancellationToken,
                                            EventPosition? startingPosition = default,
                                            ReadEventOptions readOptions = default,
                                            int iterationCount = 5)
        {
            readOptions ??= new ReadEventOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(150) };
            startingPosition ??= EventPosition.Earliest;

            try
            {
                var readAwaitable = consumer.ReadEventsFromPartitionAsync(partition, startingPosition.Value, readOptions, cancellationToken).ConfigureAwait(false);

                await foreach (var item in readAwaitable)
                {
                    await Task.Delay(250).ConfigureAwait(false);

                    if (--iterationCount <= 0)
                    {
                        break;
                    }
                }

                // Delay for a moment to ensure that cleanup has registered with the
                // service and the associated link is no longer alive.

                await Task.Delay(250).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                // The test should assert on the cancellation token; treat this as
                // expected and don't bubble.
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
        ///   Sends a set of events to the desired partitions, using a reasonably even
        ///   distribution with no guaranteed ordering.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use when creating the producer.</param>
        /// <param name="sourceEvents">The set of events to send.</param>
        /// <param name="partitionIds">The set of partitions to send events to.</param>
        /// <param name="cancellationToken">The token used to signal a cancellation request.</param>
        ///
        /// <returns>The count of events that were sent.</returns>
        ///
        private async Task<int> SendEventsToAllPartitionsAsync(string connectionString,
                                                               IEnumerable<EventData> sourceEvents,
                                                               string[] partitionIds,
                                                               CancellationToken cancellationToken = default)
        {
            var sendTasks = sourceEvents
                .GroupBy(eventData => (eventData.GetHashCode() % partitionIds.Length))
                .Select(eventGroup =>
                {
                    var options = new CreateBatchOptions { PartitionId = partitionIds[eventGroup.Key] };
                    return SendEventsAsync(connectionString, eventGroup, options, cancellationToken);
                });

            var sendCounts = await Task.WhenAll(sendTasks).ConfigureAwait(false);
            return sendCounts.Sum();
        }

        /// <summary>
        ///   Begins reading events from a given position, monitoring the status of the operation.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to use for reading.</param>
        /// <param name="partition">The identifier of the partition to read from.</param>
        /// <param name="expectedEventCount">The expected count of events; when this number of events has been read, the <see cref="ReadMonitor.EndCompletion" /> will be signaled.</param>
        /// <param name="cancellationToken">THe token used to signal cancellation of the read.</param>
        /// <param name="startingPosition">The position in the partition to start reading from.</param>
        /// <param name="readOptions">The options to apply when reading.</param>
        ///
        /// <returns>The set of monitoring primitives to observe the status of the read.</returns>
        ///
        /// <remarks>
        ///   The read operation will not terminate without cancellation; when the <paramref name="expectedEventCount" /> has been reached,
        ///   the <see cref="ReadMonitor.EndCompletion" /> will be signaled but the operation will be allowed to continue.
        /// </remarks>
        ///
        private ReadMonitor MonitorReadingEventsFromPartition(EventHubConsumerClient consumer,
                                                              string partition,
                                                              int expectedEventCount,
                                                              CancellationToken cancellationToken,
                                                              EventPosition? startingPosition = default,
                                                              ReadEventOptions readOptions = default)
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

            monitor.ReadTask = ReadEventsFromPartitionAsync(consumer, partition, int.MaxValue, cancellationToken, startingPosition, readOptions, readCallback);
            return monitor;
        }

        /// <summary>
        ///   The results of reading events.
        /// </summary>
        ///
        private class ReadState
        {
            public readonly ConcurrentDictionary<string, PartitionEvent> Events = new ConcurrentDictionary<string, PartitionEvent>();
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
