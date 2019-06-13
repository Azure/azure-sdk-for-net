// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;
using TrackOne;

namespace Azure.Messaging.EventHubs.Compatibility
{
    /// <summary>
    ///   A transport client abstraction responsible for wrapping the track one Event Hub client as a transport client for
    ///   AMQP-based connections.  It is intended that the public <see cref="EventHubClient" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.EventHubs.Core.TransportEventHubClient" />
    ///
    internal sealed class TrackOneEventHubClient : TransportEventHubClient
    {
        /// <summary>A lazy instantiation of the client instance to delegate operation to.</summary>
        private Lazy<TrackOne.EventHubClient> _trackOneClient;

        /// <summary>
        ///   The track one <see cref="TrackOne.EventHubClient" /> for use with this transport client.
        /// </summary>
        ///
        private TrackOne.EventHubClient TrackOneClient => _trackOneClient.Value;

        /// <summary>
        ///   Initializes a new instance of the <see cref="TrackOneEventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubPath">The path of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requeseted Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        /// <remarks>
        ///   As an internal type, this class performs only basic sanity checks against its arguments.  It
        ///   is assumed that callers are trusted and have performed deep validation.
        ///
        ///   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        ///   caller.
        /// </remarks>
        ///
        public TrackOneEventHubClient(string host,
                                      string eventHubPath,
                                      TokenCredential credential,
                                      EventHubClientOptions clientOptions) : this(host, eventHubPath, credential, clientOptions, CreateClient)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TrackOneEventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubPath">The path of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requeseted Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        /// <param name="eventHubClientFactory">A delegate that can be used for creation of the <see cref="TrackOne.EventHubClient" /> to which operations are delegated to.</param>
        ///
        /// <remarks>
        ///   As an internal type, this class performs only basic sanity checks against its arguments.  It
        ///   is assumed that callers are trusted and have performed deep validation.
        ///
        ///   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        ///   caller.
        /// </remarks>
        ///
        internal TrackOneEventHubClient(string host,
                                        string eventHubPath,
                                        TokenCredential credential,
                                        EventHubClientOptions clientOptions,
                                        Func<string, string, TokenCredential, EventHubClientOptions, TrackOne.EventHubClient> eventHubClientFactory)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(host), host);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNull(nameof(credential), credential);
            Guard.ArgumentNotNull(nameof(clientOptions), clientOptions);

            _trackOneClient = new Lazy<TrackOne.EventHubClient>(() => eventHubClientFactory(host, eventHubPath, credential, clientOptions), LazyThreadSafetyMode.PublicationOnly);
        }

        /// <summary>
        ///   Creates the track one Event Hub client instance for inner use, handling any necessary translation between track two
        ///   and track one concepts/types.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubPath">The path of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requeseted Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        ///
        /// <returns>The <see cref="TrackOne.EventHubClient" /> to use.</returns>
        ///
        internal static TrackOne.EventHubClient CreateClient(string host,
                                                             string eventHubPath,
                                                             TokenCredential credential,
                                                             EventHubClientOptions clientOptions)
        {
            // Translate the connection type into the corresponding Track One transport type.

            TrackOne.TransportType transportType;

            switch (clientOptions.TransportType)
            {
                case TransportType.AmqpTcp:
                    transportType = TrackOne.TransportType.Amqp;
                    break;

                case TransportType.AmqpWebSockets:
                    transportType = TrackOne.TransportType.AmqpWebSockets;
                    break;

                default:
                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidTransportType, clientOptions.TransportType.ToString(), nameof(clientOptions.TransportType)));
            }

            // Translate the provided credential into a Track One token provider.

            TokenProvider tokenProvider;

            switch (credential)
            {
                case SharedAccessSignatureCredential sasCredential:
                    tokenProvider = new TrackOneSharedAccessTokenProvider(sasCredential.SharedAccessSignature);
                    break;

                default:
                    throw new NotImplementedException("Only shared key credentials are currently supported.");
                    //TODO: Revisit this once Azure.Identity is ready for managed identities.
            }

            // Create the endpoint for the client.

            var endpointBuilder = new UriBuilder
            {
                Scheme = clientOptions.TransportType.GetUriScheme(),
                Host = host,
                Path = eventHubPath,
                Port = -1,
            };

            // Build and configure the client.

            var client = TrackOne.EventHubClient.Create(endpointBuilder.Uri, eventHubPath, tokenProvider, clientOptions.DefaultTimeout, transportType);
            client.WebProxy = clientOptions.Proxy;

            return client;
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
        public override async Task<EventHubProperties> GetPropertiesAsync(CancellationToken cancellationToken)
        {
            var runtimeInformation = await TrackOneClient.GetRuntimeInformationAsync().ConfigureAwait(false);

            return new EventHubProperties
            (
                TrackOneClient.EventHubName,
                runtimeInformation.CreatedAt,
                runtimeInformation.PartitionIds,
                DateTime.UtcNow
            );
        }

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
        public override async Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                    CancellationToken cancellationToken)
        {
            var runtimeInformation = await TrackOneClient.GetPartitionRuntimeInformationAsync(partitionId).ConfigureAwait(false);

            return new PartitionProperties
            (
                runtimeInformation.Path,
                runtimeInformation.PartitionId,
                runtimeInformation.BeginSequenceNumber,
                runtimeInformation.LastEnqueuedSequenceNumber,
                runtimeInformation.LastEnqueuedOffset,
                runtimeInformation.LastEnqueuedTimeUtc,
                runtimeInformation.IsEmpty,
                DateTime.UtcNow
            );
        }

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
        public override EventSender CreateSender(EventSenderOptions senderOptions)
        {
            (TimeSpan minBackoff, TimeSpan maxBackoff, int maxRetries) = ((ExponentialRetry)senderOptions.Retry).GetProperties();

            TrackOne.EventDataSender CreateSenderFactory()
            {
                var sender = TrackOneClient.CreateEventSender(senderOptions.PartitionId);
                sender.RetryPolicy = new RetryExponential(minBackoff, maxBackoff, maxRetries);

                return sender;
            }

            return new EventSender
            (
                new TrackOneEventSender(CreateSenderFactory),
                TrackOneClient.EventHubName,
                senderOptions
            );
        }

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public override Task CloseAsync(CancellationToken cancellationToken)
        {
            if (!_trackOneClient.IsValueCreated)
            {
                return Task.CompletedTask;
            }

            return TrackOneClient.CloseAsync();
        }
    }
}
