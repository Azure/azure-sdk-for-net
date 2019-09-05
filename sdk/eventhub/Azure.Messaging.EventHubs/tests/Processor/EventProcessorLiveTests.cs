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
    ///   The suite of live tests for the <see cref="EventProcessor" />
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
    public class EventProcessorLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncCallsPartitionProcessorInitializeAsync()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var initializeCalls = new ConcurrentDictionary<string, int>();

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onInitialize: partitionContext =>
                                initializeCalls.AddOrUpdate(partitionContext.PartitionId, 1, (partitionId, value) => value + 1)
                        );

                    hub.AddEventProcessors(1);

                    // InitializeAsync should have not been called when constructing the event processors.

                    Assert.That(initializeCalls.Keys, Is.Empty);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await hub.WaitStabilization();

                    // Validate results before calling stop.  This way, we can make sure the initialize calls were
                    // triggered by start.

                    var partitionIds = await client.GetPartitionIdsAsync();

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(initializeCalls.TryGetValue(partitionId, out var calls), Is.True, $"{ partitionId }: InitializeAsync should have been called.");
                        Assert.That(calls, Is.EqualTo(1), $"{ partitionId }: InitializeAsync should have been called only once.");
                    }

                    Assert.That(initializeCalls.Keys.Count, Is.EqualTo(partitionIds.Count()));

                    // Stop the event processors.

                    await hub.StopAllAsync();
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task StopAsyncCallsPartitionProcessorCloseAsyncWithShutdownReason()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var closeCalls = new ConcurrentDictionary<string, int>();
                    var closeReasons = new ConcurrentDictionary<string, PartitionProcessorCloseReason>();

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onClose: (partitionContext, reason) =>
                                {
                                    closeCalls.AddOrUpdate(partitionContext.PartitionId, 1, (partitionId, value) => value + 1);
                                    closeReasons[partitionContext.PartitionId] = reason;
                                }
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await hub.WaitStabilization();

                    // CloseAsync should have not been called when constructing the event processor or initializing the partition processors.

                    Assert.That(closeCalls.Keys, Is.Empty);

                    // Stop the event processors.

                    await hub.StopAllAsync();

                    // Validate results.

                    var partitionIds = await client.GetPartitionIdsAsync();

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(closeCalls.TryGetValue(partitionId, out var calls), Is.True, $"{ partitionId }: CloseAsync should have been called.");
                        Assert.That(calls, Is.EqualTo(1), $"{ partitionId }: CloseAsync should have been called only once.");

                        Assert.That(closeReasons.TryGetValue(partitionId, out var reason), Is.True, $"{ partitionId }: close reason should have been set.");
                        Assert.That(reason, Is.EqualTo(PartitionProcessorCloseReason.Shutdown), $"{ partitionId }: unexpected close reason.");
                    }

                    Assert.That(closeCalls.Keys.Count, Is.EqualTo(partitionIds.Count()));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task PartitionProcessorProcessEventsAsyncReceivesAllEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var allReceivedEvents = new ConcurrentDictionary<string, List<EventData>>();

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onProcessEvents: (partitionContext, events, cancellationToken) =>
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

                    hub.AddEventProcessors(1);

                    // Send some events.

                    var partitionIds = await client.GetPartitionIdsAsync();
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

                        await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partitionId }))
                        {
                            await producer.SendAsync(expectedEvents[partitionId]);
                        }
                    }

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize and receive events.

                    await hub.WaitStabilization();

                    // Stop the event processors.

                    await hub.StopAllAsync();

                    // Validate results.  Make sure we received every event in the correct partition processor,
                    // in the order they were sent.

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(allReceivedEvents.TryGetValue(partitionId, out var partitionReceivedEvents), Is.True, $"{ partitionId }: there should have been a set of events received.");
                        Assert.That(partitionReceivedEvents.Count, Is.EqualTo(expectedEvents[partitionId].Count), $"{ partitionId }: amount of received events should match.");

                        var index = 0;

                        foreach (var receivedEvent in partitionReceivedEvents)
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
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task PartitionProcessorProcessEventsAsyncIsCalledWithNoEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var receivedEventSets = new ConcurrentBag<IEnumerable<EventData>>();

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onProcessEvents: (partitionContext, events, cancellationToken) =>
                                receivedEventSets.Add(events)
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await hub.WaitStabilization();

                    // Stop the event processors.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(receivedEventSets, Is.Not.Empty);
                    Assert.That(receivedEventSets.Any(set => (set == null || set.Any())), Is.False);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncDoesNothingWhenEventProcessorIsRunning()
        {
            var partitions = 1;

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    int initializeCallsCount = 0;

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onInitialize: partitionContext =>
                                Interlocked.Increment(ref initializeCallsCount)
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await hub.WaitStabilization();

                    // We should be able to call StartAsync again without getting an exception.

                    Assert.That(async () => await hub.StartAllAsync(), Throws.Nothing);

                    // Give the event processors more time in case they try to initialize again, which shouldn't happen.

                    await hub.WaitStabilization();

                    // Stop the event processors.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(initializeCallsCount, Is.EqualTo(partitions));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task StopAsyncDoesNothingWhenEventProcessorIsNotRunning()
        {
            var partitions = 1;

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    int closeCallsCount = 0;

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onClose: (partitionContext, reason) =>
                                Interlocked.Increment(ref closeCallsCount)
                        );

                    hub.AddEventProcessors(1);

                    // Calling StopAsync before starting the event processors shouldn't have any effect.

                    Assert.That(async () => await hub.StopAllAsync(), Throws.Nothing);

                    Assert.That(closeCallsCount, Is.EqualTo(0));

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await hub.WaitStabilization();

                    // Stop the event processors.

                    await hub.StopAllAsync();

                    // We should be able to call StopAsync again without getting an exception.

                    Assert.That(async () => await hub.StopAllAsync(), Throws.Nothing);

                    // Validate results.

                    Assert.That(closeCallsCount, Is.EqualTo(partitions));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Failing test: needs debugging")]
        public async Task EventProcessorCanStartAgainAfterStopping()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    int receivedEventsCount = 0;

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onProcessEvents: (partitionContext, events, cancellationToken) =>
                            {
                                // Make it a list so we can safely enumerate it.

                                var eventsList = new List<EventData>(events ?? Enumerable.Empty<EventData>());

                                if (eventsList.Count > 0)
                                {
                                    Interlocked.Add(ref receivedEventsCount, eventsList.Count);
                                }
                            }
                        );

                    hub.AddEventProcessors(1);

                    // Send some events.

                    var expectedEventsCount = 20;

                    await using (var producer = client.CreateProducer())
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

                        await hub.StartAllAsync();

                        // Make sure the event processors have enough time to stabilize and receive events.

                        await hub.WaitStabilization();

                        // Stop the event processors.

                        await hub.StopAllAsync();

                        // Validate results.

                        Assert.That(receivedEventsCount, Is.EqualTo(expectedEventsCount), $"Events should match in iteration { i + 1 }.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessorCanReceiveFromSpecifiedInitialEventPosition()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    int receivedEventsCount = 0;

                    // Send some events.

                    var expectedEventsCount = 20;
                    var dummyEvent = new EventData(Encoding.UTF8.GetBytes("I'm dummy."));
                    DateTimeOffset enqueuedTime;

                    await using (var producer = client.CreateProducer())
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

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            new EventProcessorOptions { InitialEventPosition = EventPosition.FromEnqueuedTime(enqueuedTime) },
                            onProcessEvents: (partitionContext, events, cancellationToken) =>
                            {
                                // Make it a list so we can safely enumerate it.

                                var eventsList = new List<EventData>(events ?? Enumerable.Empty<EventData>());

                                if (eventsList.Count > 0)
                                {
                                    Interlocked.Add(ref receivedEventsCount, eventsList.Count);
                                }
                            }
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize and receive events.

                    await hub.WaitStabilization();

                    // Stop the event processors.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(receivedEventsCount, Is.EqualTo(expectedEventsCount));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(15)]
        public async Task EventProcessorWaitsMaximumReceiveWaitTimeForEvents(int maximumWaitTimeInSecs)
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var timestamps = new ConcurrentDictionary<string, List<DateTimeOffset>>();

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            new EventProcessorOptions { MaximumReceiveWaitTime = TimeSpan.FromSeconds(maximumWaitTimeInSecs) },
                            onInitialize: partitionContext =>
                                timestamps.TryAdd(partitionContext.PartitionId, new List<DateTimeOffset> { DateTimeOffset.UtcNow }),
                            onProcessEvents: (partitionContext, events, cancellationToken) =>
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

                    hub.AddEventProcessors(1);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await hub.WaitStabilization();

                    // Stop the event processors.

                    await hub.StopAllAsync();

                    // Validate results.

                    foreach (var kvp in timestamps)
                    {
                        var partitionId = kvp.Key;
                        var partitionTimestamps = kvp.Value;

                        Assert.That(partitionTimestamps.Count, Is.GreaterThan(1), $"{ partitionId }: more timestamp samples were expected.");

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
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(50)]
        public async Task EventProcessorCannotReceiveMoreThanMaximumMessageCountMessagesAtATime(int maximumMessageCount)
        {
            var partitions = 2;

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var unexpectedMessageCount = -1;

                    // Send some events.

                    await using (var producer = client.CreateProducer())
                    {
                        var eventSet = Enumerable
                            .Range(0, 20 * maximumMessageCount)
                            .Select(index => new EventData(new byte[10]))
                            .ToList();

                        // Send one set per partition.

                        for (int i = 0; i < partitions; i++)
                        {
                            await producer.SendAsync(eventSet);
                        }
                    }

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            new EventProcessorOptions { MaximumMessageCount = maximumMessageCount },
                            onProcessEvents: (partitionContext, events, cancellationToken) =>
                            {
                                // Make it a list so we can safely enumerate it.

                                var eventsList = new List<EventData>(events ?? Enumerable.Empty<EventData>());

                                // In case we find a message count greater than the allowed amount, we only store the first
                                // occurrence and ignore the subsequent ones.

                                if (eventsList.Count > maximumMessageCount)
                                {
                                    Interlocked.CompareExchange(ref unexpectedMessageCount, eventsList.Count, -1);
                                }
                            }
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize and receive events.

                    await hub.WaitStabilization();

                    // Stop the event processors.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(unexpectedMessageCount, Is.EqualTo(-1), $"A set of { unexpectedMessageCount } events was received.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
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
        public async Task PartitionDistributionIsEvenAfterLoadBalancing(int partitions, int eventProcessors)
        {
            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    ConcurrentDictionary<string, int> ownedPartitionsCount = new ConcurrentDictionary<string, int>();

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onInitialize: partitionContext =>
                                ownedPartitionsCount.AddOrUpdate(partitionContext.OwnerIdentifier, 1, (ownerId, value) => value + 1),
                            onClose: (partitionContext, reason) =>
                                ownedPartitionsCount.AddOrUpdate(partitionContext.OwnerIdentifier, 0, (ownerId, value) => value - 1)
                        );

                    hub.AddEventProcessors(eventProcessors);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await hub.WaitStabilization();

                    // Take a snapshot of the current partition balancing status.

                    var ownedPartitionsCountSnapshot = ownedPartitionsCount.ToArray().Select(kvp => kvp.Value);

                    // Stop the event processors.

                    await hub.StopAllAsync();

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
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LoadBalancingIsEnforcedWhenDistributionIsUneven()
        {
            var partitions = 10;

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    ConcurrentDictionary<string, int> ownedPartitionsCount = new ConcurrentDictionary<string, int>();

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorManager
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onInitialize: partitionContext =>
                                ownedPartitionsCount.AddOrUpdate(partitionContext.OwnerIdentifier, 1, (ownerId, value) => value + 1),
                            onClose: (partitionContext, reason) =>
                                ownedPartitionsCount.AddOrUpdate(partitionContext.OwnerIdentifier, 0, (ownerId, value) => value - 1)
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await hub.WaitStabilization();

                    // Assert all partitions have been claimed.

                    Assert.That(ownedPartitionsCount.ToArray().Single().Value, Is.EqualTo(partitions));

                    // Insert a new event processor into the hub so it can start stealing partitions.

                    hub.AddEventProcessors(1);

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to stabilize.

                    await hub.WaitStabilization();

                    // Take a snapshot of the current partition balancing status.

                    var ownedPartitionsCountSnapshot = ownedPartitionsCount.ToArray().Select(kvp => kvp.Value);

                    // Stop the event processors.

                    await hub.StopAllAsync();

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
