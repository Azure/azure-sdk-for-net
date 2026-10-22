// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Telemetry;
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

            // Start the root connect span before the WebSocket handshake begins
            Activity connectActivity = _tracer?.StartConnectActivity();
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
                    var tokenOptions = new TokenRequestContext(new string[] { "https://ai.azure.com/.default" });

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

#if NET7_0_OR_GREATER
                // The opening WebSocket handshake carries the service credential (the "api-key" header or a
                // bearer "Authorization" header) plus any custom headers configured via VoiceLiveClientOptions.
                // ClientWebSocket's default ConnectAsync(Uri, CancellationToken) overload performs that handshake
                // using an HTTP handler that follows 3xx redirects transparently and forwards those headers to the
                // redirect target, even if it is a different host or port than the configured endpoint (for
                // example, an attacker-controlled or compromised proxy sitting in front of the service). Use the
                // ConnectAsync(Uri, HttpMessageInvoker, CancellationToken) overload with AllowAutoRedirect disabled
                // so a redirect response causes the handshake to fail instead of silently leaking credentials to
                // an unintended destination. The invoker is only used for the HTTP-level handshake request; it is
                // safe to dispose immediately afterwards since the resulting WebSocket does not depend on it.
                using (var handler = new System.Net.Http.SocketsHttpHandler { AllowAutoRedirect = false })
                using (var invoker = new System.Net.Http.HttpMessageInvoker(handler))
                {
                    await clientWebSocket.ConnectAsync(_endpoint, invoker, cancellationToken).ConfigureAwait(false);
                }
#else
                // NOTE (security): on netstandard2.0 (used by .NET Framework and other legacy targets),
                // ClientWebSocketOptions exposes no way to disable automatic redirect-following, and the
                // HttpMessageInvoker-based ConnectAsync overload used above to close this gap is unavailable on
                // this target framework. As a result, on netstandard2.0 the WebSocket handshake can still follow a
                // same- or cross-host/port redirect and forward the api-key/Authorization header (and any custom
                // headers) to the redirect target. There is no supported public API on this target to prevent
                // that. Consumers that need protection from this risk should target net8.0 or later. See the
                // package CHANGELOG and README for details.
                await clientWebSocket.ConnectAsync(_endpoint, cancellationToken).ConfigureAwait(false);
#endif

                WebSocket = clientWebSocket;

                // Log successful connection
                _contentLogger.LogConnectionOpened(_connectionId);
            }
            catch (Exception ex)
            {
                _contentLogger.LogError(_connectionId, ex);
                // Record the connect error on the span and end it — the session is unusable
                _tracer?.EndConnectActivity(ex);
                connectActivity = null; // prevent double-stop in finally
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
                Activity closeActivity = _tracer?.StartCloseActivity();
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
                    VoiceLiveTracer.RecordError(closeActivity, ex);
                    // Log close error and ignore WebSocket exceptions during close
                    _contentLogger.LogError(_connectionId, $"WebSocket close error: {ex.Message}");
                }
                finally
                {
                    closeActivity?.Stop();
                }
            }

            // End the root connect span, recording all session-level counters
            _tracer?.EndConnectActivity();
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
