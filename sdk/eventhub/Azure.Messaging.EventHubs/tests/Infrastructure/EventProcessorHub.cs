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
    ///    TODO.
    /// </summary>
    ///
    internal class EventProcessorHub
    {
        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        private Func<PartitionContext, CheckpointManager, IPartitionProcessor> PartitionProcessorFactory { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        private EventHubClient InnerClient { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        private PartitionManager InnerPartitionManager { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        private EventProcessorOptions Options { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        private List<EventProcessor> EventProcessors { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        public EventProcessorHub(string consumerGroup,
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
        ///    TODO.
        /// </summary>
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
        ///    TODO.
        /// </summary>
        ///
        public Task StartAllAsync()
        {
            return Task.WhenAll(EventProcessors
                .Select(eventProcessor => eventProcessor.StartAsync()));
        }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        public Task StopAllAsync()
        {
            return Task.WhenAll(EventProcessors
                .Select(eventProcessor => eventProcessor.StopAsync()));
        }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        private class PartitionProcessor : IPartitionProcessor
        {
            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            private PartitionContext AssociatedPartitionContext { get; }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            private CheckpointManager CheckpointManagerReference { get; }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            private Action<PartitionContext, CheckpointManager> OnInitialize { get; }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            private Action<PartitionContext, CheckpointManager, PartitionProcessorCloseReason> OnClose { get; }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            private Action<PartitionContext, CheckpointManager, IEnumerable<EventData>, CancellationToken> OnProcessEvents { get; }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            private Action<PartitionContext, CheckpointManager, Exception, CancellationToken> OnProcessError { get; }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public PartitionProcessor(PartitionContext partitionContext,
                                      CheckpointManager checkpointManager,
                                      Action<PartitionContext, CheckpointManager> onInitialize = null,
                                      Action<PartitionContext, CheckpointManager, PartitionProcessorCloseReason> onClose = null,
                                      Action<PartitionContext, CheckpointManager, IEnumerable<EventData>, CancellationToken> onProcessEvents = null,
                                      Action<PartitionContext, CheckpointManager, Exception, CancellationToken> onProcessError = null)
            {
                AssociatedPartitionContext = partitionContext;
                CheckpointManagerReference = checkpointManager;
                OnInitialize = onInitialize;
                OnClose = onClose;
                OnProcessEvents = onProcessEvents;
                OnProcessError = onProcessError;
            }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public Task InitializeAsync()
            {
                OnInitialize?.Invoke(AssociatedPartitionContext, CheckpointManagerReference);
                return Task.CompletedTask;
            }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public Task CloseAsync(PartitionProcessorCloseReason reason)
            {
                OnClose?.Invoke(AssociatedPartitionContext, CheckpointManagerReference, reason);
                return Task.CompletedTask;
            }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public Task ProcessEventsAsync(IEnumerable<EventData> events,
                                           CancellationToken cancellationToken)
            {
                OnProcessEvents?.Invoke(AssociatedPartitionContext, CheckpointManagerReference, events, cancellationToken);
                return Task.CompletedTask;
            }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public Task ProcessErrorAsync(Exception exception,
                                          CancellationToken cancellationToken)
            {
                OnProcessError?.Invoke(AssociatedPartitionContext, CheckpointManagerReference, exception, cancellationToken);
                return Task.CompletedTask;
            }
        }
    }
}
