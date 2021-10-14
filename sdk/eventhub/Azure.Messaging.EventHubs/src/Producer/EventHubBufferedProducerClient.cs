// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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
    ///   application. This is the recommended approach, since the client is responsible for efficient network,
    ///   CPU, and memory use. Calling <see cref="CloseAsync(bool, CancellationToken)"/> or <see cref="DisposeAsync"/>
    ///   is required so that resources can be cleaned up after use.
    /// </remarks>
    ///
    /// <seealso cref="EventHubProducerClient" />
    ///
    internal class EventHubBufferedProducerClient : IAsyncDisposable
    {
        /// <summary>
        ///   The set of client options to use when options were not passed when the producer was instantiated.
        /// </summary>
        ///
        private static EventHubBufferedProducerClientOptions DefaultOptions { get; } =
            new EventHubBufferedProducerClientOptions
            {
                RetryOptions = new EventHubsRetryOptions { MaximumRetries = 15, TryTimeout = TimeSpan.FromMinutes(3) }
            };

        /// <summary>The producer to use to send events to the Event Hub.</summary>
        [SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "It is being disposed via delegation to CloseAsync.")]
        private readonly EventHubProducerClient _producer;

        /// <summary>The primitive for synchronizing access when class-wide state is changing.</summary>
        [SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "The AvailableWaitHandle property is not accessed; resources requiring dispose will not have been allocated.")]
        private readonly SemaphoreSlim _stateGuard = new SemaphoreSlim(1, 1);

        /// <summary>The set of options to use with the <see cref="EventHubBufferedProducerClient" />  instance.</summary>
        private readonly EventHubBufferedProducerClientOptions _options;

        /// <summary>Indicates whether or not this instance has started publishing.</summary>
        private volatile bool _isPublishing;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _isClosed;

        /// <summary>The handler to be called once a batch has successfully published.</summary>
        private event Func<SendEventBatchSucceededEventArgs, Task> _sendSucceededHandler;

        /// <summary>The handler to be called once a batch has failed to publish.</summary>
        private event Func<SendEventBatchFailedEventArgs, Task> _sendFailedHandler;

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
        ///   <c>true</c> if the producer has been closed <c>false</c> otherwise.
        /// </summary>
        ///
        public virtual bool IsClosed
        {
            get => _isClosed;
            protected set => _isClosed = value;
        }

        /// <summary>
        ///   The total number of events that are currently buffered and waiting to be published, across all partitions.
        /// </summary>
        ///
        public virtual int TotalBufferedEventCount { get; private set; }

        /// <summary>
        ///   The indicator for whether or not the instance has started publishing,
        ///   exposed for testing purposes..
        /// </summary>
        ///
        internal virtual bool IsPublishing
        {
            get => _isPublishing;
            set => _isPublishing = value;
        }

        /// <summary>
        ///   The instance of <see cref="EventHubsEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal EventHubsEventSource Logger { get; set; } = EventHubsEventSource.Log;

        /// <summary>
        ///    Invoked after each batch of events has been successfully published to the Event Hub, this
        ///    handler is optional and is intended to provide notifications for interested listeners.
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
        [SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "Guidance does not apply; this is an event.")]
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
                _sendSucceededHandler = value;
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(SendEventBatchSucceededAsync));

                if (_isPublishing)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                if (_sendSucceededHandler != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }
                _sendSucceededHandler = default;
            }
        }

        /// <summary>
        ///   Invoked for any batch of events that failed to be published to the Event Hub, this handler must be
        ///   provided before events may be enqueued.
        ///
        ///   It is safe to attempt resending the events by calling <see cref="EnqueueEventAsync(EventData, CancellationToken)" /> or <see cref="EnqueueEventAsync(EventData, EnqueueEventOptions, CancellationToken)" /> from within
        ///   this handler.  It is important to note that doing so will place them at the end of the buffer; the original order will not be maintained.
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
        [SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "Guidance does not apply; this is an event.")]
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
                _sendFailedHandler = value;
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(SendEventBatchFailedAsync));

                if (_isPublishing)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                if (_sendFailedHandler != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
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
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
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
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
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
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
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
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        public EventHubBufferedProducerClient(string connectionString,
                                              string eventHubName,
                                              EventHubBufferedProducerClientOptions clientOptions) : this(clientOptions)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            _producer = new EventHubProducerClient(connectionString, eventHubName, (clientOptions ?? DefaultOptions).ToEventHubProducerClientOptions());
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
            Argument.AssertWellFormedEventHubsNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            var options = (clientOptions ?? DefaultOptions).ToEventHubProducerClientOptions();

            _producer = credential switch
            {
                TokenCredential tokenCred => new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, tokenCred, options),
                AzureSasCredential sasCred => new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, sasCred, options),
                AzureNamedKeyCredential keyCred =>  new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, keyCred, options),
                _ => throw new ArgumentException(Resources.UnsupportedCredential, nameof(credential))
            };
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
            throw new NotImplementedException();
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
        public virtual async Task<EventHubProperties> GetEventHubPropertiesAsync(CancellationToken cancellationToken = default) =>
            await _producer.GetEventHubPropertiesAsync(cancellationToken).ConfigureAwait(false);

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
        public virtual async Task<string[]> GetPartitionIdsAsync(CancellationToken cancellationToken = default) =>
            await _producer.GetPartitionIdsAsync(cancellationToken).ConfigureAwait(false);

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
                                                                                   CancellationToken cancellationToken = default) =>
            await _producer.GetPartitionPropertiesAsync(partitionId, cancellationToken).ConfigureAwait(false);

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
        ///
        /// <remarks>
        ///   Upon the first call to <see cref="EnqueueEventAsync(EventData, EnqueueEventOptions, CancellationToken)" /> or
        ///   <see cref="EnqueueEventsAsync(IEnumerable{EventData}, EnqueueEventOptions, CancellationToken)" />, the <see cref="SendEventBatchSucceededAsync" /> and
        ///   <see cref="SendEventBatchFailedAsync" /> handlers will be validated and can no longer be changed.
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
        ///
        /// <remarks>
        ///   Upon the first call to <see cref="EnqueueEventAsync(EventData, EnqueueEventOptions, CancellationToken)" /> or
        ///   <see cref="EnqueueEventsAsync(IEnumerable{EventData}, EnqueueEventOptions, CancellationToken)" />, the <see cref="SendEventBatchSucceededAsync" /> and
        ///   <see cref="SendEventBatchFailedAsync" /> handlers will be validated and can no longer be changed.
        /// </remarks>
        ///
        public virtual Task<int> EnqueueEventAsync(EventData eventData,
                                                   EnqueueEventOptions options,
                                                   CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
        ///
        /// <remarks>
        ///   Upon the first call to <see cref="EnqueueEventAsync(EventData, EnqueueEventOptions, CancellationToken)" /> or <see cref="EnqueueEventsAsync(IEnumerable{EventData}, EnqueueEventOptions, CancellationToken)" />, the <see cref="SendEventBatchSucceededAsync" /> and
        ///   <see cref="SendEventBatchFailedAsync" /> handlers will be validated and can no longer be changed.
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
        ///
        /// <remarks>
        ///   Upon the first call to <see cref="EnqueueEventAsync(EventData, EnqueueEventOptions, CancellationToken)" /> or <see cref="EnqueueEventsAsync(IEnumerable{EventData}, EnqueueEventOptions, CancellationToken)" />, the <see cref="SendEventBatchSucceededAsync" /> and
        ///   <see cref="SendEventBatchFailedAsync" /> handlers will be validated and can no longer be changed.
        /// </remarks>
        ///
        public virtual Task<int> EnqueueEventsAsync(IEnumerable<EventData> events,
                                                    EnqueueEventOptions options,
                                                    CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
                await FlushInternalAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                // If we reached the try block without an exception, it is safe to assume the guard is held.

                _stateGuard.Release();
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

            var guardHeld = false;

            try
            {
                if (!_stateGuard.Wait(0, cancellationToken))
                {
                    await _stateGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                }

                // If we've reached this point without an exception, the guard is held.

                guardHeld = true;

                if (_isClosed)
                {
                    return;
                }

                _isClosed = true;
                Logger.ClientCloseStart(nameof(EventHubBufferedProducerClient), EventHubName, Identifier);

                if (_isPublishing)
                {
                    try
                    {
                        if (flush)
                        {
                            await FlushInternalAsync(CancellationToken.None).ConfigureAwait(false);
                        }
                        else
                        {
                           await ClearInternalAsync(CancellationToken.None).ConfigureAwait(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        // This exception should be non-blocking; any failures for clearing are non-impactful; any failures
                        // when flushing will be surfaced via the event handler.  Log the exception, but continue closing.

                        Logger.ClientCloseError(nameof(EventHubBufferedProducerClient), EventHubName, Identifier, ex.Message);
                    }

                    //TODO: Stop publishing for real.

                    _isPublishing = false;
                }

                await _producer.CloseAsync(CancellationToken.None).ConfigureAwait(false);

                if (_sendSucceededHandler != null)
                {
                    SendEventBatchSucceededAsync -= _sendSucceededHandler;
                }

                if (_sendFailedHandler != null)
                {
                    SendEventBatchFailedAsync -= _sendFailedHandler;
                }
            }
            catch (Exception ex)
            {
                Logger.ClientCloseError(nameof(EventHubBufferedProducerClient), EventHubName, Identifier, ex.Message);
                throw;
            }
            finally
            {
                if (guardHeld)
                {
                    _stateGuard.Release();
                }

                Logger.ClientCloseComplete(nameof(EventHubBufferedProducerClient), EventHubName, Identifier);
            }
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
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
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
        ///   Cancels any active publishing and abandons all events in the buffer that are waiting to be published.
        ///   Upon completion of this method, the buffer will be empty.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        ///   This method will modify class-level state and should be synchronized.  It is assumed that callers hold responsibility for
        ///   ensuring synchronization concerns; this method should be invoked after any primitives have been acquired.
        ///
        ///   Callers are also assumed to own responsibility for any validation that the client is in the intended state before calling.
        /// </remarks>
        ///
        internal virtual Task ClearInternalAsync(CancellationToken cancellationToken = default)
        {
            //TODO: Implement Clear

            return Task.CompletedTask;
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
        ///   Callers are also assumed to own responsibility for any validation that the client is in the intended state before calling.
        /// </remarks>
        ///
        public virtual Task FlushInternalAsync(CancellationToken cancellationToken = default)
        {
            //TODO: Implement Flush

            return Task.CompletedTask;
        }

        /// <summary>
        ///   Responsible for raising the <see cref="SendEventBatchSucceededAsync"/> event upon the successful publishing
        ///   of a batch of events.
        /// </summary>
        ///
        /// <param name="events">The set of events belonging to the batch that was successfully published.</param>
        /// <param name="partitionId">The identifier of the partition that the batch of events was published to.</param>
        ///
        protected virtual Task OnSendSucceededAsync(IReadOnlyList<EventData> events,
                                                    string partitionId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Responsible for raising the <see cref="SendEventBatchFailedAsync"/> event upon the failed publishing of a
        ///   batch of events, after all eligible retries are exhausted.
        /// </summary>
        ///
        /// <param name="events">The set of events belonging to the batch that failed to be published.</param>
        /// <param name="exception">The <see cref="Exception"/> that was raised when the events failed to publish.</param>
        /// <param name="partitionId">The identifier of the partition that the batch of events was published to.</param>
        ///
        protected virtual Task OnSendFailedAsync(IReadOnlyList<EventData> events,
                                                 Exception exception,
                                                 string partitionId)
        {
            throw new NotImplementedException();
        }
    }
}
