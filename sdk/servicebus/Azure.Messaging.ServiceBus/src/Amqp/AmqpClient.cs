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
using Azure.Messaging.ServiceBus.Receiver;
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
                          ServiceBusConnectionOptions clientOptions) : this(host, entityName, credential, clientOptions, null)
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
                             AmqpConnectionScope connectionScope)
        {
            Argument.AssertNotNullOrEmpty(host, nameof(host));
            Argument.AssertNotNullOrEmpty(entityName, nameof(entityName));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(clientOptions, nameof(clientOptions));

            try
            {
                ServiceBusEventSource.Log.EventHubClientCreateStart(host, entityName);

                ServiceEndpoint = new UriBuilder
                {
                    Scheme = clientOptions.TransportType.GetUriScheme(),
                    Host = host

                }.Uri;

                EntityName = entityName;
                Credential = credential;
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
                ServiceBusEventSource.Log.EventHubClientCreateComplete(host, entityName);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="retryPolicy"></param>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="messageCount"></param>
        /// <param name="sessionId"></param>
        /// <param name="receiveLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<ServiceBusMessage>> PeekAsync(
            ServiceBusRetryPolicy retryPolicy,
            long fromSequenceNumber,
            int messageCount = 1,
            string sessionId = null,
            string receiveLinkName = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                TimeSpan tryTimeout = retryPolicy.CalculateTryTimeout(0);

                AmqpRequestMessage amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.PeekMessageOperation,
                        tryTimeout,
                        null);
                string token = await AquireAccessTokenAsync(cancellationToken).ConfigureAwait(false);

                if (receiveLinkName != null)
                {
                    // include associated link for service optimization
                    amqpRequestMessage.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLinkName;
                }

                amqpRequestMessage.Map[ManagementConstants.Properties.FromSequenceNumber] = fromSequenceNumber;
                amqpRequestMessage.Map[ManagementConstants.Properties.MessageCount] = messageCount;

                if (!string.IsNullOrWhiteSpace(sessionId))
                {
                    amqpRequestMessage.Map[ManagementConstants.Properties.SessionId] = sessionId;
                }

                var messages = new List<ServiceBusMessage>();
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                RequestResponseAmqpLink link = await ManagementLink.GetOrCreateAsync(
                    UseMinimum(ConnectionScope.SessionTimeout,
                    tryTimeout.CalculateRemaining(stopWatch.Elapsed)))
                    .ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                ArraySegment<byte> transactionId = AmqpConstants.NullBinary;

                // This is how Track 1 makes the request
                //var responseAmqpMessage = await Task.Factory.FromAsync(
                //(c, s) => link.BeginRequest(
                //    amqpRequestMessage.AmqpMessage,
                //    transactionId,
                //    TimeSpan.FromSeconds(30),
                //    c, s),
                //(a) => link.EndRequest(a),
                //this).ConfigureAwait(false);

                using AmqpMessage responseAmqpMessage = await link.RequestAsync(
                    amqpRequestMessage.AmqpMessage,
                    tryTimeout.CalculateRemaining(stopWatch.Elapsed))
                    .ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                stopWatch.Stop();

                AmqpResponseMessage amqpResponseMessage = AmqpResponseMessage.CreateResponse(responseAmqpMessage);
                // Process the response.

                //AmqpError.ThrowIfErrorResponse(responseAmqpMessage, EntityName);
                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    ServiceBusMessage message = null;
                    IEnumerable<AmqpMap> messageList = amqpResponseMessage.GetListValue<AmqpMap>(ManagementConstants.Properties.Messages);
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
        ///
        /// </summary>
        /// <param name="sequenceNumber"></param>
        /// <param name="retryPolicy"></param>
        /// <param name="receiveLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CancelScheduledMessageAsync(
            long sequenceNumber,
            ServiceBusRetryPolicy retryPolicy,
            string receiveLinkName = null,
            CancellationToken cancellationToken = default)
        {

            try
            {
                TimeSpan tryTimeout = retryPolicy.CalculateTryTimeout(0);

                var request = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.CancelScheduledMessageOperation,
                    tryTimeout,
                    null);

                Stopwatch stopWatch = Stopwatch.StartNew();

                if (receiveLinkName != null)
                {
                    request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLinkName;
                }

                request.Map[ManagementConstants.Properties.SequenceNumbers] = new[] { sequenceNumber };

                RequestResponseAmqpLink link = await ManagementLink.GetOrCreateAsync(
                        UseMinimum(ConnectionScope.SessionTimeout,
                        tryTimeout.CalculateRemaining(stopWatch.Elapsed)))
                        .ConfigureAwait(false);

                using AmqpMessage response = await link.RequestAsync(
                    request.AmqpMessage,
                    tryTimeout.CalculateRemaining(stopWatch.Elapsed))
                    .ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                stopWatch.Stop();
                AmqpResponseMessage amqpResponseMessage = AmqpResponseMessage.CreateResponse(response);


                if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
                {
                    throw new Exception();
                    //throw response.ToMessagingContractException();
                }
            }
            catch (Exception)
            {
                throw new Exception();

                //throw AmqpExceptionHelper.GetClientException(exception, sendLink?.GetTrackingId(), null, sendLink?.Session.IsClosing() ?? false);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="retryPolicy"></param>
        /// <param name="receiveLinkName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<long> ScheduleMessageAsync(
            ServiceBusMessage message,
            ServiceBusRetryPolicy retryPolicy,
            string receiveLinkName = null,
            CancellationToken cancellationToken = default)
        {
            using (AmqpMessage amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(message))
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                TimeSpan tryTimeout = retryPolicy.CalculateTryTimeout(0);

                var request = AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.ScheduleMessageOperation,
                        tryTimeout,
                        null);

                try
                {
                    if (receiveLinkName != null)
                    {
                        request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = receiveLinkName;
                    }

                    ArraySegment<byte>[] payload = amqpMessage.GetPayload();
                    var buffer = new BufferListStream(payload);
                    ArraySegment<byte> value = buffer.ReadBytes((int)buffer.Length);

                    var entry = new AmqpMap();
                    {
                        entry[ManagementConstants.Properties.Message] = value;
                        entry[ManagementConstants.Properties.MessageId] = message.MessageId;

                        if (!string.IsNullOrWhiteSpace(message.SessionId))
                        {
                            entry[ManagementConstants.Properties.SessionId] = message.SessionId;
                        }

                        if (!string.IsNullOrWhiteSpace(message.PartitionKey))
                        {
                            entry[ManagementConstants.Properties.PartitionKey] = message.PartitionKey;
                        }

                        if (!string.IsNullOrWhiteSpace(message.ViaPartitionKey))
                        {
                            entry[ManagementConstants.Properties.ViaPartitionKey] = message.ViaPartitionKey;
                        }
                    }

                    request.Map[ManagementConstants.Properties.Messages] = new List<AmqpMap> { entry };


                    RequestResponseAmqpLink link = await ManagementLink.GetOrCreateAsync(
                        UseMinimum(ConnectionScope.SessionTimeout,
                        tryTimeout.CalculateRemaining(stopWatch.Elapsed)))
                        .ConfigureAwait(false);

                    using AmqpMessage response = await link.RequestAsync(
                        request.AmqpMessage,
                        tryTimeout.CalculateRemaining(stopWatch.Elapsed))
                        .ConfigureAwait(false);

                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    stopWatch.Stop();

                    AmqpResponseMessage amqpResponseMessage = AmqpResponseMessage.CreateResponse(response);

                    if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                    {
                        var sequenceNumbers = amqpResponseMessage.GetValue<long[]>(ManagementConstants.Properties.SequenceNumbers);
                        if (sequenceNumbers == null || sequenceNumbers.Length < 1)
                        {
                            throw new ServiceBusException(true, "Could not schedule message successfully.");
                        }

                        return sequenceNumbers[0];

                    }
                    else
                    {
                        throw new Exception();

                        //throw response.ToMessagingContractException();
                    }
                }
                catch (Exception)
                {
                    throw new Exception();
                    // throw AmqpExceptionHelper.GetClientException(exception, sendLink?.GetTrackingId(), null, sendLink?.Session.IsClosing() ?? false);
                }
            }
        }

        /// <summary>
        ///   Creates a producer strongly aligned with the active protocol and transport,
        ///   responsible for publishing <see cref="ServiceBusMessage" /> to the Event Hub.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition to which the transport producer should be bound; if <c>null</c>, the producer is unbound.</param>
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        ///
        /// <returns>A <see cref="TransportSender"/> configured in the requested manner.</returns>
        ///
        public override TransportSender CreateSender(string partitionId,
                                                         ServiceBusRetryPolicy retryPolicy)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpClient));

            return new AmqpSender
            (
                EntityName,
                partitionId,
                ConnectionScope,
                retryPolicy
            );
        }

        /// <summary>
        ///   Creates a consumer strongly aligned with the active protocol and transport, responsible
        ///   for reading <see cref="ServiceBusMessage" /> from a specific Event Hub partition, in the context
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
        /// <param name="retryPolicy">The policy which governs retry behavior and try timeouts.</param>
        /// <param name="trackLastEnqueuedEventProperties">Indicates whether information on the last enqueued event on the partition is sent as events are received.</param>
        /// <param name="ownerLevel">The relative priority to associate with the link; for a non-exclusive link, this value should be <c>null</c>.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="sessionId"></param>
        ///
        /// <returns>A <see cref="TransportConsumer" /> configured in the requested manner.</returns>
        ///
        public override TransportConsumer CreateConsumer(
            //string consumerGroup,
            //                                             string partitionId,
                                                         //EventPosition eventPosition,
                                                         ServiceBusRetryPolicy retryPolicy,
                                                         bool trackLastEnqueuedEventProperties,
                                                         long? ownerLevel,
                                                         uint? prefetchCount,
                                                         string sessionId = default)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpClient));

            return new AmqpConsumer
            (
                EntityName,
                //consumerGroup,
                //partitionId,
                //eventPosition,
                trackLastEnqueuedEventProperties,
                ownerLevel,
                prefetchCount,
                ConnectionScope,
                //MessageConverter,
                retryPolicy,
                sessionId
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
                ServiceBusEventSource.Log.ClientCloseStart(clientType, EntityName, clientId);
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
                ServiceBusEventSource.Log.ClientCloseError(clientType, EntityName, clientId, ex.Message);

                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(clientType, EntityName, clientId);
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
