// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Helper class for establishing WebSocket connections to Azure Communication Services.
    /// Provides separate methods for media streaming (with authentication) and transcription (without authentication).
    /// </summary>
    public class WebSocketConnectionHelper : IDisposable
    {
        private readonly CallAutomationClient _callAutomationClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of WebSocketConnectionHelper.
        /// </summary>
        /// <param name="callAutomationClient">The call automation client for authentication.</param>
        /// <param name="clientDiagnostics">Client diagnostics for logging.</param>
        internal WebSocketConnectionHelper(CallAutomationClient callAutomationClient, ClientDiagnostics clientDiagnostics)
        {
            _callAutomationClient = callAutomationClient ?? throw new ArgumentNullException(nameof(callAutomationClient));
            _clientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
        }

        /// <summary>
        /// Throws an ObjectDisposedException if the helper has been disposed.
        /// </summary>
        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(WebSocketConnectionHelper));
            }
        }

        /// <summary>
        /// Connects to Azure Communication Services media streaming WebSocket with authentication headers.
        /// This method automatically adds HMAC or Bearer token authentication headers before establishing the connection.
        /// </summary>
        /// <param name="transportUri">The WebSocket transport URI for media streaming.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A connected ClientWebSocket ready for media streaming operations.</returns>
        /// <exception cref="ArgumentNullException">Thrown when transportUri is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when WebSocket connection fails.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the helper has been disposed.</exception>
        public async Task<ClientWebSocket> ConnectToAcsMediaStreamingWebsocketAsync(Uri transportUri, CancellationToken cancellationToken = default)
        {
            if (transportUri == null)
                throw new ArgumentNullException(nameof(transportUri));

            ThrowIfDisposed();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(WebSocketConnectionHelper)}.{nameof(ConnectToAcsMediaStreamingWebsocketAsync)}");
            scope.Start();

            try
            {
                var webSocket = new ClientWebSocket();

                // Configure WebSocket for media streaming
                ConfigureMediaStreamingWebSocket(webSocket);

                // Add authentication headers before connecting
                await AddAuthenticationHeadersAsync(webSocket, cancellationToken).ConfigureAwait(false);

                // Connect to the WebSocket
                await webSocket.ConnectAsync(transportUri, cancellationToken).ConfigureAwait(false);

                return webSocket;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Connects to Azure Communication Services media streaming WebSocket with authentication headers. Synchronous version.
        /// This method automatically adds HMAC or Bearer token authentication headers before establishing the connection.
        /// </summary>
        /// <param name="transportUri">The WebSocket transport URI for media streaming.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A connected ClientWebSocket ready for media streaming operations.</returns>
        /// <exception cref="ArgumentNullException">Thrown when transportUri is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when WebSocket connection fails.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the helper has been disposed.</exception>
        public ClientWebSocket ConnectToAcsMediaStreamingWebsocket(Uri transportUri, CancellationToken cancellationToken = default)
        {
            if (transportUri == null)
                throw new ArgumentNullException(nameof(transportUri));

            ThrowIfDisposed();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(WebSocketConnectionHelper)}.{nameof(ConnectToAcsMediaStreamingWebsocket)}");
            scope.Start();

            try
            {
#pragma warning disable AZC0107 // Do not call public asynchronous method in synchronous scope.
                return ConnectToAcsMediaStreamingWebsocketAsync(transportUri, cancellationToken).EnsureCompleted();
#pragma warning restore AZC0107 // Do not call public asynchronous method in synchronous scope.
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Connects to Azure Communication Services transcription WebSocket without authentication headers.
        /// This method establishes a WebSocket connection for transcription services without adding authentication headers.
        /// </summary>
        /// <param name="transportUri">The WebSocket transport URI for transcription.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A connected ClientWebSocket ready for transcription operations.</returns>
        /// <exception cref="ArgumentNullException">Thrown when transportUri is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when WebSocket connection fails.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the helper has been disposed.</exception>
        public async Task<ClientWebSocket> ConnectToAcsTranscriptionWebsocketAsync(Uri transportUri, CancellationToken cancellationToken = default)
        {
            if (transportUri == null)
                throw new ArgumentNullException(nameof(transportUri));

            ThrowIfDisposed();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(WebSocketConnectionHelper)}.{nameof(ConnectToAcsTranscriptionWebsocketAsync)}");
            scope.Start();

            try
            {
                var webSocket = new ClientWebSocket();

                // Configure WebSocket for transcription (no authentication headers)
                ConfigureTranscriptionWebSocket(webSocket);

                // Connect to the WebSocket without authentication
                await webSocket.ConnectAsync(transportUri, cancellationToken).ConfigureAwait(false);

                return webSocket;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Connects to Azure Communication Services transcription WebSocket without authentication headers. Synchronous version.
        /// This method establishes a WebSocket connection for transcription services without adding authentication headers.
        /// </summary>
        /// <param name="transportUri">The WebSocket transport URI for transcription.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A connected ClientWebSocket ready for transcription operations.</returns>
        /// <exception cref="ArgumentNullException">Thrown when transportUri is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when WebSocket connection fails.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the helper has been disposed.</exception>
        public ClientWebSocket ConnectToAcsTranscriptionWebsocket(Uri transportUri, CancellationToken cancellationToken = default)
        {
            if (transportUri == null)
                throw new ArgumentNullException(nameof(transportUri));

            ThrowIfDisposed();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(WebSocketConnectionHelper)}.{nameof(ConnectToAcsTranscriptionWebsocket)}");
            scope.Start();

            try
            {
#pragma warning disable AZC0107 // Do not call public asynchronous method in synchronous scope.
                return ConnectToAcsTranscriptionWebsocketAsync(transportUri, cancellationToken).EnsureCompleted();
#pragma warning restore AZC0107 // Do not call public asynchronous method in synchronous scope.
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Configures the WebSocket for media streaming with appropriate options.
        /// </summary>
        /// <param name="webSocket">The ClientWebSocket to configure.</param>
        private void ConfigureMediaStreamingWebSocket(ClientWebSocket webSocket)
        {
            ThrowIfDisposed();

            // Configure keep-alive for media streaming
            webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
        }

        /// <summary>
        /// Configures the WebSocket for transcription with appropriate options.
        /// </summary>
        /// <param name="webSocket">The ClientWebSocket to configure.</param>
        private void ConfigureTranscriptionWebSocket(ClientWebSocket webSocket)
        {
            ThrowIfDisposed();

            // Configure keep-alive for transcription
            webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
        }

        /// <summary>
        /// Adds authentication headers to the WebSocket connection for media streaming.
        /// This method tries HMAC authentication first, then falls back to AAD Bearer token.
        /// </summary>
        /// <param name="webSocket">The ClientWebSocket to add headers to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task representing the authentication header setup.</returns>
        private async Task AddAuthenticationHeadersAsync(ClientWebSocket webSocket, CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(WebSocketConnectionHelper)}.{nameof(AddAuthenticationHeadersAsync)}");
            scope.Start();

            try
            {
                // Try to get current HMAC token info first
                var hmacTokenResponse = await _callAutomationClient.GetCurrentHmacTokenDirectAsync(cancellationToken).ConfigureAwait(false);

                if (hmacTokenResponse?.Value?.HasValidHmacInfo == true)
                {
                    var hmacHeaders = hmacTokenResponse.Value.ToWebSocketHeaders();
                    if (hmacHeaders != null)
                    {
                        foreach (var header in hmacHeaders)
                        {
                            webSocket.Options.SetRequestHeader(header.Key, header.Value);
                        }
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                // If HMAC fails, try AAD token
            }

            try
            {
                // Try to get current AAD token as fallback
                var aadTokenResponse = await _callAutomationClient.GetCurrentAadTokenDirectAsync(cancellationToken).ConfigureAwait(false);

                if (!string.IsNullOrEmpty(aadTokenResponse?.Value))
                {
                    webSocket.Options.SetRequestHeader("Authorization", $"Bearer {aadTokenResponse.Value}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                // If both authentication methods fail, log and continue without auth
                // The WebSocket connection might still succeed depending on the server configuration
            }
        }

        #region IDisposable Implementation

        /// <summary>
        /// Releases the unmanaged resources and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Note: We don't dispose _callAutomationClient or _clientDiagnostics as they are not owned by this class
                    // They are passed in from the CallAutomationClient and should be managed by the caller
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
