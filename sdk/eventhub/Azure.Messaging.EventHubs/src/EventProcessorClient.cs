// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Metadata;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Consumes events for the configured Event Hub and consumer group across all partitions, making them available for processing
    ///   through the provided handlers.
    /// </summary>
    ///
    public class EventProcessorClient : EventProcessorBase, IAsyncDisposable
    {
        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim RunningTaskSemaphore = new SemaphoreSlim(1, 1);

        /// <summary>The primitive for synchronizing access during start and set handler operations.</summary>
        private readonly object StartProcessorGuard = new object();

        /// <summary>The handler to be called just before event processing starts for a given partition.</summary>
        private Func<InitializePartitionProcessingContext, Task> _initializeProcessingForPartitionAsyncHandler;

        /// <summary>The handler to be called once event processing stops for a given partition.</summary>
        private Func<PartitionProcessingStoppedContext, Task> _processingForPartitionStoppedAsyncHandler;

        /// <summary>Responsible for processing events received from the Event Hubs service.</summary>
        private Func<EventProcessorEvent, Task> _processEventAsyncHandler;

        /// <summary>Responsible for processing unhandled exceptions thrown while this processor is running.</summary>
        private Func<ProcessorErrorContext, Task> _processErrorAsyncHandler;

        /// <summary>
        ///   The handler to be called just before event processing starts for a given partition.
        /// </summary>
        ///
        public Func<InitializePartitionProcessingContext, Task> InitializeProcessingForPartitionAsyncHandler
        {
            get => _initializeProcessingForPartitionAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _initializeProcessingForPartitionAsyncHandler = value);
        }

        /// <summary>
        ///   The handler to be called once event processing stops for a given partition.
        /// </summary>
        ///
        public Func<PartitionProcessingStoppedContext, Task> ProcessingForPartitionStoppedAsyncHandler
        {
            get => _processingForPartitionStoppedAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _processingForPartitionStoppedAsyncHandler = value);
        }

        /// <summary>
        ///   Responsible for processing events received from the Event Hubs service.  Implementation is mandatory.
        /// </summary>
        ///
        public Func<EventProcessorEvent, Task> ProcessEventAsyncHandler
        {
            get => _processEventAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _processEventAsyncHandler = value);
        }

        /// <summary>
        ///   Responsible for processing unhandled exceptions thrown while this processor is running.
        ///   Implementation is mandatory.
        /// </summary>
        ///
        public Func<ProcessorErrorContext, Task> ProcessErrorAsyncHandler
        {
            get => _processErrorAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _processErrorAsyncHandler = value);
        }

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the processor is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public override string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that the processor is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public override string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        public override string ConsumerGroup { get; }

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        public override string Identifier { get; }

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
        ///   TODO.
        /// </summary>
        ///
        private Func<EventHubConnection> ConnectionFactory { get; }

        /// <summary>
        ///   Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.
        /// </summary>
        ///
        private PartitionManager Manager { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="EventProcessorClient"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool Closed { get; protected set; } = false;

        /// <summary>
        ///   Indicates whether the client has ownership of the associated <see cref="EventHubConnection" />
        ///   and should take responsibility for managing its lifespan.
        /// </summary>
        ///
        private bool OwnsConnection { get; } = true;

        /// <summary>
        ///   The set of options to use for this event processor.
        /// </summary>
        ///
        private EventProcessorClientOptions Options { get; }

        /// <summary>
        ///   The active policy which governs retry attempts for the
        ///   processor.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the current running task.
        /// </summary>
        ///
        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        /// <summary>
        ///   The running task responsible for performing partition load balancing between multiple <see cref="EventProcessorClient" />
        ///   instances, as well as managing partition pumps and ownership.
        /// </summary>
        ///
        private Task ActiveLoadBalancingTask { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public EventProcessorClient(string consumerGroup,
                                    PartitionManager partitionManager,
                                    string connectionString) : this(consumerGroup, partitionManager, connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and SAS token are contained in this connection string.</param>
        /// <param name="processorOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public EventProcessorClient(string consumerGroup,
                                    PartitionManager partitionManager,
                                    string connectionString,
                                    EventProcessorClientOptions processorOptions) : this(consumerGroup, partitionManager, connectionString, null, processorOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventProcessorClient(string consumerGroup,
                                    PartitionManager partitionManager,
                                    string connectionString,
                                    string eventHubName) : this(consumerGroup, partitionManager, connectionString, eventHubName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and SAS token are contained in this connection string.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="processorOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventProcessorClient(string consumerGroup,
                                    PartitionManager partitionManager,
                                    string connectionString,
                                    string eventHubName,
                                    EventProcessorClientOptions processorOptions)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(partitionManager, nameof(partitionManager));
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            processorOptions = processorOptions?.Clone() ?? new EventProcessorClientOptions();

            ConnectionStringProperties connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            OwnsConnection = true;
            ConnectionFactory = () => new EventHubConnection(connectionString, eventHubName, processorOptions.ConnectionOptions);
            FullyQualifiedNamespace = connectionStringProperties.Endpoint.Host;
            EventHubName = string.IsNullOrEmpty(eventHubName) ? connectionStringProperties.EventHubName : eventHubName;
            ConsumerGroup = consumerGroup;
            Manager = partitionManager;
            Options = processorOptions;
            RetryPolicy = processorOptions.RetryOptions.ToRetryPolicy();
            Identifier = Guid.NewGuid().ToString();
            PartitionPumps = new ConcurrentDictionary<string, PartitionPump>();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="processorOptions">The set of options to use for this processor.</param>
        ///
        public EventProcessorClient(string consumerGroup,
                                    PartitionManager partitionManager,
                                    string fullyQualifiedNamespace,
                                    string eventHubName,
                                    TokenCredential credential,
                                    EventProcessorClientOptions processorOptions = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(partitionManager, nameof(partitionManager));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            processorOptions = processorOptions?.Clone() ?? new EventProcessorClientOptions();

            OwnsConnection = true;
            ConnectionFactory = () => new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential, processorOptions.ConnectionOptions);
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            Manager = partitionManager;
            Options = processorOptions;
            RetryPolicy = processorOptions.RetryOptions.ToRetryPolicy();
            Identifier = Guid.NewGuid().ToString();
            PartitionPumps = new ConcurrentDictionary<string, PartitionPump>();
        }

        // TODO: remove this constructor if not needed anymore.

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="processorOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   This constructor is intended only to support functional testing and mocking; it should not be used for production scenarios.
        /// </remarks>
        ///
        protected internal EventProcessorClient(string consumerGroup,
                                                PartitionManager partitionManager,
                                                EventHubConnection connection,
                                                EventProcessorClientOptions processorOptions)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(partitionManager, nameof(partitionManager));
            Argument.AssertNotNull(connection, nameof(connection));

            processorOptions = processorOptions?.Clone() ?? new EventProcessorClientOptions();

            OwnsConnection = false;
            ConnectionFactory = () => connection;
            FullyQualifiedNamespace = connection.FullyQualifiedNamespace;
            EventHubName = connection.EventHubName;
            ConsumerGroup = consumerGroup;
            Manager = partitionManager;
            Options = processorOptions;
            RetryPolicy = processorOptions.RetryOptions.ToRetryPolicy();
            Identifier = Guid.NewGuid().ToString();
            PartitionPumps = new ConcurrentDictionary<string, PartitionPump>();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        protected EventProcessorClient()
        {
            OwnsConnection = false;
        }

        /// <summary>
        ///   The function to be called just before event processing starts for a given partition.  It creates and starts
        ///   a new partition pump associated with the specified partition.  A partition pump might be overwritten by the
        ///   creation of the new one and, for this reason, it needs to be stopped prior to this method call.
        /// </summary>
        ///
        /// <param name="context">TODO.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected override async Task InitializeProcessingForPartitionAsync(PartitionContext context)
        {
            try
            {
                var startingPosition = EventPosition.Earliest;

                if (InitializeProcessingForPartitionAsyncHandler != null)
                {
                    var initializationContext = new InitializePartitionProcessingContext(context);
                    await InitializeProcessingForPartitionAsyncHandler(initializationContext).ConfigureAwait(false);

                    startingPosition = initializationContext.DefaultStartingPosition;
                }

                var ownership = InstanceOwnership[context.PartitionId];

                if (ownership.Offset.HasValue)
                {
                    startingPosition = EventPosition.FromOffset(ownership.Offset.Value);
                }
                else if (ownership.SequenceNumber.HasValue)
                {
                    startingPosition = EventPosition.FromSequenceNumber(ownership.SequenceNumber.Value);
                }

                var partitionPump = new PartitionPump(CreateConnection(), ConsumerGroup, context, startingPosition, ProcessEventAsync, Options);
                await partitionPump.StartAsync().ConfigureAwait(false);

                PartitionPumps[context.PartitionId] = partitionPump;
            }
            catch (Exception)
            {
                // If partition pump creation fails, we'll try again on the next time this method is called.  This should happen
                // on the next load balancing loop as long as this instance still owns the partition.
                // TODO: delegate the exception handling to an Exception Callback.
            }
        }

        /// <summary>
        ///   The handler to be called once event processing stops for a given partition.
        /// </summary>
        ///
        /// <param name="reason">The reason why the processing for the specified partition is being stopped.</param>
        /// <param name="context">TODO.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected async override Task ProcessingForPartitionStoppedAsync(ProcessingStoppedReason reason,
                                                                         PartitionContext context)
        {
            if (ProcessingForPartitionStoppedAsyncHandler != null)
            {
                try
                {
                    var stopContext = new PartitionProcessingStoppedContext(context, reason);
                    await ProcessingForPartitionStoppedAsyncHandler(stopContext);
                }
                catch (Exception)
                {
                    // TODO: delegate the exception handling to an Exception Callback.
                }
            }
        }

        /// <summary>
        ///   Responsible for processing events received from the Event Hubs service.
        /// </summary>
        ///
        /// <param name="eventData">TODO.</param>
        /// <param name="context">TODO.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected override Task ProcessEventAsync(EventData eventData,
                                                  PartitionContext context)
        {
            var processorEvent = new EventProcessorEvent(context, eventData, UpdateCheckpointAsync);
            return ProcessEventAsyncHandler(processorEvent);
        }

        /// <summary>
        ///   Responsible for processing unhandled exceptions thrown while this processor is running.
        /// </summary>
        ///
        /// <param name="exception">TODO.</param>
        /// <param name="context">TODO.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected override Task ProcessErrorAsync(Exception exception,
                                                  PartitionContext context)
        {
            var errorContext = new ProcessorErrorContext(context?.PartitionId, exception);
            return ProcessErrorAsyncHandler(errorContext);
        }

        /// <summary>
        ///   Retrieves a complete ownership list from the chosen storage service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
        ///
        protected override Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                    string eventHubName,
                                                                                    string consumerGroup) => Manager.ListOwnershipAsync(fullyQualifiedNamespace, eventHubName, consumerGroup);

        /// <summary>
        ///   Attempts to claim ownership of partitions for processing.
        /// </summary>
        ///
        /// <param name="partitionOwnership">An enumerable containing all the ownership to claim.</param>
        ///
        /// <returns>An enumerable containing the successfully claimed ownership instances.</returns>
        ///
        protected override Task<IEnumerable<PartitionOwnership>> ClaimOwnershipAsync(IEnumerable<PartitionOwnership> partitionOwnership) => Manager.ClaimOwnershipAsync(partitionOwnership);

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        /// <param name="context">The context of the partition the checkpoint is associated with.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected override async Task UpdateCheckpointAsync(EventData eventData,
                                                            PartitionContext context)
        {
            Argument.AssertNotNull(eventData, nameof(eventData));
            Argument.AssertNotNull(eventData.Offset, nameof(eventData.Offset));
            Argument.AssertNotNull(eventData.SequenceNumber, nameof(eventData.SequenceNumber));
            Argument.AssertNotNull(context, nameof(context));

            // Parameter validation is done by Checkpoint constructor.

            var checkpoint = new Checkpoint
            (
                FullyQualifiedNamespace,
                EventHubName,
                ConsumerGroup,
                Identifier,
                context.PartitionId,
                eventData.Offset.Value,
                eventData.SequenceNumber.Value
            );

            using DiagnosticScope scope =
                EventDataInstrumentation.ClientDiagnostics.CreateScope(DiagnosticProperty.EventProcessorCheckpointActivityName);
            scope.Start();

            try
            {
                await Manager.UpdateCheckpointAsync(checkpoint).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
            }
        }

        /// <summary>
        ///   Creates a <see cref="PartitionOwnership" /> instance based on the provided information.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the partition ownership is associated with.</param>
        /// <param name="offset">The offset of the last <see cref="EventData" /> checkpointed by the previous owner of the ownership.</param>
        /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> checkpointed by the previous owner of the ownership.</param>
        /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to the ownership.</param>
        /// <param name="eTag">The entity tag needed to update the ownership.</param>
        ///
        /// <returns>A <see cref="PartitionOwnership" /> instance based on the provided information.</returns>
        ///
        protected override PartitionOwnership CreatePartitionOwnership(string partitionId,
                                                                       long? offset,
                                                                       long? sequenceNumber,
                                                                       DateTimeOffset? lastModifiedTime,
                                                                       string eTag) => new PartitionOwnership(FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, partitionId, offset, sequenceNumber, lastModifiedTime, eTag);

        /// <summary>
        ///   Creates an <see cref="EventHubConnection" /> instance.  The returned instance must not be returned again by other
        ///   <see cref="CreateConnection" /> calls.
        /// </summary>
        ///
        /// <returns>A new <see cref="EventHubConnection" /> instance.</returns>
        ///
        /// <remarks>
        ///   The abstract <see cref="EventProcessorBase" /> class has ownership of the returned connection and, therefore, is
        ///   responsible for closing it.  Attempting to close the connection in the derived class may result in undefined behavior.
        /// </remarks>
        ///
        protected override EventHubConnection CreateConnection() => ConnectionFactory();

        /// <summary>
        ///   Starts the event processor.  In case it's already running, nothing happens.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="ProcessEventAsyncHandler" /> or <see cref="ProcessErrorAsyncHandler" /> set.</exception>
        ///
        public virtual async Task StartAsync()
        {
            Argument.AssertNotClosed(Closed, nameof(EventProcessorClient));

            if (ActiveLoadBalancingTask == null)
            {
                await RunningTaskSemaphore.WaitAsync().ConfigureAwait(false);

                try
                {
                    lock (StartProcessorGuard)
                    {
                        if (ActiveLoadBalancingTask == null)
                        {
                            if (_processEventAsyncHandler == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessEventAsyncHandler)));
                            }

                            if (_processErrorAsyncHandler == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessErrorAsyncHandler)));
                            }

                            // We expect the token source to be null, but we are playing safe.

                            RunningTaskTokenSource?.Cancel();
                            RunningTaskTokenSource = new CancellationTokenSource();

                            // Initialize our empty ownership dictionary.

                            InstanceOwnership = new Dictionary<string, PartitionOwnership>();

                            // Start the main running task.  It is responsible for managing the partition pumps and for partition
                            // load balancing among multiple event processor instances.

                            ActiveLoadBalancingTask = RunAsync(RunningTaskTokenSource.Token);
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
        ///   Stops the event processor.  In case it isn't running, nothing happens.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
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

                        // Now that the task has finished, clean up what is left.  Stop and remove every partition pump that is still
                        // running and dispose of our ownership dictionary.

                        InstanceOwnership = null;

                        await Task.WhenAll(PartitionPumps.Keys
                            .Select(partitionId => RemovePartitionPumpIfItExistsAsync(partitionId, ProcessingStoppedReason.Shutdown)))
                            .ConfigureAwait(false);

                        // We need to wait until all pumps have stopped before making the Active Load Balancing Task null.  If we did it sooner,
                        // we would have a race condition where the user could update the processing handlers while some pumps are still running.

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
        ///   Closes the event processor.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            Closed = true;

            await StopAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///   Closes the event processor.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public virtual void Close(CancellationToken cancellationToken = default) => CloseAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventProcessorClient" />,
        ///   including ensuring that the event client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///   Performs load balancing between multiple <see cref="EventProcessorClient" /> instances, claiming others' partitions to enforce
        ///   a more equal distribution when necessary.  It also manages its own partition pumps and ownership.
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

                await RenewOwnershipAsync().ConfigureAwait(false);

                // From the storage service provided by the user, obtain a complete list of ownership, including expired ones.  We may still need
                // their eTags to claim orphan partitions.

                var completeOwnershipList = (await ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup)
                    .ConfigureAwait(false))
                    .ToList();

                // Filter the complete ownership list to obtain only the ones that are still active.  The expiration time defaults to 30 seconds,
                // but it may be overridden by a derived class.

                IEnumerable<PartitionOwnership> activeOwnership = completeOwnershipList
                    .Where(ownership => DateTimeOffset.UtcNow.Subtract(ownership.LastModifiedTime.Value) < OwnershipExpiration);

                // Dispose of all previous partition ownership instances and get a whole new dictionary.

                InstanceOwnership = activeOwnership
                    .Where(ownership => ownership.OwnerIdentifier == Identifier)
                    .ToDictionary(ownership => ownership.PartitionId);

                // Some previously owned partitions might have had their ownership expired or might have been stolen, so we need to stop
                // the pumps we don't need anymore.

                await Task.WhenAll(PartitionPumps.Keys
                    .Except(InstanceOwnership.Keys)
                    .Select(partitionId => RemovePartitionPumpIfItExistsAsync(partitionId, ProcessingStoppedReason.OwnershipLost)))
                    .ConfigureAwait(false);

                // Now that we are left with pumps that should be running, check their status.  If any has stopped, it means an
                // unexpected failure has happened, so try closing it and starting a new one.  In case we don't have a pump that
                // should exist, create it.  This might happen when pump creation has failed in a previous cycle.

                await Task.WhenAll(InstanceOwnership
                    .Select(async kvp =>
                        {
                            if (PartitionPumps.TryGetValue(kvp.Key, out PartitionPump pump) && !pump.IsRunning)
                            {
                                await RemovePartitionPumpIfItExistsAsync(kvp.Key, ProcessingStoppedReason.Exception).ConfigureAwait(false);

                                var context = new PartitionContext(EventHubName, kvp.Key);
                                await InitializeProcessingForPartitionAsync(context).ConfigureAwait(false);
                            }
                        }))
                    .ConfigureAwait(false);

                // Get a complete list of the partition ids present in the Event Hub.  This should be immutable for the time being, but
                // it may change in the future.

                var partitionIds = await connection.GetPartitionIdsAsync(RetryPolicy).ConfigureAwait(false);

                // Find an ownership to claim and try to claim it.  The method will return null if this instance was not eligible to
                // increase its ownership list, if no claimable ownership could be found or if a claim attempt failed.

                PartitionOwnership claimedOwnership = await FindAndClaimOwnershipAsync(partitionIds, completeOwnershipList, activeOwnership).ConfigureAwait(false);

                if (claimedOwnership != null)
                {
                    InstanceOwnership[claimedOwnership.PartitionId] = claimedOwnership;

                    var context = new PartitionContext(EventHubName, claimedOwnership.PartitionId);
                    await InitializeProcessingForPartitionAsync(context).ConfigureAwait(false);
                }

                // Wait the remaining time, if any, to start the next cycle.  The total time of a cycle defaults to 10 seconds,
                // but it may be overridden by a derived class.

                TimeSpan remainingTimeUntilNextCycle = LoadBalanceUpdate - cycleDuration.Elapsed;

                if (remainingTimeUntilNextCycle > TimeSpan.Zero)
                {
                    // If a stop request has been issued, Task.Delay will throw a TaskCanceledException.  This is expected and it
                    // will be caught by the StopAsync method.

                    await Task.Delay(remainingTimeUntilNextCycle, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        ///   Invokes a specified action only if this <see cref="EventProcessorClient" /> instance is not running.
        /// </summary>
        ///
        /// <param name="action">The action to invoke.</param>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked while the event processor is running.</exception>
        ///
        private void EnsureNotRunningAndInvoke(Action action)
        {
            if (ActiveLoadBalancingTask == null)
            {
                lock (StartProcessorGuard)
                {
                    if (ActiveLoadBalancingTask == null)
                    {
                        action?.Invoke();
                    }
                    else
                    {
                        throw new InvalidOperationException(Resources.RunningEventProcessorCannotPerformOperation);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException(Resources.RunningEventProcessorCannotPerformOperation);
            }
        }
    }
}
