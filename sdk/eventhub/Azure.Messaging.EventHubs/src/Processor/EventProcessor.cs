// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
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
            Guard.ArgumentNotNull(nameof(eventHubClient), eventHubClient);
            Guard.ArgumentNotNullOrEmpty(nameof(consumerGroup), consumerGroup);
            Guard.ArgumentNotNull(nameof(partitionProcessorFactory), partitionProcessorFactory);
            Guard.ArgumentNotNull(nameof(partitionManager), partitionManager);

            InnerClient = eventHubClient;
            ConsumerGroup = consumerGroup;
            PartitionProcessorFactory = partitionProcessorFactory;
            Manager = partitionManager;
            Options = options?.Clone() ?? new EventProcessorOptions();

            Identifier = Guid.NewGuid().ToString();
            PartitionPumps = new ConcurrentDictionary<string, PartitionPump>();
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

                        PartitionPumps.Clear();

                        var partitionIds = await InnerClient.GetPartitionIdsAsync().ConfigureAwait(false);

                        await Task.WhenAll(partitionIds
                            .Select(partitionId =>
                            {
                                var partitionContext = new PartitionContext(InnerClient.EventHubName, ConsumerGroup, partitionId);
                                var checkpointManager = new CheckpointManager(partitionContext, Manager, Identifier);

                                var partitionProcessor = PartitionProcessorFactory(partitionContext, checkpointManager);

                                var partitionPump = new PartitionPump(InnerClient, ConsumerGroup, partitionId, partitionProcessor, Options);
                                PartitionPumps.TryAdd(partitionId, partitionPump);

                                return partitionPump.StartAsync();
                            })).ConfigureAwait(false);

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

                        await Task.WhenAll(PartitionPumps.Select(kvp => kvp.Value.StopAsync())).ConfigureAwait(false);
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
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.WhenAll(PartitionPumps
                    .Where(kvp => !kvp.Value.IsRunning)
                    .Select(async kvp =>
                    {
                        try
                        {
                            await kvp.Value.StopAsync();
                        }
                        catch (Exception)
                        {
                            // We're catching every possible unhandled exception that may have happened during Partition Pump execution.
                            // TODO: delegate the exception handling to an Exception Callback.
                        }

                        var partitionId = kvp.Key;

                        var partitionContext = new PartitionContext(InnerClient.EventHubName, ConsumerGroup, partitionId);
                        var checkpointManager = new CheckpointManager(partitionContext, Manager, Identifier);

                        var partitionProcessor = PartitionProcessorFactory(partitionContext, checkpointManager);

                        var partitionPump = new PartitionPump(InnerClient, ConsumerGroup, partitionId, partitionProcessor, Options);
                        PartitionPumps.TryUpdate(partitionId, partitionPump, partitionPump);

                        await partitionPump.StartAsync();
                    })).ConfigureAwait(false);

                try
                {
                    // Wait 1 second before the next verification.

                    await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
                }
                catch (TaskCanceledException) { }
            }
        }
    }
}
