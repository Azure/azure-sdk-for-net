// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Security;
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
        private const string WebSocketsSecureUriScheme = "wss";

        /// <summary>The URI scheme to apply when using web sockets for service communication.</summary>
        private const string WebSocketsInsecureUriScheme = "ws";

        /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
        private static int s_randomSeed = Environment.TickCount;

        /// <summary>The random number generator to use for a specific thread.</summary>
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

        /// <summary>The required claims to execute management operations.</summary>
        private static readonly string[] s_manageClaims = [ServiceBusClaim.Manage, ServiceBusClaim.Listen, ServiceBusClaim.Send];

        /// <summary>Indicates whether or not this instance has been disposed.</summary>
        private volatile bool _disposed;

        /// <summary>
        ///   The version of AMQP to use within the scope.
        /// </summary>
        private static Version AmqpVersion { get; } = new Version(1, 0, 0, 0);

        /// <summary>
        ///   The amount of buffer to apply to account for clock skew when
        ///   refreshing authorization.  Authorization will be refreshed earlier
        ///   than the expected expiration by this amount.
        /// </summary>
        private static TimeSpan AuthorizationRefreshBuffer { get; } = TimeSpan.FromMinutes(7);

        /// <summary>
        ///   The amount of seconds to use as the basis for calculating a random jitter amount
        ///   when refreshing token authorization.  This is intended to ensure that multiple
        ///   resources using the authorization do not all attempt to refresh at the same moment.
        /// </summary>
        private static int AuthorizationBaseJitterSeconds { get; } = 30;

        /// <summary>
        ///   The number of milliseconds to use as the basis for calculating a random jitter amount
        ///   when opening receiver links. This is intended to ensure that multiple
        ///   accept session operations don't timeout at the same exact moment.
        /// </summary>
        private static int OpenReceiveLinkBaseJitterMilliseconds { get; } = 100;

        /// <summary>
        /// The amount of time to subtract from the client timeout when setting the server timeout when attempting to
        /// accept the next available session. This will decrease the likelihood that the client times out before receiving a
        /// response from the server.
        /// </summary>
        private static TimeSpan OpenReceiveLinkBuffer { get; } = TimeSpan.FromMilliseconds(20);

        /// <summary>
        /// The amount minimum threshold for the server timeout for which we will subtract the <see cref="OpenReceiveLinkBuffer"/>.
        /// If the server timeout is less than this, we will not subtract the additional buffer.
        /// </summary>
        private static TimeSpan OpenReceiveLinkBufferThreshold { get; } = TimeSpan.FromSeconds(1);

        /// <summary>
        ///   The minimum amount of time for authorization to be refreshed; any calculations that
        ///   call for refreshing more frequently will be substituted with this value.
        /// </summary>
        private static TimeSpan MinimumAuthorizationRefresh { get; } = TimeSpan.FromMinutes(3);

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
        private static TimeSpan AuthorizationRefreshTimeout { get; } = TimeSpan.FromMinutes(3);

        /// <summary>
        ///   The amount of buffer to apply when considering an authorization token
        ///   to be expired.  The token's actual expiration will be decreased by this
        ///   amount, ensuring that it is renewed before it has expired.
        /// </summary>
        ///
        private static TimeSpan AuthorizationTokenExpirationBuffer { get; } = AuthorizationRefreshBuffer.Add(TimeSpan.FromMinutes(2));

        /// <summary>
        ///   Indicates whether this <see cref="AmqpConnectionScope"/> has been disposed.
        /// </summary>
        ///
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        ///
        public override bool IsDisposed
        {
            get => _disposed;
            protected set => _disposed = value;
        }

        /// <summary>
        ///   The cancellation token to use with operations initiated by the scope.
        /// </summary>
        private CancellationTokenSource OperationCancellationSource { get; } = new();

        /// <summary>
        ///   The set of active AMQP links associated with the connection scope.  These are considered children
        ///   of the active connection and should be managed as such.
        /// </summary>
        private ConcurrentDictionary<AmqpObject, Timer> ActiveLinks { get; } = new();

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
        ///   A <see cref="RemoteCertificateValidationCallback" /> delegate allowing custom logic to be considered for
        ///   validation of the remote certificate responsible for encrypting communication.
        /// </summary>
        ///
        private RemoteCertificateValidationCallback CertificateValidationCallback { get; }

        /// <summary>
        ///   The AMQP connection that is active for the current scope.
        /// </summary>
        private FaultTolerantAmqpObject<AmqpConnection> ActiveConnection { get; }

        /// <summary>
        ///  The controller responsible for managing transactions.
        /// </summary>
        internal FaultTolerantAmqpObject<Controller> TransactionController { get; }

        private readonly bool _useSingleSession;

        private readonly FaultTolerantAmqpObject<AmqpSession> _singletonSession;

        private string _sendViaReceiverEntityPath;

        private readonly object _syncLock = new();
        private readonly TimeSpan _operationTimeout;
        private readonly uint _connectionIdleTimeoutMilliseconds;

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpConnectionScope"/> class.
        /// </summary>
        /// <param name="serviceEndpoint">Endpoint for the Service Bus service to which the scope is associated.</param>
        /// <param name="connectionEndpoint">The endpoint to use for the initial connection to the Service Bus service.</param>
        /// <param name="credential">The credential to use for authorization with the Service Bus service.</param>
        /// <param name="transport">The transport to use for communication.</param>
        /// <param name="proxy">The proxy, if any, to use for communication.</param>
        /// <param name="useSingleSession">If true, all links will use a single session.</param>
        /// <param name="operationTimeout">The timeout for operations associated with the connection.</param>
        /// <param name="idleTimeout">The amount of time to allow a connection to have no observed traffic before considering it idle.</param>
        /// <param name="certificateValidationCallback">The validation callback to register for participation in the SSL handshake.</param>
        public AmqpConnectionScope(
            Uri serviceEndpoint,
            Uri connectionEndpoint,
            ServiceBusTokenCredential credential,
            ServiceBusTransportType transport,
            IWebProxy proxy,
            bool useSingleSession,
            TimeSpan operationTimeout,
            TimeSpan idleTimeout,
            RemoteCertificateValidationCallback certificateValidationCallback = default)
        {
            Argument.AssertNotNull(serviceEndpoint, nameof(serviceEndpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNegative(idleTimeout, nameof(idleTimeout));
            ValidateTransport(transport);

            _operationTimeout = operationTimeout;
            _connectionIdleTimeoutMilliseconds = (uint)idleTimeout.TotalMilliseconds;
            ServiceEndpoint = serviceEndpoint;
            Transport = transport;
            Proxy = proxy;
            CertificateValidationCallback = certificateValidationCallback;
            Id = $"{ServiceEndpoint}-{Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture).Substring(0, 8)}";
            TokenProvider = new CbsTokenProvider(new ServiceBusTokenCredential(credential), AuthorizationTokenExpirationBuffer, OperationCancellationSource.Token);
            _useSingleSession = useSingleSession;
#pragma warning disable CA2214 // Do not call overridable methods in constructors. This internal method is virtual for testing purposes.
            Task<AmqpConnection> connectionFactory(TimeSpan timeout) => CreateAndOpenConnectionAsync(AmqpVersion, ServiceEndpoint, connectionEndpoint, Transport, Proxy, CertificateValidationCallback, Id, timeout);
#pragma warning restore CA2214 // Do not call overridable methods in constructors

            ActiveConnection = new FaultTolerantAmqpObject<AmqpConnection>(
                connectionFactory,
                CloseConnection);

            _singletonSession = new FaultTolerantAmqpObject<AmqpSession>(
               async (timeout) =>
               {
                   var stopWatch = ValueStopwatch.StartNew();
                   AmqpConnection connection = await ActiveConnection.GetOrCreateAsync(timeout).ConfigureAwait(false);
                   AmqpSession session = await CreateAndOpenSessionAsync(
                       connection,
                       timeout.CalculateRemaining(stopWatch.GetElapsedTime()))
                   .ConfigureAwait(false);
                   // When using cross entity transactions, the controller needs to be opened before the link is established
                   // in order to let the service know that there will be cross entity transactions on this session. We can't
                   // wait until a transaction is declared to open the controller.
                   _ = await CreateControllerAsync(session, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                   return session;
               },
               session => session.Close());

            TransactionController = new FaultTolerantAmqpObject<Controller>(
                async (timeout) =>
                {
                    var stopWatch = ValueStopwatch.StartNew();
                    AmqpConnection connection = await ActiveConnection.GetOrCreateAsync(timeout).ConfigureAwait(false);
                    AmqpSession session = await CreateSessionIfNeededAsync(connection, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                    return await CreateControllerAsync(session, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                },
                controller => controller.Close());
        }

        private async Task<Controller> CreateControllerAsync(AmqpSession amqpSession, TimeSpan timeout)
        {
            var stopWatch = ValueStopwatch.StartNew();
            Controller controller;

            try
            {
                controller = new Controller(amqpSession, timeout);
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
                Argument.AssertNotDisposed(_disposed, nameof(AmqpConnectionScope));

                var stopWatch = ValueStopwatch.StartNew();
                var connection = await ActiveConnection.GetOrCreateAsync(timeout, cancellationToken).ConfigureAwait(false);

                var link = await CreateManagementLinkAsync(
                    entityPath,
                    identifier,
                    connection,
                    timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                    cancellationToken).ConfigureAwait(false);

                await OpenAmqpLinkAsync(link, entityPath, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <returns>A link for use with consumer operations.</returns>
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
            Argument.AssertNotDisposed(_disposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var stopWatch = ValueStopwatch.StartNew();
            var receiverEndpoint = new Uri(ServiceEndpoint, entityPath);

            var connection = await ActiveConnection.GetOrCreateAsync(timeout, cancellationToken).ConfigureAwait(false);

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

            await OpenAmqpLinkAsync(link, entityPath, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <returns>A link for use with sender operations.</returns>
        ///
        public virtual async Task<SendingAmqpLink> OpenSenderLinkAsync(
            string entityPath,
            string identifier,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(_disposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            var stopWatch = ValueStopwatch.StartNew();

            AmqpConnection connection = await ActiveConnection.GetOrCreateAsync(timeout, cancellationToken).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            SendingAmqpLink link = await CreateSendingLinkAsync(
                entityPath: entityPath,
                identifier: identifier,
                connection: connection,
                timeout: timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                cancellationToken: cancellationToken).ConfigureAwait(false);

            await OpenAmqpLinkAsync(link, entityPath, cancellationToken).ConfigureAwait(false);

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

            _singletonSession?.Dispose();
            TransactionController?.Dispose();
            TokenProvider.Dispose();

            IsDisposed = true;
        }

        /// <summary>
        ///   Creates an AMQP connection for a given scope.
        /// </summary>
        ///
        /// <param name="amqpVersion">The version of AMQP to use for the connection.</param>
        /// <param name="serviceEndpoint">The endpoint for the Service Bus service to which the scope is associated.</param>
        /// <param name="connectionEndpoint">The endpoint to use for the initial connection to the Service Bus service.</param>
        /// <param name="transportType">The type of transport to use for communication.</param>
        /// <param name="proxy">The proxy, if any, to use for communication.</param>
        /// <param name="certificateValidationCallback">The validation callback to register for participation in the SSL handshake.</param>
        /// <param name="scopeIdentifier">The unique identifier for the associated scope.</param>
        /// <param name="timeout">The timeout to consider when creating the connection.</param>
        /// <returns>An AMQP connection that may be used for communicating with the Service Bus service.</returns>
        protected virtual async Task<AmqpConnection> CreateAndOpenConnectionAsync(
            Version amqpVersion,
            Uri serviceEndpoint,
            Uri connectionEndpoint,
            ServiceBusTransportType transportType,
            IWebProxy proxy,
            RemoteCertificateValidationCallback certificateValidationCallback,
            string scopeIdentifier,
            TimeSpan timeout)
        {
            var serviceHostName = serviceEndpoint.Host;
            AmqpSettings amqpSettings = CreateAmpqSettings(AmqpVersion);
            AmqpConnectionSettings connectionSetings = CreateAmqpConnectionSettings(serviceHostName, scopeIdentifier, _connectionIdleTimeoutMilliseconds);

            TransportSettings transportSettings = transportType.IsWebSocketTransport()
                ? CreateTransportSettingsForWebSockets(connectionEndpoint, proxy)
                : CreateTransportSettingsforTcp(connectionEndpoint, certificateValidationCallback);

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
            var refreshTimer = default(Timer);
            var stopWatch = ValueStopwatch.StartNew();
            RequestResponseAmqpLink link = null;

            try
            {
                // Create and open the AMQP session associated with the link.

                session = await CreateSessionIfNeededAsync(connection, timeout).ConfigureAwait(false);

                // Create and open the link.

                var linkSettings = new AmqpLinkSettings();
                linkSettings.AddProperty(AmqpClientConstants.TimeoutName, (uint)timeout.CalculateRemaining(stopWatch.GetElapsedTime()).TotalMilliseconds);
                linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, AmqpClientConstants.EntityTypeManagement);
                linkSettings.OperationTimeout = _operationTimeout;
                entityPath += '/' + AmqpClientConstants.ManagementAddress;

                // Perform the initial authorization for the link.

                var endpoint = new Uri(ServiceEndpoint, entityPath);
                var audience = new[] { endpoint.AbsoluteUri };
                DateTime authExpirationUtc = await RequestAuthorizationUsingCbsAsync(
                    connection: connection,
                    tokenProvider: TokenProvider,
                    endpoint: ServiceEndpoint,
                    audience: audience,
                    requiredClaims: s_manageClaims,
                    timeout: timeout.CalculateRemaining(stopWatch.GetElapsedTime()),
                    identifier: identifier)
                    .ConfigureAwait(false);

                link = new RequestResponseAmqpLink(
                    AmqpClientConstants.EntityTypeManagement,
                    session,
                    entityPath,
                    linkSettings.Properties);
                linkSettings.LinkName = $"{connection.Settings.ContainerId};{connection.Identifier}:{session.Identifier}:{link.Identifier}";

                // Track the link before returning it, so that it can be managed with the scope.

                TimerCallback refreshHandler = CreateAuthorizationRefreshHandler
                (
                    entityPath: entityPath,
                    connection: connection,
                    amqpLink: link,
                    tokenProvider: TokenProvider,
                    endpoint: ServiceEndpoint,
                    audience: audience,
                    requiredClaims: s_manageClaims,
                    refreshTimeout: AuthorizationRefreshTimeout,
                    refreshTimerFactory: () => (ActiveLinks.ContainsKey(link) ? refreshTimer : null),
                    identifier: identifier);

                refreshTimer = new Timer(refreshHandler, null, CalculateLinkAuthorizationRefreshInterval(authExpirationUtc), Timeout.InfiniteTimeSpan);

                // Track the link before returning it, so that it can be managed with the scope.

                StartTrackingLinkAsActive(entityPath, link, refreshTimer);
                return link;
            }
            catch (Exception exception)
            {
                StopTrackingLinkAsActive(link, refreshTimer);

                // Closing the session will perform any necessary cleanup of
                // the associated link as well.

                session?.SafeClose();
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
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.</param>
        /// <param name="receiveMode">The <see cref="ServiceBusReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.</param>
        /// <param name="sessionId">The session to receive from.</param>
        /// <param name="isSessionReceiver">Whether or not this is a sessionful receiver.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
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
            var refreshTimer = default(Timer);
            var stopWatch = ValueStopwatch.StartNew();
            ReceivingAmqpLink link = null;

            try
            {
                // Perform the initial authorization for the link.

                string[] authClaims = [ServiceBusClaim.Send];
                var audience = new[] { endpoint.AbsoluteUri };
                DateTime authExpirationUtc = await RequestAuthorizationUsingCbsAsync(
                    connection: connection,
                    tokenProvider: TokenProvider,
                    endpoint: endpoint,
                    audience: audience,
                    requiredClaims: authClaims,
                    timeout: timeout,
                    identifier: identifier).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the AMQP session associated with the link.

                session = await CreateSessionIfNeededAsync(connection, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);

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
                    Target = new Target { Address = identifier },
                    OperationTimeout = _operationTimeout
                };

                if (isSessionReceiver && sessionId == null)
                {
                    // Subtract a random amount up to 100ms from the operation timeout as the jitter when attempting to open next available session link.
                    // This prevents excessive resource usage when using high amounts of concurrency and accepting the next available session. Without the jitter,
                    // we can get many timeout exceptions occurring at the exact same time which leads to high CPU usage and thread starvation,
                    // particularly when using the session processor.
                    // Take the min of 1% of the total timeout and the BaseJitter amount so that we don't end up subtracting more than 1% of the total timeout.
                    var jitterBase = Math.Min(_operationTimeout.TotalMilliseconds / 100, OpenReceiveLinkBaseJitterMilliseconds);

                    // We set the operation timeout on the properties not only to include the jitter, but also because the server will otherwise
                    // restrict the maximum timeout to 1 minute and 5 seconds, regardless of the client timeout. We only do this for accepting next available
                    // session as this is the only long-polling scenario.
                    var serverTimeout = _operationTimeout.Subtract(TimeSpan.FromMilliseconds(jitterBase * RandomNumberGenerator.Value.NextDouble()));

                    // Subtract an additional constant buffer to reduce the likelihood that the client times out before the service which leads to unnecessary
                    // network traffic. If the timeout is too short, we won't do this.
                    if (serverTimeout >= OpenReceiveLinkBufferThreshold)
                    {
                        serverTimeout = serverTimeout.Subtract(OpenReceiveLinkBuffer);
                    }

                    linkSettings.Properties = new Fields
                    {
                        {
                            AmqpClientConstants.TimeoutName,
                            (uint)serverTimeout.TotalMilliseconds
                        }
                    };
                }

                link = new ReceivingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{connection.Settings.ContainerId};{connection.Identifier}:{session.Identifier}:{link.Identifier}:{linkSettings.Source.ToString()}";

                link.AttachTo(session);

                // Configure refresh for authorization of the link.

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

                StartTrackingLinkAsActive(entityPath, link, refreshTimer);
                return link;
            }
            catch (Exception exception)
            {
                StopTrackingLinkAsActive(link, refreshTimer);
                // Closing the session will perform any necessary cleanup of
                // the associated link as well.
                session?.SafeClose();
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(
                    exception,
                    null,
                    session.GetInnerException(),
                    connection.IsClosing()))
                .Throw();

                throw; // will never be reached
            }
        }

        private async Task<AmqpSession> CreateSessionIfNeededAsync(AmqpConnection connection, TimeSpan timeout)
        {
            if (_useSingleSession)
            {
                return await _singletonSession.GetOrCreateAsync(timeout).ConfigureAwait(false);
            }

            return await CreateAndOpenSessionAsync(connection, timeout).ConfigureAwait(false);
        }

        private async Task<AmqpSession> CreateAndOpenSessionAsync(AmqpConnection connection, TimeSpan timeout)
        {
            AmqpSession session;
            var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };

            // This is the maximum number of unsettled transfers across all receive links on this session.
            // This will allow the session to accept unlimited number of transfers, even if the receiver(s)
            // are not settling any of the deliveries.
            sessionSettings.IncomingWindow = uint.MaxValue;

            session = connection.CreateSession(sessionSettings);

            await OpenAmqpObjectAsync(session, timeout).ConfigureAwait(false);
            return session;
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
            var refreshTimer = default(Timer);
            var stopWatch = ValueStopwatch.StartNew();
            SendingAmqpLink link = null;

            ValidateCanCreateSenderLink(entityPath);

            try
            {
                string[] audience;
                Uri destinationEndpoint = null;

                destinationEndpoint = new Uri(ServiceEndpoint, entityPath);
                audience = [destinationEndpoint.AbsoluteUri];

                // Perform the initial authorization for the link.

                var authClaims = new[] { ServiceBusClaim.Send };

                DateTime authExpirationUtc = await RequestAuthorizationUsingCbsAsync(
                    connection: connection,
                    tokenProvider: TokenProvider,
                    endpoint: destinationEndpoint,
                    audience: audience,
                    requiredClaims: authClaims,
                    timeout: timeout,
                    identifier: identifier)
                    .ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the AMQP session associated with the link.

                session = await CreateSessionIfNeededAsync(connection, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the link.

                var linkSettings = new AmqpLinkSettings
                {
                    Role = false,
                    InitialDeliveryCount = 0,
                    Source = new Source { Address = identifier },
                    Target = new Target { Address = destinationEndpoint.AbsolutePath },
                    OperationTimeout = _operationTimeout,
                };

                linkSettings.AddProperty(AmqpClientConstants.TimeoutName, (uint)timeout.CalculateRemaining(stopWatch.GetElapsedTime()).TotalMilliseconds);

                link = new SendingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{Id};{connection.Identifier}:{session.Identifier}:{link.Identifier}";
                link.AttachTo(session);

                // Configure refresh for authorization of the link.

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

                StartTrackingLinkAsActive(entityPath, link, refreshTimer);
                return link;
            }
            catch (Exception exception)
            {
                StopTrackingLinkAsActive(link, refreshTimer);

                // Closing the session will perform any necessary cleanup of
                // the associated link as well.

                session?.SafeClose();
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(
                    exception,
                    null,
                    session.GetInnerException(),
                    connection.IsClosing()))
                .Throw();

                throw; // will never be reached
            }
        }

        private void ValidateCanCreateSenderLink(string entityPath)
        {
            if (_useSingleSession)
            {
                lock (_syncLock)
                {
                    // The send-via entity is a receiver and there are no active links. We are reconnecting the connection.
                    if (_sendViaReceiverEntityPath != null && ActiveLinks.IsEmpty)
                    {
                        // The sender is not going to the send-via entity path, so we need to ensure the receiver is reconnected first.
                        if (entityPath != _sendViaReceiverEntityPath)
                        {
                            // User code will already need to handle InvalidOperationExceptions for transactions where the connection drops.
                            // There is no point in attempting to reconnect the receiver here on the user's behalf, as the transaction will
                            // still fail since the connection dropped.
                            throw new InvalidOperationException(
                                string.Format(
                                    CultureInfo.InvariantCulture,
                                    Resources.TransactionReconnectionError,
                                    entityPath,
                                    _sendViaReceiverEntityPath));
                        }
                    }
                }
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
        protected virtual void StartTrackingLinkAsActive(
            string entityPath,
            AmqpObject link,
            Timer authorizationRefreshTimer = null)
        {
            if (_useSingleSession)
            {
                lock (_syncLock)
                {
                    if (link is ReceivingAmqpLink)
                    {
                        // Track the send-via receiver in order to handle reconnecting in the proper order (sender first).
                        _sendViaReceiverEntityPath ??= entityPath;
                    }
                }
            }

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
                StopTrackingLinkAsActive(link);

                link.Closed -= closeHandler;
            };

            link.Closed += closeHandler;
        }

        private void StopTrackingLinkAsActive(AmqpObject link, Timer authorizationRefreshTimer = null)
        {
            var activeTimer = default(Timer);

            if (link != null)
            {
                ActiveLinks.TryRemove(link, out activeTimer);

                if (activeTimer != null)
                {
                    try
                    {
                        activeTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
                        activeTimer.Dispose();
                    }
                    catch (ObjectDisposedException)
                    {
                    }
                }
            }

            // If the refresh timer was created but not associated with the link, then it will need
            // to be cleaned up.

            if ((authorizationRefreshTimer != null) && (!ReferenceEquals(authorizationRefreshTimer, activeTimer)))
            {
                try
                {
                    authorizationRefreshTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
                    authorizationRefreshTimer.Dispose();
                }
                catch (ObjectDisposedException)
                {
                }
            }
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

            // Calculate the interval for when refreshing authorization should take place;
            // the refresh is based on the time that the credential expires, less a buffer to
            // allow for clock skew.  A random number of seconds is added as jitter, to prevent
            // multiple resources using the same token from all requesting a refresh at the same moment.

            var refreshDueInterval = expirationTimeUtc
                .Subtract(AuthorizationRefreshBuffer)
                .Subtract(currentTimeUtc.Value)
                .Subtract(TimeSpan.FromSeconds(RandomNumberGenerator.Value.NextDouble() * AuthorizationBaseJitterSeconds));

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
        ///   Performs the actions needed to open an AMQP link.
        /// </summary>
        /// <param name="link">The target AMQP object to open.</param>
        /// <param name="entityPath">The path of the entity associated with the AMQP object being opened, if any.</param>
        /// <param name="cancellationToken">Token to signal cancellation of the operation.</param>
        protected virtual async Task OpenAmqpLinkAsync(
            AmqpLink link,
            string entityPath,
            CancellationToken cancellationToken)
        {
            await OpenAmqpObjectCoreAsync(link, entityPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///  Performs the actions needed to open a request response link. This overload is necessary because <see cref="RequestResponseAmqpLink"/>
        ///  does not inherit from <see cref="AmqpLink"/>.
        /// </summary>
        /// <param name="link">The target AMQP object to open.</param>
        /// <param name="entityPath">The path of the entity associated with the AMQP object being opened, if any.</param>
        /// <param name="cancellationToken">Token to signal cancellation of the operation.</param>
        protected virtual async Task OpenAmqpLinkAsync(
            RequestResponseAmqpLink link,
            string entityPath,
            CancellationToken cancellationToken)
        {
            await OpenAmqpObjectCoreAsync(link, entityPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///  Performs the actions needed to open an AmqpObject.
        /// </summary>
        /// <param name="targetObject">The target AMQP object to open.</param>
        /// <param name="timeout">The timeout to apply when opening the object.</param>
        protected virtual async Task OpenAmqpObjectAsync(
            AmqpObject targetObject,
            TimeSpan timeout)
        {
            await OpenAmqpObjectCoreAsync(targetObject, timeout: timeout).ConfigureAwait(false);
        }

        private async Task OpenAmqpObjectCoreAsync(
            AmqpObject target,
            string entityPath = default,
            TimeSpan? timeout = default,
            CancellationToken? cancellationToken = default)
        {
            // only one of timeout or cancellation token should be set
            Debug.Assert(timeout.HasValue ^ cancellationToken.HasValue);
            try
            {
                if (cancellationToken.HasValue)
                {
                    await target.OpenAsync(cancellationToken.Value).ConfigureAwait(false);
                }
                else
                {
                    await target.OpenAsync(timeout.Value).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                switch (target)
                {
                    case AmqpLink linkTarget:
                        CloseLink(linkTarget);
                        break;
                    case RequestResponseAmqpLink linkTarget:
                        CloseLink(linkTarget);
                        break;
                }

                // The AMQP library may throw an InvalidOperationException or one of its derived types, such as
                // ObjectDisposedException if the underlying network state changes.  While normally terminal, in this
                // context, these exception types are safe to retry.  Translate them so that the retry policy
                // can correctly interpret.

                switch (ex)
                {
                    case InvalidOperationException:
                        throw new ServiceBusException(true, Resources.CouldNotCreateLink, entityPath,
                            ServiceBusFailureReason.ServiceCommunicationProblem, ex);

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
        /// <param name="connectionEndpoint">The Event Hubs service endpoint to connect to.</param>
        /// <param name="certificateValidationCallback">The validation callback to register for participation in the SSL handshake.</param>
        ///
        /// <returns>The settings to use for transport.</returns>
        private static TransportSettings CreateTransportSettingsforTcp(Uri connectionEndpoint, RemoteCertificateValidationCallback certificateValidationCallback)
        {
            var useTls = ShouldUseTls(connectionEndpoint.Scheme);
            var port = connectionEndpoint.Port < 0 ? (useTls ? AmqpConstants.DefaultSecurePort : AmqpConstants.DefaultPort) : connectionEndpoint.Port;

            // Allow the host to control the size of the transport buffers for sending and
            // receiving by setting the value to -1.  This results in much improved throughput
            // across platforms, as different Linux distros have different needs to
            // maximize efficiency, with Window having its own needs as well.
            var tcpSettings = new TcpTransportSettings
            {
                Host = connectionEndpoint.Host,
                Port = port,
                ReceiveBufferSize = -1,
                SendBufferSize = -1
            };

            // If TLS is explicitly disabled, then use the TCP settings as-is.  Otherwise,
            // wrap them for TLS usage.

            return useTls switch
            {
                false => tcpSettings,

                _ => new TlsTransportSettings(tcpSettings)
                {
                    TargetHost = connectionEndpoint.Host,
                    CertificateValidationCallback = certificateValidationCallback
                }
            };
        }

        /// <summary>
        ///  Creates the transport settings for use with web sockets.
        /// </summary>
        ///
        /// <param name="connectionEndpoint">The Event Hubs service endpoint to connect to.</param>
        /// <param name="proxy">The proxy to use for connecting to the endpoint.</param>
        ///
        /// <returns>The settings to use for transport.</returns>
        private static TransportSettings CreateTransportSettingsForWebSockets(
            Uri connectionEndpoint,
            IWebProxy proxy)
        {
            var useTls = ShouldUseTls(connectionEndpoint.Scheme);

            var uriBuilder = new UriBuilder(connectionEndpoint.Host)
            {
                Path = WebSocketsPathSuffix,
                Scheme = useTls ? WebSocketsSecureUriScheme : WebSocketsInsecureUriScheme,
                Port = connectionEndpoint.Port < 0 ? -1 : connectionEndpoint.Port
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
        /// <param name="idleTimeoutMilliseconds">The amount of time, in milliseconds, to allow a connection to have no observed traffic before considering it idle.</param>
        ///
        /// <returns>The settings to apply to the connection.</returns>
        private static AmqpConnectionSettings CreateAmqpConnectionSettings(
            string hostName,
            string identifier,
            uint idleTimeoutMilliseconds)
        {
            var connectionSettings = new AmqpConnectionSettings
            {
                IdleTimeOut = idleTimeoutMilliseconds,
                MaxFrameSize = AmqpConstants.DefaultMaxFrameSize,
                ContainerId = identifier,
                HostName = hostName
            };

            foreach (KeyValuePair<string, string> property in ClientLibraryInformation.Current.SerializedProperties)
            {
                connectionSettings.AddProperty(property.Key, property.Value);
            }

            return connectionSettings;
        }

        /// <summary>
        ///   Determines if the specified URL scheme should use TLS when creating an AMQP connection.
        /// </summary>
        ///
        /// <param name="urlScheme">The URL scheme to consider.</param>
        ///
        /// <returns><c>true</c> if the connection should use TLS; otherwise, <c>false</c>.</returns>
        ///
        private static bool ShouldUseTls(string urlScheme) => urlScheme switch
        {
            "ws" => false,
            "amqp" => false,
            "http" => false,
            _ => true
        };

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

        internal void CloseLink(AmqpLink link, string identifier = default)
        {
            ServiceBusEventSource.Log.CloseLinkStart(identifier);
            if (!_useSingleSession)
            {
                link.Session?.SafeClose();
            }
            link.SafeClose();
            ServiceBusEventSource.Log.CloseLinkComplete(identifier);
        }

        internal void CloseLink(RequestResponseAmqpLink link, string identifier = default)
        {
            ServiceBusEventSource.Log.CloseLinkStart(identifier);
            if (!_useSingleSession)
            {
                link.Session?.SafeClose();
            }
            link.SafeClose();
            ServiceBusEventSource.Log.CloseLinkComplete(identifier);
        }
    }
}
