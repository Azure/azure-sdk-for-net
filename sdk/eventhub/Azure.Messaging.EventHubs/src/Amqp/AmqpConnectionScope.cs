﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Security;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Amqp.Sasl;
using Microsoft.Azure.Amqp.Transport;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   Defines a context for AMQP operations which can be shared amongst the different
    ///   client types within a given scope.
    /// </summary>
    ///
    internal class AmqpConnectionScope : IDisposable
    {
        /// <summary>The name to assign to the SASL handler to specify that CBS tokens are in use.</summary>
        private const string CbsSaslHandlerName = "MSSBCBS";

        /// <summary>The suffix to attach to the resource path when using web sockets for service communication.</summary>
        private const string WebSocketsPathSuffix = "/$servicebus/websocket/";

        /// <summary>The URI scheme to apply when using web sockets for service communication.</summary>
        private const string WebSocketsUriScheme = "wss";

        /// <summary>The string formatting mask to apply to the service endpoint to consume events for a given consumer group and partition.</summary>
        private const string ConsumerPathSuffixMask = "{0}/ConsumerGroups/{1}/Partitions/{2}";

        /// <summary>The string formatting mask to apply to the service endpoint to publish events for a given partition.</summary>
        private const string PartitionProducerPathSuffixMask = "{0}/Partitions/{1}";

        /// <summary>Indicates whether or not this instance has been disposed.</summary>
        private volatile bool _disposed;

        /// <summary>
        ///   The version of AMQP to use within the scope.
        /// </summary>
        ///
        private static Version AmqpVersion { get; } = new Version(1, 0, 0, 0);

        /// <summary>
        ///   The amount of time to allow an AMQP connection to be idle before considering
        ///   it to be timed out.
        /// </summary>
        ///
        private static TimeSpan ConnectionIdleTimeout { get; } = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The amount of buffer to apply to account for clock skew when
        ///   refreshing authorization.  Authorization will be refreshed earlier
        ///   than the expected expiration by this amount.
        /// </summary>
        ///
        private static TimeSpan AuthorizationRefreshBuffer { get; } = TimeSpan.FromMinutes(10);

        /// <summary>
        ///   The minimum amount of time for authorization to be refreshed; any calculations that
        ///   call for refreshing more frequently will be substituted with this value.
        /// </summary>
        ///
        private static TimeSpan MinimumAuthorizationRefresh { get; } = TimeSpan.FromMinutes(2);

        /// <summary>
        ///   The maximum amount of time to allow before authorization is refreshed; any calculations
        ///   that call for refreshing less frequently will be substituted with this value.
        /// </summary>
        ///
        /// <remarks>
        ///   This value must be less than 49 days, 17 hours, 2 minutes, 47 seconds, 294 milliseconds
        ///   in order to not overflow the Timer used to track authorization refresh.
        /// </remarks>
        ///
        private static TimeSpan MaximumAuthorizationRefresh { get; } = TimeSpan.FromDays(49);

        /// <summary>
        ///   The amount time to allow to refresh authorization of an AMQP link.
        /// </summary>
        ///
        private static TimeSpan AuthorizationRefreshTimeout { get; } = TimeSpan.FromMinutes(3);

        /// <summary>
        ///   The recommended timeout to associate with an AMQP session.  It is recommended that this
        ///   interval be used when creating or opening AMQP links and related constructs.
        /// </summary>
        ///
        public TimeSpan SessionTimeout { get; } = TimeSpan.FromSeconds(30);

        /// <summary>
        ///   Indicates whether this <see cref="AmqpConnectionScope"/> has been disposed.
        /// </summary>
        ///
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        ///
        public bool IsDisposed
        {
            get => _disposed;
            private set => _disposed = value;
        }

        /// <summary>
        ///   The cancellation token to use with operations initiated by the scope.
        /// </summary>
        ///
        private CancellationTokenSource OperationCancellationSource { get; } = new CancellationTokenSource();

        /// <summary>
        ///   The set of active AMQP links associated with the connection scope.  These are considered children
        ///   of the active connection and should be managed as such.
        /// </summary>
        ///
        private ConcurrentDictionary<AmqpObject, Timer> ActiveLinks { get; } = new ConcurrentDictionary<AmqpObject, Timer>();

        /// <summary>
        ///   The unique identifier of the scope.
        /// </summary>
        ///
        private string Id { get; }

        /// <summary>
        ///   The endpoint for the Event Hubs service to which the scope is associated.
        /// </summary>
        ///
        private Uri ServiceEndpoint { get; }

        /// <summary>
        ///   The endpoint to used establishing a connection to the Event Hubs service to which the scope is associated.
        /// </summary>
        ///
        private Uri ConnectionEndpoint { get; }

        /// <summary>
        ///   The name of the Event Hub to which the scope is associated.
        /// </summary>
        ///
        private string EventHubName { get; }

        /// <summary>
        ///   The provider to use for obtaining a token for authorization with the Event Hubs service.
        /// </summary>
        ///
        private CbsTokenProvider TokenProvider { get; }

        /// <summary>
        ///   The type of transport to use for communication.
        /// </summary>
        ///
        private EventHubsTransportType Transport { get; }

        /// <summary>
        ///   The proxy, if any, which should be used for communication.
        /// </summary>
        ///
        private IWebProxy Proxy { get; }

        /// <summary>
        ///   The size of the buffer used for sending information via the active transport.
        /// </summary>
        ///
        private int SendBufferSizeInBytes { get; }

        /// <summary>
        ///   The size of the buffer used for receiving information via the active transport.
        /// </summary>
        ///
        private int ReceiveBufferSizeInBytes { get; }

        /// <summary>
        ///   A <see cref="RemoteCertificateValidationCallback" /> delegate allowing custom logic to be considered for
        ///   validation of the remote certificate responsible for encrypting communication.
        /// </summary>
        ///
        private RemoteCertificateValidationCallback CertificateValidationCallback { get; }

        /// <summary>
        ///   The AMQP connection that is active for the current scope.
        /// </summary>
        ///
        private FaultTolerantAmqpObject<AmqpConnection> ActiveConnection { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpConnectionScope"/> class.
        /// </summary>
        ///
        /// <param name="serviceEndpoint">The endpoint for the Event Hubs service to which the scope is associated.</param>
        /// <param name="connectionEndpoint">The endpoint to used establishing a connection to the Event Hubs service to which the scope is associated.</param>
        /// <param name="eventHubName"> The name of the Event Hub to which the scope is associated.</param>
        /// <param name="credential">The credential to use for authorization with the Event Hubs service.</param>
        /// <param name="transport">The transport to use for communication.</param>
        /// <param name="proxy">The proxy, if any, to use for communication.</param>
        /// <param name="identifier">The identifier to assign this scope; if not provided, one will be generated.</param>
        /// <param name="sendBufferSizeBytes">The size, in bytes, of the buffer to use for sending via the transport.</param>
        /// <param name="receiveBufferSizeBytes">The size, in bytes, of the buffer to use for receiving from the transport.</param>
        /// <param name="certificateValidationCallback">The validation callback to register for participation in the SSL handshake.</param>
        ///
        public AmqpConnectionScope(Uri serviceEndpoint,
                                   Uri connectionEndpoint,
                                   string eventHubName,
                                   EventHubTokenCredential credential,
                                   EventHubsTransportType transport,
                                   IWebProxy proxy,
                                   string identifier = default,
                                   int sendBufferSizeBytes = AmqpConstants.TransportBufferSize,
                                   int receiveBufferSizeBytes = AmqpConstants.TransportBufferSize,
                                   RemoteCertificateValidationCallback certificateValidationCallback = default)
        {
            Argument.AssertNotNull(serviceEndpoint, nameof(serviceEndpoint));
            Argument.AssertNotNull(connectionEndpoint, nameof(connectionEndpoint));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));
            ValidateTransport(transport);

            ServiceEndpoint = serviceEndpoint;
            ConnectionEndpoint = connectionEndpoint;
            EventHubName = eventHubName;
            Transport = transport;
            Proxy = proxy;
            SendBufferSizeInBytes = sendBufferSizeBytes;
            ReceiveBufferSizeInBytes = receiveBufferSizeBytes;
            CertificateValidationCallback = certificateValidationCallback;
            TokenProvider = new CbsTokenProvider(new EventHubTokenCredential(credential), OperationCancellationSource.Token);
            Id = identifier ?? $"{ eventHubName }-{ Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture).Substring(0, 8) }";

            Task<AmqpConnection> connectionFactory(TimeSpan timeout) => CreateAndOpenConnectionAsync(AmqpVersion, ServiceEndpoint, ConnectionEndpoint, Transport, Proxy, SendBufferSizeInBytes, ReceiveBufferSizeInBytes, CertificateValidationCallback, Id, timeout);
            ActiveConnection = new FaultTolerantAmqpObject<AmqpConnection>(connectionFactory, CloseConnection);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpConnectionScope"/> class.
        /// </summary>
        ///
        protected AmqpConnectionScope()
        {
        }

        /// <summary>
        ///   Opens an AMQP link for use with management operations.
        /// </summary>
        ///
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use with management operations.</returns>
        ///
        /// <remarks>
        ///   The authorization for this link does not require periodic
        ///   refreshing.
        /// </remarks>
        ///
        public virtual async Task<RequestResponseAmqpLink> OpenManagementLinkAsync(TimeSpan timeout,
                                                                                   CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(_disposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            try
            {
                EventHubsEventSource.Log.AmqpManagementLinkCreateStart(EventHubName);

                var stopWatch = ValueStopwatch.StartNew();
                var connection = await ActiveConnection.GetOrCreateAsync(timeout).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                var link = await CreateManagementLinkAsync(connection, timeout.CalculateRemaining(stopWatch.GetElapsedTime()), cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                await OpenAmqpObjectAsync(link, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                return link;
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.AmqpManagementLinkCreateError(EventHubName, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.AmqpManagementLinkCreateComplete(EventHubName);
            }
        }

        /// <summary>
        ///   Opens an AMQP link for use with consumer operations.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group in the context of which events should be received.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events should be received.</param>
        /// <param name="eventPosition">The position of the event in the partition where the link should be filtered to.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.</param>
        /// <param name="prefetchSizeInBytes">The cache size of the prefetch queue. When set, the link makes a best effort to ensure prefetched messages fit into the specified size.</param>
        /// <param name="ownerLevel">The relative priority to associate with the link; for a non-exclusive link, this value should be <c>null</c>.</param>
        /// <param name="trackLastEnqueuedEventProperties">Indicates whether information on the last enqueued event on the partition is sent as events are received.</param>
        /// <param name="linkIdentifier">The identifier to assign to the link; if <c>null</c> or <see cref="string.Empty" />, a random identifier will be generated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use with consumer operations.</returns>
        ///
        public virtual async Task<ReceivingAmqpLink> OpenConsumerLinkAsync(string consumerGroup,
                                                                           string partitionId,
                                                                           EventPosition eventPosition,
                                                                           TimeSpan timeout,
                                                                           uint prefetchCount,
                                                                           long? prefetchSizeInBytes,
                                                                           long? ownerLevel,
                                                                           bool trackLastEnqueuedEventProperties,
                                                                           string linkIdentifier,
                                                                           CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(_disposed, nameof(AmqpConnectionScope));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var ownerLevelLog = ownerLevel?.ToString(CultureInfo.InvariantCulture);
            var eventPositionLog = eventPosition.ToString();

            try
            {
                EventHubsEventSource.Log.AmqpConsumerLinkCreateStart(EventHubName, consumerGroup, partitionId, ownerLevelLog, eventPositionLog);

                var stopWatch = ValueStopwatch.StartNew();
                var consumerEndpoint = new Uri(ServiceEndpoint, string.Format(CultureInfo.InvariantCulture, ConsumerPathSuffixMask, EventHubName, consumerGroup, partitionId));

                var connection = await ActiveConnection.GetOrCreateAsync(timeout).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (string.IsNullOrEmpty(linkIdentifier))
                {
                    linkIdentifier = Guid.NewGuid().ToString();
                }

                var link = await CreateReceivingLinkAsync(
                    connection,
                    consumerEndpoint,
                    eventPosition,
                    timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                    prefetchCount,
                    prefetchSizeInBytes,
                    ownerLevel,
                    trackLastEnqueuedEventProperties,
                    linkIdentifier,
                    cancellationToken
                ).ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                await OpenAmqpObjectAsync(link, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                return link;
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.AmqpConsumerLinkCreateError(EventHubName, consumerGroup, partitionId, ownerLevelLog, eventPositionLog, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.AmqpConsumerLinkCreateComplete(EventHubName, consumerGroup, partitionId, ownerLevelLog, eventPositionLog);
            }
        }

        /// <summary>
        ///   Opens an AMQP link for use with producer operations.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition to which the link should be bound; if unbound, <c>null</c>.</param>
        /// <param name="features">The set of features which are active for the producer requesting the link.</param>
        /// <param name="options">The set of options to consider when creating the link.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="linkIdentifier">The identifier to assign to the link; if <c>null</c> or <see cref="string.Empty" />, a random identifier will be generated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use with producer operations.</returns>
        ///
        public virtual async Task<SendingAmqpLink> OpenProducerLinkAsync(string partitionId,
                                                                         TransportProducerFeatures features,
                                                                         PartitionPublishingOptions options,
                                                                         TimeSpan timeout,
                                                                         string linkIdentifier,
                                                                         CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(_disposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var featuresLog = features.ToString();

            try
            {
                EventHubsEventSource.Log.AmqpProducerLinkCreateStart(EventHubName, partitionId, featuresLog);

                var stopWatch = ValueStopwatch.StartNew();
                var path = (string.IsNullOrEmpty(partitionId)) ? EventHubName : string.Format(CultureInfo.InvariantCulture, PartitionProducerPathSuffixMask, EventHubName, partitionId);
                var producerEndpoint = new Uri(ServiceEndpoint, path);

                var connection = await ActiveConnection.GetOrCreateAsync(timeout).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (string.IsNullOrEmpty(linkIdentifier))
                {
                    linkIdentifier = Guid.NewGuid().ToString();
                }

                var link = await CreateSendingLinkAsync(connection, producerEndpoint, features, options, timeout.CalculateRemaining(stopWatch.GetElapsedTime()), linkIdentifier, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                await OpenAmqpObjectAsync(link, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                return link;
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.AmqpProducerLinkCreateError(EventHubName, partitionId, featuresLog, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.AmqpProducerLinkCreateComplete(EventHubName, partitionId, featuresLog);
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="AmqpConnectionScope" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            ActiveConnection?.Dispose();
            OperationCancellationSource.Cancel();
            OperationCancellationSource.Dispose();

            IsDisposed = true;
        }

        /// <summary>
        ///   Creates an AMQP connection for a given scope.
        /// </summary>
        ///
        /// <param name="amqpVersion">The version of AMQP to use for the connection.</param>
        /// <param name="serviceEndpoint">The endpoint for the Event Hubs service to which the scope is associated.</param>
        /// <param name="connectionEndpoint">The endpoint to used establishing a connection to the Event Hubs service to which the scope is associated.</param>
        /// <param name="transportType">The type of transport to use for communication.</param>
        /// <param name="proxy">The proxy, if any, to use for communication.</param>
        /// <param name="sendBufferSizeBytes">The size, in bytes, of the buffer to use for sending via the transport.</param>
        /// <param name="receiveBufferSizeBytes">The size, in bytes, of the buffer to use for receiving from the transport.</param>
        /// <param name="certificateValidationCallback">The validation callback to register for participation in the SSL handshake.</param>
        /// <param name="scopeIdentifier">The unique identifier for the associated scope.</param>
        /// <param name="timeout">The timeout to consider when creating the connection.</param>
        ///
        /// <returns>An AMQP connection that may be used for communicating with the Event Hubs service.</returns>
        ///
        protected virtual async Task<AmqpConnection> CreateAndOpenConnectionAsync(Version amqpVersion,
                                                                                  Uri serviceEndpoint,
                                                                                  Uri connectionEndpoint,
                                                                                  EventHubsTransportType transportType,
                                                                                  IWebProxy proxy,
                                                                                  int sendBufferSizeBytes,
                                                                                  int receiveBufferSizeBytes,
                                                                                  RemoteCertificateValidationCallback certificateValidationCallback,
                                                                                  string scopeIdentifier,
                                                                                  TimeSpan timeout)
        {
            var serviceEndpointLog = serviceEndpoint.AbsoluteUri;
            var transportTypeLog = transportType.ToString();

            EventHubsEventSource.Log.AmqpConnectionCreateStart(serviceEndpointLog, transportTypeLog);

            try
            {
                var amqpSettings = CreateAmpqSettings(AmqpVersion);
                var connectionSetings = CreateAmqpConnectionSettings(serviceEndpoint.Host, scopeIdentifier);

                var transportSettings = transportType.IsWebSocketTransport()
                    ? CreateTransportSettingsForWebSockets(connectionEndpoint.Host, proxy, sendBufferSizeBytes, receiveBufferSizeBytes)
                    : CreateTransportSettingsforTcp(connectionEndpoint.Host, connectionEndpoint.Port, sendBufferSizeBytes, receiveBufferSizeBytes, certificateValidationCallback);

                // Create and open the connection, respecting the timeout constraint
                // that was received.

                var stopWatch = ValueStopwatch.StartNew();

                var initiator = new AmqpTransportInitiator(amqpSettings, transportSettings);
                var transport = await initiator.ConnectTaskAsync(timeout).ConfigureAwait(false);

                var connection = new AmqpConnection(transport, amqpSettings, connectionSetings);
                await OpenAmqpObjectAsync(connection, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);

                // Create the CBS link that will be used for authorization.  The act of creating the link will associate
                // it with the connection.

                _ = new AmqpCbsLink(connection);

                // When the connection is closed, close each of the links associated with it.

                EventHandler closeHandler = null;

                closeHandler = (snd, args) =>
                {
                    foreach (var link in ActiveLinks.Keys)
                    {
                        link.SafeClose();
                    }

                    connection.Closed -= closeHandler;
                };

                connection.Closed += closeHandler;
                return connection;
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.AmqpConnectionCreateStartError(serviceEndpointLog, transportTypeLog, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.AmqpConnectionCreateComplete(serviceEndpointLog, transportTypeLog);
            }
        }

        /// <summary>
        ///   Creates an AMQP link for use with management operations.
        /// </summary>
        ///
        /// <param name="connection">The active and opened AMQP connection to use for this link.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use with management operations.</returns>
        ///
        protected virtual async Task<RequestResponseAmqpLink> CreateManagementLinkAsync(AmqpConnection connection,
                                                                                        TimeSpan timeout,
                                                                                        CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var session = default(AmqpSession);
            var stopWatch = ValueStopwatch.StartNew();

            try
            {
                // Create and open the AMQP session associated with the link.

                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);

                await OpenAmqpObjectAsync(session, timeout).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the link.

                var linkSettings = new AmqpLinkSettings();
                linkSettings.AddProperty(AmqpProperty.Timeout, (uint)timeout.CalculateRemaining(stopWatch.GetElapsedTime()).TotalMilliseconds);

                var link = new RequestResponseAmqpLink(AmqpManagement.LinkType, session, AmqpManagement.Address, linkSettings.Properties);

                // Track the link before returning it, so that it can be managed with the scope.

                BeginTrackingLinkAsActive(link);
                return link;
            }
            catch
            {
                // Aborting the session will perform any necessary cleanup of
                // the associated link as well.

                session?.Abort();
                throw;
            }
        }

        /// <summary>
        ///   Creates an AMQP link for use with receiving operations.
        /// </summary>
        ///
        /// <param name="connection">The active and opened AMQP connection to use for this link.</param>
        /// <param name="endpoint">The fully qualified endpoint to open the link for.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="eventPosition">The position of the event in the partition where the link should be filtered to.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.</param>
        /// <param name="prefetchSizeInBytes">The cache size of the prefetch queue. When set, the link makes a best effort to ensure prefetched messages fit into the specified size.</param>
        /// <param name="ownerLevel">The relative priority to associate with the link; for a non-exclusive link, this value should be <c>null</c>.</param>
        /// <param name="trackLastEnqueuedEventProperties">Indicates whether information on the last enqueued event on the partition is sent as events are received.</param>
        /// <param name="linkIdentifier">The identifier to assign to the link; this is assumed to be a non-null value.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use for operations related to receiving events.</returns>
        ///
        protected virtual async Task<ReceivingAmqpLink> CreateReceivingLinkAsync(AmqpConnection connection,
                                                                                 Uri endpoint,
                                                                                 EventPosition eventPosition,
                                                                                 TimeSpan timeout,
                                                                                 uint prefetchCount,
                                                                                 long? prefetchSizeInBytes,
                                                                                 long? ownerLevel,
                                                                                 bool trackLastEnqueuedEventProperties,
                                                                                 string linkIdentifier,
                                                                                 CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var session = default(AmqpSession);
            var stopWatch = ValueStopwatch.StartNew();

            try
            {
                // Perform the initial authorization for the link.

                var authClaims = new[] { EventHubsClaim.Listen };
                var authExpirationUtc = await RequestAuthorizationUsingCbsAsync(connection, TokenProvider, endpoint, endpoint.AbsoluteUri, endpoint.AbsoluteUri, authClaims, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the AMQP session associated with the link.

                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);

                await OpenAmqpObjectAsync(session, timeout).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the link.

                var filters = new FilterSet();
                filters.Add(AmqpFilter.ConsumerFilterName, AmqpFilter.CreateConsumerFilter(AmqpFilter.BuildFilterExpression(eventPosition)));

                var linkSettings = new AmqpLinkSettings
                {
                    Role = true,
                    TotalLinkCredit = prefetchCount,
                    AutoSendFlow = prefetchCount > 0,
                    SettleType = SettleMode.SettleOnSend,
                    Source = new Source { Address = endpoint.AbsolutePath, FilterSet = filters },
                    Target = new Target { Address = linkIdentifier },
                    TotalCacheSizeInBytes = prefetchSizeInBytes
                };

                linkSettings.AddProperty(AmqpProperty.EntityType, (int)AmqpProperty.Entity.ConsumerGroup);

                if (ownerLevel.HasValue)
                {
                    linkSettings.AddProperty(AmqpProperty.ConsumerOwnerLevel, ownerLevel.Value);
                }

                if (linkIdentifier != null)
                {
                    linkSettings.AddProperty(AmqpProperty.ConsumerIdentifier, linkIdentifier);
                }

                if (trackLastEnqueuedEventProperties)
                {
                    linkSettings.DesiredCapabilities ??= new Multiple<AmqpSymbol>();
                    linkSettings.DesiredCapabilities.Add(AmqpProperty.TrackLastEnqueuedEventProperties);
                }

                var link = new ReceivingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{ Id };{ connection.Identifier }:{ session.Identifier }:{ link.Identifier }";
                link.AttachTo(session);

                // Configure refresh for authorization of the link.

                var refreshTimer = default(Timer);

                var refreshHandler = CreateAuthorizationRefreshHandler
                (
                    connection,
                    link,
                    TokenProvider,
                    endpoint,
                    endpoint.AbsoluteUri,
                    endpoint.AbsoluteUri,
                    authClaims,
                    AuthorizationRefreshTimeout,
                    () => (ActiveLinks.ContainsKey(link) ? refreshTimer : null)
                );

                refreshTimer = new Timer(refreshHandler, null, CalculateLinkAuthorizationRefreshInterval(authExpirationUtc), Timeout.InfiniteTimeSpan);

                // Track the link before returning it, so that it can be managed with the scope.

                BeginTrackingLinkAsActive(link, refreshTimer);
                return link;
            }
            catch
            {
                // Aborting the session will perform any necessary cleanup of
                // the associated link as well.

                session?.Abort();
                throw;
            }
        }

        /// <summary>
        ///   Creates an AMQP link for use with publishing operations.
        /// </summary>
        ///
        /// <param name="connection">The active and opened AMQP connection to use for this link.</param>
        /// <param name="endpoint">The fully qualified endpoint to open the link for.</param>
        /// <param name="features">The set of features which are active for the producer for which the link is being created.</param>
        /// <param name="options">The set of options to consider when creating the link.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="linkIdentifier">The identifier to assign to the link; this is assumed to be a non-null value.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use for operations related to receiving events.</returns>
        ///
        protected virtual async Task<SendingAmqpLink> CreateSendingLinkAsync(AmqpConnection connection,
                                                                             Uri endpoint,
                                                                             TransportProducerFeatures features,
                                                                             PartitionPublishingOptions options,
                                                                             TimeSpan timeout,
                                                                             string linkIdentifier,
                                                                             CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var session = default(AmqpSession);
            var stopWatch = ValueStopwatch.StartNew();

            try
            {
                // Perform the initial authorization for the link.

                var authClaims = new[] { EventHubsClaim.Send };
                var authExpirationUtc = await RequestAuthorizationUsingCbsAsync(connection, TokenProvider, endpoint, endpoint.AbsoluteUri, endpoint.AbsoluteUri, authClaims, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the AMQP session associated with the link.

                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);

                await OpenAmqpObjectAsync(session, timeout).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the link.

                var linkSettings = new AmqpLinkSettings
                {
                    Role = false,
                    InitialDeliveryCount = 0,
                    Source = new Source { Address = linkIdentifier },
                    Target = new Target { Address = endpoint.AbsolutePath }
                };

                linkSettings.AddProperty(AmqpProperty.Timeout, (uint)timeout.CalculateRemaining(stopWatch.GetElapsedTime()).TotalMilliseconds);
                linkSettings.AddProperty(AmqpProperty.EntityType, (int)AmqpProperty.Entity.EventHub);

                if ((features & TransportProducerFeatures.IdempotentPublishing) != 0)
                {
                    linkSettings.DesiredCapabilities ??= new Multiple<AmqpSymbol>();
                    linkSettings.DesiredCapabilities.Add(AmqpProperty.EnableIdempotentPublishing);
                }

                // If any of the options have a value, the entire set must be specified for the link settings.  For any options that did not have a
                // value, specifying null will signal the service to generate the value.

                if ((options.ProducerGroupId.HasValue) || (options.OwnerLevel.HasValue) || (options.StartingSequenceNumber.HasValue))
                {
                    linkSettings.AddProperty(AmqpProperty.ProducerGroupId, options.ProducerGroupId);
                    linkSettings.AddProperty(AmqpProperty.ProducerOwnerLevel, options.OwnerLevel);
                    linkSettings.AddProperty(AmqpProperty.ProducerSequenceNumber, options.StartingSequenceNumber);
                }

                var link = new SendingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{ Id };{ connection.Identifier }:{ session.Identifier }:{ link.Identifier }";
                link.AttachTo(session);

                // Configure refresh for authorization of the link.

                var refreshTimer = default(Timer);

                var refreshHandler = CreateAuthorizationRefreshHandler
                (
                    connection,
                    link,
                    TokenProvider,
                    endpoint,
                    endpoint.AbsoluteUri,
                    endpoint.AbsoluteUri,
                    authClaims,
                    AuthorizationRefreshTimeout,
                    () => refreshTimer
                );

                refreshTimer = new Timer(refreshHandler, null, CalculateLinkAuthorizationRefreshInterval(authExpirationUtc), Timeout.InfiniteTimeSpan);

                // Track the link before returning it, so that it can be managed with the scope.

                BeginTrackingLinkAsActive(link, refreshTimer);
                return link;
            }
            catch
            {
                // Aborting the session will perform any necessary cleanup of
                // the associated link as well.

                session?.Abort();
                throw;
            }
        }

        /// <summary>
        ///   Performs the actions needed to configure and begin tracking the specified AMQP
        ///   link as an active link bound to this scope.
        /// </summary>
        ///
        /// <param name="link">The link to begin tracking.</param>
        /// <param name="authorizationRefreshTimer">The timer used to manage refreshing authorization, if the link requires it.</param>
        ///
        /// <remarks>
        ///   This method does operate on the specified <paramref name="link"/> in order to configure it
        ///   for active tracking; no assumptions are made about the open/connected state of the link nor are
        ///   its communication properties modified.
        /// </remarks>
        ///
        protected virtual void BeginTrackingLinkAsActive(AmqpObject link,
                                                         Timer authorizationRefreshTimer = null)
        {
            // Register the link as active and having authorization automatically refreshed, so that it can be
            // managed with the scope.

            if (!ActiveLinks.TryAdd(link, authorizationRefreshTimer))
            {
                throw new EventHubsException(true, EventHubName, Resources.CouldNotCreateLink);
            }

            // When the link is closed, stop refreshing authorization and remove it from the
            // set of associated links.

            var closeHandler = default(EventHandler);

            closeHandler = (snd, args) =>
            {
                ActiveLinks.TryRemove(link, out var timer);

                timer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
                timer?.Dispose();

                link.Closed -= closeHandler;
            };

            link.Closed += closeHandler;
        }

        /// <summary>
        ///   Performs the tasks needed to close a connection.
        /// </summary>
        ///
        /// <param name="connection">The connection to close.</param>
        ///
        protected virtual void CloseConnection(AmqpConnection connection)
        {
            connection.SafeClose();
            EventHubsEventSource.Log.FaultTolerantAmqpObjectClose(nameof(AmqpConnection), "", EventHubName, "", "", connection.TerminalException?.Message);
        }

        /// <summary>
        ///   Calculates the interval after which authorization for an AMQP link should be
        ///   refreshed.
        /// </summary>
        ///
        /// <param name="expirationTimeUtc">The date/time, in UTC, that the current authorization is expected to expire.</param>
        /// <param name="currentTimeUtc">The current date/time, in UTC.  If not specified, the system time will be used.</param>
        ///
        /// <returns>The interval after which authorization should be refreshed.</returns>
        ///
        protected virtual TimeSpan CalculateLinkAuthorizationRefreshInterval(DateTime expirationTimeUtc,
                                                                             DateTime? currentTimeUtc = null)
        {
            currentTimeUtc ??= DateTime.UtcNow;

            var refreshDueInterval = (expirationTimeUtc.Subtract(AuthorizationRefreshBuffer)).Subtract(currentTimeUtc.Value);

            return refreshDueInterval switch
            {
                _ when (refreshDueInterval < MinimumAuthorizationRefresh) => MinimumAuthorizationRefresh,
                _ when (refreshDueInterval > MaximumAuthorizationRefresh) => MaximumAuthorizationRefresh,
                _ => refreshDueInterval
            };
        }

        /// <summary>
        ///   Creates the timer event handler to support refreshing AMQP link authorization
        ///   on a recurring basis.
        /// </summary>
        ///
        /// <param name="connection">The AMQP connection to which the link being refreshed is bound to.</param>
        /// <param name="amqpLink">The AMQO link to refresh authorization for.</param>
        /// <param name="tokenProvider">The <see cref="CbsTokenProvider" /> to use for obtaining access tokens.</param>
        /// <param name="endpoint">The Event Hubs service endpoint that the AMQP link is communicating with.</param>
        /// <param name="audience">The audience associated with the authorization.  This is likely the <paramref name="endpoint"/> absolute URI.</param>
        /// <param name="resource">The resource associated with the authorization.  This is likely the <paramref name="endpoint"/> absolute URI.</param>
        /// <param name="requiredClaims">The set of claims required to support the operations of the AMQP link.</param>
        /// <param name="refreshTimeout">The timeout to apply when requesting authorization refresh.</param>
        /// <param name="refreshTimerFactory">A function to allow retrieving the <see cref="Timer" /> associated with the link authorization.</param>
        ///
        /// <returns>A <see cref="TimerCallback"/> delegate to perform the refresh when a timer is due.</returns>
        ///
        protected virtual TimerCallback CreateAuthorizationRefreshHandler(AmqpConnection connection,
                                                                          AmqpObject amqpLink,
                                                                          CbsTokenProvider tokenProvider,
                                                                          Uri endpoint,
                                                                          string audience,
                                                                          string resource,
                                                                          string[] requiredClaims,
                                                                          TimeSpan refreshTimeout,
                                                                          Func<Timer> refreshTimerFactory)
        {
            return async _ =>
            {
                EventHubsEventSource.Log.AmqpLinkAuthorizationRefreshStart(EventHubName, endpoint.AbsoluteUri);
                var refreshTimer = refreshTimerFactory();

                try
                {
                    if (refreshTimer == null)
                    {
                        return;
                    }

                    var authExpirationUtc = await RequestAuthorizationUsingCbsAsync(connection, tokenProvider, endpoint, audience, resource, requiredClaims, refreshTimeout).ConfigureAwait(false);

                    // Reset the timer for the next refresh.

                    if (authExpirationUtc >= DateTimeOffset.UtcNow)
                    {
                        refreshTimer.Change(CalculateLinkAuthorizationRefreshInterval(authExpirationUtc), Timeout.InfiniteTimeSpan);
                    }
                }
                catch (ObjectDisposedException)
                {
                    // This can occur if the connection is closed or the scope disposed after the factory
                    // is called but before the timer is updated.  The callback may also fire while the timer is
                    // in the act of disposing.  Do not consider it an error.
                }
                catch (Exception ex)
                {
                    EventHubsEventSource.Log.AmqpLinkAuthorizationRefreshError(EventHubName, endpoint.AbsoluteUri, ex.Message);

                    // Attempt to unset the timer; there's a decent chance that it has been disposed at this point or
                    // that the connection has been closed.  Ignore potential exceptions, as they won't impact operation.
                    // At worse, another timer tick will occur and the operation will be retried.

                    try
                    {
                        refreshTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    }
                    catch
                    {
                        // Intentionally ignored.
                    }
                }
                finally
                {
                    EventHubsEventSource.Log.AmqpLinkAuthorizationRefreshComplete(EventHubName, endpoint.AbsoluteUri);
                }
            };
        }

        /// <summary>
        ///   Performs the actions needed to open an AMQP object, such
        ///   as a session or link for use.
        /// </summary>
        ///
        /// <param name="target">The target AMQP object to open.</param>
        /// <param name="timeout">The timeout to apply when opening the link.</param>
        ///
        protected virtual async Task OpenAmqpObjectAsync(AmqpObject target,
                                                         TimeSpan timeout)
        {
            try
            {
                await target.OpenAsync(timeout).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                switch (target)
                {
                    case AmqpLink linkTarget:
                        linkTarget.Session?.SafeClose();
                        break;
                    case RequestResponseAmqpLink linkTarget:
                        linkTarget.Session?.SafeClose();
                        break;

                    default:
                        break;
                }

                target.SafeClose();

                // The AMQP library may throw an InvalidOperationException or one of its derived types, such as
                // ObjectDisposedException if the underlying network state changes.  While normally terminal, in this
                // context, these exception types are safe to retry.  Translate them so that the retry policy
                // can correctly interpret.

                switch (ex)
                {
                    case InvalidOperationException:
                        throw new EventHubsException(true, EventHubName, Resources.CouldNotCreateLink, EventHubsException.FailureReason.ServiceCommunicationProblem, ex);

                    default:
                        throw;
                }
            }
        }

        /// <summary>
        ///   Requests authorization for a connection or link using a connection via the CBS mechanism.
        /// </summary>
        ///
        /// <param name="connection">The AMQP connection for which the authorization is associated.</param>
        /// <param name="tokenProvider">The <see cref="CbsTokenProvider" /> to use for obtaining access tokens.</param>
        /// <param name="endpoint">The Event Hubs service endpoint that the authorization is requested for.</param>
        /// <param name="audience">The audience associated with the authorization.  This is likely the <paramref name="endpoint"/> absolute URI.</param>
        /// <param name="resource">The resource associated with the authorization.  This is likely the <paramref name="endpoint"/> absolute URI.</param>
        /// <param name="requiredClaims">The set of claims required to support the operations of the AMQP link.</param>
        /// <param name="timeout">The timeout to apply when requesting authorization.</param>
        ///
        /// <returns>The date/time, in UTC, when the authorization expires.</returns>
        ///
        /// <remarks>
        ///   It is assumed that there is a valid <see cref="AmqpCbsLink" /> already associated
        ///   with the connection; this will be used as the transport for the authorization
        ///   credentials.
        /// </remarks>
        ///
        protected virtual async Task<DateTime> RequestAuthorizationUsingCbsAsync(AmqpConnection connection,
                                                                                 CbsTokenProvider tokenProvider,
                                                                                 Uri endpoint,
                                                                                 string audience,
                                                                                 string resource,
                                                                                 string[] requiredClaims,
                                                                                 TimeSpan timeout)
        {
            try
            {
                // If the connection is in the process of closing, then do not attempt to authorize but consider it an
                // unexpected scenario that should be treated as transient.

                if (connection.IsClosing())
                {
                    throw new EventHubsException(true, EventHubName, Resources.UnknownCommunicationException, EventHubsException.FailureReason.ServiceCommunicationProblem);
                }

                var authLink = connection.Extensions.Find<AmqpCbsLink>();
                return await authLink.SendTokenAsync(TokenProvider, endpoint, audience, resource, requiredClaims, timeout).ConfigureAwait(false);
            }
            catch (Exception ex) when ((ex is ObjectDisposedException) || (ex is OperationCanceledException))
            {
                // In the case where the attempt times out, a task cancellation occurs, which in other code paths is
                // considered a terminal exception.  In this case, it should be viewed as transient.
                //
                // When there's a race condition between sending the authorization request and the connection/link closing, the
                // link can sometimes be disposed when this call is taking place; because retries are likely to succeed, consider
                // this case transient.
                //
                // Wrap the source exception in a custom exception to ensure that it is eligible to be retried.

                throw new EventHubsException(true, EventHubName, Resources.UnknownCommunicationException, EventHubsException.FailureReason.ServiceCommunicationProblem, ex);
            }
        }

        /// <summary>
        ///   Creates the settings to use for AMQP communication.
        /// </summary>
        ///
        /// <param name="amqpVersion">The version of AMQP to be used.</param>
        ///
        /// <returns>The settings for AMQP to use for communication with the Event Hubs service.</returns>
        ///
        private static AmqpSettings CreateAmpqSettings(Version amqpVersion)
        {
            var saslProvider = new SaslTransportProvider();
            saslProvider.Versions.Add(new AmqpVersion(amqpVersion));
            saslProvider.AddHandler(new SaslAnonymousHandler(CbsSaslHandlerName));

            var amqpProvider = new AmqpTransportProvider();
            amqpProvider.Versions.Add(new AmqpVersion(amqpVersion));

            var settings = new AmqpSettings();
            settings.TransportProviders.Add(saslProvider);
            settings.TransportProviders.Add(amqpProvider);

            return settings;
        }

        /// <summary>
        ///  Creates the transport settings for use with TCP.
        /// </summary>
        ///
        /// <param name="hostName">The host name of the Event Hubs service endpoint.</param>
        /// <param name="port">The port to use for connecting to the endpoint.</param>
        /// <param name="sendBufferSizeBytes">The size, in bytes, of the buffer to use for sending via the transport.</param>
        /// <param name="receiveBufferSizeBytes">The size, in bytes, of the buffer to use for receiving from the transport.</param>
        /// <param name="certificateValidationCallback">The validation callback to register for participation in the SSL handshake.</param>
        ///
        /// <returns>The settings to use for transport.</returns>
        ///
        private static TransportSettings CreateTransportSettingsforTcp(string hostName,
                                                                       int port,
                                                                       int sendBufferSizeBytes,
                                                                       int receiveBufferSizeBytes,
                                                                       RemoteCertificateValidationCallback certificateValidationCallback)
        {
            var tcpSettings = new TcpTransportSettings
            {
                Host = hostName,
                Port = port < 0 ? AmqpConstants.DefaultSecurePort : port,
                SendBufferSize = sendBufferSizeBytes,
                ReceiveBufferSize = receiveBufferSizeBytes,
            };

            return new TlsTransportSettings(tcpSettings)
            {
                TargetHost = hostName,
                CertificateValidationCallback = certificateValidationCallback
            };
        }

        /// <summary>
        ///  Creates the transport settings for use with web sockets.
        /// </summary>
        ///
        /// <param name="hostName">The host name of the Event Hubs service endpoint.</param>
        /// <param name="proxy">The proxy to use for connecting to the endpoint.</param>
        /// <param name="sendBufferSizeBytes">The size, in bytes, of the buffer to use for sending via the transport.</param>
        /// <param name="receiveBufferSizeBytes">The size, in bytes, of the buffer to use for receiving from the transport.</param>
        ///
        /// <returns>The settings to use for transport.</returns>
        ///
        private static TransportSettings CreateTransportSettingsForWebSockets(string hostName,
                                                                              IWebProxy proxy,
                                                                              int sendBufferSizeBytes,
                                                                              int receiveBufferSizeBytes)
        {
            var uriBuilder = new UriBuilder(hostName)
            {
                Path = WebSocketsPathSuffix,
                Scheme = WebSocketsUriScheme,
                Port = -1
            };

            return new WebSocketTransportSettings
            {
                Uri = uriBuilder.Uri,
                Proxy = proxy,
                SendBufferSize = sendBufferSizeBytes,
                ReceiveBufferSize = receiveBufferSizeBytes
            };
        }

        /// <summary>
        ///   Creates the AMQP connection settings to use when communicating with the Event Hubs service.
        /// </summary>
        ///
        /// <param name="hostName">The host name of the Event Hubs service endpoint.</param>
        /// <param name="identifier">unique identifier of the current Event Hubs scope.</param>
        ///
        /// <returns>The settings to apply to the connection.</returns>
        ///
        private static AmqpConnectionSettings CreateAmqpConnectionSettings(string hostName,
                                                                           string identifier)
        {
            var connectionSettings = new AmqpConnectionSettings
            {
                IdleTimeOut = (uint)ConnectionIdleTimeout.TotalMilliseconds,
                MaxFrameSize = AmqpConstants.DefaultMaxFrameSize,
                ContainerId = identifier,
                HostName = hostName
            };

            foreach (KeyValuePair<string, string> property in ClientLibraryInformation.Current.EnumerateProperties())
            {
                connectionSettings.AddProperty(property.Key, property.Value);
            }

            return connectionSettings;
        }

        /// <summary>
        ///   Validates the transport associated with the scope, throwing an argument exception
        ///   if it is unknown in this context.
        /// </summary>
        ///
        /// <param name="transport">The transport to validate.</param>
        ///
        private static void ValidateTransport(EventHubsTransportType transport)
        {
            if ((transport != EventHubsTransportType.AmqpTcp) && (transport != EventHubsTransportType.AmqpWebSockets))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.UnknownConnectionType, transport), nameof(transport));
            }
        }
    }
}
