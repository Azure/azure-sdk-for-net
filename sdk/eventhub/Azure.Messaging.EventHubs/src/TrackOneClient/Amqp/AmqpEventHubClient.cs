// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Sasl;
using Microsoft.Azure.Amqp.Transport;
using TrackOne.Amqp.Management;

namespace TrackOne.Amqp
{
    internal sealed class AmqpEventHubClient : EventHubClient
    {
        private const string CbsSaslMechanismName = "MSSBCBS";
        private readonly Lazy<AmqpServiceClient> _managementServiceClient; // serviceClient that handles management calls

        public AmqpEventHubClient(EventHubsConnectionStringBuilder csb)
            : this(csb,
                !string.IsNullOrWhiteSpace(csb.SharedAccessSignature)
                ? TokenProvider.CreateSharedAccessSignatureTokenProvider(csb.SharedAccessSignature)
                : TokenProvider.CreateSharedAccessSignatureTokenProvider(csb.SasKeyName, csb.SasKey))
        {
        }

        public AmqpEventHubClient(
            Uri endpointAddress,
            string entityPath,
            ITokenProvider tokenProvider,
            TimeSpan operationTimeout,
            TrackOne.TransportType transportType)
            : this(new EventHubsConnectionStringBuilder(endpointAddress, entityPath, operationTimeout, transportType), tokenProvider)
        {
        }

        private AmqpEventHubClient(EventHubsConnectionStringBuilder csb, ITokenProvider tokenProvider)
            : base(csb)
        {
            ContainerId = Guid.NewGuid().ToString("N");
            AmqpVersion = new Version(1, 0, 0, 0);
            MaxFrameSize = AmqpConstants.DefaultMaxFrameSize;
            InternalTokenProvider = tokenProvider;

            CbsTokenProvider = new TokenProviderAdapter(this);
            ConnectionManager = new FaultTolerantAmqpObject<AmqpConnection>(CreateConnectionAsync, CloseConnection);
            _managementServiceClient = new Lazy<AmqpServiceClient>(CreateAmpqServiceClient);
        }

        internal ICbsTokenProvider CbsTokenProvider { get; }

        internal FaultTolerantAmqpObject<AmqpConnection> ConnectionManager { get; }

        internal string ContainerId { get; }

        private Version AmqpVersion { get; }

        private uint MaxFrameSize { get; }

        internal ITokenProvider InternalTokenProvider { get; }

        internal override EventDataSender OnCreateEventSender(string partitionId)
        {
            var sender = new AmqpEventDataSender(this, partitionId);

            if (RegisteredPlugins.Count >= 1)
            {
                // register all the plugins
                foreach (KeyValuePair<string, Core.EventHubsPlugin> plugin in RegisteredPlugins)
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
            return ConnectionManager.CloseAsync();
        }

        protected override Task<EventHubRuntimeInformation> OnGetRuntimeInformationAsync()
        {
            return _managementServiceClient.Value.GetRuntimeInformationAsync();
        }

        protected override Task<EventHubPartitionRuntimeInformation> OnGetPartitionRuntimeInformationAsync(string partitionId)
        {
            return _managementServiceClient.Value.GetPartitionRuntimeInformationAsync(partitionId);
        }

        private static AmqpSettings CreateAmqpSettings(
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

        private static TransportSettings CreateTcpTlsTransportSettings(string hostName, int port)
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

        private static TransportSettings CreateWebSocketsTransportSettings(string hostName, IWebProxy webProxy)
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

        private static AmqpConnectionSettings CreateAmqpConnectionSettings(uint maxFrameSize, string containerId, string hostName)
        {
            var connectionSettings = new AmqpConnectionSettings
            {
                MaxFrameSize = maxFrameSize,
                ContainerId = containerId,
                HostName = hostName
            };

            ClientInfo.Add(connectionSettings);
            return connectionSettings;
        }

        private async Task<AmqpConnection> CreateConnectionAsync(TimeSpan timeout)
        {
            string hostName = ConnectionStringBuilder.Endpoint.Host;
            int port = ConnectionStringBuilder.Endpoint.Port;
            bool useWebSockets = ConnectionStringBuilder.TransportType == TrackOne.TransportType.AmqpWebSockets;

            var timeoutHelper = new TimeoutHelper(timeout);
            AmqpSettings amqpSettings = CreateAmqpSettings(
                amqpVersion: AmqpVersion,
                useSslStreamSecurity: true,
                hasTokenProvider: true,
                useWebSockets: useWebSockets);

            TransportSettings tpSettings = useWebSockets
                ? CreateWebSocketsTransportSettings(hostName, WebProxy)
                : CreateTcpTlsTransportSettings(hostName, port);

            var initiator = new AmqpTransportInitiator(amqpSettings, tpSettings);
            TransportBase transport = await initiator.ConnectTaskAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            AmqpConnectionSettings connectionSettings = CreateAmqpConnectionSettings(MaxFrameSize, ContainerId, hostName);
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

        private static void CloseConnection(AmqpConnection connection)
        {
            connection.SafeClose();
        }

        private AmqpServiceClient CreateAmpqServiceClient()
        {
            var client = new AmqpServiceClient(this, AmqpClientConstants.ManagementAddress);
            Fx.Assert(string.Equals(client.Address, AmqpClientConstants.ManagementAddress, StringComparison.OrdinalIgnoreCase),
                "The address should match the address of managementServiceClient");
            return client;
        }

        /// <summary>
        /// Provides an adapter from TokenProvider to ICbsTokenProvider for AMQP CBS usage.
        /// </summary>
        private sealed class TokenProviderAdapter : ICbsTokenProvider
        {
            private readonly AmqpEventHubClient eventHubClient;

            public TokenProviderAdapter(AmqpEventHubClient eventHubClient)
            {
                Fx.Assert(eventHubClient != null, "tokenProvider cannot be null");
                this.eventHubClient = eventHubClient;
            }

            public async Task<CbsToken> GetTokenAsync(Uri namespaceAddress, string appliesTo, string[] requiredClaims)
            {
                TimeSpan timeout = eventHubClient.ConnectionStringBuilder.OperationTimeout;
                SecurityToken token = await eventHubClient.InternalTokenProvider.GetTokenAsync(appliesTo, timeout).ConfigureAwait(false);
                return new CbsToken(token.TokenValue, token.TokenType, token.ExpiresAtUtc);
            }
        }
    }
}
