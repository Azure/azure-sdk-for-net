// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

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

                _contentLogger.LogConnectionOpening(_connectionId, $"{_endpoint}");

                await clientWebSocket.ConnectAsync(_endpoint, cancellationToken).ConfigureAwait(false);

                WebSocket = clientWebSocket;

                // Log successful connection
                _contentLogger.LogConnectionOpened(_connectionId);
            }
            catch (Exception ex)
            {
                _contentLogger.LogError(_connectionId, ex);
                clientWebSocket?.Dispose();
                throw;
            }
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
                    var closeCode = WebSocketCloseStatus.NormalClosure;
                    var reason = "Client initiated close";

                    // Log successful close
                    _contentLogger.LogConnectionClosing(_connectionId, (int)closeCode, reason);

                    await WebSocket.CloseAsync(
                        closeCode,
                        reason,
                        cancellationToken).ConfigureAwait(false);

                    _contentLogger.LogConnectionClosed(_connectionId);
                }
                catch (WebSocketException ex)
                {
                    // Log close error and ignore WebSocket exceptions during close
                    _contentLogger.LogError(_connectionId, $"WebSocket close error: {ex.Message}");
                }
            }
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
