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
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   An abstraction used as a base for the <see cref="EventProcessorClient" /> class.  It provides partition processing load
    ///   balancing across multiple processor instances in the context of an Event Hub and a consumer group, and it can be extended
    ///   by a concrete implementation with customized functionality.
    /// </summary>
    ///
    /// <typeparam name="T">An underlying type with additional information that fully describes the context in which a partition is being processed.</typeparam>
    ///
    public abstract class EventProcessorBase<T>
    {
        /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The random number generator to use for a specific thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim RunningTaskSemaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the processor is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public abstract string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that the processor is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public abstract string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        public abstract string ConsumerGroup { get; }

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        public abstract string Identifier { get; }

        /// <summary>
        ///   The active policy which governs retry attempts for the
        ///   processor.
        /// </summary>
        ///
        protected abstract EventHubsRetryPolicy RetryPolicy { get; }

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
        ///   A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the current running task.
        /// </summary>
        ///
        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        /// <summary>
        ///   The set of currently active partition processing tasks issued by this event processor.  Partition ids are
        ///   used as keys.
        /// </summary>
        ///
        protected ConcurrentDictionary<string, Task> ActivePartitionProcessors { get; private set; } = new ConcurrentDictionary<string, Task>();

        /// <summary>
        ///   The set of token sources that can be used to cancel currently active partition processing tasks.  Partition
        ///   ids are used as keys.
        /// </summary>
        ///
        private ConcurrentDictionary<string, CancellationTokenSource> ActivePartitionProcessorTokenSources { get; set; } = new ConcurrentDictionary<string, CancellationTokenSource>();

        /// <summary>
        ///   The set of contexts associated with partitions that are currently being processed.  Partition ids are used
        ///   as keys.
        /// </summary>
        ///
        private ConcurrentDictionary<string, T> PartitionContexts { get; set; } = new ConcurrentDictionary<string, T>();

        /// <summary>
        ///   The set of partition ownership this event processor owns.  Partition ids are used as keys.
        ///   TODO: we should decide whether this property should be made private or not (and how would the concrete class obtain checkpoint information).
        /// </summary>
        ///
        protected Dictionary<string, PartitionOwnership> InstanceOwnership { get; set; } = new Dictionary<string, PartitionOwnership>();

        /// <summary>
        ///   The running task responsible for performing partition load balancing between multiple <see cref="EventProcessorClient" />
        ///   instances, as well as managing partition processing tasks and ownership.
        ///   TODO: once IsRunning is implemented, we should make it private.
        /// </summary>
        ///
        protected Task ActiveLoadBalancingTask { get; private set; }

        /// <summary>
        ///   The function to be called just before event processing starts for a given partition.
        /// </summary>
        ///
        /// <param name="context">The context in which the associated partition will be processed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected virtual ValueTask InitializeProcessingForPartitionAsync(T context) => new ValueTask();

        /// <summary>
        ///   The handler to be called once event processing stops for a given partition.
        /// </summary>
        ///
        /// <param name="reason">The reason why the processing for the associated partition is being stopped.</param>
        /// <param name="context">The context in which the associated partition was being processed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected virtual ValueTask ProcessingForPartitionStoppedAsync(ProcessingStoppedReason reason,
                                                                       T context) => new ValueTask();

        /// <summary>
        ///   Responsible for processing events received from the Event Hubs service.
        /// </summary>
        ///
        /// <param name="partitionEvent">The partition event to be processed.</param>
        /// <param name="context">The context in which the associated partition is being processed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected abstract ValueTask ProcessEventAsync(PartitionEvent partitionEvent,
                                                       T context);

        /// <summary>
        ///   Responsible for processing unhandled exceptions thrown while this processor is running.
        /// </summary>
        ///
        /// <param name="exception">The exception to be processed.</param>
        /// <param name="context">The context in which the associated partition was being processed when the exception was thrown.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected abstract ValueTask ProcessErrorAsync(Exception exception,
                                                       T context);

        /// <summary>
        ///   Retrieves a complete ownership list from the chosen storage service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated namespace, Event Hub and consumer group.</returns>
        ///
        protected abstract Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                    string eventHubName,
                                                                                    string consumerGroup);

        /// <summary>
        ///   Attempts to claim ownership of partitions for processing.
        /// </summary>
        ///
        /// <param name="partitionOwnership">An enumerable containing all the ownership to claim.</param>
        ///
        /// <returns>An enumerable containing the successfully claimed ownership instances.</returns>
        ///
        protected abstract Task<IEnumerable<PartitionOwnership>> ClaimOwnershipAsync(IEnumerable<PartitionOwnership> partitionOwnership);

        /// <summary>
        ///   Retrieves a complete checkpoints list from the chosen storage service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing checkpoints for the associated Event Hub and consumer group.</returns>
        ///
        protected abstract Task<IEnumerable<Checkpoint>> ListCheckpointsAsync(string fullyQualifiedNamespace,
                                                                              string eventHubName,
                                                                              string consumerGroup);

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        /// <param name="context">The context of the partition the checkpoint is associated with.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected abstract Task UpdateCheckpointAsync(EventData eventData,
                                                      PartitionContext context);

        /// <summary>
        ///   Creates a <see cref="PartitionOwnership" /> instance based on the provided information.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the partition ownership is associated with.</param>
        /// <param name="lastModifiedTime">The date and time, in UTC, that the ownership is being created at.</param>
        /// <param name="eTag">The entity tag needed to update the ownership.</param>
        ///
        /// <returns>A <see cref="PartitionOwnership" /> instance based on the provided information.</returns>
        ///
        protected abstract PartitionOwnership CreatePartitionOwnership(string partitionId,
                                                                       DateTimeOffset? lastModifiedTime,
                                                                       string eTag);

        /// <summary>
        ///   Creates an <see cref="EventHubConnection" /> instance.  The returned instance must not be returned again by other
        ///   <see cref="CreateConnection" /> calls.
        /// </summary>
        ///
        /// <returns>A new <see cref="EventHubConnection" /> instance.</returns>
        ///
        /// <remarks>
        ///   The abstract <see cref="EventProcessorBase{T}" /> class has ownership of the returned connection and, therefore, is
        ///   responsible for closing it.  Attempting to close the connection in the derived class may result in undefined behavior.
        /// </remarks>
        ///
        protected abstract EventHubConnection CreateConnection();

        /// <summary>
        ///   Creates a context associated with a specific partition.  It will be passed to partition processing related methods,
        ///   such as <see cref="ProcessEventAsync" /> and <see cref="ProcessErrorAsync" />.
        /// </summary>
        ///
        /// <param name="partitionId">The partition the context is associated with.</param>
        ///
        /// <returns>A context associated with the specified partition.</returns>
        ///
        protected abstract T CreateContext(string partitionId);

        /// <summary>
        ///   Starts the event processor.  In case it's already running, nothing happens.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <remarks>
        ///   If overridden, the base class implementation must be explicitly called in order to make the event processor start
        ///   running.
        /// </remarks>
        ///
        public virtual async Task StartAsync()
        {
            if (ActiveLoadBalancingTask == null)
            {
                await RunningTaskSemaphore.WaitAsync().ConfigureAwait(false);

                try
                {
                    if (ActiveLoadBalancingTask == null)
                    {
                        // We expect the token source to be null, but we are playing safe.

                        RunningTaskTokenSource?.Cancel();
                        RunningTaskTokenSource = new CancellationTokenSource();

                        // Start the main running task.  It is responsible for managing the active partition processing tasks and
                        // for partition load balancing among multiple event processor instances.

                        ActiveLoadBalancingTask = RunAsync(RunningTaskTokenSource.Token);
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
        /// <remarks>
        ///   If overridden, the base class implementation must be explicitly called in order to make the event processor stop
        ///   running.
        /// </remarks>
        ///
        public virtual async Task StopAsync()
        {
            if (ActiveLoadBalancingTask != null)
            {
                await RunningTaskSemaphore.WaitAsync().ConfigureAwait(false);

                try
                {
                    if (ActiveLoadBalancingTask != null)
                    {
                        // Cancel the current running task.

                        RunningTaskTokenSource.Cancel();
                        RunningTaskTokenSource = null;

                        // Now that a cancellation request has been issued, wait for the running task to finish.  In case something
                        // unexpected happened and it stopped working midway, this is the moment we expect to catch an exception.

                        try
                        {
                            await ActiveLoadBalancingTask.ConfigureAwait(false);
                        }
                        catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
                        {
                            // Nothing to do here.  These exceptions are expected.
                        }
                        catch (Exception)
                        {
                            // TODO: delegate the exception handling to an Exception Callback.  Instead of delegating it to the handler,
                            // should we surface it?
                        }

                        // Now that the task has finished, clean up what is left.  Stop and remove every partition processing task that is
                        // still running and clear our dictionaries.  ActivePartitionProcessors, ActivePartitionProcessorTokenSources and
                        // PartitionContexts are already cleared by the StopPartitionProcessingIfRunningAsync method.

                        await Task.WhenAll(ActivePartitionProcessors.Keys
                            .Select(partitionId => StopPartitionProcessingIfRunningAsync(partitionId, ProcessingStoppedReason.Shutdown)))
                            .ConfigureAwait(false);

                        InstanceOwnership.Clear();

                        // TODO: once IsRunning is implemented, update the following comment.
                        // We need to wait until all tasks have stopped before making the load balancing task null.  If we did it sooner, we
                        // would have a race condition where the user could update the processing handlers while some pumps are still running.

                        ActiveLoadBalancingTask = null;
                    }
                }
                finally
                {
                    RunningTaskSemaphore.Release();
                }
            }
        }

        /// <summary>
        ///   Performs load balancing between multiple <see cref="EventProcessorClient" /> instances, claiming others' partitions to enforce
        ///   a more equal distribution when necessary.  It also manages its own partition processing tasks and ownership.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // We'll use this connection to retrieve an updated list of partition ids from the service.

            await using var connection = CreateConnection();

            while (!cancellationToken.IsCancellationRequested)
            {
                Stopwatch cycleDuration = Stopwatch.StartNew();

                // Renew this instance's ownership so they don't expire.
                // TODO: renew only after retrieving updated ownership so we use updated checkpoints.

                await RenewOwnershipAsync().ConfigureAwait(false);

                // From the storage service provided by the user, obtain a complete list of ownership, including expired ones.  We may still need
                // their eTags to claim orphan partitions.

                var completeOwnershipList = (await ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup)
                    .ConfigureAwait(false))
                    .ToList();

                // Filter the complete ownership list to obtain only the ones that are still active.  The expiration time defaults to 30 seconds,
                // but it may be overridden by a derived class.

                var utcNow = DateTimeOffset.UtcNow;

                IEnumerable<PartitionOwnership> activeOwnership = completeOwnershipList
                    .Where(ownership => utcNow.Subtract(ownership.LastModifiedTime.Value) < OwnershipExpiration);

                // Dispose of all previous partition ownership instances and get a whole new dictionary.

                InstanceOwnership = activeOwnership
                    .Where(ownership => ownership.OwnerIdentifier == Identifier)
                    .ToDictionary(ownership => ownership.PartitionId);

                // Some previously owned partitions might have had their ownership expired or might have been stolen, so we need to stop
                // the processing tasks we don't need anymore.

                await Task.WhenAll(ActivePartitionProcessors.Keys
                    .Except(InstanceOwnership.Keys)
                    .Select(partitionId => StopPartitionProcessingIfRunningAsync(partitionId, ProcessingStoppedReason.OwnershipLost)))
                    .ConfigureAwait(false);

                // Now that we are left with processing tasks that should be running, check their status.  If any has stopped, it
                // means a failure has happened, so try closing it and starting a new one.  In case we don't have a task that should
                // exist, create it.  This might happen if the user hasn't updated ActivePartitionProcessors when initializing processing
                // in the previous cycle.

                await Task.WhenAll(InstanceOwnership
                    .Select(async kvp =>
                    {
                        if (!ActivePartitionProcessors.TryGetValue(kvp.Key, out Task processingTask) || processingTask.IsCompleted)
                        {
                            // TODO: if the task fails, what's the expected reason?

                            await StopPartitionProcessingIfRunningAsync(kvp.Key, ProcessingStoppedReason.Shutdown).ConfigureAwait(false);

                            var context = CreateContext(kvp.Key);
                            PartitionContexts[kvp.Key] = context;

                            await InitializeProcessingForPartitionAsync(context).ConfigureAwait(false);
                        }
                    }))
                    .ConfigureAwait(false);

                // Get a complete list of the partition ids present in the Event Hub.  This should be immutable for the time being, but
                // it may change in the future.

                var partitionIds = await connection.GetPartitionIdsAsync(RetryPolicy).ConfigureAwait(false);

                // Find an ownership to claim and try to claim it.  The method will return null if this instance was not eligible to
                // increase its ownership list, if no claimable ownership could be found or if a claim attempt has failed.

                var claimedOwnership = await FindAndClaimOwnershipAsync(partitionIds, completeOwnershipList, activeOwnership).ConfigureAwait(false);

                if (claimedOwnership != null)
                {
                    InstanceOwnership[claimedOwnership.PartitionId] = claimedOwnership;

                    var context = CreateContext(claimedOwnership.PartitionId);
                    PartitionContexts[claimedOwnership.PartitionId] = context;

                    await InitializeProcessingForPartitionAsync(context).ConfigureAwait(false);
                }

                // Wait the remaining time, if any, to start the next cycle.  The total time of a cycle defaults to 10 seconds,
                // but it may be overridden by a derived class.

                var remainingTimeUntilNextCycle = LoadBalanceUpdate.CalculateRemaining(cycleDuration.Elapsed);

                // If a stop request has been issued, Task.Delay will throw a TaskCanceledException.  This is expected and it
                // will be caught by the StopAsync method.

                await Task.Delay(remainingTimeUntilNextCycle, cancellationToken).ConfigureAwait(false);
            }

            // If cancellation has been requested, throw an exception so we can keep a consistent behavior.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
        }

        /// <summary>
        ///   Finds and tries to claim an ownership if this processor instance is eligible to increase its ownership list.
        /// </summary>
        ///
        /// <param name="partitionIds">The set of identifiers for the partitions within the Event Hub that this processor is associated with.</param>
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the storage service provided by the user.</param>
        /// <param name="activeOwnership">The set of ownership that are still active.</param>
        ///
        /// <returns>The claimed ownership. <c>null</c> if this instance is not eligible, if no claimable ownership was found or if the claim attempt failed.</returns>
        ///
        private ValueTask<PartitionOwnership> FindAndClaimOwnershipAsync(string[] partitionIds,
                                                                         IEnumerable<PartitionOwnership> completeOwnershipEnumerable,
                                                                         IEnumerable<PartitionOwnership> activeOwnership)
        {
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

            if (ownedPartitionsCount < minimumOwnedPartitionsCount
                || ownedPartitionsCount == minimumOwnedPartitionsCount
                && !partitionDistribution.Values.Any(partitions => partitions < minimumOwnedPartitionsCount))
            {
                // Look for unclaimed partitions.  If any, randomly pick one of them to claim.

                var unclaimedPartitions = partitionIds
                    .Except(activeOwnership.Select(ownership => ownership.PartitionId))
                    .ToArray();

                if (unclaimedPartitions.Length > 0)
                {
                    var index = RandomNumberGenerator.Value.Next(unclaimedPartitions.Length);
                    var returnTask = ClaimOwnershipAsync(unclaimedPartitions[index], completeOwnershipEnumerable);

                    return new ValueTask<PartitionOwnership>(returnTask);
                }

                // Only try to steal partitions if there are no unclaimed partitions left.  At first, only processors that have exceeded the
                // maximum owned partition count should be targeted.

                var maximumOwnedPartitionsCount = minimumOwnedPartitionsCount + 1;

                var stealablePartitions = activeOwnership
                    .Where(ownership => partitionDistribution[ownership.OwnerIdentifier] > maximumOwnedPartitionsCount)
                    .Select(ownership => ownership.PartitionId)
                    .ToArray();

                // Here's the important part.  If there are no processors that have exceeded the maximum owned partition count allowed, we may
                // need to steal from the processors that have exactly the maximum amount.  If this instance is below the minimum count, then
                // we have no choice as we need to enforce balancing.  Otherwise, leave it as it is because the distribution wouldn't change.

                if (stealablePartitions.Length == 0
                    && ownedPartitionsCount < minimumOwnedPartitionsCount)
                {
                    stealablePartitions = activeOwnership
                        .Where(ownership => partitionDistribution[ownership.OwnerIdentifier] == maximumOwnedPartitionsCount)
                        .Select(ownership => ownership.PartitionId)
                        .ToArray();
                }

                // If any stealable partitions were found, randomly pick one of them to claim.

                if (stealablePartitions.Length > 0)
                {
                    var index = RandomNumberGenerator.Value.Next(stealablePartitions.Length);
                    var returnTask = ClaimOwnershipAsync(stealablePartitions[index], completeOwnershipEnumerable);

                    return new ValueTask<PartitionOwnership>(returnTask);
                }
            }

            // No ownership has been claimed.

            return new ValueTask<PartitionOwnership>(default(PartitionOwnership));
        }

        /// <summary>
        ///   Stops an owned partition processing task in case it is running.  It is also removed from the tasks dictionary
        ///   along with its corresponding token source.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is being stopped.</param>
        /// <param name="reason">The reason why the processing for the specified partition is being stopped.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task StopPartitionProcessingIfRunningAsync(string partitionId,
                                                                 ProcessingStoppedReason reason)
        {
            if (ActivePartitionProcessors.TryRemove(partitionId, out var processingTask)
                && ActivePartitionProcessorTokenSources.TryRemove(partitionId, out var tokenSource))
            {
                try
                {
                    tokenSource.Cancel();
                    await processingTask.ConfigureAwait(false);
                }
                catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
                {
                    // Nothing to do here.  These exceptions are expected.
                }
                catch (Exception)
                {
                    // TODO: delegate the exception handling to an Exception Callback.
                }
                finally
                {
                    tokenSource.Dispose();
                }
            }

            // TODO: if reason = Shutdown or OwnershipLost and we got an exception when closing, what should the final reason be?

            PartitionContexts.TryRemove(partitionId, out var context);
            await ProcessingForPartitionStoppedAsync(reason, context);
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
            var newOwnership = CreatePartitionOwnership(partitionId, DateTimeOffset.UtcNow, oldOwnership?.ETag);

            // We are expecting an enumerable with a single element if the claim attempt succeeds.

            IEnumerable<PartitionOwnership> claimedOwnership = await ClaimOwnershipAsync(new List<PartitionOwnership> { newOwnership }).ConfigureAwait(false);

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
            IEnumerable<PartitionOwnership> ownershipToRenew = InstanceOwnership.Values
                .Select(ownership => new PartitionOwnership
                (
                    ownership.FullyQualifiedNamespace,
                    ownership.EventHubName,
                    ownership.ConsumerGroup,
                    ownership.OwnerIdentifier,
                    ownership.PartitionId,
                    DateTimeOffset.UtcNow,
                    ownership.ETag
                ));

            // We cannot rely on the ownership returned by ClaimOwnershipAsync to update our InstanceOwnership dictionary.
            // If the user issues a checkpoint update, the associated ownership will have its eTag updated as well, so we
            // will fail in claiming it here, but this instance still owns it.

            return ClaimOwnershipAsync(ownershipToRenew);
        }

        /// <summary>
        ///   Starts running a task responsible for receiving and processing events in the context of a specified partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the task is associated with.  Events will be read only from this partition.</param>
        /// <param name="startingPosition">The position within the partition where the task should begin reading events.</param>
        /// <param name="maximumReceiveWaitTime">The maximum amount of time to wait to for an event to be available before emitting an empty item; if <c>null</c>, empty items will not be published.</param>
        /// <param name="retryOptions">The set of options to use for determining whether a failed operation should be retried and, if so, the amount of time to wait between retry attempts.</param>
        /// <param name="trackLastEnqueuedEventProperties">Indicates whether or not the task should request information on the last enqueued event on the partition associated with a given event, and track that information as events are received.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The running task that is currently receiving and processing events in the context of the specified partition.</returns>
        ///
        protected virtual Task RunPartitionProcessingAsync(string partitionId,
                                                           EventPosition startingPosition,
                                                           TimeSpan? maximumReceiveWaitTime,
                                                           EventHubsRetryOptions retryOptions,
                                                           bool trackLastEnqueuedEventProperties,
                                                           CancellationToken cancellationToken = default)
        {
            // TODO: should the retry options used here be the same for the abstract RetryPolicy property?

            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(retryOptions, nameof(retryOptions));

            return Task.Run(async () =>
            {
                // TODO: should we double check if a previous run already exists and close it?  We have a race condition.  Maybe we should throw in case another task exists.

                var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                var taskCancellationToken = cancellationSource.Token;

                ActivePartitionProcessorTokenSources[partitionId] = cancellationSource;

                // Context is set to default if operation fails.  This shouldn't fail unless the user tries processing
                // a partition they don't own.

                PartitionContexts.TryGetValue(partitionId, out var context);

                var clientOptions = new EventHubConsumerClientOptions
                {
                    RetryOptions = retryOptions
                };

                var readOptions = new ReadEventOptions
                {
                    MaximumWaitTime = maximumReceiveWaitTime,
                    TrackLastEnqueuedEventProperties = trackLastEnqueuedEventProperties
                };

                await using var connection = CreateConnection();

                await using (var consumer = new EventHubConsumerClient(ConsumerGroup, connection, clientOptions))
                {
                    await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partitionId, startingPosition, readOptions, taskCancellationToken))
                    {
                        using DiagnosticScope diagnosticScope = EventDataInstrumentation.ClientDiagnostics.CreateScope(DiagnosticProperty.EventProcessorProcessingActivityName);
                        diagnosticScope.AddAttribute("kind", "server");

                        if (diagnosticScope.IsEnabled
                            && partitionEvent.Data != null
                            && EventDataInstrumentation.TryExtractDiagnosticId(partitionEvent.Data, out string diagnosticId))
                        {
                            diagnosticScope.AddLink(diagnosticId);
                        }

                        diagnosticScope.Start();

                        try
                        {
                            await ProcessEventAsync(partitionEvent, context).ConfigureAwait(false);
                        }
                        catch (Exception eventProcessingException)
                        {
                            diagnosticScope.Failed(eventProcessingException);
                            throw;
                        }
                    }
                }
            });
        }
    }
}
