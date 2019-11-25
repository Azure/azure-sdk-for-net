// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Errors;
using Azure.Messaging.EventHubs.Metadata;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Consumes events for the configured Event Hub and consumer group across all partitions, making them available for processing
    ///   through the provided handlers.
    /// </summary>
    ///
    public class EventProcessorClient : EventProcessorBase<PartitionContext>, IAsyncDisposable
    {
        /// <summary>The primitive for synchronizing access during start and set handler operations.</summary>
        private readonly object StartProcessorGuard = new object();

        /// <summary>The handler to be called just before event processing starts for a given partition.</summary>
        private Func<InitializePartitionProcessingContext, ValueTask> _initializeProcessingForPartitionAsyncHandler;

        /// <summary>The handler to be called once event processing stops for a given partition.</summary>
        private Func<PartitionProcessingStoppedContext, ValueTask> _processingForPartitionStoppedAsyncHandler;

        /// <summary>Responsible for processing events received from the Event Hubs service.</summary>
        private Func<EventProcessorEvent, ValueTask> _processEventAsyncHandler;

        /// <summary>Responsible for processing unhandled exceptions thrown while this processor is running.</summary>
        private Func<ProcessorErrorContext, ValueTask> _processErrorAsyncHandler;

        /// <summary>
        ///   The handler to be called just before event processing starts for a given partition.
        /// </summary>
        ///
        public Func<InitializePartitionProcessingContext, ValueTask> InitializeProcessingForPartitionAsyncHandler
        {
            get => _initializeProcessingForPartitionAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _initializeProcessingForPartitionAsyncHandler = value);
        }

        /// <summary>
        ///   The handler to be called once event processing stops for a given partition.
        /// </summary>
        ///
        public Func<PartitionProcessingStoppedContext, ValueTask> ProcessingForPartitionStoppedAsyncHandler
        {
            get => _processingForPartitionStoppedAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _processingForPartitionStoppedAsyncHandler = value);
        }

        /// <summary>
        ///   Responsible for processing events received from the Event Hubs service.  Implementation is mandatory.
        /// </summary>
        ///
        public Func<EventProcessorEvent, ValueTask> ProcessEventAsyncHandler
        {
            get => _processEventAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _processEventAsyncHandler = value);
        }

        /// <summary>
        ///   Responsible for processing unhandled exceptions thrown while this processor is running.
        ///   Implementation is mandatory.
        /// </summary>
        ///
        public Func<ProcessorErrorContext, ValueTask> ProcessErrorAsyncHandler
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
        ///   A factory used to provide new <see cref="EventHubConnection" /> instances upon <see cref="CreateConnection"/>
        ///   call.
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
        public bool IsClosed { get; protected set; } = false;

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
        protected override EventHubsRetryPolicy RetryPolicy { get; }

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
        /// <param name="clientOptions">The set of options to use for this processor.</param>
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
                                    EventProcessorClientOptions clientOptions) : this(consumerGroup, partitionManager, connectionString, null, clientOptions)
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
        /// <param name="clientOptions">The set of options to use for this processor.</param>
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
                                    EventProcessorClientOptions clientOptions)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(partitionManager, nameof(partitionManager));
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            clientOptions = clientOptions?.Clone() ?? new EventProcessorClientOptions();

            ConnectionStringProperties connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            OwnsConnection = true;
            ConnectionFactory = () => new EventHubConnection(connectionString, eventHubName, clientOptions.ConnectionOptions);
            FullyQualifiedNamespace = connectionStringProperties.Endpoint.Host;
            EventHubName = string.IsNullOrEmpty(eventHubName) ? connectionStringProperties.EventHubName : eventHubName;
            ConsumerGroup = consumerGroup;
            Manager = partitionManager;
            Options = clientOptions;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            Identifier = Guid.NewGuid().ToString();
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
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        public EventProcessorClient(string consumerGroup,
                                    PartitionManager partitionManager,
                                    string fullyQualifiedNamespace,
                                    string eventHubName,
                                    TokenCredential credential,
                                    EventProcessorClientOptions clientOptions = default)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(partitionManager, nameof(partitionManager));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            clientOptions = clientOptions?.Clone() ?? new EventProcessorClientOptions();

            OwnsConnection = true;
            ConnectionFactory = () => new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential, clientOptions.ConnectionOptions);
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            Manager = partitionManager;
            Options = clientOptions;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            Identifier = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   This constructor is intended only to support functional testing and mocking; it should not be used for production scenarios.
        /// </remarks>
        ///
        protected internal EventProcessorClient(string consumerGroup,
                                                PartitionManager partitionManager,
                                                EventHubConnection connection,
                                                EventProcessorClientOptions clientOptions)
        {
            // TODO: we probably can remove this constructor and OwnsConnection property because the processor does not have
            // a single connection anymore.  In fact, returning the same connection from the factory might result in undefined
            // behavior.  We could take a connection factory here instead of a single connection.

            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(partitionManager, nameof(partitionManager));
            Argument.AssertNotNull(connection, nameof(connection));

            clientOptions = clientOptions?.Clone() ?? new EventProcessorClientOptions();

            OwnsConnection = false;
            ConnectionFactory = () => connection;
            FullyQualifiedNamespace = connection.FullyQualifiedNamespace;
            EventHubName = connection.EventHubName;
            ConsumerGroup = consumerGroup;
            Manager = partitionManager;
            Options = clientOptions;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            Identifier = Guid.NewGuid().ToString();
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
        ///   The function to be called just before event processing starts for a given partition.
        /// </summary>
        ///
        /// <param name="context">The context in which the associated partition will be processed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected override async ValueTask InitializeProcessingForPartitionAsync(PartitionContext context)
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

                var availableCheckpoints = await ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup);
                foreach (Checkpoint checkpoint in availableCheckpoints)
                {
                    if (checkpoint.PartitionId == context.PartitionId)
                    {
                        startingPosition = EventPosition.FromOffset(checkpoint.Offset);
                        break;
                    }
                }

                // TODO: it might be troublesome to let the users add running tasks by themselves.  If the user adds a custom
                // processing task that's not RunPartitionProcessingAsync, how would the base stop it?  It would not have a cancellation
                // token to do so.

                ActivePartitionProcessors[context.PartitionId] = RunPartitionProcessingAsync(context.PartitionId, startingPosition, Options.MaximumReceiveWaitTime, Options.RetryOptions, Options.TrackLastEnqueuedEventProperties);
            }
            catch (Exception)
            {
                // If processing task creation fails, we'll try again on the next time this method is called.  This should happen
                // on the next load balancing loop as long as this instance still owns the partition.
                // TODO: delegate the exception handling to an Exception Callback.  Do we really need a try-catch here?
            }
        }

        /// <summary>
        ///   The handler to be called once event processing stops for a given partition.
        /// </summary>
        ///
        /// <param name="reason">The reason why the processing for the associated partition is being stopped.</param>
        /// <param name="context">The context in which the associated partition was being processed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected async override ValueTask ProcessingForPartitionStoppedAsync(ProcessingStoppedReason reason,
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
                    // Maybe we should just surface the exception.
                }
            }
        }

        /// <summary>
        ///   Responsible for processing events received from the Event Hubs service.
        /// </summary>
        ///
        /// <param name="partitionEvent">The partition event to be processed.</param>
        /// <param name="context">The context in which the associated partition is being processed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected override ValueTask ProcessEventAsync(PartitionEvent partitionEvent,
                                                       PartitionContext context)
        {
            var processorEvent = new EventProcessorEvent(context, partitionEvent.Data, this);
            return ProcessEventAsyncHandler(processorEvent);
        }

        /// <summary>
        ///   Responsible for processing unhandled exceptions thrown while this processor is running.
        /// </summary>
        ///
        /// <param name="exception">The exception to be processed.</param>
        /// <param name="context">The context in which the associated partition was being processed when the exception was thrown.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected override ValueTask ProcessErrorAsync(Exception exception,
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
        /// <returns>An enumerable containing all the existing ownership for the associated namespace, Event Hub and consumer group.</returns>
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
        ///   Retrieves a complete checkpoints list from the chosen storage service.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        /// <returns>An enumerable containing all the existing checkpoints for the associated Event Hub and consumer group.</returns>
        ///
        protected override Task<IEnumerable<Checkpoint>> ListCheckpointsAsync(string fullyQualifiedNamespace,
                                                                              string eventHubName,
                                                                              string consumerGroup) => Manager.ListCheckpointsAsync(fullyQualifiedNamespace, eventHubName, consumerGroup);

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
                throw;
            }
        }

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        /// <param name="context">The context of the partition the checkpoint is associated with.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        internal Task InternalUpdateCheckpointAsync(EventData eventData,
                                                    PartitionContext context) => UpdateCheckpointAsync(eventData, context);

        /// <summary>
        ///   Creates a <see cref="PartitionOwnership" /> instance based on the provided information.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the partition ownership is associated with.</param>
        /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to the ownership.</param>
        /// <param name="eTag">The entity tag needed to update the ownership.</param>
        ///
        /// <returns>A <see cref="PartitionOwnership" /> instance based on the provided information.</returns>
        ///
        protected override PartitionOwnership CreatePartitionOwnership(string partitionId,
                                                                       DateTimeOffset? lastModifiedTime,
                                                                       string eTag) => new PartitionOwnership(FullyQualifiedNamespace, EventHubName, ConsumerGroup, Identifier, partitionId, lastModifiedTime, eTag);

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
        protected override EventHubConnection CreateConnection() => ConnectionFactory();

        /// <summary>
        ///   Creates a context associated with a specific partition.  It will be passed to partition processing related methods,
        ///   such as <see cref="ProcessEventAsync" /> and <see cref="ProcessErrorAsync" />.
        /// </summary>
        ///
        /// <param name="partitionId">The partition the context is associated with.</param>
        ///
        /// <returns>A context associated with the specified partition.</returns>
        ///
        protected override PartitionContext CreateContext(string partitionId) => new PartitionContext(partitionId);

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
            IsClosed = true;

            await StopAsync().ConfigureAwait(false);
        }

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
        /// <exception cref="EventHubsClientClosedException">Occurs when this <see cref="EventProcessorClient" /> instance is already closed.</exception>
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="ProcessEventAsyncHandler" /> or <see cref="ProcessErrorAsyncHandler" /> set.</exception>
        ///
        public override Task StartAsync()
        {
            Argument.AssertNotClosed(IsClosed, nameof(EventProcessorClient));

            lock (StartProcessorGuard)
            {
                if (_processEventAsyncHandler == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessEventAsyncHandler)));
                }

                if (_processErrorAsyncHandler == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessErrorAsyncHandler)));
                }

                return base.StartAsync();
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
