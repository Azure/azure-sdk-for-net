// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
