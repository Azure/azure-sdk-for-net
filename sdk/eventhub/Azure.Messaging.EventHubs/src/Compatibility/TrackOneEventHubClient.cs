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
        /// <summary>The active retry policy for the client.</summary>
        private EventHubRetryPolicy _retryPolicy;

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
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requeseted Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        /// <param name="defaultRetryPolicy">The default retry policy to use if no retry options were specified in the <paramref name="clientOptions" />.</param>
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
                                      string eventHubName,
                                      TokenCredential credential,
                                      EventHubClientOptions clientOptions,
                                      EventHubRetryPolicy defaultRetryPolicy) : this(host, eventHubName, credential, clientOptions, defaultRetryPolicy, CreateClient)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TrackOneEventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requeseted Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        /// <param name="defaultRetryPolicy">The default retry policy to use if no retry options were specified in the <paramref name="clientOptions" />.</param>
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
        public TrackOneEventHubClient(string host,
                                      string eventHubName,
                                      TokenCredential credential,
                                      EventHubClientOptions clientOptions,
                                      EventHubRetryPolicy defaultRetryPolicy,
                                      Func<string, string, TokenCredential, EventHubClientOptions, Func<EventHubRetryPolicy>, TrackOne.EventHubClient> eventHubClientFactory)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(host), host);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubName), eventHubName);
            Guard.ArgumentNotNull(nameof(credential), credential);
            Guard.ArgumentNotNull(nameof(clientOptions), clientOptions);
            Guard.ArgumentNotNull(nameof(defaultRetryPolicy), defaultRetryPolicy);

            _retryPolicy = defaultRetryPolicy;
            _trackOneClient = new Lazy<TrackOne.EventHubClient>(() => eventHubClientFactory(host, eventHubName, credential, clientOptions, () => _retryPolicy), LazyThreadSafetyMode.PublicationOnly);
        }

        /// <summary>
        ///   Creates the track one Event Hub client instance for inner use, handling any necessary translation between track two
        ///   and track one concepts/types.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requeseted Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        /// <param name="defaultRetryPolicyFactory">A function that retrieves a default retry policy to use if no retry options were specified in the <paramref name="clientOptions" />.</param>
        ///
        /// <returns>The <see cref="TrackOne.EventHubClient" /> to use.</returns>
        ///
        public static TrackOne.EventHubClient CreateClient(string host,
                                                           string eventHubName,
                                                           TokenCredential credential,
                                                           EventHubClientOptions clientOptions,
                                                           Func<EventHubRetryPolicy> defaultRetryPolicyFactory)
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

                case EventHubTokenCredential eventHubCredential:
                    tokenProvider = new TrackOneGenericTokenProvider(eventHubCredential);
                    break;

                default:
                    throw new ArgumentException(Resources.UnsupportedCredential, nameof(credential));
            }

            // Create the endpoint for the client.

            var endpointBuilder = new UriBuilder
            {
                Scheme = clientOptions.TransportType.GetUriScheme(),
                Host = host,
                Path = eventHubName,
                Port = -1,
            };

            // Build and configure the client.

            var retryPolicy = (clientOptions.RetryOptions != null)
                ? new BasicRetryPolicy(clientOptions.RetryOptions)
                : defaultRetryPolicyFactory();

            var operationTimeout = retryPolicy.CalculateTryTimeout(0);
            var client = TrackOne.EventHubClient.Create(endpointBuilder.Uri, eventHubName, tokenProvider, operationTimeout, transportType);

            client.WebProxy = clientOptions.Proxy;
            client.RetryPolicy = new TrackOneRetryPolicy(retryPolicy);
            client.ConnectionStringBuilder.OperationTimeout = operationTimeout;

            return client;
        }

        /// <summary>
        ///   Updates the active retry policy for the client.
        /// </summary>
        ///
        /// <param name="newRetryPolicy">The retry policy to set as active.</param>
        ///
        public override void UpdateRetryPolicy(EventHubRetryPolicy newRetryPolicy)
        {
            _retryPolicy = newRetryPolicy;

            if (_trackOneClient.IsValueCreated)
            {
                TrackOneClient.RetryPolicy = new TrackOneRetryPolicy(newRetryPolicy);
                TrackOneClient.ConnectionStringBuilder.OperationTimeout = newRetryPolicy.CalculateTryTimeout(0);
            }
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
        public override async Task<EventHubProperties> GetPropertiesAsync(CancellationToken cancellationToken)
        {
            try
            {
                var runtimeInformation = await TrackOneClient.GetRuntimeInformationAsync().ConfigureAwait(false);

                return new EventHubProperties
                (
                    TrackOneClient.EventHubName,
                    runtimeInformation.CreatedAt,
                    runtimeInformation.PartitionIds
                );
            }
            catch (TrackOne.EventHubsException ex)
            {
                throw ex.MapToTrackTwoException();
            }
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
        public override async Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                    CancellationToken cancellationToken)
        {
            try
            {
                var runtimeInformation = await TrackOneClient.GetPartitionRuntimeInformationAsync(partitionId).ConfigureAwait(false);

                if (!Int64.TryParse(runtimeInformation.LastEnqueuedOffset, out var lastEnqueuedOffset))
                {
                    throw new FormatException(String.Format(CultureInfo.CurrentCulture, Resources.CannotParseIntegerType, nameof(runtimeInformation.LastEnqueuedOffset), 64, runtimeInformation.LastEnqueuedOffset));
                }

                return new PartitionProperties
                (
                    runtimeInformation.Path,
                    runtimeInformation.PartitionId,
                    runtimeInformation.BeginSequenceNumber,
                    runtimeInformation.LastEnqueuedSequenceNumber,
                    lastEnqueuedOffset,
                    runtimeInformation.LastEnqueuedTimeUtc,
                    runtimeInformation.IsEmpty
                );
            }
            catch (TrackOne.EventHubsException ex)
            {
                throw ex.MapToTrackTwoException();
            }
        }

        /// <summary>
        ///   Creates an Event Hub producer responsible for transmitting <see cref="EventData" /> to the
        ///   Event Hub, grouped together in batches.  Depending on the <paramref name="producerOptions"/>
        ///   specified, the producer may be created to allow event data to be automatically routed to an available
        ///   partition or specific to a partition.
        /// </summary>
        ///
        /// <param name="producerOptions">The set of options to apply when creating the producer.</param>
        /// <param name="defaultRetryPolicy">The default retry policy to use if no retry options were specified in the <paramref name="producerOptions" />.</param>
        ///
        /// <returns>An Event Hub producer configured in the requested manner.</returns>
        ///
        public override EventHubProducer CreateProducer(EventHubProducerOptions producerOptions,
                                                        EventHubRetryPolicy defaultRetryPolicy)
        {
            TrackOne.EventDataSender CreateSenderFactory(EventHubRetryPolicy activeRetryPolicy)
            {
                var producer = TrackOneClient.CreateEventSender(producerOptions.PartitionId);
                producer.RetryPolicy = new TrackOneRetryPolicy(activeRetryPolicy);

                return producer;
            }

            var initialRetryPolicy = (producerOptions.RetryOptions != null)
                ? new BasicRetryPolicy(producerOptions.RetryOptions)
                : defaultRetryPolicy;

            return new EventHubProducer
            (
                new TrackOneEventHubProducer(CreateSenderFactory, initialRetryPolicy),
                TrackOneClient.EventHubName,
                producerOptions,
                initialRetryPolicy
            );
        }

        /// <summary>
        ///   Creates a consumer responsible for reading <see cref="EventData" /> from a specific Event Hub partition,
        ///   and as a member of a specific consumer group.
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
        /// <param name="defaultRetryPolicy">The default retry policy to use if no retry options were specified in the <paramref name="consumerOptions" />.</param>
        ///
        /// <returns>An Event Hub consumer configured in the requested manner.</returns>
        ///
        public override EventHubConsumer CreateConsumer(string consumerGroup,
                                                        string partitionId,
                                                        EventPosition eventPosition,
                                                        EventHubConsumerOptions consumerOptions,
                                                        EventHubRetryPolicy defaultRetryPolicy)
        {
            TrackOne.PartitionReceiver CreateReceiverFactory(EventHubRetryPolicy activeRetryPolicy)
            {
                var position = new TrackOne.EventPosition
                {
                    IsInclusive = eventPosition.IsInclusive,
                    Offset = eventPosition.Offset,
                    SequenceNumber = eventPosition.SequenceNumber,
                    EnqueuedTimeUtc = eventPosition.EnqueuedTime?.UtcDateTime
                };

                var trackOneOptions = new TrackOne.ReceiverOptions
                {
                    Identifier = consumerOptions.Identifier
                };

                PartitionReceiver consumer;

                if (consumerOptions.OwnerLevel.HasValue)
                {
                    consumer = TrackOneClient.CreateEpochReceiver(consumerGroup, partitionId, position, consumerOptions.OwnerLevel.Value, trackOneOptions);
                }
                else
                {
                    consumer = TrackOneClient.CreateReceiver(consumerGroup, partitionId, position, trackOneOptions);
                }

                consumer.RetryPolicy = new TrackOneRetryPolicy(activeRetryPolicy);

                return consumer;
            }

            var initialRetryPolicy = (consumerOptions.RetryOptions != null)
                ? new BasicRetryPolicy(consumerOptions.RetryOptions)
                : defaultRetryPolicy;

            return new EventHubConsumer
            (
                new TrackOneEventHubConsumer(CreateReceiverFactory, initialRetryPolicy),
                TrackOneClient.EventHubName,
                partitionId,
                consumerGroup,
                eventPosition,
                consumerOptions,
                initialRetryPolicy
            );
        }

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
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
