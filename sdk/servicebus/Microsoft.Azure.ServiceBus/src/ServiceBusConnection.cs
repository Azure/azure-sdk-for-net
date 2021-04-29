// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.Amqp.Transaction;
    using Microsoft.Azure.Amqp.Transport;
    using Microsoft.Azure.ServiceBus.Amqp;
    using Microsoft.Azure.ServiceBus.Primitives;

    /// <summary>
    /// Connection object to service bus namespace
    /// </summary>
    public class ServiceBusConnection
    {
        static readonly Version AmqpVersion = new Version(1, 0, 0, 0);
        readonly object syncLock;
        bool isClosedOrClosing;

        /// <summary>
        /// Creates a new connection to service bus.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace information.</param>
        /// <remarks>It is the responsibility of the user to close the connection after use through <see cref="CloseAsync"/></remarks>
        public ServiceBusConnection(ServiceBusConnectionStringBuilder connectionStringBuilder)
            : this(connectionStringBuilder?.GetNamespaceConnectionString())
        {
        }

        /// <summary>
        /// Creates a new connection to service bus.
        /// </summary>
        /// <param name="namespaceConnectionString">Namespace connection string</param>
        /// <remarks>It is the responsibility of the user to close the connection after use through <see cref="CloseAsync"/></remarks>
        public ServiceBusConnection(string namespaceConnectionString)
            : this(namespaceConnectionString, RetryPolicy.Default)
        {
        }

        /// <summary>
        /// Creates a new connection to service bus.
        /// </summary>
        /// <param name="namespaceConnectionString">Namespace connection string.</param>
        /// <param name="retryPolicy">Retry policy for operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>It is the responsibility of the user to close the connection after use through <see cref="CloseAsync"/></remarks>
        public ServiceBusConnection(string namespaceConnectionString, RetryPolicy retryPolicy = null)
            : this(retryPolicy)
        {
            if (string.IsNullOrWhiteSpace(namespaceConnectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(namespaceConnectionString));
            }

            var serviceBusConnectionStringBuilder = new ServiceBusConnectionStringBuilder(namespaceConnectionString);
            if (!string.IsNullOrWhiteSpace(serviceBusConnectionStringBuilder.EntityPath))
            {
                throw Fx.Exception.Argument(nameof(namespaceConnectionString), "NamespaceConnectionString should not contain EntityPath.");
            }

            this.InitializeConnection(serviceBusConnectionStringBuilder);
        }

        /// <summary>
        /// Creates a new connection to service bus.
        /// </summary>
        /// <param name="namespaceConnectionString">Namespace connection string.</param>
        /// <param name="operationTimeout">Duration after which individual operations will timeout.</param>
        /// <param name="retryPolicy">Retry policy for operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>It is the responsibility of the user to close the connection after use through <see cref="CloseAsync"/></remarks>
        [Obsolete("This constructor is obsolete. Use ServiceBusConnection(string namespaceConnectionString, RetryPolicy retryPolicy) constructor instead, providing operationTimeout in the connection string.")]
        public ServiceBusConnection(string namespaceConnectionString, TimeSpan operationTimeout, RetryPolicy retryPolicy = null)
            : this(retryPolicy)
        {
            if (string.IsNullOrWhiteSpace(namespaceConnectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(namespaceConnectionString));
            }

            var serviceBusConnectionStringBuilder = new ServiceBusConnectionStringBuilder(namespaceConnectionString);
            if (!string.IsNullOrWhiteSpace(serviceBusConnectionStringBuilder.EntityPath))
            {
                throw Fx.Exception.Argument(nameof(namespaceConnectionString), "NamespaceConnectionString should not contain EntityPath.");
            }

            this.InitializeConnection(serviceBusConnectionStringBuilder);
            // operationTimeout argument explicitly provided by caller should take precedence over OperationTimeout found in the connection string.
            this.OperationTimeout = operationTimeout;
        }

        /// <summary>
        /// Creates a new connection to service bus.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="transportType">Transport type.</param>
        /// <param name="retryPolicy">Retry policy for operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        public ServiceBusConnection(string endpoint, TransportType transportType, RetryPolicy retryPolicy = null)
            : this(retryPolicy)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(endpoint));
            }

            var serviceBusConnectionStringBuilder = new ServiceBusConnectionStringBuilder()
            {
                Endpoint = endpoint,
                TransportType = transportType
            };

            this.InitializeConnection(serviceBusConnectionStringBuilder);
        }

        internal ServiceBusConnection(RetryPolicy retryPolicy = null)
        {
            this.RetryPolicy = retryPolicy ?? RetryPolicy.Default;
            this.syncLock = new object();
        }

        /// <summary>
        /// Fully qualified domain name for Service Bus.
        /// </summary>
        public Uri Endpoint { get; set; }

        /// <summary>
        /// OperationTimeout is applied in erroneous situations to notify the caller about the relevant <see cref="ServiceBusException"/>
        /// </summary>
        /// <remarks>Defaults to 1 minute.</remarks>
        public TimeSpan OperationTimeout { get; set; }

        /// <summary>
        /// ConnectionIdleTimeout is applied when a connection recevies no traffic for a certain period of time.
        /// In some situations, underlying transport layer takes really long time to detect a socket error and it may
        /// cause some operations to time out after a long wait. This timeout helps to detect and close an idle connection
        /// without waiting for the network layer to identify a socket error. But this setting may result in some increased
        /// heartbeat traffic between the client and service.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public TimeSpan? ConnectionIdleTimeout { get; set; }

        /// <summary>
        /// Retry policy for operations performed on the connection.
        /// </summary>
        /// <remarks>Defaults to <see cref="RetryPolicy.Default"/></remarks>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Get the transport type from the connection string.
        /// <remarks>Available options: Amqp and AmqpWebSockets.</remarks>
        /// </summary>
        public TransportType TransportType { get; set; }

        /// <summary>
        /// Token provider for authentication. <see cref="TokenProvider"/>
        /// </summary>
        public ITokenProvider TokenProvider { get; set; }

        /// <summary>
        /// Returns true if the Service Bus Connection is closed or closing.
        /// </summary>
        public bool IsClosedOrClosing
        {
            get
            {
                lock (syncLock)
                {
                    return isClosedOrClosing;
                }
            }
            internal set
            {
                lock (syncLock)
                {
                    isClosedOrClosing = value;
                }
            }
        }

        internal FaultTolerantAmqpObject<AmqpConnection> ConnectionManager { get; set; }

        internal FaultTolerantAmqpObject<Controller> TransactionController { get; set; }

        /// <summary>
        /// Throw an OperationCanceledException if the object is Closing.
        /// </summary>
        internal virtual void ThrowIfClosed()
        {
            if (this.IsClosedOrClosing)
            {
                throw new ObjectDisposedException($"{nameof(ServiceBusConnection)} has already been closed. Please create a new instance");
            }
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public async Task CloseAsync()
        {
            var callClose = false;
            lock (this.syncLock)
            {
                if (!this.IsClosedOrClosing)
                {
                    this.IsClosedOrClosing = true;
                    callClose = true;
                }
            }

            if (callClose)
            {
                await this.ConnectionManager.CloseAsync().ConfigureAwait(false);
            }
        }

        void InitializeConnection(ServiceBusConnectionStringBuilder builder)
        {
            this.Endpoint = new Uri(builder.Endpoint);

            if (builder.SasToken != null)
            {
                this.TokenProvider = new SharedAccessSignatureTokenProvider(builder.SasToken);
            }
            else if (builder.SasKeyName != null || builder.SasKey != null)
            {
                this.TokenProvider = new SharedAccessSignatureTokenProvider(builder.SasKeyName, builder.SasKey);
            }
            else if (builder.Authentication.Equals(ServiceBusConnectionStringBuilder.AuthenticationType.ManagedIdentity))
            {
                this.TokenProvider = new ManagedIdentityTokenProvider();
            }

            this.OperationTimeout = builder.OperationTimeout;
            this.TransportType = builder.TransportType;
            this.ConnectionIdleTimeout = builder.ConnectionIdleTimeout;
            this.ConnectionManager = new FaultTolerantAmqpObject<AmqpConnection>(this.CreateConnectionAsync, CloseConnection);
            this.TransactionController = new FaultTolerantAmqpObject<Controller>(this.CreateControllerAsync, CloseController);
        }

        static void CloseConnection(AmqpConnection connection)
        {
            MessagingEventSource.Log.AmqpConnectionClosed(connection);
            connection.SafeClose();
        }

        static void CloseController(Controller controller)
        {
            controller.Close();
        }

        async Task<AmqpConnection> CreateConnectionAsync(TimeSpan timeout)
        {
            var hostName = this.Endpoint.Host;

            var timeoutHelper = new TimeoutHelper(timeout, true);
            var amqpSettings = AmqpConnectionHelper.CreateAmqpSettings(
                amqpVersion: AmqpVersion,
                useSslStreamSecurity: true,
                hasTokenProvider: true,
                useWebSockets: TransportType == TransportType.AmqpWebSockets);

            var transportSettings = CreateTransportSettings();
            var amqpTransportInitiator = new AmqpTransportInitiator(amqpSettings, transportSettings);
            var transport = await amqpTransportInitiator.ConnectTaskAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            var containerId = Guid.NewGuid().ToString();
            var amqpConnectionSettings = AmqpConnectionHelper.CreateAmqpConnectionSettings(AmqpConstants.DefaultMaxFrameSize, containerId, hostName);
            if (this.ConnectionIdleTimeout.HasValue && this.ConnectionIdleTimeout.Value > TimeSpan.Zero)
            {
                uint timeOutInMillis = checked((uint)this.ConnectionIdleTimeout.Value.TotalMilliseconds);
                amqpConnectionSettings.IdleTimeOut = timeOutInMillis;
            }

            var connection = new AmqpConnection(transport, amqpSettings, amqpConnectionSettings);
            await connection.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            // Always create the CBS Link + Session
            var cbsLink = new AmqpCbsLink(connection);
            if (connection.Extensions.Find<AmqpCbsLink>() == null)
            {
                connection.Extensions.Add(cbsLink);
            }

            MessagingEventSource.Log.AmqpConnectionCreated(hostName, connection);

            return connection;
        }

        async Task<Controller> CreateControllerAsync(TimeSpan timeout)
        {
            var timeoutHelper = new TimeoutHelper(timeout, true);
            var connection = await this.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
            AmqpSession amqpSession = null;
            Controller controller;

            try
            {
                amqpSession = connection.CreateSession(sessionSettings);
                await amqpSession.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                controller = new Controller(amqpSession, timeoutHelper.RemainingTime());
                await controller.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (amqpSession != null)
                {
                    await amqpSession.CloseAsync(timeout).ConfigureAwait(false);
                }

                MessagingEventSource.Log.AmqpCreateControllerException(this.ConnectionManager.ToString(), exception);
                throw;
            }

            return controller;
        }

        TransportSettings CreateTransportSettings()
        {
            var hostName = this.Endpoint.Host;
            var networkHost = this.Endpoint.Host;
            var port = this.Endpoint.Port;

            if (TransportType == TransportType.AmqpWebSockets)
            {
                return AmqpConnectionHelper.CreateWebSocketTransportSettings(
                    networkHost: networkHost,
                    hostName: hostName,
                    port: port,
                    proxy: WebRequest.DefaultWebProxy);
            }

            return AmqpConnectionHelper.CreateTcpTransportSettings(
                networkHost: networkHost,
                hostName: hostName,
                port: port,
                useSslStreamSecurity: true);
        }

    }
}