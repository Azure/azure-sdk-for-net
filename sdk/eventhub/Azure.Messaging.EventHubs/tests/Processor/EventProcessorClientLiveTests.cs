// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventProcessorClient" />
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
    public class EventProcessorClientLiveTests
    {
        /// <summary>The maximum number of times that the receive loop should iterate to collect the expected number of messages.</summary>
        private const int ReceiveRetryLimit = 10;

        /// <summary>The default retry policy to use for test operations.</summary>
        private static readonly EventHubRetryPolicy DefaultRetryPolicy = new RetryOptions().ToRetryPolicy();

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncCallsPartitionProcessorInitializeAsync()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var initializeCalls = new ConcurrentDictionary<string, int>();

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            onInitialize: partitionContext =>
                                initializeCalls.AddOrUpdate(partitionContext.PartitionId, 1, (partitionId, value) => value + 1)
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // InitializeAsync should have not been called when constructing the event processors.

                    Assert.That(initializeCalls.Keys, Is.Empty);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await eventProcessorManager.WaitStabilization();

                    // Validate results before calling stop.  This way, we can make sure the initialize calls were
                    // triggered by start.

                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(initializeCalls.TryGetValue(partitionId, out var calls), Is.True, $"{ partitionId }: InitializeAsync should have been called.");
                        Assert.That(calls, Is.EqualTo(1), $"{ partitionId }: InitializeAsync should have been called only once.");
                    }

                    Assert.That(initializeCalls.Keys.Count, Is.EqualTo(partitionIds.Count()));

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task StopAsyncCallsPartitionProcessorCloseAsyncWithShutdownReason()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var closeCalls = new ConcurrentDictionary<string, int>();
                    var closeReasons = new ConcurrentDictionary<string, PartitionProcessorCloseReason>();

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            onClose: (partitionContext, reason) =>
                            {
                                closeCalls.AddOrUpdate(partitionContext.PartitionId, 1, (partitionId, value) => value + 1);
                                closeReasons[partitionContext.PartitionId] = reason;
                            }
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await eventProcessorManager.WaitStabilization();

                    // CloseAsync should have not been called when constructing the event processor or initializing the partition processors.

                    Assert.That(closeCalls.Keys, Is.Empty);

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.

                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(closeCalls.TryGetValue(partitionId, out var calls), Is.True, $"{ partitionId }: CloseAsync should have been called.");
                        Assert.That(calls, Is.EqualTo(1), $"{ partitionId }: CloseAsync should have been called only once.");

                        Assert.That(closeReasons.TryGetValue(partitionId, out PartitionProcessorCloseReason reason), Is.True, $"{ partitionId }: close reason should have been set.");
                        Assert.That(reason, Is.EqualTo(PartitionProcessorCloseReason.Shutdown), $"{ partitionId }: unexpected close reason.");
                    }

                    Assert.That(closeCalls.Keys.Count, Is.EqualTo(partitionIds.Count()));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task PartitionProcessorProcessEventsAsyncReceivesAllEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var allReceivedEvents = new ConcurrentDictionary<string, List<EventData>>();

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            onProcessEvents: (partitionContext, events) =>
                            {
                                // Make it a list so we can safely enumerate it.

                                var eventsList = new List<EventData>(events ?? Enumerable.Empty<EventData>());

                                if (eventsList.Count > 0)
                                {
                                    allReceivedEvents.AddOrUpdate
                                    (
                                        partitionContext.PartitionId,
                                        partitionId => eventsList,
                                        (partitionId, list) =>
                                        {
                                            list.AddRange(eventsList);
                                            return list;
                                        }
                                    );
                                }
                            }
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Send some events.

                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);
                    var expectedEvents = new Dictionary<string, List<EventData>>();

                    foreach (var partitionId in partitionIds)
                    {
                        // Send a similar set of events for every partition.

                        expectedEvents[partitionId] = new List<EventData>
                        {
                            new EventData(Encoding.UTF8.GetBytes($"{ partitionId }: event processor tests are so long.")),
                            new EventData(Encoding.UTF8.GetBytes($"{ partitionId }: there are so many of them.")),
                            new EventData(Encoding.UTF8.GetBytes($"{ partitionId }: will they ever end?")),
                            new EventData(Encoding.UTF8.GetBytes($"{ partitionId }: let's add a few more messages.")),
                            new EventData(Encoding.UTF8.GetBytes($"{ partitionId }: this is a monologue.")),
                            new EventData(Encoding.UTF8.GetBytes($"{ partitionId }: loneliness is what I feel.")),
                            new EventData(Encoding.UTF8.GetBytes($"{ partitionId }: the end has come."))
                        };

                        await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partitionId }))
                        {
                            await producer.SendAsync(expectedEvents[partitionId]);
                        }
                    }

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize and receive events.

                    await eventProcessorManager.WaitStabilization();

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.  Make sure we received every event in the correct partition processor,
                    // in the order they were sent.

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(allReceivedEvents.TryGetValue(partitionId, out List<EventData> partitionReceivedEvents), Is.True, $"{ partitionId }: there should have been a set of events received.");
                        Assert.That(partitionReceivedEvents.Count, Is.EqualTo(expectedEvents[partitionId].Count), $"{ partitionId }: amount of received events should match.");

                        var index = 0;

                        foreach (EventData receivedEvent in partitionReceivedEvents)
                        {
                            Assert.That(receivedEvent.IsEquivalentTo(expectedEvents[partitionId][index]), Is.True, $"{ partitionId }: the received event at index { index } did not match the sent set of events.");
                            ++index;
                        }
                    }

                    Assert.That(allReceivedEvents.Keys.Count, Is.EqualTo(partitionIds.Count()));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task PartitionProcessorProcessEventsAsyncIsCalledWithNoEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var receivedEventSets = new ConcurrentBag<IEnumerable<EventData>>();

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            onProcessEvents: (partitionContext, events) =>
                                receivedEventSets.Add(events)
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await eventProcessorManager.WaitStabilization();

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.

                    Assert.That(receivedEventSets, Is.Not.Empty);
                    Assert.That(receivedEventSets.Any(set => (set == null || set.Any())), Is.False);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncDoesNothingWhenEventProcessorIsRunning()
        {
            var partitions = 1;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    int initializeCallsCount = 0;

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            onInitialize: partitionContext =>
                                Interlocked.Increment(ref initializeCallsCount)
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await eventProcessorManager.WaitStabilization();

                    // We should be able to call StartAsync again without getting an exception.

                    Assert.That(async () => await eventProcessorManager.StartAllAsync(), Throws.Nothing);

                    // Give the event processors more time in case they try to initialize again, which shouldn't happen.

                    await eventProcessorManager.WaitStabilization();

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.

                    Assert.That(initializeCallsCount, Is.EqualTo(partitions));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task StopAsyncDoesNothingWhenEventProcessorIsNotRunning()
        {
            var partitions = 1;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    int closeCallsCount = 0;

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            onClose: (partitionContext, reason) =>
                                Interlocked.Increment(ref closeCallsCount)
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Calling StopAsync before starting the event processors shouldn't have any effect.

                    Assert.That(async () => await eventProcessorManager.StopAllAsync(), Throws.Nothing);

                    Assert.That(closeCallsCount, Is.EqualTo(0));

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await eventProcessorManager.WaitStabilization();

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // We should be able to call StopAsync again without getting an exception.

                    Assert.That(async () => await eventProcessorManager.StopAllAsync(), Throws.Nothing);

                    // Validate results.

                    Assert.That(closeCallsCount, Is.EqualTo(partitions));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Failing test: needs debugging (Tracked by: #7458)")]
        public async Task EventProcessorCanStartAgainAfterStopping()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    int receivedEventsCount = 0;

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            onProcessEvents: (partitionContext, events) =>
                            {
                                // Make it a list so we can safely enumerate it.

                                var eventsList = new List<EventData>(events ?? Enumerable.Empty<EventData>());

                                if (eventsList.Count > 0)
                                {
                                    Interlocked.Add(ref receivedEventsCount, eventsList.Count);
                                }
                            }
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Send some events.

                    var expectedEventsCount = 20;

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        var dummyEvent = new EventData(Encoding.UTF8.GetBytes("I'm dummy."));

                        for (int i = 0; i < expectedEventsCount; i++)
                        {
                            await producer.SendAsync(dummyEvent);
                        }
                    }

                    // We'll start and stop the event processors twice.  This way, we can assert they will behave
                    // the same way both times, reprocessing all events in the second run.

                    for (int i = 0; i < 2; i++)
                    {
                        receivedEventsCount = 0;

                        // Start the event processors.

                        await eventProcessorManager.StartAllAsync();

                        // Make sure the event processors have enough time to stabilize and receive events.

                        await eventProcessorManager.WaitStabilization();

                        // Stop the event processors.

                        await eventProcessorManager.StopAllAsync();

                        // Validate results.

                        Assert.That(receivedEventsCount, Is.EqualTo(expectedEventsCount), $"Events should match in iteration { i + 1 }.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Unstable test. (Tracked by: #7458)")]
        public async Task EventProcessorCanReceiveFromCheckpointedEventPosition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    int receivedEventsCount = 0;

                    // Send some events.

                    var expectedEventsCount = 20;
                    var dummyEvent = new EventData(Encoding.UTF8.GetBytes("I'm dummy."));
                    long? checkpointedSequenceNumber = default;

                    var partitionId = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connectionString))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, partitionId, EventPosition.Earliest, connection))
                    {
                        // Send a few dummy events.  We are not expecting to receive these.

                        var dummyEventsCount = 30;

                        for (int i = 0; i < dummyEventsCount; i++)
                        {
                            await producer.SendAsync(dummyEvent);
                        }

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < dummyEventsCount) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await consumer.ReceiveAsync(dummyEventsCount + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(dummyEventsCount));

                        checkpointedSequenceNumber = receivedEvents.Last().SequenceNumber;

                        // Send the events we expect to receive.

                        for (int i = 0; i < expectedEventsCount; i++)
                        {
                            await producer.SendAsync(dummyEvent);
                        }
                    }

                    // Create a partition manager and add an ownership with a checkpoint in it.

                    var partitionManager = new InMemoryPartitionManager();

                    await partitionManager.ClaimOwnershipAsync(new List<PartitionOwnership>()
                    {
                        new PartitionOwnership(connection.FullyQualifiedNamespace, connection.EventHubName,
                            EventHubConsumerClient.DefaultConsumerGroupName, "ownerIdentifier", partitionId,
                            sequenceNumber: checkpointedSequenceNumber, lastModifiedTime: DateTimeOffset.UtcNow)
                    });

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            partitionManager,
                            onProcessEvents: (partitionContext, events) =>
                            {
                                // Make it a list so we can safely enumerate it.

                                var eventsList = new List<EventData>(events ?? Enumerable.Empty<EventData>());

                                if (eventsList.Count > 0)
                                {
                                    Interlocked.Add(ref receivedEventsCount, eventsList.Count);
                                }
                            }
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize and receive events.

                    await eventProcessorManager.WaitStabilization();

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.

                    Assert.That(receivedEventsCount, Is.EqualTo(expectedEventsCount));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task PartitionProcessorCanCreateACheckpointFromPartitionContext()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    // Send some events.

                    EventData lastEvent;
                    var dummyEvent = new EventData(Encoding.UTF8.GetBytes("I'm dummy."));

                    var partitionId = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, partitionId, EventPosition.Earliest, connectionString))
                    {
                        // Send a few events.  We are only interested in the last one of them.

                        var dummyEventsCount = 10;

                        for (int i = 0; i < dummyEventsCount; i++)
                        {
                            await producer.SendAsync(dummyEvent);
                        }

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < dummyEventsCount) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await consumer.ReceiveAsync(dummyEventsCount + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(dummyEventsCount));

                        lastEvent = receivedEvents.Last();
                    }

                    // Create a partition manager so we can retrieve the created checkpoint from it.

                    var partitionManager = new InMemoryPartitionManager();

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            partitionManager,
                            onProcessEvents: (partitionContext, events) =>
                            {
                                // Make it a list so we can safely enumerate it.

                                var eventsList = new List<EventData>(events ?? Enumerable.Empty<EventData>());

                                if (eventsList.Any())
                                {
                                    partitionContext.UpdateCheckpointAsync(eventsList.Last());
                                }
                            }
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize and receive events.

                    await eventProcessorManager.WaitStabilization();

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.

                    IEnumerable<PartitionOwnership> ownershipEnumerable = await partitionManager.ListOwnershipAsync(connection.FullyQualifiedNamespace, connection.EventHubName, EventHubConsumerClient.DefaultConsumerGroupName);

                    Assert.That(ownershipEnumerable, Is.Not.Null);
                    Assert.That(ownershipEnumerable.Count, Is.EqualTo(1));

                    PartitionOwnership ownership = ownershipEnumerable.Single();

                    Assert.That(ownership.Offset.HasValue, Is.True);
                    Assert.That(ownership.Offset.Value, Is.EqualTo(lastEvent.Offset));

                    Assert.That(ownership.SequenceNumber.HasValue, Is.True);
                    Assert.That(ownership.SequenceNumber.Value, Is.EqualTo(lastEvent.SequenceNumber));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Unstable test. (Tracked by: #7458). See also, line 784.")]
        public async Task EventProcessorCanReceiveFromSpecifiedInitialEventPosition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    int receivedEventsCount = 0;

                    // Send some events.

                    var expectedEventsCount = 20;
                    var dummyEvent = new EventData(Encoding.UTF8.GetBytes("I'm dummy."));
                    DateTimeOffset enqueuedTime;

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        // Send a few dummy events.  We are not expecting to receive these.

                        for (int i = 0; i < 30; i++)
                        {
                            await producer.SendAsync(dummyEvent);
                        }

                        // Wait a reasonable amount of time so the events are able to reach the service.

                        await Task.Delay(1000);

                        // Send the events we expect to receive.

                        enqueuedTime = DateTimeOffset.UtcNow;

                        for (int i = 0; i < expectedEventsCount; i++)
                        {
                            await producer.SendAsync(dummyEvent);
                        }
                    }

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            // FIX ME:  options: new EventProcessorClientOptions { DefaultInitialEventPosition = EventPosition.FromEnqueuedTime(enqueuedTime) },
                            onProcessEvents: (partitionContext, events) =>
                            {
                                // Make it a list so we can safely enumerate it.

                                var eventsList = new List<EventData>(events ?? Enumerable.Empty<EventData>());

                                if (eventsList.Count > 0)
                                {
                                    Interlocked.Add(ref receivedEventsCount, eventsList.Count);
                                }
                            }
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize and receive events.

                    await eventProcessorManager.WaitStabilization();

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.

                    Assert.That(receivedEventsCount, Is.EqualTo(expectedEventsCount));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(15)]
        [Ignore("Failing test: needs debugging (Tracked by: #7458)")]
        public async Task EventProcessorWaitsMaximumReceiveWaitTimeForEvents(int maximumWaitTimeInSecs)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var timestamps = new ConcurrentDictionary<string, List<DateTimeOffset>>();

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            options: new EventProcessorClientOptions { MaximumReceiveWaitTime = TimeSpan.FromSeconds(maximumWaitTimeInSecs) },
                            onInitialize: partitionContext =>
                                timestamps.TryAdd(partitionContext.PartitionId, new List<DateTimeOffset> { DateTimeOffset.UtcNow }),
                            onProcessEvents: (partitionContext, events) =>
                                timestamps.AddOrUpdate
                                    (
                                        // The key already exists, so the 'addValue' factory will never be called.

                                        partitionContext.PartitionId,
                                        partitionId => null,
                                        (partitionId, list) =>
                                        {
                                            list.Add(DateTimeOffset.UtcNow);
                                            return list;
                                        }
                                    )
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await eventProcessorManager.WaitStabilization();

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.

                    foreach (KeyValuePair<string, List<DateTimeOffset>> kvp in timestamps)
                    {
                        var partitionId = kvp.Key;
                        List<DateTimeOffset> partitionTimestamps = kvp.Value;

                        Assert.That(partitionTimestamps.Count, Is.GreaterThan(1), $"{ partitionId }: more time stamp samples were expected.");

                        for (int index = 1; index < partitionTimestamps.Count; index++)
                        {
                            var elapsedTime = partitionTimestamps[index].Subtract(partitionTimestamps[index - 1]).TotalSeconds;

                            Assert.That(elapsedTime, Is.GreaterThan(maximumWaitTimeInSecs - 0.1), $"{ partitionId }: elapsed time between indexes { index - 1 } and { index } was too short.");
                            Assert.That(elapsedTime, Is.LessThan(maximumWaitTimeInSecs + 5), $"{ partitionId }: elapsed time between indexes { index - 1 } and { index } was too long.");

                            ++index;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(10, 1)]
        [TestCase(10, 3)]
        [TestCase(10, 10)]
        [TestCase(30, 10)]
        [TestCase(32, 7)]
        [TestCase(32, 32)]
        [Ignore("Unstable test. (Tracked by: #7458)")]
        public async Task PartitionDistributionIsEvenAfterLoadBalancing(int partitions, int eventProcessors)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    ConcurrentDictionary<string, int> ownedPartitionsCount = new ConcurrentDictionary<string, int>();

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            onInitialize: partitionContext =>
                                ownedPartitionsCount.AddOrUpdate(partitionContext.OwnerIdentifier, 1, (ownerId, value) => value + 1),
                            onClose: (partitionContext, reason) =>
                                ownedPartitionsCount.AddOrUpdate(partitionContext.OwnerIdentifier, 0, (ownerId, value) => value - 1)
                        );

                    eventProcessorManager.AddEventProcessors(eventProcessors);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await eventProcessorManager.WaitStabilization();

                    // Take a snapshot of the current partition balancing status.

                    IEnumerable<int> ownedPartitionsCountSnapshot = ownedPartitionsCount.ToArray().Select(kvp => kvp.Value);

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.

                    var minimumOwnedPartitionsCount = partitions / eventProcessors;
                    var maximumOwnedPartitionsCount = minimumOwnedPartitionsCount + 1;

                    foreach (var count in ownedPartitionsCountSnapshot)
                    {
                        Assert.That(count, Is.InRange(minimumOwnedPartitionsCount, maximumOwnedPartitionsCount));
                    }

                    Assert.That(ownedPartitionsCountSnapshot.Sum(), Is.EqualTo(partitions));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Unstable test. (Tracked by: #7458)")]
        public async Task LoadBalancingIsEnforcedWhenDistributionIsUneven()
        {
            var partitions = 10;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    ConcurrentDictionary<string, int> ownedPartitionsCount = new ConcurrentDictionary<string, int>();

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connection,
                            onInitialize: partitionContext =>
                                ownedPartitionsCount.AddOrUpdate(partitionContext.OwnerIdentifier, 1, (ownerId, value) => value + 1),
                            onClose: (partitionContext, reason) =>
                                ownedPartitionsCount.AddOrUpdate(partitionContext.OwnerIdentifier, 0, (ownerId, value) => value - 1)
                        );

                    eventProcessorManager.AddEventProcessors(1);

                    // Start the event processors.

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await eventProcessorManager.WaitStabilization();

                    // Assert all partitions have been claimed.

                    Assert.That(ownedPartitionsCount.ToArray().Single().Value, Is.EqualTo(partitions));

                    // Insert a new event processor into the manager so it can start stealing partitions.

                    eventProcessorManager.AddEventProcessors(1);

                    await eventProcessorManager.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await eventProcessorManager.WaitStabilization();

                    // Take a snapshot of the current partition balancing status.

                    IEnumerable<int> ownedPartitionsCountSnapshot = ownedPartitionsCount.ToArray().Select(kvp => kvp.Value);

                    // Stop the event processors.

                    await eventProcessorManager.StopAllAsync();

                    // Validate results.

                    var minimumOwnedPartitionsCount = partitions / 2;
                    var maximumOwnedPartitionsCount = minimumOwnedPartitionsCount + 1;

                    foreach (var count in ownedPartitionsCountSnapshot)
                    {
                        Assert.That(count, Is.InRange(minimumOwnedPartitionsCount, maximumOwnedPartitionsCount));
                    }

                    Assert.That(ownedPartitionsCountSnapshot.Sum(), Is.EqualTo(partitions));
                }
            }
        }
    }
}
