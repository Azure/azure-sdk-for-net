﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
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
    ///   Allowing automatic routing of partitions is recommended when:
    ///   <para>- The sending of events needs to be highly available.</para>
    ///   <para>- The event data should be evenly distributed among all available partitions.</para>
    ///
    ///   If no partition is specified, the following rules are used for automatically selecting one:
    ///   <para>1) Distribute the events equally amongst all available partitions using a round-robin approach.</para>
    ///   <para>2) If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
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
        public bool IsClosed { get; protected set; } = false;

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
            PartitionProducerPool = new TransportProducerPool(Connection, RetryPolicy);
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
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            PartitionProducerPool = new TransportProducerPool(Connection, RetryPolicy);
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
            PartitionProducerPool = new TransportProducerPool(Connection, RetryPolicy);
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
            PartitionProducerPool = partitionProducerPool ?? new TransportProducerPool(Connection, RetryPolicy, eventHubProducer: transportProducer);
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
        ///   Sends an event to the associated Event Hub using a batched approach.  If the size of the event exceeds the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="eventData">The event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
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
        ///   Sends an event to the associated Event Hub using a batched approach.  If the size of the event exceeds the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="eventData">The event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
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
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, SendEventOptions, CancellationToken)"/>
        ///
        internal virtual async Task SendAsync(IEnumerable<EventData> events,
                                              CancellationToken cancellationToken = default) => await SendAsync(events, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(EventData, CancellationToken)" />
        /// <seealso cref="SendAsync(EventData, SendEventOptions, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{EventData}, CancellationToken)" />
        /// <seealso cref="SendAsync(EventDataBatch, CancellationToken)" />
        ///
        internal virtual async Task SendAsync(IEnumerable<EventData> events,
                                              SendEventOptions options,
                                              CancellationToken cancellationToken = default)
        {
            options ??= DefaultSendOptions;

            Argument.AssertNotNull(events, nameof(events));
            AssertSinglePartitionReference(options.PartitionId, options.PartitionKey);

            int attempts = 0;

            events = (events as IList<EventData>) ?? events.ToList();
            InstrumentMessages(events);

            var diagnosticIdentifiers = new List<string>();

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
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(EventData, CancellationToken)" />
        /// <seealso cref="SendAsync(EventData, SendEventOptions, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{EventData}, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{EventData}, SendEventOptions, CancellationToken)" />
        /// <seealso cref="CreateBatchAsync(CancellationToken)" />
        ///
        public virtual async Task SendAsync(EventDataBatch eventBatch,
                                            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(eventBatch, nameof(eventBatch));
            AssertSinglePartitionReference(eventBatch.SendOptions.PartitionId, eventBatch.SendOptions.PartitionKey);

            int attempts = 0;
            using DiagnosticScope scope = CreateDiagnosticScope(eventBatch.GetEventDiagnosticIdentifiers());

            var pooledProducer = PartitionProducerPool.GetPooledProducer(eventBatch.SendOptions.PartitionId, PartitionProducerLifespan);

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
                finally
                {
                    eventBatch.Unlock();
                }
            }

            throw new TaskCanceledException();
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
        /// <seealso cref="CreateBatchAsync(CreateBatchOptions, CancellationToken)" />
        ///
        public virtual async ValueTask<EventDataBatch> CreateBatchAsync(CreateBatchOptions options,
                                                                        CancellationToken cancellationToken = default)
        {
            options = options?.Clone() ?? new CreateBatchOptions();
            AssertSinglePartitionReference(options.PartitionId, options.PartitionKey);

            TransportEventBatch transportBatch = await PartitionProducerPool.EventHubProducer.CreateBatchAsync(options, cancellationToken).ConfigureAwait(false);
            return new EventDataBatch(transportBatch, FullyQualifiedNamespace, EventHubName, options.ToSendOptions());
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

            var identifier = GetHashCode().ToString();
            EventHubsEventSource.Log.ClientCloseStart(typeof(EventHubProducerClient), EventHubName, identifier);

            // Attempt to close the pool of producers.  In the event that an exception is encountered,
            // it should not impact the attempt to close the connection, assuming ownership.

            var transportProducerPoolException = default(Exception);

            try
            {
                await PartitionProducerPool.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ClientCloseError(typeof(EventHubProducerClient), EventHubName, identifier, ex.Message);
                transportProducerPoolException = ex;
            }

            // An exception when closing the connection supersedes one observed when closing the
            // individual transport clients.

            try
            {
                if (OwnsConnection)
                {
                    await Connection.CloseAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ClientCloseError(typeof(EventHubProducerClient), EventHubName, identifier, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseComplete(typeof(EventHubProducerClient), EventHubName, identifier);
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
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotSendWithPartitionIdAndPartitionKey, partitionId));
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
    }
}
