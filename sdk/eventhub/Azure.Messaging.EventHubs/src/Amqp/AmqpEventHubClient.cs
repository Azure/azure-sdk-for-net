﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// <summary>
        ///   The buffer to apply when considering refreshing; credentials that expire less than this duration will be refreshed.
        /// </summary>
        ///
        private static TimeSpan CredentialRefreshBuffer { get; } = TimeSpan.FromMinutes(5);

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
            Argument.AssertNotNullOrEmpty(host, nameof(host));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(clientOptions, nameof(clientOptions));
            Argument.AssertNotNull(defaultRetryPolicy, nameof(defaultRetryPolicy));

            try
            {
                EventHubsEventSource.Log.EventHubClientCreateStart(host, eventHubName);

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

                _retryPolicy = defaultRetryPolicy;
                _tryTimeout = _retryPolicy.CalculateTryTimeout(0);
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
            Argument.AssertNotNull(newRetryPolicy, nameof(newRetryPolicy));

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
            Argument.AssertNotClosed(_closed, nameof(AmqpEventHubClient));

            var failedAttemptCount = 0;
            var retryDelay = default(TimeSpan?);

            var stopWatch = Stopwatch.StartNew();

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        EventHubsEventSource.Log.GetPropertiesStart(EventHubName);

                        // Create the request message and the management link.

                        var token = await AquireAccessTokenAsync(cancellationToken).ConfigureAwait(false);
                        using AmqpMessage request = MessageConverter.CreateEventHubPropertiesRequest(EventHubName, token);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        RequestResponseAmqpLink link = await ManagementLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, _tryTimeout.CalculateRemaining(stopWatch.Elapsed))).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        // Send the request and wait for the response.

                        using AmqpMessage response = await link.RequestAsync(request, _tryTimeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                        stopWatch.Stop();

                        // Process the response.

                        AmqpError.ThrowIfErrorResponse(response, EventHubName);
                        return MessageConverter.CreateEventHubPropertiesFromResponse(response);
                    }
                    catch (Exception ex)
                    {
                        EventHubsEventSource.Log.GetPropertiesError(EventHubName, ex.Message);

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, mark the exception as active and break out of the loop.

                        ++failedAttemptCount;
                        retryDelay = _retryPolicy.CalculateRetryDelay(ex, failedAttemptCount);

                        if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed))
                        {
                            await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                // If no value has been returned nor exception thrown by this point,
                // then cancellation has been requested.

                throw new TaskCanceledException();
            }
            finally
            {
                stopWatch.Stop();
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
            Argument.AssertNotClosed(_closed, nameof(AmqpEventHubClient));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            var failedAttemptCount = 0;
            var retryDelay = default(TimeSpan?);
            var token = default(string);
            var link = default(RequestResponseAmqpLink);

            var stopWatch = Stopwatch.StartNew();

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        EventHubsEventSource.Log.GetPartitionPropertiesStart(EventHubName, partitionId);

                        // Create the request message and the management link.

                        token = await AquireAccessTokenAsync(cancellationToken).ConfigureAwait(false);
                        using AmqpMessage request = MessageConverter.CreatePartitionPropertiesRequest(EventHubName, partitionId, token);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        link = await ManagementLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, _tryTimeout.CalculateRemaining(stopWatch.Elapsed))).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        // Send the request and wait for the response.

                        using AmqpMessage response = await link.RequestAsync(request, _tryTimeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                        stopWatch.Stop();

                        // Process the response.

                        AmqpError.ThrowIfErrorResponse(response, EventHubName);
                        return MessageConverter.CreatePartitionPropertiesFromResponse(response);
                    }
                    catch (Exception ex)
                    {
                        EventHubsEventSource.Log.GetPartitionPropertiesError(EventHubName, partitionId, ex.Message);

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, mark the exception as active and break out of the loop.

                        ++failedAttemptCount;
                        retryDelay = _retryPolicy.CalculateRetryDelay(ex, failedAttemptCount);

                        if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed))
                        {
                            await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                // If no value has been returned nor exception thrown by this point,
                // then cancellation has been requested.

                throw new TaskCanceledException();
            }
            finally
            {
                stopWatch.Stop();
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
                                                        EventHubRetryPolicy defaultRetryPolicy)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpEventHubClient));

            LastEnqueuedEventProperties lastEnqueuedEventProperties = consumerOptions.TrackLastEnqueuedEventInformation
                ? new LastEnqueuedEventProperties(EventHubName, partitionId)
                : null;

            EventHubRetryPolicy retryPolicy = defaultRetryPolicy ?? _retryPolicy;

            var transportConsumer = new AmqpEventHubConsumer
            (
                EventHubName,
                consumerGroup,
                partitionId,
                eventPosition,
                consumerOptions,
                ConnectionScope,
                MessageConverter,
                retryPolicy,
                lastEnqueuedEventProperties
            );

            return new EventHubConsumer(transportConsumer, EventHubName, consumerGroup, partitionId, eventPosition, consumerOptions, retryPolicy);
        }

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override async Task CloseAsync(CancellationToken cancellationToken)
        {
            if (_closed)
            {
                return;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            if (ManagementLink?.TryGetOpenedObject(out var _) == true)
            {
                await ManagementLink.CloseAsync().ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            }

            ManagementLink?.Dispose();
            ConnectionScope?.Dispose();

            _closed = true;
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

            AccessToken activeToken = _accessToken;

            // If there was no current token, or it is within the buffer for expiration, request a new token.
            // There is a benign race condition here, where there may be multiple requests in-flight for a new token.  Since
            // overlapping requests should be within a small window, allow the acquired token to replace the current one without
            // attempting to coordinate or ensure that the most recent is kept.

            if ((string.IsNullOrEmpty(activeToken.Token)) || (activeToken.ExpiresOn <= DateTimeOffset.UtcNow.Add(CredentialRefreshBuffer)))
            {
                activeToken = await Credential.GetTokenAsync(new TokenRequestContext(new string[0]), cancellationToken).ConfigureAwait(false);

                if ((string.IsNullOrEmpty(activeToken.Token)))
                {
                    throw new AuthenticationException(Resources.CouldNotAcquireAccessToken);
                }

                _accessToken = activeToken;
            }

            return activeToken.Token;
        }

        /// <summary>
        ///   Uses the minimum value of the two specified <see cref="TimeSpan" /> instances.
        /// </summary>
        ///
        /// <param name="firstOption">The first option to consider.</param>
        /// <param name="secondOption">The second option to consider.</param>
        ///
        /// <returns></returns>
        ///
        private static TimeSpan UseMinimum(TimeSpan firstOption,
                                           TimeSpan secondOption) => (firstOption < secondOption) ? firstOption : secondOption;
    }
}
