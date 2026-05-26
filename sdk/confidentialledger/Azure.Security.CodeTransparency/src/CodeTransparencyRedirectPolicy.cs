// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// An <see cref="HttpPipelinePolicy"/> that follows HTTP 307 and 308 redirect responses
    /// while preserving the Authorization header, but only when the redirect target stays
    /// within the configured endpoint's trust boundary.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Code Transparency Service nodes may return 307 (Temporary Redirect) or 308 (Permanent Redirect)
    /// responses to route write operations to the primary node. The standard redirect behavior in .NET
    /// strips the Authorization header on cross-domain redirects for security reasons. This policy
    /// preserves the Authorization header for redirects to trusted targets — the configured endpoint
    /// host or a subdomain of it on HTTPS with the same port.
    /// </para>
    /// <para>
    /// Redirects to untrusted targets are refused by throwing <see cref="InvalidOperationException"/>
    /// to prevent credential and request-body leakage (MSRC #116673).
    /// </para>
    /// <para>
    /// Cache writes are staged per-call and only committed after a successful trusted chain
    /// to prevent write-URL cache poisoning.
    /// </para>
    /// </remarks>
    internal sealed class CodeTransparencyRedirectPolicy : HttpPipelinePolicy
    {
        private const int MaxRedirects = 5;

        /// <summary>
        /// Status codes that must never cause a cache commit. Broader than
        /// <see cref="IsRedirectResponse"/> so a future widening of followed
        /// codes cannot poison the cache.
        /// </summary>
        private static readonly HashSet<int> s_redirectStatusCodes =
            new HashSet<int> { 300, 301, 302, 303, 307, 308 };

        private readonly object _primaryNodeLock = new object();
        private readonly string _ledgerHostname;
        private readonly int _ledgerPort;
        private Uri _primaryNodeBaseUri;

        /// <summary>
        /// Creates a new redirect policy anchored on the specified endpoint.
        /// </summary>
        /// <param name="endpoint">The configured service endpoint used as the trust anchor.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="endpoint"/> is not an absolute URI.</exception>
        public CodeTransparencyRedirectPolicy(Uri endpoint)
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

            // Per-call staged cache candidate. Committed only after a successful trusted chain.
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
                // Transport failure (connection refused, timeout, DNS, etc.) while targeting
                // the cached primary — invalidate so the next request goes through the load
                // balancer and can discover the new primary via redirect.
                if (appliedCache)
                {
                    InvalidateCachedPrimaryNode();
                }

                throw;
            }

            // If we sent to the cached primary and got a server error, the node may be
            // unhealthy or no longer primary (e.g., DR failover). Invalidate the cache so
            // the next write goes through the load balancer to re-discover the primary.
            if (appliedCache && message.Response.Status >= 500)
            {
                InvalidateCachedPrimaryNode();
            }

            int redirectCount = 0;

            while (IsRedirectResponse(message.Response.Status))
            {
                if (++redirectCount > MaxRedirects)
                {
                    // Too many redirects; return the last redirect response as-is.
                    break;
                }

                if (!message.Response.Headers.TryGetValue("Location", out string location))
                {
                    // No Location header; return the redirect response as-is.
                    break;
                }

                Uri redirectUri = BuildRedirectUri(message.Request.Uri.ToUri(), location);

                // SECURITY: validate trust BEFORE touching request URI or cache.
                // Untrusted targets are refused to prevent credential and request-body
                // leakage to attacker-controlled hosts (MSRC #116673).
                if (!IsTrustedRedirectTarget(redirectUri))
                {
                    string origin = FormatOrigin(redirectUri);
                    message.Response.Dispose();
                    throw new InvalidOperationException(
                        $"Confidential Ledger refused to follow redirect to untrusted target origin: {origin}");
                }

                // Stage (do not commit) cache candidate for non-GET trusted hops.
                // GET requests may be redirected for other reasons (e.g., historical queries
                // routed to backup nodes), so their redirect targets should not be cached.
                if (message.Request.Method != RequestMethod.Get)
                {
                    pendingCacheUri = GetPrimaryNodeBaseUri(redirectUri);
                }

                // Update the request URI to the trusted redirect target.
                // The Authorization header is intentionally preserved because CTS redirects
                // within the trust boundary are between nodes of the same ledger.
                message.Request.Uri.Reset(redirectUri);

                // Dispose of the redirect response before re-sending.
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
                    // Transport error mid-chain: discard staged cache and invalidate any
                    // prior cached value as a safety net.
                    InvalidateCachedPrimaryNode();
                    throw;
                }
            }

            // Commit the staged cache only when the redirect chain reached a terminal
            // non-redirect, non-5xx response. If the chain ended on a 3xx (e.g., max-retries
            // exhausted, malformed Location, or no Location header), we do not know the
            // staged URL is reachable, so the cache is discarded.
            if (pendingCacheUri != null
                && !s_redirectStatusCodes.Contains(message.Response.Status)
                && message.Response.Status < 500)
            {
                CommitPrimaryNode(pendingCacheUri);
            }
            else if (message.Response.Status >= 500)
            {
                // Trusted chain ended in 5xx — invalidate any previously cached value.
                InvalidateCachedPrimaryNode();
            }
        }

        // ---------- Trust check ----------

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

        // ---------- Redirect helpers ----------

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

        // ---------- Cache helpers ----------

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
