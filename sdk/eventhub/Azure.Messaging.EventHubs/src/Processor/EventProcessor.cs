// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Receives <see cref="EventData" /> as they are available for a partition, in the context of a consumer group, and routes
    ///   them to a partition processor instance to be processed.
    /// </summary>
    ///
    /// <typeparam name="T">The type of partition processor used by this instance by default; the type must be derived from <see cref="BasePartitionProcessor" /> and must have a parameterless constructor.</typeparam>
    ///
    public class EventProcessor<T> where T : BasePartitionProcessor, new()
    {
        /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The random number generator to use for a specific thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim RunningTaskSemaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        ///   The minimum amount of time to be elapsed between two load balancing verifications.
        /// </summary>
        ///
        protected virtual TimeSpan LoadBalanceUpdate => TimeSpan.FromSeconds(10);

        /// <summary>
        ///   The minimum amount of time for an ownership to be considered expired without further updates.
        /// </summary>
        ///
        protected virtual TimeSpan OwnershipExpiration => TimeSpan.FromSeconds(30);

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        public virtual string Identifier { get; }

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
        private Func<PartitionContext, BasePartitionProcessor> PartitionProcessorFactory { get; }

        /// <summary>
        ///   Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.
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
        ///   The set of partition ownership this event processor owns.  Partition ids are used as keys.
        /// </summary>
        ///
        private Dictionary<string, PartitionOwnership> InstanceOwnership { get; set; }

        /// <summary>
        ///   The running task responsible for performing partition load balancing between multiple <see cref="EventProcessor{T}" />
        ///   instances, as well as managing partition pumps and ownership.
        /// </summary>
        ///
        private Task RunningTask { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{T}"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this event processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="eventHubClient">The client used to interact with the Azure Event Hubs service.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
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
                              PartitionManager partitionManager,
                              EventProcessorOptions options = default) : this(consumerGroup, eventHubClient, partitionContext => new T(), partitionManager, options)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{T}"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this event processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="eventHubClient">The client used to interact with the Azure Event Hubs service.</param>
        /// <param name="partitionProcessorFactory">Creates a partition processor instance for the associated <see cref="PartitionContext" />.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
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
                              Func<PartitionContext, BasePartitionProcessor> partitionProcessorFactory,
                              PartitionManager partitionManager,
                              EventProcessorOptions options = default)
        {
            Argument.NotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.NotNull(eventHubClient, nameof(eventHubClient));
            Argument.NotNull(partitionProcessorFactory, nameof(partitionProcessorFactory));
            Argument.NotNull(partitionManager, nameof(partitionManager));

            InnerClient = eventHubClient;
            ConsumerGroup = consumerGroup;
            PartitionProcessorFactory = partitionProcessorFactory;
            Manager = partitionManager;
            Options = options?.Clone() ?? new EventProcessorOptions();

            Identifier = Guid.NewGuid().ToString();
            PartitionPumps = new ConcurrentDictionary<string, PartitionPump>();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{T}"/> class.
        /// </summary>
        ///
        protected EventProcessor()
        {
        }

        /// <summary>
        ///   Starts the event processor.  In case it's already running, nothing happens.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task StartAsync()
        {
            if (RunningTask == null)
            {
                await RunningTaskSemaphore.WaitAsync().ConfigureAwait(false);

                try
                {
                    if (RunningTask == null)
                    {
                        // We expect the token source to be null, but we are playing safe.

                        RunningTaskTokenSource?.Cancel();
                        RunningTaskTokenSource = new CancellationTokenSource();

                        // Initialize our empty ownership dictionary.

                        InstanceOwnership = new Dictionary<string, PartitionOwnership>();

                        // Start the main running task.  It is resposible for managing the partition pumps and for partition
                        // load balancing among multiple event processor instances.

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
        ///   Stops the event processor.  In case it isn't running, nothing happens.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task StopAsync()
        {
            if (RunningTask != null)
            {
                await RunningTaskSemaphore.WaitAsync().ConfigureAwait(false);

                try
                {
                    if (RunningTask != null)
                    {
                        // Cancel the current running task.

                        RunningTaskTokenSource.Cancel();
                        RunningTaskTokenSource = null;

                        // Now that a cancellation request has been issued, wait for the running task to finish.  In case something
                        // unexpected happened and it stopped working midway, this is the moment we expect to catch an exception.

                        try
                        {
                            await RunningTask.ConfigureAwait(false);
                        }
                        catch (TaskCanceledException)
                        {
                            // The running task has an inner delay that is likely to throw a TaskCanceledException upon token cancellation.
                            // The task might end up leaving its main loop gracefully by chance, so we won't necessarily reach this part of
                            // the code.
                        }
                        catch (Exception)
                        {
                            // TODO: delegate the exception handling to an Exception Callback.
                        }

                        RunningTask = null;

                        // Now that the task has finished, clean up what is left.  Stop and remove every partition pump that is still
                        // running and dispose of our ownership dictionary.

                        InstanceOwnership = null;

                        await Task.WhenAll(PartitionPumps.Keys
                            .Select(partitionId => RemovePartitionPumpIfItExistsAsync(partitionId, PartitionProcessorCloseReason.Shutdown)))
                            .ConfigureAwait(false);
                    }
                }
                finally
                {
                    RunningTaskSemaphore.Release();
                }
            }
        }

        /// <summary>
        ///   Performs load balancing between multiple <see cref="EventProcessor{T}" /> instances, claiming others' partitions to enforce
        ///   a more equal distribution when necessary.  It also manages its own partition pumps and ownership.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Stopwatch cycleDuration = Stopwatch.StartNew();

                // Renew this instance's ownership so they don't expire.

                await RenewOwnershipAsync().ConfigureAwait(false);

                // From the storage service provided by the user, obtain a complete list of ownership, including expired ones.  We may still need
                // their eTags to claim orphan partitions.

                var completeOwnershipList = (await Manager
                    .ListOwnershipAsync(InnerClient.EventHubName, ConsumerGroup)
                    .ConfigureAwait(false))
                    .ToList();

                // Filter the complete ownership list to obtain only the ones that are still active.  The expiration time defaults to 30 seconds,
                // but it may be overriden by a derived class.

                var activeOwnership = completeOwnershipList
                    .Where(ownership => DateTimeOffset.UtcNow.Subtract(ownership.LastModifiedTime.Value) < OwnershipExpiration);

                // Dispose of all previous partition ownership instances and get a whole new dictionary.

                InstanceOwnership = activeOwnership
                    .Where(ownership => ownership.OwnerIdentifier == Identifier)
                    .ToDictionary(ownership => ownership.PartitionId);

                // Some previously owned partitions might have had their ownership expired or might have been stolen, so we need to stop
                // the pumps we don't need anymore.

                await Task.WhenAll(PartitionPumps.Keys
                    .Except(InstanceOwnership.Keys)
                    .Select(partitionId => RemovePartitionPumpIfItExistsAsync(partitionId, PartitionProcessorCloseReason.OwnershipLost)))
                    .ConfigureAwait(false);

                // Now that we are left with pumps that should be running, check their status.  If any has stopped, it means an
                // unexpected failure has happened, so try closing it and starting a new one.  In case we don't have a pump that
                // should exist, create it.  This might happen when pump creation has failed in a previous cycle.

                await Task.WhenAll(InstanceOwnership
                    .Where(kvp =>
                        {
                            if (PartitionPumps.TryGetValue(kvp.Key, out var pump))
                            {
                                return !pump.IsRunning;
                            }

                            return true;
                        })
                    .Select(kvp => AddOrOverwritePartitionPumpAsync(kvp.Key, kvp.Value.SequenceNumber)))
                    .ConfigureAwait(false);

                // Find an ownership to claim and try to claim it.  The method will return null if this instance was not eligible to
                // increase its ownership list, if no claimable ownership could be found or if a claim attempt failed.

                var claimedOwnership = await FindAndClaimOwnershipAsync(completeOwnershipList, activeOwnership).ConfigureAwait(false);

                if (claimedOwnership != null)
                {
                    InstanceOwnership[claimedOwnership.PartitionId] = claimedOwnership;

                    await AddOrOverwritePartitionPumpAsync(claimedOwnership.PartitionId, claimedOwnership.SequenceNumber).ConfigureAwait(false);
                }

                // Wait the remaining time, if any, to start the next cycle.  The total time of a cycle defaults to 10 seconds,
                // but it may be overriden by a derived class.

                TimeSpan remainingTimeUntilNextCycle = cycleDuration.Elapsed - LoadBalanceUpdate;

                if (remainingTimeUntilNextCycle > TimeSpan.Zero)
                {
                    // If a stop request has been issued, Task.Delay will throw a TaskCanceledException.  This is expected and it
                    // will be caught by the StopAsync method.

                    await Task.Delay(remainingTimeUntilNextCycle, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        ///   Finds and tries to claim an ownership if this <see cref="EventProcessor{T}" /> instance is eligible to increase its ownership
        ///   list.
        /// </summary>
        ///
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the stored service provided by the user.</param>
        /// <param name="activeOwnership">The set of ownership that are still active.</param>
        ///
        /// <returns>The claimed ownership. <c>null</c> if this instance is not eligible, if no claimable ownership was found or if the claim attempt failed.</returns>
        ///
        private async Task<PartitionOwnership> FindAndClaimOwnershipAsync(IEnumerable<PartitionOwnership> completeOwnershipEnumerable,
                                                                          IEnumerable<PartitionOwnership> activeOwnership)
        {
            // Get a complete list of the partition ids present in the Event Hub.  This should be immutable for the time being, but
            // it may change in the future.

            var partitionIds = await InnerClient.GetPartitionIdsAsync().ConfigureAwait(false);

            // Create a partition distribution dictionary from the active ownership list we have, mapping an owner's identifier to the amount of
            // partitions it owns.  When an event processor goes down and it has only expired ownership, it will not be taken into consideration
            // by others.

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

                var unclaimedPartitions = partitionIds
                    .Except(activeOwnership.Select(ownership => ownership.PartitionId));

                if (unclaimedPartitions.Any())
                {
                    var index = RandomNumberGenerator.Value.Next(unclaimedPartitions.Count());

                    return await ClaimOwnershipAsync(unclaimedPartitions.ElementAt(index), completeOwnershipEnumerable).ConfigureAwait(false);
                }

                // Only try to steal partitions if there are no unclaimed partitions left.  At first, only processors that have exceeded the
                // maximum owned partition count should be targeted.

                var maximumOwnedPartitionsCount = minimumOwnedPartitionsCount + 1;

                var stealablePartitions = activeOwnership
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
        ///   Creates and starts a new partition pump associated with the specified partition.  Partition pumps that are overwritten by the creation
        ///   of a new one are properly stopped.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the partition pump will be associated with.  Events will be read only from this partition.</param>
        /// <param name="initialSequenceNumber">The sequence number of the event within a partition where the partition pump should begin reading events.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task AddOrOverwritePartitionPumpAsync(string partitionId,
                                                            long? initialSequenceNumber)
        {
            // Remove and stop the existing partition pump if it exists.  We are not specifying any close reason because partition
            // pumps only are overwritten in case of failure.  In these cases, the close reason is delegated to the pump as it may
            // have more information about what caused the failure.

            await RemovePartitionPumpIfItExistsAsync(partitionId).ConfigureAwait(false);

            // Create and start the new partition pump and add it to the dictionary.

            var partitionContext = new PartitionContext(InnerClient.EventHubName, ConsumerGroup, partitionId, Identifier, Manager);

            try
            {
                var partitionProcessor = PartitionProcessorFactory(partitionContext);
                var options = Options.Clone();

                // Ovewrite the initial event position in case a checkpoint exists.

                if (initialSequenceNumber.HasValue)
                {
                    options.InitialEventPosition = EventPosition.FromSequenceNumber(initialSequenceNumber.Value);
                }

                var partitionPump = new PartitionPump(InnerClient, ConsumerGroup, partitionContext, partitionProcessor, options);

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
        /// <param name="reason">The reason why the partition processor is being closed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task RemovePartitionPumpIfItExistsAsync(string partitionId,
                                                              PartitionProcessorCloseReason? reason = null)
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

            var oldOwnership = completeOwnershipEnumerable.FirstOrDefault(ownership => ownership.PartitionId == partitionId);

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

            // We are expecting an enumerable with a single element if the claim attempt succeeds.

            var claimedOwnership = (await Manager
                .ClaimOwnershipAsync(new List<PartitionOwnership> { newOwnership })
                .ConfigureAwait(false));

            return claimedOwnership.FirstOrDefault();
        }

        /// <summary>
        ///   Renews this instance's ownership so they don't expire.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private Task RenewOwnershipAsync()
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

            // We cannot rely on the ownership returned by ClaimOwnershipAsync to update our InstanceOwnership dictionary.
            // If the user issues a checkpoint update, the associated ownership will have its eTag updated as well, so we
            // will fail in claiming it here, but this instance still owns it.

            return Manager.ClaimOwnershipAsync(ownershipToRenew);
        }
    }
}
