﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Provides a base for creating a custom processor for consuming events across all partitions of a given Event Hub
    ///   within the scope of a specific consumer group.  The processor is capable of collaborating with other instances for
    ///   the same Event Hub and consumer group pairing to share work by using a common storage platform to communicate.  Fault
    ///   tolerance is also built-in, allowing the processor to be resilient in the face of errors.
    /// </summary>
    ///
    /// <typeparam name="TPartition">The context of the partition for which an operation is being performed.</typeparam>
    ///
    public abstract class EventProcessor<TPartition> where TPartition : EventProcessorPartition, new()
    {
        /// <summary>The maximum number of failed consumers to allow when processing a partition; failed consumers are those which have been unable to receive and process events.</summary>
        private const int MaximumFailedConsumerCount = 1;

        /// <summary>The primitive for synchronizing access when starting and stopping the processor.</summary>
        private readonly SemaphoreSlim ProcessorRunningSync = new SemaphoreSlim(1, 1);

        /// <summary>Indicates whether or not this event processor is currently running.  Used only for mocking purposes.</summary>
        private bool? _isRunningOverride;

        /// <summary>Indicates the current state of the processor; used for mocking and manual status updates.</summary>
        private EventProcessorStatus? _statusOverride;

        /// <summary>The task responsible for managing the operations of the processor when it is running.</summary>
        private Task _runningProcessorTask;

        /// <summary>A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the current running task.</summary>
        private CancellationTokenSource _runningProcessorCancellationSource;

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
        ///   Indicates whether or not this event processor is currently running.
        /// </summary>
        ///
        public bool IsRunning
        {
            get
            {
                var running = _isRunningOverride;

                if (running.HasValue)
                {
                    return running.Value;
                }

                var status = Status;
                return ((status == EventProcessorStatus.Running) || (status == EventProcessorStatus.Stopping));
            }

            protected set => _isRunningOverride = value;
        }

        /// <summary>
        ///   Indicates the current state of the processor.
        /// </summary>
        ///
        internal EventProcessorStatus Status
        {
            get
            {
                EventProcessorStatus? statusOverride;

                // If there is no active processor task, ensure that it is not
                // in the process of starting by attempting to acquire the semaphore.
                //
                // If the semaphore could not be acquired, then there is an active start/stop
                // operation in progress indicating that the processor is not yet running or
                // will not be running.

                if (_runningProcessorTask == null)
                {
                    try
                    {
                        if (!ProcessorRunningSync.Wait(100))
                        {
                            return (_statusOverride ?? EventProcessorStatus.NotRunning);
                        }

                        statusOverride = _statusOverride;
                    }
                    finally
                    {
                        ProcessorRunningSync.Release();
                    }
                }
                else
                {
                    statusOverride = _statusOverride;
                }

                if (statusOverride.HasValue)
                {
                    return statusOverride.Value;
                }

                if ((_runningProcessorTask?.IsFaulted) ?? (false))
                {
                    return EventProcessorStatus.Faulted;
                }

                if ((!_runningProcessorTask?.IsCompleted) ?? (false))
                {
                    return EventProcessorStatus.Running;
                }

                return EventProcessorStatus.NotRunning;
            }
        }

        /// <summary>
        ///   The instance of <see cref="EventHubsEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal EventHubsEventSource Logger { get; set; } = EventHubsEventSource.Log;

        /// <summary>
        ///   The set of currently active partition processing tasks issued by this event processor and their associated
        ///   token sources that can be used to cancel the operation.  Partition identifiers are used as keys.
        /// </summary>
        ///
        private ConcurrentDictionary<string, PartitionProcessor> ActivePartitionProcessors { get; } = new ConcurrentDictionary<string, PartitionProcessor>();

        /// <summary>
        ///   A factory used to create new <see cref="EventHubConnection" /> instances.
        /// </summary>
        ///
        private Func<EventHubConnection> ConnectionFactory { get; }

        /// <summary>
        ///   Responsible for ownership claim for load balancing.
        /// </summary>
        ///
        private PartitionLoadBalancer LoadBalancer { get; }

        /// <summary>
        ///   The set of options to use with the <see cref="EventProcessor{TPartition}" />  instance.
        /// </summary>
        ///
        private EventProcessorOptions Options { get; }

        /// <summary>
        ///   The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch.
        /// </summary>
        ///
        private int EventBatchMaximumCount { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group the processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        /// <param name="loadBalancer">The load balancer to use for coordinating processing with other event processor instances.  If <c>null</c>, the standard load balancer will be created.</param>
        ///
        internal EventProcessor(int eventBatchMaximumCount,
                                string consumerGroup,
                                string fullyQualifiedNamespace,
                                string eventHubName,
                                TokenCredential credential,
                                EventProcessorOptions options = default,
                                PartitionLoadBalancer loadBalancer = default)
        {
            Argument.AssertInRange(eventBatchMaximumCount, 1, int.MaxValue, nameof(eventBatchMaximumCount));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertWellFormedEventHubsNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            options = options?.Clone() ?? new EventProcessorOptions();

            ConnectionFactory = () => new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential, options.ConnectionOptions);
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            Identifier = string.IsNullOrEmpty(options.Identifier) ? Guid.NewGuid().ToString() : options.Identifier;
            Options = options;
            EventBatchMaximumCount = eventBatchMaximumCount;
            LoadBalancer = loadBalancer ?? CreatePartitionLoadBalancer(CreateStorageManager(this), Identifier, ConsumerGroup, FullyQualifiedNamespace, EventHubName, options.PartitionOwnershipExpirationInterval);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group the processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="options">The set of options to use for the processor.</param>
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
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string"/>
        ///
        protected EventProcessor(int eventBatchMaximumCount,
                                 string consumerGroup,
                                 string connectionString,
                                 EventProcessorOptions options = default) : this(eventBatchMaximumCount, consumerGroup, connectionString, null, options)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group the processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string"/>
        ///
        protected EventProcessor(int eventBatchMaximumCount,
                                 string consumerGroup,
                                 string connectionString,
                                 string eventHubName,
                                 EventProcessorOptions options = default)
        {
            Argument.AssertInRange(eventBatchMaximumCount, 1, int.MaxValue, nameof(eventBatchMaximumCount));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            options = options?.Clone() ?? new EventProcessorOptions();

            var connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            ConnectionFactory = () => new EventHubConnection(connectionString, eventHubName, options.ConnectionOptions);
            FullyQualifiedNamespace = connectionStringProperties.Endpoint.Host;
            EventHubName = string.IsNullOrEmpty(eventHubName) ? connectionStringProperties.EventHubName : eventHubName;
            ConsumerGroup = consumerGroup;
            Identifier = string.IsNullOrEmpty(options.Identifier) ? Guid.NewGuid().ToString() : options.Identifier;
            Options = options;
            EventBatchMaximumCount = eventBatchMaximumCount;
            LoadBalancer = CreatePartitionLoadBalancer(CreateStorageManager(this), Identifier, ConsumerGroup, FullyQualifiedNamespace, EventHubName, options.PartitionOwnershipExpirationInterval);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group the processor is associated with.  Events are read in the context of this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        protected EventProcessor(int eventBatchMaximumCount,
                                 string consumerGroup,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 TokenCredential credential,
                                 EventProcessorOptions options = default) : this(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options, default)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        protected EventProcessor()
        {
        }

        /// <summary>
        ///   Signals the <see cref="EventProcessor{TPartition}" /> to begin processing events.  Should this method be called while the processor
        ///   is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="EventProcessor{TPartition}" /> once it starts running.</param>
        ///
        public virtual async Task StartProcessingAsync(CancellationToken cancellationToken = default) =>
            await StartProcessingInternalAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Signals the <see cref="EventProcessor{TPartition}" /> to begin processing events.  Should this method be called while the processor
        ///   is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="EventProcessor{TPartition}" /> once it starts running.</param>
        ///
        public virtual void StartProcessing(CancellationToken cancellationToken = default) =>
            StartProcessingInternalAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        ///   Signals the <see cref="EventProcessor{TPartition}" /> to stop processing events.  Should this method be called while the processor
        ///   is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="EventProcessor{TPartition}" /> will keep running.</param>
        ///
        public virtual async Task StopProcessingAsync(CancellationToken cancellationToken = default) =>
            await StopProcessingInternalAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Signals the <see cref="EventProcessor{TPartition}" /> to stop processing events.  Should this method be called while the processor
        ///   is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="EventProcessor{TPartition}" /> will keep running.</param>
        ///
        public virtual void StopProcessing(CancellationToken cancellationToken = default) =>
            StopProcessingInternalAsync(false, cancellationToken).EnsureCompleted();

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
        public override string ToString() => $"Event Processor<{ typeof(TPartition).Name }>: { Identifier }";

        /// <summary>
        ///   Creates an <see cref="EventHubConnection" /> to use for communicating with the Event Hubs service.
        /// </summary>
        ///
        /// <returns>The requested <see cref="EventHubConnection" />.</returns>
        ///
        internal virtual EventHubConnection CreateConnection() => ConnectionFactory();

        /// <summary>
        ///   Creates an <see cref="TransportConsumer" /> to use for processing.
        /// </summary>
        ///
        /// <param name="consumerGroup">The consumer group to associate with the consumer.</param>
        /// <param name="partitionId">The partition to associated with the consumer.</param>
        /// <param name="eventPosition">The position in the event stream where the consumer should begin reading.</param>
        /// <param name="connection">The connection to use for the consumer.</param>
        /// <param name="options">The options to use for configuring the consumer.</param>
        ///
        /// <returns>An <see cref="TransportConsumer" /> with the requested configuration.</returns>
        ///
        internal virtual TransportConsumer CreateConsumer(string consumerGroup,
                                                          string partitionId,
                                                          EventPosition eventPosition,
                                                          EventHubConnection connection,
                                                          EventProcessorOptions options) =>
            connection.CreateTransportConsumer(consumerGroup, partitionId, eventPosition, options.RetryOptions.ToRetryPolicy(), options.TrackLastEnqueuedEventProperties, prefetchCount: (uint?)options.PrefetchCount);

        /// <summary>
        ///   Creates a <see cref="StorageManager" /> to use for interacting with durable storage.
        /// </summary>
        ///
        /// <param name="instance">The <see cref="EventProcessor{TPartition}" /> instance to associate with the storage manager.</param>
        ///
        /// <returns>A <see cref="StorageManager" /> with the requested configuration.</returns>
        ///
        internal virtual StorageManager CreateStorageManager(EventProcessor<TPartition> instance) => new DelegatingStorageManager(instance);

        /// <summary>
        ///   Creates a <see cref="PartitionLoadBalancer"/> for managing partition ownership for the event processor.
        /// </summary>
        ///
        /// <param name="storageManager">Responsible for managing persistence of the partition ownership data.</param>
        /// <param name="identifier">The identifier of the event processor associated with the load balancer.</param>
        /// <param name="consumerGroup">The name of the consumer group this load balancer is associated with.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace that the processor is associated with.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="ownershipExpiration">The minimum amount of time for an ownership to be considered expired without further updates.</param>
        ///
        internal virtual PartitionLoadBalancer CreatePartitionLoadBalancer(StorageManager storageManager,
                                                                           string identifier,
                                                                           string consumerGroup,
                                                                           string fullyQualifiedNamespace,
                                                                           string eventHubName,
                                                                           TimeSpan ownershipExpiration) =>
            new PartitionLoadBalancer(storageManager, identifier, consumerGroup, fullyQualifiedNamespace, eventHubName, ownershipExpiration);

        /// <summary>
        ///   Creates the infrastructure for tracking the processing of a partition and begins processing the
        ///   partition in the background until cancellation is requested.
        /// </summary>
        ///
        /// <param name="partition">The Event Hub partition whose processing should be started.</param>
        /// <param name="startingPosition">The position within the event stream that processing should begin.</param>
        /// <param name="cancellationSource">A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The <see cref="PartitionProcessor" /> encapsulating the processing task, its cancellation token, and associated state.</returns>
        ///
        /// <remarks>
        ///   This method makes liberal use of class methods and state in addition to the received parameters.
        /// </remarks>
        ///
        internal virtual PartitionProcessor CreatePartitionProcessor(TPartition partition,
                                                                     EventPosition startingPosition,
                                                                     CancellationTokenSource cancellationSource)
        {
            cancellationSource.Token.ThrowIfCancellationRequested<TaskCanceledException>();
            var consumer = default(TransportConsumer);

            // If the tracking of the last enqueued event properties was requested, then read the
            // properties from the active consumer, which can change during processing in the event of
            // error scenarios.

            LastEnqueuedEventProperties readLastEnquedEventInformation()
            {
                if (!Options.TrackLastEnqueuedEventProperties)
                {
                    throw new InvalidOperationException(Resources.TrackLastEnqueuedEventPropertiesNotSet);
                }

                // This is not an expected scenario; the guard exists to prevent a race condition that is
                // unlikely, but possible, when partition processing is being stopped or consumer creation
                // outright failed.

                if ((consumer == null) || (consumer.IsClosed))
                {
                    throw new InvalidOperationException(Resources.ClientNeededForThisInformationNotAvailable);
                }

                return new LastEnqueuedEventProperties(consumer.LastReceivedEvent);
            }

            // Define the routine to handle processing for the partition.

            async Task performProcessing()
            {
                cancellationSource.Token.ThrowIfCancellationRequested<TaskCanceledException>();

                var connection = CreateConnection();
                await using var connectionAwaiter = connection.ConfigureAwait(false);

                var retryPolicy = Options.RetryOptions.ToRetryPolicy();
                var retryDelay = default(TimeSpan?);
                var capturedException = default(Exception);
                var eventBatch = default(IReadOnlyList<EventData>);
                var lastEvent = default(EventData);
                var failedAttemptCount = 0;
                var failedConsumerCount = 0;

                // Continue processing the partition until cancellation is signaled or until the count of failed consumers is too great.
                // Consumers which been consistently unable to receive and process events will be considered invalid and abandoned for a new consumer.

                while ((!cancellationSource.IsCancellationRequested) && (failedConsumerCount <= MaximumFailedConsumerCount))
                {
                    try
                    {
                        consumer = CreateConsumer(ConsumerGroup, partition.PartitionId, startingPosition, connection, Options);

                        // Allow the core dispatching loop to apply an additional set of retries over any provided by the consumer
                        // itself, as a processor should be as resilient as possible and retain partition ownership if processing is
                        // able to make forward progress.  If the retries are exhausted or a non-retriable exception occurs, the
                        // consumer will be considered invalid and potentially refreshed.

                        while (!cancellationSource.IsCancellationRequested)
                        {
                            try
                            {
                                eventBatch = await consumer.ReceiveAsync(EventBatchMaximumCount, Options.MaximumWaitTime, cancellationSource.Token).ConfigureAwait(false);
                                await ProcessEventBatchAsync(partition, eventBatch, Options.MaximumWaitTime.HasValue, cancellationSource.Token).ConfigureAwait(false);

                                // If the batch was successfully processed, capture the last event as the current starting position, in the
                                // event that the consumer becomes invalid and needs to be replaced.

                                lastEvent = eventBatch?.LastOrDefault();

                                if ((lastEvent != null) && (lastEvent.Offset != long.MinValue))
                                {
                                    startingPosition = EventPosition.FromOffset(lastEvent.Offset, false);
                                }

                                // If event batches are successfully processed, then the need for forward progress is
                                // satisfied, and the failure counts should reset.

                                failedAttemptCount = 0;
                                failedConsumerCount = 0;
                            }
                            catch (TaskCanceledException) when (cancellationSource.IsCancellationRequested)
                            {
                                // Do not log; this is an expected scenario when partition processing is asked to stop.

                                throw;
                            }
                            catch (Exception ex) when (ex.IsNotType<DeveloperCodeException>())
                            {
                                // The error handler is invoked as a fire-and-forget task; the processor does not assume responsibility
                                // for observing or surfacing exceptions that may occur in the handler.

                                _ = InvokeOnProcessingErrorAsync(ex, partition, Resources.OperationReadEvents, CancellationToken.None);

                                Logger.EventProcessorPartitionProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);
                                retryDelay = retryPolicy.CalculateRetryDelay(ex, ++failedAttemptCount);

                                if (!retryDelay.HasValue)
                                {
                                    // If the exception should not be retried, then allow it to pass to the outer loop; this is intended
                                    // to prevent being stuck in a corrupt state where the consumer is unable to read events.

                                    throw;
                                }

                                await Task.Delay(retryDelay.Value, cancellationSource.Token).ConfigureAwait(false);
                            }
                        }
                    }
                    catch (OperationCanceledException ex)
                    {
                        throw new TaskCanceledException(ex.Message, ex);
                    }
                    catch (DeveloperCodeException ex)
                    {
                        // Record that an exception was observed in developer-provided code, but consider it fatal and take no further
                        // steps to handle or dispatch it.

                        var message = string.Format(CultureInfo.InvariantCulture, Resources.DeveloperCodeExceptionMessageMask, ex.InnerException.Message);
                        Logger.EventProcessorPartitionProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, message);

                        ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                    }
                    catch (Exception ex) when (ex.IsFatalException())
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        ++failedConsumerCount;
                        capturedException = ex;
                    }
                    finally
                    {
                        try
                        {
                            if (consumer != null)
                            {
                                await consumer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.EventProcessorPartitionProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);

                            // Do not bubble the exception, as the consumer is being refreshed; failure to close this consumer is non-fatal.
                        }
                    }
                }

                // If there was an exception captured, then surface it.  Otherwise signal that cancellation took place.

                if (capturedException != null)
                {
                    ExceptionDispatchInfo.Capture(capturedException).Throw();
                }

                throw new TaskCanceledException();
            }

            // Start processing in the background and return the processor
            // metadata.

            return new PartitionProcessor
            (
                Task.Run(performProcessing, cancellationSource.Token),
                partition,
                readLastEnquedEventInformation,
                cancellationSource
            );
        }

        /// <summary>
        ///   Performs the tasks needed to process a batch of events.
        /// </summary>
        ///
        /// <param name="partition">The Event Hub partition whose processing should be started.</param>
        /// <param name="eventBatch">The batch of events to process.</param>
        /// <param name="dispatchEmptyBatches"><c>true</c> if empty batches should be dispatched to the handler; otherwise, <c>false</c>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.</param>
        ///
        internal virtual async Task ProcessEventBatchAsync(TPartition partition,
                                                           IReadOnlyList<EventData> eventBatch,
                                                           bool dispatchEmptyBatches,
                                                           CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            // If there were no events in the batch and empty batches should not be emitted,
            // take no further action.

            if (((eventBatch == null) || (eventBatch.Count <= 0)) && (!dispatchEmptyBatches))
            {
                return;
            }

            // Create the diagnostics scope used for distributed tracing and instrument the events in the batch.

            using var diagnosticScope = EventDataInstrumentation.ScopeFactory.CreateScope(DiagnosticProperty.EventProcessorProcessingActivityName);
            diagnosticScope.AddAttribute(DiagnosticProperty.KindAttribute, DiagnosticProperty.ConsumerKind);
            diagnosticScope.AddAttribute(DiagnosticProperty.EventHubAttribute, EventHubName);
            diagnosticScope.AddAttribute(DiagnosticProperty.EndpointAttribute, FullyQualifiedNamespace);

            if ((diagnosticScope.IsEnabled) && (eventBatch.Any()))
            {
                foreach (var eventData in eventBatch)
                {
                    if (EventDataInstrumentation.TryExtractDiagnosticId(eventData, out string diagnosticId))
                    {
                        var attributes = new Dictionary<string, string>(1)
                        {
                            { DiagnosticProperty.EnqueuedTimeAttribute, eventData.EnqueuedTime.ToUnixTimeMilliseconds().ToString() }
                        };

                        diagnosticScope.AddLink(diagnosticId, attributes);
                    }
                }
            }

            diagnosticScope.Start();

            // Dispatch the batch to the handler for processing.  Exceptions in the handler code are intended to be
            // unhandled by the processor; explicitly signal that the exception was observed in developer-provided
            // code.

            try
            {
                await OnProcessingEventBatchAsync(eventBatch, partition, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                diagnosticScope.Failed(ex);
                throw new DeveloperCodeException(ex);
            }
        }

        /// <summary>
        ///   Produces a list of the available checkpoints for the Event Hub and consumer group associated with the
        ///   event processor instance, so that processing for a given set of partitions can be properly initialized.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of checkpoints for the processor to take into account when initializing partitions.</returns>
        ///
        /// <remarks>
        ///   Should a partition not have a corresponding checkpoint, the <see cref="EventProcessorOptions.DefaultStartingPosition" /> will
        ///   be used to initialize the partition for processing.
        ///
        ///   In the event that a custom starting point is desired for a single partition, or each partition should start at a unique place,
        ///   it is recommended that this method express that intent by returning checkpoints for those partitions with the desired custom
        ///   starting location set.
        /// </remarks>
        ///
        protected abstract Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken);

        /// <summary>
        ///   Produces a list of the ownership assignments for partitions between each of the cooperating event processor
        ///   instances for a given Event Hub and consumer group pairing.  This method is used when load balancing to allow
        ///   the processor to discover other active collaborators and to made decisions about how to best balance work
        ///   between them.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership records to take into account when making load balancing decisions.</returns>
        ///
        protected abstract Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken);

        /// <summary>
        ///   Attempts to claim ownership of the specified partitions for processing.  This method is used by
        ///   load balancing to allow event processor instances to distribute the responsibility for processing
        ///   partitions for a given Event Hub and consumer group pairing amongst the active event processors.
        /// </summary>
        ///
        /// <param name="desiredOwnership">The set of partition ownership desired by the event processor instance; this is the set of partitions that it will attempt to request responsibility for processing.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership records for the partitions that were successfully claimed; this is expected to be the <paramref name="desiredOwnership"/> or a subset of those partitions.</returns>
        ///
        protected abstract Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
                                                                                                   CancellationToken cancellationToken);

        /// <summary>
        ///   Performs the tasks needed to process a batch of events for a given partition as they are read from the Event Hubs service.
        /// </summary>
        ///
        /// <param name="events">The batch of events to be processed.</param>
        /// <param name="partition">The context of the partition from which the events were read.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <remarks>
        ///   <para>The number of events in the <paramref name="events"/> batch may vary.  The batch will contain a number of events between zero and batch size that was
        ///   requested when the processor was created, depending on the availability of events in the partition within the requested <see cref="EventProcessorOptions.MaximumWaitTime"/>
        ///   interval.
        ///
        ///   If there are enough events available in the Event Hub partition to fill a batch of the requested size, the processor will populate the batch and dispatch it to this method
        ///   immediately.  If there were not a sufficient number of events available in the partition to populate a full batch, the event processor will continue reading from the partition
        ///   to reach the requested batch size until the <see cref="EventProcessorOptions.MaximumWaitTime"/> has elapsed, at which point it will return a batch containing whatever events were
        ///   available by the end of that period.
        ///
        ///   If a <see cref="EventProcessorOptions.MaximumWaitTime"/> was not requested, indicated by setting the option to <c>null</c>, the event processor will continue reading from the Event Hub
        ///   partition until a full batch of the requested size could be populated and will not dispatch any partial batches to this method.</para>
        ///
        ///   <para>Should an exception occur within the code for this method, the event processor will allow it to bubble and will not surface to the error handler or attempt to handle
        ///   it in any way.  Developers are strongly encouraged to take exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.</para>
        /// </remarks>
        ///
        protected abstract Task OnProcessingEventBatchAsync(IEnumerable<EventData> events,
                                                            TPartition partition,
                                                            CancellationToken cancellationToken);

        /// <summary>
        ///   Performs the tasks needed when an unexpected exception occurs within the operation of the
        ///   event processor infrastructure.
        /// </summary>
        ///
        /// <param name="exception">The exception that occurred during operation of the event processor.</param>
        /// <param name="partition">The context of the partition associated with the error, if any; otherwise, <c>null</c>.  This may only be initialized for members of <see cref="EventProcessorPartition" />, depending on the point at which the error occurred.</param>
        /// <param name="operationDescription">A short textual description of the operation during which the exception occurred; intended to be informational only.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <remarks>
        ///   This error handler is invoked when there is an exception observed within the event processor itself; it is not invoked for exceptions in
        ///   code that has been implemented to process events or other overrides and extension points that are not critical to the processor's operation.
        ///   The event processor will make every effort to recover from exceptions and continue processing.  Should an exception that cannot be recovered
        ///   from be encountered, the processor will attempt to forfeit ownership of all partitions that it was processing so that work may be redistributed.
        ///
        ///   The exceptions surfaced to this method may be fatal or non-fatal; because the processor may not be able to accurately predict whether an
        ///   exception was fatal or whether its state was corrupted, this method has responsibility for making the determination as to whether processing
        ///   should be terminated or restarted.  The method may do so by calling Stop on the processor instance and then, if desired, calling Start on the processor.
        ///
        ///   It is recommended that, for production scenarios, the decision be made by considering observations made by this error handler, the method invoked
        ///   when initializing processing for a partition, and the method invoked when processing for a partition is stopped.  Many developers will also include
        ///   data from their monitoring platforms in this decision as well.
        ///
        ///   As with event processing, should an exception occur in the code for the error handler, the event processor will allow it to bubble and will not attempt to handle
        ///   it in any way.  Developers are strongly encouraged to take exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.
        /// </remarks>
        ///
        protected abstract Task OnProcessingErrorAsync(Exception exception,
                                                       TPartition partition,
                                                       string operationDescription,
                                                       CancellationToken cancellationToken);

        /// <summary>
        ///   Performs the tasks to initialize a partition, and its associated context, for event processing.
        /// </summary>
        ///
        /// <param name="partition">The context of the partition being initialized.  Only the well-known members of the <see cref="EventProcessorPartition" /> will be populated.  If a custom context is being used, the implementor of this method is responsible for initializing custom members.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the initialization.  This is most likely to occur if the partition is claimed by another event processor instance or the processor is shutting down.</param>
        ///
        protected virtual Task OnInitializingPartitionAsync(TPartition partition,
                                                            CancellationToken cancellationToken) => Task.CompletedTask;

        /// <summary>
        ///   Performs the tasks needed when processing for a partition is being stopped.  This commonly occurs when the partition
        ///   is claimed by another event processor instance or when the current event processor instance is shutting down.
        /// </summary>
        ///
        /// <param name="partition">The context of the partition for which processing is being stopped.</param>
        /// <param name="reason">The reason that processing is being stopped for the partition.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is not expected to signal under normal circumstances and will only occur if the processor encounters an unrecoverable error.</param>
        ///
        protected virtual Task OnPartitionProcessingStoppedAsync(TPartition partition,
                                                                 ProcessingStoppedReason reason,
                                                                 CancellationToken cancellationToken) => Task.CompletedTask;

        /// <summary>
        ///   A set of information about the last enqueued event of a partition, as observed by the associated EventHubs client
        ///   associated with this context as events are received from the Event Hubs service.  This is only available if the consumer was
        ///   created with <see cref="ReadEventOptions.TrackLastEnqueuedEventProperties" /> set.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition to read the properties from.</param>
        ///
        /// <returns>The set of properties for the last event that was enqueued to the partition.</returns>
        ///
        /// <remarks>
        ///   When information about the partition's last enqueued event is being tracked, each event received from the Event Hubs
        ///   service will carry metadata about the partition that it otherwise would not. This results in a small amount of
        ///   additional network bandwidth consumption that is generally a favorable trade-off when considered
        ///   against periodically making requests for partition properties using an Event Hub client.
        /// </remarks>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="EventProcessorOptions.TrackLastEnqueuedEventProperties" /> set or when the processor is not running.</exception>
        ///
        protected virtual LastEnqueuedEventProperties ReadLastEnqueuedEventProperties(string partitionId) => throw new NotImplementedException();

        /// <summary>
        ///   Signals the <see cref="EventProcessor{TPartition}" /> to begin processing events. Should this method be called while the processor is running, no action is taken.
        /// </summary>
        ///
        /// <param name="async">When <c>true</c>, the method will be executed asynchronously; otherwise, it will execute synchronously.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="EventProcessor{TPartition}" /> once it starts running.</param>
        ///
        private async Task StartProcessingInternalAsync(bool async,
                                                        CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.EventProcessorStart(Identifier, EventHubName, ConsumerGroup);

            var releaseSync = false;

            try
            {
                // Acquire the semaphore used to synchronize processor starts and stops, respecting
                // the async flag.  When this is held, the state of the processor is stable.

                if (async)
                {
                    await ProcessorRunningSync.WaitAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    ProcessorRunningSync.Wait();
                }

                releaseSync = true;
                _statusOverride = EventProcessorStatus.Starting;
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // If the processor is already running, then it was started before the
                // semaphore was acquired; there is no work to be done.

                if (_runningProcessorTask != null)
                {
                    return;
                }

                // There should be no cancellation source, but guard against leaking resources in the
                // event of a processing crash or other exception.

                _runningProcessorCancellationSource?.Cancel();
                _runningProcessorCancellationSource?.Dispose();
                _runningProcessorCancellationSource = new CancellationTokenSource();

                // Start processing events.

                ActivePartitionProcessors.Clear();
                _runningProcessorTask = RunProcessingAsync(_runningProcessorCancellationSource.Token);
            }
            catch (Exception ex)
            {
                Logger.EventProcessorStartError(Identifier, EventHubName, ConsumerGroup, ex.Message);
                throw;
            }
            finally
            {
                _statusOverride = null;
                Logger.EventProcessorStartComplete(Identifier, EventHubName, ConsumerGroup);

                // If the cancellation token was signaled during the attempt to acquire the
                // semaphore, it cannot be safely released; ensure that it is held.

                if (releaseSync)
                {
                    ProcessorRunningSync.Release();
                }
            }
        }

        /// <summary>
        ///   Signals the <see cref="EventProcessor{TPartition}" /> to stop processing events. Should this method be called while the processor is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="async">When <c>true</c>, the method will be executed asynchronously; otherwise, it will execute synchronously.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="EventProcessor{TPartition}" /> will keep running.</param>
        ///
        private async Task StopProcessingInternalAsync(bool async,
                                                       CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.EventProcessorStop(Identifier, EventHubName, ConsumerGroup);

            var processingException = default(Exception);
            var releaseSync = false;

            try
            {
                // Acquire the semaphore used to synchronize processor starts and stops, respecting
                // the async flag.  When this is held, the state of the processor is stable.

                if (async)
                {
                    await ProcessorRunningSync.WaitAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    ProcessorRunningSync.Wait();
                }

                releaseSync = true;
                _statusOverride = EventProcessorStatus.Stopping;
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // If the processor is not running, then it was never started or has been stopped
                // before the semaphore was acquired; there is no work to be done.

                if (_runningProcessorTask == null)
                {
                    return;
                }

                // Request cancellation of the running processor task.

                _runningProcessorCancellationSource?.Cancel();
                _runningProcessorCancellationSource?.Dispose();
                _runningProcessorCancellationSource = null;

                // Allow processing to complete.  If there was a processing or load balancing error,
                // awaiting the task is where it will be surfaced.  Be sure to preserve it so
                // that it can be surfaced.

                try
                {
                    if (async)
                    {
                        await _runningProcessorTask.ConfigureAwait(false);
                    }
                    else
                    {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                        _runningProcessorTask.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                    }
                }
                catch (TaskCanceledException)
                {
                    // This is expected; no action is needed.
                }
                catch (Exception ex)
                {
                    // Preserve the exception to surface once the tasks needed to fully stop are complete;
                    // logging and invoking of the error handler will have already taken place.

                    processingException = ex;
                }

                // With the processing task having completed, perform the necessary cleanup of partition processing tasks
                // and surrender ownership.

                var stopPartitionProcessingTasks = ActivePartitionProcessors.Keys
                    .Select(partitionId => StopProcessingPartitionAsync(partitionId, ProcessingStoppedReason.Shutdown, CancellationToken.None))
                    .ToArray();

                if (async)
                {
                    await Task.WhenAll(stopPartitionProcessingTasks).ConfigureAwait(false);
                    await LoadBalancer.RelinquishOwnershipAsync(CancellationToken.None).ConfigureAwait(false);
                }
                else
                {
                    Task.WaitAll(stopPartitionProcessingTasks);

#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                    LoadBalancer.RelinquishOwnershipAsync(CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                }

                ActivePartitionProcessors.Clear();

                // Dispose of the processing task and reset processing state to
                // allow the processor to be restarted when this method completes.

                _runningProcessorTask.Dispose();
                _runningProcessorTask = null;
            }
            catch (Exception ex)
            {
                Logger.EventProcessorStopError(Identifier, EventHubName, ConsumerGroup, ex.Message);
                throw;
            }
            finally
            {
                _statusOverride = null;
                Logger.EventProcessorStopComplete(Identifier, EventHubName, ConsumerGroup);

                // If the cancellation token was signaled during the attempt to acquire the
                // semaphore, it cannot be safely released; ensure that it is held.

                if (releaseSync)
                {
                    ProcessorRunningSync.Release();
                }
            }

            // Surface any exception that was captured when the processing task was
            // initially awaited.

            if (processingException != default)
            {
                ExceptionDispatchInfo.Capture(processingException).Throw();
            }
        }

        /// <summary>
        ///   Performs the tasks needed to execute processing for this <see cref="EventProcessor{TPartition}" /> instance, managing owned partitions and
        ///   load balancing between associated processors.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        private async Task RunProcessingAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            try
            {
                var connection = CreateConnection();
                await using var connectionAwaiter = connection.ConfigureAwait(false);

                var retryPolicy = Options.RetryOptions.ToRetryPolicy();
                var cycleDuration = new Stopwatch();
                var partitionIds = default(string[]);

                while (!cancellationToken.IsCancellationRequested)
                {
                    cycleDuration.Restart();

                    try
                    {
                        partitionIds = await connection.GetPartitionIdsAsync(retryPolicy, cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception ex) when (ex.IsNotType<TaskCanceledException>())
                    {
                        // Logging for exceptions with the service operation are responsibility of the connection.

                        _ = InvokeOnProcessingErrorAsync(ex, null, Resources.OperationGetPartitionIds, CancellationToken.None);
                        partitionIds = default;
                    }

                    var remainingTimeUntilNextCycle = await PerformLoadBalancingAsync(cycleDuration, partitionIds, cancellationToken).ConfigureAwait(false);
                    await Task.Delay(remainingTimeUntilNextCycle, cancellationToken).ConfigureAwait(false);
                }

                // Cancellation has been requested; throw the corresponding exception to maintain consistent behavior.

                throw new TaskCanceledException();
            }
            catch (OperationCanceledException ex)
            {
                throw new TaskCanceledException(ex.Message, ex);
            }
            catch (Exception ex) when (ex.IsFatalException())
            {
                throw;
            }
            catch (Exception ex)
            {
                // The error handler is invoked as a fire-and-forget task; the processor does not assume responsibility
                // for observing or surfacing exceptions that may occur in the handler.

                _ = InvokeOnProcessingErrorAsync(ex, null, Resources.OperationEventProcessingLoop, CancellationToken.None);
                Logger.EventProcessorTaskError(Identifier, EventHubName, ConsumerGroup, ex.Message);

                throw;
            }
        }

        /// <summary>
        ///   Performs the tasks needed for a single cycle of load balancing.
        /// </summary>
        ///
        /// <param name="cycleDuration">Responsible for tracking the duration of this cycle.  It is expected that callers manage the stopwatch state; this method will only read from it.</param>
        /// <param name="partitionIds">The valid set of partition identifiers for the Event Hub to which the processor is associated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The interval that callers should delay before invoking the next load balancing cycle.</returns>
        ///
        private async Task<TimeSpan> PerformLoadBalancingAsync(Stopwatch cycleDuration,
                                                               string[] partitionIds,
                                                               CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            // Perform the tasks needed for the load balancing cycle, including managing partition ownership in response to claimed,
            // lost, or faulted partition processors.
            //
            // Ensure that any errors observed, whether fatal or non-fatal, are surfaced to the exception handler in
            // a fire-and-forget manner.  The processor does not assume responsibility for observing or surfacing exceptions
            // that may occur in the handler, so the associated task is intentionally unobserved.

            if ((partitionIds != default) && (partitionIds.Length > 0))
            {
                var claimedOwnership = default(EventProcessorPartitionOwnership);

                try
                {
                    claimedOwnership = await LoadBalancer.RunLoadBalancingAsync(partitionIds, cancellationToken).ConfigureAwait(false);
                }
                catch (EventHubsException ex)
                    when (Resources.OperationClaimOwnership.Equals(ex.GetFailureOperation(), StringComparison.InvariantCultureIgnoreCase))
                {
                    // If a specific partition was associated with the failure, it is carried by a well-known data member of the exception.

                    var partitionId = ex.GetFailureData<string>();

                    var partition = (partitionId ?? string.Empty) switch
                    {
                        string id when (id == string.Empty) => null,
                        string _ when (ActivePartitionProcessors.TryGetValue(partitionId, out var partitionProcessor)) => partitionProcessor.Partition,
                        _ => new TPartition { PartitionId = partitionId }
                    };

                    _ = InvokeOnProcessingErrorAsync(ex.InnerException ?? ex, partition, Resources.OperationClaimOwnership, CancellationToken.None);
                    Logger.EventProcessorClaimOwnershipError(Identifier, EventHubName, ConsumerGroup, partitionId, ((ex.InnerException ?? ex).Message));
                }
                catch (Exception ex) when (ex.IsNotType<TaskCanceledException>())
                {
                    _ = InvokeOnProcessingErrorAsync(ex, null, Resources.OperationLoadBalancing, CancellationToken.None);
                    Logger.EventProcessorLoadBalancingError(Identifier, EventHubName, ConsumerGroup, ex.Message);
                }

                // If a partition was claimed, begin processing it.

                if (claimedOwnership != default)
                {
                    await StartProcessingPartitionAsync(claimedOwnership.PartitionId, cancellationToken).ConfigureAwait(false);
                }
            }

            // Some ownership for some previously claimed partitions may have expired or have been stolen; stop the processing for partitions
            // which are no longer owned.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            await Task.WhenAll(ActivePartitionProcessors.Keys
                .Except(LoadBalancer.OwnedPartitionIds)
                .Select(partitionId => StopProcessingPartitionAsync(partitionId, ProcessingStoppedReason.OwnershipLost, cancellationToken)))
                .ConfigureAwait(false);

            // The remaining processing tasks should be running.  To ensure that is the case, validate the status of the task
            // and restart processing if it has failed.  It is also possible that task creation failed when the processing was started,
            // in which case there would be no task; create them.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            await Task.WhenAll(LoadBalancer.OwnedPartitionIds
                .Select(async partitionId =>
                {
                    if (!ActivePartitionProcessors.TryGetValue(partitionId, out var partitionProcessor) || partitionProcessor.ProcessingTask.IsCompleted)
                    {
                        await StopProcessingPartitionAsync(partitionId, ProcessingStoppedReason.OwnershipLost, cancellationToken).ConfigureAwait(false);
                        await StartProcessingPartitionAsync(partitionId, cancellationToken).ConfigureAwait(false);
                    }
                }))
                .ConfigureAwait(false);

            // Wait the remaining time, if any, to start the next cycle.

            return LoadBalancer.LoadBalanceInterval.CalculateRemaining(cycleDuration.Elapsed);
        }

        /// <summary>
        ///   Begin processing the requested partition in the background and update tracking state
        ///   so that processing can be stopped.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing should be started.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        private async Task StartProcessingPartitionAsync(string partitionId,
                                                         CancellationToken cancellationToken)
        {
            // TODO:  Implement this;  current code is just a place holder.

            var processor = new PartitionProcessor
            (
                Task.Run(() => Task.Delay(Timeout.Infinite, cancellationToken)),
                new TPartition { PartitionId = partitionId },
                () => throw new NotImplementedException(),
                CancellationTokenSource.CreateLinkedTokenSource(cancellationToken)
            );

            ActivePartitionProcessors.AddOrUpdate(partitionId, processor, (key, value) => processor);
            await Task.Delay(1).ConfigureAwait(false);
        }

        /// <summary>
        ///   Stop processing the requested partition, if is currently owned and being processed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing should be stopped.</param>
        /// <param name="reason">The reason why the processing is being stopped.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        private async Task StopProcessingPartitionAsync(string partitionId,
                                                        ProcessingStoppedReason reason,
                                                        CancellationToken cancellationToken)
        {
            // TODO:  Implement this;  current code is just a place holder.
            if (ActivePartitionProcessors.TryRemove(partitionId, out var processor))
            {
                processor.CancellationSource.Cancel();

                try
                {
                    await processor.ProcessingTask.ConfigureAwait(false);
                }
                catch (TaskCanceledException)
                {
                    // nop
                }
                finally
                {
                    processor.CancellationSource.Dispose();
                }
            }

            await Task.Delay(1).ConfigureAwait(false);
        }

        /// <summary>
        ///   Performs the tasks needed invoke the <see cref="OnProcessingErrorAsync" /> method in the background,
        ///   as it is intended to be a fire-and-forget operation.
        /// </summary>
        ///
        /// <param name="exception">The exception that occurred during operation of the event processor.</param>
        /// <param name="partition">The context of the partition associated with the error, if any; otherwise, <c>null</c>.</param>
        /// <param name="operationDescription">A short textual description of the operation during which the exception occurred; intended to be informational only.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.</param>
        ///
        private Task InvokeOnProcessingErrorAsync(Exception exception,
                                                  TPartition partition,
                                                  string operationDescription,
                                                  CancellationToken cancellationToken) => Task.Run(() => OnProcessingErrorAsync(exception, partition, operationDescription, cancellationToken));

        /// <summary>
        ///   A virtual <see cref="StorageManager" /> instance that delegates calls to the
        ///   <see cref="EventProcessor{TPartition}" /> to which it is associated.
        /// </summary>
        ///
        private class DelegatingStorageManager : StorageManager
        {
            /// <summary>
            ///   The <see cref="EventProcessor{TPartition}" /> that the storage manager is associated with.
            /// </summary>
            ///
            private EventProcessor<TPartition> Processor { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="DelegatingStorageManager"/> class.
            /// </summary>
            ///
            /// <param name="processor">The <see cref="EventProcessor{TPartition}" /> to associate the storage manager with.</param>
            ///
            public DelegatingStorageManager(EventProcessor<TPartition> processor) => Processor = processor;

            /// <summary>
            ///   Retrieves a complete ownership list from the data store.
            /// </summary>
            ///
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with. This is ignored in favor of the value from the <see cref="Processor"/>.</param>
            /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with.  This is ignored in favor of the value from the <see cref="Processor"/>.</param>
            /// <param name="consumerGroup">The name of the consumer group the ownership are associated with. This is ignored in favor of the value from the <see cref="Processor"/>.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
            ///
            /// <returns>An enumerable containing all the existing ownership for the associated Event Hub and consumer group.</returns>
            ///
            public override async Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                                         string eventHubName,
                                                                                                         string consumerGroup,
                                                                                                         CancellationToken cancellationToken) => await Processor.ListOwnershipAsync(cancellationToken).ConfigureAwait(false);
            /// <summary>
            ///   Attempts to claim ownership of partitions for processing.
            /// </summary>
            ///
            /// <param name="partitionOwnership">An enumerable containing all the ownership to claim.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
            ///
            /// <returns>An enumerable containing the successfully claimed ownership.</returns>
            ///
            public override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> partitionOwnership,
                                                                                                          CancellationToken cancellationToken) => await Processor.ClaimOwnershipAsync(partitionOwnership, cancellationToken).ConfigureAwait(false);

            /// <summary>
            ///   Retrieves a list of all the checkpoints in a data store for a given namespace, Event Hub and consumer group.
            /// </summary>
            ///
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with. This is ignored in favor of the value from the <see cref="Processor"/>.</param>
            /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with. This is ignored in favor of the value from the <see cref="Processor"/>.</param>
            /// <param name="consumerGroup">The name of the consumer group the checkpoints are associated with. This is ignored in favor of the value from the <see cref="Processor"/>.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
            ///
            /// <returns>An enumerable containing all the existing checkpoints for the associated Event Hub and consumer group.</returns>
            ///
            public override async Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(string fullyQualifiedNamespace,
                                                                                                   string eventHubName,
                                                                                                   string consumerGroup,
                                                                                                   CancellationToken cancellationToken) => await Processor.ListCheckpointsAsync(cancellationToken).ConfigureAwait(false);

            /// <summary>
            ///   This method is not implemented for this type.
            /// </summary>
            ///
            /// <param name="checkpoint">The checkpoint containing the information to be stored.</param>
            /// <param name="eventData">The event to use as the basis for the checkpoint's starting position.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
            ///
            /// <exception cref="NotImplementedException">The method is not implemented for this type.</exception>
            ///
            public override Task UpdateCheckpointAsync(EventProcessorCheckpoint checkpoint,
                                                       EventData eventData,
                                                       CancellationToken cancellationToken) => throw new NotImplementedException();
        }

        /// <summary>
        ///   The set of information needed to track and manage the active processing
        ///   of a partition.
        /// </summary>
        ///
        internal class PartitionProcessor
        {
            /// <summary>The task that is performing the processing.</summary>
            public readonly Task ProcessingTask;

            /// <summary>The partition that is being processed.</summary>
            public readonly TPartition Partition;

            /// <summary>The source token that can be used to cancel the processing for the associated <see cref="ProcessingTask" />.</summary>
            public readonly CancellationTokenSource CancellationSource;

            /// <summary>A function that can be used to read the information about the last enqueued event of the partition.</summary>
            public readonly Func<LastEnqueuedEventProperties> ReadLastEnqueuedEventProperties;

            /// <summary>
            ///   Initializes a new instance of the <see cref="PartitionProcessor"/> class.
            /// </summary>
            ///
            /// <param name="processingTask">The task that is performing the processing.</param>
            /// <param name="partition">The partition that is being processed.</param>
            /// <param name="readLastEnqueuedEventProperties">A function that can be used to read the information about the last enqueued event of the partition.</param>
            /// <param name="cancellationSource">he source token that can be used to cancel the processing.</param>
            ///
            public PartitionProcessor(Task processingTask,
                                      TPartition partition,
                                      Func<LastEnqueuedEventProperties> readLastEnqueuedEventProperties,
                                      CancellationTokenSource cancellationSource) => (ProcessingTask, Partition, ReadLastEnqueuedEventProperties, CancellationSource) = (processingTask, partition, readLastEnqueuedEventProperties, cancellationSource);
        }
    }
}
