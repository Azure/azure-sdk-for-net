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
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Processor
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
        private Func<PartitionContext, Task> _initializeProcessingForPartitionAsync;

        /// <summary>The handler to be called once event processing stops for a given partition.</summary>
        private Func<PartitionContext, PartitionProcessorCloseReason, Task> _processingForPartitionStoppedAsync;

        /// <summary>Responsible for processing sets of events received from the Event Hubs service.</summary>
        private Func<PartitionContext, IEnumerable<EventData>, Task> _processEventsAsync;

        /// <summary>Responsible for processing unexpected exceptions thrown while this <see cref="EventProcessorClient" /> is running.</summary>
        private Func<PartitionContext, Exception, Task> _processExceptionAsync;

        /// <summary>
        ///   The handler to be called just before event processing starts for a given partition.
        /// </summary>
        ///
        public Func<PartitionContext, Task> InitializeProcessingForPartitionAsync
        {
            internal get => _initializeProcessingForPartitionAsync;
            set => EnsureNotRunningAndInvoke(() => _initializeProcessingForPartitionAsync = value);
        }

        /// <summary>
        ///   The handler to be called once event processing stops for a given partition.
        /// </summary>
        ///
        public Func<PartitionContext, PartitionProcessorCloseReason, Task> ProcessingForPartitionStoppedAsync
        {
            internal get => _processingForPartitionStoppedAsync;
            set => EnsureNotRunningAndInvoke(() => _processingForPartitionStoppedAsync = value);
        }

        /// <summary>
        ///   Responsible for processing sets of events received from the Event Hubs service.  Implementation is mandatory.
        /// </summary>
        ///
        public Func<PartitionContext, IEnumerable<EventData>, Task> ProcessEventsAsync
        {
            internal get => _processEventsAsync;
            set => EnsureNotRunningAndInvoke(() => _processEventsAsync = value);
        }

        /// <summary>
        ///   Responsible for processing unexpected exceptions thrown while this <see cref="EventProcessorClient" /> is running.
        ///   Implementation is mandatory.
        /// </summary>
        ///
        public Func<PartitionContext, Exception, Task> ProcessExceptionAsync
        {
            internal get => _processExceptionAsync;
            set => EnsureNotRunningAndInvoke(() => _processExceptionAsync = value);
        }

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the processor is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Event Hub that the processor is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName => Connection.EventHubName;

        /// <summary>
        ///   A unique name used to identify this event processor.
        /// </summary>
        ///
        public virtual string Identifier { get; }

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
        ///   The active connection to the Azure Event Hubs service, enabling client communications for metadata
        ///   about the associated Event Hub and access to transport-aware consumers.
        /// </summary>
        ///
        private EventHubConnection Connection { get; }

        /// <summary>
        ///   The name of the consumer group this event processor is associated with.  Events will be
        ///   read only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

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
        private EventHubRetryPolicy RetryPolicy { get; }

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
        ///   The set of partition ownership this event processor owns.  Partition ids are used as keys.
        /// </summary>
        ///
        private Dictionary<string, PartitionOwnership> InstanceOwnership { get; set; }

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

            OwnsConnection = true;
            Connection = new EventHubConnection(connectionString, eventHubName, processorOptions.ConnectionOptions);
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
            Connection = new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential, processorOptions.ConnectionOptions);
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
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="processorOptions">The set of options to use for this processor.</param>
        ///
        /// <remarks>
        ///   This constructor is intended only to support internal functional testing; it should not be used for production scenarios nor
        ///   external mocking.
        /// </remarks>
        ///
        internal EventProcessorClient(string consumerGroup,
                                      PartitionManager partitionManager,
                                      EventHubConnection connection,
                                      EventProcessorClientOptions processorOptions)
        {
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNull(partitionManager, nameof(partitionManager));
            Argument.AssertNotNull(connection, nameof(connection));

            processorOptions = processorOptions?.Clone() ?? new EventProcessorClientOptions();

            OwnsConnection = false;
            Connection = connection;
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
        ///   Starts the event processor.  In case it's already running, nothing happens.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="ProcessEventsAsync" /> or <see cref="ProcessExceptionAsync" /> set.</exception>
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
                            if (_processEventsAsync == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessEventsAsync)));
                            }

                            if (_processExceptionAsync == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartEventProcessorWithoutHandler, nameof(ProcessExceptionAsync)));
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
                            .Select(partitionId => RemovePartitionPumpIfItExistsAsync(partitionId, PartitionProcessorCloseReason.Shutdown)))
                            .ConfigureAwait(false);
                    }
                }
                finally
                {
                    ActiveLoadBalancingTask = null;
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

            try
            {
                await StopAsync().ConfigureAwait(false);;
            }
            finally
            {
                if (OwnsConnection)
                {
                    await Connection.CloseAsync().ConfigureAwait(false);
                }
            }
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
            while (!cancellationToken.IsCancellationRequested)
            {
                Stopwatch cycleDuration = Stopwatch.StartNew();

                // Renew this instance's ownership so they don't expire.

                await RenewOwnershipAsync().ConfigureAwait(false);

                // From the storage service provided by the user, obtain a complete list of ownership, including expired ones.  We may still need
                // their eTags to claim orphan partitions.

                var completeOwnershipList = (await Manager
                    .ListOwnershipAsync(Connection.FullyQualifiedNamespace, Connection.EventHubName, ConsumerGroup)
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
                    .Select(partitionId => RemovePartitionPumpIfItExistsAsync(partitionId, PartitionProcessorCloseReason.OwnershipLost)))
                    .ConfigureAwait(false);

                // Now that we are left with pumps that should be running, check their status.  If any has stopped, it means an
                // unexpected failure has happened, so try closing it and starting a new one.  In case we don't have a pump that
                // should exist, create it.  This might happen when pump creation has failed in a previous cycle.

                await Task.WhenAll(InstanceOwnership
                    .Where(kvp =>
                        {
                            if (PartitionPumps.TryGetValue(kvp.Key, out PartitionPump pump))
                            {
                                return !pump.IsRunning;
                            }

                            return true;
                        })
                    .Select(kvp => AddOrOverwritePartitionPumpAsync(kvp.Key, kvp.Value.SequenceNumber)))
                    .ConfigureAwait(false);

                // Find an ownership to claim and try to claim it.  The method will return null if this instance was not eligible to
                // increase its ownership list, if no claimable ownership could be found or if a claim attempt failed.

                PartitionOwnership claimedOwnership = await FindAndClaimOwnershipAsync(completeOwnershipList, activeOwnership).ConfigureAwait(false);

                if (claimedOwnership != null)
                {
                    InstanceOwnership[claimedOwnership.PartitionId] = claimedOwnership;

                    await AddOrOverwritePartitionPumpAsync(claimedOwnership.PartitionId, claimedOwnership.SequenceNumber).ConfigureAwait(false);
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
        ///   Finds and tries to claim an ownership if this <see cref="EventProcessorClient" /> instance is eligible to increase its ownership
        ///   list.
        /// </summary>
        ///
        /// <param name="completeOwnershipEnumerable">A complete enumerable of ownership obtained from the stored service provided by the user.</param>
        /// <param name="activeOwnership">The set of ownership that are still active.</param>
        ///
        /// <returns>The claimed ownership. <c>null</c> if this instance is not eligible, if no claimable ownership was found or if the claim attempt failed.</returns>
        ///
        private async Task<PartitionOwnership> FindAndClaimOwnershipAsync(IEnumerable<PartitionOwnership> completeOwnershipEnumerable,
                                                                          IEnumerable<PartitionOwnership> activeOwnership)
        {
            // Get a complete list of the partition ids present in the Event Hub.  This should be immutable for the time being, but
            // it may change in the future.

            var partitionIds = await Connection.GetPartitionIdsAsync(RetryPolicy).ConfigureAwait(false);

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

            if (ownedPartitionsCount < minimumOwnedPartitionsCount ||
                ownedPartitionsCount == minimumOwnedPartitionsCount && !partitionDistribution.Values.Any(partitions => partitions < minimumOwnedPartitionsCount))
            {
                // Look for unclaimed partitions.  If any, randomly pick one of them to claim.

                IEnumerable<string> unclaimedPartitions = partitionIds
                    .Except(activeOwnership.Select(ownership => ownership.PartitionId));

                if (unclaimedPartitions.Any())
                {
                    var index = RandomNumberGenerator.Value.Next(unclaimedPartitions.Count());

                    return await ClaimOwnershipAsync(unclaimedPartitions.ElementAt(index), completeOwnershipEnumerable).ConfigureAwait(false);
                }

                // Only try to steal partitions if there are no unclaimed partitions left.  At first, only processors that have exceeded the
                // maximum owned partition count should be targeted.

                var maximumOwnedPartitionsCount = minimumOwnedPartitionsCount + 1;

                IEnumerable<string> stealablePartitions = activeOwnership
                    .Where(ownership => partitionDistribution[ownership.OwnerIdentifier] > maximumOwnedPartitionsCount)
                    .Select(ownership => ownership.PartitionId);

                // Here's the important part.  If there are no processors that have exceeded the maximum owned partition count allowed, we may
                // need to steal from the processors that have exactly the maximum amount.  If this instance is below the minimum count, then
                // we have no choice as we need to enforce balancing.  Otherwise, leave it as it is because the distribution wouldn't change.

                if (!stealablePartitions.Any() && ownedPartitionsCount < minimumOwnedPartitionsCount)
                {
                    stealablePartitions = activeOwnership
                        .Where(ownership => partitionDistribution[ownership.OwnerIdentifier] == maximumOwnedPartitionsCount)
                        .Select(ownership => ownership.PartitionId);
                }

                // If any stealable partitions were found, randomly pick one of them to claim.

                if (stealablePartitions.Any())
                {
                    var index = RandomNumberGenerator.Value.Next(stealablePartitions.Count());

                    return await ClaimOwnershipAsync(stealablePartitions.ElementAt(index), completeOwnershipEnumerable).ConfigureAwait(false);
                }
            }

            // No ownership was claimed.

            return null;
        }

        /// <summary>
        ///   Creates and starts a new partition pump associated with the specified partition.  Partition pumps that are overwritten by the creation
        ///   of a new one are properly stopped.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the partition pump will be associated with.  Events will be read only from this partition.</param>
        /// <param name="initialSequenceNumber">The sequence number of the event within a partition where the partition pump should begin reading events.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task AddOrOverwritePartitionPumpAsync(string partitionId,
                                                            long? initialSequenceNumber)
        {
            // Remove and stop the existing partition pump if it exists.  We are not specifying any close reason because partition
            // pumps only are overwritten in case of failure.  In these cases, the close reason is delegated to the pump as it may
            // have more information about what caused the failure.

            await RemovePartitionPumpIfItExistsAsync(partitionId).ConfigureAwait(false);

            // Create and start the new partition pump and add it to the dictionary.

            var partitionContext = new PartitionContext(Connection.FullyQualifiedNamespace, Connection.EventHubName, ConsumerGroup, partitionId, Identifier, Manager);
            var defaultEventPosition = EventPosition.Earliest;

            try
            {
                EventProcessorClientOptions options = Options.Clone();

                // Overwrite the initial event position in case a checkpoint exists.

                if (initialSequenceNumber.HasValue)
                {
                   defaultEventPosition = EventPosition.FromSequenceNumber(initialSequenceNumber.Value);
                }

                var partitionPump = new PartitionPump(this, Connection, ConsumerGroup, partitionContext, defaultEventPosition, options);

                await partitionPump.StartAsync().ConfigureAwait(false);

                PartitionPumps[partitionId] = partitionPump;
            }
            catch (Exception)
            {
                // If partition pump creation fails, we'll try again on the next time this method is called.  This should happen
                // on the next load balancing loop as long as this instance still owns the partition.
                // TODO: delegate the exception handling to an Exception Callback.
            }
        }

        /// <summary>
        ///   Stops an owned partition pump instance in case it exists.  It is also removed from the pumps dictionary.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition the partition pump is associated with.</param>
        /// <param name="reason">The reason why the partition processor is being closed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task RemovePartitionPumpIfItExistsAsync(string partitionId,
                                                              PartitionProcessorCloseReason? reason = null)
        {
            if (PartitionPumps.TryRemove(partitionId, out PartitionPump pump))
            {
                try
                {
                    await pump.StopAsync(reason).ConfigureAwait(false);
                }
                catch (Exception)
                {
                    // TODO: delegate the exception handling to an Exception Callback.
                }
            }
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

            PartitionOwnership oldOwnership = completeOwnershipEnumerable.FirstOrDefault(ownership => ownership.PartitionId == partitionId);

            var newOwnership = new PartitionOwnership
                (
                    Connection.FullyQualifiedNamespace,
                    Connection.EventHubName,
                    ConsumerGroup,
                    Identifier,
                    partitionId,
                    oldOwnership?.Offset,
                    oldOwnership?.SequenceNumber,
                    DateTimeOffset.UtcNow,
                    oldOwnership?.ETag
                );

            // We are expecting an enumerable with a single element if the claim attempt succeeds.

            IEnumerable<PartitionOwnership> claimedOwnership = (await Manager
                .ClaimOwnershipAsync(new List<PartitionOwnership> { newOwnership })
                .ConfigureAwait(false));

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

            return Manager.ClaimOwnershipAsync(ownershipToRenew);
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
