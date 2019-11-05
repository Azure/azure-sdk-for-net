// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Constantly receives <see cref="EventData" /> from a single partition in the context of a given consumer
    ///   group.  The received data is sent to its owner <see cref="EventProcessorClient" /> to be processed.
    /// </summary>
    ///
    internal class PartitionPump
    {
        // TODO: Remove this when moving to the consumer's iterator.
        private const int MaximumMessageCount = 25;

        /// <summary>The <see cref="EventHubsRetryPolicy" /> used to verify whether an exception is retriable or not.</summary>
        private static readonly BasicRetryPolicy RetryPolicy = new BasicRetryPolicy(new RetryOptions());

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim RunningTaskSemaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        ///   A boolean value indicating whether this partition pump is currently running or not.
        /// </summary>
        ///
        public bool IsRunning => RunningTask != null && !RunningTask.IsCompleted;

        /// <summary>
        ///   The <see cref="EventProcessorClient" /> that owns this instance.
        /// </summary>
        ///
        private EventProcessorClient OwnerEventProcessor { get; }

        /// <summary>
        ///   The active connection to the Azure Event Hubs service, enabling client communications for metadata
        ///   about the associated Event Hub and access to a transport-aware producer.
        /// </summary>
        ///
        private EventHubConnection Connection { get; }

        /// <summary>
        ///   The name of the consumer group this partition pump is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   The position within the partition where the pump should begin reading events.
        /// </summary>
        ///
        private EventPosition StartingPosition { get; }

        /// <summary>
        ///   The context of the Event Hub partition this partition pump is associated with.
        /// </summary>
        ///
        private PartitionContext Context { get; }

        /// <summary>
        ///   The set of options to use for this partition pump.
        /// </summary>
        ///
        private EventProcessorClientOptions Options { get; }

        /// <summary>
        ///   A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the current running task.
        /// </summary>
        ///
        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        /// <summary>
        ///   The consumer used to receive events from the Azure Event Hubs service.
        /// </summary>
        ///
        private EventHubConsumerClient InnerConsumer { get; set; }

        /// <summary>
        ///   The running task responsible for receiving events from the Azure Event Hubs service.
        /// </summary>
        ///
        private Task RunningTask { get; set; }

        /// <summary>
        ///   The reason why the processing for the associated partition is being stopped.  This member is only used
        ///   in case of failure.  Shutdown and OwnershipLost close reasons will be specified by the event processor.
        /// </summary>
        ///
        private CloseReason CloseReason { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionPump"/> class.
        /// </summary>
        ///
        /// <param name="eventProcessor">The <see cref="EventProcessorClient" /> that owns this instance.</param>
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="consumerGroup">The name of the consumer group this partition pump is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionContext">The context of the Event Hub partition this partition pump is associated with.  Events will be read only from this partition.</param>
        /// <param name="startingPosition">The position within the partition where the pump should begin reading events.</param>
        /// <param name="options">The set of options to use for this partition pump.</param>
        ///
        internal PartitionPump(EventProcessorClient eventProcessor,
                               EventHubConnection connection,
                               string consumerGroup,
                               PartitionContext partitionContext,
                               EventPosition startingPosition,
                               EventProcessorClientOptions options)
        {
            OwnerEventProcessor = eventProcessor;
            Connection = connection;
            ConsumerGroup = consumerGroup;
            Context = partitionContext;
            StartingPosition = startingPosition;
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

                        // In case an exception is encountered while the processing is initializing, don't catch it
                        // and let the event processor handle it.

                        EventPosition startingPosition = StartingPosition;

                        if (OwnerEventProcessor.InitializeProcessingForPartitionAsync != null)
                        {
                            var initializationContext = new InitializePartitionProcessingContext(Context);
                            await OwnerEventProcessor.InitializeProcessingForPartitionAsync(initializationContext).ConfigureAwait(false);

                            startingPosition = startingPosition ?? initializationContext.DefaultStartingPosition;
                        }

                        InnerConsumer = new EventHubConsumerClient(ConsumerGroup, Context.PartitionId, startingPosition ?? EventPosition.Earliest, Connection);

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
        /// <param name="reason">The reason why the processing for the associated partition is being stopped.  In case it's <c>null</c>, the internal close reason set by this pump is used.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public async Task StopAsync(CloseReason? reason)
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
                            // RunningTask is only expected to fail when the event processor throws while processing
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

                        // In case an exception is encountered while the processing is stopping, don't catch it and let
                        // the event processor handle it.  The pump has no way to guess when a partition was lost or when
                        // a shutdown request was sent to the event processor, so it expects a "reason" parameter to provide
                        // this information.  However, in case of pump failure, the external event processor does not have
                        // enough information to figure out what failure reason to use, as this information is only known
                        // by the pump.  In this case, we expect the processor-provided reason to be null, and the private
                        // CloseReason is used instead.

                        if (OwnerEventProcessor.ProcessingForPartitionStoppedAsync != null)
                        {
                            var stopContext = new PartitionProcessingStoppedContext(Context, reason ?? CloseReason);
                            await OwnerEventProcessor.ProcessingForPartitionStoppedAsync(stopContext).ConfigureAwait(false);
                        }
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
        ///   and delegates their processing to the event processor processing handlers.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            List<EventData> receivedEvents;
            Exception unrecoverableException = null;

            // We'll break from the loop upon encountering a non-retriable exception.  The event processor periodically
            // checks its pumps' status, so it should be aware of when one of them stops working.

            while (!cancellationToken.IsCancellationRequested && unrecoverableException == null)
            {
                try
                {
                    receivedEvents = (await InnerConsumer.ReceiveAsync(MaximumMessageCount, Options.MaximumReceiveWaitTime, cancellationToken).ConfigureAwait(false)).ToList();

                    using DiagnosticScope diagnosticScope = EventDataInstrumentation.ClientDiagnostics.CreateScope(DiagnosticProperty.EventProcessorProcessingActivityName);
                    diagnosticScope.AddAttribute("kind", "server");

                    if (diagnosticScope.IsEnabled)
                    {
                        foreach (var eventData in receivedEvents)
                        {
                            if (EventDataInstrumentation.TryExtractDiagnosticId(eventData, out string diagnosticId))
                            {
                                diagnosticScope.AddLink(diagnosticId);
                            }
                        }
                    }

                    // Small workaround to make sure we call ProcessEvent with EventData = null when no events have been received.
                    // The code is expected to get simpler when we start using the async enumerator internally to receive events.

                    if (receivedEvents.Count == 0)
                    {
                        receivedEvents.Add(null);
                    }

                    diagnosticScope.Start();

                    foreach (var eventData in receivedEvents)
                    {
                        try
                        {
                            var processorEvent = new EventProcessorEvent(Context, eventData, OwnerEventProcessor.UpdateCheckpointAsync);
                            await OwnerEventProcessor.ProcessEventAsync(processorEvent).ConfigureAwait(false);
                        }
                        catch (Exception eventProcessingException)
                        {
                            diagnosticScope.Failed(eventProcessingException);
                            unrecoverableException = eventProcessingException;
                            CloseReason = CloseReason.Exception;

                            break;
                        }
                    }
                }
                catch (Exception eventHubException)
                {
                    // Stop running only if it's not a retriable exception.

                    if (RetryPolicy.CalculateRetryDelay(eventHubException, 1) == null)
                    {
                        unrecoverableException = eventHubException;
                        CloseReason = CloseReason.Exception;

                        break;
                    }
                }
            }

            if (unrecoverableException != null)
            {
                // In case an exception is thrown by ProcessExceptionAsync, don't catch it and
                // let the calling method (StopAsync) handle it.

                var errorContext = new ProcessorErrorContext(Context.PartitionId, unrecoverableException);
                await OwnerEventProcessor.ProcessExceptionAsync(errorContext).ConfigureAwait(false);
            }
        }
    }
}
