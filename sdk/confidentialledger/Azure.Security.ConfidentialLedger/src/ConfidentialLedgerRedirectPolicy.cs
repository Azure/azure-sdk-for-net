// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// An <see cref="HttpPipelinePolicy"/> that follows HTTP 307 and 308 redirect responses
    /// while preserving the Authorization header, but only when the redirect target stays
    /// within the configured ledger endpoint's trust boundary.
    /// </summary>
    /// <remarks>
    /// Azure Confidential Ledger nodes may return 307 (Temporary Redirect) or 308 (Permanent Redirect)
    /// responses to route write operations to the primary node. The standard redirect behavior in .NET
    /// strips the Authorization header on cross-domain redirects for security reasons. This policy
    /// preserves the Authorization header for redirects to trusted targets - the configured ledger
    /// endpoint host or a subdomain of it on HTTPS with the same port.
    /// </remarks>
    internal sealed class ConfidentialLedgerRedirectPolicy : HttpPipelinePolicy
    {
        private const int MaxRedirects = 5;

        private static readonly HashSet<int> s_redirectStatusCodes =
            new HashSet<int> { 300, 301, 302, 303, 307, 308 };

        private readonly object _primaryNodeLock = new object();
        private readonly string _ledgerHostname;
        private readonly int _ledgerPort;
        private Uri _primaryNodeBaseUri;

        /// <summary>
        /// Creates a new redirect policy anchored on the configured ledger endpoint.
        /// </summary>
        /// <param name="endpoint">The configured ledger endpoint used as the trust anchor.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="endpoint"/> is not an absolute URI.</exception>
        public ConfidentialLedgerRedirectPolicy(Uri endpoint)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            if (!endpoint.IsAbsoluteUri)
            {
                throw new ArgumentException("Endpoint must be an absolute URI.", nameof(endpoint));
            }

            _ledgerHostname = CanonicalHostname(endpoint.IdnHost);
            _ledgerPort = endpoint.IsDefaultPort ? GetDefaultPort(endpoint.Scheme) : endpoint.Port;
        }

        /// <inheritdoc/>
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        /// <inheritdoc/>
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            bool appliedCache = TryApplyCachedPrimaryNode(message.Request);
            Uri pendingCacheUri = null;

            try
            {
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
            }
            catch
            {
                if (appliedCache)
                {
                    InvalidateCachedPrimaryNode();
                }

                throw;
            }

            if (appliedCache && message.Response.Status >= 500)
            {
                InvalidateCachedPrimaryNode();
            }

            int redirectCount = 0;

            while (IsRedirectResponse(message.Response.Status))
            {
                if (++redirectCount > MaxRedirects)
                {
                    break;
                }

                if (!message.Response.Headers.TryGetValue("Location", out string location))
                {
                    break;
                }

                Uri redirectUri = BuildRedirectUri(message.Request.Uri.ToUri(), location);

                if (!IsTrustedRedirectTarget(redirectUri))
                {
                    string origin = FormatOrigin(redirectUri);
                    InvalidateCachedPrimaryNode();
                    message.Response.Dispose();
                    throw new InvalidOperationException(
                        $"Confidential Ledger refused to follow redirect to untrusted target origin: {origin}");
                }

                if (message.Request.Method != RequestMethod.Get)
                {
                    pendingCacheUri = GetPrimaryNodeBaseUri(redirectUri);
                }

                message.Request.Uri.Reset(redirectUri);
                message.Response.Dispose();

                try
                {
                    if (async)
                    {
                        await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                    }
                    else
                    {
                        ProcessNext(message, pipeline);
                    }
                }
                catch
                {
                    InvalidateCachedPrimaryNode();
                    throw;
                }
            }

            if (pendingCacheUri != null
                && !s_redirectStatusCodes.Contains(message.Response.Status)
                && message.Response.Status < 500)
            {
                CommitPrimaryNode(pendingCacheUri);
            }
            else if (message.Response.Status >= 500)
            {
                InvalidateCachedPrimaryNode();
            }
        }

        private static string CanonicalHostname(string host)
        {
            if (string.IsNullOrEmpty(host))
            {
                return string.Empty;
            }

            if (host[host.Length - 1] == '.')
            {
                host = host.Substring(0, host.Length - 1);
            }

            return host.ToLowerInvariant();
        }

        private bool IsTrustedRedirectTarget(Uri target)
        {
            if (target == null || !target.IsAbsoluteUri)
            {
                return false;
            }

            if (!string.Equals(target.Scheme, Uri.UriSchemeHttps, StringComparison.Ordinal))
            {
                return false;
            }

            int targetPort = target.IsDefaultPort ? GetDefaultPort(target.Scheme) : target.Port;
            if (targetPort != _ledgerPort)
            {
                return false;
            }

            string targetHost = CanonicalHostname(target.IdnHost);
            return targetHost.Equals(_ledgerHostname, StringComparison.Ordinal)
                || targetHost.EndsWith("." + _ledgerHostname, StringComparison.Ordinal);
        }

        private static int GetDefaultPort(string scheme)
        {
            if (string.Equals(scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
            {
                return 443;
            }

            if (string.Equals(scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase))
            {
                return 80;
            }

            return -1;
        }

        private static string FormatOrigin(Uri uri)
        {
            if (uri == null || !uri.IsAbsoluteUri)
            {
                return "<invalid>";
            }

            return uri.IsDefaultPort
                ? $"{uri.Scheme}://{uri.Host}"
                : $"{uri.Scheme}://{uri.Host}:{uri.Port}";
        }

        private static bool IsRedirectResponse(int statusCode)
        {
            return statusCode == 307 || statusCode == 308;
        }

        private static Uri BuildRedirectUri(Uri requestUri, string location)
        {
            Uri redirectUri = new Uri(location, UriKind.RelativeOrAbsolute);

            if (!redirectUri.IsAbsoluteUri)
            {
                redirectUri = new Uri(requestUri, redirectUri);
            }

            return redirectUri;
        }

        private bool TryApplyCachedPrimaryNode(Request request)
        {
            if (request.Method == RequestMethod.Get)
            {
                return false;
            }

            Uri primaryNodeBaseUri = Volatile.Read(ref _primaryNodeBaseUri);
            if (primaryNodeBaseUri == null)
            {
                return false;
            }

            request.Uri.Reset(BuildUriWithPrimaryHost(request.Uri.ToUri(), primaryNodeBaseUri));
            return true;
        }

        private void CommitPrimaryNode(Uri primaryBase)
        {
            if (primaryBase == null)
            {
                return;
            }

            lock (_primaryNodeLock)
            {
                Volatile.Write(ref _primaryNodeBaseUri, primaryBase);
            }
        }

        private void InvalidateCachedPrimaryNode()
        {
            lock (_primaryNodeLock)
            {
                _primaryNodeBaseUri = null;
            }
        }

        private static Uri GetPrimaryNodeBaseUri(Uri uri)
        {
            if (uri == null || !uri.IsAbsoluteUri)
            {
                return null;
            }

            return new UriBuilder(uri.Scheme, uri.Host, uri.IsDefaultPort ? -1 : uri.Port).Uri;
        }

        private static Uri BuildUriWithPrimaryHost(Uri requestUri, Uri primaryNodeBaseUri)
        {
            var builder = new UriBuilder(requestUri)
            {
                Scheme = primaryNodeBaseUri.Scheme,
                Host = primaryNodeBaseUri.Host,
                Port = primaryNodeBaseUri.IsDefaultPort ? -1 : primaryNodeBaseUri.Port
            };

            return builder.Uri;
        }
    }
}
