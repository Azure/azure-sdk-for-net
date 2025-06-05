// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventHubBufferedProducerClientClient" />
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
    public class EventHubBufferedProducerClientLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanPublishRoundRobinWithDefaultOptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionCount = 4;
            var eventsPerPartition = 20;
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            producer.SendEventBatchSucceededAsync += args =>
            {
                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                if (handlerEvents.Count >= events.Count)
                {
                    completionSource.TrySetResult(true);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and avoid flushing and wait for publishing to complete.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);

            try
            {
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            catch (OperationCanceledException)
            {
                Assert.Fail($"The handler did not receive all events.  { handlerEvents.Count } of { events.Count } were captured.");
            }

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");
            Assert.That(handlerEvents.Select(item => item.PartitionId).Distinct().Count(), Is.EqualTo(partitionCount), "All partitions should have received events.");

            // Because the handlers are fired in the background before state is updated, it is possible that the buffered event count may not have been fully updated
            // when the handler sets the completion source.  Allow for a short spin and back-off if needed to allow it to settle.

            await PollForZeroBufferedEventCount(producer);
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= events.Count)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanPublishUsingPartitionKeysWithDefaultOptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionCount = 4;
            var eventsPerPartition = 20;
            var enqueuedCount = 0;
            var keys = new[] { "one", "I-like-long-keys!", "123", "short1122##" };
            var keyHash = new HashSet<string>(keys);
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            producer.SendEventBatchSucceededAsync += args =>
            {
                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                if (handlerEvents.Count >= events.Count)
                {
                    completionSource.TrySetResult(true);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            for (var batchIndex = 0; batchIndex < partitionCount; ++batchIndex)
            {
                var eventsToEnqueue = events.Skip(batchIndex * eventsPerPartition).Take(eventsPerPartition).ToList();
                var key = keys[batchIndex % keys.Length];

                await producer.EnqueueEventsAsync(eventsToEnqueue, new EnqueueEventOptions { PartitionKey = key }, cancellationSource.Token);
                enqueuedCount += eventsToEnqueue.Count;
            }

            Assert.That(enqueuedCount, Is.EqualTo(events.Count), "All events should have been enqueued.");

            // Avoid flushing and wait for publishing to complete naturally.

            try
            {
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            catch (OperationCanceledException)
            {
                Assert.Fail($"The handler did not receive all events.  { handlerEvents.Count } of { events.Count } were captured.");
            }

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");

            // Because the handlers are fired in the background before state is updated, it is possible that the buffered event count may not have been fully updated
            // when the handler sets the completion source.  Allow for a short spin and back-off if needed to allow it to settle.

            await PollForZeroBufferedEventCount(producer);
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= events.Count)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.PartitionKey, Is.Not.Null.And.Not.Empty, $"The event read at index: [{ index }] should have a partition key set.");
                Assert.That(keyHash.Contains(readEvents[index].Event.PartitionKey), Is.True, $"The event read at index: [{ index }] should have a known partition key.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanPublishToPartitionIdsWithDefaultOptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionCount = 4;
            var eventsPerPartition = 20;
            var enqueuedCount = 0;
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            var partitions = await producer.GetPartitionIdsAsync(cancellationSource.Token);

            producer.SendEventBatchSucceededAsync += args =>
            {
                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                if (handlerEvents.Count >= events.Count)
                {
                    completionSource.TrySetResult(true);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            for (var batchIndex = 0; batchIndex < partitionCount; ++batchIndex)
            {
                var eventsToEnqueue = events.Skip(batchIndex * eventsPerPartition).Take(eventsPerPartition).ToList();
                var id = partitions[batchIndex % partitions.Length];

                await producer.EnqueueEventsAsync(eventsToEnqueue, new EnqueueEventOptions { PartitionId = id }, cancellationSource.Token);
                enqueuedCount += eventsToEnqueue.Count;
            }

            Assert.That(enqueuedCount, Is.EqualTo(events.Count), "All events should have been enqueued.");

            // Avoid flushing and wait for publishing to complete naturally.

            try
            {
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            catch (OperationCanceledException)
            {
                Assert.Fail($"The handler did not receive all events.  { handlerEvents.Count } of { events.Count } were captured.");
            }

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");

            // Because the handlers are fired in the background before state is updated, it is possible that the buffered event count may not have been fully updated
            // when the handler sets the completion source.  Allow for a short spin and back-off if needed to allow it to settle.

            await PollForZeroBufferedEventCount(producer);
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= events.Count)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanPublishHeterogeneousEventsWithDefaultOptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionCount = 4;
            var eventsPerPartition = 20;
            var enqueuedCount = 0;
            var keys = new[] { "one", "I-like-long-keys!", "123", "short1122##" };
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            var partitions = await producer.GetPartitionIdsAsync(cancellationSource.Token);

            producer.SendEventBatchSucceededAsync += args =>
            {
                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                if (handlerEvents.Count >= events.Count)
                {
                    completionSource.TrySetResult(true);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            for (var batchIndex = 0; batchIndex < partitionCount; ++batchIndex)
            {
                var options = batchIndex switch
                {
                    _ when (batchIndex % 3 == 0) => new EnqueueEventOptions { PartitionId = partitions[batchIndex % partitions.Length] },
                    _ when (batchIndex % 5 == 0) => new EnqueueEventOptions { PartitionKey = keys[batchIndex % keys.Length] },
                    _ => null
                };

                var eventsToEnqueue = events.Skip(batchIndex * eventsPerPartition).Take(eventsPerPartition).ToList();

                await producer.EnqueueEventsAsync(eventsToEnqueue, options, cancellationSource.Token);
                enqueuedCount += eventsToEnqueue.Count;
            }

            Assert.That(enqueuedCount, Is.EqualTo(events.Count), "All events should have been enqueued.");

            // Avoid flushing and wait for publishing to complete naturally.  I

            try
            {
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            catch (OperationCanceledException)
            {
                Assert.Fail($"The handler did not receive all events.  { handlerEvents.Count } of { events.Count } were captured.");
            }

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");

            // Because the handlers are fired in the background before state is updated, it is possible that the buffered event count may not have been fully updated
            // when the handler sets the completion source.  Allow for a short spin and back-off if needed to allow it to settle.

            await PollForZeroBufferedEventCount(producer);
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= events.Count)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanPublishWithRestrictedConcurrency()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var concurrentSends = 2;
            var partitionCount = 4;
            var eventsPerPartition = 20;
            var enqueuedCount = 0;
            var keys = new[] { "one", "I-like-long-keys!", "123", "short1122##" };
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = concurrentSends };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            var partitions = await producer.GetPartitionIdsAsync(cancellationSource.Token);

            producer.SendEventBatchSucceededAsync += args =>
            {
                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                if (handlerEvents.Count >= events.Count)
                {
                    completionSource.TrySetResult(true);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            for (var batchIndex = 0; batchIndex < partitionCount; ++batchIndex)
            {
                var enqueueOptions = batchIndex switch
                {
                    _ when (batchIndex % 3 == 0) => new EnqueueEventOptions { PartitionId = partitions[batchIndex % partitions.Length] },
                    _ when (batchIndex % 5 == 0) => new EnqueueEventOptions { PartitionKey = keys[batchIndex % keys.Length] },
                    _ => null
                };

                var eventsToEnqueue = events.Skip(batchIndex * eventsPerPartition).Take(eventsPerPartition).ToList();

                await producer.EnqueueEventsAsync(eventsToEnqueue, enqueueOptions, cancellationSource.Token);
                enqueuedCount += eventsToEnqueue.Count;
            }

            Assert.That(enqueuedCount, Is.EqualTo(events.Count), "All events should have been enqueued.");

            // Avoid flushing and wait for publishing to complete naturally.  I

            try
            {
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            catch (OperationCanceledException)
            {
                Assert.Fail($"The handler did not receive all events.  { handlerEvents.Count } of { events.Count } were captured.");
            }

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");

            // Because the handlers are fired in the background before state is updated, it is possible that the buffered event count may not have been fully updated
            // when the handler sets the completion source.  Allow for a short spin and back-off if needed to allow it to settle.

            await PollForZeroBufferedEventCount(producer);
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= events.Count)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanPublishWithConcurrentPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var concurrentSendsPerPartition = 4;
            var partitionCount = 1;
            var eventsPerPartition = 80;
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            var options = new EventHubBufferedProducerClientOptions
            {
                MaximumConcurrentSends = (partitionCount * concurrentSendsPerPartition),
                MaximumConcurrentSendsPerPartition = concurrentSendsPerPartition
            };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.SendEventBatchSucceededAsync += args =>
            {
                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                if (handlerEvents.Count >= events.Count)
                {
                    completionSource.TrySetResult(true);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and avoid flushing and wait for publishing to complete.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);

            try
            {
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            catch (OperationCanceledException)
            {
                Assert.Fail($"The handler did not receive all events.  { handlerEvents.Count } of { events.Count } were captured.");
            }

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");
            Assert.That(handlerEvents.Select(item => item.PartitionId).Distinct().Count(), Is.EqualTo(partitionCount), "All partitions should have received events.");

            // Because the handlers are fired in the background before state is updated, it is possible that the buffered event count may not have been fully updated
            // when the handler sets the completion source.  Allow for a short spin and back-off if needed to allow it to settle.

            await PollForZeroBufferedEventCount(producer);
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= events.Count)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanPublishAfterIdle()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionCount = 4;
            var eventsPerPartition = 20;
            var batchCount = (partitionCount * eventsPerPartition);
            var expectedCount = (batchCount * 2);
            var events = EventGenerator.CreateSmallEvents(expectedCount).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var initialCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var idleCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var afterIdleCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();

            mockLogger
                .Setup(log => log.BufferedProducerIdleStart(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => idleCompletionSource.TrySetResult(true));

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            var partitions = await producer.GetPartitionIdsAsync(cancellationSource.Token);

            producer.Logger = mockLogger.Object;

            producer.SendEventBatchSucceededAsync += args =>
            {
                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                if (handlerEvents.Count >= batchCount)
                {
                    initialCompletionSource.TrySetResult(true);
                }

                if (handlerEvents.Count >= expectedCount)
                {
                    afterIdleCompletionSource.TrySetResult(true);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            await producer.EnqueueEventsAsync(events.Take(batchCount), cancellationSource.Token);

            // Avoid flushing and wait for publishing to complete naturally.

            try
            {
                await initialCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            catch (OperationCanceledException)
            {
                Assert.Fail($"The handler did not receive all events.  {handlerEvents.Count} of {events.Count} were captured.");
            }

            // Wait for a short period to allow the producer to go idle and then
            // enqueue all events again.

            await idleCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationSource.Token);
            await producer.EnqueueEventsAsync(events.Skip(batchCount), cancellationSource.Token);

            try
            {
                await afterIdleCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            catch (OperationCanceledException)
            {
                Assert.Fail($"The handler did not receive all events after it was idle.  {handlerEvents.Count} of {events.Count} were captured.");
            }

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerEvents.Count, Is.EqualTo(expectedCount), "All events should have been sent.");

            // Because the handlers are fired in the background before state is updated, it is possible that the buffered event count may not have been fully updated
            // when the handler sets the completion source.  Allow for a short spin and back-off if needed to allow it to settle.

            await PollForZeroBufferedEventCount(producer);
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= expectedCount)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{index}].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{index}].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanPublishAfterFlush()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventSetCount = 3;
            var eventsPerSet = 50;
            var events = EventGenerator.CreateSmallEvents(eventSetCount * eventsPerSet).ToList();
            var firstEventSet = events.Take(eventsPerSet).ToList();
            var secondEventSet = events.Skip(eventsPerSet).Take(eventsPerSet).ToList();
            var lastEventSet = events.Skip(eventsPerSet * 2).Take(eventsPerSet).ToList();
            var handlerEvents = new ConcurrentBag<EventData>();
            var pendingReads = new HashSet<string>(events.Select(evt => evt.MessageId));
            var readEvents = new List<EventData>();
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = eventSetCount };

            await using var scope = await EventHubScope.CreateAsync(1);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.SendEventBatchSucceededAsync += args =>
            {
                foreach (var item in args.EventBatch)
                {
                    handlerEvents.Add(item);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and flush the first set of events.

            await producer.EnqueueEventsAsync(firstEventSet, cancellationSource.Token);
            await producer.FlushAsync(cancellationSource.Token);

            // Enqueue and flush the remaining events; after this flush, all events
            // should have been published and captured by the handler.

            await producer.EnqueueEventsAsync(secondEventSet, cancellationSource.Token);
            await producer.EnqueueEventsAsync(lastEventSet, cancellationSource.Token);
            await producer.FlushAsync(cancellationSource.Token);

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(producer.IsClosed, Is.False, "The producer should not report that it is closed.");
            Assert.That(producer.IsPublishing, Is.False, "The producer should report that it is not publishing.");
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                if (pendingReads.Contains(partitionEvent.Data.MessageId))
                {
                    pendingReads.Remove(partitionEvent.Data.MessageId);
                    readEvents.Add(partitionEvent.Data);
                }

                if (pendingReads.Count == 0)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].IsEquivalentTo(sortedHandlerEvents[index]), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task FlushSendsAllEventsAndWaitsForHandlersWithDefaultOptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var flushCount = 0;
            var handlerInvokedAfterFlush = false;
            var partitionCount = 2;
            var eventsPerPartition = 50;
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var pendingReads = new HashSet<string>(events.Select(evt => evt.MessageId));
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = partitionCount };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.SendEventBatchSucceededAsync += args =>
            {
                // If flush was already completed, do not capture the
                // events; the handler should not have been invoked.

                if (flushCount > 0)
                {
                    handlerInvokedAfterFlush = true;
                    return Task.CompletedTask;
                }

                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and flush; when flushing is complete, all events should be sent and handlers
            // should have completed executing.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);
            await producer.FlushAsync(cancellationSource.Token);

            Interlocked.Increment(ref flushCount);

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerInvokedAfterFlush, Is.False, "The handler should not have been invoked after the FlushAsync call completed.");
            Assert.That(producer.IsClosed, Is.False, "The producer should not report that it is closed.");
            Assert.That(producer.IsPublishing, Is.False, "The producer should report that it is not publishing.");
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                if (pendingReads.Contains(partitionEvent.Data.MessageId))
                {
                    pendingReads.Remove(partitionEvent.Data.MessageId);
                    readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));
                }

                if (pendingReads.Count == 0)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task FlushSendsAllEventsAndWaitsForHandlersWithConcurrentPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var flushCount = 0;
            var handlerInvokedAfterFlush = false;
            var concurrentSendsPerPartition = 4;
            var partitionCount = 1;
            var eventsPerPartition = 80;
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var pendingReads = new HashSet<string>(events.Select(evt => evt.MessageId));
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();

            var options = new EventHubBufferedProducerClientOptions
            {
                MaximumConcurrentSends = (partitionCount * concurrentSendsPerPartition),
                MaximumConcurrentSendsPerPartition = concurrentSendsPerPartition
            };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.SendEventBatchSucceededAsync += args =>
            {
                // If flush was already completed, do not capture the
                // events; the handler should not have been invoked.

                if (flushCount > 0)
                {
                    handlerInvokedAfterFlush = true;
                    return Task.CompletedTask;
                }

                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and flush; when flushing is complete, all events should be sent and handlers
            // should have completed executing.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);
            await producer.FlushAsync(cancellationSource.Token);

            Interlocked.Increment(ref flushCount);

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerInvokedAfterFlush, Is.False, "The handler should not have been invoked after the FlushAsync call completed.");
            Assert.That(producer.IsClosed, Is.False, "The producer should not report that it is closed.");
            Assert.That(producer.IsPublishing, Is.False, "The producer should report that it is not publishing.");
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                if (pendingReads.Contains(partitionEvent.Data.MessageId))
                {
                    pendingReads.Remove(partitionEvent.Data.MessageId);
                    readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));
                }

                if (pendingReads.Count == 0)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task CloseSendsAllEventsAndWaitsForHandlersWhenFlushingWithDefaultOptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var closeCount = 0;
            var handlerInvokedAfterClose = false;
            var partitionCount = 2;
            var eventsPerPartition = 50;
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = partitionCount };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.SendEventBatchSucceededAsync += args =>
            {
                // If close was already completed, do not capture the
                // events; the handler should not have been invoked.

                if (closeCount > 0)
                {
                    handlerInvokedAfterClose = true;
                    return Task.CompletedTask;
                }

                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and close; when closing is complete, all events should be sent and handlers
            // should have completed executing.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);
            await producer.CloseAsync(flush: true, cancellationSource.Token);

            Interlocked.Increment(ref closeCount);

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerInvokedAfterClose, Is.False, "The handler should not have been invoked after the CloseAsync call completed.");
            Assert.That(producer.IsClosed, Is.True, "The producer should report that it is closed.");
            Assert.That(producer.IsPublishing, Is.False, "The producer should report that it is not publishing.");
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= events.Count)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task CloseSendsAllEventsAndWaitsForHandlersWhenFlushingWithConcurrentPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var closeCount = 0;
            var handlerInvokedAfterClose = false;
            var concurrentSendsPerPartition = 4;
            var partitionCount = 12;
            var eventsPerPartition = 80;
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();

            var options = new EventHubBufferedProducerClientOptions
            {
                MaximumConcurrentSends = (partitionCount * concurrentSendsPerPartition),
                MaximumConcurrentSendsPerPartition = concurrentSendsPerPartition
            };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.SendEventBatchSucceededAsync += args =>
            {
                // If close was already completed, do not capture the
                // events; the handler should not have been invoked.

                if (closeCount > 0)
                {
                    handlerInvokedAfterClose = true;
                    return Task.CompletedTask;
                }

                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and close; when closing is complete, all events should be sent and handlers
            // should have completed executing.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);
            await producer.CloseAsync(flush: true, cancellationSource.Token);

            Interlocked.Increment(ref closeCount);

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerInvokedAfterClose, Is.False, "The handler should not have been invoked after the FlushAsync call completed.");
            Assert.That(producer.IsClosed, Is.True, "The producer should report that it is closed.");
            Assert.That(producer.IsPublishing, Is.False, "The producer should report that it is not publishing.");
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count), "All events should have been sent.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= events.Count)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{ index }].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{ index }].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task CloseAbandonsEventsAndHandlersWhenClearingWithDefaultOptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionCount = 2;
            var eventsPerPartition = 50;
            var events = EventGenerator.CreateSmallEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = partitionCount };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and close; when closing is complete, the state of events and handlers are non-deterministic,
            // but the client state can be verified.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);
            await producer.CloseAsync(flush: false, cancellationSource.Token);

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(producer.IsClosed, Is.True, "The producer should report that it is closed.");
            Assert.That(producer.IsPublishing, Is.False, "The producer should report that it is not publishing.");
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task CloseAbandonsEventsAndHandlersWhenClearingWithConcurrentPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var concurrentSendsPerPartition = 4;
            var partitionCount = 1;
            var eventsPerPartition = 50;
            var events = EventGenerator.CreateEvents(partitionCount * eventsPerPartition).ToList();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();

            var options = new EventHubBufferedProducerClientOptions
            {
                MaximumConcurrentSends = (partitionCount * concurrentSendsPerPartition),
                MaximumConcurrentSendsPerPartition = concurrentSendsPerPartition
            };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and close; when closing is complete, the state of events and handlers are non-deterministic,
            // but the client state can be verified.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);
            await producer.CloseAsync(flush: false, cancellationSource.Token);

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(producer.IsClosed, Is.True, "The producer should report that it is closed.");
            Assert.That(producer.IsPublishing, Is.False, "The producer should report that it is not publishing.");
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task CloseSendsEventsWhenFlushingAfterIdle()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var closeCount = 0;
            var handlerInvokedAfterClose = false;
            var partitionCount = 2;
            var eventsPerPartition = 50;
            var expectedEvents = (eventsPerPartition * partitionCount);
            var events = EventGenerator.CreateSmallEvents(expectedEvents).ToList();
            var finalEvent = EventGenerator.CreateSmallEvents(1).First();
            var handlerEvents = new ConcurrentBag<EventWithPartition>();
            var readEvents = new List<EventWithPartition>();
            var initialSendCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var idleCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = partitionCount };
            var mockLogger = new Mock<EventHubsEventSource>();

            mockLogger
                .Setup(log => log.BufferedProducerIdleStart(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => idleCompletionSource.TrySetResult(true));

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.Logger = mockLogger.Object;

            producer.SendEventBatchSucceededAsync += args =>
            {
                // If close was already completed, do not capture the
                // events; the handler should not have been invoked.

                if (closeCount > 0)
                {
                    handlerInvokedAfterClose = true;
                    return Task.CompletedTask;
                }

                foreach (var item in args.EventBatch.Select(item => new EventWithPartition(args.PartitionId, item)))
                {
                    handlerEvents.Add(item);
                }

                if (handlerEvents.Count >= expectedEvents)
                {
                    initialSendCompletionSource.TrySetResult(true);
                }

                return Task.CompletedTask;
            };

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and wait for the initial send to complete.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);
            await initialSendCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            // Wait for the producer to go idle and then enqueue another event.

            await idleCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationSource.Token);

            await producer.EnqueueEventAsync(finalEvent, cancellationSource.Token);
            await producer.CloseAsync(flush: true, cancellationSource.Token);

            Interlocked.Increment(ref closeCount);

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(handlerInvokedAfterClose, Is.False, "The handler should not have been invoked after the CloseAsync call completed.");
            Assert.That(producer.IsClosed, Is.True, "The producer should report that it is closed.");
            Assert.That(producer.IsPublishing, Is.False, "The producer should report that it is not publishing.");
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");
            Assert.That(handlerEvents.Count, Is.EqualTo(events.Count + 1), "All events should have been sent.");

            // Read back the events and ensure all were successfully published.

            await using var consumerClient = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            await foreach (var partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
            {
                readEvents.Add(new EventWithPartition(partitionEvent.Partition.PartitionId, partitionEvent.Data));

                if (readEvents.Count >= events.Count + 1)
                {
                    break;
                }
            }

            // Ensure that all sent events were read back.

            readEvents = readEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();
            var sortedHandlerEvents = handlerEvents.OrderBy(evt => evt.PartitionId).ThenBy(evt => evt.Event.MessageId).ToList();

            for (var index = 0; index < readEvents.Count; ++index)
            {
                Assert.That(readEvents[index].PartitionId, Is.EqualTo(sortedHandlerEvents[index].PartitionId), $"The partition for the read and sent events should match at index: [{index}].");
                Assert.That(readEvents[index].Event.IsEquivalentTo(sortedHandlerEvents[index].Event), Is.True, $"The event for the read and sent events should match at index: [{index}].");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to publish events.
        /// </summary>
        ///
        [Test]
        public async Task CloseIsSuccessfulWhileIdle()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionCount = 2;
            var eventsPerPartition = 25;
            var expectedEvents = (eventsPerPartition * partitionCount);
            var events = EventGenerator.CreateSmallEvents(expectedEvents).ToList();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = partitionCount };
            var mockLogger = new Mock<EventHubsEventSource>();

            mockLogger
                .Setup(log => log.BufferedProducerIdleStart(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => completionSource.TrySetResult(true));

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, options);

            producer.Logger = mockLogger.Object;
            producer.SendEventBatchSucceededAsync += args => Task.CompletedTask;

            producer.SendEventBatchFailedAsync += args =>
            {
                ExceptionDispatchInfo.Capture(args.Exception).Throw();
                return Task.CompletedTask;
            };

            // Enqueue and wait for the producer to go idle.

            await producer.EnqueueEventsAsync(events, cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            // Wait for an additional small delay and then close.

            await Task.Delay(TimeSpan.FromSeconds(2), cancellationSource.Token);
            await producer.CloseAsync(flush: false, cancellationSource.Token);

            // Ensure that publishing completed with the expected state.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(producer.IsClosed, Is.True, "The producer should report that it is closed.");
            Assert.That(producer.IsPublishing, Is.False, "The producer should report that it is not publishing.");
            Assert.That(producer.TotalBufferedEventCount, Is.EqualTo(0), "No events should remain in the buffer.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ProducerCanRetrieveEventHubProperties(EventHubsTransportType transportType)
        {
            var partitionCount = 4;
            var producerOptions = new EventHubBufferedProducerClientOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, producerOptions);

            var properties = await producer.GetEventHubPropertiesAsync();

            Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
            Assert.That(properties.Name, Is.EqualTo(scope.EventHubName), "The property Event Hub name should match the scope.");
            Assert.That(properties.PartitionIds.Length, Is.EqualTo(partitionCount), "The properties should have the requested number of partitions.");
            Assert.That(properties.CreatedOn, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(60)), "The Event Hub should have been created just about now.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ProducerCanRetrievePartitionProperties(EventHubsTransportType transportType)
        {
            var partitionCount = 4;
            var producerOptions = new EventHubBufferedProducerClientOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

            await using var scope = await EventHubScope.CreateAsync(partitionCount);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential, producerOptions);

            var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            var properties = await producer.GetEventHubPropertiesAsync();
            var partition = properties.PartitionIds.First();
            var partitionProperties = await producer.GetPartitionPropertiesAsync(partition, cancellation.Token);

            Assert.That(partitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");
            Assert.That(partitionProperties.Id, Is.EqualTo(partition), "The partition identifier should match.");
            Assert.That(partitionProperties.EventHubName, Is.EqualTo(scope.EventHubName).Using((IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase), "The Event Hub path should match.");
            Assert.That(partitionProperties.BeginningSequenceNumber, Is.Not.EqualTo(default(long)), "The beginning sequence number should have been populated.");
            Assert.That(partitionProperties.LastEnqueuedSequenceNumber, Is.Not.EqualTo(default(long)), "The last sequence number should have been populated.");
            Assert.That(partitionProperties.LastEnqueuedOffsetString, Is.Not.EqualTo(default(long)), "The last offset should have been populated.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ConnectionTransportPartitionIdsMatchPartitionProperties()
        {
            await using var scope = await EventHubScope.CreateAsync(4);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            var properties = await producer.GetEventHubPropertiesAsync();
            var partitions = await producer.GetPartitionIdsAsync();

            Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
            Assert.That(properties.PartitionIds, Is.Not.Null, "A set of partition identifiers for the properties should have been returned.");
            Assert.That(partitions, Is.Not.Null, "A set of partition identifiers should have been returned.");
            Assert.That(partitions, Is.EquivalentTo(properties.PartitionIds), "The partition identifiers returned directly should match those returned with properties.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotRetrieveMetadataWhenClosed()
        {
            await using var scope = await EventHubScope.CreateAsync(1);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            var partition = (await producer.GetPartitionIdsAsync()).First();

            Assert.That(async () => await producer.GetEventHubPropertiesAsync(), Throws.Nothing);
            Assert.That(async () => await producer.GetPartitionPropertiesAsync(partition), Throws.Nothing);

            await producer.CloseAsync();
            await Task.Delay(TimeSpan.FromSeconds(5));

            Assert.That(async () => await producer.GetPartitionIdsAsync(), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
            Assert.That(async () => await producer.GetEventHubPropertiesAsync(), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
            Assert.That(async () => await producer.GetPartitionPropertiesAsync(partition), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubBufferedProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase("XYZ")]
        [TestCase("-1")]
        [TestCase("1000")]
        [TestCase("-")]
        public async Task ProducerCannotRetrievePartitionPropertiesWhenPartitionIdIsInvalid(string invalidPartition)
        {
            await using var scope = await EventHubScope.CreateAsync(1);
            await using var producer = new EventHubBufferedProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, EventHubsTestEnvironment.Instance.Credential);

            Assert.That(async () => await producer.GetPartitionPropertiesAsync(invalidPartition), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Polls the count of buffered events for a producer until it has been updated to
        ///   0 or the maximum number of iterations has been reached.
        /// </summary>
        ///
        /// <param name="producer">The producer to poll.</param>
        /// <param name="maxIterations">The maximum number of polling iterations to make.</param>
        ///
        private static async Task PollForZeroBufferedEventCount(EventHubBufferedProducerClient producer,
                                                                int maxIterations = 5)
        {
            var iterations = 0;

            if ((producer.TotalBufferedEventCount > 0) && (++iterations <= maxIterations))
            {
                await Task.Delay(TimeSpan.FromMilliseconds(125));
            }
        }

        /// <summary>
        ///   A lightweight structure for tracking events and associating with their partition.
        /// </summary>
        ///
        /// <param name="PartitionId">The identifier of the partition associated with the event.</param>
        /// <param name="Event">The event being tracked.</param>
        ///
        private sealed record EventWithPartition(string PartitionId, EventData Event)
        {
            public bool Equals(EventWithPartition other) => other.PartitionId == PartitionId && other.Event.IsEquivalentTo(Event);

            public override int GetHashCode()
            {
                var builder = new HashCodeBuilder();
                builder.Add(PartitionId);
                builder.Add(Event.GetHashCode());

                return builder.ToHashCode();
            }
        }
    }
}
