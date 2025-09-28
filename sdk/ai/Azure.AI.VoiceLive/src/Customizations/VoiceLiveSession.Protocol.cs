// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.VoiceLive
{
    public partial class VoiceLiveSession
    {
        /// <summary>
        /// Initializes an underlying <see cref="WebSocket"/> instance for communication with the VoiceLive service and
        /// then connects to the service using this socket.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <param name="headers">Added header to send.</param>
        /// <returns>A task that represents the asynchronous connection operation.</returns>
        protected internal virtual async Task ConnectAsync(IDictionary<string, string> headers, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            WebSocket?.Dispose();

            var clientWebSocket = new ClientWebSocket();

            try
            {
                foreach (var kvp in headers)
                {
                    var value = kvp.Value;
                    if (value != null)
                    {
                        clientWebSocket.Options.SetRequestHeader(kvp.Key, value);
                    }
                }

                if (_credential != null)
                {
                    // Add authorization header
                    string credentialValue = _credential.Key;
                    clientWebSocket.Options.SetRequestHeader("api-key", $"{credentialValue}");
                }
                else if (_tokenCredential != null)
                {
                    var tokenOptions = new TokenRequestContext(new string[] { "https://cognitiveservices.azure.com/.default" });

                    var token = await _tokenCredential.GetTokenAsync(tokenOptions, cancellationToken).ConfigureAwait(false);
                    clientWebSocket.Options.SetRequestHeader("Authorization", $"{token.TokenType} {token.Token}");
                }

                try
                {
                    clientWebSocket.Options.SetRequestHeader("User-Agent", "Azure-VoiceLive-SDK/.NET");
                }
                catch (System.ArgumentException)
                {
                    // On Net4.x you can't set the UserAgent for a websocket connection
                }

                await clientWebSocket.ConnectAsync(_endpoint, cancellationToken).ConfigureAwait(false);

                WebSocket = clientWebSocket;
            }
            catch
            {
                clientWebSocket?.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Initializes an underlying <see cref="WebSocket"/> instance for communication with the VoiceLive service and
        /// then connects to the service using this socket.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <param name="headers">Headers to send.</param>
        protected internal virtual void Connect(IDictionary<string, string> headers, CancellationToken cancellationToken = default)
        {
#pragma warning disable AZC0106
            ConnectAsync(headers, cancellationToken).EnsureCompleted();
#pragma warning restore AZC0106
        }

        /// <summary>
        /// Closes the WebSocket connection gracefully.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A task that represents the asynchronous close operation.</returns>
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            if (WebSocket != null && WebSocket.State == WebSocketState.Open)
            {
                try
                {
                    await WebSocket.CloseAsync(
                        WebSocketCloseStatus.NormalClosure,
                        "Client initiated close",
                        cancellationToken).ConfigureAwait(false);
                }
                catch (WebSocketException)
                {
                    // Ignore WebSocket exceptions during close
                }
            }
        }

        /// <summary>
        /// Closes the WebSocket connection gracefully.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual void Close(CancellationToken cancellationToken = default)
        {
#pragma warning disable AZC0107
            CloseAsync(cancellationToken).EnsureCompleted();
#pragma warning restore AZC0107
        }

        /// <summary>
        /// Gets the current state of the WebSocket connection.
        /// </summary>
        public WebSocketState ConnectionState => WebSocket?.State ?? WebSocketState.None;

        /// <summary>
        /// Gets a value indicating whether the session is connected and ready to send/receive messages.
        /// </summary>
        public bool IsConnected => WebSocket?.State == WebSocketState.Open;
    }
}
