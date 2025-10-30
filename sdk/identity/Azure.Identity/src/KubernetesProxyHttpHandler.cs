// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

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

            _innerHandler = CreateHandler();
            InnerHandler = _innerHandler;
            _requestSemaphore = new SemaphoreSlim(1, 1);
            _requestCount = 0;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref _requestCount);

            try
            {
                // Reload handler if CA certificate file has changed
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

                            // Dispose old handler after in-flight requests complete
                            Task.Run(async () =>
                            {
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

            string pathAndQuery = request.RequestUri.PathAndQuery;
            UriBuilder newUri = new UriBuilder(_config.ProxyUrl);

            string proxyPath = newUri.Path.TrimEnd('/');
            string requestPath = pathAndQuery.TrimStart('/');

            if (string.IsNullOrEmpty(proxyPath) || proxyPath == "/")
            {
                newUri.Path = "/" + requestPath;
            }
            else
            {
                newUri.Path = proxyPath + "/" + requestPath;
            }

            request.RequestUri = newUri.Uri;
        }

        private bool ShouldReloadHandler()
        {
            if (string.IsNullOrEmpty(_config.CaFilePath))
            {
                return false;
            }

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
