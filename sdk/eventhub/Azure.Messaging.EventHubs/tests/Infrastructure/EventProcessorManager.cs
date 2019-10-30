// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        ///   The name of the consumer group the event processors are associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.
        /// </summary>
        ///
        private EventHubConnection Connection { get; }

        /// <summary>
        ///   The partition manager shared by all event processors in this hub.
        /// </summary>
        ///
        private PartitionManager InnerPartitionManager { get; }

        /// <summary>
        ///   The set of options to use for the event processors.
        /// </summary>
        ///
        private EventProcessorClientOptions Options { get; }

        /// <summary>
        ///   The event processors managed by this hub.
        /// </summary>
        ///
        private List<EventProcessorClient> EventProcessors { get; }

        /// <summary>
        ///   A callback action to be called on <see cref="EventProcessorClient.InitializeProcessingForPartitionAsync" />.
        /// </summary>
        ///
        private Action<PartitionContext> OnInitialize { get; }

        /// <summary>
        ///   A callback action to be called on <see cref="EventProcessorClient.ProcessingForPartitionStoppedAsync" />.
        /// </summary>
        ///
        private Action<PartitionContext, PartitionProcessorCloseReason> OnClose { get; }

        /// <summary>
        ///   A callback action to be called on <see cref="EventProcessorClient.ProcessEventsAsync" />.
        /// </summary>
        ///
        private Action<PartitionContext, IEnumerable<EventData>> OnProcessEvents { get; }

        /// <summary>
        ///   A callback action to be called on <see cref="EventProcessorClient.ProcessExceptionAsync" />.
        /// </summary>
        ///
        private Action<PartitionContext, Exception> OnProcessException { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorManager"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group the event processors are associated with.  Events are read in the context of this group.</param>
        /// <param name="client">The client used to interact with the Azure Event Hubs service.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="options">The set of options to use for the event processors.</param>
        /// <param name="onInitialize">A callback action to be called on <see cref="EventProcessorClient.InitializeProcessingForPartitionAsync" />.</param>
        /// <param name="onClose">A callback action to be called on <see cref="EventProcessorClient.ProcessingForPartitionStoppedAsync" />.</param>
        /// <param name="onProcessEvents">A callback action to be called on <see cref="EventProcessorClient.ProcessEventsAsync" />.</param>
        /// <param name="onProcessException">A callback action to be called on <see cref="EventProcessorClient.ProcessExceptionAsync" />.</param>
        ///
        public EventProcessorManager(string consumerGroup,
                                     EventHubConnection client,
                                     PartitionManager partitionManager = null,
                                     EventProcessorClientOptions options = null,
                                     Action<PartitionContext> onInitialize = null,
                                     Action<PartitionContext, PartitionProcessorCloseReason> onClose = null,
                                     Action<PartitionContext, IEnumerable<EventData>> onProcessEvents = null,
                                     Action<PartitionContext, Exception> onProcessException = null)
        {
            ConsumerGroup = consumerGroup;
            Connection = client;

            InnerPartitionManager = partitionManager ?? new InMemoryPartitionManager();

            // In case it has not been specified, set the maximum receive wait time to 2 seconds because the default
            // value (1 minute) would take too much time.

            Options = options?.Clone() ?? new EventProcessorClientOptions();

            if (Options.MaximumReceiveWaitTime == null)
            {
                Options.MaximumReceiveWaitTime = TimeSpan.FromSeconds(2);
            }

            OnInitialize = onInitialize;
            OnClose = onClose;
            OnProcessEvents = onProcessEvents;
            OnProcessException = onProcessException;

            EventProcessors = new List<EventProcessorClient>();
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
                var eventProcessor = new ShortWaitTimeMock
                    (
                        ConsumerGroup,
                        InnerPartitionManager,
                        Connection,
                        Options
                    );

                if (OnInitialize != null)
                {
                    eventProcessor.InitializeProcessingForPartitionAsync = (partitionContext) =>
                    {
                        OnInitialize(partitionContext);
                        return Task.CompletedTask;
                    };
                }

                if (OnClose != null)
                {
                    eventProcessor.ProcessingForPartitionStoppedAsync = (partitionContext, reason) =>
                    {
                        OnClose(partitionContext, reason);
                        return Task.CompletedTask;
                    };
                }

                eventProcessor.ProcessEventsAsync = (partitionContext, events) =>
                {
                    OnProcessEvents?.Invoke(partitionContext, events);
                    return Task.CompletedTask;
                };

                eventProcessor.ProcessExceptionAsync = (partitionContext, exception) =>
                {
                    OnProcessException?.Invoke(partitionContext, exception);
                    return Task.CompletedTask;
                };

                EventProcessors.Add(eventProcessor);
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
        ///   Waits until the partition load distribution is stabilized.  Throws an <see cref="OperationCanceledException"/>
        ///   if the load takes too long to stabilize.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task WaitStabilization()
        {
            var stabilizedStatusAchieved = false;
            var consecutiveStabilizedStatus = 0;
            List<PartitionOwnership> previousActiveOwnership = null;

            CancellationToken timeoutToken = (new CancellationTokenSource(TimeSpan.FromMinutes(1))).Token;

            while (!stabilizedStatusAchieved)
            {
                // Remember to filter expired ownership.

                var activeOwnership = (await InnerPartitionManager
                    .ListOwnershipAsync(Connection.FullyQualifiedNamespace, Connection.EventHubName, ConsumerGroup)
                    .ConfigureAwait(false))
                    .Where(ownership => DateTimeOffset.UtcNow.Subtract(ownership.LastModifiedTime.Value) < ShortWaitTimeMock.ShortOwnershipExpiration)
                    .ToList();

                // Increment stabilized status count if current partition distribution matches the previous one.  Reset it
                // otherwise.

                if (AreOwnershipDistributionsTheSame(previousActiveOwnership, activeOwnership))
                {
                    ++consecutiveStabilizedStatus;
                }
                else
                {
                    consecutiveStabilizedStatus = 1;
                }

                previousActiveOwnership = activeOwnership;

                if (consecutiveStabilizedStatus < 10)
                {
                    // Wait a load balance update cycle before the next verification.  Give up if the whole process takes more than 1 minute.

                    await Task.Delay(ShortWaitTimeMock.ShortLoadBalanceUpdate, timeoutToken);
                }
                else
                {
                    // We'll consider the load stabilized only if its status doesn't change after 10 verifications.

                    stabilizedStatusAchieved = true;
                }
            }
        }

        /// <summary>
        ///   Compares two ownership distributions among event processors to determine if they represent the same
        ///   distribution.
        /// </summary>
        ///
        /// <param name="first">The first distribution to consider.</param>
        /// <param name="second">The second distribution to consider.</param>
        ///
        /// <returns><c>true</c>, if there are no owner changes between distributions; otherwise, <c>false</c>.</returns>
        ///
        /// <remarks>
        ///   Filtering expired ownership is assumed to be responsibility of the caller.
        /// </remarks>
        ///
        private bool AreOwnershipDistributionsTheSame(IEnumerable<PartitionOwnership> first,
                                                      IEnumerable<PartitionOwnership> second)
        {
            // If the distributions are the same instance, they're equal.  This should only happen
            // if both are null or if they are the exact same instance.

            if (Object.ReferenceEquals(first, second))
            {
                return true;
            }

            // If one or the other is null, then they cannot be equal, since we know that
            // they are not both null.

            if ((first == null) || (second == null))
            {
                return false;
            }

            // If the owners of each partition are equal, the instances are equal.

            var firstOrderedDistribution = first.OrderBy(ownership => ownership.PartitionId).ToList();
            var secondOrderedDistribution = second.OrderBy(ownership => ownership.PartitionId).ToList();

            if (firstOrderedDistribution.Count != secondOrderedDistribution.Count)
            {
                return false;
            }

            for (var index = 0; index < firstOrderedDistribution.Count; ++index)
            {
                // We must check assert the partitions are the same as well, otherwise we might have matching
                // owners by chance.

                if (firstOrderedDistribution[index].PartitionId != secondOrderedDistribution[index].PartitionId)
                {
                    return false;
                }

                if (firstOrderedDistribution[index].OwnerIdentifier != secondOrderedDistribution[index].OwnerIdentifier)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///   Allows the load balance update and ownership expiration time spans to be overridden
        ///   for testing purposes.
        /// </summary>
        ///
        private class ShortWaitTimeMock : EventProcessorClient
        {
            /// <summary>A value used to override event processors' load balance update time span.</summary>
            public static readonly TimeSpan ShortLoadBalanceUpdate = TimeSpan.FromSeconds(1);

            /// <summary>A value used to override event processors' ownership expiration time span.</summary>
            public static readonly TimeSpan ShortOwnershipExpiration = TimeSpan.FromSeconds(3);

            /// <summary>
            ///   The minimum amount of time to be elapsed between two load balancing verifications.
            /// </summary>
            ///
            protected override TimeSpan LoadBalanceUpdate => ShortLoadBalanceUpdate;

            /// <summary>
            ///   The minimum amount of time for an ownership to be considered expired without further updates.
            /// </summary>
            ///
            protected override TimeSpan OwnershipExpiration => ShortOwnershipExpiration;

            /// <summary>
            ///   Initializes a new instance of the <see cref="ShortWaitTimeMock"/> class.
            /// </summary>
            ///
            /// <param name="consumerGroup">The name of the consumer group this event processor is associated with.  Events are read in the context of this group.</param>
            /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
            /// <param name="connection">The client used to interact with the Azure Event Hubs service.</param>
            /// <param name="options">The set of options to use for this event processor.</param>
            ///
            public ShortWaitTimeMock(string consumerGroup,
                                     PartitionManager partitionManager,
                                     EventHubConnection connection,
                                     EventProcessorClientOptions options) : base(consumerGroup, partitionManager, connection, options)
            {
            }
        }
    }
}
