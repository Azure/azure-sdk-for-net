// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Constantly receives <see cref="EventData" /> from a single partition in the context of a given consumer
    ///   group.  The received data is sent to an <see cref="IPartitionProcessor" /> to be processed.
    /// </summary>
    ///
    internal class PartitionPump
    {
        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim RunningTaskSemaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        ///   A boolean value indicating whether this partition pump is currently running or not.
        /// </summary>
        ///
        public bool IsRunning => RunningTask != null && !RunningTask.IsCompleted;

        /// <summary>
        ///   The client used to interact with the Azure Event Hubs service.
        /// </summary>
        ///
        private EventHubClient InnerClient { get; }

        /// <summary>
        ///   The name of the consumer group this partition pump is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition this partition pump is associated with.  Events will be
        ///   read only from this partition.
        /// </summary>
        ///
        private string PartitionId { get; }

        /// <summary>
        ///   An instance of a class that implements the <see cref="IPartitionProcessor" /> interface.
        ///   It's provided by the constructor caller and it's used to process events and errors.
        /// </summary>
        ///
        private IPartitionProcessor PartitionProcessor { get; }

        /// <summary>
        ///   The set of options to use for this partition pump.
        /// </summary>
        ///
        private EventProcessorOptions Options { get; }

        /// <summary>
        ///   A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the current running task.
        /// </summary>
        ///
        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        /// <summary>
        ///   The consumer used to receive events from the Azure Event Hubs service.
        /// </summary>
        ///
        private EventHubConsumer InnerConsumer { get; set; }

        /// <summary>
        ///   The running task responsible for receiving events from the Azure Event Hubs service.
        /// </summary>
        ///
        private Task RunningTask { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionPump"/> class.
        /// </summary>
        ///
        /// <param name="eventHubClient">The client used to interact with the Azure Event Hubs service.</param>
        /// <param name="consumerGroup">The name of the consumer group this partition pump is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this partition pump is associated with.  Events will be read only from this partition.</param>
        /// <param name="partitionProcessor">A partition processor used to process events and errors.  Its implementation must be provided by the caller.</param>
        /// <param name="options">The set of options to use for this partition pump.</param>
        ///
        internal PartitionPump(EventHubClient eventHubClient,
                               string consumerGroup,
                               string partitionId,
                               IPartitionProcessor partitionProcessor,
                               EventProcessorOptions options)
        {
            InnerClient = eventHubClient;
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
            PartitionProcessor = partitionProcessor;
            Options = options;
        }

        /// <summary>
        ///   Starts the partition pump.  In case it's already running, nothing happens.
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

                        InnerConsumer = InnerClient.CreateConsumer(ConsumerGroup, PartitionId, Options.InitialEventPosition);

                        await PartitionProcessor.InitializeAsync().ConfigureAwait(false);

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
        ///   Stops the partition pump.  In case it hasn't been started, nothing happens.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public Task StopAsync() => StopAsync(PartitionProcessorCloseReason.Shutdown);

        /// <summary>
        ///   Stops the partition pump.  In case it hasn't been started, nothing happens.
        /// </summary>
        ///
        /// <param name="reason">The reason why the partition pump is being closed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task StopAsync(PartitionProcessorCloseReason reason)
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

                        await InnerConsumer.CloseAsync().ConfigureAwait(false);
                        InnerConsumer = null;

                        await PartitionProcessor.CloseAsync(reason).ConfigureAwait(false);
                    }
                }
                finally
                {
                    RunningTaskSemaphore.Release();
                }
            }
        }

        /// <summary>
        ///   The main loop of a partition pump.  It receives events from the Azure Event Hubs service
        ///   and delegates their processing to the inner partition processor.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            var retryPolicy = new BasicRetryPolicy(new RetryOptions());

            while (!cancellationToken.IsCancellationRequested)
            {
                IEnumerable<EventData> receivedEvents = null;

                try
                {
                    receivedEvents = await InnerConsumer.ReceiveAsync(Options.MaximumMessageCount, Options.MaximumReceiveWaitTime, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    await PartitionProcessor.ProcessErrorAsync(exception, cancellationToken).ConfigureAwait(false);

                    // Stop the pump if it's not a retryable exception.

                    if (retryPolicy.CalculateRetryDelay(exception, 1) == null)
                    {
                        // StopAsync cannot be awaited in this method because it awaits RunningTask, so we would have a deadlock.
                        // For this reason, StopAsync starts to run concurrently with this task.

                        _ = StopAsync(PartitionProcessorCloseReason.EventHubException);
                        break;
                    }
                }

                await PartitionProcessor.ProcessEventsAsync(receivedEvents, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
