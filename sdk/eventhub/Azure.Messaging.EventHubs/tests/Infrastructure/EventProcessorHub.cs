// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Processor;
using System;
using System.Collections.Concurrent;
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
        private List<EventProcessor> EventProcessors { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        public ConcurrentDictionary<string, int> EventsCount { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        public ConcurrentDictionary<string, int> PartitionDistribution { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        public ConcurrentDictionary<string, PartitionProcessorCloseReason> CloseReason { get; }

        /// <summary>
        ///    TODO.
        /// </summary>
        ///
        public EventProcessorHub(string consumerGroup,
                                 EventHubClient client,
                                 int eventProcessorCount = 1)
        {
            Func<PartitionContext, CheckpointManager, IPartitionProcessor> factory =
                (partitionContext, checkpointManager) =>
                {
                    return new PartitionProcessor(this, partitionContext.PartitionId);
                };

            var partitionManager = new InMemoryPartitionManager();

            var options = new EventProcessorOptions { MaximumReceiveWaitTime = TimeSpan.FromSeconds(2) };

            EventProcessors = new List<EventProcessor>();

            for (int i = 0; i < eventProcessorCount; i++)
            {
                EventProcessors.Add
                (
                    new EventProcessor(consumerGroup,
                        client,
                        factory,
                        partitionManager,
                        options
                ));
            }

            EventsCount = new ConcurrentDictionary<string, int>();
            PartitionDistribution = new ConcurrentDictionary<string, int>();
            CloseReason = new ConcurrentDictionary<string, PartitionProcessorCloseReason>();
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
            private EventProcessorHub Hub;

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            private string PartitionId { get; }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public PartitionProcessor(EventProcessorHub hub, string partitionId)
            {
                Hub = hub;
                PartitionId = partitionId;
            }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public Task InitializeAsync()
            {
                // If key already exists, the original value won't be overwritten.

                Hub.EventsCount.TryAdd(PartitionId, 0);

                return Task.CompletedTask;
            }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public Task CloseAsync(PartitionProcessorCloseReason reason)
            {
                Hub.CloseReason[PartitionId] = reason;

                return Task.CompletedTask;
            }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public Task ProcessEventsAsync(IEnumerable<EventData> events,
                                           CancellationToken cancellationToken)
            {
                if (events.Count() > 0)
                {
                    var existingValue = Hub.EventsCount[PartitionId];
                    Hub.EventsCount.TryUpdate(PartitionId, existingValue + events.Count(), existingValue);
                }

                return Task.CompletedTask;
            }

            /// <summary>
            ///    TODO.
            /// </summary>
            ///
            public Task ProcessErrorAsync(Exception exception,
                                          CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
