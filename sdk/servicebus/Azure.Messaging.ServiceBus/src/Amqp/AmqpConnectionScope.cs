// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Amqp.Sasl;
using Microsoft.Azure.Amqp.Transaction;
using Microsoft.Azure.Amqp.Transport;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   Defines a context for AMQP operations which can be shared amongst the different
    ///   client types within a given scope.
    /// </summary>
    internal class AmqpConnectionScope : TransportConnectionScope
    {
        /// <summary>The name to assign to the SASL handler to specify that CBS tokens are in use.</summary>
        private const string CbsSaslHandlerName = "MSSBCBS";

        /// <summary>The suffix to attach to the resource path when using web sockets for service communication.</summary>
        private const string WebSocketsPathSuffix = "/$servicebus/websocket/";

        /// <summary>The URI scheme to apply when using web sockets for service communication.</summary>
        private const string WebSocketsUriScheme = "wss";

        /// <summary>
        ///   The version of AMQP to use within the scope.
        /// </summary>
        private static Version AmqpVersion { get; } = new Version(1, 0, 0, 0);

        /// <summary>
        ///   The amount of time to allow an AMQP connection to be idle before considering
        ///   it to be timed out.
        /// </summary>
        private static TimeSpan ConnectionIdleTimeout { get; } = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The amount of buffer to apply to account for clock skew when
        ///   refreshing authorization.  Authorization will be refreshed earlier
        ///   than the expected expiration by this amount.
        /// </summary>
        private static TimeSpan AuthorizationRefreshBuffer { get; } = TimeSpan.FromMinutes(10);

        /// <summary>
        ///   The minimum amount of time for authorization to be refreshed; any calculations that
        ///   call for refreshing more frequently will be substituted with this value.
        /// </summary>
        private static TimeSpan MinimumAuthorizationRefresh { get; } = TimeSpan.FromMinutes(2);

        /// <summary>
        ///   The amount time to allow to refresh authorization of an AMQP link.
        /// </summary>
        private static TimeSpan AuthorizationRefreshTimeout { get; } = TimeSpan.FromMinutes(3);

        /// <summary>
        ///   Indicates whether this <see cref="AmqpConnectionScope"/> has been disposed.
        /// </summary>
        ///
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        public override bool IsDisposed { get; protected set; }

        /// <summary>
        ///   The cancellation token to use with operations initiated by the scope.
        /// </summary>
        private CancellationTokenSource OperationCancellationSource { get; } = new CancellationTokenSource();

        /// <summary>
        ///   The set of active AMQP links associated with the connection scope.  These are considered children
        ///   of the active connection and should be managed as such.
        /// </summary>
        private ConcurrentDictionary<AmqpObject, Timer> ActiveLinks { get; } = new ConcurrentDictionary<AmqpObject, Timer>();

        /// <summary>
        ///   The unique identifier of the scope.
        /// </summary>
        private string Id { get; }

        /// <summary>
        ///   The endpoint for the Service Bus service to which the scope is associated.
        /// </summary>
        private Uri ServiceEndpoint { get; }

        /// <summary>
        ///   The provider to use for obtaining a token for authorization with the Service Bus service.
        /// </summary>
        private CbsTokenProvider TokenProvider { get; }

        /// <summary>
        ///   The type of transport to use for communication.
        /// </summary>
        private ServiceBusTransportType Transport { get; }

        /// <summary>
        ///   The proxy, if any, which should be used for communication.
        /// </summary>
        private IWebProxy Proxy { get; }

        /// <summary>
        ///   The AMQP connection that is active for the current scope.
        /// </summary>
        private FaultTolerantAmqpObject<AmqpConnection> ActiveConnection { get; }

        /// <summary>
        ///  The controller responsible for managing transactions.
        /// </summary>
        public FaultTolerantAmqpObject<Controller> TransactionController { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpConnectionScope"/> class.
        /// </summary>
        ///
        /// <param name="serviceEndpoint">Endpoint for the Service Bus service to which the scope is associated.</param>
        /// <param name="credential">The credential to use for authorization with the Service Bus service.</param>
        /// <param name="transport">The transport to use for communication.</param>
        /// <param name="proxy">The proxy, if any, to use for communication.</param>
        /// <param name="identifier">The identifier to assign this scope; if not provided, one will be generated.</param>
        ///
        public AmqpConnectionScope(Uri serviceEndpoint,
                                   ServiceBusTokenCredential credential,
                                   ServiceBusTransportType transport,
                                   IWebProxy proxy,
                                   string identifier = default)
        {
            Argument.AssertNotNull(serviceEndpoint, nameof(serviceEndpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            ValidateTransport(transport);

            ServiceEndpoint = serviceEndpoint;
            Transport = transport;
            Proxy = proxy;
            TokenProvider = new CbsTokenProvider(new ServiceBusTokenCredential(credential, serviceEndpoint.ToString()), OperationCancellationSource.Token);
            Id = identifier ?? $"{ ServiceEndpoint }-{ Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture).Substring(0, 8) }";

#pragma warning disable CA2214 // Do not call overridable methods in constructors. This internal method is virtual for testing purposes.
            Task<AmqpConnection> connectionFactory(TimeSpan timeout) => CreateAndOpenConnectionAsync(AmqpVersion, ServiceEndpoint, Transport, Proxy, Id, timeout);
#pragma warning restore CA2214 // Do not call overridable methods in constructors
            ActiveConnection = new FaultTolerantAmqpObject<AmqpConnection>(
                connectionFactory,
                CloseConnection);
            TransactionController = new FaultTolerantAmqpObject<Controller>(
                CreateControllerAsync,
                CloseController);
        }

        private async Task<Controller> CreateControllerAsync(TimeSpan timeout)
        {
            var stopWatch = ValueStopwatch.StartNew();
            AmqpConnection connection = await ActiveConnection.GetOrCreateAsync(timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);

            var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
            AmqpSession amqpSession = null;
            Controller controller;

            try
            {
                amqpSession = connection.CreateSession(sessionSettings);
                await amqpSession.OpenAsync(timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);

                controller = new Controller(amqpSession, timeout.CalculateRemaining(stopWatch.GetElapsedTime()));
                await controller.OpenAsync(timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (amqpSession != null)
                {
                    await amqpSession.CloseAsync(timeout).ConfigureAwait(false);
                }

                ServiceBusEventSource.Log.CreateControllerException(ActiveConnection.ToString(), exception.ToString());
                throw;
            }

            return controller;
        }

        private void CloseController(Controller controller) =>
            controller.Close();

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
        /// <param name="entityPath">The path for the entity.</param>
        /// <param name="identifier">The identifier for the sender or receiver that is opening a management link.</param>
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
        public virtual async Task<RequestResponseAmqpLink> OpenManagementLinkAsync(
            string entityPath,
            string identifier,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            ServiceBusEventSource.Log.CreateManagementLinkStart(identifier);
            try
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                var stopWatch = ValueStopwatch.StartNew();
                var connection = await ActiveConnection.GetOrCreateAsync(timeout).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                var link = await CreateManagementLinkAsync(
                    entityPath,
                    identifier,
                    connection,
                    timeout.CalculateRemaining(stopWatch.GetElapsedTime()), cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                await OpenAmqpObjectAsync(link, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                ServiceBusEventSource.Log.CreateManagementLinkComplete(identifier);
                return link;
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.CreateManagementLinkException(identifier, ex.ToString());
                throw;
            }
        }

        /// <summary>
        ///   Opens an AMQP link for use with receiver operations.
        /// </summary>
        /// <param name="identifier">The identifier of the entity that is receiving.</param>
        /// <param name="entityPath">The entity path to receive from.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.</param>
        /// <param name="receiveMode">The <see cref="ServiceBusReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="sessionId">The session to connect to.</param>
        /// <param name="isSessionReceiver">Whether or not this is a sessionful receiver.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use with consumer operations.</returns>
        ///
        public virtual async Task<ReceivingAmqpLink> OpenReceiverLinkAsync(
            string identifier,
            string entityPath,
            TimeSpan timeout,
            uint prefetchCount,
            ServiceBusReceiveMode receiveMode,
            string sessionId,
            bool isSessionReceiver,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var stopWatch = ValueStopwatch.StartNew();
            var receiverEndpoint = new Uri(ServiceEndpoint, entityPath);

            var connection = await ActiveConnection.GetOrCreateAsync(timeout).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            ReceivingAmqpLink link = await CreateReceivingLinkAsync(
                entityPath: entityPath,
                identifier: identifier,
                connection: connection,
                endpoint: receiverEndpoint,
                timeout: timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                prefetchCount: prefetchCount,
                receiveMode: receiveMode,
                sessionId: sessionId,
                isSessionReceiver: isSessionReceiver,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            await OpenAmqpObjectAsync(link, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            return link;
        }

        /// <summary>
        ///   Opens an AMQP link for use with sender operations.
        /// </summary>
        /// <param name="entityPath"></param>
        /// <param name="identifier">The identifier for the sender that is opening a send link.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use with producer operations.</returns>
        ///
        public virtual async Task<SendingAmqpLink> OpenSenderLinkAsync(
            string entityPath,
            string identifier,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var stopWatch = ValueStopwatch.StartNew();

            AmqpConnection connection = await ActiveConnection.GetOrCreateAsync(timeout).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            SendingAmqpLink link = await CreateSendingLinkAsync(
                entityPath: entityPath,
                identifier: identifier,
                connection: connection,
                timeout: timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                cancellationToken: cancellationToken).ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            await OpenAmqpObjectAsync(link, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            return link;
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="AmqpConnectionScope" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        public override void Dispose()
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
        /// <param name="serviceEndpoint">The endpoint for the Service Bus service to which the scope is associated.</param>
        /// <param name="transportType">The type of transport to use for communication.</param>
        /// <param name="proxy">The proxy, if any, to use for communication.</param>
        /// <param name="scopeIdentifier">The unique identifier for the associated scope.</param>
        /// <param name="timeout">The timeout to consider when creating the connection.</param>
        ///
        /// <returns>An AMQP connection that may be used for communicating with the Service Bus service.</returns>
        protected virtual async Task<AmqpConnection> CreateAndOpenConnectionAsync(
            Version amqpVersion,
            Uri serviceEndpoint,
            ServiceBusTransportType transportType,
            IWebProxy proxy,
            string scopeIdentifier,
            TimeSpan timeout)
        {
            var hostName = serviceEndpoint.Host;
            AmqpSettings amqpSettings = CreateAmpqSettings(AmqpVersion);
            AmqpConnectionSettings connectionSetings = CreateAmqpConnectionSettings(hostName, scopeIdentifier);

            TransportSettings transportSettings = transportType.IsWebSocketTransport()
                ? CreateTransportSettingsForWebSockets(hostName, proxy)
                : CreateTransportSettingsforTcp(hostName, serviceEndpoint.Port);

            // Create and open the connection, respecting the timeout constraint
            // that was received.

            var stopWatch = ValueStopwatch.StartNew();

            var initiator = new AmqpTransportInitiator(amqpSettings, transportSettings);
            TransportBase transport = await initiator.ConnectTaskAsync(timeout).ConfigureAwait(false);

            var connection = new AmqpConnection(transport, amqpSettings, connectionSetings);
            await OpenAmqpObjectAsync(connection, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);

            // Create the CBS link that will be used for authorization.  The act of creating the link will associate
            // it with the connection.

#pragma warning disable CA1806 // Do not ignore method results
            new AmqpCbsLink(connection);
#pragma warning restore CA1806 // Do not ignore method results

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

        /// <summary>
        ///   Creates an AMQP link for use with management operations.
        /// </summary>
        /// <param name="entityPath"></param>
        /// <param name="identifier">The identifier for the sender or receiver that is opening a management link.</param>
        /// <param name="connection">The active and opened AMQP connection to use for this link.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use with management operations.</returns>
        protected virtual async Task<RequestResponseAmqpLink> CreateManagementLinkAsync(
            string entityPath,
            string identifier,
            AmqpConnection connection,
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
                linkSettings.AddProperty(AmqpClientConstants.TimeoutName, (uint)timeout.CalculateRemaining(stopWatch.GetElapsedTime()).TotalMilliseconds);
                linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, AmqpClientConstants.EntityTypeManagement);
                entityPath += '/' + AmqpClientConstants.ManagementAddress;

                // Perform the initial authorization for the link.

                string[] claims = { ServiceBusClaim.Manage, ServiceBusClaim.Listen, ServiceBusClaim.Send };
                var endpoint = new Uri(ServiceEndpoint, entityPath);
                var audience = new[] { endpoint.AbsoluteUri };
                DateTime authExpirationUtc = await RequestAuthorizationUsingCbsAsync(
                    connection: connection,
                    tokenProvider: TokenProvider,
                    endpoint: ServiceEndpoint,
                    audience: audience,
                    requiredClaims: claims,
                    timeout: timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                    identifier: identifier)
                    .ConfigureAwait(false);

                var link = new RequestResponseAmqpLink(
                    AmqpClientConstants.EntityTypeManagement,
                    session,
                    entityPath,
                    linkSettings.Properties);
                linkSettings.LinkName = $"{connection.Settings.ContainerId};{connection.Identifier}:{session.Identifier}:{link.Identifier}";

                // Track the link before returning it, so that it can be managed with the scope.
                var refreshTimer = default(Timer);

                TimerCallback refreshHandler = CreateAuthorizationRefreshHandler
                (
                    entityPath: entityPath,
                    connection: connection,
                    amqpLink: link,
                    tokenProvider: TokenProvider,
                    endpoint: ServiceEndpoint,
                    audience: audience,
                    requiredClaims: claims,
                    refreshTimeout: AuthorizationRefreshTimeout,
                    refreshTimerFactory: () => (ActiveLinks.ContainsKey(link) ? refreshTimer : null),
                    identifier: identifier);

                refreshTimer = new Timer(refreshHandler, null, CalculateLinkAuthorizationRefreshInterval(authExpirationUtc), Timeout.InfiniteTimeSpan);

                // Track the link before returning it, so that it can be managed with the scope.

                BeginTrackingLinkAsActive(entityPath, link, refreshTimer);
                return link;
            }
            catch (Exception exception)
            {
                // Aborting the session will perform any necessary cleanup of
                // the associated link as well.

                session?.Abort();
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(
                    exception,
                    null,
                    session.GetInnerException(),
                    connection.IsClosing()))
                .Throw();

                throw; // will never be reached
            }
        }

        /// <summary>
        ///   Creates an AMQP link for use with receiving operations.
        /// </summary>
        /// <param name="entityPath">The entity path to receive from.</param>
        /// <param name="identifier">The identifier for the receiver that is creating a receive link.</param>
        /// <param name="connection">The active and opened AMQP connection to use for this link.</param>
        /// <param name="endpoint">The fully qualified endpoint to open the link for.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.</param>
        /// <param name="receiveMode">The <see cref="ServiceBusReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="sessionId">The session to receive from.</param>
        /// <param name="isSessionReceiver">Whether or not this is a sessionful receiver.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use for operations related to receiving events.</returns>
        protected virtual async Task<ReceivingAmqpLink> CreateReceivingLinkAsync(
            string entityPath,
            string identifier,
            AmqpConnection connection,
            Uri endpoint,
            TimeSpan timeout,
            uint prefetchCount,
             ServiceBusReceiveMode receiveMode,
            string sessionId,
            bool isSessionReceiver,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var session = default(AmqpSession);
            var stopWatch = ValueStopwatch.StartNew();

            try
            {
                // Perform the initial authorization for the link.

                string[] authClaims = new string[] { ServiceBusClaim.Send };
                var audience = new[] { endpoint.AbsoluteUri };
                DateTime authExpirationUtc = await RequestAuthorizationUsingCbsAsync(
                    connection: connection,
                    tokenProvider: TokenProvider,
                    endpoint: endpoint,
                    audience: audience,
                    requiredClaims: authClaims,
                    timeout: timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                    identifier: identifier).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the AMQP session associated with the link.

                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };

                // This is the maximum number of unsettled transfers across all receive links on this session.
                // This will allow the session to accept unlimited number of transfers, even if the receiver(s)
                // are not settling any of the deliveries.
                sessionSettings.IncomingWindow = uint.MaxValue;

                session = connection.CreateSession(sessionSettings);

                await OpenAmqpObjectAsync(session, timeout).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                var filters = new FilterSet();

                // even if supplied sessionId is null, we need to add the Session filter if it is a session receiver
                if (isSessionReceiver)
                {
                    filters.Add(AmqpClientConstants.SessionFilterName, sessionId);
                }

                var linkSettings = new AmqpLinkSettings
                {
                    Role = true,
                    TotalLinkCredit = prefetchCount,
                    AutoSendFlow = prefetchCount > 0,
                    SettleType = (receiveMode == ServiceBusReceiveMode.PeekLock) ? SettleMode.SettleOnDispose : SettleMode.SettleOnSend,
                    Source = new Source { Address = endpoint.AbsolutePath, FilterSet = filters },
                    Target = new Target { Address = Guid.NewGuid().ToString() }
                };

                var link = new ReceivingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{connection.Settings.ContainerId};{connection.Identifier}:{session.Identifier}:{link.Identifier}:{linkSettings.Source.ToString()}";

                link.AttachTo(session);

                // Configure refresh for authorization of the link.

                var refreshTimer = default(Timer);

                TimerCallback refreshHandler = CreateAuthorizationRefreshHandler
                (
                    entityPath: entityPath,
                    connection: connection,
                    amqpLink: link,
                    tokenProvider: TokenProvider,
                    endpoint: endpoint,
                    audience: audience,
                    requiredClaims: authClaims,
                    refreshTimeout: AuthorizationRefreshTimeout,
                    refreshTimerFactory: () => (ActiveLinks.ContainsKey(link) ? refreshTimer : null),
                    identifier: identifier);

                refreshTimer = new Timer(refreshHandler, null, CalculateLinkAuthorizationRefreshInterval(authExpirationUtc), Timeout.InfiniteTimeSpan);

                // Track the link before returning it, so that it can be managed with the scope.

                BeginTrackingLinkAsActive(entityPath, link, refreshTimer);
                return link;
            }
            catch (Exception exception)
            {
                // Aborting the session will perform any necessary cleanup of
                // the associated link as well.

                session?.Abort();
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(
                    exception,
                    null,
                    session.GetInnerException(),
                    connection.IsClosing()))
                .Throw();

                throw; // will never be reached
            }
        }

        /// <summary>
        ///   Creates an AMQP link for use with publishing operations.
        /// </summary>
        /// <param name="entityPath">The entity path to send to.</param>
        /// <param name="identifier">The identifier of the sender that is creating a send link.</param>
        /// <param name="connection">The active and opened AMQP connection to use for this link.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use for operations related to receiving events.</returns>
        protected virtual async Task<SendingAmqpLink> CreateSendingLinkAsync(
            string entityPath,
            string identifier,
            AmqpConnection connection,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var session = default(AmqpSession);
            var stopWatch = ValueStopwatch.StartNew();

            try
            {
                string[] audience;
                Uri destinationEndpoint = null;

                destinationEndpoint = new Uri(ServiceEndpoint, entityPath);
                audience = new string[] { destinationEndpoint.AbsoluteUri };

                // Perform the initial authorization for the link.

                var authClaims = new[] { ServiceBusClaim.Send };

                DateTime authExpirationUtc = await RequestAuthorizationUsingCbsAsync(
                    connection: connection,
                    tokenProvider: TokenProvider,
                    endpoint: destinationEndpoint,
                    audience: audience,
                    requiredClaims: authClaims,
                    timeout: timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                    identifier: identifier)
                    .ConfigureAwait(false);

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
                    Source = new Source { Address = Guid.NewGuid().ToString() },
                    Target = new Target { Address = destinationEndpoint.AbsolutePath }
                };

                linkSettings.AddProperty(AmqpClientConstants.TimeoutName, (uint)timeout.CalculateRemaining(stopWatch.GetElapsedTime()).TotalMilliseconds);

                var link = new SendingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{ Id };{ connection.Identifier }:{ session.Identifier }:{ link.Identifier }";
                link.AttachTo(session);

                // Configure refresh for authorization of the link.

                var refreshTimer = default(Timer);

                TimerCallback refreshHandler = CreateAuthorizationRefreshHandler
                (
                    entityPath: entityPath,
                    connection: connection,
                    amqpLink: link,
                    tokenProvider: TokenProvider,
                    endpoint: destinationEndpoint,
                    audience: audience,
                    requiredClaims: authClaims,
                    refreshTimeout: AuthorizationRefreshTimeout,
                    refreshTimerFactory: () => refreshTimer,
                    identifier: identifier
                );

                refreshTimer = new Timer(refreshHandler, null, CalculateLinkAuthorizationRefreshInterval(authExpirationUtc), Timeout.InfiniteTimeSpan);

                // Track the link before returning it, so that it can be managed with the scope.

                BeginTrackingLinkAsActive(entityPath, link, refreshTimer);
                return link;
            }
            catch (Exception exception)
            {
                // Aborting the session will perform any necessary cleanup of
                // the associated link as well.

                session?.Abort();
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(
                    exception,
                    null,
                    session.GetInnerException(),
                    connection.IsClosing()))
                .Throw();

                throw; // will never be reached
            }
        }

        /// <summary>
        ///   Performs the actions needed to configure and begin tracking the specified AMQP
        ///   link as an active link bound to this scope.
        /// </summary>
        /// <param name="entityPath">The entity path for the associated link.</param>
        /// <param name="link">The link to begin tracking.</param>
        /// <param name="authorizationRefreshTimer">The timer used to manage refreshing authorization, if the link requires it.</param>
        ///
        /// <remarks>
        ///   This method does operate on the specified <paramref name="link"/> in order to configure it
        ///   for active tracking; no assumptions are made about the open/connected state of the link nor are
        ///   its communication properties modified.
        /// </remarks>
        protected virtual void BeginTrackingLinkAsActive(
            string entityPath,
            AmqpObject link,
            Timer authorizationRefreshTimer = null)
        {
            // Register the link as active and having authorization automatically refreshed, so that it can be
            // managed with the scope.

            if (!ActiveLinks.TryAdd(link, authorizationRefreshTimer))
            {
                throw new ServiceBusException(true, entityPath, Resources.CouldNotCreateLink);
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
        protected virtual void CloseConnection(AmqpConnection connection) => connection.SafeClose();

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
        protected virtual TimeSpan CalculateLinkAuthorizationRefreshInterval(
            DateTime expirationTimeUtc,
            DateTime? currentTimeUtc = null)
        {
            currentTimeUtc ??= DateTime.UtcNow;

            var refreshDueInterval = (expirationTimeUtc.Subtract(AuthorizationRefreshBuffer)).Subtract(currentTimeUtc.Value);
            return (refreshDueInterval < MinimumAuthorizationRefresh) ? MinimumAuthorizationRefresh : refreshDueInterval;
        }

        /// <summary>
        ///   Creates the timer event handler to support refreshing AMQP link authorization
        ///   on a recurring basis.
        /// </summary>
        /// <param name="entityPath">The entity path to refresh authorization with.</param>
        /// <param name="connection">The AMQP connection to which the link being refreshed is bound to.</param>
        /// <param name="amqpLink">The AMQP link to refresh authorization for.</param>
        /// <param name="tokenProvider">The <see cref="CbsTokenProvider" /> to use for obtaining access tokens.</param>
        /// <param name="endpoint">The Service Bus service endpoint that the AMQP link is communicating with.</param>
        /// <param name="audience">The audience associated with the authorization.  This is likely the <paramref name="endpoint"/> absolute URI.</param>
        /// <param name="requiredClaims">The set of claims required to support the operations of the AMQP link.</param>
        /// <param name="refreshTimeout">The timeout to apply when requesting authorization refresh.</param>
        /// <param name="refreshTimerFactory">A function to allow retrieving the <see cref="Timer" /> associated with the link authorization.</param>
        /// <param name="identifier">The identifier of the entity that will be refreshing authorization.</param>
        ///
        /// <returns>A <see cref="TimerCallback"/> delegate to perform the refresh when a timer is due.</returns>
        protected virtual TimerCallback CreateAuthorizationRefreshHandler(
            string entityPath,
            AmqpConnection connection,
            AmqpObject amqpLink,
            CbsTokenProvider tokenProvider,
            Uri endpoint,
            string[] audience,
            string[] requiredClaims,
            TimeSpan refreshTimeout,
            Func<Timer> refreshTimerFactory,
            string identifier)
        {
            return async _ =>
            {
                ServiceBusEventSource.Log.AmqpLinkAuthorizationRefreshStart(entityPath, endpoint.AbsoluteUri);
                Timer refreshTimer = refreshTimerFactory();

                try
                {
                    if (refreshTimer == null)
                    {
                        return;
                    }

                    DateTime authExpirationUtc = await RequestAuthorizationUsingCbsAsync(
                        connection: connection,
                        tokenProvider: tokenProvider,
                        endpoint: endpoint,
                        audience: audience,
                        requiredClaims: requiredClaims,
                        timeout: refreshTimeout,
                        identifier: identifier)
                    .ConfigureAwait(false);

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
                    ServiceBusEventSource.Log.AmqpLinkAuthorizationRefreshError(entityPath, endpoint.AbsoluteUri, ex.Message);

                    // Attempt to unset the timer; there's a decent chance that it has been disposed at this point or
                    // that the connection has been closed.  Ignore potential exceptions, as they won't impact operation.
                    // At worse, another timer tick will occur and the operation will be retried.

                    try
                    { refreshTimer.Change(Timeout.Infinite, Timeout.Infinite); }
                    catch { }
                }
                finally
                {
                    ServiceBusEventSource.Log.AmqpLinkAuthorizationRefreshComplete(entityPath, endpoint.AbsoluteUri);
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
        protected virtual async Task OpenAmqpObjectAsync(
            AmqpObject target,
            TimeSpan timeout)
        {
            try
            {
                await target.OpenAsync(timeout).ConfigureAwait(false);
            }
            catch
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
                throw;
            }
        }

        /// <summary>
        ///   Requests authorization for a connection or link using a connection via the CBS mechanism.
        /// </summary>
        ///
        /// <param name="connection">The AMQP connection for which the authorization is associated.</param>
        /// <param name="tokenProvider">The <see cref="CbsTokenProvider" /> to use for obtaining access tokens.</param>
        /// <param name="endpoint">The Service Bus service endpoint that the authorization is requested for.</param>
        /// <param name="audience">The audience associated with the authorization.  This is likely the <paramref name="endpoint"/> absolute URI.</param>
        /// <param name="requiredClaims">The set of claims required to support the operations of the AMQP link.</param>
        /// <param name="timeout">The timeout to apply when requesting authorization.</param>
        /// <param name="identifier">The identifier of the entity requesting authorization.</param>
        ///
        /// <returns>The date/time, in UTC, when the authorization expires.</returns>
        ///
        /// <remarks>
        ///   It is assumed that there is a valid <see cref="AmqpCbsLink" /> already associated
        ///   with the connection; this will be used as the transport for the authorization
        ///   credentials.
        /// </remarks>
        protected virtual async Task<DateTime> RequestAuthorizationUsingCbsAsync(
            AmqpConnection connection,
            CbsTokenProvider tokenProvider,
            Uri endpoint,
            string[] audience,
            string[] requiredClaims,
            TimeSpan timeout,
            string identifier)
        {
            string uri = endpoint.AbsoluteUri;
            ServiceBusEventSource.Log.RequestAuthorizationStart(identifier, uri);
            AmqpCbsLink authLink = connection.Extensions.Find<AmqpCbsLink>();
            DateTime cbsTokenExpiresAtUtc = DateTime.MaxValue;

            try
            {
                foreach (string resource in audience)
                {
                    DateTime expiresAt =
                        await authLink.SendTokenAsync(TokenProvider, endpoint, resource, resource, requiredClaims, timeout).ConfigureAwait(false);
                    if (expiresAt < cbsTokenExpiresAtUtc)
                    {
                        cbsTokenExpiresAtUtc = expiresAt;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.RequestAuthorizationException(identifier, uri, ex.ToString());
                throw;
            }

            ServiceBusEventSource.Log.RequestAuthorizationComplete(identifier, uri, cbsTokenExpiresAtUtc.ToString(CultureInfo.InvariantCulture));
            return cbsTokenExpiresAtUtc;
        }

        /// <summary>
        ///   Creates the settings to use for AMQP communication.
        /// </summary>
        ///
        /// <param name="amqpVersion">The version of AMQP to be used.</param>
        ///
        /// <returns>The settings for AMQP to use for communication with the Service Bus service.</returns>
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
        /// <param name="hostName">The host name of the Service Bus service endpoint.</param>
        /// <param name="port">The port to use for connecting to the endpoint.</param>
        ///
        /// <returns>The settings to use for transport.</returns>
        private static TransportSettings CreateTransportSettingsforTcp(
            string hostName,
            int port)
        {
            var tcpSettings = new TcpTransportSettings
            {
                Host = hostName,
                Port = port < 0 ? AmqpConstants.DefaultSecurePort : port,
                ReceiveBufferSize = AmqpConstants.TransportBufferSize,
                SendBufferSize = AmqpConstants.TransportBufferSize
            };

            return new TlsTransportSettings(tcpSettings)
            {
                TargetHost = hostName,
            };
        }

        /// <summary>
        ///  Creates the transport settings for use with web sockets.
        /// </summary>
        ///
        /// <param name="hostName">The host name of the Service Bus service endpoint.</param>
        /// <param name="proxy">The proxy to use for connecting to the endpoint.</param>
        ///
        /// <returns>The settings to use for transport.</returns>
        private static TransportSettings CreateTransportSettingsForWebSockets(
            string hostName,
            IWebProxy proxy)
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
                Proxy = proxy ?? (default)
            };
        }

        /// <summary>
        ///   Creates the AMQP connection settings to use when communicating with the Service Bus service.
        /// </summary>
        ///
        /// <param name="hostName">The host name of the Service Bus service endpoint.</param>
        /// <param name="identifier">unique identifier of the current Service Bus scope.</param>
        ///
        /// <returns>The settings to apply to the connection.</returns>
        private static AmqpConnectionSettings CreateAmqpConnectionSettings(
            string hostName,
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
        private static void ValidateTransport(ServiceBusTransportType transport)
        {
            if ((transport != ServiceBusTransportType.AmqpTcp) && (transport != ServiceBusTransportType.AmqpWebSockets))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.UnknownConnectionType, transport), nameof(transport));
            }
        }
    }
}
