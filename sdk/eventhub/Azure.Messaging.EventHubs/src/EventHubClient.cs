// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Compatibility;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The main point of interaction with Azure Event Hubs, the client offers a
    ///   connection to a specific Event Hub within the Event Hubs namespace and offers operations
    ///   for sending event data, receiving events, and inspecting the connected Event Hub.
    /// </summary>
    ///
    /// <seealso href="https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-about" />
    ///
    public class EventHubClient : IAsyncDisposable
    {
        /// <summary>
        ///   The path of the specific Event Hub that the client is connected to, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubPath { get; private set; }

        /// <summary>
        ///   The credential provided for use in authorization with the Azure Event Hubs connection.  This credential
        ///   will be validated against the Event Hubs namespace and the requested Event Hub for which operations
        ///   will be performed.
        /// </summary>
        ///
        internal TokenCredential Credential { get; private set; }

        /// <summary>
        ///   An abstracted Event Hub Client specific to the active protocol and transport intended to perform delegated operations.
        /// </summary>
        ///
        internal TransportEventHubClient InnerClient { get; set; }

        /// <summary>
        ///   The set of client options used for creation of this client.
        /// </summary>
        ///
        internal EventHubClientOptions ClientOptions { get; private set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub path and SAS token are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the path to the desired Event Hub,
        ///   which is needed.  In this case, the path can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the path.
        /// </remarks>
        ///
        public EventHubClient(string connectionString) : this(connectionString, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub path and SAS token are contained in this connection string.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the path to the desired Event Hub,
        ///   which is needed.  In this case, the path can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the path.
        /// </remarks>
        ///
        public EventHubClient(string connectionString,
                              EventHubClientOptions clientOptions)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(connectionString), connectionString);
            ValidateClientOptions(clientOptions);

            var connectionStringProperties = ParseConnectionString(connectionString);
            ValidateConnectionStringProperties(connectionStringProperties, nameof(connectionString));

            ClientOptions = clientOptions?.Clone() ?? new EventHubClientOptions();
            EventHubPath = connectionStringProperties.EventHubPath;

            var eventHubsHostName = connectionStringProperties.Endpoint.Host;

            var sharedAccessSignature = new SharedAccessSignature
            (
                 ClientOptions.TransportType,
                 eventHubsHostName,
                 EventHubPath,
                 connectionStringProperties.SharedAccessKeyName,
                 connectionStringProperties.SharedAccessKey
            );

            InnerClient = BuildTransportClient(eventHubsHostName, EventHubPath, new SharedAccessSignatureCredential(sharedAccessSignature), ClientOptions);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubPath">The path of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requeseted Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        public EventHubClient(string host,
                              string eventHubPath,
                              TokenCredential credential,
                              EventHubClientOptions clientOptions = default)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(host), host);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNull(nameof(credential), credential);
            ValidateClientOptions(clientOptions);

            EventHubPath = eventHubPath;
            Credential = credential;
            ClientOptions = clientOptions?.Clone() ?? new EventHubClientOptions();
            InnerClient = BuildTransportClient(host, eventHubPath, credential, ClientOptions);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        /// <remarks>
        ///   Because this is a non-public constructor, it is assumed that the <paramref name="clientOptions" /> passed are
        ///   owned by this instance and are safe from changes made by consumers.  It is considered the responsibility of the
        ///   caller to ensure that any needed cloning of options is performed.
        /// </remarks>
        ///
        protected EventHubClient(EventHubClientOptions clientOptions)
        {
            ValidateClientOptions(clientOptions);
            ClientOptions = clientOptions;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        protected EventHubClient()
        {
        }

        /// <summary>
        ///   Retrieves information about an Event Hub, including the number of partitions present
        ///   and their identifiers.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>The set of information for the Event Hub that this client is associated with.</returns>
        ///
        public virtual Task<EventHubProperties> GetPropertiesAsync(CancellationToken cancellationToken = default) => InnerClient.GetPropertiesAsync(cancellationToken);

        /// <summary>
        ///   Retrieves the set of identifiers for the partitions of an Event Hub.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>The set of identifiers for the partitions within the Event Hub that this client is associated with.</returns>
        ///
        /// <remarks>
        ///   This method is synonomous with invoking <see cref="GetPropertiesAsync(CancellationToken)" /> and reading the <see cref="EventHubProperties.PartitionIds"/>
        ///   property that is returned. It is offered as a convienience for quick access to the set of partition identifiers for the associated Event Hub.
        ///   No new or extended information is presented.
        /// </remarks>
        ///
        public virtual async Task<string[]> GetPartitionIdsAsync(CancellationToken cancellationToken = default) =>
            (await GetPropertiesAsync(cancellationToken).ConfigureAwait(false))?.PartitionIds;

        /// <summary>
        ///   Retrieves information about a specific partiton for an Event Hub, including elements that describe the available
        ///   events in the partition event stream.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>The set of information for the requested partition under the Event Hub this client is associated with.</returns>
        ///
        public virtual Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                             CancellationToken cancellationToken = default) => InnerClient.GetPartitionPropertiesAsync(partitionId, cancellationToken);

        /// <summary>
        ///   Creates an event sender responsible for transmitting <see cref="EventData" /> to the
        ///   Event Hub, grouped together in batches.  Depending on the <paramref name="senderOptions"/>
        ///   specified, the sender may be created to allow event data to be automatically routed to an available
        ///   partition or specific to a partition.
        /// </summary>
        ///
        /// <param name="senderOptions">The set of options to apply when creating the sender.</param>
        ///
        /// <returns>An event sender configured in the requested manner.</returns>
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
        public virtual EventSender CreateSender(SenderOptions senderOptions = default)
        {
            var options = senderOptions?.Clone() ?? new SenderOptions { Retry = null, Timeout = null };

            options.Retry = options.Retry ?? ClientOptions.Retry.Clone();
            options.Timeout = options.TimeoutOrDefault ?? ClientOptions.DefaultTimeout;

            return BuildEventSender(ClientOptions.TransportType, EventHubPath, options);
        }

        /// <summary>
        ///   Creates an event receiver responsible for reading <see cref="EventData" /> from a specific Event Hub partition,
        ///   and as a member of a specific consumer group.
        ///
        ///   A receiver may be exclusive, which asserts ownership over the partition for the consumer
        ///   group to ensure that only one receiver from that group is reading the from the partition.
        ///   These exclusive receivers are sometimes referred to as "Epoch Receivers."
        ///
        ///   A receiver may also be non-exclusive, allowing multiple receivers from the same consumer
        ///   group to be actively reading events from the partition.  These non-exclusive receivers are
        ///   sometimes referred to as "Non-epoch Receivers."
        ///
        ///   Designating a receiver as exclusive may be specified in the <paramref name="receiverOptions" />.
        ///   By default, receivers are created as non-exclusive.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="receiverOptions">The set of options to apply when creating the receiver.</param>
        ///
        /// <returns>An event receiver configured in the requested manner.</returns>
        ///
        /// <remarks>
        ///   If the starting event position is not specified in the <paramref name="receiverOptions"/>, the receiver will
        ///   default to ignoring events in the partition that were queued prior to the receiver being created and read only
        ///   events which appear after that point.
        /// </remarks>
        ///
        public virtual EventReceiver CreateReceiver(string partitionId,
                                                    ReceiverOptions receiverOptions = default)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);

            var options = receiverOptions?.Clone() ?? new ReceiverOptions { Retry = null, DefaultMaximumReceiveWaitTime = null };

            options.Retry = options.Retry ?? ClientOptions.Retry.Clone();
            options.DefaultMaximumReceiveWaitTime = options.MaximumReceiveWaitTimeOrDefault ?? ClientOptions.DefaultTimeout;

            return BuildEventReceiver(ClientOptions.TransportType, EventHubPath, partitionId, options);
        }

        /// <summary>
        ///   Closes the connection to the Event Hub instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => InnerClient.CloseAsync(cancellationToken);

        /// <summary>
        ///   Closes the connection to the Event Hub instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        public virtual void Close(CancellationToken cancellationToken = default) => CloseAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventHubClient" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
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
        ///   Builds an Event Hub Client specific to the protocol and transport specified by the
        ///   requested connection type of the <paramref name="options" />.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.</param>
        /// <param name="eventHubPath">The path to a specific Event Hub.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.</param>
        /// <param name="options">The set of options to use for the client.</param>
        ///
        /// <returns>A client generalization spcecific to the specified protocol/transport to which operations may be delegated.</returns>
        ///
        /// <remarks>
        ///   As an internal method, only basic sanity checks are performed against arguments.  It is
        ///   assumed that callers are trusted and have performed deep validation.
        ///
        ///   Parameters passed are also assumed to be owned by thee transport client and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the caller.
        /// </remarks>
        ///
        internal virtual TransportEventHubClient BuildTransportClient(string host,
                                                                      string eventHubPath,
                                                                      TokenCredential credential,
                                                                      EventHubClientOptions options)
        {
            switch (options.TransportType)
            {
                case TransportType.AmqpTcp:
                case TransportType.AmqpWebSockets:
                    return new TrackOneEventHubClient(host, eventHubPath, credential, options);

                default:
                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidTransportType, options.TransportType.ToString()), nameof(options.TransportType));
            }
        }

        /// <summary>
        ///   Builds an event sender instance using the provided options.
        /// </summary>
        ///
        /// <param name="connectionType">The type of connection being used for communication with the EventHubs servcie.</param>
        /// <param name="eventHubPath">The path to a specific Event Hub.</param>
        /// <param name="options">The set of options to use for the sender.</param>
        ///
        /// <returns>The fully constructed sender.</returns>
        ///
        internal virtual EventSender BuildEventSender(TransportType connectionType,
                                                      string eventHubPath,
                                                      SenderOptions options) =>
            new EventSender(connectionType, eventHubPath, options);

        /// <summary>
        ///   Builds a partition receiver instance using the provided options.
        /// </summary>
        ///
        /// <param name="connectionType">The type of connection being used for communication with the EventHubs servcie.</param>
        /// <param name="eventHubPath">The path to a specific Event Hub.</param>
        /// <param name="partitionId">The identifier of the partition to receive from.</param>
        /// <param name="options">The set of options to use for the receiver.</param>
        ///
        /// <returns>The fully constructed receiver.</returns>
        ///
        internal virtual EventReceiver BuildEventReceiver(TransportType connectionType,
                                                          string eventHubPath,
                                                          string partitionId,
                                                          ReceiverOptions options) =>
            new EventReceiver(connectionType, eventHubPath, partitionId, options);

        /// <summary>
        ///   Performs the actions needed to validate the <see cref="ConnectionStringProperties" /> associated
        ///   with this client.
        /// </summary>
        ///
        /// <param name="properties">The set of properties parsed from the connection string associated this client.</param>
        /// <param name="connectionStringArgumentName">The name of the argument associated with the connection string; to be used when raising <see cref="ArgumentException" /> variants.</param>
        ///
        /// <remarks>
        ///   In the case that the prioperties violate an invariant or otherwise represent a combination that
        ///   is not permissible, an appropriate exception will be thrown.
        /// </remarks>
        ///
        internal static void ValidateConnectionStringProperties(ConnectionStringProperties properties,
                                                                string connectionStringArgumentName)
        {
            if ((String.IsNullOrEmpty(properties.Endpoint?.Host))
                || (String.IsNullOrEmpty(properties.EventHubPath))
                || (String.IsNullOrEmpty(properties.SharedAccessKeyName))
                || (String.IsNullOrEmpty(properties.SharedAccessKey)))
            {
                throw new ArgumentException(Resources.InvalidConnectionString, connectionStringArgumentName);
            }
        }

        /// <summary>
        ///   Parses an Event Hubs connection string into its components.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to parse.</param>
        ///
        /// <returns>The component properties parsed from the connection string.</returns>
        ///
        internal static ConnectionStringProperties ParseConnectionString(string connectionString) =>
            ConnectionStringParser.Parse(connectionString);

        /// <summary>
        ///   Performs the actions needed to validate the <see cref="EventHubClientOptions" /> associated
        ///   with this client.
        /// </summary>
        ///
        /// <param name="clientOptions">The set of options to validate.</param>
        ///
        /// <remarks>
        ///   In the case that the options violate an invariant or otherwise represent a combination that
        ///   is not permissible, an appropriate exception will be thrown.
        /// </remarks>
        ///
        internal static void ValidateClientOptions(EventHubClientOptions clientOptions)
        {
            // If there were no options passed, they cannot be in an invalid state.

            if (clientOptions == null)
            {
                return;
            }

            // A proxy is only valid when websockets is used as the transport.

            if ((clientOptions.TransportType == TransportType.AmqpTcp) && (clientOptions.Proxy != null))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.ProxyMustUseWebsockets), nameof(clientOptions));
            }
        }
    }
}
