// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Consumes events for the configured Event Hub and consumer group across all partitions, making them available for processing
    ///   through the provided handlers.
    /// </summary>
    ///
    public class EventProcessorClient
    {
        /// <summary>The delegate to invoke when attempting to update a checkpoint using an empty event.</summary>
        private static readonly Func<CancellationToken, Task> EmptyEventUpdateCheckpoint = cancellationToken => throw new InvalidOperationException(Resources.CannotCreateCheckpointForEmptyEvent);

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim RunningTaskSemaphore = new SemaphoreSlim(1, 1);

        /// <summary>The primitive for synchronizing access during start and set handler operations.</summary>
        private readonly object StartProcessorGuard = new object();

        /// <summary>The handler to be called just before event processing starts for a given partition.</summary>
        private Func<PartitionInitializingEventArgs, Task> _partitionInitializingAsync;

        /// <summary>The handler to be called once event processing stops for a given partition.</summary>
        private Func<PartitionClosingEventArgs, Task> _partitionClosingAsync;

        /// <summary>Responsible for processing events received from the Event Hubs service.</summary>
        private Func<ProcessEventArgs, Task> _processEventAsync;

        /// <summary>Responsible for processing unhandled exceptions thrown while this processor is running.</summary>
        private Func<ProcessErrorEventArgs, Task> _processErrorAsync;

        /// <summary>Indicates whether or not this event processor is currently running.  Used only for mocking purposes.</summary>
        private bool? _isRunningOverride;

        /// <summary>
        ///   The event to be raised just before event processing starts for a given partition.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<PartitionInitializingEventArgs, Task> PartitionInitializingAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(PartitionInitializingAsync));

                if (_partitionInitializingAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _partitionInitializingAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(PartitionInitializingAsync));

                if (_partitionInitializingAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _partitionInitializingAsync = default);
            }
        }

        /// <summary>
        ///   The event to be raised once event processing stops for a given partition.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<PartitionClosingEventArgs, Task> PartitionClosingAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(PartitionClosingAsync));

                if (_partitionClosingAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _partitionClosingAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(PartitionClosingAsync));

                if (_partitionClosingAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _partitionClosingAsync = default);
            }
        }

        /// <summary>
        ///   The event responsible for processing events received from the Event Hubs service.  Implementation
        ///   is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessEventArgs, Task> ProcessEventAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessEventAsync));

                if (_processEventAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processEventAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessEventAsync));

                if (_processEventAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processEventAsync = default);
            }
        }

        /// <summary>
        ///   The event responsible for processing unhandled exceptions thrown while this processor is running.
        ///   Implementation is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessErrorEventArgs, Task> ProcessErrorAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = default);
            }
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
        ///   Indicates whether or not this event processor is currently running.
        /// </summary>
        ///
        public bool IsRunning
        {
            get
            {
                if (_isRunningOverride.HasValue)
                {
                    return _isRunningOverride.Value;
                }

                // Capture the load balancing task so we don't end up with a race condition.

                var loadBalancingTask = ActiveLoadBalancingTask;

                return loadBalancingTask != null && !loadBalancingTask.IsCompleted;
            }

            protected set => _isRunningOverride = value;
        }

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        public string Identifier { get; }

        /// <summary>
        ///   Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.
        /// </summary>
        ///
        private PartitionManager StorageManager { get; }

        /// <summary>
        ///   Responsibility for load balancing of partition ownership.
        /// </summary>
        ///
        private PartitionLoadBalancer LoadBalancer { get; }

        /// <summary>
        ///   The set of options to use for consumers responsible for partition processing.
        /// </summary>
        ///
        private EventHubConsumerClientOptions ProcessingConsumerOptions { get; }

        /// <summary>
        ///   The set of options to use to read events when processing a partition.
        /// </summary>
        ///
        private ReadEventOptions ProcessingReadEventOptions { get; }

        /// <summary>
        ///   A factory used to provide new <see cref="EventHubConnection" /> instances.
        /// </summary>
        ///
        private Func<EventHubConnection> ConnectionFactory { get; }

        /// <summary>
        ///   The active policy which governs retry attempts for the
        ///   processor.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The running task responsible for performing partition load balancing between multiple <see cref="EventProcessorClient" />
        ///   instances, as well as managing partition processing tasks and ownership.
        /// </summary>
        ///
        private Task ActiveLoadBalancingTask { get; set; }

        /// <summary>
        ///   A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the current running task.
        /// </summary>
        ///
        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        /// <summary>
        ///   The set of currently active partition processing tasks issued by this event processor and their associated
        ///   token sources that can be used to cancel the operation.  Partition ids are used as keys.
        /// </summary>
        ///
        private ConcurrentDictionary<string, (Task, CancellationTokenSource)> ActivePartitionProcessors { get; set; } = new ConcurrentDictionary<string, (Task, CancellationTokenSource)>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
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
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string connectionString) : this(checkpointStore, consumerGroup, connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
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
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string connectionString,
                                    EventProcessorClientOptions clientOptions) : this(checkpointStore, consumerGroup, connectionString, null, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string connectionString,
                                    string eventHubName) : this(checkpointStore, consumerGroup, connectionString, eventHubName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string connectionString,
                                    string eventHubName,
                                    EventProcessorClientOptions clientOptions)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            clientOptions = clientOptions?.Clone() ?? new EventProcessorClientOptions();

            ProcessingConsumerOptions = new EventHubConsumerClientOptions
            {
                RetryOptions = clientOptions.RetryOptions
            };

            ProcessingReadEventOptions = new ReadEventOptions
            {
                MaximumWaitTime = clientOptions.MaximumWaitTime,
                TrackLastEnqueuedEventProperties = clientOptions.TrackLastEnqueuedEventProperties
            };

            ConnectionStringProperties connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            ConnectionFactory = () => new EventHubConnection(connectionString, eventHubName, clientOptions.ConnectionOptions);
            FullyQualifiedNamespace = connectionStringProperties.Endpoint.Host;
            EventHubName = string.IsNullOrEmpty(eventHubName) ? connectionStringProperties.EventHubName : eventHubName;
            ConsumerGroup = consumerGroup;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            StorageManager = CreateStorageManager(checkpointStore);
            Identifier = string.IsNullOrEmpty(clientOptions.Identifier) ? Guid.NewGuid().ToString() : clientOptions.Identifier;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        ///
        public EventProcessorClient(BlobContainerClient checkpointStore,
                                    string consumerGroup,
                                    string fullyQualifiedNamespace,
                                    string eventHubName,
                                    TokenCredential credential,
                                    EventProcessorClientOptions clientOptions = default)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            clientOptions = clientOptions?.Clone() ?? new EventProcessorClientOptions();

            ProcessingConsumerOptions = new EventHubConsumerClientOptions
            {
                RetryOptions = clientOptions.RetryOptions
            };

            ProcessingReadEventOptions = new ReadEventOptions
            {
                MaximumWaitTime = clientOptions.MaximumWaitTime,
                TrackLastEnqueuedEventProperties = clientOptions.TrackLastEnqueuedEventProperties
            };

            ConnectionFactory = () => new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential, clientOptions.ConnectionOptions);
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            StorageManager = CreateStorageManager(checkpointStore);
            Identifier = string.IsNullOrEmpty(clientOptions.Identifier) ? Guid.NewGuid().ToString() : clientOptions.Identifier;
            LoadBalancer = new PartitionLoadBalancer(StorageManager, Identifier, consumerGroup, fullyQualifiedNamespace, eventHubName, TimeSpan.FromSeconds(30));
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        protected EventProcessorClient()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessorClient"/> class.
        /// </summary>
        ///
        /// <param name="storageManager">Interacts with the storage system with responsibility for creation of checkpoints and for ownership claim.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="connectionFactory">A factory used to provide new <see cref="EventHubConnection" /> instances.</param>
        /// <param name="clientOptions">The set of options to use for this processor.</param>
        /// <param name="loadBalancer">The <see cref="PartitionLoadBalancer" /> used to manage partition load balance operations.</param>
        ///
        /// <remarks>
        ///   This constructor is intended only to support functional testing and mocking; it should not be used for production scenarios.
        /// </remarks>
        ///
        internal EventProcessorClient(PartitionManager storageManager,
                                      string consumerGroup,
                                      string fullyQualifiedNamespace,
                                      string eventHubName,
                                      Func<EventHubConnection> connectionFactory,
                                      EventProcessorClientOptions clientOptions,
                                      PartitionLoadBalancer loadBalancer = default)
        {
            Argument.AssertNotNull(storageManager, nameof(storageManager));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(connectionFactory, nameof(connectionFactory));

            clientOptions = clientOptions?.Clone() ?? new EventProcessorClientOptions();

            ProcessingConsumerOptions = new EventHubConsumerClientOptions
            {
                RetryOptions = clientOptions.RetryOptions
            };

            ProcessingReadEventOptions = new ReadEventOptions
            {
                MaximumWaitTime = clientOptions.MaximumWaitTime,
                TrackLastEnqueuedEventProperties = clientOptions.TrackLastEnqueuedEventProperties
            };

            ConnectionFactory = connectionFactory;
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            StorageManager = storageManager;
            Identifier = string.IsNullOrEmpty(clientOptions.Identifier) ? Guid.NewGuid().ToString() : clientOptions.Identifier;
            LoadBalancer = loadBalancer ?? new PartitionLoadBalancer(storageManager, Identifier, consumerGroup, fullyQualifiedNamespace, eventHubName, TimeSpan.FromSeconds(30));
        }

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to begin processing events.  Should this method be called while the processor
        ///   is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="EventProcessorClient" /> once it starts running.</param>
        ///
        /// <exception cref="EventHubsClientClosedException">Occurs when this <see cref="EventProcessorClient" /> instance is already closed.</exception>
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="ProcessEventAsync" /> or <see cref="ProcessErrorAsync" /> set.</exception>
        ///
        public virtual async Task StartProcessingAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            if (ActiveLoadBalancingTask == null)
            {
                await RunningTaskSemaphore.WaitAsync().ConfigureAwait(false);

                try
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    lock (StartProcessorGuard)
                    {
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        if (ActiveLoadBalancingTask == null)
                        {
                            if (_processEventAsync == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessEventAsync)));
                            }

                            if (_processErrorAsync == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessErrorAsync)));
                            }

                            // We expect the token source to be null, but we are playing safe.

                            RunningTaskTokenSource?.Cancel();
                            RunningTaskTokenSource?.Dispose();
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
        ///   Signals the <see cref="EventProcessorClient" /> to begin processing events.  Should this method be called while the processor
        ///   is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="EventProcessorClient" /> once it starts running.</param>
        ///
        /// <exception cref="EventHubsClientClosedException">Occurs when this <see cref="EventProcessorClient" /> instance is already closed.</exception>
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="ProcessEventAsync" /> or <see cref="ProcessErrorAsync" /> set.</exception>
        ///
        public virtual void StartProcessing(CancellationToken cancellationToken = default) => StartProcessingAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to stop processing events.  Should this method be called while the processor
        ///   is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="EventProcessorClient" /> will keep running.</param>
        ///
        public virtual async Task StopProcessingAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            await RunningTaskSemaphore.WaitAsync().ConfigureAwait(false);

            try
            {
                if (ActiveLoadBalancingTask != null)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    // Cancel the current running task.

                    RunningTaskTokenSource.Cancel();
                    RunningTaskTokenSource.Dispose();
                    RunningTaskTokenSource = null;

                    // Now that a cancellation request has been issued, wait for the running task to finish.  In case something
                    // unexpected happened and it stopped working midway, this is the moment we expect to catch an exception.

                    Exception loadBalancingException = default;

                    try
                    {
                        await ActiveLoadBalancingTask.ConfigureAwait(false);
                    }
                    catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
                    {
                        // Nothing to do here.  These exceptions are expected.
                    }
                    catch (Exception ex)
                    {
                        loadBalancingException = ex;
                    }

                    // Now that the task has finished, clean up what is left.  Stop and remove every partition processing task that is
                    // still running and clear our dictionaries.  ActivePartitionProcessors dictionary is already cleared by the
                    // StopPartitionProcessingIfRunningAsync method.

                    await Task.WhenAll(ActivePartitionProcessors.Keys
                        .Select(partitionId => StopPartitionProcessingIfRunningAsync(partitionId, ProcessingStoppedReason.Shutdown, CancellationToken.None)))
                        .ConfigureAwait(false);

                    // Stop the LoadBalancer.

                    await LoadBalancer.StopAsync(cancellationToken);

                    // We need to wait until all tasks have stopped before making the load balancing task null.  If we did it sooner, we
                    // would have a race condition where the user could update the processing handlers while some pumps are still running.

                    ActiveLoadBalancingTask.Dispose();
                    ActiveLoadBalancingTask = null;

                    if (loadBalancingException != default)
                    {
                        throw loadBalancingException;
                    }
                }
            }
            finally
            {
                RunningTaskSemaphore.Release();
            }
        }

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to stop processing events.  Should this method be called while the processor
        ///   is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="EventProcessorClient" /> will keep running.</param>
        ///
        public virtual void StopProcessing(CancellationToken cancellationToken = default) => StopProcessingAsync(cancellationToken).GetAwaiter().GetResult();

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
        public override string ToString() => $"Event Processor: { Identifier }";

        /// <summary>
        ///   Updates the checkpoint using the given information for the associated partition and consumer group in the chosen storage service.
        /// </summary>
        ///
        /// <param name="eventData">The event containing the information to be stored in the checkpoint.</param>
        /// <param name="context">The context of the partition the checkpoint is associated with.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        internal Task UpdateCheckpointAsync(EventData eventData,
                                            PartitionContext context,
                                            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

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
                return StorageManager.UpdateCheckpointAsync(checkpoint, cancellationToken);
            }
            catch (Exception e)
            {
                // In case of failure, there is no need to call the error handler because the exception can
                // be thrown directly to the user here.

                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        ///   Creates an <see cref="EventHubConsumerClient" /> to use for processing.
        /// </summary>
        ///
        /// <param name="consumerGroup">The consumer group to associate with the consumer client.</param>
        /// <param name="connection">The connection to use for the consumer client.</param>
        /// <param name="options">The options to use for configuring the consumer client.</param>
        ///
        /// <returns>An <see cref="EventHubConsumerClient" /> with the requested configuration.</returns>
        ///
        internal virtual EventHubConsumerClient CreateConsumer(string consumerGroup,
                                                               EventHubConnection connection,
                                                               EventHubConsumerClientOptions options) => new EventHubConsumerClient(consumerGroup, connection, options);

        /// <summary>
        ///   Creates a <see cref="PartitionManager" /> to use for interacting with durable storage.
        /// </summary>
        ///
        /// <param name="checkpointStore">The client responsible for interaction with durable storage, responsible for persisting checkpoints and load-balancing state.</param>
        ///
        /// <returns>A <see cref="PartitionManager" /> with the requested configuration.</returns>
        ///
        internal virtual PartitionManager CreateStorageManager(BlobContainerClient checkpointStore) => new BlobsCheckpointStore(checkpointStore, RetryPolicy);

        /// <summary>
        ///   Starts running a task responsible for receiving and processing events in the context of a specified partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the task is associated with.  Events will be read only from this partition.</param>
        /// <param name="startingPosition">The position within the partition where the task should begin reading events.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The running task that is currently receiving and processing events in the context of the specified partition.</returns>
        ///
        internal virtual Task RunPartitionProcessingAsync(string partitionId,
                                                          EventPosition startingPosition,
                                                          CancellationToken cancellationToken) => Task.Run(async () =>
        {
            var emptyPartitionContext = new EmptyPartitionContext(partitionId);

            await using var connection = ConnectionFactory();
            await using var consumer = CreateConsumer(ConsumerGroup, connection, ProcessingConsumerOptions);
            await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partitionId, startingPosition, ProcessingReadEventOptions, cancellationToken).ConfigureAwait(false))
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
                    Func<CancellationToken, Task> updateCheckpoint;

                    if (partitionEvent.Data != null)
                    {
                        updateCheckpoint = updateCheckpointToken => UpdateCheckpointAsync(partitionEvent.Data, partitionEvent.Partition, updateCheckpointToken);
                    }
                    else
                    {
                        updateCheckpoint = EmptyEventUpdateCheckpoint;
                    }

                    var eventArgs = new ProcessEventArgs(partitionEvent.Partition ?? emptyPartitionContext, partitionEvent.Data, updateCheckpoint, RunningTaskTokenSource.Token);

                    await OnProcessEventAsync(eventArgs).ConfigureAwait(false);
                }
                catch (Exception eventProcessingException)
                {
                    diagnosticScope.Failed(eventProcessingException);
                    throw;
                }
            }
        });

        /// <summary>
        ///   Called when a 'partition initializing' event is triggered.
        /// </summary>
        ///
        /// <param name="eventArgs">The set of arguments to identify the context of the partition that will be processed.</param>
        ///
        private Task OnPartitionInitializingAsync(PartitionInitializingEventArgs eventArgs)
        {
            if (_partitionInitializingAsync != null)
            {
                return _partitionInitializingAsync(eventArgs);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///   Called when a 'partition closing' event is triggered.
        /// </summary>
        ///
        /// <param name="eventArgs">The set of arguments to identify the context of the partition that was being processed.</param>
        ///
        private Task OnPartitionClosingAsync(PartitionClosingEventArgs eventArgs)
        {
            if (_partitionClosingAsync != null)
            {
                return _partitionClosingAsync(eventArgs);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///   Called when a 'process event' event is triggered.
        /// </summary>
        ///
        /// <param name="eventArgs">The set of arguments to identify the context of the event to be processed.</param>
        ///
        private Task OnProcessEventAsync(ProcessEventArgs eventArgs) => _processEventAsync(eventArgs);

        /// <summary>
        ///   Called when a 'process error' event is triggered.
        /// </summary>
        ///
        /// <param name="eventArgs">The set of arguments to identify the context of the error to be processed.</param>
        ///
        private Task OnProcessErrorAsync(ProcessErrorEventArgs eventArgs) => _processErrorAsync(eventArgs);

        /// <summary>
        ///   Performs load balancing between multiple <see cref="EventProcessorClient" /> instances, claiming others' partitions to enforce
        ///   a more equal distribution when necessary.  It also manages its own partition processing tasks and ownership.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // We'll use this connection to retrieve an updated list of partition ids from the service.

            await using var consumer = CreateConsumer(ConsumerGroup, ConnectionFactory(), ProcessingConsumerOptions);

            while (!cancellationToken.IsCancellationRequested)
            {
                var cycleDuration = Stopwatch.StartNew();

                // Some previously owned partitions might have had their ownership expired or might have been stolen, so we need to stop
                // the processing tasks we don't need anymore.

                await Task.WhenAll(ActivePartitionProcessors.Keys
                    .Except(LoadBalancer.OwnedPartitionIds)
                    .Select(partitionId => StopPartitionProcessingIfRunningAsync(partitionId, ProcessingStoppedReason.OwnershipLost, cancellationToken)))
                    .ConfigureAwait(false);

                // Get a complete list of the partition ids present in the Event Hub.  This should be immutable for the time being, but
                // it may change in the future.

                var partitionIds = default(string[]);

                try
                {
                    partitionIds = await consumer.GetPartitionIdsAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    var errorEventArgs = new ProcessErrorEventArgs(null, Resources.OperationGetPartitionIds, ex, cancellationToken);
                    _ = OnProcessErrorAsync(errorEventArgs);
                }

                // There's no point in continuing the current cycle if we failed to fetch the partitionIds.

                if (partitionIds != default)
                {
                    PartitionOwnership claimedOwnership = default;

                    try
                    {
                        claimedOwnership = await LoadBalancer.RunAsync(partitionIds, cancellationToken);
                    }
                    catch (EventHubsException ex)
                    {
                        var errorEventArgs = new ProcessErrorEventArgs(null, ex.Message, ex, cancellationToken);
                        _ = OnProcessErrorAsync(errorEventArgs);
                    }
                    catch (Exception ex)
                    {
                        var errorEventArgs = new ProcessErrorEventArgs(null, string.Empty /*which resource to use here?*/, ex, cancellationToken);
                        _ = OnProcessErrorAsync(errorEventArgs);
                    }

                    if (claimedOwnership != default)
                    {
                        await StartPartitionProcessingAsync(claimedOwnership.PartitionId, cancellationToken).ConfigureAwait(false);
                    }
                }

                // Wait the remaining time, if any, to start the next cycle.  The total time of a cycle defaults to 10 seconds,
                // but it may be overridden by a derived class.

                var remainingTimeUntilNextCycle = LoadBalancer.LoadBalanceUpdate.CalculateRemaining(cycleDuration.Elapsed);

                // If a stop request has been issued, Task.Delay will throw a TaskCanceledException.  This is expected and it
                // will be caught by the StopAsync method.

                await Task.Delay(remainingTimeUntilNextCycle, cancellationToken).ConfigureAwait(false);
            }

            // If cancellation has been requested, throw an exception so we can keep a consistent behavior.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
        }

        /// <summary>
        ///   Creates and starts running a new partition processing task.  Another task might be overwritten by the creation
        ///   of the new one and, for this reason, it needs to be stopped prior to this method call.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is starting.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        private async Task StartPartitionProcessingAsync(string partitionId,
                                                         CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var initializingEventArgs = new PartitionInitializingEventArgs(partitionId, EventPosition.Earliest, cancellationToken);
            await OnPartitionInitializingAsync(initializingEventArgs).ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            IEnumerable<Checkpoint> availableCheckpoints;

            try
            {
                availableCheckpoints = await StorageManager.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // If processing task creation fails, we'll try again on the next time this method is called.
                // This should happen on the next load balancing loop as long as this instance still owns the
                // partition.

                var errorEventArgs = new ProcessErrorEventArgs(null, Resources.OperationListCheckpoints, ex, cancellationToken);
                _ = OnProcessErrorAsync(errorEventArgs);

                return;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var startingPosition = initializingEventArgs.DefaultStartingPosition;

            foreach (var checkpoint in availableCheckpoints)
            {
                if (checkpoint.PartitionId == partitionId)
                {
                    // When resuming from a checkpoint, the intent to process the next available event in the stream which
                    // follows the one that was used to create the checkpoint.  Because the offset is inclusive, increment
                    // the value from the checkpoint in order to force a shift to the next available event in the stream.

                    startingPosition = EventPosition.FromOffset(checkpoint.Offset + 1);
                    break;
                }
            }

            var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(RunningTaskTokenSource.Token);
            var processingTask = RunPartitionProcessingAsync(partitionId, startingPosition, tokenSource.Token);

            ActivePartitionProcessors[partitionId] = (processingTask, tokenSource);
        }

        /// <summary>
        ///   Stops an owned partition processing task in case it is running.  It is also removed from the tasks dictionary
        ///   along with its corresponding token source.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is being stopped.</param>
        /// <param name="reason">The reason why the processing for the specified partition is being stopped.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        private async Task StopPartitionProcessingIfRunningAsync(string partitionId,
                                                                 ProcessingStoppedReason reason,
                                                                 CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            if (ActivePartitionProcessors.TryRemove(partitionId, out var activeTaskAndTokenSource))
            {
                var (processingTask, tokenSource) = activeTaskAndTokenSource;

                try
                {
                    tokenSource.Cancel();
                    await processingTask.ConfigureAwait(false);
                }
                catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
                {
                    // Nothing to do here.  These exceptions are expected.
                }
                catch (Exception ex)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    // TODO: should the handler be notified in the processing task instead?  User will be notified
                    // earlier.

                    var errorEventArgs = new ProcessErrorEventArgs(partitionId, Resources.OperationReadEvents, ex, cancellationToken);
                    _ = OnProcessErrorAsync(errorEventArgs);
                }
                finally
                {
                    processingTask.Dispose();
                    tokenSource.Dispose();
                }
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            // TODO: if reason = Shutdown or OwnershipLost and we got an exception when closing, what should the final reason be?

            var closingEventArgs = new PartitionClosingEventArgs(partitionId, reason, cancellationToken);
            _ = OnPartitionClosingAsync(closingEventArgs);
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

        /// <summary>
        ///   Represents a basic partition context for event processing when the
        ///   full context was not available.
        /// </summary>
        ///
        /// <seealso cref="Azure.Messaging.EventHubs.PartitionContext" />
        ///
        private class EmptyPartitionContext : PartitionContext
        {
            /// <summary>
            ///   Initializes a new instance of the <see cref="EmptyPartitionContext" /> class.
            /// </summary>
            ///
            /// <param name="partitionId">The identifier of the partition that the context represents.</param>
            ///
            public EmptyPartitionContext(string partitionId) : base(partitionId)
            {
            }

            /// <summary>
            ///   A set of information about the last enqueued event of a partition, not available for the
            ///   empty context.
            /// </summary>
            ///
            /// <returns>The set of properties for the last event that was enqueued to the partition.</returns>
            ///
            /// <exception cref="InvalidOperationException">The method call is not available on the <see cref="EmptyPartitionContext"/>.</exception>
            ///
            public override LastEnqueuedEventProperties ReadLastEnqueuedEventProperties() =>
                throw new InvalidOperationException(Resources.CannotReadLastEnqueuedEventPropertiesWithoutEvent);
        }
    }
}
