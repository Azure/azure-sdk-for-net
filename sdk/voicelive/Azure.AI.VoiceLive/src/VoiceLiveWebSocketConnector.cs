// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
#if NETSTANDARD2_0
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
#endif

namespace Azure.AI.VoiceLive
{
    internal static class VoiceLiveWebSocketConnector
    {
        internal static async Task<WebSocket> ConnectAsync(
            Uri endpoint,
            IDictionary<string, string> headers,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            if (!endpoint.IsAbsoluteUri || (endpoint.Scheme != "ws" && endpoint.Scheme != "wss"))
            {
                throw new ArgumentException("The WebSocket endpoint must be an absolute ws or wss URI.", nameof(endpoint));
            }

            using var invoker = new HttpMessageInvoker(new HttpClientHandler
            {
                AllowAutoRedirect = false,
                UseCookies = false
            });

#if NETSTANDARD2_0
            return await ConnectLegacyAsync(endpoint, headers, invoker, cancellationToken).ConfigureAwait(false);
#else
            var webSocket = new ClientWebSocket();
            try
            {
                foreach (var header in headers)
                {
                    webSocket.Options.SetRequestHeader(header.Key, header.Value);
                }

                await webSocket.ConnectAsync(endpoint, invoker, cancellationToken).ConfigureAwait(false);
                return webSocket;
            }
            catch (Exception)
            {
                webSocket.Dispose();
                throw;
            }
#endif
        }

#if NETSTANDARD2_0
        private static async Task<WebSocket> ConnectLegacyAsync(
            Uri endpoint,
            IDictionary<string, string> headers,
            HttpMessageInvoker invoker,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using var optionsSocket = new ClientWebSocket();
            IDisposable response = null;
            CancellationTokenRegistration registration = default;
            try
            {
                Stream stream;
                if (RuntimeInformation.FrameworkDescription.StartsWith(".NET Framework", StringComparison.Ordinal))
                {
                    // ClientWebSocket registers the ws/wss factories that return a writable upgrade stream.
                    var request = (HttpWebRequest)WebRequest.Create(endpoint);
                    request.AllowAutoRedirect = false;
                    request.Proxy = optionsSocket.Options.Proxy;
                    foreach (var header in headers)
                    {
                        if (string.Equals(header.Key, "User-Agent", StringComparison.OrdinalIgnoreCase))
                        {
                            request.UserAgent = header.Value;
                        }
                        else if (string.Equals(header.Key, "Host", StringComparison.OrdinalIgnoreCase))
                        {
                            request.Host = header.Value;
                        }
                        else
                        {
                            request.Headers[header.Key] = header.Value;
                        }
                    }

                    registration = cancellationToken.Register(request.Abort);
                    var result = (HttpWebResponse)await request.GetResponseAsync().ConfigureAwait(false);
                    response = result;
                    cancellationToken.ThrowIfCancellationRequested();
                    ValidateResponse(result.StatusCode, request.Headers["Sec-WebSocket-Key"], name => result.Headers[name]);
                    stream = result.GetResponseStream();
                }
                else
                {
                    var requestUri = new UriBuilder(endpoint) { Scheme = endpoint.Scheme == "wss" ? "https" : "http" }.Uri;
                    using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
                    foreach (var header in headers)
                    {
                        if (!request.Headers.TryAddWithoutValidation(header.Key, header.Value))
                        {
                            throw new ArgumentException($"The header '{header.Key}' is not valid for a WebSocket handshake.", nameof(headers));
                        }
                    }

                    byte[] nonce = new byte[16];
                    using (var random = RandomNumberGenerator.Create())
                    {
                        random.GetBytes(nonce);
                    }
                    string key = Convert.ToBase64String(nonce);
                    request.Headers.Add("Connection", "Upgrade");
                    request.Headers.Add("Upgrade", "websocket");
                    request.Headers.Add("Sec-WebSocket-Version", "13");
                    request.Headers.Add("Sec-WebSocket-Key", key);

                    var result = await invoker.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    response = result;
                    cancellationToken.ThrowIfCancellationRequested();
                    ValidateResponse(result.StatusCode, key,
                        name => result.Headers.TryGetValues(name, out IEnumerable<string> values) ? string.Join(",", values) : null);
                    stream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
                }

                const int bufferSize = 16 * 1024;
                WebSocket webSocket = WebSocket.CreateClientWebSocket(
                    stream,
                    subProtocol: null,
                    receiveBufferSize: bufferSize,
                    sendBufferSize: bufferSize,
                    keepAliveInterval: optionsSocket.Options.KeepAliveInterval,
                    useZeroMaskingKey: false,
                    internalBuffer: WebSocket.CreateClientBuffer(bufferSize, bufferSize));
                response = null; // The WebSocket owns the upgraded response stream.
                return webSocket;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is WebException)
            {
                if (ex is WebException webException)
                {
                    webException.Response?.Dispose();
                }
                if (cancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException("The WebSocket connection was canceled.", ex, cancellationToken);
                }
                throw new WebSocketException("Unable to connect to the Voice Live service.", ex);
            }
            finally
            {
                registration.Dispose();
                response?.Dispose();
            }
        }

        private static void ValidateResponse(HttpStatusCode statusCode, string key, Func<string, string> getHeader)
        {
            if (statusCode != HttpStatusCode.SwitchingProtocols)
            {
                throw new WebSocketException(
                    $"The server returned status code '{(int)statusCode}' when status code '101' was expected. WebSocket redirects are not supported.");
            }

            if (!string.Equals(getHeader("Upgrade"), "websocket", StringComparison.OrdinalIgnoreCase)
                || !ContainsHeaderToken(getHeader("Connection"), "Upgrade"))
            {
                throw new WebSocketException("The server returned invalid WebSocket upgrade headers.");
            }

            string expectedAccept;
            // SHA-1 is required by the RFC 6455 handshake, not used to protect credentials.
            using (var hash = SHA1.Create())
            {
                expectedAccept = Convert.ToBase64String(hash.ComputeHash(
                    Encoding.ASCII.GetBytes(key + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11")));
            }

            if (!string.Equals(getHeader("Sec-WebSocket-Accept"), expectedAccept, StringComparison.Ordinal))
            {
                throw new WebSocketException("The server returned an invalid Sec-WebSocket-Accept header.");
            }

            if (!string.IsNullOrEmpty(getHeader("Sec-WebSocket-Protocol"))
                || !string.IsNullOrEmpty(getHeader("Sec-WebSocket-Extensions")))
            {
                throw new WebSocketException("The server returned an unrequested WebSocket subprotocol or extension.");
            }
        }

        private static bool ContainsHeaderToken(string header, string token)
        {
            if (header != null)
            {
                foreach (string value in header.Split(','))
                {
                    if (string.Equals(value.Trim(), token, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
#endif
    }
}
