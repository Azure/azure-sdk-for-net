// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Constantly receives <see cref="EventData" /> from every partition in the context of a given consumer group.
    ///   The received data is sent to an <see cref="IPartitionProcessor" /> to be processed.
    /// </summary>
    ///
    public class EventProcessor
    {
        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim RunningTaskSemaphore = new SemaphoreSlim(1, 1);

        /// <summary>TODO.</summary>
        protected virtual int LoopTimeInMilliseconds => 10000;

        /// <summary>TODO.</summary>
        protected virtual int ExpirationTimeInMilliseconds => 30000;

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        public string Identifier { get; }

        /// <summary>
        ///   The client used to interact with the Azure Event Hubs service.
        /// </summary>
        ///
        private EventHubClient InnerClient { get; }

        /// <summary>
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   A factory used to create partition processors.
        /// </summary>
        ///
        private Func<PartitionContext, CheckpointManager, IPartitionProcessor> PartitionProcessorFactory { get; }

        /// <summary>
        ///   Interacts with the storage system, dealing with ownership and checkpoints.
        /// </summary>
        ///
        private PartitionManager Manager { get; }

        /// <summary>
        ///   The set of options to use for this event processor.
        /// </summary>
        ///
        private EventProcessorOptions Options { get; }

        /// <summary>
        ///   A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the current running task.
        /// </summary>
        ///
        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        /// <summary>
        ///   The set of partition pumps used by this event processor.  Partition ids are used as keys.
        /// </summary>
        ///
        private ConcurrentDictionary<string, PartitionPump> PartitionPumps { get; }

        /// <summary>
        ///   TODO. (avoid stealing back)
        /// </summary>
        ///
        private ConcurrentDictionary<string, PartitionOwnership> InstanceOwnership { get; }

        /// <summary>
        ///   The running task responsible for checking the status of the owned partition pumps.
        /// </summary>
        ///
        private Task RunningTask { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this event processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="eventHubClient">The client used to interact with the Azure Event Hubs service.</param>
        /// <param name="partitionProcessorFactory">Creates an instance of a class implementing the <see cref="IPartitionProcessor" /> interface.</param>
        /// <param name="partitionManager">Interacts with the storage system, dealing with ownership and checkpoints.</param>
        /// <param name="options">The set of options to use for this event processor.</param>
        ///
        /// <remarks>
        ///   Ownership of the <paramref name="eventHubClient" /> is assumed to be responsibility of the caller; this
        ///   processor will delegate operations to it, but will not perform any clean-up tasks, such as closing or
        ///   disposing of the instance.
        /// </remarks>
        ///
        public EventProcessor(string consumerGroup,
                              EventHubClient eventHubClient,
                              Func<PartitionContext, CheckpointManager, IPartitionProcessor> partitionProcessorFactory,
                              PartitionManager partitionManager,
                              EventProcessorOptions options = default)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(consumerGroup), consumerGroup);
            Guard.ArgumentNotNull(nameof(eventHubClient), eventHubClient);
            Guard.ArgumentNotNull(nameof(partitionProcessorFactory), partitionProcessorFactory);
            Guard.ArgumentNotNull(nameof(partitionManager), partitionManager);

            InnerClient = eventHubClient;
            ConsumerGroup = consumerGroup;
            PartitionProcessorFactory = partitionProcessorFactory;
            Manager = partitionManager;
            Options = options?.Clone() ?? new EventProcessorOptions();

            Identifier = Guid.NewGuid().ToString();
            PartitionPumps = new ConcurrentDictionary<string, PartitionPump>();
            InstanceOwnership = new ConcurrentDictionary<string, PartitionOwnership>();
        }

        /// <summary>
        ///   Starts the event processor.  In case it's already running, nothing happens.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task StartAsync()
        {
            if (RunningTask == null)
            {
                await RunningTaskSemaphore.WaitAsync().ConfigureAwait(false);

                try
                {
                    if (RunningTask == null)
                    {
                        RunningTaskTokenSource?.Cancel();
                        RunningTaskTokenSource = new CancellationTokenSource();

                        // TODO: shouldn't we stop everything safely instead of clearing it?

                        PartitionPumps.Clear();

                        RunningTask = RunAsync(RunningTaskTokenSource.Token);
                    }
                }
                finally
                {
                    RunningTaskSemaphore.Release();
                }
            }
        }

        /// <summary>
        ///   Stops the event processor.  In case it hasn't been started, nothing happens.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task StopAsync()
        {
            if (RunningTask != null)
            {
                await RunningTaskSemaphore.WaitAsync().ConfigureAwait(false);

                try
                {
                    if (RunningTask != null)
                    {
                        RunningTaskTokenSource.Cancel();
                        RunningTaskTokenSource = null;

                        try
                        {
                            await RunningTask.ConfigureAwait(false);
                        }
                        finally
                        {
                            RunningTask = null;
                        }

                        var ownedPartitionIds = PartitionPumps.Keys;

                        await Task.WhenAll(ownedPartitionIds
                            .Select(partitionId => RemovePartitionPumpIfItExistsAsync(partitionId, PartitionProcessorCloseReason.Shutdown)))
                            .ConfigureAwait(false);

                        InstanceOwnership.Clear();
                    }
                }
                finally
                {
                    RunningTaskSemaphore.Release();
                }
            }
        }

        /// <summary>
        ///   The main loop of an event processor.  It loops through every owned <see cref="PartitionPump" />, checking
        ///   its status and creating a new one if necessary.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <remarks>
        ///   The actual goal of this method is to perform load balancing between multiple <see cref="EventProcessor" />
        ///   instances, but this feature is currently out of the scope of the current preview.
        /// </remarks>
        ///
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            Random random = new Random();

            while (!cancellationToken.IsCancellationRequested)
            {
                // Renew ownership.

                await RenewOwnershipAsync();

                // Remove lost partitions.

                await Task.WhenAll(PartitionPumps.Keys
                    .Except(InstanceOwnership.Keys)
                    .Select(partitionId => RemovePartitionPumpIfItExistsAsync(partitionId, PartitionProcessorCloseReason.OwnershipLost)));

                // Restart failed pumps.

                await Task.WhenAll(PartitionPumps
                    .Where(kvp => !kvp.Value.IsRunning)
                    .Select(kvp => AddOrOverwritePartitionPumpAsync(kvp.Key)));

                var partitionIds = await InnerClient.GetPartitionIdsAsync().ConfigureAwait(false);

                var ownershipList = (await Manager.ListOwnershipAsync(InnerClient.EventHubName, ConsumerGroup).ConfigureAwait(false)).ToList();
                var activeOwnership = ownershipList
                    .Where(ownership => DateTimeOffset.UtcNow.Subtract(ownership.LastModifiedTime.Value).TotalSeconds < ExpirationTimeInMilliseconds)
                    .ToList();

                var partitionDistribution = new Dictionary<string, int>
                {
                    { Identifier, 0 }
                };

                foreach (var ownership in activeOwnership)
                {
                    if (partitionDistribution.TryGetValue(ownership.OwnerIdentifier, out var value))
                    {
                        partitionDistribution[ownership.OwnerIdentifier] = value + 1;
                    }
                    else
                    {
                        partitionDistribution[ownership.OwnerIdentifier] = 1;
                    }
                }

                // eventProcessorsCount guaranteed to be > 0

                var minimumPartitionCount = partitionIds.Length / partitionDistribution.Keys.Count;
                var ownedPartitions = partitionDistribution[Identifier];

                if (ownedPartitions < minimumPartitionCount ||
                    ownedPartitions == minimumPartitionCount && !partitionDistribution.Any(kvp => kvp.Value < minimumPartitionCount))
                {
                    var unclaimedPartitions = new List<string>();

                    if (activeOwnership.Count < partitionIds.Length)
                    {
                        unclaimedPartitions = partitionIds
                            .Where(partitionId => !activeOwnership.Any(ownership => ownership.PartitionId == partitionId))
                            .ToList();
                    }

                    if (unclaimedPartitions.Count > 0)
                    {
                        var index = random.Next(unclaimedPartitions.Count);
                        var expiredOwnership = ownershipList.Where(ownership => ownership.PartitionId == unclaimedPartitions[index]);
                        var eTag = expiredOwnership.FirstOrDefault()?.ETag;

                        var claimedOwnership = await ClaimOwnershipAsync(unclaimedPartitions[index], ownershipList).ConfigureAwait(false);

                        if (claimedOwnership != null)
                        {
                            InstanceOwnership[claimedOwnership.PartitionId] = claimedOwnership;
                            await AddOrOverwritePartitionPumpAsync(claimedOwnership.PartitionId);
                        }
                    }
                    else if (ownedPartitions < minimumPartitionCount)
                    {
                        // TODO: other case should steal as well (n, ..., n, n+1, ..., n+1, n+2)

                        var stealableOwnership = activeOwnership
                            .Where(ownership => partitionDistribution[ownership.OwnerIdentifier] > minimumPartitionCount + 1)
                            .ToList();

                        if (stealableOwnership.Count == 0)
                        {
                            stealableOwnership = activeOwnership
                                .Where(ownership => partitionDistribution[ownership.OwnerIdentifier] == minimumPartitionCount + 1)
                                .ToList();
                        }

                        if (stealableOwnership.Count > 0)
                        {
                            var index = random.Next(stealableOwnership.Count);
                            var claimedOwnership = await ClaimOwnershipAsync(stealableOwnership[index].PartitionId, ownershipList).ConfigureAwait(false);

                            if (claimedOwnership != null)
                            {
                                InstanceOwnership[claimedOwnership.PartitionId] = claimedOwnership;
                                await AddOrOverwritePartitionPumpAsync(claimedOwnership.PartitionId);
                            }
                        }
                    }
                }

                try
                {
                    // Wait 10 seconds before the next verification.

                    await Task.Delay(LoopTimeInMilliseconds, cancellationToken).ConfigureAwait(false);
                }
                catch (TaskCanceledException) { }
            }
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task AddOrOverwritePartitionPumpAsync(string partitionId)
        {
            await RemovePartitionPumpIfItExistsAsync(partitionId).ConfigureAwait(false);

            var partitionContext = new PartitionContext(InnerClient.EventHubName, ConsumerGroup, partitionId);
            var checkpointManager = new CheckpointManager(partitionContext, Manager, Identifier);

            try
            {
                var partitionProcessor = PartitionProcessorFactory(partitionContext, checkpointManager);
                var partitionPump = new PartitionPump(InnerClient, ConsumerGroup, partitionId, partitionProcessor, Options);

                await partitionPump.StartAsync().ConfigureAwait(false);

                PartitionPumps[partitionId] = partitionPump;
            }
            catch (Exception)
            {
                // If partition pump creation fails, we'll try again on the next time this method is called.  This should happen
                // on the next event processor main loop as long as this instance still owns the partition.
                // TODO: delegate the exception handling to an Exception Callback.
            }
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        /// <returns>TODO.</returns>
        ///
        private async Task RemovePartitionPumpIfItExistsAsync(string partitionId, PartitionProcessorCloseReason? reason = null)
        {
            if (PartitionPumps.TryRemove(partitionId, out var pump))
            {
                try
                {
                    await pump.StopAsync(reason).ConfigureAwait(false);
                }
                catch (Exception)
                {
                    // TODO: delegate the exception handling to an Exception Callback.
                }
            }
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        /// <returns>TODO.</returns>
        ///
        private async Task<PartitionOwnership> ClaimOwnershipAsync(string partitionId, List<PartitionOwnership> completeOwnershipList)
        {
            var oldOwnership = completeOwnershipList.FirstOrDefault(ownership => ownership.PartitionId == partitionId);

            var newOwnership = new PartitionOwnership
                (
                    InnerClient.EventHubName,
                    ConsumerGroup,
                    Identifier,
                    partitionId,
                    oldOwnership?.Offset,
                    oldOwnership?.SequenceNumber,
                    DateTimeOffset.UtcNow,
                    oldOwnership?.ETag
                );

            var claimedOwnership = (await Manager
                .ClaimOwnershipAsync(new List<PartitionOwnership> { newOwnership })
                .ConfigureAwait(false));

            return claimedOwnership.FirstOrDefault();
        }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        /// <returns>TODO.</returns>
        ///
        private async Task RenewOwnershipAsync()
        {
            var ownershipToRenew = InstanceOwnership.Values
                .Select(ownership => new PartitionOwnership
                (
                    ownership.EventHubName,
                    ownership.ConsumerGroup,
                    ownership.OwnerIdentifier,
                    ownership.PartitionId,
                    ownership.Offset,
                    ownership.SequenceNumber,
                    DateTimeOffset.UtcNow,
                    ownership.ETag
                ));

            var renewedOwnership = (await Manager
                .ClaimOwnershipAsync(ownershipToRenew)
                .ConfigureAwait(false))
                .ToDictionary(ownership => ownership.PartitionId);

            InstanceOwnership.Clear();

            foreach (var partitionId in renewedOwnership.Keys)
            {
                InstanceOwnership[partitionId] = renewedOwnership[partitionId];
            }
        }
    }
}
