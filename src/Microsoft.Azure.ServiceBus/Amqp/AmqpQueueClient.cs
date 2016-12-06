// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Sasl;
    using Microsoft.Azure.Amqp.Transport;

    sealed class AmqpQueueClient : QueueClient
    {
        const string CbsSaslMechanismName = "MSSBCBS";

        public AmqpQueueClient(ServiceBusConnectionSettings connectionSettings, ReceiveMode mode)
            : base(connectionSettings, mode)
        {
            this.ContainerId = Guid.NewGuid().ToString("N");
            this.AmqpVersion = new Version(1, 0, 0, 0);
            this.MaxFrameSize = AmqpConstants.DefaultMaxFrameSize;
            var tokenProvider = connectionSettings.CreateTokenProvider();
            this.TokenProvider = tokenProvider;
            this.CbsTokenProvider = new TokenProviderAdapter(this);
            this.ConnectionManager = new FaultTolerantAmqpObject<AmqpConnection>(this.CreateConnectionAsync, this.CloseConnection);
        }

        internal ICbsTokenProvider CbsTokenProvider { get; }

        internal FaultTolerantAmqpObject<AmqpConnection> ConnectionManager { get; }

        internal string ContainerId { get; }

        Version AmqpVersion { get; }

        uint MaxFrameSize { get; }

        TokenProvider TokenProvider { get; }

        internal static AmqpSettings CreateAmqpSettings(
            Version amqpVersion,
            bool useSslStreamSecurity,
            bool hasTokenProvider,
            string sslHostName = null,
            bool useWebSockets = false,
            bool sslStreamUpgrade = false,
            NetworkCredential networkCredential = null,
            RemoteCertificateValidationCallback certificateValidationCallback = null,
            bool forceTokenProvider = true)
        {
            var settings = new AmqpSettings();
            if (useSslStreamSecurity && !useWebSockets && sslStreamUpgrade)
            {
                var tlsSettings = new TlsTransportSettings();
                tlsSettings.CertificateValidationCallback = certificateValidationCallback;
                tlsSettings.TargetHost = sslHostName;

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
                    var plainHandler = new SaslPlainHandler();
                    plainHandler.AuthenticationIdentity = networkCredential.UserName;
                    plainHandler.Password = networkCredential.Password;
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

        internal override MessageSender OnCreateMessageSender()
        {
            return new AmqpMessageSender(this);
        }

        internal override MessageReceiver OnCreateMessageReceiver()
        {
            return new AmqpMessageReceiver(this);
        }

        protected override Task OnCloseAsync()
        {
            // Closing the Connection will also close all Links associated with it.
            return this.ConnectionManager.CloseAsync();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1305:FieldNamesMustNotUseHungarianNotation",
            Justification = "tpSettings is a local variable.")]
        static TransportSettings CreateTcpTransportSettings(
            string networkHost,
            string hostName,
            int port,
            bool useSslStreamSecurity,
            bool sslStreamUpgrade = false,
            string sslHostName = null,
            X509Certificate2 certificate = null,
            RemoteCertificateValidationCallback certificateValidationCallback = null)
        {
            TcpTransportSettings tcpSettings = new TcpTransportSettings
            {
                Host = networkHost,
                Port = port < 0 ? AmqpConstants.DefaultSecurePort : port,
                ReceiveBufferSize = AmqpConstants.TransportBufferSize,
                SendBufferSize = AmqpConstants.TransportBufferSize
            };

            TransportSettings tpSettings = tcpSettings;
            if (useSslStreamSecurity && !sslStreamUpgrade)
            {
                TlsTransportSettings tlsSettings = new TlsTransportSettings(tcpSettings)
                {
                    TargetHost = sslHostName ?? hostName,
                    Certificate = certificate,
                    CertificateValidationCallback = certificateValidationCallback
                };
                tpSettings = tlsSettings;
            }

            return tpSettings;
        }

        static AmqpConnectionSettings CreateAmqpConnectionSettings(uint maxFrameSize, string containerId, string hostName)
        {
            var connectionSettings = new AmqpConnectionSettings
            {
                MaxFrameSize = maxFrameSize,
                ContainerId = containerId,
                HostName = hostName
            };
            return connectionSettings;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1305:FieldNamesMustNotUseHungarianNotation",
            Justification = "tpSettings is a local variable.")]
        async Task<AmqpConnection> CreateConnectionAsync(TimeSpan timeout)
        {
            string hostName = this.ConnectionSettings.Endpoint.Host;
            string networkHost = this.ConnectionSettings.Endpoint.Host;
            int port = this.ConnectionSettings.Endpoint.Port;

            var timeoutHelper = new TimeoutHelper(timeout);
            var amqpSettings = CreateAmqpSettings(
                amqpVersion: this.AmqpVersion,
                useSslStreamSecurity: true,
                hasTokenProvider: true);

            TransportSettings tpSettings = CreateTcpTransportSettings(
                networkHost: networkHost,
                hostName: hostName,
                port: port,
                useSslStreamSecurity: true);

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

        void CloseConnection(AmqpConnection connection)
        {
            connection.SafeClose();
        }

        /// <summary>
        /// Provides an adapter from TokenProvider to ICbsTokenProvider for AMQP CBS usage.
        /// </summary>
        sealed class TokenProviderAdapter : ICbsTokenProvider
        {
            readonly AmqpQueueClient queueClient;

            public TokenProviderAdapter(AmqpQueueClient queueClient)
            {
                Fx.Assert(queueClient != null, "tokenProvider cannot be null");
                this.queueClient = queueClient;
            }

            public async Task<CbsToken> GetTokenAsync(Uri namespaceAddress, string appliesTo, string[] requiredClaims)
            {
                string claim = requiredClaims?.FirstOrDefault();
                var tokenProvider = this.queueClient.TokenProvider;
                var timeout = this.queueClient.ConnectionSettings.OperationTimeout;
                var token = await tokenProvider.GetTokenAsync(appliesTo, claim, timeout).ConfigureAwait(false);
                return new CbsToken(token.TokenValue, CbsConstants.ServiceBusSasTokenType, token.ExpiresAtUtc);
            }
        }
    }
}