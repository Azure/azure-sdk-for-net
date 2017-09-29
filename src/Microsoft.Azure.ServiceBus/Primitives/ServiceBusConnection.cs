// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Transport;
    using Microsoft.Azure.ServiceBus.Amqp;

    internal abstract class ServiceBusConnection
    {
        static readonly Version AmqpVersion = new Version(1, 0, 0, 0);

        protected ServiceBusConnection(TimeSpan operationTimeout, RetryPolicy retryPolicy)
        {
            this.OperationTimeout = operationTimeout;
            this.RetryPolicy = retryPolicy;
        }

        public Uri Endpoint { get; set; }

        /// <summary>
        /// OperationTimeout is applied in erroneous situations to notify the caller about the relevant <see cref="ServiceBusException"/>
        /// </summary>
        public TimeSpan OperationTimeout { get; set; }

        /// <summary>
        /// Get the retry policy instance that was created as part of this builder's creation.
        /// </summary>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Get the shared access policy key value from the connection string
        /// </summary>
        /// <value>Shared Access Signature key</value>
        public string SasKey { get; set; }

        /// <summary>
        /// Get the shared access policy name from the connection string
        /// </summary>
        public string SasKeyName { get; set; }

        /// <summary>
        /// Get the shared access signature token from the connection string
        /// </summary>
        public string SasToken { get; set; }

        /// <summary>
        /// Get the transport type from the connection string.
        /// <remarks>Amqp and AmqpWebSockets are available.</remarks>
        /// </summary>
        public TransportType TransportType { get; set; }

        internal FaultTolerantAmqpObject<AmqpConnection> ConnectionManager { get; set; }

        public Task CloseAsync()
        {
            return this.ConnectionManager.CloseAsync();
        }

        protected void InitializeConnection(ServiceBusConnectionStringBuilder builder)
        {
            this.Endpoint = new Uri(builder.Endpoint);
            this.SasKeyName = builder.SasKeyName;
            this.SasKey = builder.SasKey;
            this.SasToken = builder.SasToken;
            this.TransportType = builder.TransportType;
            this.ConnectionManager = new FaultTolerantAmqpObject<AmqpConnection>(this.CreateConnectionAsync, CloseConnection);
        }

        static void CloseConnection(AmqpConnection connection)
        {
            MessagingEventSource.Log.AmqpConnectionClosed(connection);
            connection.SafeClose();
        }

        async Task<AmqpConnection> CreateConnectionAsync(TimeSpan timeout)
        {
            var hostName = this.Endpoint.Host;

            var timeoutHelper = new TimeoutHelper(timeout);
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
                    port: port);
            }

            return AmqpConnectionHelper.CreateTcpTransportSettings(
                networkHost: networkHost,
                hostName: hostName,
                port: port,
                useSslStreamSecurity: true);
        }

        internal TokenProvider CreateTokenProvider()
        {
            if (SasToken != null)
            {
                return TokenProvider.CreateSharedAccessSignatureTokenProvider(SasToken);
            }
            else
            {
                return TokenProvider.CreateSharedAccessSignatureTokenProvider(SasKeyName, SasKey);
            }
        }

    }
}