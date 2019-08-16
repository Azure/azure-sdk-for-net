// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.Amqp.Transaction;
    using Microsoft.Azure.Amqp.Transport;
    using Azure.Messaging.ServiceBus.Amqp;
    using Azure.Messaging.ServiceBus.Primitives;

    /// <summary>
    /// Connection object to service bus namespace
    /// </summary>
    public class ServiceBusConnection: IAsyncDisposable
    {
        private static readonly Version AmqpVersion = new Version(1, 0, 0, 0);

        private readonly object syncLock;

        private bool isClosedOrClosing;

        private AmqpClientOptions options;

        /// <summary>
        /// Creates a new connection to service bus.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace information.</param>
        /// <remarks>It is the responsibility of the user to close the connection after use through <see cref="DisposeAsync"/></remarks>
        internal ServiceBusConnection(ServiceBusConnectionStringBuilder connectionStringBuilder, AmqpClientOptions options = null)
            : this(options)
        {

            this.InitializeConnection(connectionStringBuilder);
        }

        /// <summary>
        /// Creates a new connection to service bus.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        public ServiceBusConnection(string endpoint, TokenCredential credential, AmqpClientOptions options = null)
            : this(options)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(endpoint));
            }

            var serviceBusConnectionStringBuilder = new ServiceBusConnectionStringBuilder()
            {
                Endpoint = endpoint
            };

            TokenCredential = credential;
            this.InitializeConnection(serviceBusConnectionStringBuilder);
        }

        internal ServiceBusConnection(AmqpClientOptions options = null)
        {
            options = options ?? new AmqpClientOptions();
            this.options = options;
            this.OperationTimeout = options.OperationTimeout;
            this.TransportType = options.TransportType;
            this.RetryPolicy = options.RetryPolicy;
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
        public TimeSpan OperationTimeout { get; private set; }

        /// <summary>
        /// Retry policy for operations performed on the connection.
        /// </summary>
        public RetryPolicy RetryPolicy { get; private set; }

        /// <summary>
        /// Get the transport type from the connection string.
        /// <remarks>Available options: Amqp and AmqpWebSockets.</remarks>
        /// </summary>
        public TransportType TransportType { get; private set; }

        /// <summary>
        /// Token provider for authentication. <see cref="TokenCredential"/>
        /// </summary>
        public TokenCredential TokenCredential { get; set; }

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


        private void InitializeConnection(ServiceBusConnectionStringBuilder builder)
        {
            this.Endpoint = new Uri(builder.Endpoint);

            if (builder.SasToken != null)
            {
                this.TokenCredential = new SharedAccessSignatureTokenProvider(builder.SasToken);
            }
            else if (builder.SasKeyName != null || builder.SasKey != null)
            {
                this.TokenCredential = new SharedAccessSignatureTokenProvider(builder.SasKeyName, builder.SasKey);
            }
            else if (builder.Authentication.Equals(ServiceBusConnectionStringBuilder.AuthenticationType.ManagedIdentity))
            {
                this.TokenCredential = null;
            }

            this.OperationTimeout = builder.OperationTimeout;
            this.TransportType = builder.TransportType;
            this.ConnectionManager = new FaultTolerantAmqpObject<AmqpConnection>(this.CreateConnectionAsync, CloseConnection);
            this.TransactionController = new FaultTolerantAmqpObject<Controller>(this.CreateControllerAsync, CloseController);
        }

        private static void CloseConnection(AmqpConnection connection)
        {
            MessagingEventSource.Log.AmqpConnectionClosed(connection);
            connection.SafeClose();
        }

        private static void CloseController(Controller controller)
        {
            controller.Close();
        }

        private async Task<AmqpConnection> CreateConnectionAsync(TimeSpan timeout)
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

        private async Task<Controller> CreateControllerAsync(TimeSpan timeout)
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

        private TransportSettings CreateTransportSettings()
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

        public async ValueTask DisposeAsync()
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
                await this.ConnectionManager.CloseAsync();
            }
        }
    }
}