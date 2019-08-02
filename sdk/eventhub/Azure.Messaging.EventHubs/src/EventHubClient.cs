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
    ///   The main point of interaction with the Azure Event Hubs service, the client offers a
    ///   connection to a specific Event Hub within the Event Hubs namespace and offers operations
    ///   for sending event data, receiving events, and inspecting the connected Event Hub.
    /// </summary>
    ///
    /// <seealso href="https://docs.microsoft.com/en-us/Azure/event-hubs/event-hubs-about" />
    ///
    public class EventHubClient : IAsyncDisposable
    {
        /// <summary>The policy to use for determining retry behavior for when an operation fails.</summary>
        private EventHubRetryPolicy _retryPolicy;

        /// <summary>
        ///   The name of the Event Hub that the client is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        public EventHubRetryPolicy RetryPolicy
        {
            get => _retryPolicy;

            set
            {
                Guard.ArgumentNotNull(nameof(RetryPolicy), value);
                _retryPolicy = value;

                // Applying a custom retry policy invalidates the retry options specified.
                // Clear them to ensure the custom policy is propagated as the default.

                ClientOptions.ClearRetryOptions();
                InnerClient.UpdateRetryPolicy(value);
            }
        }

        /// <summary>
        ///   An abstracted Event Hub Client specific to the active protocol and transport intended to perform delegated operations.
        /// </summary>
        ///
        private TransportEventHubClient InnerClient { get; set; }

        /// <summary>
        ///   The set of client options used for creation of this client.
        /// </summary>
        ///
        private EventHubClientOptions ClientOptions { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
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
        public EventHubClient(string connectionString) : this(connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and SAS token are contained in this connection string.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
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
        public EventHubClient(string connectionString,
                              EventHubClientOptions clientOptions) : this(connectionString, null, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventHubClient(string connectionString,
                              string eventHubName) : this(connectionString, eventHubName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and SAS token are contained in this connection string.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public EventHubClient(string connectionString,
                              string eventHubName,
                              EventHubClientOptions clientOptions)
        {
            clientOptions = clientOptions?.Clone() ?? new EventHubClientOptions();

            Guard.ArgumentNotNullOrEmpty(nameof(connectionString), connectionString);
            ValidateClientOptions(clientOptions);

            var connectionStringProperties = ParseConnectionString(connectionString);
            ValidateConnectionProperties(connectionStringProperties, eventHubName, nameof(connectionString));

            var eventHubsHostName = connectionStringProperties.Endpoint.Host;

            if (String.IsNullOrEmpty(eventHubName))
            {
                eventHubName = connectionStringProperties.EventHubName;
            }

            var sharedAccessSignature = new SharedAccessSignature
            (
                 BuildResource(clientOptions.TransportType, eventHubsHostName, eventHubName),
                 connectionStringProperties.SharedAccessKeyName,
                 connectionStringProperties.SharedAccessKey
            );

            _retryPolicy = new BasicRetryPolicy(clientOptions.RetryOptions);
            ClientOptions = clientOptions;
            EventHubName = eventHubName;
            InnerClient = BuildTransportClient(eventHubsHostName, eventHubName, new SharedAccessSignatureCredential(sharedAccessSignature), clientOptions, _retryPolicy);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        public EventHubClient(string host,
                              string eventHubName,
                              TokenCredential credential,
                              EventHubClientOptions clientOptions = default)
        {
            clientOptions = clientOptions?.Clone() ?? new EventHubClientOptions();

            Guard.ArgumentNotNullOrEmpty(nameof(host), host);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubName), eventHubName);
            Guard.ArgumentNotNull(nameof(credential), credential);
            ValidateClientOptions(clientOptions);

            switch (credential)
            {
                case SharedAccessSignatureCredential _:
                    break;

                case EventHubSharedKeyCredential sharedKeyCredential:
                    credential = sharedKeyCredential.ConvertToSharedAccessSignatureCredential(BuildResource(clientOptions.TransportType, host, eventHubName));
                    break;

                default:
                    credential = new EventHubTokenCredential(credential, BuildResource(clientOptions.TransportType, host, eventHubName));
                    break;
            }

            _retryPolicy = new BasicRetryPolicy(clientOptions.RetryOptions);
            EventHubName = eventHubName;
            ClientOptions = clientOptions;
            InnerClient = BuildTransportClient(host, eventHubName, credential, clientOptions, _retryPolicy);
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
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the Event Hub that this client is associated with.</returns>
        ///
        public virtual Task<EventHubProperties> GetPropertiesAsync(CancellationToken cancellationToken = default) => InnerClient.GetPropertiesAsync(cancellationToken);

        /// <summary>
        ///   Retrieves the set of identifiers for the partitions of an Event Hub.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
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
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the requested partition under the Event Hub this client is associated with.</returns>
        ///
        public virtual Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                             CancellationToken cancellationToken = default) => InnerClient.GetPartitionPropertiesAsync(partitionId, cancellationToken);

        /// <summary>
        ///   Creates an Event Hub producer responsible for publishing <see cref="EventData" /> to the
        ///   Event Hub, either as a single item or grouped together in batches.  Depending on the
        ///   <paramref name="producerOptions"/> specified, the producer may be created to allow event
        ///   data to be automatically routed to an available partition or specific to a partition.
        /// </summary>
        ///
        /// <param name="producerOptions">The set of options to apply when creating the producer.</param>
        ///
        /// <returns>An Event Hub producer configured in the requested manner.</returns>
        ///
        /// <remarks>
        ///   Allowing automatic routing of partitions is recommended when:
        ///   <para>- The publishing of events needs to be highly available.</para>
        ///   <para>- The event data should be evenly distributed among all available partitions.</para>
        ///
        ///   If no partition is specified, the following rules are used for automatically selecting one:
        ///   <para>- Distribute the events equally amongst all available partitions using a round-robin approach.</para>
        ///   <para>- If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
        /// </remarks>
        ///
        public virtual EventHubProducer CreateProducer(EventHubProducerOptions producerOptions = default)
        {
            var options = producerOptions?.Clone() ?? new EventHubProducerOptions { RetryOptions = null };
            options.RetryOptions = options.RetryOptions ?? ClientOptions.RetryOptions?.Clone();

            return InnerClient.CreateProducer(options, _retryPolicy);
        }

        /// <summary>
        ///   Creates an Event Hub consumer responsible for reading <see cref="EventData" /> from a specific Event Hub partition,
        ///   in the context of a specific consumer group.
        ///
        ///   A consumer may be exclusive, which asserts ownership over the partition for the consumer
        ///   group to ensure that only one consumer from that group is reading the from the partition.
        ///   These exclusive consumers are sometimes referred to as "Epoch Consumers."
        ///
        ///   A consumer may also be non-exclusive, allowing multiple consumers from the same consumer
        ///   group to be actively reading events from the partition.  These non-exclusive consumers are
        ///   sometimes referred to as "Non-epoch Consumers."
        ///
        ///   Designating a consumer as exclusive may be specified in the <paramref name="consumerOptions" />.
        ///   By default, consumers are created as non-exclusive.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="consumerOptions">The set of options to apply when creating the consumer.</param>
        ///
        /// <returns>An Event Hub consumer configured in the requested manner.</returns>
        ///
        public virtual EventHubConsumer CreateConsumer(string consumerGroup,
                                                       string partitionId,
                                                       EventPosition eventPosition,
                                                       EventHubConsumerOptions consumerOptions = default)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);
            Guard.ArgumentNotNull(nameof(eventPosition), eventPosition);

            var options = consumerOptions?.Clone() ?? new EventHubConsumerOptions { RetryOptions = null };
            options.RetryOptions = options.RetryOptions ?? ClientOptions.RetryOptions?.Clone();

            return InnerClient.CreateConsumer(consumerGroup, partitionId, eventPosition, options, _retryPolicy);
        }

        /// <summary>
        ///   Closes the connection to the Event Hub instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => InnerClient.CloseAsync(cancellationToken);

        /// <summary>
        ///   Closes the connection to the Event Hub instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
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
        ///   Builds an Event Hub Client specific to the protocol and transport specified by the
        ///   requested connection type of the <paramref name="options" />.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.</param>
        /// <param name="eventHubName">The name of a specific Event Hub.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.</param>
        /// <param name="options">The set of options to use for the client.</param>
        /// <param name="defaultRetryPolicy">The default retry policy to use if no retry options were specified in the <paramref name="options" />.</param>
        ///
        /// <returns>A client generalization specific to the specified protocol/transport to which operations may be delegated.</returns>
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
                                                                      string eventHubName,
                                                                      TokenCredential credential,
                                                                      EventHubClientOptions options,
                                                                      EventHubRetryPolicy defaultRetryPolicy)
        {
            switch (options.TransportType)
            {
                case TransportType.AmqpTcp:
                case TransportType.AmqpWebSockets:
                    return new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetryPolicy);

                default:
                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidTransportType, options.TransportType.ToString()), nameof(options.TransportType));
            }
        }

        /// <summary>
        ///   Builds the audience for use in the signature.
        /// </summary>
        ///
        /// <param name="transportType">The type of protocol and transport that will be used for communicating with the Event Hubs service.</param>
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        ///
        /// <returns>The value to use as the audience of the signature.</returns>
        ///
        private static string BuildResource(TransportType transportType,
                                            string host,
                                            string eventHubName)
        {
            var builder = new UriBuilder(host)
            {
                Scheme = transportType.GetUriScheme(),
                Path = eventHubName,
                Port = -1,
                Fragment = String.Empty,
                Password = String.Empty,
                UserName = String.Empty,
            };

            if (builder.Path.EndsWith("/"))
            {
                builder.Path = builder.Path.TrimEnd('/');
            }

            return builder.Uri.AbsoluteUri.ToLowerInvariant();
        }

        /// <summary>
        ///   Performs the actions needed to validate the set of properties for connecting to the
        ///   Event Hubs service, as passed to this client during creation.
        /// </summary>
        ///
        /// <param name="properties">The set of properties parsed from the connection string associated this client.</param>
        /// <param name="eventHubName">The name of the Event Hub passed independent of the connection string, allowing easier use of a namespace-level connection string.</param>
        /// <param name="connectionStringArgumentName">The name of the argument associated with the connection string; to be used when raising <see cref="ArgumentException" /> variants.</param>
        ///
        /// <remarks>
        ///   In the case that the properties violate an invariant or otherwise represent a combination that
        ///   is not permissible, an appropriate exception will be thrown.
        /// </remarks>
        ///
        private static void ValidateConnectionProperties(ConnectionStringProperties properties,
                                                         string eventHubName,
                                                         string connectionStringArgumentName)
        {
            // The Event Hub name may only be specified in one of the possible forms, either as part of the
            // connection string or as a stand-alone parameter, but not both.

            if ((!String.IsNullOrEmpty(eventHubName)) && (!String.IsNullOrEmpty(properties.EventHubName)))
            {
                throw new ArgumentException(Resources.OnlyOneEventHubNameMayBeSpecified, connectionStringArgumentName);
            }

            // Ensure that each of the needed components are present for connecting.

            if ((String.IsNullOrEmpty(eventHubName)) && (String.IsNullOrEmpty(properties.EventHubName))
                || (String.IsNullOrEmpty(properties.Endpoint?.Host))
                || (String.IsNullOrEmpty(properties.SharedAccessKeyName))
                || (String.IsNullOrEmpty(properties.SharedAccessKey)))
            {
                throw new ArgumentException(Resources.MissingConnectionInformation, connectionStringArgumentName);
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
        private static ConnectionStringProperties ParseConnectionString(string connectionString) =>
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
        private static void ValidateClientOptions(EventHubClientOptions clientOptions)
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
