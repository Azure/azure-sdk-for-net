// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Constantly receives <see cref="EventData" /> from a single partition in the context of a given consumer
    ///   group.  The received data is sent to an <see cref="IPartitionProcessor" /> to be processed.
    /// </summary>
    ///
    internal class PartitionPump
    {
        /// <summary>The <see cref="EventHubRetryPolicy" /> used to verify whether an exception is retriable or not.</summary>
        private static readonly BasicRetryPolicy RetryPolicy = new BasicRetryPolicy(new RetryOptions());

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
        ///   The reason why the partition processor is being closed.  This member is only used in case of failure, as a Shutdown
        ///   or OwnershipLost close reason will be specified by the event processor.
        /// </summary>
        ///
        private PartitionProcessorCloseReason CloseReason { get; set; }

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
                        // We expect the token source to be null, but we are playing safe.

                        RunningTaskTokenSource?.Cancel();
                        RunningTaskTokenSource = new CancellationTokenSource();

                        InnerConsumer = InnerClient.CreateConsumer(ConsumerGroup, PartitionId, Options.InitialEventPosition);

                        // In case an exception is encountered while partition processor is initializing, don't catch it
                        // and let the event processor handle it.  The inner consumer hasn't connected to the service yet,
                        // so there's no need to close it.

                        await PartitionProcessor.InitializeAsync().ConfigureAwait(false);

                        // Before closing, the running task will set the close reason in case of failure.  When something
                        // unexpected happens and it's not set, the default value (Unknown) is kept.

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
        ///   Stops the partition pump.  In case it isn't running, nothing happens.
        /// </summary>
        ///
        /// <param name="reason">The reason why the partition processor is being closed.  In case it's <c>null</c>, the internal close reason set by this pump is used.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task StopAsync(PartitionProcessorCloseReason? reason)
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
                            // RunningTask is only expected to fail when the partition processor throws while processing
                            // an error, but unforeseen scenarios might happen.

                            await RunningTask.ConfigureAwait(false);
                        }
                        catch (Exception)
                        {
                            // TODO: delegate the exception handling to an Exception Callback.
                        }

                        RunningTask = null;

                        // It's important to close the consumer as soon as possible.  Failing to do so multiple times
                        // would make it impossible to create more consumers for the associated partition as there's a
                        // limit per client.

                        await InnerConsumer.CloseAsync().ConfigureAwait(false);

                        // In case an exception is encountered while partition processor is closing, don't catch it and
                        // let the event processor handle it.  The pump has no way to guess when a partition was lost or
                        // when a shutdown request was sent to the event processor, so it expects a "reason" parameter to
                        // provide this information.  However, in case of pump failure, the external event processor does
                        // not have enough information to figure out what failure reason to use, as this information is
                        // only known by the pump.  In this case, we expect the processor-provided reason to be null, and
                        // the private CloseReason is used instead.

                        await PartitionProcessor.CloseAsync(reason ?? CloseReason).ConfigureAwait(false);
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
            Exception unrecoverableException = null;

            // We'll break from the loop upon encountering a non-retriable exception.  The event processor periodically
            // checks its pumps' status, so it should be aware of when one of them stops working.

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var receivedEvents = await InnerConsumer.ReceiveAsync(Options.MaximumMessageCount, Options.MaximumReceiveWaitTime, cancellationToken).ConfigureAwait(false);

                    try
                    {
                        await PartitionProcessor.ProcessEventsAsync(receivedEvents, cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception partitionProcessorException)
                    {
                        unrecoverableException = partitionProcessorException;
                        CloseReason = PartitionProcessorCloseReason.PartitionProcessorException;

                        break;
                    }
                }
                catch (Exception eventHubException)
                {
                    // Stop running only if it's not a retriable exception.

                    if (RetryPolicy.CalculateRetryDelay(eventHubException, 1) == null)
                    {
                        unrecoverableException = eventHubException;
                        CloseReason = PartitionProcessorCloseReason.EventHubException;

                        break;
                    }
                }
            }

            if (unrecoverableException != null)
            {
                // In case an exception is encountered while partition processor is processing the error, don't
                // catch it and let the calling method (StopAsync) handle it.

                await PartitionProcessor.ProcessErrorAsync(unrecoverableException, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
