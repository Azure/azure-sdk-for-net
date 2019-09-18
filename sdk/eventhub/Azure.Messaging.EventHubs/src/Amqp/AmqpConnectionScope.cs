// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Microsoft.Azure.Amqp;
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

        /// <summary>The version of AMQP to use within the scope.</summary>
        private static readonly Version s_amqpVersion = new Version(1, 0, 0, 0);

        /// <summary>Indicates whether or not this instance has been disposed.</summary>
        private bool _disposed = false;

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
        ///   The name of the Event Hub to which the scope is associated.
        /// </summary>
        ///
        private string EventHubName { get; }

        /// <summary>
        ///   The credential to use for authorization with the Event Hubs service.
        /// </summary>
        ///
        private TokenCredential Credential { get; }

        /// <summary>
        ///   The type of transport to use for communication.
        /// </summary>
        ///
        private TransportType Transport { get; }

        /// <summary>
        ///   The proxy, if any, which should be used for communication.
        /// </summary>
        ///
        private IWebProxy Proxy { get; }

        /// <summary>
        ///   The AMQP connection that is active for the current scope.
        /// </summary>
        ///
        private FaultTolerantAmqpObject<AmqpConnection> ActiveConnection { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpConnectionScope"/> class.
        /// </summary>
        ///
        /// <param name="serviceEndpoint">Endpoint for the Event Hubs service to which the scope is associated.</param>
        /// <param name="eventHubName"> The name of the Event Hub to which the scope is associated</param>
        /// <param name="credential">The credential to use for authorization with the Event Hubs service.</param>
        /// <param name="transport">The transport to use for communication.</param>
        /// <param name="proxy">The proxy, if any, to use for communication.</param>
        /// <param name="identifier">The identifier to assign this scope; if not provided, one will be generated.</param>
        ///
        public AmqpConnectionScope(Uri serviceEndpoint,
                                   string eventHubName,
                                   TokenCredential credential,
                                   TransportType transport,
                                   IWebProxy proxy,
                                   string identifier = default)
        {
            Argument.AssertNotNull(serviceEndpoint, nameof(serviceEndpoint));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(credential, nameof(credential));
            ValidateTransport(transport);

            ServiceEndpoint = serviceEndpoint;
            EventHubName = eventHubName;
            Credential = credential;
            Transport = transport;
            Proxy = proxy;
            Id = identifier ?? $"{ eventHubName }-{ Guid.NewGuid().ToString("D").Substring(0, 8) }";

            Task<AmqpConnection> connectionFactory(TimeSpan timeout) => CreateConnectionAsync(s_amqpVersion, ServiceEndpoint, Transport, Proxy, Id, timeout);
            ActiveConnection = new FaultTolerantAmqpObject<AmqpConnection>(connectionFactory, CloseConnection);
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
        public async Task<RequestResponseAmqpLink> OpenManagementLinkAsync(TimeSpan timeout,
                                                                           CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var stopWatch = Stopwatch.StartNew();
            AmqpConnection connection = await ActiveConnection.GetOrCreateAsync(timeout).ConfigureAwait(false);
            stopWatch.Stop();

            return await OpenManagementLinkAsync(connection, timeout.CalculateRemaining(stopWatch.Elapsed), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="AmqpConnectionScope" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            ActiveConnection?.Dispose();
            _disposed = true;
        }

        /// <summary>
        ///   Creates an AMQP connection for a given scope.
        /// </summary>
        ///
        /// <param name="amqpVersion">The version of AMQP to use for the connection.</param>
        /// <param name="serviceEndpoint">The endpoint for the Event Hubs service to which the scope is associated.</param>
        /// <param name="transportType">The type of transport to use for communication.</param>
        /// <param name="proxy">The proxy, if any, to use for communication.</param>
        /// <param name="scopeIdentifier">The unique identifier for the associated scope.</param>
        /// <param name="timeout">The timeout to consider when creating the connection.</param>
        ///
        /// <returns>An AMQP connection that may be used for communicating with the Event Hubs service.</returns>
        ///
        protected virtual async Task<AmqpConnection> CreateConnectionAsync(Version amqpVersion,
                                                                           Uri serviceEndpoint,
                                                                           TransportType transportType,
                                                                           IWebProxy proxy,
                                                                           string scopeIdentifier,
                                                                           TimeSpan timeout)
        {
            var hostName = serviceEndpoint.Host;
            AmqpSettings amqpSettings = CreateAmpqSettings(s_amqpVersion);
            AmqpConnectionSettings connectionSetings = CreateAmqpConnectionSettings(hostName, scopeIdentifier);

            TransportSettings transportSettings = transportType.IsWebSocketTransport()
                ? CreateTransportSettingsForWebSockets(hostName, proxy)
                : CreateTransportSettingsforTcp(hostName, serviceEndpoint.Port);

            // Create and open the connection, respecting the timeout constraint
            // that was received.

            var stopWatch = Stopwatch.StartNew();

            var initiator = new AmqpTransportInitiator(amqpSettings, transportSettings);
            TransportBase transport = await initiator.ConnectTaskAsync(timeout).ConfigureAwait(false);

            var connection = new AmqpConnection(transport, amqpSettings, connectionSetings);
            await connection.OpenAsync(timeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);

            stopWatch.Stop();

            // Create the CBS link that will be used for authorization and ensure that it is associated
            // with the connection.

            var cbsLink = new AmqpCbsLink(connection);

            // TODO (pri2 // squire):
            //   The act of creating the link should ensure that it is added to the connection.  Unsure
            //   of why this additional check was in the track one code.   Investigate and either
            //   document or remove.

            if (!connection.Extensions.Contains(typeof(AmqpCbsLink)))
            {
                connection.Extensions.Add(cbsLink);
            }

            return connection;
        }

        /// <summary>
        ///   Opens an AMQP link for use with management operations.
        /// </summary>
        ///
        /// <param name="connection">The active and opened AMQP connection to use for this link.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A link for use with management operations.</returns>
        ///
        protected virtual async Task<RequestResponseAmqpLink> OpenManagementLinkAsync(AmqpConnection connection,
                                                                                      TimeSpan timeout,
                                                                                      CancellationToken cancellationToken)
        {
            Argument.AssertNotDisposed(_disposed, nameof(AmqpConnectionScope));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var session = default(AmqpSession);
            var stopWatch = Stopwatch.StartNew();

            try
            {
                // Create and open the AMQP session associated with the link.

                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);

                await session.OpenAsync(timeout).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // Create and open the link.

                var linkSettings = new AmqpLinkSettings();
                linkSettings.AddProperty(AmqpProperty.Timeout, (uint)timeout.CalculateRemaining(stopWatch.Elapsed).TotalMilliseconds);

                var link = new RequestResponseAmqpLink(AmqpManagement.LinkType, session, AmqpManagement.Address, linkSettings.Properties);
                await link.OpenAsync(timeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);

                stopWatch.Stop();
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
        ///   Performs the tasks needed to close a connection.
        /// </summary>
        ///
        /// <param name="connection">The connection to close.</param>
        ///
        protected virtual void CloseConnection(AmqpConnection connection) => connection.SafeClose();

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
        ///
        /// <returns>The settings to use for transport.</returns>
        ///
        private static TransportSettings CreateTransportSettingsforTcp(string hostName,
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
        /// <param name="hostName">The host name of the Event Hubs service endpoint.</param>
        /// <param name="proxy">The proxy to use for connecting to the endpoint.</param>
        ///
        /// <returns>The settings to use for transport.</returns>
        ///
        private static TransportSettings CreateTransportSettingsForWebSockets(string hostName,
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
                MaxFrameSize = AmqpConstants.DefaultMaxFrameSize,
                ContainerId = identifier,
                HostName = hostName
            };

            foreach (KeyValuePair<string, string> property in ClientLibraryInformation.s_current.EnumerateProperties())
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
        private static void ValidateTransport(TransportType transport)
        {
            if ((transport != TransportType.AmqpTcp) && (transport != TransportType.AmqpWebSockets))
            {
                throw new ArgumentException(nameof(transport), string.Format(CultureInfo.CurrentCulture, Resources.UnknownConnectionType, transport));
            }
        }
    }
}
