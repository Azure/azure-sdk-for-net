// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Provides authentication for WebSocket connections to Azure Communication Services
    /// media streaming and transcription endpoints.
    /// <para>
    /// Sets required headers (X-Ms-Host, Authorization, date, x-ms-content-sha256) on a
    /// <see cref="ClientWebSocket"/> before the customer calls <c>ConnectAsync</c>.
    /// Supports HMAC (connection string / access key) and AAD (TokenCredential) authentication.
    /// </para>
    /// <example>
    /// Recommended usage with CallAutomationClient:
    /// <code>
    /// var client = new CallAutomationClient(connectionString);
    /// var authenticator = client.GetWebSocketAuthenticator();
    /// var webSocket = new ClientWebSocket();
    ///
    /// webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
    /// await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
    /// await webSocket.ConnectAsync(streamUrl, cancellationToken);
    /// </code>
    /// </example>
    /// </summary>
    public class AcsWebSocketAuthenticator
    {
        private readonly AzureKeyCredential _keyCredential;
        private readonly TokenCredential _tokenCredential;
        private readonly string _acsEndpoint;
        private readonly CallAutomationClient _callAutomationClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AcsWebSocketAuthenticator"/> class with an Azure Key Credential.
        /// </summary>
        /// <param name="keyCredential">The Azure Key Credential for HMAC authentication.</param>
        /// <param name="acsEndpoint">The Azure Communication Services endpoint.</param>
        /// <exception cref="ArgumentNullException">Thrown when keyCredential or acsEndpoint is null.</exception>
        public AcsWebSocketAuthenticator(AzureKeyCredential keyCredential, string acsEndpoint)
        {
            _keyCredential = keyCredential ?? throw new ArgumentNullException(nameof(keyCredential));
            _acsEndpoint = acsEndpoint ?? throw new ArgumentNullException(nameof(acsEndpoint));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AcsWebSocketAuthenticator"/> class with a Token Credential.
        /// </summary>
        /// <param name="tokenCredential">The Token Credential for Azure AD authentication.</param>
        /// <param name="acsEndpoint">The Azure Communication Services endpoint.</param>
        /// <exception cref="ArgumentNullException">Thrown when tokenCredential or acsEndpoint is null.</exception>
        public AcsWebSocketAuthenticator(TokenCredential tokenCredential, string acsEndpoint)
        {
            _tokenCredential = tokenCredential ?? throw new ArgumentNullException(nameof(tokenCredential));
            _acsEndpoint = acsEndpoint ?? throw new ArgumentNullException(nameof(acsEndpoint));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AcsWebSocketAuthenticator"/> class with a CallAutomationClient.
        /// This constructor allows the authenticator to use the existing authentication from the CallAutomationClient,
        /// trying HMAC authentication first, then falling back to AAD Bearer token.
        /// </summary>
        /// <param name="callAutomationClient">The CallAutomationClient to get authentication from.</param>
        /// <exception cref="ArgumentNullException">Thrown when callAutomationClient is null.</exception>
        public AcsWebSocketAuthenticator(CallAutomationClient callAutomationClient)
        {
            _callAutomationClient = callAutomationClient ?? throw new ArgumentNullException(nameof(callAutomationClient));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AcsWebSocketAuthenticator"/> class for custom authentication scenarios.
        /// </summary>
        public AcsWebSocketAuthenticator()
        {
        }

        /// <summary>
        /// Authenticates and configures a WebSocket connection for Azure Communication Services.
        /// This method allows customers to add authentication headers and configure WebSocket options.
        /// </summary>
        /// <param name="webSocket">The ClientWebSocket instance to authenticate and configure.</param>
        /// <param name="streamUrl">The WebSocket stream URL to connect to.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous authentication operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when webSocket or streamUrl is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no authentication method is configured.</exception>
        public async Task AuthenticateWebSocketAsync(
            ClientWebSocket webSocket,
            Uri streamUrl,
            CancellationToken cancellationToken = default)
        {
            if (webSocket == null)
                throw new ArgumentNullException(nameof(webSocket));
            if (streamUrl == null)
                throw new ArgumentNullException(nameof(streamUrl));

            // Add common headers
            webSocket.Options.SetRequestHeader("User-Agent", GetUserAgent());

            if (_callAutomationClient != null)
            {
                await AuthenticateFromClientAsync(webSocket, streamUrl, cancellationToken).ConfigureAwait(false);
            }
            else if (_keyCredential != null && _acsEndpoint != null)
            {
                await AuthenticateWithHMACAsync(webSocket, streamUrl, cancellationToken).ConfigureAwait(false);
            }
            else if (_tokenCredential != null && _acsEndpoint != null)
            {
                await AuthenticateWithTokenAsync(webSocket, streamUrl, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                // Allow custom authentication - customer can override this method or add their own headers
                await AuthenticateCustomAsync(webSocket, streamUrl, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides a method for customers to implement custom authentication logic.
        /// Override this method to implement custom authentication scenarios.
        /// </summary>
        /// <param name="webSocket">The ClientWebSocket instance to authenticate.</param>
        /// <param name="streamUrl">The WebSocket stream URL.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous custom authentication operation.</returns>
        protected virtual Task AuthenticateCustomAsync(
            ClientWebSocket webSocket,
            Uri streamUrl,
            CancellationToken cancellationToken = default)
        {
            // Default implementation does nothing - customers can override for custom authentication
            return Task.CompletedTask;
        }

        /// <summary>
        /// Adds a custom header to the WebSocket request.
        /// This method can be used to add additional headers before establishing the WebSocket connection.
        /// </summary>
        /// <param name="webSocket">The ClientWebSocket instance.</param>
        /// <param name="headerName">The name of the header to add.</param>
        /// <param name="headerValue">The value of the header to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when headerName is empty.</exception>
        public void AddCustomHeader(ClientWebSocket webSocket, string headerName, string headerValue)
        {
            if (webSocket == null)
                throw new ArgumentNullException(nameof(webSocket));
            if (string.IsNullOrEmpty(headerName))
                throw new ArgumentException("Header name cannot be null or empty.", nameof(headerName));
            if (headerValue == null)
                throw new ArgumentNullException(nameof(headerValue));

            webSocket.Options.SetRequestHeader(headerName, headerValue);
        }

        /// <summary>
        /// Configures WebSocket options such as keep-alive interval, buffer sizes, and subprotocols.
        /// </summary>
        /// <param name="webSocket">The ClientWebSocket instance to configure.</param>
        /// <param name="keepAliveInterval">The WebSocket keep-alive interval.</param>
        /// <param name="receiveBufferSize">The receive buffer size in bytes.</param>
        /// <param name="sendBufferSize">The send buffer size in bytes.</param>
        /// <param name="subProtocol">Optional subprotocol to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when webSocket is null.</exception>
        public void ConfigureWebSocketOptions(
            ClientWebSocket webSocket,
            TimeSpan? keepAliveInterval = null,
            int? receiveBufferSize = null,
            int? sendBufferSize = null,
            string subProtocol = null)
        {
            if (webSocket == null)
                throw new ArgumentNullException(nameof(webSocket));

            if (keepAliveInterval.HasValue)
            {
                webSocket.Options.KeepAliveInterval = keepAliveInterval.Value;
            }

            if (receiveBufferSize.HasValue && receiveBufferSize.Value > 0)
            {
                webSocket.Options.SetBuffer(receiveBufferSize.Value, receiveBufferSize.Value);
            }
            else if (sendBufferSize.HasValue && sendBufferSize.Value > 0)
            {
                webSocket.Options.SetBuffer(receiveBufferSize ?? 4096, sendBufferSize.Value);
            }

            if (!string.IsNullOrEmpty(subProtocol))
            {
                webSocket.Options.AddSubProtocol(subProtocol);
            }
        }

        private async Task AuthenticateWithHMACAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken)
        {
            var date = DateTimeOffset.UtcNow.ToString("r", System.Globalization.CultureInfo.InvariantCulture);

            // Create content hash for empty content (WebSocket upgrade has no body)
            string contentHash;
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(string.Empty));
                contentHash = Convert.ToBase64String(hashBytes);
            }

            // The host used for signing must be the ACS resource endpoint authority
            var acsHost = new Uri(_acsEndpoint).Authority;
            var pathAndQuery = streamUrl.PathAndQuery;

            const string signedHeaders = "date;host;x-ms-content-sha256";
            var stringToSign = $"GET\n{pathAndQuery}\n{date};{acsHost};{contentHash}";
            var signature = ComputeHMAC(stringToSign);

            var authorization = $"HMAC-SHA256 SignedHeaders={signedHeaders}&Signature={signature}";

            webSocket.Options.SetRequestHeader("X-Ms-Host", acsHost);
            webSocket.Options.SetRequestHeader("date", date);
            webSocket.Options.SetRequestHeader("x-ms-content-sha256", contentHash);
            webSocket.Options.SetRequestHeader("Authorization", authorization);

            await Task.CompletedTask.ConfigureAwait(false);
        }

        private async Task AuthenticateWithTokenAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken)
        {
            // Get access token for Azure Communication Services
            var tokenRequestContext = new TokenRequestContext(new[] { "https://communication.azure.com/.default" });
            var accessToken = await _tokenCredential.GetTokenAsync(tokenRequestContext, cancellationToken).ConfigureAwait(false);

            webSocket.Options.SetRequestHeader("Authorization", $"Bearer {accessToken.Token}");
        }

        /// <summary>
        /// Authenticates WebSocket using credentials from the CallAutomationClient.
        /// Uses HMAC if a key credential is available, otherwise falls back to AAD token.
        /// </summary>
        private async Task AuthenticateFromClientAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken)
        {
            var client = _callAutomationClient;

            // Determine the ACS host - prefer explicit ACS endpoint, fallback to resource endpoint
            var acsHost = !string.IsNullOrEmpty(client._acsEndpoint)
                ? new Uri(client._acsEndpoint).Authority
                : new Uri(client._resourceEndpoint).Authority;

            // Always set X-Ms-Host for routing
            webSocket.Options.SetRequestHeader("X-Ms-Host", acsHost);

            if (client._keyCredential != null)
            {
                // Use HMAC with the client's key credential and resource endpoint
                var date = DateTimeOffset.UtcNow.ToString("r", System.Globalization.CultureInfo.InvariantCulture);

                string contentHash;
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    var hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(string.Empty));
                    contentHash = Convert.ToBase64String(hashBytes);
                }

                var pathAndQuery = streamUrl.PathAndQuery;

                const string signedHeaders = "date;host;x-ms-content-sha256";
                var stringToSign = $"GET\n{pathAndQuery}\n{date};{acsHost};{contentHash}";

                using var hmac = new System.Security.Cryptography.HMACSHA256(Convert.FromBase64String(client._keyCredential.Key));
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToSign));
                var signature = Convert.ToBase64String(hash);

                var authorization = $"HMAC-SHA256 SignedHeaders={signedHeaders}&Signature={signature}";

                webSocket.Options.SetRequestHeader("date", date);
                webSocket.Options.SetRequestHeader("x-ms-content-sha256", contentHash);
                webSocket.Options.SetRequestHeader("Authorization", authorization);
            }
            else if (client._tokenCredential != null)
            {
                var tokenRequestContext = new TokenRequestContext(new[] { "https://communication.azure.com/.default" });
                var accessToken = await client._tokenCredential.GetTokenAsync(tokenRequestContext, cancellationToken).ConfigureAwait(false);
                webSocket.Options.SetRequestHeader("Authorization", $"Bearer {accessToken.Token}");
            }
            else
            {
                throw new InvalidOperationException("CallAutomationClient does not have accessible credentials for WebSocket authentication. Use AcsWebSocketAuthenticator with explicit credentials instead.");
            }
        }

        private string ComputeHMAC(string value)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA256(Convert.FromBase64String(_keyCredential.Key));
            var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
            return Convert.ToBase64String(hash);
        }

        private static string GetUserAgent()
        {
            // Get the current assembly version for User-Agent header
            var assembly = typeof(AcsWebSocketAuthenticator).Assembly;
            var version = assembly.GetName().Version?.ToString() ?? "1.0.0";
            return $"Azure-Communication-CallAutomation/{version}";
        }
    }
}
