// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Net;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Sasl;
    using Microsoft.Azure.Amqp.Transport;
    using Microsoft.Azure.ServiceBus.Primitives;

    internal class AmqpConnectionHelper
    {
        const string CbsSaslMechanismName = "MSSBCBS";

        public static AmqpSettings CreateAmqpSettings(
            Version amqpVersion,
            bool useSslStreamSecurity,
            bool hasTokenProvider,
            string sslHostName = null,
            bool useWebSockets = false,
            bool sslStreamUpgrade = false,
            System.Net.NetworkCredential networkCredential = null,
            bool forceTokenProvider = true)
        {
            var amqpSettings = new AmqpSettings();
            if (useSslStreamSecurity && !useWebSockets && sslStreamUpgrade)
            {
                var tlsSettings = new TlsTransportSettings
                {
                    TargetHost = sslHostName
                };

                var tlsProvider = new TlsTransportProvider(tlsSettings);
                tlsProvider.Versions.Add(new AmqpVersion(amqpVersion));
                amqpSettings.TransportProviders.Add(tlsProvider);
            }

            if (hasTokenProvider || networkCredential != null)
            {
                var saslTransportProvider = new SaslTransportProvider();
                saslTransportProvider.Versions.Add(new AmqpVersion(amqpVersion));
                amqpSettings.TransportProviders.Add(saslTransportProvider);

                if (forceTokenProvider)
                {
                    saslTransportProvider.AddHandler(new SaslAnonymousHandler(CbsSaslMechanismName));
                }
                else if (networkCredential != null)
                {
                    var plainHandler = new SaslPlainHandler
                    {
                        AuthenticationIdentity = networkCredential.UserName,
                        Password = networkCredential.Password
                    };
                    saslTransportProvider.AddHandler(plainHandler);
                }
                else
                {
                    // old client behavior: keep it for validation only
                    saslTransportProvider.AddHandler(new SaslExternalHandler());
                }
            }

            var amqpTransportProvider = new AmqpTransportProvider();
            amqpTransportProvider.Versions.Add(new AmqpVersion(amqpVersion));
            amqpSettings.TransportProviders.Add(amqpTransportProvider);

            return amqpSettings;
        }

        public static TransportSettings CreateTcpTransportSettings(
            string networkHost,
            string hostName,
            int port,
            bool useSslStreamSecurity,
            bool sslStreamUpgrade = false,
            string sslHostName = null)
        {
            var tcpTransportSettings = new TcpTransportSettings
            {
                Host = networkHost,
                Port = port < Constants.WellKnownPublicPortsLimit ? AmqpConstants.DefaultSecurePort : port,
                ReceiveBufferSize = AmqpConstants.TransportBufferSize,
                SendBufferSize = AmqpConstants.TransportBufferSize
            };

            TransportSettings tpSettings = tcpTransportSettings;
            if (useSslStreamSecurity && !sslStreamUpgrade)
            {
                var tlsTransportSettings = new TlsTransportSettings(tcpTransportSettings)
                {
                    TargetHost = sslHostName ?? hostName
                };
                tpSettings = tlsTransportSettings;
            }

            return tpSettings;
        }

        public static TransportSettings CreateWebSocketTransportSettings(
            string networkHost,
            string hostName,
            int port,
            IWebProxy proxy)
        {
            var uriBuilder = new UriBuilder(
                WebSocketConstants.WebSocketSecureScheme,
                networkHost,
                port < Constants.WellKnownPublicPortsLimit ? WebSocketConstants.WebSocketSecurePort : port,
                WebSocketConstants.WebSocketDefaultPath);
            var webSocketTransportSettings = new WebSocketTransportSettings
            {
                Uri = uriBuilder.Uri,
                ReceiveBufferSize = AmqpConstants.TransportBufferSize,
                SendBufferSize = AmqpConstants.TransportBufferSize,
                Proxy = proxy
            };

            TransportSettings tpSettings = webSocketTransportSettings;
            return tpSettings;
        }

        public static AmqpConnectionSettings CreateAmqpConnectionSettings(uint maxFrameSize, string containerId, string hostName)
        {
            var connectionSettings = new AmqpConnectionSettings
            {
                MaxFrameSize = maxFrameSize,
                ContainerId = containerId,
                HostName = hostName,
                IdleTimeOut = (uint)Constants.DefaultOperationTimeout.TotalMilliseconds
            };

            connectionSettings.AddProperty("product", ClientInfo.Product);
            connectionSettings.AddProperty("version", ClientInfo.Version);
            connectionSettings.AddProperty("framework", ClientInfo.Framework);
            connectionSettings.AddProperty("platform", ClientInfo.Platform);
            return connectionSettings;
        }
    }
}