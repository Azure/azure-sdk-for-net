// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        ///   Responsible for processing events received from the Event Hubs service.
        /// </summary>
        ///
        private Func<EventProcessorEvent, ValueTask> ProcessEventAsync { get; }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        private Func<EventData, PartitionContext, Task> UpdateCheckpointAsync { get; }

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
        ///   Initializes a new instance of the <see cref="PartitionPump"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="consumerGroup">The name of the consumer group this partition pump is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionContext">The context of the Event Hub partition this partition pump is associated with.  Events will be read only from this partition.</param>
        /// <param name="startingPosition">The position within the partition where the pump should begin reading events.</param>
        /// <param name="processEventAsync">Responsible for processing events received from the Event Hubs service.</param>
        /// <param name="updateCheckpointAsync">Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.</param>
        /// <param name="options">The set of options to use for this partition pump.</param>
        ///
        internal PartitionPump(EventHubConnection connection,
                               string consumerGroup,
                               PartitionContext partitionContext,
                               EventPosition startingPosition,
                               Func<EventProcessorEvent, ValueTask> processEventAsync,
                               Func<EventData, PartitionContext, Task> updateCheckpointAsync,
                               EventProcessorClientOptions options)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(partitionContext, nameof(partitionContext));
            Argument.AssertNotNull(processEventAsync, nameof(processEventAsync));
            Argument.AssertNotNull(updateCheckpointAsync, nameof(updateCheckpointAsync));
            Argument.AssertNotNull(options, nameof(options));

            Connection = connection;
            ConsumerGroup = consumerGroup;
            Context = partitionContext;
            StartingPosition = startingPosition;
            ProcessEventAsync = processEventAsync;
            UpdateCheckpointAsync = updateCheckpointAsync;
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

                        InnerConsumer = new EventHubConsumerClient(ConsumerGroup, Connection);

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
                            // In case the pump has failed, don't catch the unhandled exception and let the caller handle it.

                            await RunningTask.ConfigureAwait(false);
                        }
                        finally
                        {
                            RunningTask = null;
                            await InnerConsumer.CloseAsync().ConfigureAwait(false);
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
            TransportConsumer transportConsumer = null;
            Exception unrecoverableException = null;

            // We'll break from the loop upon encountering a non-retriable exception.  The event processor periodically
            // checks its pumps' status, so it should be aware of when one of them stops working.

            try
            {
                transportConsumer = Connection.CreateTransportConsumer(ConsumerGroup, Context.PartitionId, StartingPosition);

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        receivedEvents = (await transportConsumer.ReceiveAsync(MaximumMessageCount, Options.MaximumReceiveWaitTime, cancellationToken).ConfigureAwait(false)).ToList();

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
                                var processorEvent = new EventProcessorEvent(Context, eventData, UpdateCheckpointAsync);
                                await ProcessEventAsync(processorEvent).ConfigureAwait(false);
                            }
                            catch (Exception eventProcessingException)
                            {
                                diagnosticScope.Failed(eventProcessingException);
                                unrecoverableException = eventProcessingException;

                                break;
                            }
                        }
                    }
                    catch (Exception eventHubException)
                    {
                        // Stop running only if it's not a retriable exception.

                        if (RetryPolicy.CalculateRetryDelay(eventHubException, 1) == null)
                        {
                            throw eventHubException;
                        }
                    }

                    if (unrecoverableException != null)
                    {
                        throw unrecoverableException;
                    }
                }
            }
            finally
            {
                if (transportConsumer != null)
                {
                    await transportConsumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }
            }
        }
    }
}
