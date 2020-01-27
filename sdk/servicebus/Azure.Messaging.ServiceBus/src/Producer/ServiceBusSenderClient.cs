// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus.Producer
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
    public class ServiceBusSenderClient : IAsyncDisposable
    {
        /// <summary>The minimum allowable size, in bytes, for a batch to be sent.</summary>
        internal const int MinimumBatchSizeLimit = 24;

        /// <summary>The set of default publishing options to use when no specific options are requested.</summary>
        private static readonly SendEventOptions DefaultSendOptions = new SendEventOptions();

        /// <summary>
        ///   The fully qualified Service Bus namespace that the producer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the entity that the producer is connected to, specific to the
        ///   Service Bus namespace that contains it.
        /// </summary>
        ///
        public string EntityName => Connection.EntityName;

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusSenderClient"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed { get; protected set; } = false;

        /// <summary>
        ///   Indicates whether the client has ownership of the associated <see cref="ServiceBusConnection" />
        ///   and should take responsibility for managing its lifespan.
        /// </summary>
        ///
        private bool OwnsConnection { get; } = true;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private ServiceBusRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The active connection to the Azure Event Hubs service, enabling client communications for metadata
        ///   about the associated Event Hub and access to a transport-aware producer.
        /// </summary>
        ///
        private ServiceBusConnection Connection { get; }

        /// <summary>
        ///   An abstracted Event Hub transport-specific producer that is associated with the
        ///   Event Hub gateway rather than a specific partition; intended to perform delegated operations.
        /// </summary>
        ///
        private TransportSender ServiceBusSender { get; }

        /// <summary>
        ///   The set of active Event Hub transport-specific producers created by this client which are specific to
        ///   a given partition; intended to perform delegated operations.
        /// </summary>
        ///
        private ConcurrentDictionary<string, TransportSender> PartitionProducers { get; } = new ConcurrentDictionary<string, TransportSender>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
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
        public ServiceBusSenderClient(string connectionString) : this(connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
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
        public ServiceBusSenderClient(string connectionString, ServiceBusSenderClientOptions clientOptions)
            : this(connectionString, null, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="entityName">The name of the specific Event Hub to associate the producer with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="entityName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public ServiceBusSenderClient(string connectionString, string entityName)
            : this(connectionString, entityName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="entityName">The name of the specific Event Hub to associate the producer with.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="entityName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public ServiceBusSenderClient(string connectionString,
                                      string entityName,
                                      ServiceBusSenderClientOptions clientOptions)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            clientOptions = clientOptions?.Clone() ?? new ServiceBusSenderClientOptions();

            OwnsConnection = true;
            Connection = new ServiceBusConnection(connectionString, entityName, clientOptions.ConnectionOptions);
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            ServiceBusSender = Connection.CreateTransportProducer(null, RetryPolicy);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associated the producer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        public ServiceBusSenderClient(string fullyQualifiedNamespace,
                                      string eventHubName,
                                      TokenCredential credential,
                                      ServiceBusSenderClientOptions clientOptions = default)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));

            clientOptions = clientOptions?.Clone() ?? new ServiceBusSenderClientOptions();

            OwnsConnection = true;
            Connection = new ServiceBusConnection(fullyQualifiedNamespace, eventHubName, credential, clientOptions.ConnectionOptions);
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            ServiceBusSender = Connection.CreateTransportProducer(null, RetryPolicy);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Event Hubs service.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        public ServiceBusSenderClient(ServiceBusConnection connection,
                                      ServiceBusSenderClientOptions clientOptions = default)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            clientOptions = clientOptions?.Clone() ?? new ServiceBusSenderClientOptions();

            OwnsConnection = false;
            Connection = connection;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            ServiceBusSender = Connection.CreateTransportProducer(null, RetryPolicy);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connection">The connection to use as the basis for delegation of client-type operations.</param>
        /// <param name="transportProducer">The transport producer instance to use as the basis for service communication.</param>
        ///
        /// <remarks>
        ///   This constructor is intended to be used internally for functional
        ///   testing only.
        /// </remarks>
        ///
        internal ServiceBusSenderClient(ServiceBusConnection connection,
                                        TransportSender transportProducer)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(transportProducer, nameof(transportProducer));

            OwnsConnection = false;
            Connection = connection;
            ServiceBusSender = transportProducer;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        protected ServiceBusSenderClient()
        {
            OwnsConnection = false;
        }

        /// <summary>
        ///   Retrieves information about the Event Hub that the connection is associated with, including
        ///   the number of partitions present and their identifiers.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the Event Hub that this client is associated with.</returns>
        ///
        public virtual Task<EventHubProperties> GetEventHubPropertiesAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSenderClient));
            return Connection.GetPropertiesAsync(RetryPolicy, cancellationToken);
        }

        /// <summary>
        ///   Retrieves the set of identifiers for the partitions of an Event Hub.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of identifiers for the partitions within the Event Hub that this client is associated with.</returns>
        ///
        /// <remarks>
        ///   This method is synonymous with invoking <see cref="GetEventHubPropertiesAsync(CancellationToken)" /> and reading the <see cref="EventHubProperties.PartitionIds"/>
        ///   property that is returned. It is offered as a convenience for quick access to the set of partition identifiers for the associated Event Hub.
        ///   No new or extended information is presented.
        /// </remarks>
        ///
        public virtual Task<string[]> GetPartitionIdsAsync(CancellationToken cancellationToken = default)
        {

            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSenderClient));
            return Connection.GetPartitionIdsAsync(RetryPolicy, cancellationToken);
        }

        /// <summary>
        ///   Retrieves information about a specific partition for an Event Hub, including elements that describe the available
        ///   events in the partition event stream.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the requested partition under the Event Hub this client is associated with.</returns>
        ///
        public virtual Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                             CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSenderClient));
            return Connection.GetPartitionPropertiesAsync(partitionId, RetryPolicy, cancellationToken);
        }

        /// <summary>
        ///   Sends an event to the associated Event Hub using a batched approach.  If the size of the event exceeds the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="message">The event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(ServiceBusMessage, SendEventOptions, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{ServiceBusMessage}, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{ServiceBusMessage}, SendEventOptions, CancellationToken)" />
        ///
        internal virtual Task SendAsync(ServiceBusMessage message,
                                        CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            return SendAsync(new[] { message }, null, cancellationToken);
        }

        /// <summary>
        ///   Sends an event to the associated Event Hub using a batched approach.  If the size of the event exceeds the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="message">The event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(ServiceBusMessage, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{ServiceBusMessage}, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{ServiceBusMessage}, SendEventOptions, CancellationToken)" />
        ///
        internal virtual Task SendAsync(ServiceBusMessage message,
                                        SendEventOptions options,
                                        CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            return SendAsync(new[] { message }, options, cancellationToken);
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="messages">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(IEnumerable{ServiceBusMessage}, SendEventOptions, CancellationToken)"/>
        ///
        public virtual Task SendAsync(
            IEnumerable<ServiceBusMessage> messages,
            CancellationToken cancellationToken = default) =>
            SendAsync(messages, null, cancellationToken);

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="messages">The set of event data to send.</param>
        /// <param name="options">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(ServiceBusMessage, CancellationToken)" />
        /// <seealso cref="SendAsync(ServiceBusMessage, SendEventOptions, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{ServiceBusMessage}, CancellationToken)" />
        ///
        internal virtual async Task SendAsync(IEnumerable<ServiceBusMessage> messages,
                                              SendEventOptions options,
                                              CancellationToken cancellationToken = default)
        {
            options ??= DefaultSendOptions;

            Argument.AssertNotNull(messages, nameof(messages));
            AssertSinglePartitionReference(options.PartitionId, options.PartitionKey);

            // Determine the transport producer to delegate the send operation to.  Because sending to a specific
            // partition requires a dedicated client, use (or create) that client if a partition was specified.  Otherwise
            // the default gateway producer can be used to request automatic routing from the Event Hubs service gateway.

            TransportSender activeSender;

            if (string.IsNullOrEmpty(options.PartitionId))
            {
                activeSender = ServiceBusSender;
            }
            else
            {
                // This assertion is intended as an additional check, not as a guarantee.  There still exists a benign
                // race condition where a transport producer may be created after the client has been closed; in this case
                // the transport producer will be force-closed with the associated connection or, worst case, will close once
                // its idle timeout period elapses.

                Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSenderClient));
                activeSender = PartitionProducers.GetOrAdd(options.PartitionId, id => Connection.CreateTransportProducer(id, RetryPolicy));
            }

            using DiagnosticScope scope = CreateDiagnosticScope();

            messages = messages.ToList();
            InstrumentMessages(messages);

            try
            {
                await activeSender.SendAsync(messages, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        ///// <summary>
        /////   Sends a set of events to the associated Event Hub using a batched approach.
        ///// </summary>
        /////
        ///// <param name="eventBatch">The set of event data to send. A batch may be created using <see cref="CreateBatchAsync(CancellationToken)" />.</param>
        ///// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /////
        ///// <returns>A task to be resolved on when the operation has completed.</returns>
        /////
        ///// <seealso cref="SendAsync(Message, CancellationToken)" />
        ///// <seealso cref="SendAsync(Message, SendEventOptions, CancellationToken)" />
        ///// <seealso cref="SendAsync(IEnumerable{Message}, CancellationToken)" />
        ///// <seealso cref="SendAsync(IEnumerable{Message}, SendEventOptions, CancellationToken)" />
        ///// <seealso cref="CreateBatchAsync(CancellationToken)" />
        /////
        //public virtual async Task SendAsync(IEnumerable<Message> messages,
        //                                    CancellationToken cancellationToken = default)
        //{
        //    Argument.AssertNotNull(messages, nameof(messages));
        //    AssertSinglePartitionReference(messages.SendOptions.PartitionId, messages.SendOptions.PartitionKey);

        //    // Determine the transport producer to delegate the send operation to.  Because sending to a specific
        //    // partition requires a dedicated client, use (or create) that client if a partition was specified.  Otherwise
        //    // the default gateway producer can be used to request automatic routing from the Event Hubs service gateway.

        //    TransportProducer activeProducer;

        //    if (String.IsNullOrEmpty(messages.SendOptions.PartitionId))
        //    {
        //        activeProducer = EventHubProducer;
        //    }
        //    else
        //    {
        //        // This assertion is intended as an additional check, not as a guarantee.  There still exists a benign
        //        // race condition where a transport producer may be created after the client has been closed; in this case
        //        // the transport producer will be force-closed with the associated connection or, worst case, will close once
        //        // its idle timeout period elapses.

        //        Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSenderClient));
        //        activeProducer = PartitionProducers.GetOrAdd(messages.SendOptions.PartitionId, id => Connection.CreateTransportProducer(id, RetryPolicy));
        //    }

        //    using DiagnosticScope scope = CreateDiagnosticScope();

        //    try
        //    {
        //        await activeProducer.SendAsync(messages, cancellationToken).ConfigureAwait(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        scope.Failed(ex);
        //        throw;
        //    }
        //}

        /// <summary>
        ///   Creates a size-constraint batch to which <see cref="EventData" /> may be added using a try-based pattern.  If an event would
        ///   exceed the maximum allowable size of the batch, the batch will not allow adding the event and signal that scenario using its
        ///   return value.
        ///
        ///   Because events that would violate the size constraint cannot be added, publishing a batch will not trigger an exception when
        ///   attempting to send the events to the Event Hubs service.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="EventDataBatch" /> with the default batch options.</returns>
        ///
        /// <seealso cref="CreateBatchAsync(CreateBatchOptions, CancellationToken)" />
        ///
        public virtual ValueTask<EventDataBatch> CreateBatchAsync(CancellationToken cancellationToken = default) => CreateBatchAsync(null, cancellationToken);

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
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
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

            TransportEventBatch transportBatch = await ServiceBusSender.CreateBatchAsync(options, cancellationToken).ConfigureAwait(false);
            return new EventDataBatch(transportBatch, options.ToSendOptions());
        }

        /// <summary>
        ///   Closes the producer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            IsClosed = true;

            var identifier = GetHashCode().ToString();
            EventHubsEventSource.Log.ClientCloseStart(typeof(ServiceBusSenderClient), EntityName, identifier);

            // Attempt to close the active transport producers.  In the event that an exception is encountered,
            // it should not impact the attempt to close the connection, assuming ownership.

            var transportProducerException = default(Exception);

            try
            {
                await ServiceBusSender.CloseAsync(cancellationToken).ConfigureAwait(false);

                var pendingCloses = new List<Task>();

                foreach (var producer in PartitionProducers.Values)
                {
                    pendingCloses.Add(producer.CloseAsync(CancellationToken.None));
                }

                PartitionProducers.Clear();
                await Task.WhenAll(pendingCloses).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.ClientCloseError(typeof(ServiceBusSenderClient), EntityName, identifier, ex.Message);
                transportProducerException = ex;
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
                EventHubsEventSource.Log.ClientCloseError(typeof(ServiceBusSenderClient), EntityName, identifier, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseComplete(typeof(ServiceBusSenderClient), EntityName, identifier);
            }

            // If there was an active exception pending from closing the individual
            // transport producers, surface it now.

            if (transportProducerException != default)
            {
                throw transportProducerException;
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusSenderClient" />,
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
        /// <returns>The requested <see cref="DiagnosticScope" />.</returns>
        ///
        private DiagnosticScope CreateDiagnosticScope()
        {
            DiagnosticScope scope = EventDataInstrumentation.ClientDiagnostics.CreateScope(DiagnosticProperty.ProducerActivityName);
            scope.AddAttribute(DiagnosticProperty.TypeAttribute, DiagnosticProperty.EventHubProducerType);
            scope.AddAttribute(DiagnosticProperty.ServiceContextAttribute, DiagnosticProperty.EventHubsServiceContext);
            scope.AddAttribute(DiagnosticProperty.EventHubAttribute, EntityName);
            scope.AddAttribute(DiagnosticProperty.EndpointAttribute, Connection.ServiceEndpoint);
            scope.Start();

            return scope;
        }

        /// <summary>
        ///   Performs the actions needed to instrument a set of events.
        /// </summary>
        ///
        /// <param name="messages">The events to instrument.</param>
        ///
        private void InstrumentMessages(IEnumerable<ServiceBusMessage> messages)
        {
            foreach (ServiceBusMessage message in messages)
            {
                //EventDataInstrumentation.InstrumentEvent(message);
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
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources1.CannotSendWithPartitionIdAndPartitionKey, partitionId));
            }
        }
    }
}
