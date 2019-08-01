// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        public string InstanceId { get; }

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
        ///   An instance of a class that implements the <see cref="IPartitionProcessorFactory" /> interface.
        ///   It's provided by the user and it's used to create partition processors.
        /// </summary>
        ///
        private IPartitionProcessorFactory PartitionProcessorFactory { get; }

        /// <summary>
        ///   An instance of a class that implements the <see cref="IPartitionManager" /> interface.
        ///   It's provided by the user and it's used to interact with the storage system, dealing with
        ///   leases and checkpoints.
        /// </summary>
        ///
        private IPartitionManager PartitionManager { get; }

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
        private ConcurrentDictionary<string, PartitionPump> PartitionPumps { get; set; }

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
        /// <param name="partitionProcessorFactory">A factory used to create partition processors.  Its implementation must be provided by the user.</param>
        /// <param name="partitionManager">A partition manager used to interact with the storage system.  Its implementation must be provided by the user.</param>
        /// <param name="options">The set of options to use for this event processor.</param>
        ///
        public EventProcessor(string consumerGroup,
                              EventHubClient eventHubClient,
                              IPartitionProcessorFactory partitionProcessorFactory,
                              IPartitionManager partitionManager,
                              EventProcessorOptions options = default)
        {
            Guard.ArgumentNotNull(nameof(eventHubClient), eventHubClient);
            Guard.ArgumentNotNullOrEmpty(nameof(consumerGroup), consumerGroup);
            Guard.ArgumentNotNull(nameof(partitionProcessorFactory), partitionProcessorFactory);
            Guard.ArgumentNotNull(nameof(partitionManager), partitionManager);

            InnerClient = eventHubClient;
            ConsumerGroup = consumerGroup;
            PartitionProcessorFactory = partitionProcessorFactory;
            PartitionManager = partitionManager;
            Options = options?.Clone() ?? new EventProcessorOptions();

            InstanceId = Guid.NewGuid().ToString();
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
                        RunningTaskTokenSource = new CancellationTokenSource();

                        PartitionPumps = new ConcurrentDictionary<string, PartitionPump>();

                        var partitionIds = await InnerClient.GetPartitionIdsAsync().ConfigureAwait(false);

                        await Task.WhenAll(partitionIds.Select(async partitionId =>
                        {
                            var partitionContext = new PartitionContext(InnerClient.EventHubPath, ConsumerGroup, InstanceId, partitionId);
                            var checkpointManager = new CheckpointManager(partitionContext, PartitionManager);

                            var partitionProcessor = PartitionProcessorFactory.CreatePartitionProcessor(partitionContext, checkpointManager);

                            var partitionPump = new PartitionPump(InnerClient, ConsumerGroup, partitionId, partitionProcessor, Options);
                            PartitionPumps.TryAdd(partitionId, partitionPump);

                            await partitionPump.StartAsync().ConfigureAwait(false);
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

                        await RunningTask.ConfigureAwait(false);
                        RunningTask = null;

                        await Task.WhenAll(PartitionPumps.Select(kvp => kvp.Value.StopAsync())).ConfigureAwait(false);
                        PartitionPumps = null;
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
            var pumpsToUpdate = new List<string>();

            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var kvp in PartitionPumps)
                {
                    var partitionPump = kvp.Value;

                    if (!partitionPump.IsRunning)
                    {
                        pumpsToUpdate.Add(kvp.Key);
                    }
                }

                await Task.WhenAll(pumpsToUpdate.Select(async partitionId =>
                {
                    var partitionContext = new PartitionContext(InnerClient.EventHubPath, ConsumerGroup, InstanceId, partitionId);
                    var checkpointManager = new CheckpointManager(partitionContext, PartitionManager);

                    var partitionProcessor = PartitionProcessorFactory.CreatePartitionProcessor(partitionContext, checkpointManager);

                    var partitionPump = new PartitionPump(InnerClient, ConsumerGroup, partitionId, partitionProcessor, Options);
                    PartitionPumps.TryUpdate(partitionId, partitionPump, partitionPump);

                    await partitionPump.StartAsync().ConfigureAwait(false);
                })).ConfigureAwait(false);

                pumpsToUpdate.Clear();

                // Wait 1 second before the next verification.

                await Task.Delay(1000).ConfigureAwait(false);
            }
        }
    }
}
