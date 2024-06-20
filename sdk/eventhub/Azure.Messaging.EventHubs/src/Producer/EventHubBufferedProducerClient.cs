// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   A client responsible for publishing instances of <see cref="EventData"/> to a specific
    ///   Event Hub.  Depending on the options specified when events are enqueued, they may be
    ///   automatically assigned to a partition, grouped according to the specified partition
    ///   key, or assigned a specifically requested partition.
    ///
    ///   The <see cref="EventHubBufferedProducerClient" /> does not publish immediately, instead using
    ///   a deferred model where events are collected into a buffer so that they may be efficiently batched
    ///   and published when the batch is full or the <see cref="EventHubBufferedProducerClientOptions.MaximumWaitTime" />
    ///   has elapsed with no new events enqueued.
    ///
    ///   This model is intended to shift the burden of batch management from callers, at the cost of non-deterministic
    ///   timing, for when events will be published. There are additional trade-offs to consider, as well:
    ///   <list type="bullet">
    ///     <item><description>If the application crashes, events in the buffer will not have been published.  To prevent data loss, callers are encouraged to track publishing progress using the <see cref="SendEventBatchSucceededAsync" /> and <see cref="SendEventBatchFailedAsync" /> handlers.</description></item>
    ///     <item><description>Events specifying a partition key may be assigned a different partition than those using the same key with other producers.</description></item>
    ///     <item><description>In the unlikely event that a partition becomes temporarily unavailable, the <see cref="EventHubBufferedProducerClient" /> may take longer to recover than other producers.</description></item>
    ///   </list>
    ///
    ///   In scenarios where it is important to have events published immediately with a deterministic outcome, ensure
    ///   that partition keys are assigned to a partition consistent with other publishers, or where maximizing availability
    ///   is a requirement, using the <see cref="EventHubProducerClient" /> is recommended.
    /// </summary>
    ///
    /// <remarks>
    ///   The <see cref="EventHubBufferedProducerClient"/> is safe to cache and use as a singleton for the lifetime of an
    ///   application, which is the recommended approach.  The producer is responsible for ensuring efficient network,
    ///   CPU, and memory use. Calling either <see cref="CloseAsync(bool, CancellationToken)"/> or <see cref="DisposeAsync"/>
    ///   when no more events will be enqueued or as the application is shutting down is required so that the buffer can be flushed
    ///   and resources cleaned up properly.
    /// </remarks>
    ///
    /// <seealso cref="EventHubProducerClient" />
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    ///
    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "Event Hubs are AMQP-based services and don't use ClientOptions functionality")]
    public class EventHubBufferedProducerClient : IAsyncDisposable
    {
        /// <summary>The maximum amount of time, in milliseconds, to allow for acquiring the semaphore guarding a partition's publishing eligibility.</summary>
        private const int PartitionPublishingGuardAcquireLimitMilliseconds = 100;

        /// <summary>The base interval to delay when publishing is throttled and an operation needs to back-off before retrying.  Four seconds is recommended by the service.</summary>
        private static readonly TimeSpan ThrottleBackoffInterval = TimeSpan.FromSeconds(4);

        /// <summary>The minimum interval to allow for waiting when building a batch to publish.</summary>
        private static readonly TimeSpan MinimumPublishingWaitInterval = TimeSpan.FromMilliseconds(5);

        /// <summary>The default interval to delay for events to be available when building a batch to publish.</summary>
        private static readonly TimeSpan PublishingDelayInterval = TimeSpan.FromMilliseconds(100);

        /// <summary>The set of client options to use when options were not passed when the producer was instantiated.</summary>
        private static readonly EventHubBufferedProducerClientOptions DefaultOptions = new();

        /// <summary>The random number generator to use for a specific thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The set of currently active partition publishing tasks.  Partition identifiers are used as keys.</summary>
        private readonly ConcurrentDictionary<string, PartitionPublishingState> _activePartitionStateMap = new();

        /// <summary>The set of options to use with the <see cref="EventHubBufferedProducerClient" /> instance.</summary>
        private readonly EventHubBufferedProducerClientOptions _options;

        /// <summary>The primitive for synchronizing access when class-wide state is changing.</summary>
        [SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "The AvailableWaitHandle property is not accessed; resources requiring dispose will not have been allocated.")]
        private readonly SemaphoreSlim _stateGuard = new SemaphoreSlim(1, 1);

        /// <summary>The producer to use to send events to the Event Hub.</summary>
        [SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "It is being disposed via delegation to CloseAsync.")]
        private readonly EventHubProducerClient _producer;

        /// <summary>A <see cref="CancellationTokenSource"/> instance to signal the request to cancel the background tasks responsible for publishing and management after any in-process batches are complete.</summary>
        [SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "It is being disposed via delegation to StopPublishingAsync, which is called by CloseAsync.")]
        private CancellationTokenSource _backgroundTasksCancellationSource;

        /// <summary>A <see cref="CancellationTokenSource"/> instance to signal that any active publishing operations, including those in-flight, should terminate immediately.</summary>
        private CancellationTokenSource _activeSendOperationsCancellationSource;

        /// <summary>A completion source that be awaited when publishing would like to pause and wait for an event to be enqueued.</summary>
        private TaskCompletionSource<bool> _eventEnqueuedCompletionSource;

        /// <summary>The task responsible for managing the operations of the producer when it is running.</summary>
        private Task _producerManagementTask;

        /// <summary>The task responsible for publishing events.</summary>
        private Task _publishingTask;

        /// <summary>The set of partitions identifiers for the configured Event Hub, intended to be used for partition assignment.</summary>
        private string[] _partitions;

        /// <summary>A hash representing the set of partitions identifiers for the configured Event Hub, intended to be used for partition validation.</summary>
        private HashSet<string> _partitionHash;

        /// <summary>The count of total events that have been buffered across all partitions.</summary>
        private int _totalBufferedEventCount;

        /// <summary>The handler to be called once a batch has successfully published.</summary>
        private Func<SendEventBatchSucceededEventArgs, Task> _sendSucceededHandler;

        /// <summary>The handler to be called once a batch has failed to publish.</summary>
        private Func<SendEventBatchFailedEventArgs, Task> _sendFailedHandler;

        /// <summary>Indicates whether or not registration for handlers is locked; if so, no changes are permitted.</summary>
        private volatile bool _areHandlersLocked;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _isClosed;

        /// <summary>The client diagnostics instance used to instrument events when enqueueing.</summary>
        private readonly MessagingClientDiagnostics _clientDiagnostics;

        /// <summary>
        ///   The fully qualified Event Hubs namespace that this producer is currently associated with, which will likely be similar
        ///   to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => _producer.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Event Hub that this producer is connected to, specific to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName => _producer.EventHubName;

        /// <summary>
        ///   A unique name to identify the buffered producer.
        /// </summary>
        ///
        public string Identifier => _producer.Identifier;

        /// <summary>
        ///   Indicates whether or not this <see cref="EventHubBufferedProducerClient" /> is currently
        ///   active and publishing queued events.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is publishing; otherwise, <c>false</c>.
        /// </value>
        ///
        /// <remarks>
        ///   The producer will begin publishing when an event is enqueued and should remain active until
        ///   either <see cref="CloseAsync" /> or <see cref="DisposeAsync" /> is called.
        ///
        ///   If any events were enqueued, <see cref="IsClosed" /> is <c>false</c>, and <see cref="IsPublishing" />
        ///   is <c>false</c>, this likely indicates an unrecoverable state for the client.  It is recommended to
        ///   close the <see cref="EventHubBufferedProducerClient" /> and create a new instance.
        ///
        ///   In this state, exceptions will be reported by the Event Hubs client library logs, which can be captured
        ///   using the <see cref="Azure.Core.Diagnostics.AzureEventSourceListener" />.
        /// </remarks>
        ///
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample10_AzureEventSourceListener.md">Capturing Event Hubs logs</seealso>
        ///
        public virtual bool IsPublishing => _producerManagementTask != null;

        /// <summary>
        ///   Indicates whether or not this <see cref="EventHubBufferedProducerClient" /> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public virtual bool IsClosed
        {
            get => _isClosed;
            internal set => _isClosed = value;
        }

        /// <summary>
        ///   The total number of events that are currently buffered and waiting to be published, across all partitions.
        /// </summary>
        ///
        public virtual int TotalBufferedEventCount => _totalBufferedEventCount;

        /// <summary>
        ///   The instance of <see cref="EventHubsEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        /// <remarks>
        ///   This member is exposed internally to support testing only; it is not intended
        ///   for other use.
        /// </remarks>
        ///
        internal EventHubsEventSource Logger { get; set; } = EventHubsEventSource.Log;

        /// <summary>
        ///     The resolver to use for assigning partitions for automatic routing and partition keys.
        ///  </summary>
        ///
        /// <remarks>
        ///   This member is exposed internally to support testing only; it is not intended
        ///   for other use.
        /// </remarks>
        ///
        internal PartitionResolver PartitionResolver { get; set; } = new();

        /// <summary>
        ///   The interval at which the background management operations should run.
        /// </summary>
        ///
        /// <remarks>
        ///   This member is exposed internally to support testing only; it is not intended
        ///   for other use.
        /// </remarks>
        ///
        internal TimeSpan BackgroundManagementInterval { get; set; } = TimeSpan.FromSeconds(10);

        /// <summary>
        ///   The set of state for the partitions which are actively being published to.  Partition identifiers are used as keys.
        /// </summary>
        ///
        /// <remarks>
        ///   This member is exposed internally to support testing only; it is not intended
        ///   for other use.
        /// </remarks>
        ///
        internal ConcurrentDictionary<string, PartitionPublishingState> ActivePartitionStateMap => _activePartitionStateMap;

        /// <summary>
        ///   Invoked after each batch of events has been successfully published to the Event Hub, this handler is optional
        ///   and is intended to provide notifications for interested listeners.  If this producer was configured with
        ///   <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSends" /> or <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSendsPerPartition" />
        ///   set greater than 1, the handler will be invoked concurrently.
        ///
        ///   This handler will be awaited after publishing the batch; the publishing operation will not be considered complete until the handler
        ///   call returns.  It is advised that no long-running operations be performed in the handler to avoid negatively impacting throughput.
        ///
        ///   It is not recommended to invoke <see cref="CloseAsync" /> or <see cref="DisposeAsync" /> from this handler; doing so may result
        ///   in a deadlock scenario if those calls are awaited.
        /// </summary>
        ///
        /// <remarks>
        ///   It is not necessary to explicitly unregister this handler; it will be automatically unregistered when
        ///   <see cref="CloseAsync" /> or <see cref="DisposeAsync" /> is invoked.
        /// </remarks>
        ///
        /// <exception cref="ArgumentException">If an attempt is made to remove a handler that doesn't match the current handler registered.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add or remove a handler while the processor is running.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add a handler when one is currently registered.</exception>
        ///
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<SendEventBatchSucceededEventArgs, Task> SendEventBatchSucceededAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(SendEventBatchSucceededAsync));

                if (_sendSucceededHandler != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                if (_areHandlersLocked)
                {
                    throw new InvalidOperationException(Resources.CannotChangeHandlersWhenPublishing);
                }

                _sendSucceededHandler = value;
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(SendEventBatchSucceededAsync));

                if (_sendSucceededHandler != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                if (_areHandlersLocked)
                {
                    throw new InvalidOperationException(Resources.CannotChangeHandlersWhenPublishing);
                }

                _sendSucceededHandler = default;
            }
        }

        /// <summary>
        ///   Invoked for any batch of events that failed to be published to the Event Hub, this handler must be
        ///   provided before events may be enqueued.  If this producer was not configured with <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSends" />
        ///   and <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSendsPerPartition" /> both set to 1, the handler will be invoked
        ///   concurrently.
        ///
        ///   It is safe to attempt resending the events by calling <see cref="EnqueueEventAsync(EventData, EnqueueEventOptions, CancellationToken)" /> or
        ///   <see cref="EnqueueEventsAsync(IEnumerable{EventData}, EnqueueEventOptions, CancellationToken)" /> from within this handler.  It is important
        ///   to note that doing so will place them at the end of the buffer; the original order will not be maintained.
        ///
        ///   This handler will be awaited after failure to publish the batch; the publishing operation is not considered complete until the
        ///   handler call returns.  It is advised that no long-running operations be performed in the handler to avoid negatively impacting throughput.
        ///
        ///   It is not recommended to invoke <see cref="CloseAsync" /> or <see cref="DisposeAsync" /> from this handler; doing so may result
        ///   in a deadlock scenario if those calls are awaited.
        /// </summary>
        ///
        /// <remarks>
        ///   Should a transient failure occur during publishing, this handler will not be invoked immediately; it is only
        ///   invoked after applying the retry policy and all eligible retries have been exhausted.  Should publishing succeed
        ///   during a retry attempt, this handler is not invoked.
        ///
        ///   Since applications do not have deterministic control over failed batches, it is recommended that the application
        ///   set a generous number of retries and try timeout interval in the <see cref="EventHubProducerClientOptions.RetryOptions"/>.
        ///   Doing so will allow the <see cref="EventHubBufferedProducerClient" /> a higher chance to recover from transient failures.  This is
        ///   especially important when ensuring the order of events is needed.
        ///
        ///   It is not necessary to explicitly unregister this handler; it will be automatically unregistered when
        ///   <see cref="CloseAsync" /> or <see cref="DisposeAsync" /> is invoked.
        /// </remarks>
        ///
        /// <exception cref="ArgumentException">If an attempt is made to remove a handler that doesn't match the current handler registered.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add or remove a handler while the processor is running.</exception>
        /// <exception cref="NotSupportedException">If an attempt is made to add a handler when one is currently registered.</exception>
        ///
        /// <seealso cref="EventHubsRetryOptions" />
        ///
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<SendEventBatchFailedEventArgs, Task> SendEventBatchFailedAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(SendEventBatchFailedAsync));

                if (_sendFailedHandler != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                if (_areHandlersLocked)
                {
                    throw new InvalidOperationException(Resources.CannotChangeHandlersWhenPublishing);
                }

                _sendFailedHandler = value;
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(SendEventBatchFailedAsync));

                if (_sendFailedHandler != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                if (_areHandlersLocked)
                {
                    throw new InvalidOperationException(Resources.CannotChangeHandlersWhenPublishing);
                }

                _sendFailedHandler = default;
            }
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
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
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventHubBufferedProducerClient(string connectionString) : this(connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="clientOptions">A set of <see cref="EventHubBufferedProducerClientOptions"/> to apply when configuring the buffered producer.</param>
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
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventHubBufferedProducerClient(string connectionString,
                                              EventHubBufferedProducerClientOptions clientOptions) : this(connectionString, null, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventHubBufferedProducerClient(string connectionString,
                                              string eventHubName) : this(connectionString, eventHubName, default)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="clientOptions">A set of <see cref="EventHubBufferedProducerClientOptions"/> to apply when configuring the buffered producer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventHubBufferedProducerClient(string connectionString,
                                              string eventHubName,
                                              EventHubBufferedProducerClientOptions clientOptions) : this(clientOptions)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            _producer = new EventHubProducerClient(connectionString, eventHubName, (clientOptions ?? DefaultOptions).ToEventHubProducerClientOptions());

            _clientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                _producer.FullyQualifiedNamespace,
                _producer.EventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="credential">The shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of <see cref="EventHubBufferedProducerClientOptions"/> to apply when configuring the producer.</param>
        ///
        public EventHubBufferedProducerClient(string fullyQualifiedNamespace,
                                              string eventHubName,
                                              AzureNamedKeyCredential credential,
                                              EventHubBufferedProducerClientOptions clientOptions = default) : this(fullyQualifiedNamespace, eventHubName, (object)credential, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="credential">The shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of <see cref="EventHubBufferedProducerClientOptions"/> to apply when configuring the producer.</param>
        ///
        public EventHubBufferedProducerClient(string fullyQualifiedNamespace,
                                              string eventHubName,
                                              AzureSasCredential credential,
                                              EventHubBufferedProducerClientOptions clientOptions = default) : this(fullyQualifiedNamespace, eventHubName, (object)credential, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="credential">The shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of <see cref="EventHubBufferedProducerClientOptions"/> to apply when configuring the producer.</param>
        ///
        public EventHubBufferedProducerClient(string fullyQualifiedNamespace,
                                              string eventHubName,
                                              TokenCredential credential,
                                              EventHubBufferedProducerClientOptions clientOptions = default) : this(fullyQualifiedNamespace, eventHubName, (object)credential, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="clientOptions">A set of <see cref="EventHubBufferedProducerClientOptions"/> to apply when configuring the producer.</param>
        ///
        public EventHubBufferedProducerClient(EventHubConnection connection,
                                              EventHubBufferedProducerClientOptions clientOptions = default) : this(clientOptions)
        {
            _producer = new EventHubProducerClient(connection, (clientOptions ?? DefaultOptions).ToEventHubProducerClientOptions());

            _clientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                _producer.FullyQualifiedNamespace,
                _producer.EventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="producer">The <see cref="EventHubProducerClient" />  to use for delegating Event Hubs service operations to.</param>
        /// <param name="clientOptions">A set of <see cref="EventHubBufferedProducerClientOptions"/> to apply when configuring the producer.</param>
        ///
        /// <remarks>
        ///   This constructor is intended to be used internally for functional
        ///   testing only.
        /// </remarks>
        ///
        internal EventHubBufferedProducerClient(EventHubProducerClient producer,
                                                EventHubBufferedProducerClientOptions clientOptions = default) : this(clientOptions)
        {
            _producer = producer;
            _clientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                _producer.FullyQualifiedNamespace,
                _producer.EventHubName);
        }

        /// <summary>
        ///   Used for mocking the producer for testing purposes.
        /// </summary>
        ///
        protected EventHubBufferedProducerClient()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="credential">The credential to use for authorization.  This may be of type <see cref="TokenCredential" />, <see cref="AzureSasCredential" />, or <see cref="AzureNamedKeyCredential" />.</param>
        /// <param name="clientOptions">A set of <see cref="EventHubBufferedProducerClientOptions"/> to apply when configuring the producer.</param>
        ///
        private EventHubBufferedProducerClient(string fullyQualifiedNamespace,
                                               string eventHubName,
                                               object credential,
                                               EventHubBufferedProducerClientOptions clientOptions = default) : this(clientOptions)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            var options = (clientOptions ?? DefaultOptions).ToEventHubProducerClientOptions();

            if (Uri.TryCreate(fullyQualifiedNamespace, UriKind.Absolute, out var uri))
            {
                fullyQualifiedNamespace = uri.Host;
            }

            Argument.AssertWellFormedEventHubsNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));

            _producer = credential switch
            {
                TokenCredential tokenCred => new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, tokenCred, options),
                AzureSasCredential sasCred => new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, sasCred, options),
                AzureNamedKeyCredential keyCred =>  new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, keyCred, options),
                _ => throw new ArgumentException(Resources.UnsupportedCredential, nameof(credential))
            };

            _clientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.EventHubsServiceContext,
                _producer.FullyQualifiedNamespace,
                _producer.EventHubName);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubBufferedProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="options">>A set of <see cref="EventHubBufferedProducerClientOptions"/> to apply when configuring the producer.</param>
        ///
        private EventHubBufferedProducerClient(EventHubBufferedProducerClientOptions options)
        {
            _options = options?.Clone() ?? DefaultOptions;
        }

        /// <summary>
        ///   The number of events that are buffered and waiting to be published for a given partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition.</param>
        ///
        public virtual int GetBufferedEventCount(string partitionId)
        {
            Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            if (_activePartitionStateMap.TryGetValue(partitionId, out var publisher))
            {
                return publisher.BufferedEventCount;
            }

            return 0;
        }

        /// <summary>
        ///   Retrieves information about the Event Hub that the connection is associated with, including
        ///   the number of partitions present and their identifiers.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the Event Hub that this client is associated with.</returns>
        ///
        public virtual async Task<EventHubProperties> GetEventHubPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));
            return await _producer.GetEventHubPropertiesAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Retrieves the set of identifiers for the partitions of an Event Hub.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of identifiers for the partitions within the Event Hub that this client is associated with.</returns>
        ///
        /// <remarks>
        ///   This method is synonymous with invoking <see cref="GetEventHubPropertiesAsync(CancellationToken)" /> and reading the <see cref="EventHubProperties.PartitionIds" />
        ///   property that is returned. It is offered as a convenience for quick access to the set of partition identifiers for the associated Event Hub.
        ///   No new or extended information is presented.
        /// </remarks>
        ///
        public virtual async Task<string[]> GetPartitionIdsAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));
            return await _producer.GetPartitionIdsAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Retrieves information about a specific partition for an Event Hub, including elements that describe the available
        ///   events in the partition event stream.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the requested partition under the Event Hub this client is associated with.</returns>
        ///
        public virtual async Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                   CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));
            return await _producer.GetPartitionPropertiesAsync(partitionId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Enqueues an <see cref="EventData"/> into the buffer to be published to the Event Hub.  If there is no capacity in
        ///   the buffer when this method is invoked, it will wait for space to become available and ensure that the <paramref name="eventData"/>
        ///   has been enqueued.
        ///
        ///   When this call returns, the <paramref name="eventData" /> has been accepted into the buffer, but it may not have been published yet.
        ///   Publishing will take place at a nondeterministic point in the future as the buffer is processed.
        /// </summary>
        ///
        /// <param name="eventData">The event to be enqueued into the buffer and, later, published.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The total number of events that are currently buffered and waiting to be published, across all partitions.</returns>
        ///
        /// <exception cref="InvalidOperationException">Occurs when no <see cref="SendEventBatchFailedAsync" /> handler is currently registered.</exception>
        /// <exception cref="EventHubsException">Occurs when querying Event Hub metadata took longer than expected.</exception>
        ///
        /// <remarks>
        ///   Upon the first attempt to enqueue an event, the <see cref="SendEventBatchSucceededAsync" /> and <see cref="SendEventBatchFailedAsync" /> handlers
        ///   can no longer be changed.
        /// </remarks>
        ///
        public virtual Task<int> EnqueueEventAsync(EventData eventData,
                                                   CancellationToken cancellationToken = default) => EnqueueEventAsync(eventData, default, cancellationToken);

        /// <summary>
        ///   Enqueues an <see cref="EventData"/> into the buffer to be published to the Event Hub.  If there is no capacity in
        ///   the buffer when this method is invoked, it will wait for space to become available and ensure that the <paramref name="eventData"/>
        ///   has been enqueued.
        ///
        ///   When this call returns, the <paramref name="eventData" /> has been accepted into the buffer, but it may not have been published yet.
        ///   Publishing will take place at a nondeterministic point in the future as the buffer is processed.
        /// </summary>
        ///
        /// <param name="eventData">The event to be enqueued into the buffer and, later, published.</param>
        /// <param name="options">The set of options to apply when publishing this event.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The total number of events that are currently buffered and waiting to be published, across all partitions.</returns>
        ///
        /// <exception cref="InvalidOperationException">Occurs when no <see cref="SendEventBatchFailedAsync" /> handler is currently registered.</exception>
        /// <exception cref="InvalidOperationException">Occurs when both a partition identifier and partition key have been specified in the <paramref name="options"/>.</exception>
        /// <exception cref="InvalidOperationException">Occurs when an invalid partition identifier has been specified in the <paramref name="options"/>.</exception>
        /// <exception cref="EventHubsException">Occurs when querying Event Hub metadata took longer than expected.</exception>
        ///
        /// <remarks>
        ///   Upon the first attempt to enqueue an event, the <see cref="SendEventBatchSucceededAsync" /> and <see cref="SendEventBatchFailedAsync" /> handlers
        ///   can no longer be changed.
        /// </remarks>
        ///
        public virtual async Task<int> EnqueueEventAsync(EventData eventData,
                                                         EnqueueEventOptions options,
                                                         CancellationToken cancellationToken = default)
        {
            (var partitionId, var partitionKey) = EnqueueEventOptions.DeconstructOrUseDefaultAttributes(options);

            Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));
            Argument.AssertNotNull(eventData, nameof(eventData));
            AssertSinglePartitionReference(partitionId, partitionKey);
            AssertRequiredHandlerSetForEnqueue(_sendFailedHandler, nameof(SendEventBatchFailedAsync));

            _areHandlersLocked = true;
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var logPartition = partitionKey ?? partitionId ?? string.Empty;
            var operationId = GenerateOperationId();

            Logger.BufferedProducerEventEnqueueStart(Identifier, EventHubName, logPartition, operationId);

            try
            {
                // If publishing has not been started or is not healthy, attempt to restart it.

                if ((!IsPublishing) || (_producerManagementTask?.IsCompleted ?? false))
                {
                    try
                    {
                        if (!_stateGuard.Wait(0, cancellationToken))
                        {
                            await _stateGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                        }

                        Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));

                        // StartPublishingAsync will verify that publishing is not already taking
                        // place and act appropriately if nothing needs to be restarted; there's no need
                        // to perform a double-check of the conditions here after acquiring the semaphore.

                        // If this call takes too long to complete, an EventHubsException will be thrown.

                        await StartPublishingAsync(cancellationToken).ConfigureAwait(false);
                    }
                    finally
                    {
                        if (_stateGuard.CurrentCount == 0)
                        {
                            _stateGuard.Release();
                        }
                    }
                }

                // If there was a partition identifier requested, validate that it is part of
                // the known set, now that publishing has been started.

                if (!string.IsNullOrEmpty(partitionId))
                {
                    AssertValidPartition(partitionId, _partitionHash);
                }

                // If there was a partition key requested, calculate the assigned partition and
                // annotate the event so that it is preserved by the Event Hubs broker.

                if (!string.IsNullOrEmpty(partitionKey))
                {
                    partitionId = PartitionResolver.AssignForPartitionKey(partitionKey, _partitions);
                    eventData.GetRawAmqpMessage().SetPartitionKey(partitionKey);
                }

                // If no partition was assigned, assign one for automatic routing.

                if (string.IsNullOrEmpty(partitionId))
                {
                    partitionId = PartitionResolver.AssignRoundRobin(_partitions);
                }

                // Enqueue the event into the channel for the assigned partition.  Note that this call will wait
                // if there is no room in the channel and may take some time to complete.

                var partitionState = _activePartitionStateMap.GetOrAdd(partitionId, partitionId => new PartitionPublishingState(partitionId, _options));
                var writer = partitionState.PendingEventsWriter;

                _clientDiagnostics.InstrumentMessage(eventData.Properties, DiagnosticProperty.EventActivityName, out _, out _);
                await writer.WriteAsync(eventData, cancellationToken).ConfigureAwait(false);

                var count = Interlocked.Increment(ref _totalBufferedEventCount);
                Interlocked.Increment(ref partitionState.BufferedEventCount);

                _eventEnqueuedCompletionSource?.TrySetResult(true);
                Logger.BufferedProducerEventEnqueued(Identifier, EventHubName, logPartition, partitionId, operationId, count);
            }
            catch (Exception ex)
            {
                Logger.BufferedProducerEventEnqueueError(Identifier, EventHubName, logPartition, operationId, ex.Message);
                throw;
            }
            finally
            {
                Logger.BufferedProducerEventEnqueueComplete(Identifier, EventHubName, logPartition, operationId);
            }

            return _totalBufferedEventCount;
        }

        /// <summary>
        ///   Enqueues a set of <see cref="EventData"/> into the buffer to be published to the Event Hub.  If there is insufficient capacity in
        ///   the buffer when this method is invoked, it will wait for space to become available and ensure that all <paramref name="events"/>
        ///   in the <paramref name="events"/> set have been enqueued.
        ///
        ///   When this call returns, the <paramref name="events" /> have been accepted into the buffer, but it may not have been published yet.
        ///   Publishing will take place at a nondeterministic point in the future as the buffer is processed.
        /// </summary>
        ///
        /// <param name="events">The set of events to be enqueued into the buffer and, later, published.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The total number of events that are currently buffered and waiting to be published, across all partitions.</returns>
        ///
        /// <exception cref="InvalidOperationException">Occurs when no <see cref="SendEventBatchFailedAsync" /> handler is currently registered.</exception>
        /// <exception cref="EventHubsException">Occurs when querying Event Hub metadata took longer than expected.</exception>
        ///
        /// <remarks>
        ///   Should cancellation or an unexpected exception occur, it is possible for calls to this method to result in a partial failure where some, but not all,
        ///   of the <paramref name="events" /> have enqueued.  For scenarios where it is important to understand whether each individual event has been
        ///   enqueued, it is recommended to call the see <see cref="EnqueueEventAsync(EventData, EnqueueEventOptions, CancellationToken)" /> or
        ///   <see cref="EnqueueEventAsync(EventData, CancellationToken)" /> overloads instead of this method.
        ///
        ///   Upon the first attempt to enqueue events, the <see cref="SendEventBatchSucceededAsync" /> and <see cref="SendEventBatchFailedAsync" /> handlers
        ///   can no longer be changed.
        /// </remarks>
        ///
        public virtual Task<int> EnqueueEventsAsync(IEnumerable<EventData> events,
                                                    CancellationToken cancellationToken = default) => EnqueueEventsAsync(events, default, cancellationToken);

        /// <summary>
        ///   Enqueues a set of <see cref="EventData"/> into the buffer to be published to the Event Hub.  If there is insufficient capacity in
        ///   the buffer when this method is invoked, it will wait for space to become available and ensure that all <paramref name="events"/>
        ///   in the <paramref name="events"/> set have been enqueued.
        ///
        ///   When this call returns, the <paramref name="events"/> have been accepted into the buffer, but it may not have been published yet.
        ///   Publishing will take place at a nondeterministic point in the future as the buffer is processed.
        /// </summary>
        ///
        /// <param name="events">The set of events to be enqueued into the buffer and, later, published.</param>
        /// <param name="options">The set of options to apply when publishing these events.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The total number of events that are currently buffered and waiting to be published, across all partitions.</returns>
        ///
        /// <exception cref="InvalidOperationException">Occurs when no <see cref="SendEventBatchFailedAsync" /> handler is currently registered.</exception>
        /// <exception cref="InvalidOperationException">Occurs when both a partition identifier and partition key have been specified in the <paramref name="options"/>.</exception>
        /// <exception cref="InvalidOperationException">Occurs when an invalid partition identifier has been specified in the <paramref name="options"/>.</exception>
        /// <exception cref="EventHubsException">Occurs when the <see cref="EventHubBufferedProducerClient" /> was unable to start within the configured timeout period.</exception>
        ///
        /// <remarks>
        ///   Should cancellation or an unexpected exception occur, it is possible for calls to this method to result in a partial failure where some, but not all,
        ///   of the <paramref name="events" /> have enqueued.  For scenarios where it is important to understand whether each individual event has been
        ///   enqueued, it is recommended to call the see <see cref="EnqueueEventAsync(EventData, EnqueueEventOptions, CancellationToken)" /> or
        ///   <see cref="EnqueueEventAsync(EventData, CancellationToken)" /> overloads instead of this method.
        ///
        ///   Upon the first attempt to enqueue events, the <see cref="SendEventBatchSucceededAsync" /> and <see cref="SendEventBatchFailedAsync" /> handlers
        ///   can no longer be changed.
        /// </remarks>
        ///
        public virtual async Task<int> EnqueueEventsAsync(IEnumerable<EventData> events,
                                                          EnqueueEventOptions options,
                                                          CancellationToken cancellationToken = default)
        {
            (var partitionId, var partitionKey) = EnqueueEventOptions.DeconstructOrUseDefaultAttributes(options);

            Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));
            Argument.AssertNotNull(events, nameof(events));
            AssertSinglePartitionReference(partitionId, partitionKey);
            AssertRequiredHandlerSetForEnqueue(_sendFailedHandler, nameof(SendEventBatchFailedAsync));

            _areHandlersLocked = true;
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var logPartition = (partitionKey ?? partitionId ?? string.Empty);
            var operationId = GenerateOperationId();

            Logger.BufferedProducerEventEnqueueStart(Identifier, EventHubName, logPartition, operationId);

            try
            {
                // If publishing has not been started or is not healthy, attempt to restart it.

                if ((!IsPublishing) || (_producerManagementTask?.IsCompleted ?? false))
                {
                    try
                    {
                        if (!_stateGuard.Wait(0, cancellationToken))
                        {
                            await _stateGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                        }

                        Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));

                        // StartPublishingAsync will verify that publishing is not already taking
                        // place and act appropriately if nothing needs to be restarted; there's no need
                        // to perform a double-check of the conditions here after acquiring the semaphore.

                        // If this call takes too long to complete, an EventHubsException will be thrown.

                        await StartPublishingAsync(cancellationToken).ConfigureAwait(false);
                    }
                    finally
                    {
                        if (_stateGuard.CurrentCount == 0)
                        {
                            _stateGuard.Release();
                        }
                    }
                }

                // If there was a partition identifier requested, validate that it is part of
                // the known set, now that publishing has been started.

                if (!string.IsNullOrEmpty(partitionId))
                {
                    AssertValidPartition(partitionId, _partitionHash);
                }

                // If there was a partition key requested, calculate the assigned partition.

                if (!string.IsNullOrEmpty(partitionKey))
                {
                    partitionId = PartitionResolver.AssignForPartitionKey(partitionKey, _partitions);
                }

                // If there is a stable partition identifier for all events in the batch, acquire the publisher for it.

                var partitionState = string.IsNullOrEmpty(partitionId)
                    ? null
                    : _activePartitionStateMap.GetOrAdd(partitionId, partitionId => new PartitionPublishingState(partitionId, _options));

                // Enumerate the events and enqueue them.

                foreach (var eventData in events)
                {
                    var eventPartitionId = partitionId;

                    // If there is an associated partition key, annotate the event so that it is
                    // preserved by the Event Hubs broker.

                    if (!string.IsNullOrEmpty(partitionKey))
                    {
                        eventData.GetRawAmqpMessage().SetPartitionKey(partitionKey);
                    }

                    // If no partition was assigned, assign one for automatic routing.

                    if (string.IsNullOrEmpty(eventPartitionId))
                    {
                        eventPartitionId = PartitionResolver.AssignRoundRobin(_partitions);
                    }

                    // Enqueue the event into the channel for the assigned partition.  Note that this call will wait
                    // if there is no room in the channel and may take some time to complete.

                    var activePartitionState = partitionState ?? _activePartitionStateMap.GetOrAdd(eventPartitionId, partitionId => new PartitionPublishingState(eventPartitionId, _options));
                    var writer = activePartitionState.PendingEventsWriter;

                    _clientDiagnostics.InstrumentMessage(eventData.Properties, DiagnosticProperty.EventActivityName, out _, out _);
                    await writer.WriteAsync(eventData, cancellationToken).ConfigureAwait(false);

                    var count = Interlocked.Increment(ref _totalBufferedEventCount);
                    Interlocked.Increment(ref activePartitionState.BufferedEventCount);

                    _eventEnqueuedCompletionSource?.TrySetResult(true);
                    Logger.BufferedProducerEventEnqueued(Identifier, EventHubName, logPartition, eventPartitionId, operationId, count);
                }
            }
            catch (Exception ex)
            {
                Logger.BufferedProducerEventEnqueueError(Identifier, EventHubName, logPartition, operationId, ex.Message);
                throw;
            }
            finally
            {
                Logger.BufferedProducerEventEnqueueComplete(Identifier, EventHubName, logPartition, operationId);
            }

            return _totalBufferedEventCount;
        }

        /// <summary>
        ///   Attempts to publish all events in the buffer immediately.  This may result in multiple batches being published,
        ///   the outcome of each of which will be individually reported by the <see cref="SendEventBatchSucceededAsync" /> and
        ///   <see cref="SendEventBatchFailedAsync" /> handlers.
        ///
        ///   Upon completion of this method, the buffer will be empty.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        public virtual async Task FlushAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));

            if (!_stateGuard.Wait(0, cancellationToken))
            {
                await _stateGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
            }

            try
            {
                Argument.AssertNotClosed(_isClosed, nameof(EventHubBufferedProducerClient));

                // Stop publishing and allow any active send operations to complete before performing the flush.

                await StopPublishingAsync(cancelActiveSendOperations: false, cancellationToken).ConfigureAwait(false);
                await FlushInternalAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                if (_stateGuard.CurrentCount == 0)
                {
                    _stateGuard.Release();
                }
            }
        }

        /// <summary>
        ///   Closes the producer and performs the tasks needed to clean up all the resources used by the <see cref="EventHubBufferedProducerClient"/>.
        /// </summary>
        ///
        /// <param name="flush"><c>true</c> if all buffered events that are pending should be published before closing; <c>false</c> to abandon all events and close immediately.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <remarks>
        ///   This method will automatically unregister the <see cref="SendEventBatchSucceededAsync"/> and <see cref="SendEventBatchFailedAsync"/> handlers.
        /// </remarks>
        ///
        public virtual async Task CloseAsync(bool flush = true,
                                             CancellationToken cancellationToken = default)
        {
            if (_isClosed)
            {
                return;
            }

            var capturedExceptions = default(List<Exception>);

            try
            {
                if (!_stateGuard.Wait(0, cancellationToken))
                {
                    await _stateGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                }

                // If we've reached this point without an exception, the guard is held.

                if (_isClosed)
                {
                    return;
                }

                _isClosed = true;
                Logger.ClientCloseStart(nameof(EventHubBufferedProducerClient), EventHubName, Identifier);

                // Flush or clear the buffered events.  Before doing so, ensure that publishing has been
                // fully stopped.

                try
                {
                    if (flush)
                    {
                        // Publishing should allow any active send operations to complete before performing the flush.

                        await StopPublishingAsync(cancelActiveSendOperations: false, cancellationToken).ConfigureAwait(false);
                        await FlushInternalAsync(CancellationToken.None).ConfigureAwait(false);
                    }
                    else
                    {
                       // Publishing should cancel any active send operations and prioritize the clear.

                       try
                       {
                           await StopPublishingAsync(cancelActiveSendOperations: true, cancellationToken).ConfigureAwait(false);
                       }
                       catch (OperationCanceledException)
                       {
                           // This is expected and should not impact the clear.
                       }

                       ClearInternal(CancellationToken.None);
                    }
                }
                catch (Exception ex)
                {
                    Logger.ClientCloseError(nameof(EventHubBufferedProducerClient), EventHubName, Identifier, ex.Message);
                    (capturedExceptions ??= new List<Exception>()).Add(ex);
                }

                // Close the producer.

                try
                {
                    await _producer.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Logger.ClientCloseError(nameof(EventHubBufferedProducerClient), EventHubName, Identifier, ex.Message);
                    (capturedExceptions ??= new List<Exception>()).Add(ex);
                }

                // Clean up partition state.

                foreach (var pair in _activePartitionStateMap)
                {
                    // Dispose for the partition publishers will log exceptions and
                    // avoid surfacing them, as processing is stopping.

                    try
                    {
                        _activePartitionStateMap.TryRemove(pair.Key, out _);
                        pair.Value.Dispose();
                    }
                    catch (Exception ex)
                    {
                       Logger.ClientCloseError(nameof(EventHubBufferedProducerClient), EventHubName, Identifier, ex.Message);
                       (capturedExceptions ??= new List<Exception>()).Add(ex);
                    }
                }

                _activePartitionStateMap.Clear();

                // Unregister the event handlers.

                _areHandlersLocked = false;

                if (_sendSucceededHandler != null)
                {
                    SendEventBatchSucceededAsync -= _sendSucceededHandler;
                    _sendSucceededHandler = null;
                }

                if (_sendFailedHandler != null)
                {
                    SendEventBatchFailedAsync -= _sendFailedHandler;
                    _sendFailedHandler = null;
                }
            }
            catch (Exception ex)
            {
                Logger.ClientCloseError(nameof(EventHubBufferedProducerClient), EventHubName, Identifier, ex.Message);
                throw;
            }
            finally
            {
                if (_stateGuard.CurrentCount == 0)
                {
                    _stateGuard.Release();
                }

                Logger.ClientCloseComplete(nameof(EventHubBufferedProducerClient), EventHubName, Identifier);
            }

            // Surface any exceptions that were captured during cleanup.

            if (capturedExceptions?.Count == 1)
            {
                ExceptionDispatchInfo.Capture(capturedExceptions[0]).Throw();
            }
            else if (capturedExceptions is not null)
            {
                throw new AggregateException(capturedExceptions);
            };
        }

        /// <summary>
        ///   Closes the producer and performs the tasks needed to clean up all the resources used by the <see cref="EventHubBufferedProducerClient"/>.
        /// </summary>
        ///
        /// <remarks>
        ///   Calling this method will also invoke <see cref="FlushInternalAsync(CancellationToken)"/>, which will attempt to publish any events that are still pending,
        ///   and finish any active sending.  It will also automatically unregister the <see cref="SendEventBatchSucceededAsync"/> and <see cref="SendEventBatchFailedAsync"/>
        ///   handlers.
        ///
        ///   This method is identical to <see cref="CloseAsync(bool, CancellationToken)"/> and either can be used to send pending events and clean up resources.
        /// </remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async ValueTask DisposeAsync()
        {
            await CloseAsync(true).ConfigureAwait(false);
            GC.SuppressFinalize(this);
        }

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
        ///   Abandons all events in the buffer that are waiting to be published.  Upon completion of this method, the buffer will be empty.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        ///   This method will modify class-level state and should be synchronized.  It is assumed that callers hold responsibility for
        ///   ensuring synchronization concerns; this method should be invoked after any primitives have been acquired.
        ///
        ///   Callers are also assumed to own responsibility for stopping all publishing and performing any necessary
        ///   validation of client state before calling.
        /// </remarks>
        ///
        internal virtual void ClearInternal(CancellationToken cancellationToken = default)
        {
            var operationId = GenerateOperationId();

            try
            {
                Logger.BufferedProducerClearStart(Identifier, EventHubName, operationId);

                foreach (var partitionStateItem in _activePartitionStateMap)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (partitionStateItem.Value.BufferedEventCount > 0)
                    {
                        while (partitionStateItem.Value.TryReadEvent(out _))
                        {
                        }

                        Interlocked.Add(ref _totalBufferedEventCount, (partitionStateItem.Value.BufferedEventCount * -1));
                        partitionStateItem.Value.BufferedEventCount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.BufferedProducerClearError(Identifier, EventHubName, operationId, ex.Message);
                throw;
            }
            finally
            {
                Logger.BufferedProducerClearComplete(Identifier, EventHubName, operationId);
            }
        }

        /// <summary>
        ///   Attempts to publish all events in the buffer immediately.  This may result in multiple batches being published,
        ///   the outcome of each of which will be individually reported by the <see cref="SendEventBatchSucceededAsync" /> and
        ///   <see cref="SendEventBatchFailedAsync" /> handlers.
        ///
        ///   Upon completion of this method, the buffer will be empty.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        ///   This method will modify class-level state and should be synchronized.  It is assumed that callers hold responsibility for
        ///   ensuring synchronization concerns; this method should be invoked after any primitives have been acquired.
        ///
        ///   Callers are also assumed to own responsibility for stopping all publishing and performing any necessary
        ///   validation of client state before calling.
        /// </remarks>
        ///
        internal virtual async Task FlushInternalAsync(CancellationToken cancellationToken = default)
        {
            var operationId = GenerateOperationId();
            var activeDrains = new List<Task>(_options.MaximumConcurrentSends);

            try
            {
                Logger.BufferedProducerFlushStart(Identifier, EventHubName, operationId);

                foreach (var partitionStateItem in _activePartitionStateMap)
                {
                    // If cancellation has been requested then do so; outstanding drains and handlers
                    // will manage their own cancellation.

                    cancellationToken.ThrowIfCancellationRequested();

                    // If needed, wait for drain tasks to complete so there is room.

                    while (activeDrains.Count >= _options.MaximumConcurrentSends)
                    {
                        var awaiSingleWatch = ValueStopwatch.StartNew();
                        Logger.BufferedProducerPublishingAwaitStart(Identifier, EventHubName, activeDrains.Count, operationId);

                        // The drain task is responsible for managing its own exceptions and will not throw.

                        var finished = await Task.WhenAny(activeDrains).ConfigureAwait(false);
                        activeDrains.Remove(finished);

                        Logger.BufferedProducerPublishingAwaitComplete(Identifier, EventHubName, activeDrains.Count, operationId, awaiSingleWatch.GetElapsedTime().TotalSeconds);
                    }

                    // Drain the next partition; because this is an exclusive operation and is ensuring only a single
                    // invocation for each partition, there's no need to acquire the partition guard.

                    if ((!cancellationToken.IsCancellationRequested)
                        && (partitionStateItem.Value.BufferedEventCount > 0))
                    {
                        activeDrains.Add(DrainAndPublishPartitionEvents(partitionStateItem.Value, operationId, cancellationToken));
                    }
                }

                // Wait for any remaining partitions to complete, which will also wait for outstanding handlers.  This
                // is expected to manage their own exceptions and should not throw.

                await Task.WhenAll(activeDrains).AwaitWithCancellation(cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.BufferedProducerFlushError(Identifier, EventHubName, operationId, ex.Message);
                throw;
            }
            finally
            {
                Logger.BufferedProducerFlushComplete(Identifier, EventHubName, operationId);
            }
        }

        /// <summary>
        ///   Attempts to publish a single batch of previously buffered events to the requested partition.
        /// </summary>
        ///
        /// <param name="partitionState">The state of publishing for the partition.</param>
        /// <param name="releaseGuard"><c>true</c> if the <see cref="PartitionPublishingState.PartitionGuard" /> should be released after publishing; otherwise, <c>false</c>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel publishing.</param>
        ///
        /// <remarks>
        ///   This method has responsibility for invoking the event handlers to communicate
        ///   success or failure of the operation.
        /// </remarks>
        ///
        internal virtual async Task PublishBatchToPartition(PartitionPublishingState partitionState,
                                                            bool releaseGuard,
                                                            CancellationToken cancellationToken)
        {
            var operationId = GenerateOperationId();
            var partitionId = partitionState.PartitionId;
            var batchEvents = new List<EventData>();
            var publishWatch = default(ValueStopwatch);
            var batch = default(EventDataBatch);

            Logger.BufferedProducerEventBatchPublishStart(Identifier, EventHubName, partitionState.PartitionId, operationId);

            try
            {
                // Determine the intervals for the time limit on building the batch and for delaying between empty reads.

                var totalWaitTime = _options.MaximumWaitTime ?? Timeout.InfiniteTimeSpan;
                var remainingWaitTime = totalWaitTime;
                var delayInterval = CalculateBatchingDelay(totalWaitTime, PublishingDelayInterval);

                // The wait time constraint should not consider creating the batch; start tracking after the batch is available to build.

                batch = await _producer.CreateBatchAsync(new CreateBatchOptions { PartitionId = partitionId }, cancellationToken).ConfigureAwait(false);
                publishWatch = ValueStopwatch.StartNew();

                // Build the batch, stopping either when it is full or when the allowable wait time
                // has been exceeded.

                while (ShouldWait(remainingWaitTime, MinimumPublishingWaitInterval))
                {
                    if ((partitionState.TryReadEvent(out var currentEvent)) && (currentEvent != null))
                    {
                        if (batch.TryAdd(currentEvent))
                        {
                            batchEvents.Add(currentEvent);
                            Logger.BufferedProducerEventBatchPublishEventAdded(Identifier, EventHubName, partitionId, operationId, batchEvents.Count, publishWatch.GetElapsedTime().TotalSeconds);
                        }
                        else
                        {
                            // If this event is the first for the batch, then it is too large to ever successfully publish.  Because this event is poison
                            // it should not be stashed.  Since it was not added to the batch, the normal error handler path won't properly report it.
                            // Instead, perform the logging and handler invocation inline and then exit.

                            if (batch.Count == 0)
                            {
                                Interlocked.Decrement(ref partitionState.BufferedEventCount);
                                Interlocked.Decrement(ref _totalBufferedEventCount);

                                var message = string.Format(CultureInfo.InvariantCulture, Resources.EventTooLargeMask, EventHubName, batch.MaximumSizeInBytes);
                                var exception = new EventHubsException(EventHubName, message, EventHubsException.FailureReason.MessageSizeExceeded);

                                Logger.BufferedProducerEventBatchPublishError(Identifier, EventHubName, partitionId, operationId, message);

                                // Handler invocation is performed with a guarantee not to throw; exceptions in the handler are logged
                                // as part of the invocation.

                                await SafeInvokeOnSendFailedAsync(new List<EventData>(1) { currentEvent }, exception, partitionId, cancellationToken).ConfigureAwait(false);
                                return;
                            }

                            // The last read event could not fit in the batch; stash it for the next reader so that it isn't lost.

                            partitionState.StashEvent(currentEvent);

                            // The batch is full; break out of the batch building loop and move onto publishing.

                            break;
                        }
                    }
                    else
                    {
                        // If no event was available, delay for a short period to avoid a tight loop while attempting to read.  At
                        // this point, the remaining time has not been updated, but the attempt to read was a quick synchronous operation,
                        // so the lack of precision is not a concern.

                        delayInterval = CalculateBatchingDelay(remainingWaitTime, delayInterval);
                        Logger.BufferedProducerEventBatchPublishNoEventRead(Identifier, EventHubName, partitionId, operationId, delayInterval.TotalSeconds, publishWatch.GetElapsedTime().TotalSeconds);

                        if (ShouldWait(remainingWaitTime, MinimumPublishingWaitInterval))
                        {
                            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                            await Task.Delay(delayInterval, cancellationToken).ConfigureAwait(false);
                        }
                    }

                    // Adjust the remaining time based on the current total amount of time spent building the batch; if
                    // no wait time was specified, this will remain infinite.

                    remainingWaitTime = totalWaitTime.CalculateRemaining(publishWatch.GetElapsedTime());
                }

                // If there were events added to the batch, publish them.

                if (batch.Count > 0)
                {
                    // Handler invocation is performed with a guarantee not to throw; exceptions in the handler are logged
                    // as part of the invocation.

                    await SendBatchAsync(batch, partitionId, operationId, cancellationToken).ConfigureAwait(false);
                    await SafeInvokeOnSendSucceededAsync(batchEvents, partitionId, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Logger.BufferedProducerEventBatchPublishError(Identifier, EventHubName, partitionId, operationId, ex.Message);

                // Handler invocation is performed with a guarantee not to throw; exceptions in the handler are logged
                // as part of the invocation.

                if (batch?.Count > 0)
                {
                    await SafeInvokeOnSendFailedAsync(batchEvents, ex, partitionId, cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                // Succeed or fail, the batch events are no longer buffered; remove them from the partition state and the total.

                var delta = (batchEvents.Count * -1);

                Interlocked.Add(ref partitionState.BufferedEventCount, delta);
                Interlocked.Add(ref _totalBufferedEventCount, delta);

                batch?.Dispose();

                if (releaseGuard)
                {
                    partitionState.PartitionGuard.Release();
                }

                var duration = publishWatch.IsActive ? publishWatch.GetElapsedTime().TotalSeconds : 0;
                Logger.BufferedProducerEventBatchPublishComplete(Identifier, EventHubName, partitionId, operationId, batchEvents.Count, duration);
            }
        }

        /// <summary>
        ///   Attempts to fully drain the events buffered for a partition, publishing them in batches.
        /// </summary>
        ///
        /// <param name="partitionState">The state of publishing for the partition.</param>
        /// <param name="operationId">An identifier for the publishing operations that can be used to correlate related log entries.  If <c>null</c> or empty, a new identifier will be generated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel publishing.</param>
        ///
        /// <remarks>
        ///   This method has responsibility for invoking the event handlers to communicate success or failure of the
        ///   operation.
        /// </remarks>
        ///
        internal virtual async Task DrainAndPublishPartitionEvents(PartitionPublishingState partitionState,
                                                                   string operationId,
                                                                   CancellationToken cancellationToken)
        {
            ValueStopwatch publishWatch;
            EventData readEvent;

            var drainComplete = false;
            var partitionId = partitionState.PartitionId;
            var batchEvents = default(List<EventData>);
            var batch = default(EventDataBatch);

            if (string.IsNullOrEmpty(operationId))
            {
                operationId = GenerateOperationId();
            }

            Logger.BufferedProducerDrainStart(Identifier, EventHubName, partitionId, operationId);

            try
            {
                while (!drainComplete)
                {
                    batch ??= await _producer.CreateBatchAsync(new CreateBatchOptions { PartitionId = partitionId }, cancellationToken).ConfigureAwait(false);
                    batchEvents ??= new List<EventData>();

                    publishWatch = ValueStopwatch.StartNew();

                    // Read events until one does not fit in the batch.

                    while ((partitionState.TryReadEvent(out readEvent)) && (batch.TryAdd(readEvent)))
                    {
                        batchEvents.Add(readEvent);
                        Logger.BufferedProducerEventBatchPublishEventAdded(Identifier, EventHubName, partitionId, operationId, batch.Count, publishWatch.GetElapsedTime().TotalSeconds);
                    }

                    // If there were no events read and there are none in the batch, then draining is complete.

                    if ((readEvent == null) && (batch.Count == 0))
                    {
                        drainComplete = true;
                        Logger.BufferedProducerEventBatchPublishNoEventRead(Identifier, EventHubName, partitionId, operationId, 0, publishWatch.GetElapsedTime().TotalSeconds);
                    }
                    else if (batch.Count == 0)
                    {
                        // If the read event is the first for the batch, then it is too large to ever successfully publish.  Because this event is poison
                        // it should not be stashed.  Since it was not added to the batch, the normal error handler path won't properly report it.
                        // Instead, perform the logging and handler invocation inline.

                        Interlocked.Decrement(ref partitionState.BufferedEventCount);
                        Interlocked.Decrement(ref _totalBufferedEventCount);

                        var message = string.Format(CultureInfo.InvariantCulture, Resources.EventTooLargeMask, EventHubName, batch.MaximumSizeInBytes);
                        var exception = new EventHubsException(EventHubName, message, EventHubsException.FailureReason.MessageSizeExceeded);

                        Logger.BufferedProducerEventBatchPublishError(Identifier, EventHubName, partitionId, operationId, message);
                        await SafeInvokeOnSendFailedAsync(new List<EventData>(1) { readEvent }, exception, partitionId, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        // There are events in the batch to publish, but may or may not be an event read that could not fit in the batch.

                        if (readEvent != null)
                        {
                            partitionState.StashEvent(readEvent);
                        }

                        Logger.BufferedProducerEventBatchPublishStart(Identifier, EventHubName, partitionState.PartitionId, operationId);

                        try
                        {
                            await _producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);
                            await SafeInvokeOnSendSucceededAsync(batchEvents, partitionState.PartitionId, cancellationToken).ConfigureAwait(false);
                        }
                        catch (Exception ex)
                        {
                            Logger.BufferedProducerEventBatchPublishError(Identifier, EventHubName, partitionId, operationId, ex.Message);
                            await SafeInvokeOnSendFailedAsync(batchEvents, ex, partitionId, cancellationToken).ConfigureAwait(false);

                            // If publishing was canceled, break out of the drain loop.

                            if (ex is OperationCanceledException)
                            {
                                throw;
                            }
                        }
                        finally
                        {
                            Logger.BufferedProducerEventBatchPublishComplete(Identifier, EventHubName, partitionId, operationId, batch.Count, publishWatch.GetElapsedTime().TotalSeconds);

                            var delta = (batchEvents.Count * -1);

                            Interlocked.Add(ref partitionState.BufferedEventCount, delta);
                            Interlocked.Add(ref _totalBufferedEventCount, delta);
                        }

                        batch.Dispose();

                        batch = null;
                        batchEvents = null;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // This is expected when cancellation is detected when creating a new batch; the partition
                // will be left in a consistent state.
            }
            catch (Exception ex)
            {
                // This path should not be possible under normal conditions; if triggered, then
                // something is in a corrupt state and the drain cannot continue.  Consider all remaining
                // events to be failures and cease publishing.

                Logger.BufferedProducerDrainError(Identifier, EventHubName, partitionId, operationId, ex.Message);
                var events = new List<EventData>();

                while (partitionState.TryReadEvent(out readEvent))
                {
                   events.Add(readEvent);
                }

                var partitionStateDelta = (partitionState.BufferedEventCount * -1);
                var totalDeltaZero = (_totalBufferedEventCount * -1);

                Interlocked.Add(ref _totalBufferedEventCount, Math.Max(totalDeltaZero, partitionStateDelta));
                Interlocked.Exchange(ref partitionState.BufferedEventCount, 0);

                await SafeInvokeOnSendFailedAsync(events, ex, partitionId, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                batch?.Dispose();
                Logger.BufferedProducerDrainComplete(Identifier, EventHubName, partitionId, operationId);
            }
        }

        /// <summary>
        ///   Gets the current date and time.
        /// </summary>
        ///
        /// <returns>The <see cref="DateTimeOffset" /> representing the current time.</returns>
        ///
        internal virtual DateTimeOffset GetCurrentTime() => DateTimeOffset.UtcNow;

        /// <summary>
        ///   Responsible for raising the <see cref="SendEventBatchSucceededAsync"/> event upon the successful publishing
        ///   of a batch of events.
        /// </summary>
        ///
        /// <param name="events">The set of events belonging to the batch that was successfully published.</param>
        /// <param name="partitionId">The identifier of the partition that the batch of events was published to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel publishing.</param>
        ///
        protected virtual async Task OnSendSucceededAsync(IReadOnlyList<EventData> events,
                                                          string partitionId,
                                                          CancellationToken cancellationToken = default)
        {
            // Once publishing has started, it's not possible to add/remove handlers; its safe to assume that
            // the reference is valid without caching it.

            if (_sendSucceededHandler == null)
            {
                Logger.BufferedProducerNoPublishEventHandler(Identifier, EventHubName, partitionId);
                return;
            }

            var operationId = GenerateOperationId();
            Logger.BufferedProducerOnSendSucceededStart(Identifier, EventHubName, partitionId, operationId);

            try
            {
                var args = new SendEventBatchSucceededEventArgs(events, partitionId, cancellationToken);
                await _sendSucceededHandler(args).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.BufferedProducerOnSendSucceededError(Identifier, EventHubName, partitionId, operationId, ex.Message);
                throw;
            }
            finally
            {
                Logger.BufferedProducerOnSendSucceededComplete(Identifier, EventHubName, partitionId, operationId);
            }
        }

        /// <summary>
        ///   Responsible for raising the <see cref="SendEventBatchFailedAsync"/> event upon the failed publishing of a
        ///   batch of events, after all eligible retries are exhausted.
        /// </summary>
        ///
        /// <param name="events">The set of events belonging to the batch that failed to be published.</param>
        /// <param name="exception">The <see cref="Exception"/> that was raised when the events failed to publish.</param>
        /// <param name="partitionId">The identifier of the partition that the batch of events was published to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel publishing.</param>
        ///
        protected virtual async Task OnSendFailedAsync(IReadOnlyList<EventData> events,
                                                       Exception exception,
                                                       string partitionId,
                                                       CancellationToken cancellationToken = default)
        {
            // Once publishing has started, it's not possible to add/remove handlers; its safe to assume that
            // the reference is valid without caching it.

            if (_sendFailedHandler == null)
            {
                Logger.BufferedProducerNoPublishEventHandler(Identifier, EventHubName, partitionId);
                return;
            }

            var operationId = GenerateOperationId();
            Logger.BufferedProducerOnSendFailedStart(Identifier, EventHubName, partitionId, operationId);

            try
            {
                var args = new SendEventBatchFailedEventArgs(events, exception, partitionId, cancellationToken);
                await _sendFailedHandler(args).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.BufferedProducerOnSendFailedError(Identifier, EventHubName, partitionId, operationId, ex.Message);
                throw;
            }
            finally
            {
                Logger.BufferedProducerOnSendFailedComplete(Identifier, EventHubName, partitionId, operationId);
            }
        }

        /// <summary>
        ///   Queries for the identifiers of the Event Hub partitions.
        /// </summary>
        ///
        /// <param name="producer">The producer client instance to use for querying.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the query.</param>
        ///
        /// <returns>The set of identifiers for the Event Hub partitions.</returns>
        ///
        protected virtual async Task<string[]> ListPartitionIdsAsync(EventHubProducerClient producer,
                                                                     CancellationToken cancellationToken) =>
            await producer.GetPartitionIdsAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Performs the actions needed to initialize the <see cref="EventHubBufferedProducerClient" /> to begin accepting events to be
        ///   enqueued and published.  If this method is called while processing is active, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect background processing once it starts running.</param>
        ///
        /// <remarks>
        ///   This method will modify class-level state and should be synchronized.  It is assumed that callers hold responsibility for
        ///   ensuring synchronization concerns; this method should be invoked after any primitives have been acquired.
        ///
        ///   Callers are also assumed to own responsibility for any validation that the client is in the intended state before calling.
        /// </remarks>
        ///
        private async Task StartPublishingAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.BufferedProducerBackgroundProcessingStart(Identifier, EventHubName);

            try
            {
                // Ensure that partition information is populated.  If already populated, then allow the
                // background management task to keep the information current.

                if ((_partitions == null) || (_partitionHash == null))
                {
                    // The retry policy for the buffered producer is, by default, generous to allow for long running background work to be done
                    // effectively. For startup, a more conservative retry policy is needed to prevent the producer from hanging, so cancel
                    // after one TryTimeout interval.

                    using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                    linkedCts.CancelAfter(_options.RetryOptions.TryTimeout);

                    try
                    {
                        await UpdatePartitionInformation(linkedCts.Token).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        throw new EventHubsException(true, EventHubName, Resources.BufferedProducerStartupTimeout, EventHubsException.FailureReason.ServiceTimeout);
                    }
                }

                // If there is already a task running for the background management process,
                // then no further initialization is needed.

                if ((IsPublishing) && (!_producerManagementTask.IsCompleted))
                {
                    return;
                }

                // There should be no cancellation source, but guard against leaking resources in the
                // event of a crash or other exception.

                _backgroundTasksCancellationSource?.Cancel();
                _backgroundTasksCancellationSource?.Dispose();
                _backgroundTasksCancellationSource = new CancellationTokenSource();

                // If there was a task present, then it will have been previously faulted
                // or has just been canceled; capture any exception for logging.  This is
                // considered non-fatal, as a new instance of the task will be started.

                if (_producerManagementTask != null)
                {
                    try
                    {
                        await _producerManagementTask.ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        Logger.BufferedProducerManagementTaskError(Identifier, EventHubName, ex.Message);
                    }
                }

                // Start the background processing task responsible for ensuring updated state and managing partition
                // processing health.

                _producerManagementTask = RunProducerManagementAsync(_backgroundTasksCancellationSource.Token);
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException opEx)
                {
                    throw new TaskCanceledException(opEx.Message, opEx);
                }

                Logger.BufferedProducerBackgroundProcessingStartError(Identifier, EventHubName, ex.Message);
                throw;
            }
            finally
            {
                Logger.BufferedProducerBackgroundProcessingStartComplete(Identifier, EventHubName);
            }
        }

        /// <summary>
        ///   Performs the actions needed to stop processing events. the <see cref="EventHubBufferedProducerClient" /> to begin accepting events to be
        ///   enqueued and published.  Should this method be called while processing is not active, no action is taken.
        /// </summary>
        ///
        /// <param name="cancelActiveSendOperations"><c>true</c> if active "SendAsync" operations should be canceled; otherwise, <c>false</c>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.</param>
        ///
        /// <remarks>
        ///   This method will modify class-level state and should be synchronized.  It is assumed that callers hold responsibility for
        ///   ensuring synchronization concerns; this method should be invoked after any primitives have been acquired.  Callers are also
        ///   assumed to own responsibility for any validation that the client is in the intended state before calling.
        ///
        ///   This method does not consider any events that have been enqueued and are in a pending state.  It is assumed
        ///   that the caller has responsibility for disposing of any active partition state and invoking <see cref="FlushInternalAsync" />
        ///   or <see cref="ClearInternal" /> as needed.
        /// </remarks>
        ///
        private async Task StopPublishingAsync(bool cancelActiveSendOperations,
                                               CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.BufferedProducerBackgroundProcessingStop(Identifier, EventHubName);

            var capturedExceptions = default(List<Exception>);

            try
            {
                // If there is no task running for the background management process, there
                // is nothing to stop.

                if (_producerManagementTask == null)
                {
                    return;
                }

                // Request cancellation of the background processing.

                _backgroundTasksCancellationSource?.Cancel();
                _backgroundTasksCancellationSource?.Dispose();
                _backgroundTasksCancellationSource = null;

                if (cancelActiveSendOperations)
                {
                    _activeSendOperationsCancellationSource?.Cancel();
                }

                // Wait for the background tasks to complete.

                try
                {
                    await _producerManagementTask.ConfigureAwait(false);
                }
                catch (TaskCanceledException)
                {
                    // This is expected; no action is needed.
                }
                catch (Exception ex)
                {
                    Logger.BufferedProducerBackgroundProcessingStopError(Identifier, EventHubName, ex.Message);
                    (capturedExceptions ??= new List<Exception>()).Add(ex);
                }

                _producerManagementTask = null;
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException opEx)
                {
                    throw new TaskCanceledException(opEx.Message, opEx);
                }

                Logger.BufferedProducerBackgroundProcessingStopError(Identifier, EventHubName, ex.Message);
                (capturedExceptions ??= new List<Exception>()).Add(ex);
            }
            finally
            {
                _activeSendOperationsCancellationSource?.Dispose();
                Logger.BufferedProducerBackgroundProcessingStopComplete(Identifier, EventHubName);
            }

            // Surface any exceptions that were captured during cleanup.

            if (capturedExceptions?.Count == 1)
            {
                ExceptionDispatchInfo.Capture(capturedExceptions[0]).Throw();
            }
            else if (capturedExceptions is not null)
            {
                throw new AggregateException(capturedExceptions);
            };
        }

        /// <summary>
        ///   Performs the actions need to publish a batch of events, applying any needed
        ///   logic for handling special error cases and recovery.
        /// </summary>
        ///
        /// <param name="batch">The batch of events to publish.</param>
        /// <param name="partitionId">The identifier of the partition associated with this publishing operation.</param>
        /// <param name="operationId">The identifier of the publishing operation that this invocation is associated with.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.</param>
        ///
        /// <remarks>
        ///   Callers are assumed to retain ownership over the <paramref name="batch" /> and are responsible for its disposal.
        /// </remarks>
        ///
        private async Task SendBatchAsync(EventDataBatch batch,
                                          string partitionId,
                                          string operationId,
                                          CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var throttleBackoffs = 0;

                try
                {
                    await _producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);
                    return;
                }
                catch (EventHubsException ex) when (ex.Reason == EventHubsException.FailureReason.ServiceBusy)
                {
                    // The service is throttling requests.  Because this is not a scenario under control
                    // of callers, the operation should continue to be retried until cancellation takes
                    // place or the operation succeeds/fails. Retry policy limits should not be applied.

                    ++throttleBackoffs;

                    var randomJitter = TimeSpan.FromSeconds(RandomNumberGenerator.Value.NextDouble());
                    var backoffInterval = ThrottleBackoffInterval.Add(randomJitter);

                    Logger.BufferedProducerThrottleDelay(Identifier, EventHubName, partitionId, operationId, backoffInterval.TotalSeconds, throttleBackoffs);
                    await Task.Delay(backoffInterval, cancellationToken).ConfigureAwait(false);
                }
            }

            throw new TaskCanceledException();
        }

        /// <summary>
        ///   Responsible for invoking <see cref="OnSendSucceededAsync" /> and ensuring that no exceptions
        ///   are surfaced.  This is necessary because the method may be overridden and non-throwing behavior
        ///   cannot be guaranteed.
        /// </summary>
        ///
        /// <param name="events">The set of events belonging to the batch that was successfully published.</param>
        /// <param name="partitionId">The identifier of the partition that the batch of events was published to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the handler invocation.  It is the responsibility of the registered handler to make the decision to honor cancellation or not.</param>
        ///
        private async Task SafeInvokeOnSendSucceededAsync(IReadOnlyList<EventData> events,
                                                          string partitionId,
                                                          CancellationToken cancellationToken)
        {
            try
            {
                await OnSendSucceededAsync(events, partitionId, cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                // Exceptions in the handler are logged as part of the invocation.  There is no value in throwing,
                // as the source is a background task and the exception is not observable by application code.
            }
        }

        /// <summary>
        ///   Responsible for invoking <see cref="OnSendFailedAsync" /> and ensuring that no exceptions
        ///   are surfaced.  This is necessary because the method may be overridden and non-throwing behavior
        ///   cannot be guaranteed.
        /// </summary>
        ///
        /// <param name="events">The set of events belonging to the batch that failed to be published.</param>
        /// <param name="exception">The <see cref="Exception"/> that was raised when the events failed to publish.</param>
        /// <param name="partitionId">The identifier of the partition that the batch of events was published to.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the handler invocation.  It is the responsibility of the registered handler to make the decision to honor cancellation or not.</param>
        ///
        private async Task SafeInvokeOnSendFailedAsync(IReadOnlyList<EventData> events,
                                                       Exception exception,
                                                       string partitionId,
                                                       CancellationToken cancellationToken)
        {
            try
            {
                await OnSendFailedAsync(events, exception, partitionId, cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                // Exceptions in the handler are logged as part of the invocation.  There is no value in throwing,
                // as the source is a background task and the exception is not observable by application code.
            }
        }

        /// <summary>
        ///   Performs the tasks needed to manage state for the <see cref="EventHubBufferedProducerClient" /> and
        ///   ensure the health of the tasks responsible for partition processing.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        private async Task RunProducerManagementAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Logger.BufferedProducerManagementCycleStart(Identifier, EventHubName);
                var cycleDuration = ValueStopwatch.StartNew();

                try
                {
                    // Ensure that the publishing task is running.

                    if (_publishingTask == null)
                    {
                        _publishingTask = RunPublishingAsync(cancellationToken);
                        Logger.BufferedProducerPublishingTaskInitialStart(Identifier, EventHubName);
                    }
                    else if (_publishingTask.IsCompleted)
                    {
                        try
                        {
                            await _publishingTask.ConfigureAwait(false);
                        }
                        catch (Exception ex) when (ex is not TaskCanceledException)
                        {
                            Logger.BufferedProducerPublishingTaskError(Identifier, EventHubName, ex.Message);
                        }

                        _publishingTask = RunPublishingAsync(cancellationToken);
                        Logger.BufferedProducerPublishingTaskRestart(Identifier, EventHubName);
                    }

                    // Refresh the partition information.

                    await UpdatePartitionInformation(cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    // This is expected; allow the loop to continue and exit normally
                    // so that the publishing task can be shut down.
                }
                catch (Exception ex)
                {
                    // Exceptions in the management operations are not critical; log but
                    // allow the loop to continue.

                    Logger.BufferedProducerManagementTaskError(Identifier, EventHubName, ex.Message);
                }

                // Determine the delay to apply before the next management cycle; if cancellation
                // was requested, then do not delay and allow the loop to terminate.

                var remainingTimeUntilNextCycle = BackgroundManagementInterval.CalculateRemaining(cycleDuration.GetElapsedTime());
                Logger.BufferedProducerManagementCycleComplete(Identifier, EventHubName, _partitions.Length, cycleDuration.GetElapsedTime().TotalSeconds, remainingTimeUntilNextCycle.TotalSeconds);

                if ((!cancellationToken.IsCancellationRequested) && (ShouldWait(remainingTimeUntilNextCycle, TimeSpan.Zero)))
                {
                    try
                    {
                        await Task.Delay(remainingTimeUntilNextCycle, cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        // Expected; take no action and allow the loop to exit so shutdown
                        // can continue.
                    }
                }
            }

            // If there was a publishing task, it has the same cancellation token associated.
            // Wait for it to complete; allow any exceptions to surface.  In the normal case, this
            // will be a cancellation exception; otherwise, there was an actual error.

            if (_publishingTask != null)
            {
                try
                {
                    await _publishingTask.ConfigureAwait(false);
                }
                catch (Exception ex) when (ex is not TaskCanceledException)
                {
                    Logger.BufferedProducerPublishingTaskError(Identifier, EventHubName, ex.Message);
                    throw;
                }
            }

            throw new TaskCanceledException();
        }

        /// <summary>
        ///   Performs the tasks needed to perform publishing for the <see cref="EventHubBufferedProducerClient" />.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        private Task RunPublishingAsync(CancellationToken cancellationToken) =>
            Task.Run(async () =>
            {
                var operationId = GenerateOperationId();
                Logger.BufferedProducerPublishingManagementStart(Identifier, EventHubName, operationId);

                try
                {
                    // There should be only one instance of this background publishing task running, so it is safe to assume
                    // no other publishing operations are active.  Reset the operation cancellation source to ensure that
                    // any prior cancellation or disposal does not prevent canceling operations created here.

                    var activeOperationCancellationSource = new CancellationTokenSource();
                    var existingSource = Interlocked.Exchange(ref _activeSendOperationsCancellationSource, activeOperationCancellationSource);
                    existingSource?.Dispose();

                    var partitionIndex = 0u;
                    var partitions = default(string[]);
                    var activeTasks = new List<Task>(_options.MaximumConcurrentSends);

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        // If needed, wait for publishing tasks to complete so there is room.

                        while (activeTasks.Count >= _options.MaximumConcurrentSends)
                        {
                            var awaitSingleWatch = ValueStopwatch.StartNew();
                            Logger.BufferedProducerPublishingAwaitStart(Identifier, EventHubName, activeTasks.Count, operationId);

                            // The publishing task is responsible for managing its own exceptions and will not throw.

                            var finished = await Task.WhenAny(activeTasks).ConfigureAwait(false);
                            activeTasks.Remove(finished);

                            Logger.BufferedProducerPublishingAwaitComplete(Identifier, EventHubName, activeTasks.Count, operationId, awaitSingleWatch.GetElapsedTime().TotalSeconds);
                        }

                        // Select a partition to process; because the set of partitions is unstable, capture a local reference to
                        // avoid potentially creating an invalid index into the array.

                        partitions = _partitions;
                        var partition = partitions[partitionIndex % partitions.Length];

                        unchecked
                        {
                            ++partitionIndex;
                        }

                        try
                        {
                            // If the selected partition is not actively being used to enqueue or its semaphore cannot be
                            // acquired within the time limit, the partition is not available and the loop should iterate
                            // to consider the next available partition.
                            //
                            // There is a benign race condition in checking the buffered event count, resulting in a partition
                            // that has just had an event enqueued to be skipped for a cycle, but this is permissible to favor
                            // building dense batches.
                            //
                            // The semaphore guard is intentionally acquired as the last clause to ensure that it is only attempted
                            // if all other conditions are true; this ensures that it does not need to be released if checks fail
                            // and a batch isn't going to be published for this iteration.

                            if ((!cancellationToken.IsCancellationRequested)
                                && (_activePartitionStateMap.TryGetValue(partition, out var partitionState))
                                && (partitionState.BufferedEventCount > 0)
                                && ((partitionState.PartitionGuard.Wait(0, cancellationToken)) || (await partitionState.PartitionGuard.WaitAsync(PartitionPublishingGuardAcquireLimitMilliseconds, cancellationToken).ConfigureAwait((false)))))
                            {
                                // Responsibility for releasing the guard semaphore is passed to the task.

                                activeTasks.Add(PublishBatchToPartition(partitionState, releaseGuard: true, activeOperationCancellationSource.Token));
                            }

                            // If there are no events in the buffer, avoid a tight loop by blocking to wait for events to be enqueued
                            // after a small delay.

                            if (_totalBufferedEventCount == 0)
                            {
                                // If completion source doesn't exist or was already set, then swap in a new completion source to be
                                // set when an event is enqueued.  Allow the publishing loop to tick for one additional check of the
                                // buffers, to ensure that no events were enqueued during the swap.

                                if ((_eventEnqueuedCompletionSource == null) || (_eventEnqueuedCompletionSource.Task.IsCompleted))
                                {
                                    // Because we want to ensure that calls to enqueue events see the new completion source, use
                                    // an interlocked operation to ensure the new value is visible to other threads.

                                    Interlocked.Exchange(ref _eventEnqueuedCompletionSource, new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously));
                                    await Task.Delay(PublishingDelayInterval, cancellationToken).ConfigureAwait(false);
                                }
                                else
                                {
                                    // If the buffer is still empty and no event was enqueued since the completion source was created,
                                    // await an event to be enqueued.  Clearing the completion source after the await does not need a memory
                                    // fence; it does not matter if other threads see the stale value.

                                    Logger.BufferedProducerIdleStart(Identifier, EventHubName, operationId);

                                    var idleWatch = ValueStopwatch.StartNew();

                                    await _eventEnqueuedCompletionSource.Task.AwaitWithCancellation(cancellationToken);
                                    _eventEnqueuedCompletionSource = null;

                                    Logger.BufferedProducerIdleComplete(Identifier, EventHubName, operationId, idleWatch.GetElapsedTime().TotalSeconds);
                                }
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            // This is expected; allow the loop to exit with no further interaction.
                        }
                    }

                    // Wait for all of the active publishing tasks to complete; these hold responsibility for
                    // managing and logging their exceptions and should never throw.  The tasks also will honor
                    // cancellation internally and should be fully awaited rather than allowing "WhenAll" to cancel.

                    Logger.BufferedProducerPublishingAwaitAllStart(Identifier, EventHubName, activeTasks.Count, operationId);
                    var awaitAllWatch = ValueStopwatch.StartNew();

                    try
                    {
                        await Task.WhenAll(activeTasks).ConfigureAwait(false);
                    }
                    catch (AggregateException ex)
                    {
                        ex.Handle(exception => exception is OperationCanceledException);
                    }

                    Logger.BufferedProducerPublishingAwaitAllComplete(Identifier, EventHubName, activeTasks.Count, operationId, awaitAllWatch.GetElapsedTime().TotalSeconds);
                }
                catch (Exception ex)
                {
                    // The publishing tasks are responsible for managing their own exceptions and should not
                    // throw.  If we reach this block, then it indicates something is not working as expected
                    // and this task should fail.

                    Logger.BufferedProducerPublishingManagementError(Identifier, EventHubName, operationId, ex.Message);
                    throw;
                }
                finally
                {
                    Logger.BufferedProducerPublishingManagementComplete(Identifier, EventHubName, operationId);
                }
            }, cancellationToken);

        /// <summary>
        ///    Ensures that class state has accurate partition information, updating it if the
        ///    set of Event Hub partitions has changed since they were last queried.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        ///   This method will potentially modify class state, overwriting the tracked set of partitions.
        /// </remarks>
        ///
        private async Task UpdatePartitionInformation(CancellationToken cancellationToken)
        {
            var currentPartitions = _partitions;
            var queriedPartitions = await _producer.GetPartitionIdsAsync(cancellationToken).ConfigureAwait(false);

            // Assume that if the count of partitions matches the current count, then no updated is needed.
            // This is safe because partition identifiers are stable and new partitions can be added but
            // the can never be removed.

            if ((currentPartitions?.Length ?? 0) != queriedPartitions.Length)
            {
                // The partitions need to be updated.  Because the two class members tracking partitions
                // are used for different purposes, it is permissible for them to drift for a short time.
                // As a result, there's no need to synchronize them.

                _partitions = queriedPartitions;
                _partitionHash = new HashSet<string>(queriedPartitions);;
            }
        }

        /// <summary>
        ///   Ensures that no more than a single partition reference is active.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition to which the producer is bound.</param>
        /// <param name="partitionKey">The hash key for partition routing that was requested for a publish operation.</param>
        ///
        private static void AssertSinglePartitionReference(string partitionId,
                                                           string partitionKey)
        {
            if ((!string.IsNullOrEmpty(partitionId)) && (!string.IsNullOrEmpty(partitionKey)))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotSendWithPartitionIdAndPartitionKey, partitionKey, partitionId));
            }
        }

        /// <summary>
        ///   Ensures that if a partition identifier was specified, it refers to a valid
        ///   partition for the Event Hub.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition to which the producer is bound.</param>
        /// <param name="validPartitions">The set of valid partitions to consider.</param>
        ///
        private static void AssertValidPartition(string partitionId,
                                                 HashSet<string> validPartitions)
        {
            if (!validPartitions.Contains(partitionId))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotSendToUknownPartition, partitionId));
            }
        }

        /// <summary>
        ///   Ensures that an event handler required for enqueuing events has been set.
        /// </summary>
        ///
        /// <param name="handler">The event handler instance to validate.</param>
        /// <param name="handlerName">The name of the event handler.</param>
        ///
        private static void AssertRequiredHandlerSetForEnqueue(object handler,
                                                               string handlerName)
        {
            if (handler == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotEnqueueEventWithoutHandler, handlerName));
            }
        }

        /// <summary>
        ///   Creates a channel for queuing events to be published.
        /// </summary>
        ///
        /// <param name="capacity">The maximum amount of events that can be queued in the channel.</param>
        ///
        /// <returns>A bounded channel, configured for many:many read/write usage.</returns>
        ///
        private static Channel<EventData> CreatePendingEventChannel(int capacity) =>
            Channel.CreateBounded<EventData>(new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleWriter = false,
                SingleReader = false
            });

        /// <summary>
        ///   Generates a unique identifier to be used for correlation in a
        ///   logging scope.
        /// </summary>
        ///
        /// <returns>The identifier that was generated.</returns>
        ///
        private static string GenerateOperationId() => Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture);

        /// <summary>
        ///   Determines if waiting should take place, taking into account <see cref="Timeout.InfiniteTimeSpan" />
        ///   as an indicator of a desire to always wait.
        /// </summary>
        ///
        /// <param name="waitTime">The desired interval to wait.</param>
        /// <param name="minimumAllowedWaitTime">The minimum allowed interval for waiting.</param>
        ///
        /// <returns><c>true</c> if waiting should be allowed; otherwise, <c>false</c>.</returns>
        ///
        private static bool ShouldWait(TimeSpan waitTime,
                                       TimeSpan minimumAllowedWaitTime) =>
          ((waitTime == Timeout.InfiniteTimeSpan) || (waitTime > minimumAllowedWaitTime));

        /// <summary>
        ///   Calculates the amount of delay to apply when building a batch, ensuring that the remaining time
        ///   allotted supersedes the delay amount, if not enough time remains for the full delay.
        /// </summary>
        /// <param name="remainingTime">The amount of allotted time remaining.</param>
        /// <param name="delayInterval">The desired delay interval.</param>
        ///
        /// <returns>The amount of delay to apply.</returns>
        ///
        private static TimeSpan CalculateBatchingDelay(TimeSpan remainingTime,
                                                       TimeSpan delayInterval) => ((remainingTime != Timeout.InfiniteTimeSpan) && (remainingTime < delayInterval)) ? remainingTime : delayInterval;

        /// <summary>
        ///   The set of information needed to track and manage the active publishing
        ///   activities for a partition.
        /// </summary>
        ///
        internal sealed class PartitionPublishingState : IDisposable
        {
            /// <summary>The writer to use for enqueuing events to be published.</summary>
            public ChannelWriter<EventData> PendingEventsWriter => _pendingEvents.Writer;

            /// <summary>The identifier of the partition that is being published.</summary>
            public readonly string PartitionId;

            /// <summary>The primitive for synchronizing access for publishing to the partition.</summary>
            public readonly SemaphoreSlim PartitionGuard;

            /// <summary>The number of events that are currently buffered and waiting to be published for this partition.</summary>
            public int BufferedEventCount;

            /// <summary>An event that has been stashed to be read as the next available event; this is necessary due to the inability to peek the channel.</summary>
            private ConcurrentQueue<EventData> _stashedEvents;

            /// <summary>The events that have been enqueued and are pending publishing.</summary>
            private readonly Channel<EventData> _pendingEvents;

            /// <summary>
            ///   Initializes a new instance of the <see cref="PartitionPublishingState"/> class.
            /// </summary>
            ///
            /// <param name="partitionId">The identifier of the partition this publisher is associated with.</param>
            /// <param name="options">The options used for creating the buffered producer.</param>
            ///
            public PartitionPublishingState(string partitionId,
                                            EventHubBufferedProducerClientOptions options)
            {
                PartitionId = partitionId;
                PartitionGuard = new(options.MaximumConcurrentSendsPerPartition, options.MaximumConcurrentSendsPerPartition);

                _pendingEvents = CreatePendingEventChannel(options.MaximumEventBufferLengthPerPartition);
                _stashedEvents = new();
            }

            /// <summary>
            ///   Attempts to read an event to be published.
            /// </summary>
            ///
            /// <param name="readEvent">The event, if one was read; otherwise, <c>null</c>.</param>
            ///
            /// <returns><c>true</c> if an event was read; otherwise, <c>false</c>.</returns>
            ///
            public bool TryReadEvent(out EventData readEvent)
            {
                if (_stashedEvents.TryDequeue(out readEvent))
                {
                    return true;
                }

                return _pendingEvents.Reader.TryRead(out readEvent);
            }

            /// <summary>
            ///   Stashes an event with priority for the next time a read is requested.  This is
            ///   intended to both support concurrent publishing for a partition and to work around
            ///   the lack of "Peek" operation for channels.
            /// </summary>
            ///
            /// <param name="eventData">The event to stash.</param>
            ///
            public void StashEvent(EventData eventData) => _stashedEvents.Enqueue(eventData);

            /// <summary>
            ///   Performs tasks needed to clean-up the disposable resources used by the publisher.
            /// </summary>
            ///
            public void Dispose()
            {
                _pendingEvents.Writer.TryComplete();
                PartitionGuard.Dispose();
            }
        }
    }
}
