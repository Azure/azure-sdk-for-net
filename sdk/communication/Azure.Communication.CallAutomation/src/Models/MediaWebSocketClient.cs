// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Represents an authenticated WebSocket connection to Azure Communication Services
    /// media streaming and transcription endpoints.
    /// </summary>
#pragma warning disable AZC0005 // Sealed class intentionally has no protected constructor for mocking.
    public sealed class MediaWebSocketClient : IDisposable
#pragma warning restore AZC0005
    {
        private readonly ClientWebSocket _socket;

        private MediaWebSocketClient(ClientWebSocket socket)
        {
            _socket = socket;
        }

        /// <summary>
        /// Creates a new <see cref="MediaWebSocketBuilder"/> for constructing
        /// an authenticated WebSocket connection.
        /// </summary>
        /// <param name="client">The CallAutomationClient to use for authentication.</param>
        /// <returns>A new builder instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when client is null.</exception>
        public static MediaWebSocketBuilder Builder(CallAutomationClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new MediaWebSocketBuilder(client);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _socket.Dispose();
        }

        /// <summary>
        /// Fluent builder for constructing and connecting a <see cref="MediaWebSocketClient"/>.
        /// </summary>
        public sealed class MediaWebSocketBuilder
        {
            private readonly CallAutomationClient _client;
            private Uri _streamUrl;
            private TimeSpan? _connectTimeout;
            private TimeSpan? _keepAliveInterval;
            private int? _receiveBufferSize;
            private int? _sendBufferSize;
            private string _subProtocol;
            private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();

            internal MediaWebSocketBuilder(CallAutomationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Sets the WebSocket stream URL to connect to.
            /// </summary>
            public MediaWebSocketBuilder WithStreamUrl(string streamUrl)
            {
                _streamUrl = new Uri(streamUrl ?? throw new ArgumentNullException(nameof(streamUrl)));
                return this;
            }

            /// <summary>
            /// Sets the WebSocket stream URL to connect to.
            /// </summary>
            public MediaWebSocketBuilder WithStreamUrl(Uri streamUrl)
            {
                _streamUrl = streamUrl ?? throw new ArgumentNullException(nameof(streamUrl));
                return this;
            }

            /// <summary>
            /// Adds a custom header to the WebSocket request.
            /// </summary>
            public MediaWebSocketBuilder WithCustomHeader(string name, string value)
            {
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("Header name cannot be null or empty.", nameof(name));
                _headers[name] = value ?? throw new ArgumentNullException(nameof(value));
                return this;
            }

            /// <summary>
            /// Sets the connection timeout. If not specified, the connection attempt will wait
            /// indefinitely (or until the provided <see cref="CancellationToken"/> is cancelled).
            /// </summary>
            public MediaWebSocketBuilder WithConnectTimeout(TimeSpan timeout)
            {
                _connectTimeout = timeout;
                return this;
            }

            /// <summary>
            /// Sets the WebSocket keep-alive interval. If not specified, the default value from
            /// <see cref="ClientWebSocket"/> is used (30 seconds).
            /// </summary>
            public MediaWebSocketBuilder WithKeepAliveInterval(TimeSpan interval)
            {
                _keepAliveInterval = interval;
                return this;
            }

            /// <summary>
            /// Sets the receive and send buffer sizes. If not specified, the default values from
            /// <see cref="ClientWebSocket"/> are used (16,384 bytes for both receive and send).
            /// </summary>
            public MediaWebSocketBuilder WithBufferSize(int receiveBufferSize, int sendBufferSize)
            {
                _receiveBufferSize = receiveBufferSize;
                _sendBufferSize = sendBufferSize;
                return this;
            }

            /// <summary>
            /// Adds a WebSocket sub-protocol.
            /// </summary>
            public MediaWebSocketBuilder WithSubProtocol(string subProtocol)
            {
                _subProtocol = subProtocol;
                return this;
            }

            /// <summary>
            /// Builds, authenticates, and connects the WebSocket.
            /// Returns a <see cref="MediaWebSocketClient"/> wrapping the connected socket.
            /// </summary>
            public async Task<MediaWebSocketClient> BuildAndConnectAsync(CancellationToken cancellationToken = default)
            {
                if (_streamUrl == null)
                    throw new InvalidOperationException("Stream URL must be set. Call WithStreamUrl() before BuildAndConnectAsync().");

                var webSocket = new ClientWebSocket();

                try
                {
                    if (_keepAliveInterval.HasValue)
                        webSocket.Options.KeepAliveInterval = _keepAliveInterval.Value;

                    if (_receiveBufferSize.HasValue && _sendBufferSize.HasValue)
                        webSocket.Options.SetBuffer(_receiveBufferSize.Value, _sendBufferSize.Value);

                    if (!string.IsNullOrEmpty(_subProtocol))
                        webSocket.Options.AddSubProtocol(_subProtocol);

                    foreach (var header in _headers)
                    {
                        webSocket.Options.SetRequestHeader(header.Key, header.Value);
                    }

                    var authenticator = new AcsWebSocketAuthenticator(_client);
                    await authenticator.AuthenticateWebSocketAsync(webSocket, _streamUrl, cancellationToken).ConfigureAwait(false);

                    if (_connectTimeout.HasValue)
                    {
                        using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                        timeoutCts.CancelAfter(_connectTimeout.Value);
                        await webSocket.ConnectAsync(_streamUrl, timeoutCts.Token).ConfigureAwait(false);
                    }
                    else
                    {
                        await webSocket.ConnectAsync(_streamUrl, cancellationToken).ConfigureAwait(false);
                    }

                    return new MediaWebSocketClient(webSocket);
                }
                catch
                {
                    webSocket.Dispose();
                    throw;
                }
            }
        }
    }
}
