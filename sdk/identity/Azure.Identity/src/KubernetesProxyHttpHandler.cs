// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// HTTP message handler that redirects all requests to a Kubernetes token proxy.
    /// Handles custom CA certificates and monitors CA file changes for automatic reloading.
    /// </summary>
    internal class KubernetesProxyHttpHandler : DelegatingHandler
    {
        private readonly KubernetesProxyConfig _config;
        private HttpClientHandler _innerHandler;
        private byte[] _lastCaData;
        private readonly object _lock = new object();
        private SemaphoreSlim _requestSemaphore;
        private int _requestCount;

        public KubernetesProxyHttpHandler(KubernetesProxyConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));

            // Create the initial handler
            _innerHandler = CreateHandler();
            InnerHandler = _innerHandler;
            _requestSemaphore = new SemaphoreSlim(1, 1);
            _requestCount = 0;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Increment request count to track in-flight requests
            Interlocked.Increment(ref _requestCount);

            try
            {
                // Check if we need to reload the CA file and recreate the handler
                if (ShouldReloadHandler())
                {
                    lock (_lock)
                    {
                        if (ShouldReloadHandler())
                        {
                            var oldHandler = _innerHandler;
                            var oldSemaphore = _requestSemaphore;

                            _innerHandler = CreateHandler();
                            InnerHandler = _innerHandler;
                            _requestSemaphore = new SemaphoreSlim(1, 1);

                            // Dispose old handler deterministically after all in-flight requests complete
                            Task.Run(async () =>
                            {
                                // Wait until all requests using the old handler complete
                                await oldSemaphore.WaitAsync().ConfigureAwait(false);
                                oldHandler?.Dispose();
                                oldSemaphore?.Dispose();
                            });
                        }
                    }
                }

                RewriteRequestUrl(request);

                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                if (Interlocked.Decrement(ref _requestCount) == 0)
                {
                    _requestSemaphore?.Release();
                }
            }
        }

        private void RewriteRequestUrl(HttpRequestMessage request)
        {
            if (request.RequestUri == null)
            {
                return;
            }

            // Preserve the original path and query
            string pathAndQuery = request.RequestUri.PathAndQuery;

            // Build new URL: proxy base URL + original path
            UriBuilder newUri = new UriBuilder(_config.ProxyUrl);

            // Combine paths: trim trailing slash from proxy path and leading slash from request path
            string proxyPath = newUri.Path.TrimEnd('/');
            string requestPath = pathAndQuery.TrimStart('/');

            // If proxy path is just "/" or empty, don't add extra slash
            if (string.IsNullOrEmpty(proxyPath) || proxyPath == "/")
            {
                newUri.Path = "/" + requestPath;
            }
            else
            {
                newUri.Path = proxyPath + "/" + requestPath;
            }

            // Update the request URI
            request.RequestUri = newUri.Uri;
        }

        private bool ShouldReloadHandler()
        {
            // Only need to reload if using a CA file (not inline data)
            if (string.IsNullOrEmpty(_config.CaFilePath))
            {
                return false;
            }

            // Check if CA file content has changed
            byte[] currentCaData = GetCaCertificateData();

            if (currentCaData == null || currentCaData.Length == 0)
            {
                // File is empty or doesn't exist - keep using current handler during rotation gaps
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
                // If we can't read the file, return null to avoid breaking existing connections
                return null;
            }
        }

        private static bool AreByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }

            return true;
        }

        private HttpClientHandler CreateHandler()
        {
            var handler = new HttpClientHandler();

            // Get CA certificate data
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
                X509Certificate2Collection certCollection = ParsePemCertificates(pemContent);

                // Configure custom certificate validation
                handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                {
                    // If there are no errors with default validation, accept it
                    if (errors == System.Net.Security.SslPolicyErrors.None)
                    {
                        return true;
                    }

                    // For netstandard2.0 compatibility, use ExtraStore instead of CustomTrustStore
                    // Add our custom CA certificates to the extra store for chain building
                    chain.ChainPolicy.ExtraStore.AddRange(certCollection);

                    // Disable certificate revocation checking (not applicable for custom CAs in this scenario)
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

                    // We need to verify that the chain can be built with our custom CA
                    // even if there are untrusted root errors (which is expected for custom CAs)
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

                    // Build and validate the chain with our custom CA
                    bool chainIsValid = chain.Build(cert);

                    if (!chainIsValid)
                    {
                        return false;
                    }

                    // Verify that the root certificate in the chain matches one of our custom CAs
                    // This ensures we're trusting only our specified CA certificates
                    if (chain.ChainElements.Count > 0)
                    {
                        var rootCert = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
                        foreach (X509Certificate2 customCert in certCollection)
                        {
                            if (rootCert.Thumbprint.Equals(customCert.Thumbprint, StringComparison.OrdinalIgnoreCase))
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Failed to configure custom CA certificates for Kubernetes token proxy.", ex);
            }
        }

        /// <summary>
        /// Parse PEM-encoded certificates. Supports netstandard2.0 by manually parsing PEM format.
        /// </summary>
        private static X509Certificate2Collection ParsePemCertificates(string pemContent)
        {
            var collection = new X509Certificate2Collection();
            const string beginCert = "-----BEGIN CERTIFICATE-----";
            const string endCert = "-----END CERTIFICATE-----";

            int startIndex = 0;
            while (true)
            {
                // Find the start of the next certificate
                int certStart = pemContent.IndexOf(beginCert, startIndex, StringComparison.Ordinal);
                if (certStart < 0)
                {
                    break;
                }

                // Find the end of this certificate
                int certEnd = pemContent.IndexOf(endCert, certStart, StringComparison.Ordinal);
                if (certEnd < 0)
                {
                    break;
                }

                // Extract the base64 content (between BEGIN and END markers)
                int base64Start = certStart + beginCert.Length;
                int base64Length = certEnd - base64Start;
                string base64Content = pemContent.Substring(base64Start, base64Length);

                // Remove whitespace and newlines
                base64Content = base64Content.Replace("\r", "").Replace("\n", "").Replace(" ", "").Replace("\t", "");

                // Convert base64 to bytes and create certificate
                byte[] certBytes = Convert.FromBase64String(base64Content);
                X509Certificate2 cert = new X509Certificate2(certBytes);
                collection.Add(cert);

                // Move to next certificate
                startIndex = certEnd + endCert.Length;
            }

            if (collection.Count == 0)
            {
                throw new InvalidOperationException("No valid certificates found in PEM content");
            }

            return collection;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _innerHandler?.Dispose();
                _requestSemaphore?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
