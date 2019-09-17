// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Metadata;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   A transport client abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="EventHubClient" /> make use of an instance via containment
    ///   and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.EventHubs.Core.TransportEventHubClient" />
    ///
    internal class AmqpEventHubClient : TransportEventHubClient
    {
        // <summary>The buffer to apply when considering refreshing; credentials that expire less than this duration will be refreshed.</summary>
        private static readonly TimeSpan CredentialRefreshBuffer = TimeSpan.FromMinutes(5);

        /// <summary>The active retry policy for the client.</summary>
        private EventHubRetryPolicy _retryPolicy;

        /// <summary>The amount of time to allow for an operation to complete before considering it to have timed out.</summary>
        private TimeSpan _tryTimeout;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed = false;

        /// <summary>The currently active token to use for authorization with the Event Hubs service.</summary>
        private AccessToken _accessToken;

        /// <summary>
        ///   Indicates whether or not this client has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public override bool Closed => _closed;

        /// <summary>
        ///   The name of the Event Hub to which the client is bound.
        /// </summary>
        ///
        private string EventHubName { get; }

        /// <summary>
        ///   Gets the credential to use for authorization with the Event Hubs service.
        /// </summary>
        ///
        private TokenCredential Credential { get; }

        /// <summary>
        ///   The converter to use for translating between AMQP messages and client library
        ///   types.
        /// </summary>
        ///
        private AmqpMessageConverter MessageConverter { get; }

        /// <summary>
        ///   The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private AmqpConnectionScope ConnectionScope { get; }

        /// <summary>
        ///   The AMQP link intended for use with management operations.
        /// </summary>
        ///
        private FaultTolerantAmqpObject<RequestResponseAmqpLink> ManagementLink { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpEventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
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
        public AmqpEventHubClient(string host,
                                  string eventHubName,
                                  TokenCredential credential,
                                  EventHubClientOptions clientOptions,
                                  EventHubRetryPolicy defaultRetryPolicy) : this(host, eventHubName, credential, clientOptions, defaultRetryPolicy, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpEventHubClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
        /// <param name="defaultRetryPolicy">The default retry policy to use if no retry options were specified in the <paramref name="clientOptions" />.</param>
        /// <param name="connectionScope">The optional scope to use for AMQP connection management.  If <c>null</c>, a new scope will be created.</param>
        /// <param name="messageConverter">The optional converter to use for transforming AMQP message-related types.  If <c>null</c>, a new converter will be created.</param>
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
        protected AmqpEventHubClient(string host,
                                     string eventHubName,
                                     TokenCredential credential,
                                     EventHubClientOptions clientOptions,
                                     EventHubRetryPolicy defaultRetryPolicy,
                                     AmqpConnectionScope connectionScope,
                                     AmqpMessageConverter messageConverter)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(host), host);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubName), eventHubName);
            Guard.ArgumentNotNull(nameof(credential), credential);
            Guard.ArgumentNotNull(nameof(clientOptions), clientOptions);
            Guard.ArgumentNotNull(nameof(defaultRetryPolicy), defaultRetryPolicy);

            try
            {
                EventHubsEventSource.Log.EventHubClientCreateStart(host, eventHubName);

                _retryPolicy = defaultRetryPolicy;
                _tryTimeout = _retryPolicy.CalculateTryTimeout(0);

                EventHubName = eventHubName;
                Credential = credential;
                MessageConverter = messageConverter ?? new AmqpMessageConverter();

                if (connectionScope == null)
                {
                    var endpointBuilder = new UriBuilder
                    {
                        Scheme = clientOptions.TransportType.GetUriScheme(),
                        Host = host
                    };

                    connectionScope = new AmqpConnectionScope(endpointBuilder.Uri, eventHubName, credential, clientOptions.TransportType, clientOptions.Proxy);
                }

                ConnectionScope = connectionScope;
                ManagementLink = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(timeout => ConnectionScope.OpenManagementLinkAsync(timeout, CancellationToken.None), link => link.SafeClose());
            }
            finally
            {
                EventHubsEventSource.Log.EventHubClientCreateComplete(host, eventHubName);
            }

        }

        /// <summary>
        ///   Updates the active retry policy for the client.
        /// </summary>
        ///
        /// <param name="newRetryPolicy">The retry policy to set as active.</param>
        ///
        public override void UpdateRetryPolicy(EventHubRetryPolicy newRetryPolicy)
        {
            Guard.ArgumentNotNull(nameof(newRetryPolicy), newRetryPolicy);

            _retryPolicy = newRetryPolicy;
            _tryTimeout = _retryPolicy.CalculateTryTimeout(0);
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
            // Since the AMQP objects do not honor the cancellation token, manually check for cancellation between operation steps.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            try
            {
                EventHubsEventSource.Log.GetPropertiesStart(EventHubName);

                // Create the request message and the management link.

                var token = await AquireAccessTokenAsync(cancellationToken).ConfigureAwait(false);
                using var request = MessageConverter.CreateEventHubPropertiesRequest(EventHubName, token);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                var stopWatch = Stopwatch.StartNew();
                var link = await ManagementLink.GetOrCreateAsync(_tryTimeout).ConfigureAwait(false);

                // Send the request and wait for the response.

                stopWatch.Stop();
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                using var response = await link.RequestAsync(request, _tryTimeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);

                // Process the response.

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                ThrowIfErrorResponse(response, EventHubName);

                return MessageConverter.CreateEventHubPropertiesFromResponse(response);
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.GetPropertiesError(EventHubName, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.GetPropertiesComplete(EventHubName);
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
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);

            // Since the AMQP objects do not honor the cancellation token, manually check for cancellation between operation steps.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            try
            {
                EventHubsEventSource.Log.GetPartitionPropertiesStart(EventHubName, partitionId);

                // Create the request message and the management link.

                var token = await AquireAccessTokenAsync(cancellationToken).ConfigureAwait(false);
                using var request = MessageConverter.CreatePartitionPropertiesRequest(EventHubName, partitionId, token);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                var stopWatch = Stopwatch.StartNew();
                var link = await ManagementLink.GetOrCreateAsync(_tryTimeout).ConfigureAwait(false);

                // Send the request and wait for the response.

                stopWatch.Stop();
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                using var response = await link.RequestAsync(request, _tryTimeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);

                // Process the response.

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                ThrowIfErrorResponse(response, EventHubName);

                return MessageConverter.CreatePartitionPropertiesFromResponse(response);
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.GetPartitionPropertiesError(EventHubName, partitionId, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.GetPartitionPropertiesComplete(EventHubName, partitionId);
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
                                                        EventHubRetryPolicy defaultRetryPolicy) => throw new NotImplementedException();

        /// <summary>
        ///   Creates an Event Hub consumer responsible for reading <see cref="EventData" /> from a specific Event Hub partition,
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
                                                        EventHubRetryPolicy defaultRetryPolicy) => throw new NotImplementedException();

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override Task CloseAsync(CancellationToken cancellationToken)
        {
            if (_closed)
            {
                return Task.CompletedTask;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            ManagementLink?.Dispose();
            ConnectionScope?.Dispose();

            _closed = true;

            return Task.CompletedTask;
        }

        /// <summary>
        ///   Acquires an access token for authorization with the Event Hubs service.
        /// </summary>
        ///
        /// <returns>The token to use for service authorization.</returns>
        ///
        private async Task<string> AquireAccessTokenAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var activeToken = _accessToken;

            // If there was no current token, or it is within the buffer for expiration, request a new token.
            // There is a benign race condition here, where there may be multiple requests in-flight for a new token.  Since
            // overlapping requests should be within a small window, allow the acquired token to replace the current one without
            // attempting to coordinate or ensure that the most recent is kept.

            if ((String.IsNullOrEmpty(activeToken.Token)) || (activeToken.ExpiresOn <= DateTimeOffset.UtcNow.Add(CredentialRefreshBuffer)))
            {
                activeToken = await Credential.GetTokenAsync(new TokenRequest(new string[0]), cancellationToken).ConfigureAwait(false);

                if ((String.IsNullOrEmpty(activeToken.Token)))
                {
                    throw new AuthenticationException(Resources.CouldNotAcquireAccessToken);
                }

                _accessToken = activeToken;
            }

            return activeToken.Token;
        }

        /// <summary>
        ///   Determines if a given AMQP message response is an error and, if so, throws the
        ///   appropriate corresponding exception type.
        /// </summary>
        ///
        /// <param name="response">The AMQP response message to consider.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the request.</param>
        ///
        private static void ThrowIfErrorResponse(AmqpMessage response,
                                                 string eventHubName)
        {
            var statusCode = default(int);

            if ((response?.ApplicationProperties?.Map.TryGetValue(AmqpResponse.StatusCode, out statusCode) != true)
                || (!AmqpResponse.IsSuccessStatus((AmqpResponseStatusCode)statusCode)))
            {
                throw AmqpError.CreateExceptionForResponse(response, eventHubName);
            }
        }
    }
}
