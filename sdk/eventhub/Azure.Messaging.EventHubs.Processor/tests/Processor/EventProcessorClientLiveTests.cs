// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Producer;
using Moq;
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
        /// <summary>
        ///   Verifies that the <see cref="EventProcessorClient" /> can read a set of published events.
        /// </summary>
        ///
        [Test]
        [TestCase(LoadBalancingStrategy.Balanced)]
        [TestCase(LoadBalancingStrategy.Greedy)]
        public async Task EventsCanBeReadByOneProcessorClient(LoadBalancingStrategy loadBalancingStrategy)
        {
            // Setup the environment.

            await using EventHubScope scope = await EventHubScope.CreateAsync(2);
            var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
           cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            // Send a set of events.

            var sourceEvents = EventGenerator.CreateEvents(50).ToList();
            var sentCount = await SendEvents(connectionString, sourceEvents, cancellationSource.Token);

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the events.

            var processedEvents = new ConcurrentDictionary<string, EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250), LoadBalancingStrategy = loadBalancingStrategy };
            var processor = CreateProcessor(scope.ConsumerGroups.First(), connectionString, options: options);

            processor.ProcessErrorAsync += CreateAssertingErrorHandler();
            processor.ProcessEventAsync += CreateEventTrackingHandler(sentCount, processedEvents, completionSource, cancellationSource.Token);

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            // Validate the events that were processed.

            foreach (var sourceEvent in sourceEvents)
            {
                var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                Assert.That(processedEvents.TryGetValue(sourceId, out var processedEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
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
            var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
           cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            // Send a set of events.

            var sourceEvents = EventGenerator.CreateEvents(50).ToList();
            var sentCount = await SendEvents(connectionString, sourceEvents, cancellationSource.Token);

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the events.

            var processedEvents = new ConcurrentDictionary<string, EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250) };
            var processor = CreateProcessorWithIdentity(scope.ConsumerGroups.First(), scope.EventHubName, options: options);

            processor.ProcessErrorAsync += CreateAssertingErrorHandler();
            processor.ProcessEventAsync += CreateEventTrackingHandler(sentCount, processedEvents, completionSource, cancellationSource.Token);

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, $"The cancellation token should not have been signaled.  { processedEvents.Count } events were processed.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            // Validate the events that were processed.

            foreach (var sourceEvent in sourceEvents)
            {
                var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                Assert.That(processedEvents.TryGetValue(sourceId, out var processedEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
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
            var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            // Send a set of events.

            var sourceEvents = EventGenerator.CreateEvents(500).ToList();
            var sentCount = await SendEvents(connectionString, sourceEvents, cancellationSource.Token);

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the events.

            var processedEvents = new ConcurrentDictionary<string, EventData>();
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
                processor.ProcessErrorAsync += CreateAssertingErrorHandler();
                processor.ProcessEventAsync += CreateEventTrackingHandler(sentCount, processedEvents, completionSource, cancellationSource.Token);
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
                var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                Assert.That(processedEvents.TryGetValue(sourceId, out var processedEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
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
            var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            // Discover the partitions.

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var partitionId in (await producer.GetPartitionIdsAsync()))
                {
                    partitionIds.Add(partitionId);
                }
            }

            // Send a set of events.

            var sourceEvents = EventGenerator.CreateEvents(200).ToList();
            var sentCount = await SendEvents(connectionString, sourceEvents, cancellationSource.Token);

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the events.

            var processedEvents = new ConcurrentDictionary<string, EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var storageManager = new InMemoryStorageManager(_ => {});
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250) };
            var processor = CreateProcessorWithIdentity(scope.ConsumerGroups.First(), scope.EventHubName, storageManager, options);

            processor.ProcessErrorAsync += CreateAssertingErrorHandler();
            processor.ProcessEventAsync += CreateEventTrackingHandler(sentCount, processedEvents, completionSource, cancellationSource.Token);

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, $"The cancellation token should not have been signaled.  { processedEvents.Count } events were processed.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            // Validate that events that were processed.

            var ownership = (await storageManager.ListOwnershipAsync(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, scope.ConsumerGroups.First(), cancellationSource.Token))?.ToList();

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
            var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            // Send a set of events.

            var sourceEvents = EventGenerator.CreateEvents(25).ToList();
            var lastSourceEvent = sourceEvents.Last();
            var sentCount = await SendEvents(connectionString, sourceEvents, cancellationSource.Token);

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Read the initial set back, marking the offset and sequence number of the last event in the initial set.

            var startingOffset = 0L;

            await using (var consumer = new EventHubConsumerClient(scope.ConsumerGroups.First(), connectionString))
            {
                await foreach  (var partitionEvent in consumer.ReadEventsAsync(new ReadEventOptions { MaximumWaitTime = null }, cancellationSource.Token))
                {
                    if (partitionEvent.Data.IsEquivalentTo(lastSourceEvent))
                    {
                        startingOffset = partitionEvent.Data.Offset;

                        break;
                    }
                }
            }

            // Send the second set of events to be read by the processor.

            sourceEvents = EventGenerator.CreateEvents(20).ToList();
            sentCount = await SendEvents(connectionString, sourceEvents, cancellationSource.Token);

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the second set of events.

            var processedEvents = new ConcurrentDictionary<string, EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250) };
            var processor = CreateProcessor(scope.ConsumerGroups.First(), connectionString, options: options);

            processor.PartitionInitializingAsync += args =>
            {
                args.DefaultStartingPosition = EventPosition.FromOffset(startingOffset, false);
                return Task.CompletedTask;
            };

            processor.ProcessErrorAsync += CreateAssertingErrorHandler();
            processor.ProcessEventAsync += CreateEventTrackingHandler(sentCount, processedEvents, completionSource, cancellationSource.Token);

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            // Validate the events that were processed.

            foreach (var sourceEvent in sourceEvents)
            {
                var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                Assert.That(processedEvents.TryGetValue(sourceId, out var processedEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
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
            var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            // Send a set of events.

            var segmentEventCount = 25;
            var beforeCheckpointEvents = EventGenerator.CreateEvents(segmentEventCount).ToList();
            var afterCheckpointEvents = EventGenerator.CreateEvents(segmentEventCount).ToList();
            var sourceEvents = Enumerable.Concat(beforeCheckpointEvents, afterCheckpointEvents).ToList();
            var checkpointEvent = beforeCheckpointEvents.Last();
            var sentCount = await SendEvents(connectionString, sourceEvents, cancellationSource.Token);

            Assert.That(sentCount, Is.EqualTo(sourceEvents.Count), "Not all of the source events were sent.");

            // Attempt to read back the first half of the events and checkpoint.

            Func<ProcessEventArgs, Task> processedEventCallback = async args =>
            {
                if (args.Data.IsEquivalentTo(checkpointEvent))
                {
                    await args.UpdateCheckpointAsync(cancellationSource.Token);
                }
            };

            var processedEvents = new ConcurrentDictionary<string, EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var beforeCheckpointProcessHandler = CreateEventTrackingHandler(segmentEventCount, processedEvents, completionSource, cancellationSource.Token, processedEventCallback);
            var options = new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromMilliseconds(250) };
            var storageManager = new InMemoryStorageManager(_ => {});
            var processor = CreateProcessor(scope.ConsumerGroups.First(), connectionString, storageManager, options);

            processor.ProcessErrorAsync += CreateAssertingErrorHandler();
            processor.ProcessEventAsync += beforeCheckpointProcessHandler;

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await processor.StopProcessingAsync(cancellationSource.Token);

            // Validate a checkpoint was created and that events were processed.

            var checkpoints = (await storageManager.ListCheckpointsAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup, cancellationSource.Token))?.ToList();
            Assert.That(checkpoints, Is.Not.Null, "A checkpoint should have been created.");
            Assert.That(checkpoints.Count, Is.EqualTo(1), "A single checkpoint should exist.");
            Assert.That(processedEvents.Count, Is.AtLeast(beforeCheckpointEvents.Count), "All events before the checkpoint should have been processed.");

            // Reset state and start the processor again; it should resume from the event following the checkpoint.

            processedEvents.Clear();
            completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            processor.ProcessEventAsync -= beforeCheckpointProcessHandler;
            processor.ProcessEventAsync += CreateEventTrackingHandler(segmentEventCount, processedEvents, completionSource, cancellationSource.Token);

            await processor.StartProcessingAsync(cancellationSource.Token);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            await processor.StopProcessingAsync(cancellationSource.Token);
            cancellationSource.Cancel();

            foreach (var sourceEvent in afterCheckpointEvents)
            {
                var sourceId = sourceEvent.Properties[EventGenerator.IdPropertyName].ToString();
                Assert.That(processedEvents.TryGetValue(sourceId, out var processedEvent), Is.True, $"The event with custom identifier [{ sourceId }] was not processed." );
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
            var credential = EventHubsTestEnvironment.Instance.Credential;
            EventHubConnection createConnection() => new EventHubConnection(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, eventHubName, credential);

            storageManager ??= new InMemoryStorageManager(_=> {});
            return new TestEventProcessorClient(storageManager, consumerGroup, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, eventHubName, credential, createConnection, options);
        }

        /// <summary>
        ///   Sends a set of events using a new producer to do so.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use when creating the producer.</param>
        /// <param name="sourceEvents">The set of events to send.</param>
        /// <param name="cancellationToken">The token used to signal a cancellation request.</param>
        ///
        /// <returns>The count of events that were sent.</returns>
        ///
        private async Task<int> SendEvents(string connectionString,
                                           IEnumerable<EventData> sourceEvents,
                                           CancellationToken cancellationToken)
        {
            var sentCount = 0;

            await using (var producer = new EventHubProducerClient(connectionString))
            {
                foreach (var batch in (await EventGenerator.BuildBatchesAsync(sourceEvents, producer, default, cancellationToken)))
                {
                    await producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);

                    sentCount += batch.Count;
                    batch.Dispose();
                }
            }

            return sentCount;
        }

        /// <summary>
        ///  Creates an event handler for the <see cref="EventProcessorClient.ProcessEventsAsync" />
        ///  event which tracks events against a target count, guarding against duplicates and
        ///  capturing accepted events.
        /// </summary>
        ///
        /// <param name="targetCount">The desired count of events.  Once the number of processed events reaches this count, the <paramref name="completionSource" /> will be signaled.</param>
        /// <param name="processedEvents">The set of events that were accepted and marked as processed.</param>
        /// <param name="completionSource">The completion source to signal when the number of events processed reaches the <paramref name="targetCount" />.</param>
        /// <param name="cancellationToken">The token used to signal a request for cancellation.</param>
        /// <param name="acceptedEventCallback">An optional callback function that </param>
        ///
        /// <returns>A delegate suitable for use with the <see cref="EventProcessorClient.ProcessEventsAsync" /> event.</returns>
        ///
        private Func<ProcessEventArgs, Task> CreateEventTrackingHandler(int targetCount,
                                                                        ConcurrentDictionary<string, EventData> processedEvents,
                                                                        TaskCompletionSource<bool> completionSource,
                                                                        CancellationToken cancellationToken,
                                                                        Func<ProcessEventArgs, Task> acceptedEventCallback = default) =>
            async args =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Guard against empty arguments with no event and duplicates; Event Hubs has an
                // at-least-once guarantee and may send the same event more than once.

                if (args.HasEvent)
                {
                    var eventId = args.Data.Properties[EventGenerator.IdPropertyName].ToString();

                    if (processedEvents.TryAdd(eventId, args.Data))
                    {
                        if (acceptedEventCallback != default)
                        {
                            await acceptedEventCallback(args).ConfigureAwait(false);
                        }

                        if (processedEvents.Count >= targetCount)
                        {
                           completionSource.TrySetResult(true);
                        }
                    }
                }
            };

        /// <summary>
        ///  Creates an event handler for the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///  event which performs an <see cref="Assert.Fail" /> when an error is handled.
        /// </summary>
        ///
        /// <returns>A delegate suitable for use with the <see cref="EventProcessorClient.ProcessErrorAsync" /> event.</returns>
        ///
        private Func<ProcessErrorEventArgs, Task> CreateAssertingErrorHandler() =>
            args =>
            {
                Assert.Fail($"Processor Error Surfaced: ({ args.Exception.GetType().Name })[{ args.Exception.Message }]");
                return Task.CompletedTask;
            };

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
                                              EventProcessorOptions options) : base(storageManager, consumerGroup, fullyQualifiedNamespace, eventHubName, 100, credential, options)
            {
                InjectedConnectionFactory = connectionFactory;
            }

            protected override EventHubConnection CreateConnection() => InjectedConnectionFactory();
        }
    }
}
