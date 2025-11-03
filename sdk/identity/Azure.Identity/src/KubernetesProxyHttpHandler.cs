// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
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
    internal class KubernetesProxyHttpHandler : DelegatingHandler
    {
        private readonly KubernetesProxyConfig _config;
        private byte[] _lastCaData;
        private readonly object _lock = new object();
        private HttpPipeline _pipeline;

        public KubernetesProxyHttpHandler(KubernetesProxyConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));

            InnerHandler = CreateHandler();
            if (_config.Transport != null)
            {
                // Use mock transport for testing
                _pipeline = new HttpPipeline(_config.Transport);
            }
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using (((DisposingHttpClientHandler)InnerHandler).StartSend())
            {
                // Reload handler if CA certificate file has changed
                if (ShouldReloadHandler())
                {
                    lock (_lock)
                    {
                        if (ShouldReloadHandler())
                        {
                            var oldHandler = InnerHandler as DisposingHttpClientHandler;
                            InnerHandler = CreateHandler();

                            // Dispose old handler after in-flight requests complete
                            Task.Run(async () =>
                            {
                                await oldHandler.WaitForOutstandingRequests().ConfigureAwait(false);
                                oldHandler.Dispose();
                            });
                        }
                    }
                }

                RewriteRequestUrl(request);

                if (_pipeline != null)
                {
                    return await SendMockRequest(request, cancellationToken).ConfigureAwait(false);
                }

                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
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

        private bool ShouldReloadHandler()
        {
            byte[] currentCaData = GetCaCertificateData();

            // Keep using current handler during rotation gaps (empty or missing file)
            if (currentCaData == null || currentCaData.Length == 0)
            {
                return false;
            }

            if (_lastCaData == null || !AreByteArraysEqual(currentCaData, _lastCaData))
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
            catch
            {
                return null;
            }
        }

        private static bool AreByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null)
                return true;
            if (a == null || b == null)
                return false;
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }

        private DisposingHttpClientHandler CreateHandler()
        {
            var handler = new DisposingHttpClientHandler();

            byte[] caData = GetCaCertificateData();
            _lastCaData = caData;

            // Configure TLS/SSL settings if custom CA is provided
            if (caData != null && caData.Length > 0)
            {
                ConfigureCustomCertificates(handler, caData);
            }

            return handler;
        }

        private void ConfigureCustomCertificates(HttpClientHandler handler, byte[] caData)
        {
            try
            {
                string pemContent = System.Text.Encoding.UTF8.GetString(caData);
                X509Certificate2 caCertificate = PemReader.LoadCertificate(pemContent.AsSpan(), keyType: PemReader.KeyType.RSA);

                handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                {
                    if (errors == System.Net.Security.SslPolicyErrors.None)
                    {
                        return true;
                    }

                    chain.ChainPolicy.ExtraStore.Add(caCertificate);
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

                    if (!chain.Build(cert))
                    {
                        return false;
                    }

                    // Verify the root certificate matches our custom CA
                    if (chain.ChainElements.Count > 0)
                    {
                        var rootCert = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
                        if (rootCert.Thumbprint.Equals(caCertificate.Thumbprint, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }

                    return false;
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Failed to configure custom CA certificate for Kubernetes token proxy.", ex);
            }
        }
    }
}
