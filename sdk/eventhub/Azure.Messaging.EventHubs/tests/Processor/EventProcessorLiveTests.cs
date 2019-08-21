// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            await using (var scope = await EventHubScope.CreateAsync(10))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    ConcurrentDictionary<string, int> initializeCalls = new ConcurrentDictionary<string, int>();

                    // Create the event processor hub to manage our event processor.

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onInitialize: (partitionContext, checkpointManager) =>
                                initializeCalls.AddOrUpdate(partitionContext.PartitionId, 1, (partitionId, value) => value + 1)
                        );

                    hub.AddEventProcessors(1);

                    // InitializeAsync should have not been called when constructing the event processor.

                    Assert.That(initializeCalls.Keys, Is.Empty);

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Make sure the event processor has enough time to claim partitions.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // Validate results.

                    var partitionIds = await client.GetPartitionIdsAsync();

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(initializeCalls.TryGetValue(partitionId, out var calls), Is.True);
                        Assert.That(calls, Is.EqualTo(1));
                    }

                    Assert.That(initializeCalls.Keys.Count, Is.EqualTo(partitionIds.Count()));

                    // Stop the event processor.

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
            await using (var scope = await EventHubScope.CreateAsync(10))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    ConcurrentDictionary<string, int> closeCalls = new ConcurrentDictionary<string, int>();
                    ConcurrentDictionary<string, PartitionProcessorCloseReason> closeReasons = new ConcurrentDictionary<string, PartitionProcessorCloseReason>();

                    // Create the event processor hub to manage our event processor.

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onClose: (partitionContext, checkpointManager, reason) =>
                                {
                                    closeCalls.AddOrUpdate(partitionContext.PartitionId, 1, (partitionId, value) => value + 1);
                                    closeReasons[partitionContext.PartitionId] = reason;
                                }
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Make sure the event processor has enough time to claim partitions.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // CloseAsync should have not been called when constructing the event processor or initializing the partition processor.

                    Assert.That(closeCalls.Keys, Is.Empty);

                    // Stop the event processor.

                    await hub.StopAllAsync();

                    // Validate results.

                    var partitionIds = await client.GetPartitionIdsAsync();

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(closeCalls.TryGetValue(partitionId, out var calls), Is.True);
                        Assert.That(calls, Is.EqualTo(1));

                        Assert.That(closeReasons.TryGetValue(partitionId, out var reason), Is.True);
                        Assert.That(reason, Is.EqualTo(PartitionProcessorCloseReason.Shutdown));
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
            await using (var scope = await EventHubScope.CreateAsync(10))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    ConcurrentDictionary<string, List<EventData>> allReceivedEvents = new ConcurrentDictionary<string, List<EventData>>();

                    // Create the event processor hub to manage our event processor.

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onProcessEvents: (partitionContext, checkpointManager, events, cancellationToken) =>
                            {
                                if (events.Count() > 0)
                                {
                                    allReceivedEvents.AddOrUpdate
                                    (
                                        partitionContext.PartitionId,
                                        partitionId => new List<EventData>(events),
                                        (partitionId, list) =>
                                        {
                                            list.AddRange(events);
                                            return list;
                                        }
                                    );
                                }
                            }
                        );

                    hub.AddEventProcessors(1);

                    // Send some events to be received by the event processor.

                    var partitionIds = await client.GetPartitionIdsAsync();
                    var expectedEvents = new Dictionary<string, List<EventData>>();

                    foreach (var partitionId in partitionIds)
                    {
                        // We'll send a similar set of events for every partition.

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

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Make sure the event processor has enough time to claim partitions and receive events.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(5000);

                    // Stop the event processor.

                    await hub.StopAllAsync();

                    // Validate results.  We are making sure we received every event in the correct partition processor, 
                    // in the order they were sent.

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(allReceivedEvents.TryGetValue(partitionId, out var partitionReceivedEvents), Is.True);

                        var index = 0;

                        foreach (var receivedEvent in partitionReceivedEvents)
                        {
                            Assert.That(receivedEvent.IsEquivalentTo(expectedEvents[partitionId][index]), Is.True);
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
        public async Task PartitionProcessorProcessEventsAsyncIsCalledWithNoEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(10))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    // TODO: better naming.
                    ConcurrentDictionary<string, byte> wasProcessEventsCalled = new ConcurrentDictionary<string, byte>();
                    ConcurrentDictionary<string, byte> wasProcessEventsCalledWithNullOrNonEmptyCollection = new ConcurrentDictionary<string, byte>();

                    // Create the event processor hub to manage our event processor.

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onProcessEvents: (partitionContext, checkpointManager, events, cancellationToken) =>
                            {
                                wasProcessEventsCalled.TryAdd(partitionContext.PartitionId, 0);

                                if (events == null || events.Count() != 0)
                                {
                                    wasProcessEventsCalledWithNullOrNonEmptyCollection.TryAdd(partitionContext.PartitionId, 0);
                                }
                            }
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Make sure the event processor has enough time to claim partitions.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // Stop the event processor.

                    await hub.StopAllAsync();

                    // Validate results.

                    var partitionIds = await client.GetPartitionIdsAsync();

                    foreach (var partitionId in partitionIds)
                    {
                        Assert.That(wasProcessEventsCalled.ContainsKey(partitionId), Is.True);
                        Assert.That(wasProcessEventsCalledWithNullOrNonEmptyCollection.ContainsKey(partitionId), Is.False);
                    }

                    Assert.That(wasProcessEventsCalled.Count, Is.EqualTo(partitionIds.Count()));
                    Assert.That(wasProcessEventsCalledWithNullOrNonEmptyCollection.Count, Is.EqualTo(0));
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
            var partitions = 10;

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    int initializeCallsCount = 0;

                    // Create the event processor hub to manage our event processor.

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onInitialize: (partitionContext, checkpointManager) => Interlocked.Increment(ref initializeCallsCount)
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Make sure the event processor has enough time to claim partitions.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // We should be able to call StartAsync again without getting an exception.

                    Assert.That(async () => await hub.StartAllAsync(), Throws.Nothing);

                    // Give the event processor more time in case it tries to initialize again, which shouldn't happen.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // Stop the event processor.

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
            var partitions = 10;

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    int closeCallsCount = 0;

                    // Create the event processor hub to manage our event processor.

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onClose: (partitionContext, checkpointManager, reason) => Interlocked.Increment(ref closeCallsCount)
                        );

                    hub.AddEventProcessors(1);

                    // Calling StopAsync before starting the event processor shouldn't have any effect.

                    Assert.That(async () => await hub.StopAllAsync(), Throws.Nothing);

                    // Give the event processor some time in case it tries to do something, which shouldn't happen.
                    // TODO: regulate delay with options.

                    await Task.Delay(500);

                    Assert.That(closeCallsCount, Is.EqualTo(0));

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Make sure the event processor has enough time to claim partitions.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // Stop the event processor.

                    await hub.StopAllAsync();

                    // We should be able to call StartAsync again without getting an exception.

                    Assert.That(async () => await hub.StopAllAsync(), Throws.Nothing);

                    // Give the event processor some time in case it tries to do something, which shouldn't happen.
                    // TODO: regulate delay with options.

                    await Task.Delay(500);

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
        public async Task EventProcessorCanStartAgainAfterStopping()
        {
            await using (var scope = await EventHubScope.CreateAsync(10))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    int receivedEventsCount = 0;

                    // Create the event processor hub to manage our event processor.

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onProcessEvents: (partitionContext, checkpointManager, events, cancellationToken) =>
                            {
                                if (events.Count() > 0)
                                {
                                    Interlocked.Add(ref receivedEventsCount, events.Count());
                                }
                            }
                        );

                    hub.AddEventProcessors(1);

                    // Send some events to be received by the event processor.

                    var expectedEventsCount = 20;

                    await using (var producer = client.CreateProducer())
                    {
                        var dummyEvent = new EventData(Encoding.UTF8.GetBytes("I'm dummy."));

                        for (int i = 0; i < expectedEventsCount; i++)
                        {
                            await producer.SendAsync(dummyEvent);
                        }
                    }

                    // We'll start and stop the event processor twice.  This way, we can assert it will behave
                    // the same behavior in both runs, reprocessing all events in the second one.

                    for (int i = 0; i < 2; i++)
                    {
                        receivedEventsCount = 0;

                        // Start the event processor.

                        await hub.StartAllAsync();

                        // Make sure the event processor has enough time to claim partitions and receive events.
                        // TODO: we'll probably need to extend this delay once load balancing is implemented.

                        await Task.Delay(500);

                        // Stop the event processor.

                        await hub.StopAllAsync();

                        // Validate results.

                        Assert.That(receivedEventsCount, Is.EqualTo(expectedEventsCount));
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
        [Ignore("Current implementation does not catch ProcessEventsAsync exceptions")]
        public async Task PartitionProcessorProcessErrorAsyncIsCalledWhenProcessEventsAsyncThrows()
        {
            await using (var scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var poisonedPartition = (await client.GetPartitionIdsAsync()).First();
                    var expectedException = new Exception("I'm so unexpected.");
                    ConcurrentDictionary<string, Exception> thrownExceptions = new ConcurrentDictionary<string, Exception>();

                    // Create the event processor hub to manage our event processor.

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onProcessEvents: (partitionContext, checkpointManager, events, cancellationToken) =>
                            {
                                if (partitionContext.PartitionId == poisonedPartition)
                                {
                                    throw expectedException;
                                }
                            },
                            onProcessError: (partitionContext, checkpointManager, exception, cancellationToken) =>
                            {
                                thrownExceptions.TryAdd(partitionContext.PartitionId, exception);
                            }
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Make sure the event processor has enough time to claim partitions.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // Stop the event processor.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(thrownExceptions.Count, Is.EqualTo(1));
                    Assert.That(thrownExceptions.TryGetValue(poisonedPartition, out var thrownException), Is.True);
                    Assert.That(thrownException, Is.EqualTo(expectedException));
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
        [Ignore("Load balancing not supported yet")]
        public async Task PartitionDistributionIsEvenAfterLoadBalancing(int partitions, int eventProcessors)
        {
            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    ConcurrentDictionary<string, int> ownedPartitionsCount = new ConcurrentDictionary<string, int>();

                    // Create the event processor hub to manage our event processors.

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onInitialize: (partitionContext, checkpointManager) =>
                                ownedPartitionsCount.AddOrUpdate(checkpointManager.OwnerIdentifier, 1, (ownerId, value) => value + 1),
                            onClose: (partitionContext, checkpointManager, reason) =>
                                ownedPartitionsCount.AddOrUpdate(checkpointManager.OwnerIdentifier, 0, (ownerId, value) => value - 1)
                        );

                    hub.AddEventProcessors(eventProcessors);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Make sure the event processors have enough time to claim partitions.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // Take a snapshot of the current partition balancing status so it won't change when closing the event processors.

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
        [Ignore("Load balancing not supported yet")]
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

                    var hub = new EventProcessorHub
                        (
                            EventHubConsumer.DefaultConsumerGroupName,
                            client,
                            onInitialize: (partitionContext, checkpointManager) =>
                                ownedPartitionsCount.AddOrUpdate(checkpointManager.OwnerIdentifier, 1, (ownerId, value) => value + 1),
                            onClose: (partitionContext, checkpointManager, reason) =>
                                ownedPartitionsCount.AddOrUpdate(checkpointManager.OwnerIdentifier, 0, (ownerId, value) => value - 1)
                        );

                    hub.AddEventProcessors(1);

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Make sure the event processor has enough time to claim partitions.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // Assert all partitions have been claimed.

                    Assert.That(ownedPartitionsCount.ToArray().Single().Value, Is.EqualTo(partitions));

                    // Insert a new event processor into the hub so it can start stealing partitions.

                    hub.AddEventProcessors(1);

                    await hub.StartAllAsync();

                    // Make sure the new event processor has enough time to steal partitions.
                    // TODO: we'll probably need to extend this delay once load balancing is implemented.

                    await Task.Delay(500);

                    // Take a snapshot of the current partition balancing status so it won't change when closing the event processors.

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
