// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Amqp
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp.Sasl;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Transport;
    using Microsoft.Azure.EventHubs.Amqp.Management;

    sealed class AmqpEventHubClient : EventHubClient
    {
        const string CbsSaslMechanismName = "MSSBCBS";
        readonly Lazy<AmqpServiceClient> managementServiceClient; // serviceClient that handles management calls

        internal AmqpEventHubClient(
            Uri endpointAddress,
            string entityPath,
            ITokenProvider tokenProvider,
            TimeSpan operationTimeout,
            EventHubs.TransportType transportType)
            : this(new EventHubsConnectionStringBuilder(endpointAddress, entityPath, operationTimeout, transportType), tokenProvider)
        {
        }

        internal AmqpEventHubClient(EventHubsConnectionStringBuilder csb, ITokenProvider tokenProvider)
            : base(csb)
        {
            this.ContainerId = Guid.NewGuid().ToString("N");
            this.AmqpVersion = new Version(1, 0, 0, 0);
            this.MaxFrameSize = AmqpConstants.DefaultMaxFrameSize;

            if (tokenProvider != null)
            {
                this.InternalTokenProvider = tokenProvider;
            }
            else if (!string.IsNullOrWhiteSpace(csb.SharedAccessSignature))
            {
                this.InternalTokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(csb.SharedAccessSignature);
            }
            else if (!string.IsNullOrWhiteSpace(csb.SasKey))
            {
                this.InternalTokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(csb.SasKeyName, csb.SasKey);
            }
            else if (string.Equals(csb.Authentication, "ManagedIdentity", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(csb.Authentication, "Managed Identity", StringComparison.OrdinalIgnoreCase))
            {
                this.InternalTokenProvider = TokenProvider.CreateManagedIdentityTokenProvider();
            }

            this.CbsTokenProvider = new TokenProviderAdapter(this);
            this.ConnectionManager = new FaultTolerantAmqpObject<AmqpConnection>(this.CreateConnectionAsync, CloseConnection);
            this.managementServiceClient = new Lazy<AmqpServiceClient>(this.CreateAmpqServiceClient);
        }

        internal ICbsTokenProvider CbsTokenProvider { get; }

        internal FaultTolerantAmqpObject<AmqpConnection> ConnectionManager { get; }

        internal string ContainerId { get; }

        Version AmqpVersion { get; }

        uint MaxFrameSize { get; }

        internal ITokenProvider InternalTokenProvider { get; }

        internal override EventDataSender OnCreateEventSender(string partitionId)
        {
            var sender = new AmqpEventDataSender(this, partitionId);

            if (this.RegisteredPlugins.Count >= 1)
            {
                // register all the plugins
                foreach (var plugin in this.RegisteredPlugins)
                {
                    sender.RegisterPlugin(plugin.Value);
                }
            }

            return sender;
        }

        protected override PartitionReceiver OnCreateReceiver(
            string consumerGroupName, string partitionId, EventPosition eventPosition, long? epoch, ReceiverOptions receiverOptions)
        {
            return new AmqpPartitionReceiver(
                this, consumerGroupName, partitionId, eventPosition, epoch, receiverOptions);
        }

        protected override Task OnCloseAsync()
        {
            // Closing the Connection will also close all Links associated with it.
            return this.ConnectionManager.CloseAsync();
        }

        protected override Task<EventHubRuntimeInformation> OnGetRuntimeInformationAsync()
        {
            return this.managementServiceClient.Value.GetRuntimeInformationAsync();
        }

        protected override Task<EventHubPartitionRuntimeInformation> OnGetPartitionRuntimeInformationAsync(string partitionId)
        {
            return this.managementServiceClient.Value.GetPartitionRuntimeInformationAsync(partitionId);
        }

        static AmqpSettings CreateAmqpSettings(
           Version amqpVersion,
           bool useSslStreamSecurity,
           bool hasTokenProvider,
           string sslHostName = null,
           bool useWebSockets = false,
           bool sslStreamUpgrade = false,
           NetworkCredential networkCredential = null,
           bool forceTokenProvider = true)
        {
            var settings = new AmqpSettings();
            if (useSslStreamSecurity && !useWebSockets && sslStreamUpgrade)
            {
                var tlsSettings = new TlsTransportSettings
                {
                    TargetHost = sslHostName
                };

                var tlsProvider = new TlsTransportProvider(tlsSettings);
                tlsProvider.Versions.Add(new AmqpVersion(amqpVersion));
                settings.TransportProviders.Add(tlsProvider);
            }

            if (hasTokenProvider || networkCredential != null)
            {
                var saslProvider = new SaslTransportProvider();
                saslProvider.Versions.Add(new AmqpVersion(amqpVersion));
                settings.TransportProviders.Add(saslProvider);

                if (forceTokenProvider)
                {
                    saslProvider.AddHandler(new SaslAnonymousHandler(CbsSaslMechanismName));
                }
                else if (networkCredential != null)
                {
                    var plainHandler = new SaslPlainHandler
                    {
                        AuthenticationIdentity = networkCredential.UserName,
                        Password = networkCredential.Password
                    };
                    saslProvider.AddHandler(plainHandler);
                }
                else
                {
                    // old client behavior: keep it for validation only
                    saslProvider.AddHandler(new SaslExternalHandler());
                }
            }

            var amqpProvider = new AmqpTransportProvider();
            amqpProvider.Versions.Add(new AmqpVersion(amqpVersion));
            settings.TransportProviders.Add(amqpProvider);

            return settings;
        }

        static TransportSettings CreateTcpTlsTransportSettings(string hostName, int port)
        {
            TcpTransportSettings tcpSettings = new TcpTransportSettings
            {
                Host = hostName,
                Port = port < 0 ? AmqpConstants.DefaultSecurePort : port,
                ReceiveBufferSize = AmqpConstants.TransportBufferSize,
                SendBufferSize = AmqpConstants.TransportBufferSize
            };

            TlsTransportSettings tlsSettings = new TlsTransportSettings(tcpSettings)
            {
                TargetHost = hostName,
            };

            return tlsSettings;
        }

        static TransportSettings CreateWebSocketsTransportSettings(string hostName, IWebProxy webProxy)
        {
            var uriBuilder = new UriBuilder(hostName)
            {
                Path = AmqpClientConstants.WebSocketsPathSuffix,
                Scheme = AmqpClientConstants.UriSchemeWss,
                Port = -1 // Port will be assigned on transport listener.
            };
            var ts = new WebSocketTransportSettings
            {
                Uri = uriBuilder.Uri
            };

            // Proxy Uri provided?
            if (webProxy != null)
            {
                ts.Proxy = webProxy;
            }

            return ts;
        }

        static AmqpConnectionSettings CreateAmqpConnectionSettings(uint maxFrameSize, string containerId, string hostName)
        {
            var connectionSettings = new AmqpConnectionSettings
            {
                MaxFrameSize = maxFrameSize,
                ContainerId = containerId,
                HostName = hostName,
                IdleTimeOut = (uint)AmqpClientConstants.ConnectionIdleTimeout.TotalMilliseconds
            };

            ClientInfo.Add(connectionSettings);
            return connectionSettings;
        }

        async Task<AmqpConnection> CreateConnectionAsync(TimeSpan timeout)
        {
            string hostName = this.ConnectionStringBuilder.Endpoint.Host;
            int port = this.ConnectionStringBuilder.Endpoint.Port;
            bool useWebSockets = this.ConnectionStringBuilder.TransportType == EventHubs.TransportType.AmqpWebSockets;

            var timeoutHelper = new TimeoutHelper(timeout);
            var amqpSettings = CreateAmqpSettings(
                amqpVersion: this.AmqpVersion,
                useSslStreamSecurity: true,
                hasTokenProvider: true,
                useWebSockets: useWebSockets);

            TransportSettings tpSettings = useWebSockets
                ? CreateWebSocketsTransportSettings(hostName, this.WebProxy)
                : CreateTcpTlsTransportSettings(hostName, port);

            var initiator = new AmqpTransportInitiator(amqpSettings, tpSettings);
            var transport = await initiator.ConnectTaskAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            var connectionSettings = CreateAmqpConnectionSettings(this.MaxFrameSize, this.ContainerId, hostName);
            var connection = new AmqpConnection(transport, amqpSettings, connectionSettings);
            await connection.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            // Always create the CBS Link + Session
            var cbsLink = new AmqpCbsLink(connection);
            if (connection.Extensions.Find<AmqpCbsLink>() == null)
            {
                connection.Extensions.Add(cbsLink);
            }

            return connection;
        }

        static void CloseConnection(AmqpConnection connection)
        {
            connection.SafeClose();
        }

        AmqpServiceClient CreateAmpqServiceClient()
        {
            var client = new AmqpServiceClient(this, AmqpClientConstants.ManagementAddress);
            Fx.Assert(string.Equals(client.Address, AmqpClientConstants.ManagementAddress, StringComparison.OrdinalIgnoreCase),
                "The address should match the address of managementServiceClient");
            return client;
        }

        /// <summary>
        /// Provides an adapter from TokenProvider to ICbsTokenProvider for AMQP CBS usage.
        /// </summary>
        sealed class TokenProviderAdapter : ICbsTokenProvider
        {
            readonly AmqpEventHubClient eventHubClient;

            public TokenProviderAdapter(AmqpEventHubClient eventHubClient)
            {
                Fx.Assert(eventHubClient != null, "tokenProvider cannot be null");
                this.eventHubClient = eventHubClient;
            }

            public async Task<CbsToken> GetTokenAsync(Uri namespaceAddress, string appliesTo, string[] requiredClaims)
            {
                var timeout = this.eventHubClient.ConnectionStringBuilder.OperationTimeout;
                var token = await this.eventHubClient.InternalTokenProvider.GetTokenAsync(appliesTo, timeout).ConfigureAwait(false);
                return new CbsToken(token.TokenValue, token.TokenType, token.ExpiresAtUtc);
            }
        }
    }
}