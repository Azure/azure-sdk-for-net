// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net.Http;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    /// <summary>
    /// HTTP message handler that redirects all requests to a Kubernetes token proxy.
    /// Handles custom CA certificates and monitors CA file changes for automatic reloading.
    /// </summary>
    [UnsupportedOSPlatform("browser")]
    internal class KubernetesProxyHttpHandler : HttpMessageHandler
    {
        private readonly KubernetesProxyConfig _config;
        private byte[] _lastCaData;
        private readonly object _lock = new object();
        private HttpPipeline _pipeline;
        private HandlerState _handler;
        private bool _disposed;

        internal HttpMessageHandler InnerHandler => Volatile.Read(ref _handler).Handler;

        public KubernetesProxyHttpHandler(KubernetesProxyConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));

            _lastCaData = GetCaCertificateData();
            _handler = CreateHandler(_lastCaData);
            if (_config.Transport != null)
            {
                // Use mock transport for testing
                _pipeline = new HttpPipeline(_config.Transport);
            }
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HandlerState handler;
            HandlerState handlerToDispose = null;
            lock (_lock)
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(KubernetesProxyHttpHandler));
                }

                if (!string.IsNullOrEmpty(_config.CaFilePath))
                {
                    byte[] caData = GetCaCertificateData();
                    if (ShouldReloadHandler(caData))
                    {
                        HandlerState replacement = CreateHandler(caData);
                        if (RetireHandler(_handler))
                        {
                            handlerToDispose = _handler;
                        }
                        _handler = replacement;
                        _lastCaData = caData;
                        AzureIdentityEventSource.Singleton.KubernetesProxyCaCertificateReloaded();
                    }
                }

                handler = _handler;
                handler.OutstandingRequests++;
            }

            try
            {
                handlerToDispose?.Dispose();
                RewriteRequestUrl(request);

                if (_pipeline != null)
                {
                    return await SendMockRequest(request, cancellationToken).ConfigureAwait(false);
                }

                return await handler.Invoker.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                bool shouldDispose;
                lock (_lock)
                {
                    handler.OutstandingRequests--;
                    shouldDispose = handler.Retired && handler.OutstandingRequests == 0;
                }

                if (shouldDispose)
                {
                    handler.Dispose();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                HandlerState handlerToDispose = null;
                lock (_lock)
                {
                    if (!_disposed)
                    {
                        _disposed = true;
                        if (RetireHandler(_handler))
                        {
                            handlerToDispose = _handler;
                        }
                    }
                }

                handlerToDispose?.Dispose();
            }

            base.Dispose(disposing);
        }

        private static bool RetireHandler(HandlerState handler)
        {
            handler.Retired = true;
            return handler.OutstandingRequests == 0;
        }

        private async Task<HttpResponseMessage> SendMockRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Request pipelineRequest = _pipeline.CreateRequest();

            pipelineRequest.Method = new RequestMethod(request.Method.Method);
            pipelineRequest.Uri.Reset(request.RequestUri);

            // Copy headers from HttpRequestMessage to Request
            foreach (var header in request.Headers)
            {
                foreach (var value in header.Value)
                {
                    pipelineRequest.Headers.Add(header.Key, value);
                }
            }

            // Copy content if present
            if (request.Content != null)
            {
                foreach (var contentHeader in request.Content.Headers)
                {
                    foreach (var value in contentHeader.Value)
                    {
                        pipelineRequest.Headers.Add(contentHeader.Key, value);
                    }
                }
                var contentStream = await request.Content.ReadAsStreamAsync().ConfigureAwait(false);
                pipelineRequest.Content = RequestContent.Create(contentStream);
            }

            Response pipelineResponse = await _pipeline.SendRequestAsync(pipelineRequest, cancellationToken).ConfigureAwait(false);

            // Convert Response back to HttpResponseMessage
            var response = new HttpResponseMessage((System.Net.HttpStatusCode)pipelineResponse.Status);
            response.ReasonPhrase = pipelineResponse.ReasonPhrase;

            // Copy response content
            if (pipelineResponse.ContentStream != null)
            {
                response.Content = new StreamContent(pipelineResponse.ContentStream);
            }

            // Copy response headers
            foreach (var header in pipelineResponse.Headers)
            {
                if (pipelineResponse.Headers.TryGetValues(header.Name, out var values))
                {
                    if (!response.Headers.TryAddWithoutValidation(header.Name, values))
                    {
                        response.Content?.Headers.TryAddWithoutValidation(header.Name, values);
                    }
                }
            }

            return response;
        }

        private void RewriteRequestUrl(HttpRequestMessage request)
        {
            if (request.RequestUri == null)
            {
                throw new InvalidOperationException("Request URI is null.");
            }

            string pathAndQuery = request.RequestUri.PathAndQuery;
            UriBuilder newUri = new UriBuilder(_config.ProxyUrl);

            string proxyPath = newUri.Path.TrimEnd('/');
            string requestPath = pathAndQuery.TrimStart('/');

            string combinedPath;
            if (string.IsNullOrEmpty(proxyPath) || proxyPath == "/")
            {
                combinedPath = "/" + requestPath;
            }
            else
            {
                combinedPath = proxyPath + "/" + requestPath;
            }

            // Build URI string directly to avoid UriBuilder.Path escaping
            string uriString = $"{newUri.Scheme}://{newUri.Host}:{newUri.Port}{combinedPath}";
            request.RequestUri = new Uri(uriString);
            request.Headers.Host = _config.SniName;
        }

        private bool ShouldReloadHandler(byte[] currentCaData)
        {
            // Keep using current handler during rotation gaps (empty or missing file)
            if (currentCaData == null || currentCaData.Length == 0)
            {
                AzureIdentityEventSource.Singleton.KubernetesProxyCaCertificateReloadSkipped("CA certificate file is empty or missing");
                return false;
            }

            if (_lastCaData == null || !currentCaData.AsSpan().SequenceEqual(_lastCaData))
            {
                return true;
            }

            return false;
        }

        private byte[] GetCaCertificateData()
        {
            try
            {
                string caContent = _config.GetCaCertificateContent();
                if (string.IsNullOrEmpty(caContent))
                {
                    return null;
                }

                return System.Text.Encoding.UTF8.GetBytes(caContent);
            }
            catch (Exception ex)
            {
                AzureIdentityEventSource.Singleton.KubernetesProxyCaCertificateReloadFailed(ex.Message);
                return null;
            }
        }

        private HandlerState CreateHandler(byte[] caData)
        {
            var handler = new HttpClientHandler();
            X509Certificate2 caCertificate = null;

            try
            {
                if (caData != null && caData.Length > 0)
                {
                    caCertificate = ConfigureCustomCertificates(handler, caData);
                }

                return new HandlerState(handler, caCertificate);
            }
            catch
            {
                caCertificate?.Dispose();
                handler.Dispose();
                throw;
            }
        }

        private X509Certificate2 ConfigureCustomCertificates(HttpClientHandler handler, byte[] caData)
        {
            try
            {
                string pemContent = System.Text.Encoding.UTF8.GetString(caData);
                X509Certificate2 caCertificate = PemReader.LoadCertificate(pemContent.AsSpan(), allowCertificateOnly: true);
                string caThumbprint = caCertificate.Thumbprint;

                handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                {
                    // Return false if certificate is null
                    if (cert == null)
                    {
                        return false;
                    }

                    // Check for SSL policy errors that we cannot handle with custom validation
                    if (errors != System.Net.Security.SslPolicyErrors.None &&
                        errors != System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors)
                    {
                        return false;
                    }

                    // Create a new X509Chain for custom validation instead of reusing the one
                    // passed from SSL validation. On Linux with OpenSSL, the passed-in chain
                    // is already in a partially built state and calling Build() on it again
                    // causes a NullReferenceException in OpenSslX509ChainProcessor.FindFirstChain.
                    using (var customChain = new X509Chain())
                    {
                        // Configure chain to trust our custom CA
                        customChain.ChainPolicy.ExtraStore.Add(caCertificate);
                        customChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                        customChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

                        if (!customChain.Build(cert))
                        {
                            return false;
                        }

                        // Verify the root certificate matches our custom CA
                        if (customChain.ChainElements.Count > 0)
                        {
                            var rootCert = customChain.ChainElements[customChain.ChainElements.Count - 1].Certificate;
                            if (rootCert.Thumbprint.Equals(caThumbprint, StringComparison.OrdinalIgnoreCase))
                            {
                                return true;
                            }
                        }

                        return false;
                    }
                };

                return caCertificate;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Failed to configure custom CA certificate for Kubernetes token proxy.", ex);
            }
        }

        private sealed class HandlerState : IDisposable
        {
            private readonly X509Certificate2 _caCertificate;

            public HttpClientHandler Handler { get; }
            public HttpMessageInvoker Invoker { get; }
            public int OutstandingRequests { get; set; }
            public bool Retired { get; set; }

            public HandlerState(HttpClientHandler handler, X509Certificate2 caCertificate)
            {
                Handler = handler;
                Invoker = new HttpMessageInvoker(handler);
                _caCertificate = caCertificate;
            }

            public void Dispose()
            {
                Invoker.Dispose();
                _caCertificate?.Dispose();
            }
        }
    }
}
