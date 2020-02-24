// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Tests;
using Azure.Messaging.EventHubs.Producer;
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

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Unstable test. (Tracked by: #7458)")]
        public async Task PartitionProcessorCanCreateACheckpoint()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    // Send some events.

                    EventData lastEvent;

                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                    {
                        // Send a few events.  We are only interested in the last one of them.

                        var dummyEventsCount = 10;

                        using (var dummyBatch = await producer.CreateBatchAsync())
                        {

                            for (int i = 0; i < dummyEventsCount; i++)
                            {
                                dummyBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("I'm dummy.")));
                            }

                            await producer.SendAsync(dummyBatch);
                        }

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < dummyEventsCount) && (++index < ReceiveRetryLimit))
                        {
                            Assert.Fail("Convert to iterator.");
                            //receivedEvents.AddRange(await receiver.ReceiveAsync(dummyEventsCount + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(dummyEventsCount));

                        lastEvent = receivedEvents.Last();
                    }

                    // Create a storage manager so we can retrieve the created checkpoint from it.

                    var storageManager = new MockCheckPointStorage();

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connectionString,
                            storageManager,
                            onProcessEvent: eventArgs =>
                            {
                                if (eventArgs.Data != null)
                                {
                                    eventArgs.UpdateCheckpointAsync();
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

                    IEnumerable<PartitionOwnership> ownershipEnumerable = await storageManager.ListOwnershipAsync(connection.FullyQualifiedNamespace, connection.EventHubName, EventHubConsumerClient.DefaultConsumerGroupName);

                    Assert.That(ownershipEnumerable, Is.Not.Null);
                    Assert.That(ownershipEnumerable.Count, Is.EqualTo(1));
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
                    DateTimeOffset enqueuedTime;

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        // Send a few dummy events.  We are not expecting to receive these.

                        using (var dummyBatch = await producer.CreateBatchAsync())
                        {
                            for (int i = 0; i < 30; i++)
                            {
                                dummyBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("I'm dummy.")));
                            }

                            await producer.SendAsync(dummyBatch);
                        }

                        // Wait a reasonable amount of time so the events are able to reach the service.

                        await Task.Delay(1000);

                        // Send the events we expect to receive.

                        enqueuedTime = DateTimeOffset.UtcNow;

                        using (var dummyBatch = await producer.CreateBatchAsync())
                        {
                            for (int i = 0; i < expectedEventsCount; i++)
                            {
                                dummyBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("I'm dummy.")));
                            }

                            await producer.SendAsync(dummyBatch);
                        }
                    }

                    // Create the event processor manager to manage our event processors.

                    var eventProcessorManager = new EventProcessorManager
                        (
                            EventHubConsumerClient.DefaultConsumerGroupName,
                            connectionString,
                            onInitialize: eventArgs =>
                                eventArgs.DefaultStartingPosition = EventPosition.FromEnqueuedTime(enqueuedTime),
                            onProcessEvent: eventArgs =>
                            {
                                if (eventArgs.Data != null)
                                {
                                    Interlocked.Increment(ref receivedEventsCount);
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
        public async Task EventProcessorWaitsMaximumWaitTimeForEvents(int maximumWaitTimeInSecs)
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
                            connectionString,
                            clientOptions: new EventProcessorClientOptions { MaximumWaitTime = TimeSpan.FromSeconds(maximumWaitTimeInSecs) },
                            onInitialize: eventArgs =>
                                timestamps.TryAdd(eventArgs.PartitionId, new List<DateTimeOffset> { DateTimeOffset.UtcNow }),
                            onProcessEvent: eventArgs =>
                                timestamps.AddOrUpdate
                                    (
                                        // The key already exists, so the 'addValue' factory will never be called.

                                        eventArgs.Partition.PartitionId,
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
                            connectionString
                        // TODO: fix test. OwnerIdentifier is not accessible anymore.
                        // onInitialize: eventArgs =>
                        //     ownedPartitionsCount.AddOrUpdate(eventArgs.Context.OwnerIdentifier, 1, (ownerId, value) => value + 1),
                        // onStop: eventArgs =>
                        //     ownedPartitionsCount.AddOrUpdate(eventArgs.Context.OwnerIdentifier, 0, (ownerId, value) => value - 1)
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
                            connectionString
                        // TODO: fix test. OwnerIdentifier is not accessible anymore.
                        // onInitialize: eventArgs =>
                        //     ownedPartitionsCount.AddOrUpdate(eventArgs.Context.OwnerIdentifier, 1, (ownerId, value) => value + 1),
                        // onStop: eventArgs =>
                        //     ownedPartitionsCount.AddOrUpdate(eventArgs.Context.OwnerIdentifier, 0, (ownerId, value) => value - 1)
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

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Test failing during nightly runs. (Tracked by: #10067)")]
        public async Task ProcessorDoesNotProcessCheckpointedEventsAgain()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var firstEventBatch = Enumerable
                    .Range(0, 20)
                    .Select(index => new EventData(Encoding.UTF8.GetBytes($"First event batch: { index }")))
                    .ToList();

                var secondEventBatch = Enumerable
                    .Range(0, 10)
                    .Select(index => new EventData(Encoding.UTF8.GetBytes($"Second event batch: { index }")))
                    .ToList();

                var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var firstBatchReceivedEventsCount = 0;

                // Send the first batch of events and checkpoint after the last one.

                var checkpointStorage = new MockCheckPointStorage();
                var firstProcessor = new EventProcessorClient(checkpointStorage, EventHubConsumerClient.DefaultConsumerGroupName,
                    TestEnvironment.FullyQualifiedNamespace, scope.EventHubName, () => new EventHubConnection(connectionString), default);

                firstProcessor.ProcessEventAsync += async eventArgs =>
                {
                    if (++firstBatchReceivedEventsCount == firstEventBatch.Count)
                    {
                        await eventArgs.UpdateCheckpointAsync();
                        completionSource.SetResult(true);
                    }
                };

                firstProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    using var batch = await producer.CreateBatchAsync();

                    foreach (var eventData in firstEventBatch)
                    {
                        batch.TryAdd(eventData);
                    }

                    await producer.SendAsync(batch);
                }

                // Establish timed cancellation to ensure that the test doesn't hang.

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                await firstProcessor.StartProcessingAsync(cancellationSource.Token);

                while (!completionSource.Task.IsCompleted
                    && !cancellationSource.IsCancellationRequested)
                {
                    await Task.Delay(25);
                }

                await firstProcessor.StopProcessingAsync(cancellationSource.Token);

                // Send the second batch of events. Only the new events should be read by the second processor.

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    using var batch = await producer.CreateBatchAsync();

                    foreach (var eventData in secondEventBatch)
                    {
                        batch.TryAdd(eventData);
                    }

                    await producer.SendAsync(batch);
                }

                completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var secondBatchReceivedEvents = new List<EventData>();

                var secondProcessor = new EventProcessorClient(checkpointStorage, EventHubConsumerClient.DefaultConsumerGroupName,
                    TestEnvironment.FullyQualifiedNamespace, scope.EventHubName, () => new EventHubConnection(connectionString), default);

                secondProcessor.ProcessEventAsync += eventArgs =>
                {
                    secondBatchReceivedEvents.Add(eventArgs.Data);

                    if (secondBatchReceivedEvents.Count == firstEventBatch.Count)
                    {
                        completionSource.SetResult(true);
                    }

                    return Task.CompletedTask;
                };

                var wasErrorHandlerCalled = false;

                secondProcessor.ProcessErrorAsync += eventArgs =>
                {
                    wasErrorHandlerCalled = true;
                    return Task.CompletedTask;
                };

                await secondProcessor.StartProcessingAsync(cancellationSource.Token);

                while (!completionSource.Task.IsCompleted
                    && !cancellationSource.IsCancellationRequested)
                {
                    await Task.Delay(25);
                }

                await secondProcessor.StopProcessingAsync(cancellationSource.Token);

                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processors should have stopped without cancellation.");
                Assert.That(wasErrorHandlerCalled, Is.False, "No errors should have happened while resuming from checkpoint.");

                var index = 0;

                foreach (var eventData in secondBatchReceivedEvents)
                {
                    Assert.That(eventData.IsEquivalentTo(secondEventBatch[index]), Is.True, "The received and sent event datas do not match.");
                    index++;
                }

                Assert.That(index, Is.EqualTo(secondEventBatch.Count), $"The second processor did not receive the expected amount of events.");
            }
        }
    }
}
