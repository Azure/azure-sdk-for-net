// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    /// Handles PartitionOwnership management for an <see cref="EventProcessorClient" />.
    /// </summary>
    ///
    public class EventHubClientPartitionOwnershipManager
    {
        /// <summary>
        ///   The set of partition ownership this event processor owns.  Partition ids are used as keys.
        /// </summary>
        ///
        private Dictionary<string, PartitionOwnership> InstanceOwnership { get; set; }

        /// <summary>
        ///   Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.
        /// </summary>
        ///
        private PartitionManager Manager { get; }

        /// <summary>
        ///   A unique name used to identify the event processor owning this <see cref="EventHubClientPartitionOwnershipManager"/>.
        /// </summary>
        ///
        public string Identifier { get; }

        /// <summary>
        ///   The active connection to the Azure Event Hubs service, enabling client communications for metadata
        ///   about the associated Event Hub and access to transport-aware consumers.
        /// </summary>
        ///
        private EventHubConnection Connection { get; }

        /// <summary>
        ///   The active policy which governs retry attempts for the
        ///   processor.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The set of partition pumps used by this event processor.  Partition ids are used as keys.
        /// </summary>
        ///
        private ConcurrentDictionary<string, PartitionPump> PartitionPumps { get; }

        /// <summary>
        ///   The partition Ids for the partition pumps used by this event processor.  Partition ids are used as keys.
        /// </summary>
        ///
        public ICollection<string> PartitionPumpPartitionIds => PartitionPumps.Keys;

        /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The random number generator to use for a specific thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClientPartitionOwnershipManager"/> class.
        /// </summary>
        /// <param name="eventHubClientIdentifier">The unique identifier for the <see cref="EventProcessorClient" /> owning this instance.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="connection"></param>
        /// <param name="retyPolicy"></param>
        ///
        public EventHubClientPartitionOwnershipManager(string eventHubClientIdentifier, string consumerGroup, PartitionManager partitionManager, EventHubConnection connection, EventHubsRetryPolicy retyPolicy)
        {
            Argument.AssertNotNullOrEmpty(eventHubClientIdentifier, nameof(eventHubClientIdentifier));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(partitionManager, nameof(partitionManager));
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(retyPolicy, nameof(retyPolicy));

            this.Identifier = eventHubClientIdentifier;
            this.ConsumerGroup = consumerGroup;
            this.Manager = partitionManager;
            this.Connection = connection;
            this.RetryPolicy = retyPolicy;
            PartitionPumps = new ConcurrentDictionary<string, PartitionPump>();
            InstanceOwnership = new Dictionary<string, PartitionOwnership>();
        }

        /// <summary>
        ///   Renews this instance's ownership so they don't expire.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task RenewOwnershipAsync(Dictionary<string, PartitionOwnership> instanceOwnership)
        {
            IEnumerable<PartitionOwnership> ownershipToRenew = instanceOwnership.Values
                .Select(ownership => new PartitionOwnership
                (
                    ownership.FullyQualifiedNamespace,
                    ownership.EventHubName,
                    ownership.ConsumerGroup,
                    ownership.OwnerIdentifier,
                    ownership.PartitionId,
                    ownership.Offset,
                    ownership.SequenceNumber,
                    DateTimeOffset.UtcNow,
                    ownership.ETag
                ));

            // We cannot rely on the ownership returned by ClaimOwnershipAsync to update our InstanceOwnership dictionary.
            // If the user issues a checkpoint update, the associated ownership will have its eTag updated as well, so we
            // will fail in claiming it here, but this instance still owns it.

            return Manager.ClaimOwnershipAsync(ownershipToRenew);
        }

        /// <summary>
        ///   Finds and tries to claim an ownership if this <see cref="EventProcessorClient" /> instance is eligible to increase its ownership
        ///   list.
        /// </summary>
        ///
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the stored service provided by the user.</param>
        /// <param name="activeOwnership">The set of ownership that are still active.</param>
        ///
        /// <returns>The claimed ownership. <c>null</c> if this instance is not eligible, if no claimable ownership was found or if the claim attempt failed.</returns>
        ///
        public virtual async Task<PartitionOwnership> FindAndClaimOwnershipAsync(IEnumerable<PartitionOwnership> completeOwnershipEnumerable,
                                                                          IEnumerable<PartitionOwnership> activeOwnership)
        {
            // Get a complete list of the partition ids present in the Event Hub.  This should be immutable for the time being, but
            // it may change in the future.

            var partitionIds = await Connection.GetPartitionIdsAsync(RetryPolicy).ConfigureAwait(false);

            // Create a partition distribution dictionary from the active ownership list we have, mapping an owner's identifier to the amount of
            // partitions it owns.  When an event processor goes down and it has only expired ownership, it will not be taken into consideration
            // by others.

            var partitionDistribution = new Dictionary<string, int>
            {
                { Identifier, 0 }
            };

            foreach (PartitionOwnership ownership in activeOwnership)
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

            // The minimum owned partitions count is the minimum amount of partitions every event processor needs to own when the distribution
            // is balanced.  If n = minimumOwnedPartitionsCount, a balanced distribution will only have processors that own n or n + 1 partitions
            // each.  We can guarantee the partition distribution has at least one key, which corresponds to this event processor instance, even
            // if it owns no partitions.

            var minimumOwnedPartitionsCount = partitionIds.Length / partitionDistribution.Keys.Count;
            var ownedPartitionsCount = partitionDistribution[Identifier];

            // There are two possible situations in which we may need to claim a partition ownership.
            //
            // The first one is when we are below the minimum amount of owned partitions.  There's nothing more to check, as we need to claim more
            // partitions to enforce balancing.
            //
            // The second case is a bit tricky.  Sometimes the claim must be performed by an event processor that already has reached the minimum
            // amount of ownership.  This may happen, for instance, when we have 13 partitions and 3 processors, each of them owning 4 partitions.
            // The minimum amount of partitions per processor is, in fact, 4, but in this example we still have 1 orphan partition to claim.  To
            // avoid overlooking this kind of situation, we may want to claim an ownership when we have exactly the minimum amount of ownership,
            // but we are making sure there are no better candidates among the other event processors.

            if (ownedPartitionsCount < minimumOwnedPartitionsCount ||
                ownedPartitionsCount == minimumOwnedPartitionsCount && !partitionDistribution.Values.Any(partitions => partitions < minimumOwnedPartitionsCount))
            {
                // Look for unclaimed partitions.  If any, randomly pick one of them to claim.

                IEnumerable<string> unclaimedPartitions = partitionIds
                    .Except(activeOwnership.Select(ownership => ownership.PartitionId));

                if (unclaimedPartitions.Any())
                {
                    var index = RandomNumberGenerator.Value.Next(unclaimedPartitions.Count());

                    return await ClaimOwnershipAsync(unclaimedPartitions.ElementAt(index), completeOwnershipEnumerable).ConfigureAwait(false);
                }

                // Only try to steal partitions if there are no unclaimed partitions left.  At first, only processors that have exceeded the
                // maximum owned partition count should be targeted.

                var maximumOwnedPartitionsCount = minimumOwnedPartitionsCount + 1;

                IEnumerable<string> stealablePartitions = activeOwnership
                    .Where(ownership => partitionDistribution[ownership.OwnerIdentifier] > maximumOwnedPartitionsCount)
                    .Select(ownership => ownership.PartitionId);

                // Here's the important part.  If there are no processors that have exceeded the maximum owned partition count allowed, we may
                // need to steal from the processors that have exactly the maximum amount.  If this instance is below the minimum count, then
                // we have no choice as we need to enforce balancing.  Otherwise, leave it as it is because the distribution wouldn't change.

                if (!stealablePartitions.Any() && ownedPartitionsCount < minimumOwnedPartitionsCount)
                {
                    stealablePartitions = activeOwnership
                        .Where(ownership => partitionDistribution[ownership.OwnerIdentifier] == maximumOwnedPartitionsCount)
                        .Select(ownership => ownership.PartitionId);
                }

                // If any stealable partitions were found, randomly pick one of them to claim.

                if (stealablePartitions.Any())
                {
                    var index = RandomNumberGenerator.Value.Next(stealablePartitions.Count());

                    return await ClaimOwnershipAsync(stealablePartitions.ElementAt(index), completeOwnershipEnumerable).ConfigureAwait(false);
                }
            }

            // No ownership was claimed.

            return null;
        }

        /// <summary>
        ///   Tries to claim ownership of the specified partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the ownership is associated with.</param>
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the stored service provided by the user.</param>
        ///
        /// <returns>The claimed ownership. <c>null</c> if the claim attempt failed.</returns>
        ///
        private async Task<PartitionOwnership> ClaimOwnershipAsync(string partitionId,
                                                                   IEnumerable<PartitionOwnership> completeOwnershipEnumerable)
        {
            // We need the eTag from the most recent ownership of this partition, even if it's expired.  We want to keep the offset and
            // the sequence number as well.

            PartitionOwnership oldOwnership = completeOwnershipEnumerable.FirstOrDefault(ownership => ownership.PartitionId == partitionId);

            var newOwnership = new PartitionOwnership
                (
                    Connection.FullyQualifiedNamespace,
                    Connection.EventHubName,
                    ConsumerGroup,
                    Identifier,
                    partitionId,
                    oldOwnership?.Offset,
                    oldOwnership?.SequenceNumber,
                    DateTimeOffset.UtcNow,
                    oldOwnership?.ETag
                );

            // We are expecting an enumerable with a single element if the claim attempt succeeds.

            IEnumerable<PartitionOwnership> claimedOwnership = (await Manager
                .ClaimOwnershipAsync(new List<PartitionOwnership> { newOwnership })
                .ConfigureAwait(false));

            return claimedOwnership.FirstOrDefault();
        }

        /// <summary>
        ///   Creates and starts a new partition pump associated with the specified partition.  A partition pump might be overwritten by the creation
        ///   of the new one and, for this reason, it needs to be stopped prior to this method call.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the partition pump will be associated with.  Events will be read only from this partition.</param>
        /// <param name="initialSequenceNumber">The sequence number of the event within a partition where the partition pump should begin reading events.</param>
        /// <param name="InitializeProcessingForPartitionAsync">The handler to be called just before event processing starts for a given partition.</param>
        /// <param name="processEventAsync"></param>
        /// <param name="updateCheckpointAsync"></param>
        /// <param name="Options"></param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task AddPartitionPumpAsync(string partitionId,
                                                 long? initialSequenceNumber,
                                                 Func<InitializePartitionProcessingContext, ValueTask> InitializeProcessingForPartitionAsync,
                                                 Func<EventProcessorEvent, ValueTask> processEventAsync,
                                                 Func<EventData, PartitionContext, Task> updateCheckpointAsync,
                                                 EventProcessorClientOptions Options)
        {
            var partitionContext = new PartitionContext(partitionId);

            try
            {
                EventPosition? startingPosition = default;

                if (initialSequenceNumber.HasValue)
                {
                    startingPosition = EventPosition.FromSequenceNumber(initialSequenceNumber.Value, false);
                }

                if (InitializeProcessingForPartitionAsync != null)
                {
                    var initializationContext = new InitializePartitionProcessingContext(partitionContext);
                    await InitializeProcessingForPartitionAsync(initializationContext).ConfigureAwait(false);

                    startingPosition = startingPosition ?? initializationContext.DefaultStartingPosition;
                }

                var partitionPump = new PartitionPump(Connection, ConsumerGroup, partitionContext, startingPosition ?? EventPosition.Earliest, processEventAsync, updateCheckpointAsync, Options);

                await partitionPump.StartAsync().ConfigureAwait(false);

                PartitionPumps[partitionId] = partitionPump;
            }
            catch (Exception)
            {
                // If partition pump creation fails, we'll try again on the next time this method is called.  This should happen
                // on the next load balancing loop as long as this instance still owns the partition.
                // TODO: delegate the exception handling to an Exception Callback.
            }
        }

        /// <summary>
        ///   Stops an owned partition pump instance in case it exists.  It is also removed from the pumps dictionary.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the partition pump is associated with.</param>
        /// <param name="reason">The reason why the processing for the specified partition is being stopped.</param>
        /// <param name="processingForPartitionStoppedAsync"></param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task RemovePartitionPumpIfItExistsAsync(string partitionId,
                                                              ProcessingStoppedReason reason,
                                                              Func<PartitionProcessingStoppedContext, ValueTask> processingForPartitionStoppedAsync)
        {
            if (PartitionPumps.TryRemove(partitionId, out PartitionPump pump))
            {
                try
                {
                    await pump.StopAsync().ConfigureAwait(false);
                }
                catch (Exception)
                {
                    // TODO: delegate the exception handling to an Exception Callback.
                }

                if (processingForPartitionStoppedAsync != null)
                {
                    try
                    {
                        var partitionContext = new PartitionContext(partitionId);
                        var stopContext = new PartitionProcessingStoppedContext(partitionContext, reason);

                        await processingForPartitionStoppedAsync(stopContext);
                    }
                    catch (Exception)
                    {
                        // TODO: delegate the exception handling to an Exception Callback.
                    }
                }
            }
        }

        internal bool TryGetPartitionPump(string partitionId, out PartitionPump pump)
        {
            return PartitionPumps.TryGetValue(partitionId, out pump);
        }

        internal async Task StopAsync(Func<PartitionProcessingStoppedContext, ValueTask> processingForPartitionStoppedAsync)
        {
            // Now that the task has finished, clean up what is left.  Stop and remove every partition pump that is still
            // running and dispose of our ownership dictionary.

            InstanceOwnership = null;

            await Task.WhenAll(PartitionPumpPartitionIds
                .Select(partitionId => RemovePartitionPumpIfItExistsAsync(partitionId, ProcessingStoppedReason.Shutdown, processingForPartitionStoppedAsync)))
                .ConfigureAwait(false);
        }
    }
}