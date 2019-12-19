// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Tests;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   Provides an easy way to instantiate, start and stop multiple event processors.
    /// </summary>
    ///
    internal class EventProcessorManager
    {
        /// <summary>
        ///   The fully qualified Event Hubs namespace that the processor is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that the processor is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group the event processors are associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   A factory used to provide new <see cref="EventHubConnection" /> instances.
        /// </summary>
        ///
        private Func<EventHubConnection> ConnectionFactory { get; }

        /// <summary>
        ///   The partition manager shared by all event processors in this hub.
        /// </summary>
        ///
        private PartitionManager InnerPartitionManager { get; }

        /// <summary>
        ///   The set of options to use for the event processors.
        /// </summary>
        ///
        private EventProcessorClientOptions ClientOptions { get; }

        /// <summary>
        ///   The event processors managed by this hub.
        /// </summary>
        ///
        private List<EventProcessorClient> EventProcessors { get; }

        /// <summary>
        ///   A callback action to be called on <see cref="EventProcessorClient.PartitionInitializingAsync" />.
        /// </summary>
        ///
        private Action<PartitionInitializingEventArgs> OnInitialize { get; }

        /// <summary>
        ///   A callback action to be called on <see cref="EventProcessorClient.PartitionClosingAsync" />.
        /// </summary>
        ///
        private Action<PartitionClosingEventArgs> OnStop { get; }

        /// <summary>
        ///   A callback action to be called on <see cref="EventProcessorClient.ProcessEventAsync" />.
        /// </summary>
        ///
        private Action<ProcessEventArgs> OnProcessEvent { get; }

        /// <summary>
        ///   A callback action to be called on <see cref="EventProcessorClient.ProcessErrorAsync" />.
        /// </summary>
        ///
        private Action<ProcessErrorEventArgs> OnProcessError { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorManager"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group the event processors are associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="clientOptions">The set of options to use for the event processors.</param>
        /// <param name="onInitialize">A callback action to be called on <see cref="EventProcessorClient.PartitionInitializingAsync" />.</param>
        /// <param name="onStop">A callback action to be called on <see cref="EventProcessorClient.PartitionClosingAsync" />.</param>
        /// <param name="onProcessEvent">A callback action to be called on <see cref="EventProcessorClient.ProcessEventAsync" />.</param>
        /// <param name="onProcessError">A callback action to be called on <see cref="EventProcessorClient.ProcessErrorAsync" />.</param>
        ///
        public EventProcessorManager(string consumerGroup,
                                     string connectionString,
                                     PartitionManager partitionManager = null,
                                     EventProcessorClientOptions clientOptions = null,
                                     Action<PartitionInitializingEventArgs> onInitialize = null,
                                     Action<PartitionClosingEventArgs> onStop = null,
                                     Action<ProcessEventArgs> onProcessEvent = null,
                                     Action<ProcessErrorEventArgs> onProcessError = null)
        {
            ConnectionStringProperties connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            FullyQualifiedNamespace = connectionStringProperties.Endpoint.Host;
            EventHubName = connectionStringProperties.EventHubName;
            ConsumerGroup = consumerGroup;
            ConnectionFactory = () => new EventHubConnection(connectionString);
            InnerPartitionManager = partitionManager ?? new MockCheckPointStorage();

            // In case it has not been specified, set the maximum wait time to 2 seconds because the default
            // value (1 minute) would take too much time.

            ClientOptions = clientOptions?.Clone() ?? new EventProcessorClientOptions();

            if (ClientOptions.MaximumWaitTime == null)
            {
                ClientOptions.MaximumWaitTime = TimeSpan.FromSeconds(2);
            }

            OnInitialize = onInitialize;
            OnStop = onStop;
            OnProcessEvent = onProcessEvent;
            OnProcessError = onProcessError;

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
                        InnerPartitionManager,
                        ConsumerGroup,
                        FullyQualifiedNamespace,
                        EventHubName,
                        ConnectionFactory,
                        ClientOptions
                    );

                if (OnInitialize != null)
                {
                    eventProcessor.PartitionInitializingAsync += eventArgs =>
                    {
                        OnInitialize(eventArgs);
                        return Task.CompletedTask;
                    };
                }

                if (OnStop != null)
                {
                    eventProcessor.PartitionClosingAsync += eventArgs =>
                    {
                        OnStop(eventArgs);
                        return Task.CompletedTask;
                    };
                }

                eventProcessor.ProcessEventAsync += eventArgs =>
                {
                    OnProcessEvent?.Invoke(eventArgs);
                    return Task.CompletedTask;
                };

                eventProcessor.ProcessErrorAsync += eventArgs =>
                {
                    OnProcessError?.Invoke(eventArgs);
                    return Task.CompletedTask;
                };

                EventProcessors.Add(eventProcessor);
            }
        }

        /// <summary>
        ///   Starts the event processors.
        /// </summary>
        ///
        public Task StartAllAsync()
        {
            return Task.WhenAll(EventProcessors
                .Select(eventProcessor => eventProcessor.StartProcessingAsync()));
        }

        /// <summary>
        ///   Stops the event processors.
        /// </summary>
        ///
        public Task StopAllAsync()
        {
            return Task.WhenAll(EventProcessors
                .Select(eventProcessor => eventProcessor.StopProcessingAsync()));
        }

        /// <summary>
        ///   Waits until the partition load distribution is stabilized.  Throws an <see cref="OperationCanceledException"/>
        ///   if the load takes too long to stabilize.
        /// </summary>
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
                    .ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, timeoutToken)
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
            public static readonly TimeSpan ShortLoadBalanceUpdate = TimeSpan.FromSeconds(1);
            public static readonly TimeSpan ShortOwnershipExpiration = TimeSpan.FromSeconds(3);

            public ShortWaitTimeMock(PartitionManager partitionManager,
                                     string consumerGroup,
                                     string fullyQualifiedNamespace,
                                     string eventHubName,
                                     Func<EventHubConnection> connectionFactory,
                                     EventProcessorClientOptions clientOptions) : base(partitionManager, consumerGroup, fullyQualifiedNamespace, eventHubName, connectionFactory, clientOptions)
            {
            }
        }
    }
}
