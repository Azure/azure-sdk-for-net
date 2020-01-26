// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Consumer;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   A transport client abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="ServiceBusConnection" /> make use of an instance via containment
    ///   and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.ServiceBus.Core.TransportClient" />
    ///
    internal class AmqpClient : TransportClient
    {
        /// <summary>
        ///   The buffer to apply when considering refreshing; credentials that expire less than this duration will be refreshed.
        /// </summary>
        ///
        private static TimeSpan CredentialRefreshBuffer { get; } = TimeSpan.FromMinutes(5);

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
        public override bool IsClosed => _closed;

        /// <summary>
        ///   The endpoint for the Event Hubs service to which the client is associated.
        /// </summary>
        ///
        public override Uri ServiceEndpoint { get; }

        /// <summary>
        ///   The name of the Event Hub to which the client is bound.
        /// </summary>
        ///
        private string EntityName { get; }

        /// <summary>
        ///   Gets the credential to use for authorization with the Event Hubs service.
        /// </summary>
        ///
        private ServiceBusTokenCredential Credential { get; }

        /// <summary>
        ///   The converter to use for translating between AMQP messages and client library
        ///   types.
        /// </summary>
        ///
        private AmqpMessageConverterNew MessageConverterEH { get; }

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
        ///   Initializes a new instance of the <see cref="AmqpClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
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
        public AmqpClient(string host,
                          string entityName,
                          ServiceBusTokenCredential credential,
                          ServiceBusConnectionOptions clientOptions) : this(host, entityName, credential, clientOptions, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpClient"/> class.
        /// </summary>
        ///
        /// <param name="host">The fully qualified host name for the Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific Event Hub to connect the client to.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the client.</param>
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
        protected AmqpClient(string host,
                             string entityName,
                             ServiceBusTokenCredential credential,
                             ServiceBusConnectionOptions clientOptions,
                             AmqpConnectionScope connectionScope,
                             AmqpMessageConverterNew messageConverter)
        {
            Argument.AssertNotNullOrEmpty(host, nameof(host));
            Argument.AssertNotNullOrEmpty(entityName, nameof(entityName));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(clientOptions, nameof(clientOptions));

            try
            {
                EventHubsEventSource.Log.EventHubClientCreateStart(host, entityName);

                ServiceEndpoint = new UriBuilder
                {
                    Scheme = clientOptions.TransportType.GetUriScheme(),
                    Host = host

                }.Uri;

                EntityName = entityName;
                Credential = credential;
                MessageConverterEH = messageConverter ?? new AmqpMessageConverterNew();
                ConnectionScope = connectionScope ?? new AmqpConnectionScope(ServiceEndpoint, entityName, credential, clientOptions.TransportType, clientOptions.Proxy);

                ManagementLink = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(
                    timeout => ConnectionScope.OpenManagementLinkAsync(timeout, CancellationToken.None),
                    link =>
                    {
                        link.Session?.SafeClose();
                        link.SafeClose();
                    });
            }
            finally
            {
                EventHubsEventSource.Log.EventHubClientCreateComplete(host, entityName);
            }
        }

        /// <summary>
        ///   Retrieves information about an Event Hub, including the number of partitions present
        ///   and their identifiers.
        /// </summary>
        ///
        /// <param name="retryPolicy">The retry policy to use as the basis for retrieving the information.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the Event Hub that this client is associated with.</returns>
        ///
        public override async Task<EventHubProperties> GetPropertiesAsync(ServiceBusRetryPolicy retryPolicy,
                                                                          CancellationToken cancellationToken)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpClient));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            var failedAttemptCount = 0;
            var retryDelay = default(TimeSpan?);

            var stopWatch = Stopwatch.StartNew();

            try
            {
                var tryTimeout = retryPolicy.CalculateTryTimeout(0);

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        EventHubsEventSource.Log.GetPropertiesStart(EntityName);

                        // Create the request message and the management link.

                        var token = await AquireAccessTokenAsync(cancellationToken).ConfigureAwait(false);
                        using AmqpMessage request = MessageConverterEH.CreateEventHubPropertiesRequest(EntityName, token);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        RequestResponseAmqpLink link = await ManagementLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, tryTimeout.CalculateRemaining(stopWatch.Elapsed))).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        // Send the request and wait for the response.

                        using AmqpMessage response = await link.RequestAsync(request, tryTimeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                        stopWatch.Stop();

                        // Process the response.

                        AmqpError.ThrowIfErrorResponse(response, EntityName);
                        return MessageConverterEH.CreateEventHubPropertiesFromResponse(response);
                    }
                    catch (Exception ex)
                    {
                        Exception activeEx = ex.TranslateServiceException(EntityName);

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, mark the exception as active and break out of the loop.

                        ++failedAttemptCount;
                        retryDelay = retryPolicy.CalculateRetryDelay(activeEx, failedAttemptCount);

                        if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed) && (!cancellationToken.IsCancellationRequested))
                        {
                            EventHubsEventSource.Log.GetPropertiesError(EntityName, activeEx.Message);
                            await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);

                            tryTimeout = retryPolicy.CalculateTryTimeout(failedAttemptCount);
                            stopWatch.Reset();
                        }
                        else if (ex is AmqpException)
                        {
                            throw activeEx;
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
            catch (Exception ex)
            {
                EventHubsEventSource.Log.GetPropertiesError(EntityName, ex.Message);
                throw;
            }
            finally
            {
                stopWatch.Stop();
                EventHubsEventSource.Log.GetPropertiesComplete(EntityName);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="consumer"></param>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<ServiceBusMessage>> PeekAsync(
            TransportConsumer consumer,
            long fromSequenceNumber, int messageCount = 1, string sessionId = null, CancellationToken cancellationToken = default)
        {
            try
            {
                //var token = await AquireAccessTokenAsync(cancellationToken).ConfigureAwait(false);
                //using AmqpMessage request = MessageConverterEH.CreateEventHubPropertiesRequest(EntityName, token);
                //request.ApplicationProperties.Map[AmqpManagement.SecurityTokenKey] = token;
                var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.PeekMessageOperation,
                        TimeSpan.FromSeconds(100),
                        null);
                var token = await AquireAccessTokenAsync(cancellationToken).ConfigureAwait(false);
                amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[AmqpManagement.SecurityTokenKey] = token;
                amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[AmqpManagement.ResourceNameKey] = EntityName;
                //amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[AmqpManagement.ResourceTypeKey] = AmqpManagement.EventHubResourceTypeValue;


                await consumer.ReceiveLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, TimeSpan.FromSeconds(10))).ConfigureAwait(false);

                if (consumer.ReceiveLink.TryGetOpenedObject(out ReceivingAmqpLink receiveLink))
                {
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLink.Name;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.FromSequenceNumber] = fromSequenceNumber;
                amqpRequestMessage.Map[ManagementConstants.Properties.MessageCount] = messageCount;

                if (!string.IsNullOrWhiteSpace(sessionId))
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = sessionId;
                }

                var messages = new List<ServiceBusMessage>();

                //using AmqpMessage request = AmqpMessage.Create();
                    //MessageConverterEH.CreatePartitionPropertiesRequest(EntityName, partitionId, token);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                var link = await ManagementLink.GetOrCreateAsync(
                    UseMinimum(ConnectionScope.SessionTimeout,
                    TimeSpan.FromSeconds(60)))//tryTimeout.CalculateRemaining(stopWatch.Elapsed)))
                    .ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Send the request and wait for the response.

                //using AmqpMessage responseAmqpMessage = await link.RequestAsync(
                //    amqpRequestMessage.AmqpMessage,
                //    TimeSpan.FromSeconds(60))//tryTimeout.CalculateRemaining(stopWatch.Elapsed))
                //    .ConfigureAwait(false);
                ArraySegment<byte> transactionId = AmqpConstants.NullBinary;

                var responseAmqpMessage = await Task.Factory.FromAsync(
                (c, s) => link.BeginRequest(
                    amqpRequestMessage.AmqpMessage,
                    transactionId,
                    TimeSpan.FromSeconds(30),
                    c, s),
                (a) => link.EndRequest(a),
                this).ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                //stopWatch.Stop();
                var amqpResponseMessage = AmqpResponseMessage.CreateResponse(responseAmqpMessage);
                // Process the response.

                AmqpError.ThrowIfErrorResponse(responseAmqpMessage, EntityName);
                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    ServiceBusMessage message = null;
                    var messageList = amqpResponseMessage.GetListValue<AmqpMap>(ManagementConstants.Properties.Messages);
                    foreach (AmqpMap entry in messageList)
                    {
                        var payload = (ArraySegment<byte>)entry[ManagementConstants.Properties.Message];
                        var amqpMessage = AmqpMessage.CreateAmqpStreamMessage(new BufferListStream(new[] { payload }), true);
                        message = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage, true);
                        messages.Add(message);
                    }

                    if (message != null)
                    {
                        //this.LastPeekedSequenceNumber = message.SystemProperties.SequenceNumber;
                    }

                    return messages;
                }

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.NoContent ||
                    (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.NotFound && Equals(AmqpClientConstants.MessageNotFoundError, amqpResponseMessage.GetResponseErrorCondition())))
                {
                    return messages;
                }
                throw new Exception();
                //throw amqpResponseMessage.ToMessagingContractException();
            }
            catch (Exception exception)
            {
                throw exception;
                //throw AmqpExceptionHelper.GetClientException(exception);
            }
        }


        /// <summary>
        ///   Retrieves information about a specific partition for an Event Hub, including elements that describe the available
        ///   events in the partition event stream.
        /// </summary>
        ///
        /// <param name="partitionId">The unique identifier of a partition associated with the Event Hub.</param>
        /// <param name="retryPolicy">The retry policy to use as the basis for retrieving the information.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The set of information for the requested partition under the Event Hub this client is associated with.</returns>
        ///
        public override async Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                    ServiceBusRetryPolicy retryPolicy,
                                                                                    CancellationToken cancellationToken)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpClient));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            var failedAttemptCount = 0;
            var retryDelay = default(TimeSpan?);
            var token = default(string);
            var link = default(RequestResponseAmqpLink);

            var stopWatch = Stopwatch.StartNew();

            try
            {
                var tryTimeout = retryPolicy.CalculateTryTimeout(0);

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        EventHubsEventSource.Log.GetPartitionPropertiesStart(EntityName, partitionId);

                        // Create the request message and the management link.

                        token = await AquireAccessTokenAsync(cancellationToken).ConfigureAwait(false);
                        using AmqpMessage request = MessageConverterEH.CreatePartitionPropertiesRequest(EntityName, partitionId, token);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        link = await ManagementLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, tryTimeout.CalculateRemaining(stopWatch.Elapsed))).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        // Send the request and wait for the response.

                        using AmqpMessage response = await link.RequestAsync(request, tryTimeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                        stopWatch.Stop();

                        // Process the response.

                        AmqpError.ThrowIfErrorResponse(response, EntityName);
                        return MessageConverterEH.CreatePartitionPropertiesFromResponse(response);
                    }
                    catch (Exception ex)
                    {
                        Exception activeEx = ex.TranslateServiceException(EntityName);

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, mark the exception as active and break out of the loop.

                        ++failedAttemptCount;
                        retryDelay = retryPolicy.CalculateRetryDelay(activeEx, failedAttemptCount);

                        if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed) && (!cancellationToken.IsCancellationRequested))
                        {
                            EventHubsEventSource.Log.GetPartitionPropertiesError(EntityName, partitionId, activeEx.Message);
                            await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);

                            tryTimeout = retryPolicy.CalculateTryTimeout(failedAttemptCount);
                            stopWatch.Reset();
                        }
                        else if (ex is AmqpException)
                        {
                            throw activeEx;
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
            catch (Exception ex)
            {
                EventHubsEventSource.Log.GetPartitionPropertiesError(EntityName, partitionId, ex.Message);
                throw;
            }
            finally
            {
                stopWatch.Stop();
                EventHubsEventSource.Log.GetPartitionPropertiesComplete(EntityName, partitionId);
            }
        }

        /// <summary>
        ///   Creates a producer strongly aligned with the active protocol and transport,
        ///   responsible for publishing <see cref="EventData" /> to the Event Hub.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition to which the transport producer should be bound; if <c>null</c>, the producer is unbound.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        ///
        /// <returns>A <see cref="TransportProducer"/> configured in the requested manner.</returns>
        ///
        public override TransportProducer CreateProducer(string partitionId,
                                                         ServiceBusRetryPolicy retryPolicy)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpClient));

            return new AmqpProducer
            (
                EntityName,
                partitionId,
                ConnectionScope,
                MessageConverterEH,
                retryPolicy
            );
        }

        /// <summary>
        ///   Creates a consumer strongly aligned with the active protocol and transport, responsible
        ///   for reading <see cref="EventData" /> from a specific Event Hub partition, in the context
        ///   of a specific consumer group.
        ///
        ///   A consumer may be exclusive, which asserts ownership over the partition for the consumer
        ///   group to ensure that only one consumer from that group is reading the from the partition.
        ///   These exclusive consumers are sometimes referred to as "Epoch Consumers."
        ///
        ///   A consumer may also be non-exclusive, allowing multiple consumers from the same consumer
        ///   group to be actively reading events from the partition.  These non-exclusive consumers are
        ///   sometimes referred to as "Non-epoch Consumers."
        ///
        ///   Designating a consumer as exclusive may be specified by setting the <paramref name="ownerLevel" />.
        ///   When <c>null</c>, consumers are created as non-exclusive.
        /// </summary>
        ///
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="trackLastEnqueuedEventProperties">Indicates whether information on the last enqueued event on the partition is sent as events are received.</param>
        /// <param name="ownerLevel">The relative priority to associate with the link; for a non-exclusive link, this value should be <c>null</c>.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        ///
        /// <returns>A <see cref="TransportConsumer" /> configured in the requested manner.</returns>
        ///
        public override TransportConsumer CreateConsumer(
            //string consumerGroup,
            //                                             string partitionId,
                                                         EventPosition eventPosition,
                                                         ServiceBusRetryPolicy retryPolicy,
                                                         bool trackLastEnqueuedEventProperties,
                                                         long? ownerLevel,
                                                         uint? prefetchCount)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpClient));

            return new AmqpConsumer
            (
                EntityName,
                //consumerGroup,
                //partitionId,
                eventPosition,
                trackLastEnqueuedEventProperties,
                ownerLevel,
                prefetchCount,
                ConnectionScope,
                //MessageConverter,
                retryPolicy
            );
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

            _closed = true;

            var clientId = GetHashCode().ToString();
            var clientType = GetType();

            try
            {
                EventHubsEventSource.Log.ClientCloseStart(clientType, EntityName, clientId);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (ManagementLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await ManagementLink.CloseAsync().ConfigureAwait(false);
                }

                ManagementLink?.Dispose();
                ConnectionScope?.Dispose();
            }
            catch (Exception ex)
            {
                _closed = false;
                EventHubsEventSource.Log.ClientCloseError(clientType, EntityName, clientId, ex.Message);

                throw;
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseComplete(clientType, EntityName, clientId);
            }
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
                activeToken = await Credential.GetTokenUsingDefaultScopeAsync(cancellationToken).ConfigureAwait(false);

                if ((string.IsNullOrEmpty(activeToken.Token)))
                {
                    throw new AuthenticationException(Resources1.CouldNotAcquireAccessToken);
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
