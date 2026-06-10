// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// An <see cref="HttpPipelinePolicy"/> that follows HTTP 307 and 308 redirect responses
    /// while preserving the Authorization header.
    /// </summary>
    /// <remarks>
    /// Azure Confidential Ledger nodes may return 307 (Temporary Redirect) or 308 (Permanent Redirect)
    /// responses to route write operations to the primary node. The standard redirect behavior in .NET
    /// strips the Authorization header on cross-domain redirects for security reasons. However, ACL
    /// redirects occur between trusted nodes within the same ledger, so the Authorization header must
    /// be preserved for the redirected request to succeed.
    /// </remarks>
    internal sealed class ConfidentialLedgerRedirectPolicy : HttpPipelinePolicy
    {
        private const int MaxRedirects = 5;
        private readonly object _primaryNodeLock = new object();
        private readonly bool _cachePrimaryNode;
        private Uri _primaryNodeBaseUri;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfidentialLedgerRedirectPolicy"/>.
        /// </summary>
        /// <param name="cachePrimaryNode">
        /// When <c>true</c> (the default), the policy remembers the redirect target of the most recent
        /// non-GET request and routes subsequent non-GET requests directly to that host until a transport
        /// failure or 5xx response invalidates the cache. This optimization is appropriate when the
        /// redirect chain always terminates at a single sticky primary node (the default CCF behavior).
        /// When <c>false</c>, the cache is disabled: 307/308 responses are still followed (and the
        /// <c>Authorization</c> header is still preserved across the redirect) but no host pinning is
        /// performed. Use this when the upstream gateway may redirect to any healthy host (for example,
        /// the Confidential Ledger Web Frontend Gateway).
        /// </param>
        public ConfidentialLedgerRedirectPolicy(bool cachePrimaryNode = true)
        {
            _cachePrimaryNode = cachePrimaryNode;
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

                // Only cache the redirect target as the primary node for non-GET (write) requests.
                // GET requests may be redirected for other reasons (e.g., historical queries routed
                // to backup nodes), so their redirect targets should not be assumed to be the primary.
                if (message.Request.Method != RequestMethod.Get)
                {
                    CachePrimaryNode(redirectUri);
                }

                // Disallow redirect from HTTPS to HTTP.
                if (string.Equals(message.Request.Uri.Scheme, "https", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(redirectUri.Scheme, "https", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Update the request URI to the redirect target.
                // The Authorization header is intentionally preserved because ACL redirects
                // are between trusted nodes within the same ledger.
                message.Request.Uri.Reset(redirectUri);

                // Dispose of the redirect response before re-sending.
                message.Response.Dispose();

                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
            }
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
            if (!_cachePrimaryNode)
            {
                return false;
            }

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

        private void CachePrimaryNode(Uri redirectUri)
        {
            if (!_cachePrimaryNode)
            {
                return;
            }

            Uri candidatePrimary = GetPrimaryNodeBaseUri(redirectUri);
            if (candidatePrimary == null)
            {
                return;
            }

            lock (_primaryNodeLock)
            {
                Volatile.Write(ref _primaryNodeBaseUri, candidatePrimary);
            }
        }

        private void InvalidateCachedPrimaryNode()
        {
            if (!_cachePrimaryNode)
            {
                return;
            }

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
