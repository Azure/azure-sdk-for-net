// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Allows the load balance update and ownership expiration time spans to be overridden
    ///   for testing purposes.
    /// </summary>
    ///
    public class MockEventProcessorClient : EventProcessorClient
    {
        /// <summary>A value used to override event processors' load balance update time span.</summary>
        public static readonly TimeSpan ShortLoadBalanceUpdate = TimeSpan.FromMilliseconds(100);

        /// <summary>A value used to override event processors' ownership expiration time span.</summary>
        public static readonly TimeSpan ShortOwnershipExpiration = TimeSpan.FromSeconds(3);

        /// <summary>A dictionary used to track calls to InitializeProcessingForPartitionAsync.</summary>
        public ConcurrentDictionary<string, int> initializeCalls = new ConcurrentDictionary<string, int>();

        /// <summary>A dictionary used to track calls to ProcessEventAsync.</summary>
        public ConcurrentDictionary<string, EventData[]> processEventCalls = new ConcurrentDictionary<string, EventData[]>();

        /// <summary>A dictionary used to track calls to ProcessingForPartitionStoppedAsync.</summary>
        public ConcurrentDictionary<string, int> closeCalls = new ConcurrentDictionary<string, int>();

        /// <summary>A dictionary used to track ProcessingStoppedReasons for calls to ProcessingForPartitionStoppedAsync.</summary>
        public ConcurrentDictionary<string, ProcessingStoppedReason> stopReasons = new ConcurrentDictionary<string, ProcessingStoppedReason>();

        /// <summary>A dictionary used to track calls to ProcessExceptionAsync.</summary>
        public ConcurrentDictionary<string, Exception[]> exceptionCalls = new ConcurrentDictionary<string, Exception[]>();

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

        private readonly PartitionManager Manager;

        private readonly EventHubConnection Connection;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ShortWaitTimeMock"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this event processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="connection">The client used to interact with the Azure Event Hubs service.</param>
        /// <param name="options">The set of options to use for this event processor.</param>
        ///
        public MockEventProcessorClient(string consumerGroup,
                                 PartitionManager partitionManager,
                                 EventHubConnection connection,
                                 EventProcessorClientOptions options) : base(consumerGroup, partitionManager, connection, options)
        {
            Manager = partitionManager;
            Connection = connection;

            ProcessExceptionAsync = async errorContext =>
            {
                Exception[] newException = new Exception[] { errorContext.ProcessorException };
                exceptionCalls.AddOrUpdate(
                    errorContext.PartitionId,
                    newException,
                    (partitionId, value) => value.Concat(newException).ToArray());
                await Task.Delay(1);
            };

            ProcessEventAsync = async processorEvent =>
            {
                EventData[] newEvent = new EventData[] { processorEvent.Data };
                processEventCalls.AddOrUpdate(
                    processorEvent.Context.PartitionId,
                    newEvent,
                    (partitionId, value) => value.Concat(newEvent).ToArray());
                await Task.Delay(1);
            };

            InitializeProcessingForPartitionAsync = async initializationContext =>
            {
                initializeCalls.AddOrUpdate(initializationContext.Context.PartitionId, 1, (partitionId, value) => value + 1);
                await Task.Delay(1);
            };

            ProcessingForPartitionStoppedAsync = async stopContext =>
            {
                closeCalls.AddOrUpdate(stopContext.Context.PartitionId, 1, (partitionId, value) => value + 1);
                stopReasons[stopContext.Context.PartitionId] = stopContext.Reason;
                await Task.Delay(1);
            };
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

            CancellationToken timeoutToken = (new CancellationTokenSource(TimeSpan.FromSeconds(5))).Token;

            while (!stabilizedStatusAchieved)
            {
                // Remember to filter expired ownership.

                var activeOwnership = (await Manager
                    .ListOwnershipAsync(Connection.FullyQualifiedNamespace, Connection.EventHubName, ConsumerGroup)
                    .ConfigureAwait(false))
                    .Where(ownership => DateTimeOffset.UtcNow.Subtract(ownership.LastModifiedTime.Value) < ShortOwnershipExpiration)
                    .ToList();

                // Increment stabilized status count if current partition distribution matches the previous one.  Reset it
                // otherwise.

                if (EventProcessorManager.AreOwnershipDistributionsTheSame(previousActiveOwnership, activeOwnership))
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

                    await Task.Delay(ShortLoadBalanceUpdate, timeoutToken);
                }
                else
                {
                    // We'll consider the load stabilized only if its status doesn't change after 10 verifications.

                    stabilizedStatusAchieved = true;
                }
            }
        }
    }
}
