// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Provides an easy way to instantiate, start and stop multiple event processors.
    /// </summary>
    ///
    internal class EventProcessorManager
    {
        /// <summary>
        ///   A factory used to create partition processors.
        /// </summary>
        ///
        private Func<PartitionContext, CheckpointManager, IPartitionProcessor> PartitionProcessorFactory { get; }

        /// <summary>
        ///   The name of the consumer group the event processors are associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   The client used to interact with the Azure Event Hubs service.
        /// </summary>
        ///
        private EventHubClient InnerClient { get; }

        /// <summary>
        ///   The partition manager shared by all event processors in this hub.
        /// </summary>
        ///
        private PartitionManager InnerPartitionManager { get; }

        /// <summary>
        ///   The set of options to use for the event processors.
        /// </summary>
        ///
        private EventProcessorOptions Options { get; }

        /// <summary>
        ///   The event processors managed by this hub.
        /// </summary>
        ///
        private List<EventProcessor> EventProcessors { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorManager"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group the event processors are associated with.  Events are read in the context of this group.</param>
        /// <param name="client">The client used to interact with the Azure Event Hubs service.</param>
        /// <param name="options">The set of options to use for the event processors.</param>
        /// <param name="onInitialize">A callback action to be called on <see cref="PartitionProcessor.InitializeAsync" />.</param>
        /// <param name="onClose">A callback action to be called on <see cref="PartitionProcessor.CloseAsync" />.</param>
        /// <param name="onProcessEvents">A callback action to be called on <see cref="PartitionProcessor.ProcessEventsAsync" />.</param>
        /// <param name="onProcessError">A callback action to be called on <see cref="PartitionProcessor.ProcessErrorAsync" />.</param>
        ///
        public EventProcessorManager(string consumerGroup,
                                     EventHubClient client,
                                     EventProcessorOptions options = null,
                                     Action<PartitionContext, CheckpointManager> onInitialize = null,
                                     Action<PartitionContext, CheckpointManager, PartitionProcessorCloseReason> onClose = null,
                                     Action<PartitionContext, CheckpointManager, IEnumerable<EventData>, CancellationToken> onProcessEvents = null,
                                     Action<PartitionContext, CheckpointManager, Exception, CancellationToken> onProcessError = null)
        {
            ConsumerGroup = consumerGroup;
            InnerClient = client;

            PartitionProcessorFactory = (partitionContext, checkpointManager) =>
                new PartitionProcessor
                (
                    partitionContext,
                    checkpointManager,
                    onInitialize,
                    onClose,
                    onProcessEvents,
                    onProcessError
                );

            InnerPartitionManager = new InMemoryPartitionManager();

            // In case it has not been specified, set the maximum receive wait time to 2 seconds because the default
            // value (1 minute) would take too much time.

            Options = options?.Clone() ?? new EventProcessorOptions();

            if (Options.MaximumReceiveWaitTime == null)
            {
                Options.MaximumReceiveWaitTime = TimeSpan.FromSeconds(2);
            }

            EventProcessors = new List<EventProcessor>();
        }

        /// <summary>
        ///   Adds new uninitialized event processors instances to this hub.
        /// </summary>
        ///
        /// <param name="amount">The amount of event processors to add.</param>
        ///
        public void AddEventProcessors(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                EventProcessors.Add(new EventProcessor
                    (
                        ConsumerGroup,
                        InnerClient,
                        PartitionProcessorFactory,
                        InnerPartitionManager,
                        Options
                    ));
            }
        }

        /// <summary>
        ///   Starts the event processors.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public Task StartAllAsync()
        {
            return Task.WhenAll(EventProcessors
                .Select(eventProcessor => eventProcessor.StartAsync()));
        }

        /// <summary>
        ///   Stops the event processors.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public Task StopAllAsync()
        {
            return Task.WhenAll(EventProcessors
                .Select(eventProcessor => eventProcessor.StopAsync()));
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task WaitStabilization(int partitions)
        {
            var stabilizedStatusAchieved = false;
            var consecutiveStabilizedStatus = 0;
            List<PartitionOwnership> previousActiveOwnership = null;

            var maximumWaitTime = TimeSpan.FromSeconds(60 + 10 * partitions / EventProcessors.Count);

            var startTime = DateTimeOffset.UtcNow;

            while (!stabilizedStatusAchieved)
            {
                var ellapsedTime = DateTimeOffset.UtcNow.Subtract(startTime);

                if (ellapsedTime > maximumWaitTime)
                {
                    throw new TimeoutException("Stabilization took too long to finish.");
                }

                // Remember to filter expired ownership.

                var activeOwnership = (await InnerPartitionManager
                    .ListOwnershipAsync(InnerClient.EventHubName, ConsumerGroup)
                    .ConfigureAwait(false))
                    .Where(ownership => DateTimeOffset.UtcNow.Subtract(ownership.LastModifiedTime.Value).TotalSeconds < 30)
                    .ToList();

                // Increment stabilized status count if current partition distribution matches the previous one.  Reset it
                // otherwise.

                if (AreOwnersTheSame(previousActiveOwnership, activeOwnership))
                {
                    ++consecutiveStabilizedStatus;
                }
                else
                {
                    consecutiveStabilizedStatus = 1;
                }

                previousActiveOwnership = activeOwnership;

                if (consecutiveStabilizedStatus < 6)
                {
                    // Wait 5 seconds before the next verification.  The event processors wait 10 seconds between updates
                    // so there's no need to verify it too often.  We may end up waiting a bit more than the maximum wait
                    // time, but this is no reason for concern as the only purpose of the timeout is to avoid an endless loop.

                    await Task.Delay(5000);
                }
                else
                {
                    // We'll consider the load stabilized only if its status doesn't change after 6 verifications.

                    stabilizedStatusAchieved = true;
                }
            }
        }

        /// <summary>
        ///   TODO. (no filter) (rename)
        /// </summary>
        ///
        /// <returns>TODO.</returns>
        ///
        private bool AreOwnersTheSame(IEnumerable<PartitionOwnership> first,
            IEnumerable<PartitionOwnership> second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            var firstOrderedDistribution = first.OrderBy(ownership => ownership.PartitionId).ToList();
            var secondOrderedDistribution = second.OrderBy(ownership => ownership.PartitionId).ToList();

            if (firstOrderedDistribution.Count != secondOrderedDistribution.Count)
            {
                return false;
            }

            for (var index = 0; index < firstOrderedDistribution.Count; ++index)
            {
                if (firstOrderedDistribution[index].OwnerIdentifier != secondOrderedDistribution[index].OwnerIdentifier)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///   A test helper implementation of <see cref="IPartitionProcessor" />.
        /// </summary>
        ///
        private class PartitionProcessor : IPartitionProcessor
        {
            /// <summary>
            ///   Contains information about the partition this partition processor will be processing
            ///   events from.
            /// </summary>
            ///
            private PartitionContext AssociatedPartitionContext { get; }

            /// <summary>
            ///   Responsible for the creation of checkpoints.
            /// </summary>
            ///
            private CheckpointManager AssociatedCheckpointManager { get; }

            /// <summary>
            ///   A callback action to be called on <see cref="InitializeAsync" />.
            /// </summary>
            ///
            private Action<PartitionContext, CheckpointManager> OnInitialize { get; }

            /// <summary>
            ///   A callback action to be called on <see cref="CloseAsync" />.
            /// </summary>
            ///
            private Action<PartitionContext, CheckpointManager, PartitionProcessorCloseReason> OnClose { get; }

            /// <summary>
            ///   A callback action to be called on <see cref="ProcessEventsAsync" />.
            /// </summary>
            ///
            private Action<PartitionContext, CheckpointManager, IEnumerable<EventData>, CancellationToken> OnProcessEvents { get; }

            /// <summary>
            ///   A callback action to be called on <see cref="ProcessErrorAsync" />.
            /// </summary>
            ///
            private Action<PartitionContext, CheckpointManager, Exception, CancellationToken> OnProcessError { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="PartitionProcessor"/> class.
            /// </summary>
            ///
            /// <param name="partitionContext">Contains information about the partition this partition processor will be processing events from.</param>
            /// <param name="checkpointManager">Responsible for the creation of checkpoints.</param>
            /// <param name="onInitialize">A callback action to be called on <see cref="InitializeAsync" />.</param>
            /// <param name="onClose">A callback action to be called on <see cref="CloseAsync" />.</param>
            /// <param name="onProcessEvents">A callback action to be called on <see cref="ProcessEventsAsync" />.</param>
            /// <param name="onProcessError">A callback action to be called on <see cref="ProcessErrorAsync" />.</param>
            ///
            public PartitionProcessor(PartitionContext partitionContext,
                                      CheckpointManager checkpointManager,
                                      Action<PartitionContext, CheckpointManager> onInitialize = null,
                                      Action<PartitionContext, CheckpointManager, PartitionProcessorCloseReason> onClose = null,
                                      Action<PartitionContext, CheckpointManager, IEnumerable<EventData>, CancellationToken> onProcessEvents = null,
                                      Action<PartitionContext, CheckpointManager, Exception, CancellationToken> onProcessError = null)
            {
                AssociatedPartitionContext = partitionContext;
                AssociatedCheckpointManager = checkpointManager;
                OnInitialize = onInitialize;
                OnClose = onClose;
                OnProcessEvents = onProcessEvents;
                OnProcessError = onProcessError;
            }

            /// <summary>
            ///   Initializes the partition processor.
            /// </summary>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public Task InitializeAsync()
            {
                OnInitialize?.Invoke(AssociatedPartitionContext, AssociatedCheckpointManager);
                return Task.CompletedTask;
            }

            /// <summary>
            ///   Closes the partition processor.
            /// </summary>
            ///
            /// <param name="reason">The reason why the partition processor is being closed.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public Task CloseAsync(PartitionProcessorCloseReason reason)
            {
                OnClose?.Invoke(AssociatedPartitionContext, AssociatedCheckpointManager, reason);
                return Task.CompletedTask;
            }

            /// <summary>
            ///   Processes a set of received <see cref="EventData" />.
            /// </summary>
            ///
            /// <param name="events">The received events to be processed.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  It's not used in this sample.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public Task ProcessEventsAsync(IEnumerable<EventData> events,
                                           CancellationToken cancellationToken)
            {
                OnProcessEvents?.Invoke(AssociatedPartitionContext, AssociatedCheckpointManager, events, cancellationToken);
                return Task.CompletedTask;
            }

            /// <summary>
            ///   Processes an unexpected exception thrown when <see cref="EventProcessor" /> is running.
            /// </summary>
            ///
            /// <param name="exception">The exception to be processed.  It's not used in this sample.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.  It's not used in this sample.</param>
            ///
            /// <returns>A task to be resolved on when the operation has completed.</returns>
            ///
            public Task ProcessErrorAsync(Exception exception,
                                          CancellationToken cancellationToken)
            {
                OnProcessError?.Invoke(AssociatedPartitionContext, AssociatedCheckpointManager, exception, cancellationToken);
                return Task.CompletedTask;
            }
        }
    }
}
