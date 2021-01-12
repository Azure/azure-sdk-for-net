// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   A client responsible for publishing <see cref="EventData" /> to a specific Event Hub,
    ///   grouped together in batches.  Depending on the options specified when sending, events data
    ///   may be automatically routed to an available partition or sent to a specifically requested partition.
    /// </summary>
    ///
    /// <remarks>
    ///   <para>
    ///     Allowing automatic routing of partitions is recommended when:
    ///     <para>- The sending of events needs to be highly available.</para>
    ///     <para>- The event data should be evenly distributed among all available partitions.</para>
    ///   </para>
    ///
    ///   <para>
    ///     If no partition is specified, the following rules are used for automatically selecting one:
    ///     <para>1) Distribute the events equally amongst all available partitions using a round-robin approach.</para>
    ///     <para>2) If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
    ///   </para>
    ///
    ///   <para>
    ///     The <see cref="EventHubProducerClient" /> is safe to cache and use for the lifetime of an application, and that is best practice when the application
    ///     publishes events regularly or semi-regularly.  The producer holds responsibility for efficient resource management, working to keep resource usage low during
    ///     periods of inactivity and manage health during periods of higher use.  Calling either the <see cref="CloseAsync" /> or <see cref="DisposeAsync" />
    ///     method as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.
    ///   </para>
    /// </remarks>
    ///
    public class EventHubProducerClient : IAsyncDisposable
    {
        /// <summary>The maximum number of attempts that may be made to get a <see cref="TransportProducer" /> from the pool.</summary>
        internal const int MaximumCreateProducerAttempts = 3;

        /// <summary>The minimum allowable size, in bytes, for a batch to be sent.</summary>
        internal const int MinimumBatchSizeLimit = 24;

        /// <summary>The set of default publishing options to use when no specific options are requested.</summary>
        private static readonly SendEventOptions DefaultSendOptions = new SendEventOptions();

        /// <summary>Sets how long a dedicated <see cref="TransportProducer" /> would sit in memory before its <see cref="TransportProducerPool" /> would remove and close it.</summary>
        private static readonly TimeSpan PartitionProducerLifespan = TimeSpan.FromMinutes(5);

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the producer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Event Hub that the producer is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName => Connection.EventHubName;

        /// <summary>
        ///   Indicates whether or not this <see cref="EventHubProducerClient" /> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed
        {
            get => _closed;
            protected set => _closed = value;
        }

        /// <summary>
        ///   Indicates whether the client has ownership of the associated <see cref="EventHubConnection" />
        ///   and should take responsibility for managing its lifespan.
        /// </summary>
        ///
        private bool OwnsConnection { get; } = true;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The set of options to use with the <see cref="EventHubProducerClient" />  instance.
        /// </summary>
        ///
        private EventHubProducerClientOptions Options { get; }

        /// <summary>
        ///   The active connection to the Azure Event Hubs service, enabling client communications for metadata
        ///   about the associated Event Hub and access to a transport-aware producer.
        /// </summary>
        ///
        private EventHubConnection Connection { get; }

        /// <summary>
        ///   A <see cref="TransportProducerPool" /> used to manage a set of partition specific <see cref="TransportProducer" />.
        /// </summary>
        ///
        private TransportProducerPool PartitionProducerPool { get; }

        /// <summary>
        ///   The publishing-related state associated with partitions.
        /// </summary>
        ///
        /// <value>
        ///   Created if the producer has been configured with one or more features which requires
        ///   publishing to partitions in a stateful manner; otherwise, <c>null</c>.
        /// </value>
        ///
        private ConcurrentDictionary<string, PartitionPublishingState> PartitionState { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducerClient" /> class.
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
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string"/>
        ///
        public EventHubProducerClient(string connectionString) : this(connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="clientOptions">The set of options to use for this consumer.</param>
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
        public EventHubProducerClient(string connectionString,
                                      EventHubProducerClientOptions clientOptions) : this(connectionString, null, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string"/>
        ///
        public EventHubProducerClient(string connectionString,
                                      string eventHubName) : this(connectionString, eventHubName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string"/>
        ///
        public EventHubProducerClient(string connectionString,
                                      string eventHubName,
                                      EventHubProducerClientOptions clientOptions)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            clientOptions = clientOptions?.Clone() ?? new EventHubProducerClientOptions();

            OwnsConnection = true;
            Connection = new EventHubConnection(connectionString, eventHubName, clientOptions.ConnectionOptions);
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            Options = clientOptions;

            PartitionProducerPool = new TransportProducerPool(partitionId =>
                Connection.CreateTransportProducer(
                    partitionId,
                    clientOptions.CreateFeatureFlags(),
                    Options.GetPublishingOptionsOrDefaultForPartition(partitionId),
                    RetryPolicy));

            if (RequiresStatefulPartitions(clientOptions))
            {
                PartitionState = new ConcurrentDictionary<string, PartitionPublishingState>();
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="credential">The Event Hubs shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        internal EventHubProducerClient(string fullyQualifiedNamespace,
                                        string eventHubName,
                                        EventHubsSharedAccessKeyCredential credential,
                                        EventHubProducerClientOptions clientOptions = default)
        {
            Argument.AssertWellFormedEventHubsNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            clientOptions = clientOptions?.Clone() ?? new EventHubProducerClientOptions();

            OwnsConnection = true;
            Connection = new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential, clientOptions.ConnectionOptions);
            Options = clientOptions;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();

            PartitionProducerPool = new TransportProducerPool(partitionId =>
                Connection.CreateTransportProducer(
                    partitionId,
                    clientOptions.CreateFeatureFlags(),
                    Options.GetPublishingOptionsOrDefaultForPartition(partitionId),
                    RetryPolicy));

            if (RequiresStatefulPartitions(clientOptions))
            {
                PartitionState = new ConcurrentDictionary<string, PartitionPublishingState>();
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        public EventHubProducerClient(string fullyQualifiedNamespace,
                                      string eventHubName,
                                      TokenCredential credential,
                                      EventHubProducerClientOptions clientOptions = default)
        {
            Argument.AssertWellFormedEventHubsNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            clientOptions = clientOptions?.Clone() ?? new EventHubProducerClientOptions();

            OwnsConnection = true;
            Connection = new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential, clientOptions.ConnectionOptions);
            Options = clientOptions;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();

            PartitionProducerPool = new TransportProducerPool(partitionId =>
                Connection.CreateTransportProducer(
                    partitionId,
                    clientOptions.CreateFeatureFlags(),
                    Options.GetPublishingOptionsOrDefaultForPartition(partitionId),
                    RetryPolicy));

            if (RequiresStatefulPartitions(clientOptions))
            {
                PartitionState = new ConcurrentDictionary<string, PartitionPublishingState>();
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="EventHubConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        public EventHubProducerClient(EventHubConnection connection,
                                      EventHubProducerClientOptions clientOptions = default)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            clientOptions = clientOptions?.Clone() ?? new EventHubProducerClientOptions();

            OwnsConnection = false;
            Connection = connection;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            Options = clientOptions;

            PartitionProducerPool = new TransportProducerPool(partitionId =>
                Connection.CreateTransportProducer(
                    partitionId,
                    clientOptions.CreateFeatureFlags(),
                    Options.GetPublishingOptionsOrDefaultForPartition(partitionId),
                    RetryPolicy));

            if (RequiresStatefulPartitions(clientOptions))
            {
                PartitionState = new ConcurrentDictionary<string, PartitionPublishingState>();
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducerClient" /> class.
        /// </summary>
        ///
        /// <param name="connection">The connection to use as the basis for delegation of client-type operations.</param>
        /// <param name="transportProducer">The transport producer instance to use as the basis for service communication.</param>
        /// <param name="partitionProducerPool">A <see cref="TransportProducerPool" /> used to manage a set of partition specific <see cref="TransportProducer" />.</param>
        ///
        /// <remarks>
        ///   This constructor is intended to be used internally for functional
        ///   testing only.
        /// </remarks>
        ///
        internal EventHubProducerClient(EventHubConnection connection,
                                        TransportProducer transportProducer,
                                        TransportProducerPool partitionProducerPool = default)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(transportProducer, nameof(transportProducer));

            OwnsConnection = false;
            Connection = connection;
            RetryPolicy = new EventHubsRetryOptions().ToRetryPolicy();
            Options = new EventHubProducerClientOptions();
            PartitionProducerPool = partitionProducerPool ?? new TransportProducerPool(partitionId => transportProducer);

            if (RequiresStatefulPartitions(Options))
            {
                PartitionState = new ConcurrentDictionary<string, PartitionPublishingState>();
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProducerClient" /> class.
        /// </summary>
        ///
        protected EventHubProducerClient()
        {
            OwnsConnection = false;
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
            Argument.AssertNotClosed(IsClosed, nameof(EventHubProducerClient));
            return await Connection.GetPropertiesAsync(RetryPolicy, cancellationToken).ConfigureAwait(false);
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
            Argument.AssertNotClosed(IsClosed, nameof(EventHubProducerClient));
            return await Connection.GetPartitionIdsAsync(RetryPolicy, cancellationToken).ConfigureAwait(false);
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
            Argument.AssertNotClosed(IsClosed, nameof(EventHubProducerClient));
            return await Connection.GetPartitionPropertiesAsync(partitionId, RetryPolicy, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   A set of information about the state of publishing for a partition, as observed by the <see cref="EventHubProducerClient" />.  This
        ///   data can always be read, but will only be populated with information relevant to the active features for the producer client.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information about the publishing state of the requested partition, within the context of this producer.</returns>
        ///
        /// <remarks>
        ///   The state of a partition is only understood by the <see cref="EventHubProducerClient" /> after events have been published to that
        ///   partition; calling this method for a partition before events have been published to it will return an empty set of properties.
        /// </remarks>
        ///
        public virtual async Task<PartitionPublishingProperties> GetPartitionPublishingPropertiesAsync(string partitionId,
                                                                                                       CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(EventHubProducerClient));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            // If the producer does not require stateful partitions, return an empty
            // instance.

            if (!RequiresStatefulPartitions(Options))
            {
                return PartitionPublishingProperties.Empty;
            }

            // If the state has not yet been initialized, then do so now.

            var partitionState = PartitionState.GetOrAdd(partitionId, new PartitionPublishingState(partitionId));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            try
            {
                await partitionState.PublishingGuard.WaitAsync(cancellationToken).ConfigureAwait(false);

                if (!partitionState.IsInitialized)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await InitializePartitionStateAsync(partitionState, cancellationToken).ConfigureAwait(false);
                }

                return CreatePublishingPropertiesFromPartitionState(Options, partitionState);
            }
            finally
            {
                partitionState.PublishingGuard.Release();
            }
        }

        /// <summary>
        ///   Sends the <see cref="EventData" /> to the associated Event Hub.  To avoid the
        ///   overhead associated with measuring and validating the size in the client, validation will
        ///   be delegated to the Event Hubs service and is deferred until the operation is invoked.
        ///   The call will fail if the size of the specified <paramref name="eventData"/> exceeds the
        ///   maximum allowable size of a single event.
        /// </summary>
        ///
        /// <param name="eventData">The event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>
        ///   A task to be resolved on when the operation has completed; if no exception is thrown when awaited, the
        ///   Event Hubs service has acknowledge receipt and assumed responsibility for delivery of the event.
        /// </returns>
        ///
        /// <seealso cref="SendAsync(EventData, SendEventOptions, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{EventData}, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{EventData}, SendEventOptions, CancellationToken)" />
        /// <seealso cref="SendAsync(EventDataBatch, CancellationToken)" />
        ///
        internal virtual async Task SendAsync(EventData eventData,
                                              CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(eventData, nameof(eventData));
            await SendAsync(new[] { eventData }, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Sends the <see cref="EventData" /> to the associated Event Hub.  To avoid the
        ///   overhead associated with measuring and validating the size in the client, validation will
        ///   be delegated to the Event Hubs service and is deferred until the operation is invoked.
        ///   The call will fail if the size of the specified <paramref name="eventData"/> exceeds the
        ///   maximum allowable size of a single event.
        /// </summary>
        ///
        /// <param name="eventData">The event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>
        ///   A task to be resolved on when the operation has completed; if no exception is thrown when awaited, the
        ///   Event Hubs service has acknowledge receipt and assumed responsibility for delivery of the event.
        /// </returns>
        ///
        /// <seealso cref="SendAsync(EventData, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{EventData}, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{EventData}, SendEventOptions, CancellationToken)" />
        /// <seealso cref="SendAsync(EventDataBatch, CancellationToken)" />
        ///
        internal virtual async Task SendAsync(EventData eventData,
                                              SendEventOptions options,
                                              CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(eventData, nameof(eventData));
            await SendAsync(new[] { eventData }, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub as a single operation.  To avoid the
        ///   overhead associated with measuring and validating the size in the client, validation will
        ///   be delegated to the Event Hubs service and is deferred until the operation is invoked.
        ///   The call will fail if the size of the specified set of events exceeds the maximum allowable
        ///   size of a single batch.
        /// </summary>
        ///
        /// <param name="eventSet">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>
        ///   A task to be resolved on when the operation has completed; if no exception is thrown when awaited, the
        ///   Event Hubs service has acknowledge receipt and assumed responsibility for delivery of the set of events.
        /// </returns>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when the set of events exceeds the maximum size allowed in a single batch, as determined by the Event Hubs service.  The <see cref="EventHubsException.Reason" /> will be set to
        ///   <see cref="EventHubsException.FailureReason.MessageSizeExceeded"/> in this case.
        /// </exception>
        ///
        /// <remarks>
        ///   When published, the result is atomic; either all events that belong to the set were successful or all
        ///   have failed.  Partial success is not possible.
        /// </remarks>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, SendEventOptions, CancellationToken)" />
        /// <seealso cref="SendAsync(EventDataBatch, CancellationToken)" />
        /// <seealso cref="CreateBatchAsync(CancellationToken)" />
        ///
        public virtual async Task SendAsync(IEnumerable<EventData> eventSet,
                                            CancellationToken cancellationToken = default) => await SendAsync(eventSet, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Sends a set of events to the associated Event Hub as a single operation.  To avoid the
        ///   overhead associated with measuring and validating the size in the client, validation will
        ///   be delegated to the Event Hubs service and is deferred until the operation is invoked.
        ///   The call will fail if the size of the specified set of events exceeds the maximum allowable
        ///   size of a single batch.
        /// </summary>
        ///
        /// <param name="eventSet">The set of event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>
        ///   A task to be resolved on when the operation has completed; if no exception is thrown when awaited, the
        ///   Event Hubs service has acknowledge receipt and assumed responsibility for delivery of the set of events.
        /// </returns>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when the set of events exceeds the maximum size allowed in a single batch, as determined by the Event Hubs service.  The <see cref="EventHubsException.Reason" /> will be set to
        ///   <see cref="EventHubsException.FailureReason.MessageSizeExceeded"/> in this case.
        /// </exception>
        ///
        /// <remarks>
        ///   When published, the result is atomic; either all events that belong to the set were successful or all
        ///   have failed.  Partial success is not possible.
        /// </remarks>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, CancellationToken)" />
        /// <seealso cref="SendAsync(EventDataBatch, CancellationToken)" />
        /// <seealso cref="CreateBatchAsync(CreateBatchOptions, CancellationToken)" />
        ///
        public virtual async Task SendAsync(IEnumerable<EventData> eventSet,
                                            SendEventOptions options,
                                            CancellationToken cancellationToken = default)
        {
            options = options?.Clone() ?? DefaultSendOptions;

            Argument.AssertNotNull(eventSet, nameof(eventSet));
            AssertSinglePartitionReference(options.PartitionId, options.PartitionKey);

            var events = eventSet switch
            {
               IReadOnlyList<EventData> eventList => eventList,
               _ => eventSet.ToList()
            };

            if (events.Count == 0)
            {
                return;
            }

            var sendTask = (Options.EnableIdempotentPartitions)
                ? SendIdempotentAsync(events, options, cancellationToken)
                : SendInternalAsync(events, options, cancellationToken);

            await sendTask.ConfigureAwait(false);
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.
        /// </summary>
        ///
        /// <param name="eventBatch">The set of event data to send. A batch may be created using <see cref="CreateBatchAsync(CancellationToken)" />.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>
        ///   A task to be resolved on when the operation has completed; if no exception is thrown when awaited, the
        ///   Event Hubs service has acknowledge receipt and assumed responsibility for delivery of the batch.
        /// </returns>
        ///
        /// <remarks>
        ///   When published, the result is atomic; either all events that belong to the batch were successful or all
        ///   have failed.  Partial success is not possible.
        /// </remarks>
        ///
        /// <seealso cref="CreateBatchAsync(CancellationToken)" />
        ///
        public virtual async Task SendAsync(EventDataBatch eventBatch,
                                            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(eventBatch, nameof(eventBatch));
            AssertSinglePartitionReference(eventBatch.SendOptions.PartitionId, eventBatch.SendOptions.PartitionKey);

            if (eventBatch.Count == 0)
            {
                return;
            }

            var sendTask = (Options.EnableIdempotentPartitions)
                ? SendIdempotentAsync(eventBatch, cancellationToken)
                : SendInternalAsync(eventBatch, cancellationToken);

            await sendTask.ConfigureAwait(false);
        }

        /// <summary>
        ///   Creates a size-constraint batch to which <see cref="EventData" /> may be added using a try-based pattern.  If an event would
        ///   exceed the maximum allowable size of the batch, the batch will not allow adding the event and signal that scenario using its
        ///   return value.
        ///
        ///   Because events that would violate the size constraint cannot be added, publishing a batch will not trigger an exception when
        ///   attempting to send the events to the Event Hubs service.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="EventDataBatch" /> with the default batch options.</returns>
        ///
        /// <seealso cref="CreateBatchAsync(CreateBatchOptions, CancellationToken)" />
        /// <seealso cref="SendAsync(EventDataBatch, CancellationToken)" />
        ///
        public virtual async ValueTask<EventDataBatch> CreateBatchAsync(CancellationToken cancellationToken = default) => await CreateBatchAsync(null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Creates a size-constraint batch to which <see cref="EventData" /> may be added using a try-based pattern.  If an event would
        ///   exceed the maximum allowable size of the batch, the batch will not allow adding the event and signal that scenario using its
        ///   return value.
        ///
        ///   Because events that would violate the size constraint cannot be added, publishing a batch will not trigger an exception when
        ///   attempting to send the events to the Event Hubs service.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider when creating this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="EventDataBatch" /> with the requested <paramref name="options"/>.</returns>
        ///
        /// <seealso cref="CreateBatchAsync(CancellationToken)" />
        /// <seealso cref="SendAsync(EventDataBatch, CancellationToken)" />
        ///
        public virtual async ValueTask<EventDataBatch> CreateBatchAsync(CreateBatchOptions options,
                                                                        CancellationToken cancellationToken = default)
        {
            options = options?.Clone() ?? new CreateBatchOptions();
            AssertSinglePartitionReference(options.PartitionId, options.PartitionKey);

            TransportEventBatch transportBatch = await PartitionProducerPool.EventHubProducer.CreateBatchAsync(options, cancellationToken).ConfigureAwait(false);
            return new EventDataBatch(transportBatch, FullyQualifiedNamespace, EventHubName, options);
        }

        /// <summary>
        ///   Closes the producer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            if (IsClosed)
            {
                return;
            }

            IsClosed = true;

            var identifier = GetHashCode().ToString(CultureInfo.InvariantCulture);
            EventHubsEventSource.Log.ClientCloseStart(nameof(EventHubProducerClient), EventHubName, identifier);

            // Attempt to close the pool of producers.  In the event that an exception is encountered,
            // it should not impact the attempt to close the connection, assuming ownership.

            var transportProducerPoolException = default(Exception);

            try
            {
                await PartitionProducerPool.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ClientCloseError(nameof(EventHubProducerClient), EventHubName, identifier, ex.Message);
                transportProducerPoolException = ex;
            }

            // An exception when closing the connection supersedes one observed when closing the
            // individual transport clients.

            try
            {
                if (OwnsConnection)
                {
                    await Connection.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ClientCloseError(nameof(EventHubProducerClient), EventHubName, identifier, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseComplete(nameof(EventHubProducerClient), EventHubName, identifier);
            }

            // If there was an active exception pending from closing the
            // transport producer pool, surface it now.

            if (transportProducerPoolException != default)
            {
                ExceptionDispatchInfo.Capture(transportProducerPoolException).Throw();
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventHubProducerClient" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync()
        {
            await CloseAsync().ConfigureAwait(false);
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
        ///   Sends a set of events to the associated Event Hub using a batched approach.  Because the batch is implicitly created, the size of the event set is not
        ///   validated until this method is invoked.  The call will fail if the size of the specified set of events exceeds the maximum allowable size of a single batch.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        private async Task SendInternalAsync(IReadOnlyList<EventData> events,
                                             SendEventOptions options,
                                             CancellationToken cancellationToken = default)
        {
            var attempts = 0;
            var diagnosticIdentifiers = new List<string>();

            InstrumentMessages(events);

            foreach (var eventData in events)
            {
                if (EventDataInstrumentation.TryExtractDiagnosticId(eventData, out var identifier))
                {
                    diagnosticIdentifiers.Add(identifier);
                }
            }

            using DiagnosticScope scope = CreateDiagnosticScope(diagnosticIdentifiers);

            var pooledProducer = PartitionProducerPool.GetPooledProducer(options.PartitionId, PartitionProducerLifespan);

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await using var _ = pooledProducer.ConfigureAwait(false);
                    await pooledProducer.TransportProducer.SendAsync(events, options, cancellationToken).ConfigureAwait(false);

                    return;
                }
                catch (EventHubsException eventHubException)
                    when (eventHubException.Reason == EventHubsException.FailureReason.ClientClosed && ShouldRecreateProducer(pooledProducer.TransportProducer, options.PartitionId))
                {
                    if (++attempts >= MaximumCreateProducerAttempts)
                    {
                        scope.Failed(eventHubException);
                        throw;
                    }

                    pooledProducer = PartitionProducerPool.GetPooledProducer(options.PartitionId, PartitionProducerLifespan);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            throw new TaskCanceledException();
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.
        /// </summary>
        ///
        /// <param name="eventBatch">The set of event data to send. A batch may be created using <see cref="CreateBatchAsync(CancellationToken)" />.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        private async Task SendInternalAsync(EventDataBatch eventBatch,
                                             CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = CreateDiagnosticScope(eventBatch.GetEventDiagnosticIdentifiers());

            var attempts = 0;
            var pooledProducer = PartitionProducerPool.GetPooledProducer(eventBatch.SendOptions.PartitionId, PartitionProducerLifespan);

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        await using var _ = pooledProducer.ConfigureAwait(false);

                        eventBatch.Lock();
                        await pooledProducer.TransportProducer.SendAsync(eventBatch, cancellationToken).ConfigureAwait(false);

                        return;
                    }
                    catch (EventHubsException eventHubException)
                        when (eventHubException.Reason == EventHubsException.FailureReason.ClientClosed && ShouldRecreateProducer(pooledProducer.TransportProducer, eventBatch.SendOptions.PartitionId))
                    {
                        if (++attempts >= MaximumCreateProducerAttempts)
                        {
                            scope.Failed(eventHubException);
                            throw;
                        }

                        pooledProducer = PartitionProducerPool.GetPooledProducer(eventBatch.SendOptions.PartitionId, PartitionProducerLifespan);
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }
            }
            finally
            {
                eventBatch.Unlock();
            }

            throw new TaskCanceledException();
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  Because the batch is implicitly created, the size of the event set is not
        ///   validated until this method is invoked.  The call will fail if the size of the specified set of events exceeds the maximum allowable size of a single batch.
        /// </summary>
        ///
        /// <param name="eventSet">The set of event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        private async Task SendIdempotentAsync(IReadOnlyList<EventData> eventSet,
                                               SendEventOptions options,
                                               CancellationToken cancellationToken = default)
        {
            AssertPartitionIsReferenced(options.PartitionId);
            AssertIdempotentEventsNotPublished(eventSet);

            try
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                EventHubsEventSource.Log.IdempotentPublishStart(EventHubName, options.PartitionId);

                var partitionState = PartitionState.GetOrAdd(options.PartitionId, new PartitionPublishingState(options.PartitionId));

                try
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    await partitionState.PublishingGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                    EventHubsEventSource.Log.IdempotentSynchronizationAcquire(EventHubName, options.PartitionId);

                    // Ensure that the partition state has been initialized.

                    if (!partitionState.IsInitialized)
                    {
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                        await InitializePartitionStateAsync(partitionState, cancellationToken).ConfigureAwait(false);
                    }

                    // Sequence the events for publishing.

                    var lastSequence = partitionState.LastPublishedSequenceNumber.Value;
                    var firstSequence = lastSequence;

                    foreach (var eventData in eventSet)
                    {
                        lastSequence = NextSequence(lastSequence);
                        eventData.PendingPublishSequenceNumber = lastSequence;
                        eventData.PendingProducerGroupId = partitionState.ProducerGroupId;
                        eventData.PendingProducerOwnerLevel = partitionState.OwnerLevel;
                    }

                    // Publish the events.

                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    EventHubsEventSource.Log.IdempotentSequencePublish(EventHubName, options.PartitionId, firstSequence, lastSequence);
                    await SendInternalAsync(eventSet, options, cancellationToken).ConfigureAwait(false);

                    // Update state and commit the state.

                    EventHubsEventSource.Log.IdempotentSequenceUpdate(EventHubName, options.PartitionId, partitionState.LastPublishedSequenceNumber.Value, lastSequence);
                    partitionState.LastPublishedSequenceNumber = lastSequence;

                    foreach (var eventData in eventSet)
                    {
                        eventData.CommitPublishingState();
                    }
                }
                catch
                {
                    // Clear the pending state in the face of an exception.

                    foreach (var eventData in eventSet)
                    {
                        eventData.ClearPublishingState();
                    }

                    throw;
                }
                finally
                {
                    partitionState.PublishingGuard.Release();
                    EventHubsEventSource.Log.IdempotentSynchronizationRelease(EventHubName, options.PartitionId);
                }
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.IdempotentPublishError(EventHubName, options.PartitionId, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.IdempotentPublishComplete(EventHubName, options.PartitionId);
            }
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.
        /// </summary>
        ///
        /// <param name="eventBatch">The set of event data to send. A batch may be created using <see cref="CreateBatchAsync(CancellationToken)" />.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        private async Task SendIdempotentAsync(EventDataBatch eventBatch,
                                               CancellationToken cancellationToken = default)
        {
            var options = eventBatch.SendOptions;

            AssertPartitionIsReferenced(options.PartitionId);
            AssertIdempotentBatchNotPublished(eventBatch);

            try
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                EventHubsEventSource.Log.IdempotentPublishStart(EventHubName, options.PartitionId);

                var partitionState = PartitionState.GetOrAdd(options.PartitionId, new PartitionPublishingState(options.PartitionId));

                var eventSet = eventBatch.AsEnumerable<EventData>() switch
                {
                    IReadOnlyList<EventData> eventList => eventList,
                    IEnumerable<EventData> eventEnumerable => eventEnumerable.ToList()
                };

                try
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    await partitionState.PublishingGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                    EventHubsEventSource.Log.IdempotentSynchronizationAcquire(EventHubName, options.PartitionId);

                    // Ensure that the partition state has been initialized.

                    if (!partitionState.IsInitialized)
                    {
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                        await InitializePartitionStateAsync(partitionState, cancellationToken).ConfigureAwait(false);
                    }

                    // Sequence the events for publishing.

                    var lastSequence = partitionState.LastPublishedSequenceNumber.Value;
                    var firstSequence = NextSequence(lastSequence);

                    foreach (var eventData in eventSet)
                    {
                        lastSequence = NextSequence(lastSequence);
                        eventData.PendingPublishSequenceNumber = lastSequence;
                        eventData.PendingProducerGroupId = partitionState.ProducerGroupId;
                        eventData.PendingProducerOwnerLevel = partitionState.OwnerLevel;
                    }

                    // Publish the events.

                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    EventHubsEventSource.Log.IdempotentSequencePublish(EventHubName, options.PartitionId, firstSequence, lastSequence);
                    await SendInternalAsync(eventBatch, cancellationToken).ConfigureAwait(false);

                    // Update state and commit the sequencing.  This needs only to happen at the batch level, as the contained
                    // events are not accessible by callers.

                    EventHubsEventSource.Log.IdempotentSequenceUpdate(EventHubName, options.PartitionId, partitionState.LastPublishedSequenceNumber.Value, lastSequence);
                    partitionState.LastPublishedSequenceNumber = lastSequence;
                    eventBatch.StartingPublishedSequenceNumber = firstSequence;
                }
                catch
                {
                    // Clear the pending sequence numbers in the face of an exception.

                    foreach (var eventData in eventSet)
                    {
                        eventData.ClearPublishingState();
                    }

                    throw;
                }
                finally
                {
                    partitionState.PublishingGuard.Release();
                    EventHubsEventSource.Log.IdempotentSynchronizationRelease(EventHubName, options.PartitionId);
                }
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.IdempotentPublishError(EventHubName, options.PartitionId, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.IdempotentPublishComplete(EventHubName, options.PartitionId);
            }
        }

        /// <summary>
        ///   Initializes state instance for a given partition.
        /// </summary>
        ///
        /// <param name="partitionState">The state of the partition to be initialized.  This parameter will be mutated by this call.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        ///   The <paramref name="partitionState"/> parameter will be mutated by this call.  To avoid duplicate initialization or state corruption, this
        ///   method should only be called while the <see cref="PartitionPublishingState.PublishingGuard" /> primitive of the state instance is held.
        /// </remarks>
        ///
        private async Task InitializePartitionStateAsync(PartitionPublishingState partitionState,
                                                         CancellationToken cancellationToken = default)
        {
            if (partitionState.IsInitialized)
            {
                return;
            }

            var attempts = 0;
            var pooledProducer = PartitionProducerPool.GetPooledProducer(partitionState.PartitionId, PartitionProducerLifespan);

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await using var _ = pooledProducer.ConfigureAwait(false);
                    var properties = await pooledProducer.TransportProducer.ReadInitializationPublishingPropertiesAsync(cancellationToken).ConfigureAwait(false);

                    partitionState.ProducerGroupId = properties.ProducerGroupId;
                    partitionState.OwnerLevel = properties.OwnerLevel;
                    partitionState.LastPublishedSequenceNumber = properties.LastPublishedSequenceNumber;

                    // If the state was not initialized and no exception has occurred, then the service is behaving
                    // unexpectedly and the client should be considered invalid.

                    if (!partitionState.IsInitialized)
                    {
                        throw new EventHubsException(false, EventHubName, EventHubsException.FailureReason.InvalidClientState);
                    }

                    EventHubsEventSource.Log.IdempotentPublishInitializeState(
                        EventHubName,
                        partitionState.PartitionId,
                        partitionState.ProducerGroupId.Value,
                        partitionState.OwnerLevel.Value,
                        partitionState.LastPublishedSequenceNumber.Value);

                    return;
                }
                catch (EventHubsException eventHubException)
                    when (eventHubException.Reason == EventHubsException.FailureReason.ClientClosed && ShouldRecreateProducer(pooledProducer.TransportProducer, partitionState.PartitionId))
                {
                    if (++attempts >= MaximumCreateProducerAttempts)
                    {
                        throw;
                    }

                    pooledProducer = PartitionProducerPool.GetPooledProducer(partitionState.PartitionId, PartitionProducerLifespan);
                }
            }

            throw new TaskCanceledException();
        }

        /// <summary>
        ///   Creates and configures a diagnostics scope to be used for instrumenting
        ///   events.
        /// </summary>
        ///
        /// <param name="diagnosticIdentifiers">The set of diagnostic identifiers to which the scope will be linked.</param>
        ///
        /// <returns>The requested <see cref="DiagnosticScope" />.</returns>
        ///
        private DiagnosticScope CreateDiagnosticScope(IEnumerable<string> diagnosticIdentifiers)
        {
            DiagnosticScope scope = EventDataInstrumentation.ScopeFactory.CreateScope(DiagnosticProperty.ProducerActivityName);
            scope.AddAttribute(DiagnosticProperty.KindAttribute, DiagnosticProperty.ClientKind);
            scope.AddAttribute(DiagnosticProperty.ServiceContextAttribute, DiagnosticProperty.EventHubsServiceContext);
            scope.AddAttribute(DiagnosticProperty.EventHubAttribute, EventHubName);
            scope.AddAttribute(DiagnosticProperty.EndpointAttribute, FullyQualifiedNamespace);

            if (scope.IsEnabled)
            {
                foreach (var identifier in diagnosticIdentifiers)
                {
                    scope.AddLink(identifier);
                }
            }

            scope.Start();

            return scope;
        }

        /// <summary>
        ///   Performs the actions needed to instrument a set of events.
        /// </summary>
        ///
        /// <param name="events">The events to instrument.</param>
        ///
        private void InstrumentMessages(IEnumerable<EventData> events)
        {
            foreach (EventData eventData in events)
            {
                EventDataInstrumentation.InstrumentEvent(eventData, FullyQualifiedNamespace, EventHubName);
            }
        }

        /// <summary>
        ///   Checks if the <see cref="TransportProducer" /> returned by the <see cref="TransportProducerPool" /> is still open.
        /// </summary>
        ///
        /// <param name="producer">The <see cref="TransportProducer" /> that has being checked.</param>
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="TransportProducer" /> is closed; otherwise, <c>false</c>.</returns>
        ///
        private bool ShouldRecreateProducer(TransportProducer producer,
                                            string partitionId) => !string.IsNullOrEmpty(partitionId)
                                                                   && producer.IsClosed
                                                                   && !IsClosed
                                                                   && !Connection.IsClosed;

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
        ///   Ensures that a partition reference is active and the request is not for publishing
        ///   to the Event Hubs gateway.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition to which the producer is bound.</param>
        ///
        private static void AssertPartitionIsReferenced(string partitionId)
        {
            if (string.IsNullOrEmpty(partitionId))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotPublishToGateway, partitionId));
            }
        }

        /// <summary>
        ///   Ensures that a batch of events has not been previously acknowledged by the Event Hubs
        ///   service as having been successfully published.
        /// </summary>
        ///
        /// <param name="batch">The <see cref="EventDataBatch" /> to consider.</param>
        ///
        private static void AssertIdempotentBatchNotPublished(EventDataBatch batch)
        {
            if ((batch.StartingPublishedSequenceNumber.HasValue)
                || (batch.AsEnumerable<EventData>().Any(eventData => eventData.PublishedSequenceNumber.HasValue)))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.IdempotentAlreadyPublished));
            }
        }

        /// <summary>
        ///   Ensures that a batch of events has not been previously acknowledged by the Event Hubs
        ///   service as having been successfully published.
        /// </summary>
        ///
        /// <param name="eventSet">The set of <see cref="EventData" /> to consider.</param>
        ///
        private static void AssertIdempotentEventsNotPublished(IEnumerable<EventData> eventSet)
        {
            foreach (var eventData in eventSet)
            {
                if (eventData.PublishedSequenceNumber.HasValue)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.IdempotentAlreadyPublished));
                }
            }
        }

        /// <summary>
        ///   Calculates the next sequence number based on the current sequence number.
        /// </summary>
        ///
        /// <param name="currentSequence">The current sequence number to consider.</param>
        ///
        /// <returns>The next sequence number, in proper order.</returns>
        ///
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int NextSequence(int currentSequence)
        {
            if (unchecked(++currentSequence) < 0)
            {
                currentSequence = 0;
            }

            return currentSequence;
        }

        /// <summary>
        ///   Indicates whether publishing requires stateful partitions.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for making the determination.</param>
        ///
        /// <returns><c>true</c> if publishing is stateful; otherwise, <c>false</c>.</returns>
        ///
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool RequiresStatefulPartitions(EventHubProducerClientOptions options) => options.EnableIdempotentPartitions;

        /// <summary>
        ///   Creates a set of publishing properties based on the configuration of a producer and the current
        ///   partition publishing state.
        /// </summary>
        ///
        /// <param name="options">The options that describe the configuration of the producer.</param>
        /// <param name="state">The current state of publishing for the partition, as observed by the producer..</param>
        ///
        /// <returns>The set of properties that represents the current state.</returns>
        ///
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PartitionPublishingProperties CreatePublishingPropertiesFromPartitionState(EventHubProducerClientOptions options,
                                                                                                  PartitionPublishingState state) =>
                    new PartitionPublishingProperties(options.EnableIdempotentPartitions,
                                                      state.ProducerGroupId,
                                                      state.OwnerLevel,
                                                      state.LastPublishedSequenceNumber);
    }
}
