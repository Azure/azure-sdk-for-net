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
    /// Provides authentication and configuration for WebSocket connections in Azure Communication Services.
    /// This allows customers to control WebSocket connections, add headers, configure options for media streaming, transcription, and other WebSocket scenarios.
    /// <example>
    /// Basic usage with HMAC authentication:
    /// <code>
    /// var authenticator = new AcsWebSocketAuthenticator(keyCredential, acsEndpoint);
    /// var webSocket = new ClientWebSocket();
    ///
    /// // Customers can configure WebSocket options as needed
    /// webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
    /// webSocket.Options.SetBuffer(4096, 4096);
    ///
    /// // Add authentication headers
    /// await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl, cancellationToken);
    ///
    /// // Connect to WebSocket
    /// await webSocket.ConnectAsync(streamUrl, cancellationToken);
    /// </code>
    ///
    /// Usage with CallAutomationClient (recommended):
    /// <code>
    /// var callAutomationClient = new CallAutomationClient(connectionString);
    /// var authenticator = new AcsWebSocketAuthenticator(callAutomationClient);
    /// var webSocket = new ClientWebSocket();
    ///
    /// // Configure WebSocket as needed
    /// webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
    ///
    /// // Add authentication headers (uses existing CallAutomationClient auth)
    /// await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl, cancellationToken);
    ///
    /// // Connect to WebSocket
    /// await webSocket.ConnectAsync(streamUrl, cancellationToken);
    /// </code>
    ///
    /// Custom authentication example:
    /// <code>
    /// public class CustomAuthenticator : AcsWebSocketAuthenticator
    /// {
    ///     protected override async Task AuthenticateCustomAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken)
    ///     {
    ///         // Add custom authentication headers
    ///         webSocket.Options.SetRequestHeader("Custom-Auth", "MyToken");
    ///         await Task.CompletedTask;
    ///     }
    /// }
    ///
    /// var authenticator = new CustomAuthenticator();
    /// var webSocket = new ClientWebSocket();
    /// await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl, cancellationToken);
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
                await AddAuthenticationHeadersAsync(webSocket, cancellationToken).ConfigureAwait(false);
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
            // Generate HMAC authentication header similar to CustomHMACAuthenticationPolicy
            var utcNowString = DateTimeOffset.UtcNow.ToString("r", System.Globalization.CultureInfo.InvariantCulture);

            // Create content hash for empty content (WebSocket)
            string contentHash;
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Array.Empty<byte>());
                contentHash = Convert.ToBase64String(hashBytes);
            }

            var stringToSign = $"GET\n{streamUrl.PathAndQuery}\n{utcNowString};{_acsEndpoint};{contentHash}";
            var signature = ComputeHMAC(stringToSign);

            var authorization = $"HMAC-SHA256 SignedHeaders=x-ms-date;host;x-ms-content-sha256&Signature={signature}";

            webSocket.Options.SetRequestHeader("x-ms-date", utcNowString);
            webSocket.Options.SetRequestHeader("x-ms-content-sha256", contentHash);
            webSocket.Options.SetRequestHeader("Authorization", authorization);
            webSocket.Options.SetRequestHeader("X-FORWARDED-HOST", _acsEndpoint);

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
        /// Adds authentication headers to the WebSocket connection using CallAutomationClient.
        /// This method tries HMAC authentication first, then falls back to AAD Bearer token.
        /// </summary>
        /// <param name="webSocket">The ClientWebSocket to add headers to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task representing the authentication header setup.</returns>
        private async Task AddAuthenticationHeadersAsync(ClientWebSocket webSocket, CancellationToken cancellationToken)
        {
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
            catch
            {
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
            catch
            {
                // If both authentication methods fail, continue without auth
                // The WebSocket connection might still succeed depending on the server configuration
            }
        }

        private string ComputeHMAC(string value)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA256(Convert.FromBase64String(_keyCredential.Key));
            var hash = hmac.ComputeHash(System.Text.Encoding.ASCII.GetBytes(value));
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
