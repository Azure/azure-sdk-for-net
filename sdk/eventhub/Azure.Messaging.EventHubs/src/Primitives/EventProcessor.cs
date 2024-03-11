// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Provides a base for creating a custom processor which consumes events across all partitions of a given Event Hub
    ///   for a specific consumer group.  The processor is capable of collaborating with other instances for the same Event
    ///   Hub and consumer group pairing to share work by using a common storage platform to communicate.  Fault tolerance
    ///   is also built-in, allowing the processor to be resilient in the face of errors.
    /// </summary>
    ///
    /// <typeparam name="TPartition">The context of the partition for which an operation is being performed.</typeparam>
    ///
    /// <remarks>
    ///   To enable coordination for sharing of partitions between <see cref="EventProcessor{TPartition}"/> instances, they will assert exclusive read access to partitions
    ///   for the consumer group.  No other readers should be active in the consumer group other than processors intending to collaborate.  Non-exclusive readers will
    ///   be denied access; exclusive readers, including processors using a different storage locations, will interfere with the processor's operation and performance.
    ///
    ///   The <see cref="EventProcessor{TPartition}" /> is safe to cache and use for the lifetime of an application, which is the recommended approach.
    ///   The processor is responsible for ensuring efficient network, CPU, and memory use.  Calling either <see cref="StopProcessingAsync" /> or <see cref="StopProcessing" />
    ///   when all processing is complete or as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.
    /// </remarks>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples">Event Hubs event processor samples and discussion</seealso>
    ///
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public abstract class EventProcessor<TPartition> where TPartition : EventProcessorPartition, new()
    {
        /// <summary>The maximum number of failed consumers to allow when processing a partition; failed consumers are those which have been unable to receive and process events.</summary>
        private const int MaximumFailedConsumerCount = 1;

        /// <summary>Indicates whether or not the consumer should consider itself invalid when a partition is stolen by another consumer, as determined by the Event Hubs service.</summary>
        private const bool InvalidateConsumerWhenPartitionIsStolen = true;

        /// <summary>The minimum duration to allow for a delay between load balancing cycles.</summary>
        private static readonly TimeSpan MinimumLoadBalancingDelay = TimeSpan.FromMilliseconds(15);

        /// <summary>Defines the warning threshold for the upper limit percentage of total ownership interval spent on load balancing.</summary>
        private static readonly double LoadBalancingDurationWarnThreshold = 0.70;

        /// <summary>The primitive for synchronizing access when starting and stopping the processor.</summary>
        private readonly SemaphoreSlim ProcessorRunningGuard = new SemaphoreSlim(1, 1);

        /// <summary>The maximum number of seconds that a load balancing cycle can take before a warning is issued; this value is based on the <see cref="Options" /> for processor.</summary>
        private readonly double LoadBalancingCycleMaximumExecutionSeconds;

        /// <summary>The maximum number of advised partitions that this processor should own; if more are owned, a warning is issued; this value is based on the host environment.</summary>
        private readonly int MaximumAdvisedOwnedPartitions;

        /// <summary>Indicates whether or not this event processor is currently running.  Used only for mocking purposes.</summary>
        private bool? _isRunningOverride;

        /// <summary>Indicates the current state of the processor; used for mocking and manual status updates.</summary>
        private EventProcessorStatus? _statusOverride;

        /// <summary>The task responsible for managing the operations of the processor when it is running.</summary>
        private Task _runningProcessorTask;

        /// <summary>A <see cref="CancellationTokenSource" /> instance to signal the request to cancel the current running task.</summary>
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
        /// <remarks>
        ///   The identifier can be set using the <see cref="EventProcessorOptions.Identifier"/> property on the
        ///   <see cref="EventProcessorOptions"/> passed when constructing the processor.  If not specified, a
        ///   random identifier will be generated.
        ///
        ///   It is recommended that you set a stable unique identifier for processor instances, as this allows
        ///   the processor to recover partition ownership when an application or host instance is restarted.  It
        ///   also aids readability in Azure SDK logs and allows for more easily correlating logs to a specific
        ///   processor instance.
        /// </remarks>
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
                    if (!ProcessorRunningGuard.Wait(100))
                    {
                        return (_statusOverride ?? EventProcessorStatus.NotRunning);
                    }

                    // If we reach this point, the semaphore was acquired and should
                    // be released.

                    statusOverride = _statusOverride;
                    ProcessorRunningGuard.Release();
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
        ///   The active policy which governs retry attempts for the processor.
        /// </summary>
        ///
        protected EventHubsRetryPolicy RetryPolicy { get; }

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
        ///   The client diagnostics for this processor.
        /// </summary>
        ///
        private MessagingClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        /// <param name="loadBalancer">The load balancer to use for coordinating processing with other event processor instances.  If <c>null</c>, the standard load balancer will be created.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        internal EventProcessor(int eventBatchMaximumCount,
                                string consumerGroup,
                                string fullyQualifiedNamespace,
                                string eventHubName,
                                TokenCredential credential,
                                EventProcessorOptions options = default,
                                PartitionLoadBalancer loadBalancer = default) : this(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, (object)credential, options, loadBalancer)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
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
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
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
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
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
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
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

            var connectionStringProperties = EventHubsConnectionStringProperties.Parse(connectionString);
            connectionStringProperties.Validate(eventHubName, nameof(connectionString));

            FullyQualifiedNamespace = connectionStringProperties.Endpoint.Host;
            EventHubName = string.IsNullOrEmpty(eventHubName) ? connectionStringProperties.EventHubName : eventHubName;
            ConsumerGroup = consumerGroup;
            Identifier = string.IsNullOrEmpty(options.Identifier) ? Guid.NewGuid().ToString() : options.Identifier;
            RetryPolicy = options.RetryOptions.ToRetryPolicy();
            Options = options;
            EventBatchMaximumCount = eventBatchMaximumCount;
            LoadBalancingCycleMaximumExecutionSeconds = (options.PartitionOwnershipExpirationInterval.TotalSeconds * LoadBalancingDurationWarnThreshold);
            MaximumAdvisedOwnedPartitions = CalculateMaximumAdvisedOwnedPartitions();

            ConnectionFactory = () => new EventHubConnection(connectionString, eventHubName, options.ConnectionOptions);
            LoadBalancer = new PartitionLoadBalancer(CreateCheckpointStore(this), Identifier, ConsumerGroup, FullyQualifiedNamespace, EventHubName, options.PartitionOwnershipExpirationInterval, options.LoadBalancingUpdateInterval);
            ClientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                FullyQualifiedNamespace,
                EventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        protected EventProcessor(int eventBatchMaximumCount,
                                 string consumerGroup,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 AzureNamedKeyCredential credential,
                                 EventProcessorOptions options = default) : this(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, (object)credential, options, default)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The shared signature credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        protected EventProcessor(int eventBatchMaximumCount,
                                 string consumerGroup,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 AzureSasCredential credential,
                                 EventProcessorOptions options = default) : this(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, (object)credential, options, default)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        protected EventProcessor(int eventBatchMaximumCount,
                                 string consumerGroup,
                                 string fullyQualifiedNamespace,
                                 string eventHubName,
                                 TokenCredential credential,
                                 EventProcessorOptions options = default) : this(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, (object)credential, options, default)
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
        ///   Initializes a new instance of the <see cref="EventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The credential to use for authorization.  This may be of any type supported by the protected constructors.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        /// <param name="loadBalancer">The load balancer to use for coordinating processing with other event processor instances.  If <c>null</c>, the standard load balancer will be created.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        private EventProcessor(int eventBatchMaximumCount,
                               string consumerGroup,
                               string fullyQualifiedNamespace,
                               string eventHubName,
                               object credential,
                               EventProcessorOptions options = default,
                               PartitionLoadBalancer loadBalancer = default)
        {
            Argument.AssertInRange(eventBatchMaximumCount, 1, int.MaxValue, nameof(eventBatchMaximumCount));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            options = options?.Clone() ?? new EventProcessorOptions();

            if (Uri.TryCreate(fullyQualifiedNamespace, UriKind.Absolute, out var uri))
            {
                fullyQualifiedNamespace = uri.Host;
            }

            Argument.AssertWellFormedEventHubsNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            Identifier = string.IsNullOrEmpty(options.Identifier) ? Guid.NewGuid().ToString() : options.Identifier;
            RetryPolicy = options.RetryOptions.ToRetryPolicy();
            Options = options;
            EventBatchMaximumCount = eventBatchMaximumCount;
            LoadBalancingCycleMaximumExecutionSeconds = (options.PartitionOwnershipExpirationInterval.TotalSeconds * LoadBalancingDurationWarnThreshold);
            MaximumAdvisedOwnedPartitions = CalculateMaximumAdvisedOwnedPartitions();

            ConnectionFactory = () => EventHubConnection.CreateWithCredential(fullyQualifiedNamespace, eventHubName, credential, options.ConnectionOptions);
            LoadBalancer = loadBalancer ?? new PartitionLoadBalancer(CreateCheckpointStore(this), Identifier, ConsumerGroup, FullyQualifiedNamespace, EventHubName, Options.PartitionOwnershipExpirationInterval, Options.LoadBalancingUpdateInterval);
            ClientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                FullyQualifiedNamespace,
                EventHubName);
        }

        /// <summary>
        ///   Signals the <see cref="EventProcessor{TPartition}" /> to begin processing events.  Should this method be called while the processor
        ///   is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="EventProcessor{TPartition}" /> once it starts running.</param>
        ///
        /// <exception cref="AggregateException">
        ///   As the processor starts, it will attempt to detect configuration and permissions errors that would prevent it from
        ///   being able to recover without intervention.  For example, an incorrect connection string or the inability to query the
        ///   Event Hub would be detected.  These exceptions will be packaged as an <see cref="AggregateException"/>, and will cause
        ///   <see cref="StartProcessingAsync" /> to fail.
        /// </exception>
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
        /// <exception cref="AggregateException">
        ///   As the processor starts, it will attempt to detect configuration and permissions errors that would prevent it from
        ///   being able to recover without intervention.  For example, an incorrect connection string or the inability to query the
        ///   Event Hub would be detected.  These exceptions will be packaged as an <see cref="AggregateException"/>, and will cause
        ///   <see cref="StartProcessing" /> to fail.
        /// </exception>
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
        /// <remarks>
        ///   When stopping, the processor will update the ownership of partitions that it was responsible for processing and clean up network resources used for communication with
        ///   the Event Hubs service.  As a result, this method will perform network I/O and may need to wait for partition reads that were active to complete.
        ///
        ///   <para>Due to service calls and network latency, an invocation of this method may take slightly longer than the specified <see cref="EventProcessorOptions.MaximumWaitTime" /> or
        ///   if the wait time was not configured, the duration of the <see cref="EventHubsRetryOptions.TryTimeout" /> of the configured retry policy.</para>
        /// </remarks>
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
        /// <remarks>
        ///   When stopping, the processor will update the ownership of partitions that it was responsible for processing and clean up network resources used for communication with
        ///   the Event Hubs service.  As a result, this method will perform network I/O and may need to wait for partition reads that were active to complete.
        ///
        ///   <para>Due to service calls and network latency, an invocation of this method may take slightly longer than the specified <see cref="EventProcessorOptions.MaximumWaitTime" /> or
        ///   if the wait time was not configured, the duration of the <see cref="EventHubsRetryOptions.TryTimeout" /> of the configured retry policy.</para>
        /// </remarks>
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
        ///   Creates an <see cref="TransportConsumer" /> to use for processing.
        /// </summary>
        ///
        /// <param name="consumerGroup">The consumer group to associate with the consumer.</param>
        /// <param name="partitionId">The partition to associated with the consumer.</param>
        /// <param name="consumerIdentifier">The identifier to associate with the consumer; if <c>null</c> or <see cref="string.Empty" />, a random identifier will be generated.</param>
        /// <param name="eventPosition">The position in the event stream where the consumer should begin reading.</param>
        /// <param name="connection">The connection to use for the consumer.</param>
        /// <param name="options">The options to use for configuring the consumer.</param>
        /// <param name="exclusive"><c>true</c> if this should be an exclusive consumer; otherwise, <c>false</c>.</param>
        ///
        /// <returns>An <see cref="TransportConsumer" /> with the requested configuration.</returns>
        ///
        internal virtual TransportConsumer CreateConsumer(string consumerGroup,
                                                          string partitionId,
                                                          string consumerIdentifier,
                                                          EventPosition eventPosition,
                                                          EventHubConnection connection,
                                                          EventProcessorOptions options,
                                                          bool exclusive) =>
            connection.CreateTransportConsumer(
                consumerGroup,
                partitionId,
                consumerIdentifier,
                eventPosition,
                options.RetryOptions.ToRetryPolicy(),
                options.TrackLastEnqueuedEventProperties,
                InvalidateConsumerWhenPartitionIsStolen,
                prefetchCount: (uint?)options.PrefetchCount,
                prefetchSizeInBytes: options.PrefetchSizeInBytes,
                ownerLevel: exclusive ? 0 : null);

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

            if ((eventBatch == null) || ((eventBatch.Count <= 0) && (!dispatchEmptyBatches)))
            {
                return;
            }

            // Create the diagnostics scope used for distributed tracing and instrument the events in the batch.

            using var diagnosticScope = ClientDiagnostics.CreateScope(DiagnosticProperty.EventProcessorProcessingActivityName, ActivityKind.Consumer, MessagingDiagnosticOperation.Process);

            if ((diagnosticScope.IsEnabled) && (eventBatch.Count > 0))
            {
                var isBatch = (EventBatchMaximumCount > 1);

                if (isBatch && ActivityExtensions.SupportsActivitySource)
                {
                    diagnosticScope.AddIntegerAttribute(MessagingClientDiagnostics.BatchCount, eventBatch.Count);
                }

                foreach (var eventData in eventBatch)
                {
                    if (MessagingClientDiagnostics.TryExtractTraceContext(eventData.Properties, out var traceparent, out var tracestate))
                    {
                        if (isBatch)
                        {
                            var attributes = new Dictionary<string, string>(1)
                            {
                                { DiagnosticProperty.EnqueuedTimeAttribute, eventData.EnqueuedTime.ToUnixTimeMilliseconds().ToString(CultureInfo.InvariantCulture) }
                            };

                            // Use links only when the batch size is not set to a single event.

                            diagnosticScope.AddLink(traceparent, tracestate, attributes);
                        }
                        else
                        {
                            diagnosticScope.SetTraceContext(traceparent, tracestate);
                            diagnosticScope.AddAttribute(
                                DiagnosticProperty.EnqueuedTimeAttribute,
                                eventData.EnqueuedTime.ToUnixTimeMilliseconds().ToString(CultureInfo.InvariantCulture));
                        }
                    }
                }
            }

            diagnosticScope.Start();

            // Dispatch the batch to the handler for processing.  Exceptions in the handler code are intended to be
            // unhandled by the processor; explicitly signal that the exception was observed in developer-provided
            // code.

            var operation = Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture);
            var watch = ValueStopwatch.StartNew();

            try
            {
                var startingSequenceNumber = default(string);
                var endingSequenceNumber = default(string);

                if (eventBatch.Count > 0)
                {
                    startingSequenceNumber = eventBatch[0].SequenceNumber.ToString();
                    endingSequenceNumber = eventBatch[eventBatch.Count - 1].SequenceNumber.ToString();
                }

                Logger.EventProcessorProcessingHandlerStart(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, operation, eventBatch.Count, startingSequenceNumber, endingSequenceNumber);
                await OnProcessingEventBatchAsync(eventBatch, partition, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.EventProcessorProcessingHandlerError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, operation, ex.Message);
                diagnosticScope.Failed(ex);

                throw new DeveloperCodeException(ex);
            }
            finally
            {
                Logger.EventProcessorProcessingHandlerComplete(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, operation, watch.GetElapsedTime().TotalSeconds, eventBatch.Count);
            }
        }

        /// <summary>
        ///   Creates the infrastructure for tracking the processing of a partition and begins processing the
        ///   partition in the background until cancellation is requested.
        /// </summary>
        ///
        /// <param name="partition">The Event Hub partition whose processing should be started.</param>
        /// <param name="cancellationSource">A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the operation.</param>
        /// <param name="startingPositionOverride">Allows for skipping partition initialization and directly overriding the position within the event stream where processing will begin.</param>
        ///
        /// <returns>The <see cref="PartitionProcessor" /> encapsulating the processing task, its cancellation token, and associated state.</returns>
        ///
        /// <remarks>
        ///   This method makes liberal use of class methods and state in addition to the received parameters.
        /// </remarks>
        ///
        internal virtual PartitionProcessor CreatePartitionProcessor(TPartition partition,
                                                                     CancellationTokenSource cancellationSource,
                                                                     EventPosition? startingPositionOverride = null)
        {
            cancellationSource.Token.ThrowIfCancellationRequested<TaskCanceledException>();
            var consumer = default(TransportConsumer);

            // If the tracking of the last enqueued event properties was requested, then read the
            // properties from the active consumer, which can change during processing in the event of
            // error scenarios.

            LastEnqueuedEventProperties readLastEnqueuedEventProperties()
            {
                // This is not an expected scenario; the guard exists to prevent a race condition that is
                // unlikely, but possible, when partition processing is being stopped or consumer creation
                // outright failed.

                if ((consumer == null) || (consumer.IsClosed))
                {
                    Argument.AssertNotClosed(true, Resources.ClientNeededForThisInformationNotAvailable);
                }

                return new LastEnqueuedEventProperties(consumer.LastReceivedEvent);
            }

            // Define the routine to handle processing for the partition.

            async Task performProcessing()
            {
                cancellationSource.Token.ThrowIfCancellationRequested<TaskCanceledException>();

                var connection = default(EventHubConnection);
                var retryDelay = default(TimeSpan?);
                var capturedException = default(Exception);
                var eventBatch = default(IReadOnlyList<EventData>);
                var lastEvent = default(EventData);
                var failedAttemptCount = 0;
                var failedConsumerCount = 0;

                // Determine the position to start processing from; this will occur during
                // partition initialization normally, but may be superseded if an override
                // was passed.  In the event that initialization is run and encounters an
                // exception, it takes responsibility for firing the error handler.

                var (startingPosition, checkpoint) = startingPositionOverride switch
                {
                    _ when startingPositionOverride.HasValue => (startingPositionOverride.Value, null),
                    _ => await InitializePartitionForProcessingAsync(partition, cancellationSource.Token).ConfigureAwait(false)
                };

                var checkpointUsed = (checkpoint != null);
                var checkpointLastModified = checkpointUsed ? checkpoint.LastModified : null;
                var checkpointAuthor = checkpointUsed ? checkpoint.ClientIdentifier : null;

                Logger.EventProcessorPartitionProcessingEventPositionDetermined(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, startingPosition.ToString(), checkpointUsed, checkpointLastModified, checkpointAuthor);

                // Create the connection to be used for spawning consumers; if the creation
                // fails, then consider the processing task to be failed.  The main processing
                // loop will take responsibility for attempting to restart or relinquishing ownership.

                try
                {
                    connection = CreateConnection();
                }
                catch (Exception ex)
                {
                    // The error handler is invoked as a fire-and-forget task; the processor does not assume responsibility
                    // for observing or surfacing exceptions that may occur in the handler.

                    _ = InvokeOnProcessingErrorAsync(ex, partition, Resources.OperationReadEvents, CancellationToken.None);
                    Logger.EventProcessorPartitionProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);

                    throw;
                }

                await using var connectionAwaiter = connection.ConfigureAwait(false);

                // Continue processing the partition until cancellation is signaled or until the count of failed consumers is too great.
                // Consumers which been consistently unable to receive and process events will be considered invalid and abandoned for a new consumer.

                while ((!cancellationSource.IsCancellationRequested) && (failedConsumerCount <= MaximumFailedConsumerCount))
                {
                    try
                    {
                        consumer = CreateConsumer(ConsumerGroup, partition.PartitionId, $"P{ partition.PartitionId }-{ Identifier }", startingPosition, connection, Options, true);

                        // Register for notification when the cancellation token is triggered.  Attempt to close the consumer
                        // in response to force-close the link and short-circuit any receive operation that is blocked and
                        // awaiting timeout.

                        using var cancellationRegistration = cancellationSource.Token.Register(static state =>
                        {
                            // Because this is a best-effort attempt and exceptions are expected and not relevant to
                            // callers, use a fire-and-forget approach rather than awaiting.

                            _ = ((TransportConsumer)state).CloseAsync(CancellationToken.None);
                        }, consumer, useSynchronizationContext: false);

                        // Allow the core dispatching loop to apply an additional set of retries over any provided by the consumer
                        // itself, as a processor should be as resilient as possible and retain partition ownership if processing is
                        // able to make forward progress.  If the retries are exhausted or a non-retriable exception occurs, the
                        // consumer will be considered invalid and potentially refreshed.

                        while (!cancellationSource.IsCancellationRequested)
                        {
                            var stopWatch = ValueStopwatch.StartNew();
                            var cycleStartTime = Logger.GetLogFormattedUtcNow();

                            try
                            {
                                eventBatch = await consumer.ReceiveAsync(EventBatchMaximumCount, Options.MaximumWaitTime, cancellationSource.Token).ConfigureAwait(false);
                                await ProcessEventBatchAsync(partition, eventBatch, Options.MaximumWaitTime.HasValue, cancellationSource.Token).ConfigureAwait(false);

                                // If the batch was successfully processed, capture the last event as the current starting position, in the
                                // event that the consumer becomes invalid and needs to be replaced.

                                lastEvent = (eventBatch != null && eventBatch.Count > 0) ? eventBatch[eventBatch.Count - 1] : null;

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
                            catch (EventHubsException ex) when (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
                            {
                                // This is an expected scenario that may occur when ownership changes; log the exception for tracking but
                                // do not surface it to the error handler.

                                Logger.EventProcessorPartitionProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);
                                throw;
                            }
                            catch (Exception ex) when ((cancellationSource.IsCancellationRequested)
                                && (((ex is EventHubsException ehEx) && (ehEx.Reason == EventHubsException.FailureReason.ClientClosed)) || (ex is ObjectDisposedException)))
                            {
                                // Do not log as an exception; this is an expected scenario when partition processing is asked to stop.

                                Logger.EventProcessorPartitionProcessingStopConsumerClose(partition.PartitionId, Identifier, EventHubName, ConsumerGroup);
                                throw new TaskCanceledException();
                            }
                            catch (Exception ex) when (ex.IsNotType<DeveloperCodeException>())
                            {
                                // The error handler is invoked as a fire-and-forget task; the processor does not assume responsibility
                                // for observing or surfacing exceptions that may occur in the handler.

                                _ = InvokeOnProcessingErrorAsync(ex, partition, Resources.OperationReadEvents, CancellationToken.None);

                                Logger.EventProcessorPartitionProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);
                                retryDelay = RetryPolicy.CalculateRetryDelay(ex, ++failedAttemptCount);

                                if (!retryDelay.HasValue)
                                {
                                    // If the exception should not be retried, then allow it to pass to the outer loop; this is intended
                                    // to prevent being stuck in a corrupt state where the consumer is unable to read events.

                                    throw;
                                }

                                await Task.Delay(retryDelay.Value, cancellationSource.Token).ConfigureAwait(false);
                            }

                            // Capture the end-to-end cycle information for the partition.  This is intended to provide an
                            // all-up view for partition processing, showing when and how long it took for a batch be read and
                            // processed.

                            var startingSequence = default(string);
                            var endingSequence = default(string);

                            if (eventBatch != null && eventBatch.Count > 0)
                            {
                                startingSequence = eventBatch[0].SequenceNumber.ToString();
                                endingSequence = eventBatch[eventBatch.Count - 1].SequenceNumber.ToString();
                            }

                            Logger.EventProcessorPartitionProcessingCycleComplete(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, eventBatch?.Count ?? 0, startingSequence, endingSequence, cycleStartTime, Logger.GetLogFormattedUtcNow(), stopWatch.GetElapsedTime().TotalSeconds);
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        throw;
                    }
                    catch (OperationCanceledException ex)
                    {
                        throw new TaskCanceledException(ex.Message, ex);
                    }
                    catch (DeveloperCodeException ex)
                    {
                        // If an exception leaked from developer-provided code, the processor lacks the proper level of context and
                        // insight to understand if it is safe to ignore and continue.  Instead, this will be thrown and allowed to
                        // fault the partition processing task.  To ensure visibility, log the error with an explicit call-out to identify
                        // it as originating in developer code.

                        var message = string.Format(CultureInfo.InvariantCulture, Resources.DeveloperCodeExceptionMessageMask, ex.InnerException.Message);
                        Logger.EventProcessorPartitionProcessingError(partition.PartitionId, Identifier, EventHubName, ConsumerGroup, message);

                        // Because this can be non-obvious to developers who are not capturing logs, also surface an exception to the error handler
                        // which offers guidance for error handling in developer code.

                        var handlerException = new EventHubsException(false, EventHubName, Resources.DeveloperCodeEventProcessingError, EventHubsException.FailureReason.GeneralError, ex.InnerException);
                        _  = InvokeOnProcessingErrorAsync(handlerException, partition, Resources.OperationEventProcessingDeveloperCode, CancellationToken.None);

                        // Discard the wrapper and propagate just the source exception from developer code.

                        ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                    }
                    catch (EventHubsException ex) when (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
                    {
                        // If the partition was stolen, the consumer should not be recreated as that would reassert ownership
                        // and potentially interfere with the new owner.  Instead, the exception should be surfaced to fault
                        // the processor task and allow the next load balancing cycle to make the decision on whether processing
                        // should be restarted or the new owner acknowledged.

                        ReportPartitionStolen(partition.PartitionId);
                        throw;
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

            // Start processing in the background and return the processor metadata.  Since the task is
            // expected to run continually until the processor is stopped or ownership changes, mark it as
            // long-running.  Other than the long-running designation, the options used intentionally match
            // the recommended defaults used by Task.Run.
            //
            // For more context, see: https://devblogs.microsoft.com/pfxteam/task-run-vs-task-factory-startnew/

            return new PartitionProcessor
            (
                Task.Factory.StartNew(performProcessing, cancellationSource.Token, TaskCreationOptions.LongRunning | TaskCreationOptions.DenyChildAttach, TaskScheduler.Default).Unwrap(),
                partition,
                readLastEnqueuedEventProperties,
                cancellationSource
            );
        }

        /// <summary>
        ///   Creates an <see cref="EventHubConnection" /> to use for communicating with the Event Hubs service.
        /// </summary>
        ///
        /// <returns>The requested <see cref="EventHubConnection" />.</returns>
        ///
        protected internal virtual EventHubConnection CreateConnection() => ConnectionFactory();

        /// <summary>
        ///   Performs the tasks needed to validate basic configuration and permissions of the dependencies needed for
        ///   the processor to function.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the validation.</param>
        ///
        /// <exception cref="AggregateException">Any validation failures will result in an aggregate exception.</exception>
        ///
        protected internal virtual async Task ValidateProcessingPreconditions(CancellationToken cancellationToken)
        {
            var validationTask = Task.WhenAll
            (
                ValidateEventHubsConnectionAsync(cancellationToken),
                ValidateStorageConnectionAsync(cancellationToken)
            );

            try
            {
                await validationTask.ConfigureAwait(false);
            }
            catch
            {
                // If the validation task has an exception, it will be the aggregate exception
                // that we wish to surface.  Use that if it is available.

                if (validationTask.Exception != null)
                {
                    throw validationTask.Exception;
                }

                throw;
            }
        }

        /// <summary>
        ///   Produces a list of the available checkpoints for the Event Hub and consumer group associated with the
        ///   event processor instance, so that processing for a given set of partitions can be properly initialized.
        ///   It's recommended that <see cref="GetCheckpointAsync"/> is implemented instead of overriding <see cref="ListCheckpointsAsync"/> for
        ///   better performance and efficiency.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of checkpoints for the processor to take into account when initializing partitions.</returns>
        ///
        /// <remarks>
        ///   This method exists to preserve backwards compatibility; it is highly recommended that <see cref="GetCheckpointAsync(string, CancellationToken)" />
        ///   be overridden and implemented instead to improve efficiency.
        /// </remarks>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken) => throw new NotImplementedException(Resources.ListCheckpointsAsyncObsolete);

        /// <summary>
        ///   Returns a checkpoint for the Event Hub, consumer group, and identifier of the partition associated with the
        ///   event processor instance, so that processing for a given partition can be properly initialized.
        ///   The default implementation calls the <see cref="ListCheckpointsAsync"/> and filters results by <see cref="EventProcessorCheckpoint.PartitionId"/>.
        ///   It's recommended that this method is overridden in <see cref="EventProcessor{TPartition}"/> implementations to achieve an optimal performance.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition for which to retrieve the checkpoint.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The checkpoint for the processor to take into account when initializing partition.</returns>
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
        protected virtual async Task<EventProcessorCheckpoint> GetCheckpointAsync(string partitionId,
                                                                                  CancellationToken cancellationToken)
        {
            foreach (var checkpoint in await ListCheckpointsAsync(cancellationToken).ConfigureAwait(false))
            {
                if (checkpoint.PartitionId == partitionId)
                {
                    return checkpoint;
                }
            }

            return null;
        }

        /// <summary>
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="offset">The offset to associate with the checkpoint, intended as informational metadata. This will only be used for positioning if there is no value provided for <paramref name="sequenceNumber"/>.</param>
        /// <param name="sequenceNumber">The sequence number to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        /// <remarks>
        ///   This overload exists to preserve backwards compatibility; it is highly recommended that <see cref="UpdateCheckpointAsync(string, CheckpointPosition, CancellationToken)" />
        ///   be called instead.
        /// </remarks>
        ///
        protected virtual Task UpdateCheckpointAsync(string partitionId,
                                                     long offset,
                                                     long? sequenceNumber,
                                                     CancellationToken cancellationToken)
        {
            if (sequenceNumber.HasValue)
            {
                return UpdateCheckpointAsync(partitionId, new CheckpointPosition(sequenceNumber.Value), cancellationToken);
            }

            throw new NotImplementedException();
        }

        /// <summary>
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="startingPosition">The starting position to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        protected virtual Task UpdateCheckpointAsync(string partitionId,
                                                     CheckpointPosition startingPosition,
                                                     CancellationToken cancellationToken) => throw new NotImplementedException();

        /// <summary>
        ///   Requests a list of the ownership assignments for partitions between each of the cooperating event processor
        ///   instances for a given Event Hub and consumer group pairing.  This method is used during load balancing to allow
        ///   the processor to discover other active collaborators and to make decisions about how to best balance work
        ///   between them.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership data to take into account when making load balancing decisions.</returns>
        ///
        protected abstract Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken);

        /// <summary>
        ///   Attempts to claim ownership of the specified partitions for processing.  This operation is used by
        ///   load balancing to enable distributing the responsibility for processing partitions for an
        ///   Event Hub and consumer group pairing amongst the active event processors.
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
        ///   The number of events in the <paramref name="events"/> batch may vary, with the batch containing between zero and maximum batch size that was specified when the processor was created.
        ///   The actual number of events in a batch depends on the number events available in the processor's prefetch queue at the time when a read takes place.
        ///
        ///   When at least one event is available in the prefetch queue, they will be used to form the batch as close to the requested maximum batch size as possible without waiting for additional
        ///   events from the Event Hub partition to be read.  When no events are available in prefetch the processor will wait until at least one event is available or the requested
        ///   <see cref="EventProcessorOptions.MaximumWaitTime"/> has elapsed, after which the batch will be dispatched for processing.
        ///
        ///   If <see cref="EventProcessorOptions.MaximumWaitTime"/> is <c>null</c>, the processor will continue trying to read from the Event Hub partition until a batch with at least one event could
        ///   be formed and will not dispatch any empty batches to this method.
        ///
        ///   This method will be invoked concurrently, limited to one call per partition. The processor will await each invocation to ensure
        ///   that the events from the same partition are processed in the order that they were read from the partition.  No time limit is
        ///   imposed on an invocation of this handler; the processor will wait indefinitely for execution to complete before dispatching another
        ///   event for the associated partition.  It is safe for implementations to perform long-running operations, retries, delays, and dead-lettering activities.
        ///
        ///   Should an exception occur within the code for this method, the event processor will allow it to propagate up the stack without attempting to handle it in any way.
        ///   On most hosts, this will fault the task responsible for partition processing, causing it to be restarted from the last checkpoint.  On some hosts, it may crash the process.
        ///   Developers are strongly encouraged to take all exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.
        ///
        ///   It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.
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
        ///   should be terminated or restarted.  If desired, this can be done safely by calling <see cref="StopProcessingAsync" /> and/or <see cref="StartProcessingAsync" />.
        ///
        ///   It is recommended that, for production scenarios, the decision be made by considering observations made by this error handler, the method invoked
        ///   when initializing processing for a partition, and the method invoked when processing for a partition is stopped.  Many developers will also include
        ///   data from their monitoring platforms in this decision as well.
        ///
        ///   As with event processing, should an exception occur in the code for the error handler, the event processor will allow it to bubble and will not attempt to handle
        ///   it in any way.  Developers are strongly encouraged to take exception scenarios into account and guard against them using try/catch blocks and other means as appropriate.
        ///
        ///   This method will be invoked concurrently and is not awaited by the processor, as each error is independent.  No time limit is imposed on an invocation; it is safe for
        ///   implementations to perform long-running operations and retries as needed.
        /// </remarks>
        ///
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/TROUBLESHOOTING.md">Troubleshoot Event Hubs issues</seealso>
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
        /// <remarks>
        ///   It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.
        ///
        ///   This method will be invoked concurrently, limited to one call per partition.  The processor will await each invocation before beginning to process
        ///   the associated partition.
        ///
        ///   The processor will wait indefinitely for execution of the handler to complete. It is recommended for implementations to avoid
        ///   long-running operations, as they will delay processing for the associated partition.
        /// </remarks>
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
        /// <remarks>
        ///   It is not recommended that the state of the processor be managed directly from within this method; requesting to start or stop the processor may result in
        ///   a deadlock scenario, especially if using the synchronous form of the call.
        ///
        ///   This method will be invoked concurrently, as each close is independent.  No time limit is imposed on an invocation; it is safe for implementations
        ///   to perform long-running operations and retries as needed.  This handler has no influence on processing for the associated partition and offers no
        ///   guarantee that execution will complete before processing for the partition is restarted or migrates to a new host.
        /// </remarks>
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
        protected virtual LastEnqueuedEventProperties ReadLastEnqueuedEventProperties(string partitionId)
        {
            if (!ActivePartitionProcessors.TryGetValue(partitionId, out var processor))
            {
                Argument.AssertNotClosed(true, Resources.ClientNeededForThisInformationNotAvailable);
            }

            return processor.ReadLastEnqueuedEventProperties();
        }

        /// <summary>
        ///   Queries for the identifiers of the Event Hub partitions.
        /// </summary>
        ///
        /// <param name="connection">The active connection to the Event Hubs service.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the query.</param>
        ///
        /// <returns>The set of identifiers for the Event Hub partitions.</returns>
        ///
        protected virtual async Task<string[]> ListPartitionIdsAsync(EventHubConnection connection,
                                                                     CancellationToken cancellationToken) =>
            await connection.GetPartitionIdsAsync(RetryPolicy, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Allows reporting that a partition was stolen by another event consumer causing ownership
        ///   to be considered relinquished until the next load balancing cycle reconciles it.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition that was stolen.</param>
        ///
        private void ReportPartitionStolen(string partitionId) => LoadBalancer.ReportPartitionStolen(partitionId);

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

            var capturedValidationException = default(Exception);

            try
            {
                // Acquire the semaphore used to synchronize processor starts and stops, respecting
                // the async flag.  When this is held, the state of the processor is stable.

                if (async)
                {
                    await ProcessorRunningGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    ProcessorRunningGuard.Wait(cancellationToken);
                }

                // If the processor is already running, then it was started before the
                // semaphore was acquired; there is no work to be done.

                if (_runningProcessorTask != null)
                {
                    return;
                }

                _statusOverride = EventProcessorStatus.Starting;

                // There should be no cancellation source, but guard against leaking resources in the
                // event of a processing crash or other exception.

                _runningProcessorCancellationSource?.Cancel();
                _runningProcessorCancellationSource?.Dispose();
                _runningProcessorCancellationSource = new CancellationTokenSource();

                // Start processing in the background. Since the task is expected to run continually
                // until the processor is stopped or ownership changes, mark it as long-running.
                // Other than the long-running designation, the options used intentionally match
                // the recommended defaults used by Task.Run.
                //
                // For more context, see: https://devblogs.microsoft.com/pfxteam/task-run-vs-task-factory-startnew/

                ActivePartitionProcessors.Clear();
                _runningProcessorTask = Task.Factory.StartNew(() => RunProcessingAsync(_runningProcessorCancellationSource.Token), _runningProcessorCancellationSource.Token, TaskCreationOptions.LongRunning | TaskCreationOptions.DenyChildAttach, TaskScheduler.Default).Unwrap();

                // Validate the processor configuration and ensuring basic permissions are held for
                // service operations.

                try
                {
                    if (async)
                    {
                        await ValidateProcessingPreconditions(cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        // Wait is used over GetAwaiter().GetResult() because it will
                        // ensure an AggregateException is thrown rather than unwrapping and
                        // throwing only the first exception.

                        ValidateProcessingPreconditions(cancellationToken).Wait(cancellationToken);
                    }
                }
                catch (AggregateException ex)
                {
                    // Capture the validation exception and log, but do not throw.  Because this is
                    // a fatal exception and the processing task was already started, StopProcessing
                    // will need to be called, which requires the semaphore.  The validation exception
                    // will be handled after the start operation has officially completed and the
                    // semaphore has been released.

                    capturedValidationException = ex.Flatten();
                    Logger.EventProcessorStartError(Identifier, EventHubName, ConsumerGroup, ex.Message);

                    // Canceling the main source here won't cause a problem and will help expedite stopping
                    // the processor later.

                    try
                    {
                        _runningProcessorCancellationSource?.Cancel();
                    }
                    catch (Exception cancelEx)
                    {
                        Logger.ProcessorStoppingCancellationWarning(Identifier, EventHubName, ConsumerGroup, cancelEx.Message);
                    }
                }

                // Ensure the load balancing and partition ownership intervals are not configured too closely.  The ownership
                // interval should be at least twice the load balancing interval.  Documented guidance recommends a factor of
                // three.
                //
                // A smaller gap is valid and may be desirable in some unusual scenarios, but is likely to cause
                // issues for mainline scenarios.  Emit a warning to the error handler and logs, but allow starting to proceed.

                var ownershipSeconds = Options.PartitionOwnershipExpirationInterval.TotalSeconds;
                var loadBalancingSeconds = Options.LoadBalancingUpdateInterval.TotalSeconds;

                if (ownershipSeconds < (loadBalancingSeconds * 2))
                {
                    Logger.ProcessorLoadBalancingIntervalsTooCloseWarning(Identifier, EventHubName, loadBalancingSeconds, ownershipSeconds);

                    var message = string.Format(CultureInfo.InvariantCulture, Resources.ProcessorLoadBalancingIntervalsTooCloseMask, loadBalancingSeconds, ownershipSeconds);
                    var intervalException = new EventHubsException(true, EventHubName, message, EventHubsException.FailureReason.GeneralError);
                    _ = InvokeOnProcessingErrorAsync(intervalException, null, Resources.OperationLoadBalancing, CancellationToken.None);
                }
            }
            catch (OperationCanceledException ex)
            {
                Logger.EventProcessorStartError(Identifier, EventHubName, ConsumerGroup, ex.Message);
                throw new TaskCanceledException();
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

                if (ProcessorRunningGuard.CurrentCount == 0)
                {
                    ProcessorRunningGuard.Release();
                }
            }

            // If there was a validation exception captured, then stop the processor now
            // that it is safe to do so.

            if (capturedValidationException != null)
            {
                try
                {
                    if (async)
                    {
                        await StopProcessingInternalAsync(async, CancellationToken.None).ConfigureAwait(false);
                    }
                    else
                    {
                        StopProcessingInternalAsync(async, CancellationToken.None).EnsureCompleted();
                    }
                }
                catch
                {
                    // An exception is expected here, as the processor configuration was invalid and
                    // processing was canceled.  It will have already been logged; ignore it here.
                }

                ExceptionDispatchInfo.Capture(capturedValidationException).Throw();
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

            try
            {
                // Acquire the semaphore used to synchronize processor starts and stops, respecting
                // the async flag.  When this is held, the state of the processor is stable.

                if (async)
                {
                    await ProcessorRunningGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    ProcessorRunningGuard.Wait(cancellationToken);
                }

                _statusOverride = EventProcessorStatus.Stopping;

                // If the processor is not running, then it was never started or has been stopped
                // before the semaphore was acquired; there is no work to be done.

                if (_runningProcessorTask == null)
                {
                    return;
                }

                // Request cancellation of the running processor task.  If developer code registered a cancellation
                // callback in one of the event handlers, it is possible that cancellation will throw.  Capture this
                // as a warning so that it does not interfere with shutting down the processor.

                try
                {
                    _runningProcessorCancellationSource?.Cancel();
                }
                catch (Exception ex)
                {
                    Logger.ProcessorStoppingCancellationWarning(Identifier, EventHubName, ConsumerGroup, ex.Message);
                }

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
                catch
                {
                    // No action is needed.  The task logs and surfaces the exception itself.
                }

                // With the processing task having completed, perform the necessary cleanup of partition processing tasks
                // and surrender ownership.

                var stopPartitionProcessingTasks = new Task[ActivePartitionProcessors.Keys.Count];
                var index = -1;

                foreach (var partitionId in ActivePartitionProcessors.Keys)
                {
                    stopPartitionProcessingTasks[++index] = StopProcessingPartitionAsync(partitionId, ProcessingStoppedReason.Shutdown, CancellationToken.None);
                };

                if (async)
                {
                    await Task.WhenAll(stopPartitionProcessingTasks).ConfigureAwait(false);
                    await LoadBalancer.RelinquishOwnershipAsync(CancellationToken.None).ConfigureAwait(false);
                }
                else
                {
                    Task.WaitAll(stopPartitionProcessingTasks, CancellationToken.None);

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
            catch (OperationCanceledException ex)
            {
                Logger.EventProcessorStopError(Identifier, EventHubName, ConsumerGroup, ex.Message);
                throw new TaskCanceledException();
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

                if (ProcessorRunningGuard.CurrentCount == 0)
                {
                    ProcessorRunningGuard.Release();
                }
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

                ValueStopwatch cycleDuration;
                var partitionIds = default(string[]);

                while (!cancellationToken.IsCancellationRequested)
                {
                    var startingOwnedPartitionCount = LoadBalancer.OwnedPartitionCount;
                    cycleDuration = ValueStopwatch.StartNew();

                    try
                    {
                        partitionIds = await ListPartitionIdsAsync(connection, cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception ex) when (ex.IsNotType<TaskCanceledException>())
                    {
                        // Do not invoke the error handler when failing to list partitions as the processor is
                        // stopping.  Instead, signal cancellation to short-circuit and avoid trying to run a
                        // load balancing cycle.

                        if (cancellationToken.IsCancellationRequested)
                        {
                            throw new TaskCanceledException();
                        }

                        // Logging for exceptions with the service operation are responsibility of the connection. Only the handler
                        // invocation needs to be performed here.

                        _ = InvokeOnProcessingErrorAsync(ex, null, Resources.OperationGetPartitionIds, CancellationToken.None);
                        partitionIds = default;
                    }

                    // Execute the current load balancing cycle.

                    Logger.EventProcessorLoadBalancingCycleStart(Identifier, EventHubName, partitionIds?.Length ?? 0, startingOwnedPartitionCount);
                    TimeSpan remainingTimeUntilNextCycle;

                    try
                    {
                        var totalPartitions = partitionIds?.Length ?? 0;
                        remainingTimeUntilNextCycle = await PerformLoadBalancingAsync(cycleDuration, partitionIds, cancellationToken).ConfigureAwait(false);

                        var endingOwnedPartitionCount = LoadBalancer.OwnedPartitionCount;
                        var cycleElapsedSeconds = cycleDuration.GetElapsedTime().TotalSeconds;

                        Logger.EventProcessorLoadBalancingCycleComplete(Identifier, EventHubName, totalPartitions, endingOwnedPartitionCount, cycleElapsedSeconds, remainingTimeUntilNextCycle.TotalSeconds);

                        // If the duration of the load balancing cycle was long enough to potentially impact ownership stability,
                        // emit warnings.  This is impactful enough that the error handler will be pinged to ensure visibility for the
                        // host application.

                        if (cycleElapsedSeconds >= LoadBalancingCycleMaximumExecutionSeconds)
                        {
                            var ownershipIntervalSeconds = LoadBalancer.OwnershipExpirationInterval.TotalSeconds;
                            Logger.EventProcessorLoadBalancingCycleSlowWarning(Identifier, EventHubName, cycleElapsedSeconds, ownershipIntervalSeconds);

                            var message = string.Format(CultureInfo.InvariantCulture, Resources.ProcessorLoadBalancingCycleSlowMask, cycleElapsedSeconds, ownershipIntervalSeconds);
                            var slowException = new EventHubsException(true, EventHubName, message, EventHubsException.FailureReason.GeneralError);
                            _ = InvokeOnProcessingErrorAsync(slowException, null, Resources.OperationEventProcessingLoop, CancellationToken.None);
                        }

                        // If the number of partitions owned has changed since the cycle started and is above maximum advisable set, emit a warning.  This is
                        // a loose heuristic and does not apply to all workloads.  The error handler will not be pinged to avoid false positive notifications.

                        if ((startingOwnedPartitionCount != endingOwnedPartitionCount) && (endingOwnedPartitionCount > MaximumAdvisedOwnedPartitions))
                        {
                            Logger.EventProcessorHighPartitionOwnershipWarning(Identifier, EventHubName, totalPartitions, endingOwnedPartitionCount, MaximumAdvisedOwnedPartitions);
                        }
                    }
                    catch (Exception ex) when ((ex.IsNotType<TaskCanceledException>()) && (!ex.IsFatalException()))
                    {
                        // Do not invoke the error handler when the processor is stopping.  Instead, signal cancellation to
                        // short-circuit and avoid trying to run another load balancing cycle.

                        if (cancellationToken.IsCancellationRequested)
                        {
                            throw new TaskCanceledException();
                        }

                        _ = InvokeOnProcessingErrorAsync(ex, null, Resources.OperationGetPartitionIds, CancellationToken.None);
                        Logger.EventProcessorTaskError(Identifier, EventHubName, ConsumerGroup, ex.Message);

                        // In the case of a load balancing failure, run another cycle again with minimal delay.

                        remainingTimeUntilNextCycle = MinimumLoadBalancingDelay;
                    }

                    // Evaluate the time remaining before the next cycle and delay.

                    await Task.Delay(remainingTimeUntilNextCycle, cancellationToken).ConfigureAwait(false);
                }

                // Cancellation has been requested; throw the corresponding exception to maintain consistent behavior.

                throw new TaskCanceledException();
            }
            catch (TaskCanceledException)
            {
                throw;
            }
            catch (OperationCanceledException ex)
            {
                throw new TaskCanceledException(ex.Message, ex);
            }
            catch (Exception ex) when (ex.IsFatalException())
            {
                // It is not safe to allocate or log here, as this class of errors includes those such as
                // OutOfMemoryException and StackOverflowException.  It is assumed the process is crashing.

                throw;
            }
            catch (Exception ex)
            {
                // The error handler is invoked as a fire-and-forget task; the processor does not assume responsibility
                // for observing or surfacing exceptions that may occur in the handler.

                var fatalException = new EventHubsException(false, EventHubName, string.Format(CultureInfo.InvariantCulture, Resources.ProcessorLoadBalancingFatalErrorMask, ex.Message), EventHubsException.FailureReason.InvalidClientState, ex);
                _ = InvokeOnProcessingErrorAsync(fatalException, null, Resources.OperationEventProcessingLoop, CancellationToken.None);

                Logger.EventProcessorFatalTaskError(Identifier, EventHubName, ConsumerGroup, ex.Message);

                // Attempt to stop the processor as a best effort.  This needs to take place in the background
                // as it awaits the task that this method is running in and will otherwise deadlock.

                _ = Task.Run(() =>
                {
                    StopProcessingInternalAsync(true, CancellationToken.None)
                        .ContinueWith(stopTask =>
                        {
                            var stopEx = stopTask.Exception.Flatten().InnerException;
                            _ = InvokeOnProcessingErrorAsync(stopEx, null, Resources.OperationLoadBalancing, CancellationToken.None);
                        },
                        TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.RunContinuationsAsynchronously);
                });

                throw fatalException;
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
        /// <returns>The interval that callers should delay before invoking the next load balancing cycle; <see cref="TimeSpan.Zero"/> if callers should invoke the next cycle immediately.</returns>
        ///
        private async Task<TimeSpan> PerformLoadBalancingAsync(ValueStopwatch cycleDuration,
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

            var claimedOwnership = default(EventProcessorPartitionOwnership);

            if ((partitionIds != default) && (partitionIds.Length > 0))
            {
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
                        string id when (id.Length == 0) => null,
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

                // If a partition was claimed, begin processing it if not already being processed.

                if ((claimedOwnership != default) && (!ActivePartitionProcessors.ContainsKey(claimedOwnership.PartitionId)))
                {
                    TryStartProcessingPartition(claimedOwnership.PartitionId, cancellationToken);
                }
            }

            // Some ownership for some previously claimed partitions may have expired or have been stolen; stop the processing
            // for partitions which are no longer owned.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            foreach (var partitionId in ActivePartitionProcessors.Keys)
            {
                if (!LoadBalancer.IsPartitionOwned(partitionId))
                {
                   // The partition is no longer owned.  Stopping may take longer than a load balancing cycle
                   // should run if event processing is active and chooses not to honor cancellation immediately, so
                   // do not wait for the stop to complete.  Its continuation will ensure proper clean-up even when unobserved.
                   // If the processor is stopped, the task will be awaited then to ensure that all processing is complete.

                   _ = StopProcessingPartitionAsync(partitionId, ProcessingStoppedReason.OwnershipLost, cancellationToken);
                }
            }

            // The tasks for owned partitions should be running.  To ensure that is the case, validate the status of the task
            // and restart processing if it has failed.  It is also possible that task creation failed when the processing was started,
            // in which case there would be no task; create them.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            foreach (var partitionId in LoadBalancer.OwnedPartitionIds)
            {
                var processorFound = ActivePartitionProcessors.TryGetValue(partitionId, out var partitionProcessor);

                if ((!processorFound) || (partitionProcessor.ProcessingTask.IsCompleted))
                {
                    // If there is a processing task, it is known to have been completed so awaiting will not be blocked by event
                    // processing currently in flight.  Any time spent will be in the StopProcessingPartitionAsync handler, which
                    // is expected to run quickly.

                    if (processorFound)
                    {
                        await StopProcessingPartitionAsync(partitionId, ProcessingStoppedReason.OwnershipLost, cancellationToken).ConfigureAwait(false);
                    }

                    TryStartProcessingPartition(partitionId, cancellationToken);
                }
            }

            // If load balancing is greedy and ownership is not balanced, then signal that there should be a very minimal delay before
            // invoking the next load balancing cycle, to ensure a yield which allows the thread pool to manage its load.

            if ((Options.LoadBalancingStrategy == LoadBalancingStrategy.Greedy) && (!LoadBalancer.IsBalanced))
            {
                return MinimumLoadBalancingDelay;
            }

            // Wait the remaining time, if any, to start the next cycle.

            var nextCycle = LoadBalancer.LoadBalanceInterval.CalculateRemaining(cycleDuration.GetElapsedTime());
            return (nextCycle >= MinimumLoadBalancingDelay) ? nextCycle : MinimumLoadBalancingDelay;
        }

        /// <summary>
        ///   Performs the actions needed to initialize a partition for processing; this
        ///   includes invoking the initialization handler and querying checkpoints.
        /// </summary>
        ///
        /// <param name="partition">The partition to initialize.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A tuple containing the <see cref="EventPosition" /> to start processing from and whether the position was based on a checkpoint or not.</returns>
        ///
        /// <remarks>
        ///   This method will invoke the error handler should an exception be encountered; the
        ///   exception will then be bubbled to callers.
        /// </remarks>
        ///
        private async Task<(EventPosition Position, EventProcessorCheckpoint CheckpointUsed)> InitializePartitionForProcessingAsync(TPartition partition,
                                                                                                                                    CancellationToken cancellationToken)
        {
            var operationDescription = Resources.OperationClaimOwnership;

            try
            {
                // Initialize the partition context; the handler is responsible for initialing any custom fields of the partition type.

                await OnInitializingPartitionAsync(partition, cancellationToken).ConfigureAwait(false);

                // Query the available checkpoints for the partition.

                operationDescription = Resources.OperationListCheckpoints;
                var checkpoint = await GetCheckpointAsync(partition.PartitionId, cancellationToken).ConfigureAwait(false);

                // Determine the starting position for processing the partition.

                operationDescription = Resources.OperationClaimOwnership;

                if (checkpoint != null)
                {
                    return (checkpoint.StartingPosition, checkpoint);
                }

                return (Options.DefaultStartingPosition, null);
            }
            catch (Exception ex)
            {
                // The error handler is invoked as a fire-and-forget task; the processor does not assume responsibility
                // for observing or surfacing exceptions that may occur in the handler.

                _ = InvokeOnProcessingErrorAsync(ex, partition, operationDescription, CancellationToken.None);
                throw;
            }
        }

        /// <summary>
        ///   Attempts to begin processing the requested partition in the background and update tracking state
        ///   so that processing can be stopped.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing should be started.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><c>true</c> if processing was successfully started; otherwise, <c>false</c>.</returns>
        ///
        /// <remarks>
        ///   Exceptions encountered in this method will be logged and will result in the error handler being
        ///   invoked.  They will not be surfaced to callers.  This is intended to be a safe operation consumed
        ///   as part of the load balancing cycle, which is failure-tolerant.
        /// </remarks>
        ///
        private bool TryStartProcessingPartition(string partitionId,
                                                 CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.EventProcessorPartitionProcessingStart(partitionId, Identifier, EventHubName, ConsumerGroup);

            var partition = new TPartition { PartitionId = partitionId };
            var cancellationSource = default(CancellationTokenSource);

            try
            {
                // Create and register the partition processor.  Ownership of the cancellationSource is transferred
                // to the processor upon creation, including the responsibility for disposal.

                cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, CancellationToken.None);
                var processor = CreatePartitionProcessor(partition, cancellationSource);

                ActivePartitionProcessors.AddOrUpdate(partitionId, processor, (key, value) => processor);
                cancellationSource = null;

                return true;
            }
            catch (Exception ex)
            {
                // The error handler is invoked as a fire-and-forget task; the processor does not assume responsibility
                // for observing or surfacing exceptions that may occur in the handler.

                _ = InvokeOnProcessingErrorAsync(ex, partition, Resources.OperationClaimOwnership, CancellationToken.None);
                Logger.EventProcessorPartitionProcessingStartError(partitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);

                cancellationSource?.Cancel();
                cancellationSource?.Dispose();
                return false;
            }
            finally
            {
                Logger.EventProcessorPartitionProcessingStartComplete(partitionId, Identifier, EventHubName, ConsumerGroup);
            }
        }

        /// <summary>
        ///   Stops processing the requested partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing should be stopped.</param>
        /// <param name="reason">The reason why the processing is being stopped.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        ///   Exceptions encountered when stopping processing for an owned partition will be logged and will result in the error handler
        ///   being invoked.  They will not be surfaced to callers.  This is intended to be a safe operation consumed
        ///   as part of the load balancing cycle, which is failure-tolerant.
        /// </remarks>
        ///
        private Task StopProcessingPartitionAsync(string partitionId,
                                                  ProcessingStoppedReason reason,
                                                  CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var partition = default(TPartition);
            var stopWatch = Stopwatch.StartNew();

            try
            {
                // If the partition processor is not being tracked, then there is no
                // further work to be done.

                if (!ActivePartitionProcessors.TryGetValue(partitionId, out var partitionProcessor))
                {
                    return Task.CompletedTask;
                }

                // If a cleanup task has already been registered, the processing task was updated and awaiting
                // that will ensure stopping is complete.

                if (partitionProcessor.CleanupRegistered)
                {
                    return partitionProcessor.ProcessingTask;
                }

                // Attempt to stop the processor; any exceptions should be treated as a problem with processing, not
                // associated with the attempt to stop.

                Logger.EventProcessorPartitionProcessingStop(partitionId, Identifier, EventHubName, ConsumerGroup);
                partition = partitionProcessor.Partition;

                // To ensure that callers do not have to wait until the processing task has fully stopped,
                // schedule an explicit continuation for the task.  This allows the cleanup to happen in the
                // background, if desired, and be awaited via the partition processor task at a later time.

                var stopContinuation = partitionProcessor.ProcessingTask.ContinueWith(async (task, state) =>
                {
                    var innerPartition = default(TPartition);
                    var (innerId, innerReason, innerWatch) = ((string, ProcessingStoppedReason, Stopwatch))state;

                    try
                    {
                        // Await the processing task to ensure that any in-flight event processing
                        // has completed.

                        try
                        {
                            await task.ConfigureAwait(false);
                        }
                        catch (TaskCanceledException)
                        {
                            // This is expected; no action is needed.
                        }
                        catch
                        {
                            // The processing task is in a failed state; any logging and dispatching
                            // to the error handler happened in the processing task before the exception
                            // was thrown.  All that remains is to override the reason for stopping.

                            innerReason = ProcessingStoppedReason.OwnershipLost;
                        }

                        // There is no longer a need for the processing task; dispose it.

                        task.Dispose();

                        innerPartition = ActivePartitionProcessors.TryGetValue(innerId, out var innerProcessor) switch
                        {
                            true => innerProcessor.Partition,
                            _ => new TPartition { PartitionId = innerId }
                        };

                        // Notify the handler of the now-closed partition, awaiting completion to allow for a more deterministic model
                        // for developers where the initialize and stop handlers will fire in a deterministic order and not interleave.
                        //
                        // Because the processor does not assume responsibility for observing or surfacing exceptions that may occur in the handler,
                        // errors are logged but the error handler is not invoked nor does an exception in the handler constitute a failure to stop
                        // processing the partition.  This also aims to prevent an infinite loop scenario where StopProcessing is called from the
                        // error handler, which calls the partition stopped handler, which has an exception that again calls the error handler.

                        try
                        {
                            await OnPartitionProcessingStoppedAsync(innerPartition, innerReason, cancellationToken).ConfigureAwait(false);
                        }
                        catch (TaskCanceledException)
                        {
                            // This is expected; no action is needed.
                        }
                        catch (Exception ex)
                        {
                            // This is an error in handler code and does not get surfaced to the error handler.

                            Logger.EventProcessorPartitionProcessingStopError(innerId, Identifier, EventHubName, ConsumerGroup, ex.Message);
                        }
                    }
                    catch (Exception ex) when (ex.IsNotType<TaskCanceledException>())
                    {
                        // The error handler is invoked as a fire-and-forget task; the processor does not assume responsibility
                        // for observing or surfacing exceptions that may occur in the handler.

                        _ = InvokeOnProcessingErrorAsync(ex, innerPartition, Resources.OperationSurrenderOwnership, CancellationToken.None);
                        Logger.EventProcessorPartitionProcessingStopError(innerId, Identifier, EventHubName, ConsumerGroup, ex.Message);
                    }
                    finally
                    {
                        innerWatch.Stop();
                        Logger.EventProcessorPartitionProcessingStopComplete(innerId, Identifier, EventHubName, ConsumerGroup, innerWatch.Elapsed.TotalSeconds);
                    }

                    // If the partition processor is still being tracked, dispose it and remove it from the
                    // tracking items.  This is done last to ensure that any interested observers can await
                    // the cleanup if desired.

                    if (ActivePartitionProcessors.TryRemove(innerId, out var disposeProcessor))
                    {
                        disposeProcessor.Dispose();
                    }
                }, (partitionId, reason, stopWatch), default, TaskContinuationOptions.RunContinuationsAsynchronously, TaskScheduler.Default);

                // Set the processing task to the continuation, which allows it to be awaited when the processor is
                // stopping or otherwise needs to be ensure completion.

                partitionProcessor.RegisterCleanupTask(stopContinuation);

                // If developer code in a handler registered a callback for cancellation, it is possible that
                // the attempt to cancel will throw.  Capture this as a warning and do not prevent the partition processing
                // task from being cleaned up.

                try
                {
                    partitionProcessor.CancellationSource.Cancel();
                }
                catch (Exception ex)
                {
                    Logger.PartitionProcessorStoppingCancellationWarning(partitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);
                }

                return stopContinuation;
            }
            catch (Exception ex) when (ex.IsNotType<TaskCanceledException>())
            {
                // The error handler is invoked as a fire-and-forget task; the processor does not assume responsibility
                // for observing or surfacing exceptions that may occur in the handler.

                _ = InvokeOnProcessingErrorAsync(ex, partition, Resources.OperationSurrenderOwnership, CancellationToken.None);
                Logger.EventProcessorPartitionProcessingStopError(partitionId, Identifier, EventHubName, ConsumerGroup, ex.Message);

                return Task.CompletedTask;
            }
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
                                                  CancellationToken cancellationToken) => Task.Run(() => OnProcessingErrorAsync(exception, partition, operationDescription, cancellationToken), CancellationToken.None);

        /// <summary>
        ///   Performs the actions needed to validate the connection to the requested
        ///   Event Hub.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the validation.</param>
        ///
        private async Task ValidateEventHubsConnectionAsync(CancellationToken cancellationToken = default)
        {
            // Validate that the Event Hubs connection is valid by querying properties of the Event Hub.
            // This is core functionality for the processor to discover partitions and validates read access.

            var connection = CreateConnection();
            await using var connectionAwaiter = connection.ConfigureAwait(false);

            var properties = await connection.GetPropertiesAsync(RetryPolicy, cancellationToken).ConfigureAwait(false);
            var partitionIndex = new Random().Next(0, (properties.PartitionIds.Length - 1));

            // To ensure validity of the requested consumer group and that at least one partition exists,
            // attempt to read from a partition.

            var consumer = CreateConsumer(ConsumerGroup, properties.PartitionIds[partitionIndex], $"SV-{ Identifier }", EventPosition.Earliest, connection, Options, false);

            try
            {
                await consumer.ReceiveAsync(1, TimeSpan.FromMilliseconds(5), cancellationToken).ConfigureAwait(false);
            }
            catch (EventHubsException ex)
                when ((ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
                    || (ex.Reason == EventHubsException.FailureReason.QuotaExceeded))
            {
                // This is expected when another processor is already running; no action is needed, as it
                // validates that the reader was able to connect.
            }
            finally
            {
                await consumer.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///   Performs the actions needed to validate the connection to the storage
        ///   provider for checkpoints and ownership.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the validation.</param>
        ///
        private async Task ValidateStorageConnectionAsync(CancellationToken cancellationToken)
        {
            // Because the processor does not have knowledge of what storage implementation is in use,
            // it cannot perform any specific in-depth validations.  Use the standard checkpoint query
            // for an invalid partition; this should ensure that the basic storage connection can be made
            // and that a read operation is valid.

            await GetCheckpointAsync("-1", cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Creates a <see cref="CheckpointStore" /> to use for interacting with persistence for checkpoints and ownership.
        /// </summary>
        ///
        /// <param name="instance">The <see cref="EventProcessor{TPartition}" /> instance to associate with the checkpoint store.</param>
        ///
        /// <returns>A <see cref="CheckpointStore" /> with the requested configuration.</returns>
        ///
        internal static CheckpointStore CreateCheckpointStore(EventProcessor<TPartition> instance) => new DelegatingCheckpointStore(instance);

        /// <summary>
        ///   Calculates the maximum number of partitions that it is advised this processor
        ///   own, based on the host environment and some general heuristics.
        /// </summary>
        ///
        /// <returns>The maximum number of partitions that it is advised this processor own.</returns>
        ///
        /// <remarks>
        ///   The safe number of partitions owned will vary quite a bit by application logic, event structure, and the
        ///   host environment.  This is a general approximation based on support issues observed since the initial
        ///   processor release.
        /// </remarks>
        ///
        private static int CalculateMaximumAdvisedOwnedPartitions() => (Environment.ProcessorCount * 2);

        /// <summary>
        ///   The set of information needed to track and manage the active processing
        ///   of a partition.
        /// </summary>
        ///
        internal class PartitionProcessor : IDisposable
        {
            /// <summary>The partition that is being processed.</summary>
            public readonly TPartition Partition;

            /// <summary>The source token that can be used to cancel the processing for the associated <see cref="ProcessingTask" />.</summary>
            public readonly CancellationTokenSource CancellationSource;

            /// <summary>A function that can be used to read the information about the last enqueued event of the partition.</summary>
            public readonly Func<LastEnqueuedEventProperties> ReadLastEnqueuedEventProperties;

            /// <summary>
            ///   Gets a value indicating whether a cleanup task has been registered.
            /// </summary>
            ///
            /// <value> <c>true</c> if a cleanup task was registered; otherwise, <c>false</c>.</value>
            ///
            public bool CleanupRegistered { get; private set; }

            /// <summary>
            ///   The task that is performing the processing.
            /// </summary>
            ///
            public Task ProcessingTask { get; private set; }

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

            /// <summary>
            ///   Updates the processing task instance with a task responsible for cleaning
            ///   up the processor.  This is useful when adding an explicit continuation that
            ///   will later be awaited to ensure cleanup, such as when stopping processing.
            /// </summary>
            ///
            /// <param name="task">The new task to use as the <see cref="ProcessingTask"/>.</param>
            ///
            public void RegisterCleanupTask(Task task)
            {
                ProcessingTask = task;
                CleanupRegistered = true;
            }

            /// <summary>
            ///   Performs tasks needed to clean-up the disposable resources used by the processor.  This method does
            ///   not assume responsibility for signaling the cancellation source or awaiting the <see cref="ProcessingTask" />.
            /// </summary>
            ///
            public void Dispose()
            {
                CancellationSource?.Dispose();

                // If there is a processing task and it is already completed,
                // dispose it.  Generally, disposal of the partition processor takes
                // place inside of this task and disposal will cause an error.
                //
                // Per the Task documentation, this pattern is safe.  Further discussion
                // can be found in Stephen Toub's write-up "Do I need to dispose of tasks?"
                //
                // https://learn.microsoft.com/dotnet/api/system.threading.tasks.task.dispose
                // https://devblogs.microsoft.com/pfxteam/do-i-need-to-dispose-of-tasks/

                if (ProcessingTask?.IsCompleted == true)
                {
                    ProcessingTask.Dispose();
                }
            }
        }

        /// <summary>
        ///   A virtual <see cref="CheckpointStore" /> instance that delegates calls to the
        ///   <see cref="EventProcessor{TPartition}" /> to which it is associated.
        /// </summary>
        ///
        private class DelegatingCheckpointStore : CheckpointStore
        {
            /// <summary>
            ///   The <see cref="EventProcessor{TPartition}" /> that the storage manager is associated with.
            /// </summary>
            ///
            private EventProcessor<TPartition> Processor { get; }

            /// <summary>
            ///   Initializes a new instance of the <see cref="DelegatingCheckpointStore"/> class.
            /// </summary>
            ///
            /// <param name="processor">The <see cref="EventProcessor{TPartition}" /> to associate the storage manager with.</param>
            ///
            public DelegatingCheckpointStore(EventProcessor<TPartition> processor) => Processor = processor;

            /// <summary>
            ///   Requests a list of the ownership assignments for partitions between each of the cooperating event processor
            ///   instances for a given Event Hub and consumer group pairing.  This operation is used during load balancing to allow
            ///   the processor to discover other active collaborators and to make decisions about how to best balance work
            ///   between them.
            /// </summary>
            ///
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
            /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
            ///
            /// <returns>The set of ownership data to take into account when making load balancing decisions.</returns>
            ///
            public async override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(string fullyQualifiedNamespace,
                                                                                                         string eventHubName,
                                                                                                         string consumerGroup,
                                                                                                         CancellationToken cancellationToken) => await Processor.ListOwnershipAsync(cancellationToken).ConfigureAwait(false);
            /// <summary>
            ///   Attempts to claim ownership of the specified partitions for processing.  This operation is used by
            ///   load balancing to enable distributing the responsibility for processing partitions for an
            ///   Event Hub and consumer group pairing amongst the active event processors.
            /// </summary>
            ///
            /// <param name="desiredOwnership">The set of partition ownership desired by the event processor instance; this is the set of partitions that it will attempt to request responsibility for processing.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
            ///
            /// <returns>The set of ownership records for the partitions that were successfully claimed; this is expected to be the <paramref name="desiredOwnership"/> or a subset of those partitions.</returns>
            ///
            public async override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
                                                                                                          CancellationToken cancellationToken) => await Processor.ClaimOwnershipAsync(desiredOwnership, cancellationToken).ConfigureAwait(false);

            /// <summary>
            ///   Requests checkpoint information for a specific partition, allowing an event processor to resume reading
            ///   from the next event in the stream.
            /// </summary>
            ///
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
            /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
            /// <param name="partitionId">The identifier of the partition to read a checkpoint for.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
            ///
            /// <returns>An <see cref="EventProcessorCheckpoint"/> instance, if a checkpoint was found for the requested partition; otherwise, <c>null</c>.</returns>
            ///
            public async override Task<EventProcessorCheckpoint> GetCheckpointAsync(string fullyQualifiedNamespace,
                                                                                    string eventHubName,
                                                                                    string consumerGroup,
                                                                                    string partitionId,
                                                                                    CancellationToken cancellationToken) => await Processor.GetCheckpointAsync(partitionId, cancellationToken).ConfigureAwait(false);

            /// <summary>
            ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
            ///   that an event processor should begin reading from.
            /// </summary>
            ///
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
            /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
            /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
            /// <param name="clientIdentifier">The unique identifier of the client that authored this checkpoint.</param>
            /// <param name="startingPosition">The starting position to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
            /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
            ///
            public async override Task UpdateCheckpointAsync(string fullyQualifiedNamespace,
                                                             string eventHubName,
                                                             string consumerGroup,
                                                             string partitionId,
                                                             string clientIdentifier,
                                                             CheckpointPosition startingPosition,
                                                             CancellationToken cancellationToken) => await Processor.UpdateCheckpointAsync(partitionId, startingPosition, cancellationToken).ConfigureAwait(false);
        }
    }
}
