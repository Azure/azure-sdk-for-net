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
    public class EventProcessorClient : IAsyncDisposable
    {
        /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The random number generator to use for a specific thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim RunningTaskSemaphore = new SemaphoreSlim(1, 1);

        /// <summary>The primitive for synchronizing access during start and set handler operations.</summary>
        private readonly object StartProcessorGuard = new object();

        /// <summary>The handler to be called just before event processing starts for a given partition.</summary>
        private Func<InitializingPartitionEventArgs, ValueTask> _initializeProcessingForPartitionAsyncHandler;

        /// <summary>The handler to be called once event processing stops for a given partition.</summary>
        private Func<ClosingPartitionEventArgs, ValueTask> _processingForPartitionStoppedAsyncHandler;

        /// <summary>Responsible for processing events received from the Event Hubs service.</summary>
        private Func<ProcessingEventArgs, ValueTask> _processEventAsyncHandler;

        /// <summary>Responsible for processing unhandled exceptions thrown while this processor is running.</summary>
        private Func<ProcessingErrorEventArgs, ValueTask> _processErrorAsyncHandler;

        /// <summary>
        ///   The handler to be called just before event processing starts for a given partition.
        /// </summary>
        ///
        public Func<InitializingPartitionEventArgs, ValueTask> InitializeProcessingForPartitionAsyncHandler
        {
            get => _initializeProcessingForPartitionAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _initializeProcessingForPartitionAsyncHandler = value);
        }

        /// <summary>
        ///   The handler to be called once event processing stops for a given partition.
        /// </summary>
        ///
        public Func<ClosingPartitionEventArgs, ValueTask> ProcessingForPartitionStoppedAsyncHandler
        {
            get => _processingForPartitionStoppedAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _processingForPartitionStoppedAsyncHandler = value);
        }

        /// <summary>
        ///   Responsible for processing events received from the Event Hubs service.  Implementation is mandatory.
        /// </summary>
        ///
        public Func<ProcessingEventArgs, ValueTask> ProcessEventAsyncHandler
        {
            get => _processEventAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _processEventAsyncHandler = value);
        }

        /// <summary>
        ///   Responsible for processing unhandled exceptions thrown while this processor is running.
        ///   Implementation is mandatory.
        /// </summary>
        ///
        public Func<ProcessingErrorEventArgs, ValueTask> ProcessErrorAsyncHandler
        {
            get => _processErrorAsyncHandler;
            set => EnsureNotRunningAndInvoke(() => _processErrorAsyncHandler = value);
        }

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the processor is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that the processor is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        public string Identifier { get; }

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
        protected EventHubsRetryPolicy RetryPolicy { get; }

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
        private ConcurrentDictionary<string, PartitionContext> PartitionContexts { get; set; } = new ConcurrentDictionary<string, PartitionContext>();

        /// <summary>
        ///   The set of partition ownership this event processor owns.  Partition ids are used as keys.
        ///   TODO: create on constructor, destroy on close.
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
        }

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
            // TODO: we probably can remove this constructor and OwnsConnection property because the processor does not have
            // a single connection anymore.  In fact, returning the same connection from the factory might result in undefined
            // behavior.  We could take a connection factory here instead of a single connection.

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
        protected async ValueTask InitializeProcessingForPartitionAsync(PartitionContext context)
        {
            try
            {
                var startingPosition = EventPosition.Earliest;

                if (InitializeProcessingForPartitionAsyncHandler != null)
                {
                    var initializingArgs = new InitializingPartitionEventArgs(context);
                    await InitializeProcessingForPartitionAsyncHandler(initializingArgs).ConfigureAwait(false);

                    startingPosition = initializingArgs.DefaultStartingPosition;
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

                // TODO: it might be troublesome to let the users add running tasks by themselves.  If the user adds a custom
                // processing task that's not RunPartitionProcessingAsync, how would the base stop it?  It would not have a cancellation
                // token to do so.

                ActivePartitionProcessors[context.PartitionId] = RunPartitionProcessingAsync(context.PartitionId, startingPosition, Options.MaximumReceiveWaitTime, Options.RetryOptions, Options.TrackLastEnqueuedEventInformation);
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
        protected async ValueTask ProcessingForPartitionStoppedAsync(ProcessingStoppedReason reason,
                                                                     PartitionContext context)
        {
            if (ProcessingForPartitionStoppedAsyncHandler != null)
            {
                try
                {
                    var closingArgs = new ClosingPartitionEventArgs(context, reason);
                    await ProcessingForPartitionStoppedAsyncHandler(closingArgs);
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
        protected ValueTask ProcessEventAsync(PartitionEvent partitionEvent,
                                              PartitionContext context)
        {
            var eventArgs = new ProcessingEventArgs(context, partitionEvent.Data, this);
            return ProcessEventAsyncHandler(eventArgs);
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
        protected ValueTask ProcessErrorAsync(Exception exception,
                                              PartitionContext context)
        {
            var errorArgs = new ProcessingErrorEventArgs(context?.PartitionId, "TODO", exception);
            return ProcessErrorAsyncHandler(errorArgs);
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
        protected Task<IEnumerable<PartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
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
        protected Task<IEnumerable<PartitionOwnership>> ClaimOwnershipAsync(IEnumerable<PartitionOwnership> partitionOwnership) => Manager.ClaimOwnershipAsync(partitionOwnership);

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        /// <param name="context">The context of the partition the checkpoint is associated with.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        protected async Task UpdateCheckpointAsync(EventData eventData,
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
        /// <param name="offset">The offset of the last <see cref="EventData" /> checkpointed by the previous owner of the ownership.</param>
        /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> checkpointed by the previous owner of the ownership.</param>
        /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to the ownership.</param>
        /// <param name="eTag">The entity tag needed to update the ownership.</param>
        ///
        /// <returns>A <see cref="PartitionOwnership" /> instance based on the provided information.</returns>
        ///
        protected PartitionOwnership CreatePartitionOwnership(string partitionId,
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
        protected EventHubConnection CreateConnection() => ConnectionFactory();

        /// <summary>
        ///   Creates a context associated with a specific partition.  It will be passed to partition processing related methods,
        ///   such as <see cref="ProcessEventAsync" /> and <see cref="ProcessErrorAsync" />.
        /// </summary>
        ///
        /// <param name="partitionId">The partition the context is associated with.</param>
        ///
        /// <returns>A context associated with the specified partition.</returns>
        ///
        protected PartitionContext CreateContext(string partitionId) => new PartitionContext(partitionId);

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
        public async Task StartAsync()
        {
            Argument.AssertNotClosed(IsClosed, nameof(EventProcessorClient));

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

                            // Start the main running task.  It is responsible for managing the active partition processing tasks and
                            // for partition load balancing among multiple event processor instances.

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
            var newOwnership = CreatePartitionOwnership(partitionId, oldOwnership?.Offset, oldOwnership?.SequenceNumber, DateTimeOffset.UtcNow, oldOwnership?.ETag);

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
                    ownership.Offset,
                    ownership.SequenceNumber,
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
        /// <param name="trackLastEnqueuedEventInformation">Indicates whether or not the task should request information on the last enqueued event on the partition associated with a given event, and track that information as events are received.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The running task that is currently receiving and processing events in the context of the specified partition.</returns>
        ///
        protected virtual Task RunPartitionProcessingAsync(string partitionId,
                                                           EventPosition startingPosition,
                                                           TimeSpan? maximumReceiveWaitTime,
                                                           RetryOptions retryOptions,
                                                           bool trackLastEnqueuedEventInformation,
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

                var options = new EventHubConsumerClientOptions
                {
                    RetryOptions = retryOptions,
                    TrackLastEnqueuedEventInformation = trackLastEnqueuedEventInformation
                };

                await using var connection = CreateConnection();

                await using (var consumer = new EventHubConsumerClient(ConsumerGroup, connection, options))
                {
                    await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partitionId, startingPosition, maximumReceiveWaitTime, taskCancellationToken))
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
