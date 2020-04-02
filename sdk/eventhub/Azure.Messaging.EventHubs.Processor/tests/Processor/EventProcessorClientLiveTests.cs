// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor.Tests;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;
using Moq;
using Moq.Protected;
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
        /// <summary>The name of the custom event property which holds a test-specific artificial sequence number.</summary>
        private static readonly string CustomIdProperty = $"{ nameof(EventProcessorClientLiveTests) }::Identifier";

        /// <summary>The name of the custom event property which holds a test-specific artificial sequence number.</summary>
        private static readonly string CustomSequenceProperty = $"{ nameof(EventProcessorClientLiveTests) }::Sequence";

        /// <summary>A generator for random values used within the tests.</summary>
        private readonly Random RandomGenerator = new Random();

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> can read a set of published events.
        /// </summary>
        ///
        [Test]
        public async Task EventsCanBeReadByOneProcessorClient()
        {
            // Setup the environment.

            await using EventHubScope scope = await EventHubScope.CreateAsync(2);
            var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

            // Test the scenario.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(2));

            var sentCount = 0;
            var processCount = 0L;
            var sourceEvents = CreateEvents(50).ToList();
            var processedEvents = new Dictionary<string, EventData>();

            // Send a set of events.

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var batch in (await BuildBatchesAsync(sourceEvents, producer, cancellationSource.Token)))
                {
                    await producer.SendAsync(batch, cancellationSource.Token);

                    sentCount += batch.Count;
                    batch.Dispose();
                }
            }

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the events.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250) };
            var processor = CreateProcessor(scope.ConsumerGroups.First(), connectionString, options: options);

            processor.ProcessErrorAsync += args =>
            {
                Assert.Fail($"Processor Error Surfaced: ({ args.Exception.GetType().Name })[{ args.Exception.Message }]");
                return Task.CompletedTask;
            };

            processor.ProcessEventAsync += args =>
            {
                if (args.HasEvent)
                {
                    var eventId = args.Data.Properties[CustomIdProperty].ToString();

                    // Guard against duplicates; Event Hubs has an at-least-once guarantee.

                    if ((TryAdd(processedEvents, eventId, args.Data)) && (Interlocked.Increment(ref processCount) >= sentCount))
                    {
                        completionSource.TrySetResult(true);
                    }
                }

                return Task.CompletedTask;
            };

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            // Validate the events that were processed.

            foreach (var sourceEvent in sourceEvents)
            {
                var sourceId = sourceEvent.Properties[CustomIdProperty].ToString();

                if (!processedEvents.TryGetValue(sourceId, out var processedEvent))
                {
                    Assert.Fail($"The event with custom identifier [{ sourceId }] was not processed.");
                }

                Assert.That(sourceEvent.IsEquivalentTo(processedEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> can read a set of published events.
        /// </summary>
        ///
        [Test]
        public async Task EventsCanBeReadByOneProcessorClientUsingAnIdentityCredential()
        {
            // Setup the environment.

            await using EventHubScope scope = await EventHubScope.CreateAsync(2);
            var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

            // Test the scenario.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(2));

            var sentCount = 0;
            var processCount = 0L;
            var sourceEvents = CreateEvents(50).ToList();
            var processedEvents = new Dictionary<string, EventData>();

            // Send a set of events.

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var batch in (await BuildBatchesAsync(sourceEvents, producer, cancellationSource.Token)))
                {
                    await producer.SendAsync(batch, cancellationSource.Token);

                    sentCount += batch.Count;
                    batch.Dispose();
                }
            }

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the events.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250) };
            var processor = CreateProcessorWithIdentity(scope.ConsumerGroups.First(), scope.EventHubName, options: options);

            processor.ProcessErrorAsync += args =>
            {
                Assert.Fail($"Processor Error Surfaced: ({ args.Exception.GetType().Name })[{ args.Exception.Message }]");
                return Task.CompletedTask;
            };

            processor.ProcessEventAsync += args =>
            {
                if (args.HasEvent)
                {
                    var eventId = args.Data.Properties[CustomIdProperty].ToString();

                    // Guard against duplicates; Event Hubs has an at-least-once guarantee.

                    if ((TryAdd(processedEvents, eventId, args.Data)) && (Interlocked.Increment(ref processCount) >= sentCount))
                    {
                        completionSource.TrySetResult(true);
                    }
                }

                return Task.CompletedTask;
            };

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, $"The cancellation token should not have been signaled.  { processedEvents.Count } events were processed.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            // Validate the events that were processed.

            foreach (var sourceEvent in sourceEvents)
            {
                var sourceId = sourceEvent.Properties[CustomIdProperty].ToString();

                if (!processedEvents.TryGetValue(sourceId, out var processedEvent))
                {
                    Assert.Fail($"The event with custom identifier [{ sourceId }] was not processed.");
                }

                Assert.That(sourceEvent.IsEquivalentTo(processedEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> can read a set of published events.
        /// </summary>
        ///
        [Test]
        public async Task EventsCanBeReadByMultipleProcessorClients()
        {
            // Setup the environment.

            await using EventHubScope scope = await EventHubScope.CreateAsync(4);
            var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

            // Test the scenario.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(3));

            var sentCount = 0;
            var processCount = 0L;
            var sourceEvents = CreateEvents(500).ToList();
            var processedEvents = new ConcurrentDictionary<string, EventData>();


            // Send a set of events.

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var batch in (await BuildBatchesAsync(sourceEvents, producer, cancellationSource.Token)))
                {
                    await producer.SendAsync(batch, cancellationSource.Token);

                    sentCount += batch.Count;
                    batch.Dispose();
                }
            }

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the events.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            // Create multiple processors using the same handlers; events may not appear in the same order, but each event
            // should be read once.

            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(500) };

            var processors = new[]
            {
                CreateProcessor(scope.ConsumerGroups.First(), connectionString, options: options),
                CreateProcessor(scope.ConsumerGroups.First(), connectionString, options: options)
            };

            foreach (var processor in processors)
            {
                processor.ProcessErrorAsync += args =>
                {
                    Assert.Fail($"Processor Error Surfaced: ({ args.Exception.GetType().Name })[{ args.Exception.Message }]");
                    return Task.CompletedTask;
                };

                processor.ProcessEventAsync += args =>
                {
                    if (args.HasEvent)
                    {
                        var eventId = args.Data.Properties[CustomIdProperty].ToString();

                        // Guard against duplicates; Event Hubs has an at-least-once guarantee.

                        if ((processedEvents.TryAdd(eventId, args.Data)) && (Interlocked.Increment(ref processCount) >= sentCount))
                        {
                            completionSource.TrySetResult(true);
                        }
                    }

                    return Task.CompletedTask;
                };
            }

            await Task.WhenAll(processors.Select(processor => processor.StartProcessingAsync(cancellationSource.Token)));

            // Allow the processors to complete, while respecting the test timeout.

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, $"The cancellation token should not have been signaled.  { processedEvents.Count } events were processed.");

            await Task.WhenAll(processors.Select(processor => processor.StopProcessingAsync(cancellationSource.Token)));
            cancellationSource.Cancel();

            // Validate the events that were processed.

            foreach (var sourceEvent in sourceEvents)
            {
                var sourceId = sourceEvent.Properties[CustomIdProperty].ToString();

                if (!processedEvents.TryGetValue(sourceId, out var processedEvent))
                {
                    Assert.Fail($"The event with custom identifier [{ sourceId }] was not processed.");
                }

                Assert.That(sourceEvent.IsEquivalentTo(processedEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> can read a set of published events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorClientCreatesOwnership()
        {
            // Setup the environment.

            var partitionCount = 2;
            var partitionIds = new HashSet<string>();

            await using EventHubScope scope = await EventHubScope.CreateAsync(partitionCount);
            var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

            // Test the scenario.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(2));

            var sentCount = 0;
            var processCount = 0L;
            var sourceEvents = CreateEvents(200).ToList();
            var processedEvents = new HashSet<string>();

            // Send a set of events.

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var partition in (await producer.GetPartitionIdsAsync(cancellationSource.Token)))
                {
                    partitionIds.Add(partition);
                }

                foreach (var batch in (await BuildBatchesAsync(sourceEvents, producer, cancellationSource.Token)))
                {
                    await producer.SendAsync(batch, cancellationSource.Token);

                    sentCount += batch.Count;
                    batch.Dispose();
                }
            }

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the events.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var storageManager = new InMemoryStorageManager(_ => {});
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250) };
            var processor = CreateProcessorWithIdentity(scope.ConsumerGroups.First(), scope.EventHubName, storageManager, options);

            processor.ProcessErrorAsync += args =>
            {
                Assert.Fail($"Processor Error Surfaced: ({ args.Exception.GetType().Name })[{ args.Exception.Message }]");
                return Task.CompletedTask;
            };

            processor.ProcessEventAsync += args =>
            {
                if (args.HasEvent)
                {
                    var eventId = args.Data.Properties[CustomIdProperty].ToString();

                    // Guard against duplicates; Event Hubs has an at-least-once guarantee.

                    if ((!processedEvents.Contains(eventId)) && (Interlocked.Increment(ref processCount) >= sentCount))
                    {
                        completionSource.TrySetResult(true);
                    }
                }

                return Task.CompletedTask;
            };

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, $"The cancellation token should not have been signaled.  { processedEvents.Count } events were processed.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            // Validate that events that were processed.

            var ownership = (await storageManager.ListOwnershipAsync(TestEnvironment.FullyQualifiedNamespace, scope.EventHubName, scope.ConsumerGroups.First(), cancellationSource.Token))?.ToList();

            Assert.That(ownership, Is.Not.Null, "The ownership list should have been returned.");
            Assert.That(ownership.Count, Is.AtLeast(1), "At least one partition should have been owned.");

            foreach (var partitionOwnership in ownership)
            {
                Assert.That(partitionIds.Contains(partitionOwnership.PartitionId), Is.True, $"The partition `{ partitionOwnership.PartitionId }` is not valid for the Event Hub.");
                Assert.That(partitionOwnership.OwnerIdentifier, Is.Empty, "Ownership should have bee relinquished when the processor was stopped.");
            }

        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> can read a set of published events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorClientCanStartFromAnInitialPosition()
        {
            // Setup the environment.

            await using EventHubScope scope = await EventHubScope.CreateAsync(1);
            var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

            // Test the scenario.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(3));

            var sentCount = 0;
            var sourceEvents = CreateEvents(20).ToList();
            var lastSourceEvent = sourceEvents.Last();

            // Send an initial set of events to populate the partition.

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var batch in (await BuildBatchesAsync(sourceEvents, producer, cancellationSource.Token)))
                {
                    await producer.SendAsync(batch, cancellationSource.Token);

                    sentCount += batch.Count;
                    batch.Dispose();
                }
            }

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Read the initial set back, marking the offset and sequence number of the last event in the initial set.

            var startingCustomSequence = 0;
            var startingOffset = 0L;

            await using (var consumer = new EventHubConsumerClient(scope.ConsumerGroups.First(), connectionString))
            {
                await foreach  (var partitionEvent in consumer.ReadEventsAsync(new ReadEventOptions { MaximumWaitTime = null }, cancellationSource.Token))
                {
                    if (partitionEvent.Data.IsEquivalentTo(lastSourceEvent))
                    {
                        startingCustomSequence = int.Parse(partitionEvent.Data.Properties[CustomSequenceProperty].ToString());
                        startingOffset = partitionEvent.Data.Offset;

                        break;
                    }
                }
            }

            // Send the second set of events to be read by the processor.

            sentCount = 0;
            sourceEvents = CreateEvents(20, (startingCustomSequence + 1)).ToList();

            // Send an initial set of events to populate the partition.

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var batch in (await BuildBatchesAsync(sourceEvents, producer, cancellationSource.Token)))
                {
                    await producer.SendAsync(batch, cancellationSource.Token);

                    sentCount += batch.Count;
                    batch.Dispose();
                }
            }

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the second set of events.

            var processCount = 0L;
            var processedEvents = new Dictionary<string, EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250) };
            var processor = CreateProcessor(scope.ConsumerGroups.First(), connectionString, options: options);

            processor.PartitionInitializingAsync += args =>
            {
                args.DefaultStartingPosition = EventPosition.FromOffset(startingOffset, false);
                return Task.CompletedTask;
            };

            processor.ProcessErrorAsync += args =>
            {
                Assert.Fail($"Processor Error Surfaced: ({ args.Exception.GetType().Name })[{ args.Exception.Message }]");
                return Task.CompletedTask;
            };

            processor.ProcessEventAsync += args =>
            {
                if (args.HasEvent)
                {
                    var eventId = args.Data.Properties[CustomIdProperty].ToString();

                    // Guard against duplicates; Event Hubs has an at-least-once guarantee.

                    if ((TryAdd(processedEvents, eventId, args.Data)) && (Interlocked.Increment(ref processCount) >= sentCount))
                    {
                        completionSource.TrySetResult(true);
                    }
                }

                return Task.CompletedTask;
            };

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            // Validate the events that were processed.

            foreach (var sourceEvent in sourceEvents)
            {
                var sourceId = sourceEvent.Properties[CustomIdProperty].ToString();

                if (!processedEvents.TryGetValue(sourceId, out var processedEvent))
                {
                    Assert.Fail($"The event with custom identifier [{ sourceId }] was not processed.");
                }

                Assert.That(sourceEvent.IsEquivalentTo(processedEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> can read a set of published events.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorClientBeginsWithTheNextEventAfterCheckpointing()
        {
            // Setup the environment.

            await using EventHubScope scope = await EventHubScope.CreateAsync(1);
            var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

            // Test the scenario.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromMinutes(3));

            var sentCount = 0;
            var segmentEventCount = 25;
            var beforeCheckpointEvents = CreateEvents(segmentEventCount).ToList();
            var afterCheckpointEvents = CreateEvents(segmentEventCount, segmentEventCount).ToList();
            var sourceEvents = Enumerable.Concat(beforeCheckpointEvents, afterCheckpointEvents).ToList();
            var checkpointEvent = beforeCheckpointEvents.Last();

            // Send the full set of events.

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var batch in (await BuildBatchesAsync(sourceEvents, producer, cancellationSource.Token)))
                {
                    await producer.SendAsync(batch, cancellationSource.Token);

                    sentCount += batch.Count;
                    batch.Dispose();
                }
            }

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the first half of the events and checkpoint.

            var processCount = 0L;
            var processedEvents = new Dictionary<string, EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250) };
            var storageManager = new InMemoryStorageManager(_ => {});
            var processor = CreateProcessor(scope.ConsumerGroups.First(), connectionString, storageManager, options);

            processor.ProcessErrorAsync += args =>
            {
                Assert.Fail($"Processor Error Surfaced: ({ args.Exception.GetType().Name })[{ args.Exception.Message }]");
                return Task.CompletedTask;
            };

            processor.ProcessEventAsync += async args =>
            {
                if (args.HasEvent)
                {
                    var eventId = args.Data.Properties[CustomIdProperty].ToString();

                    if (args.Data.IsEquivalentTo(checkpointEvent))
                    {
                        await args.UpdateCheckpointAsync(cancellationSource.Token);
                    }

                    // Guard against duplicates; Event Hubs has an at-least-once guarantee.

                    if ((TryAdd(processedEvents, eventId, args.Data)) && (Interlocked.Increment(ref processCount) >= segmentEventCount))
                    {
                        completionSource.TrySetResult(true);
                    }
                }
            };

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await processor.StopProcessingAsync(cancellationSource.Token);

            // Validate a checkpoint was created and that events were processed.

            var checkpoints = (await storageManager.ListCheckpointsAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup, cancellationSource.Token))?.ToList();
            Assert.That(checkpoints, Is.Not.Null, "A checkpoint should have been created.");
            Assert.That(checkpoints.Count, Is.EqualTo(1), "A single checkpoint should exist.");
            Assert.That(processCount, Is.AtLeast(beforeCheckpointEvents.Count), "All events before the checkpoint should have been processed.");

            // Reset state and start the processor again; it should resume from the event following the checkpoint.

            processedEvents.Clear();

            processCount = 0;
            completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            foreach (var sourceEvent in afterCheckpointEvents)
            {
                var sourceId = sourceEvent.Properties[CustomIdProperty].ToString();

                if (!processedEvents.TryGetValue(sourceId, out var processedEvent))
                {
                    Assert.Fail($"The event with custom identifier [{ sourceId }] was not processed.");
                }

                Assert.That(sourceEvent.IsEquivalentTo(processedEvent), $"The event with custom identifier [{ sourceId }] did not match the corresponding processed event.");
            }
        }

        /// <summary>
        ///   Creates an <see cref="EventProcessorClient" /> that uses mock storage and
        ///   a connection based on a connection string.
        /// </summary>
        ///
        /// <param name="consumerGroup">The consumer group for the processor.</param>
        /// <param name="connectionString">The connection to use for spawning connections.</param>
        /// <param name="storageManager">The storage manager to set for the processor; if <c>default</c>, a mock storage manager will be created.</param>
        /// <param name="options">The set of client options to pass.</param>
        ///
        /// <returns>The processor instance.</returns>
        ///
        private EventProcessorClient CreateProcessor(string consumerGroup,
                                                     string connectionString,
                                                     StorageManager storageManager = default,
                                                     EventProcessorOptions options = default)
        {
            EventHubConnection createConnection() => new EventHubConnection(connectionString);

            storageManager ??= new InMemoryStorageManager(_=> {});
            return new TestEventProcessorClient(storageManager, consumerGroup, "fakeNamespace", "fakeEventHub", Mock.Of<TokenCredential>(), createConnection, options);
        }

        /// <summary>
        ///   Creates an <see cref="EventProcessorClient" /> that uses mock storage and
        ///   a connection based on an identity credential.
        /// </summary>
        ///
        /// <param name="consumerGroup">The consumer group for the processor.</param>
        /// <param name="eventHubName">The name of the Event Hub for the processor.</param>
        /// <param name="storageManager">The storage manager to set for the processor; if <c>default</c>, a mock storage manager will be created.</param>
        /// <param name="options">The set of client options to pass.</param>
        ///
        /// <returns>The processor instance.</returns>
        ///
        private EventProcessorClient CreateProcessorWithIdentity(string consumerGroup,
                                                                 string eventHubName,
                                                                 StorageManager storageManager = default,
                                                                 EventProcessorOptions options = default)
        {
            var credential = new ClientSecretCredential(TestEnvironment.EventHubsTenant, TestEnvironment.EventHubsClient, TestEnvironment.EventHubsSecret);
            EventHubConnection createConnection() => new EventHubConnection(TestEnvironment.FullyQualifiedNamespace, eventHubName, credential);

            storageManager ??= new InMemoryStorageManager(_=> {});
            return new TestEventProcessorClient(storageManager, consumerGroup, TestEnvironment.FullyQualifiedNamespace, eventHubName, credential, createConnection, options);
        }

        /// <summary>
        ///   Creates a set of events with random data and random body size.
        /// </summary>
        ///
        /// <param name="numberOfEvents">The number of events to create.</param>
        /// <param name="startSequenceNumberingAt">The number to start the custom sequencing at.</param>
        ///
        /// <returns></returns>
        ///
        private IEnumerable<EventData> CreateEvents(int numberOfEvents,
                                                    int startSequenceNumberingAt = 0)
        {
            const int minimumBodySize = 3;
            const int maximumBodySize = 83886;

            EventData currentEvent;

            var currentSequence = startSequenceNumberingAt;

            for (var index = 0; index < numberOfEvents; ++index)
            {
                var buffer = new byte[RandomGenerator.Next(minimumBodySize, maximumBodySize)];
                RandomGenerator.NextBytes(buffer);

                currentEvent = new EventData(buffer);
                currentEvent.Properties.Add(CustomIdProperty, Guid.NewGuid().ToString());
                currentEvent.Properties.Add(CustomSequenceProperty, currentSequence);

                currentSequence++;
                yield return currentEvent;
            }
        }

        /// <summary>
        ///   Builds a set of batches from the provided events.
        /// </summary>
        ///
        /// <param name="events">The events to group into batches.</param>
        /// <param name="producer">The producer to use for creating batches.</param>
        /// <param name="batchEvents">A dictionary to which the events included in the batches should be tracked.</param>
        /// <param name="cancellationToken">The token used to signal a cancellation request.</param>
        ///
        /// <returns>The set of batches needed to contain the entire set of <paramref name="events"/>.</returns>
        ///
        /// <remarks>
        ///   Callers are assumed to be responsible for taking ownership of the lifespan of the returned batches, including
        ///   their disposal.
        ///
        ///   This method is intended for use within the test suite only; it is not hardened for general purpose use.
        /// </remarks>
        ///
        private async Task<IEnumerable<EventDataBatch>> BuildBatchesAsync(IEnumerable<EventData> events,
                                                                          EventHubProducerClient producer,
                                                                          CancellationToken cancellationToken)
        {
            EventData eventData;

            var queuedEvents = new Queue<EventData>(events);
            var batches = new List<EventDataBatch>();
            var currentBatch = default(EventDataBatch);

            while (queuedEvents.Count > 0)
            {
                currentBatch ??= (await producer.CreateBatchAsync(cancellationToken).ConfigureAwait(false));
                eventData = queuedEvents.Peek();

                if (!currentBatch.TryAdd(eventData))
                {
                    if (currentBatch.Count == 0)
                    {
                        throw new InvalidOperationException("There was an event too large to fit into a batch.");
                    }

                    batches.Add(currentBatch);
                    currentBatch = default;
                }
                else
                {
                   queuedEvents.Dequeue();
                }
            }

            if ((currentBatch != default) && (currentBatch.Count > 0))
            {
                batches.Add(currentBatch);
            }

            return batches;
        }

        /// <summary>
        ///   Attempts to add an item to the <paramref name="dictionary" /> if it does not
        ///   already exist.
        /// </summary>
        ///
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        ///
        /// <param name="dictionary">The dictionary to attempt to add the item to.</param>
        /// <param name="key">The key to assign the item.</param>
        /// <param name="value">The value of the item.</param>
        ///
        /// <returns><c>true</c> if the item was added; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryAdd<TKey, TValue>(Dictionary<TKey, TValue> dictionary,
                                                 TKey key,
                                                 TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                return false;
            }

            dictionary.Add(key, value);
            return true;
        }

        /// <summary>
        ///   A mock <see cref="EventProcessorClient" /> used for testing purposes to override
        ///   connection creation.
        /// </summary>
        ///
        public class TestEventProcessorClient : EventProcessorClient
        {
            private readonly Func<EventHubConnection> InjectedConnectionFactory;

            internal TestEventProcessorClient(StorageManager storageManager,
                                              string consumerGroup,
                                              string fullyQualifiedNamespace,
                                              string eventHubName,
                                              TokenCredential credential,
                                              Func<EventHubConnection> connectionFactory,
                                              EventProcessorOptions options) : base(storageManager, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
            {
                InjectedConnectionFactory = connectionFactory;
            }

            protected override EventHubConnection CreateConnection() => InjectedConnectionFactory();
        }
    }
}
