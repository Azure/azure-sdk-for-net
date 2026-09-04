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
    /// An <see cref="HttpPipelinePolicy"/> that follows HTTP 303, 307 and 308 redirect responses
    /// while preserving the Authorization header, but only when the redirect target stays
    /// within the configured endpoint's trust boundary.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Code Transparency Service nodes may return 307 (Temporary Redirect) or 308 (Permanent Redirect)
    /// responses to route write operations to the primary node, and 303 (See Other) responses to point
    /// a completed write at the created resource (for example, the committed entry that carries the
    /// receipt). The standard redirect behavior in .NET
    /// strips the Authorization header on cross-domain redirects for security reasons. This policy
    /// preserves the Authorization header for redirects to trusted targets — the configured endpoint
    /// host or a subdomain of it on HTTPS with the same port. A 303 redirect is followed with a GET
    /// request and without the original request body, per HTTP semantics.
    /// </para>
    /// <para>
    /// Redirects to untrusted targets are refused by throwing <see cref="InvalidOperationException"/>
    /// to prevent credential and request-body leakage to attacker-controlled hosts.
    /// </para>
    /// <para>
    /// Cache writes are staged per-call and only committed after a successful trusted chain
    /// to prevent write-URL cache poisoning.
    /// </para>
    /// </remarks>
    internal sealed class CodeTransparencyRedirectPolicy : HttpPipelinePolicy
    {
        private const int MaxRedirects = 5;
        private const int SeeOtherStatusCode = 303;
        internal const string SuppressSeeOtherRedirectProperty = "CodeTransparency.SuppressSeeOtherRedirect";

        /// <summary>
        /// Status a Code Transparency node returns for a read of a not-yet-committed entry (its
        /// <c>Location</c> points back at the same entry URL) until the transaction is committed and
        /// indexed. Treated as retriable on a followed redirect so the pipeline polls until 200.
        /// </summary>
        private const int PendingEntryStatusCode = 302;

        /// <summary>
        /// Query parameter that selects the service API version. It is preserved across followed
        /// redirects so a <c>Location</c> that omits it (for example, <c>/entries/{id}</c>) does not
        /// fall back to the service's unversioned (legacy) behavior instead of the versioned API.
        /// </summary>
        private const string ApiVersionParameter = "api-version";

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

            while (ShouldFollowRedirect(message))
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

                // Validate trust before modifying the request URI or staging a cache write.
                if (!IsTrustedRedirectTarget(redirectUri))
                {
                    string origin = FormatOrigin(redirectUri);
                    InvalidateCachedPrimaryNode();
                    message.Response.Dispose();
                    throw new InvalidOperationException(
                        $"Confidential Ledger refused to follow redirect to untrusted target origin: {origin}");
                }

                // A 303 See Other instructs the client to retrieve the redirect target with a
                // GET request and without the original request body. This is a resource redirect
                // (for example, from a completed write to the created entry), not a primary-node redirect.
                bool isSeeOther = message.Response.Status == SeeOtherStatusCode;

                // Stage cache candidate for non-GET trusted hops. A 303 must not update the
                // primary-node cache because its target is a resource, not a primary node.
                if (!isSeeOther && message.Request.Method != RequestMethod.Get)
                {
                    pendingCacheUri = GetPrimaryNodeBaseUri(redirectUri);
                }

                if (isSeeOther)
                {
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Content = null;
                    message.Request.Headers.Remove("Content-Type");

                    // The followed GET returns the target resource (for example, 200 with the
                    // entry receipt), a status the request's original classifier does not recognize.
                    // Apply standard success semantics (2xx succeeds) to the followed response, and
                    // treat a pending 302 (entry not yet committed) as retriable so the pipeline polls.
                    message.ResponseClassifier = FollowedRedirectResponseClassifier.Instance;
                }

                // Preserve the Authorization header on trusted redirects.
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
                    // Transport error mid-chain: invalidate cache for clean retry.
                    InvalidateCachedPrimaryNode();
                    throw;
                }
            }

            // Commit staged cache only on a terminal non-redirect, non-5xx response.
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
            return statusCode == SeeOtherStatusCode || statusCode == 307 || statusCode == 308;
        }

        private static bool ShouldFollowRedirect(HttpMessage message)
        {
            return !(message.Response.Status == SeeOtherStatusCode &&
                message.TryGetProperty(SuppressSeeOtherRedirectProperty, out object suppressRedirect) &&
                suppressRedirect is true) &&
                IsRedirectResponse(message.Response.Status);
        }

        private static Uri BuildRedirectUri(Uri requestUri, string location)
        {
            Uri redirectUri = new Uri(location, UriKind.RelativeOrAbsolute);

            if (!redirectUri.IsAbsoluteUri)
            {
                redirectUri = new Uri(requestUri, redirectUri);
            }

            // Code Transparency Service nodes return a Location (for example, /entries/{id}) that omits
            // the api-version. Following it verbatim makes the next request use the service's legacy
            // (unversioned) behavior, which surfaces a still-pending transaction as 503. Carry the
            // api-version from the original request forward so the followed request stays on the
            // negotiated API version.
            return PreserveApiVersion(requestUri, redirectUri);
        }

        /// <summary>
        /// Copies the <c>api-version</c> query parameter from <paramref name="requestUri"/> onto
        /// <paramref name="redirectUri"/> when the redirect target does not already specify one.
        /// </summary>
        private static Uri PreserveApiVersion(Uri requestUri, Uri redirectUri)
        {
            if (redirectUri == null || !redirectUri.IsAbsoluteUri)
            {
                return redirectUri;
            }

            // The redirect target already selects an API version; leave it untouched.
            if (QueryContainsKey(redirectUri.Query, ApiVersionParameter))
            {
                return redirectUri;
            }

            string apiVersion = GetQueryParameterValue(requestUri?.Query, ApiVersionParameter);
            if (string.IsNullOrEmpty(apiVersion))
            {
                return redirectUri;
            }

            string appended = ApiVersionParameter + "=" + Uri.EscapeDataString(apiVersion);
            UriBuilder builder = new UriBuilder(redirectUri);
            string existingQuery = builder.Query; // Leading '?' when non-empty.
            builder.Query = string.IsNullOrEmpty(existingQuery)
                ? appended
                : existingQuery.TrimStart('?') + "&" + appended;

            return builder.Uri;
        }

        /// <summary>
        /// Returns <c>true</c> when the query string contains a parameter named <paramref name="key"/>.
        /// </summary>
        private static bool QueryContainsKey(string query, string key)
        {
            if (string.IsNullOrEmpty(query))
            {
                return false;
            }

            foreach (string pair in query.TrimStart('?').Split('&'))
            {
                if (pair.Length == 0)
                {
                    continue;
                }

                int equalsIndex = pair.IndexOf('=');
                string name = equalsIndex >= 0 ? pair.Substring(0, equalsIndex) : pair;
                if (string.Equals(Uri.UnescapeDataString(name), key, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the value of the query parameter named <paramref name="key"/>, or <c>null</c> when absent.
        /// </summary>
        private static string GetQueryParameterValue(string query, string key)
        {
            if (string.IsNullOrEmpty(query))
            {
                return null;
            }

            foreach (string pair in query.TrimStart('?').Split('&'))
            {
                if (pair.Length == 0)
                {
                    continue;
                }

                int equalsIndex = pair.IndexOf('=');
                string name = equalsIndex >= 0 ? pair.Substring(0, equalsIndex) : pair;
                if (string.Equals(Uri.UnescapeDataString(name), key, StringComparison.OrdinalIgnoreCase))
                {
                    return equalsIndex >= 0 ? Uri.UnescapeDataString(pair.Substring(equalsIndex + 1)) : string.Empty;
                }
            }

            return null;
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

        /// <summary>
        /// Classifies the response of a followed 303 See Other redirect using standard HTTP
        /// semantics: any 2xx status is a success, everything else is an error. This replaces
        /// the originating request's classifier, which only recognizes the pre-redirect status
        /// codes (for example, 201/303 for a write). A pending <c>302 Found</c> (the entry is not
        /// yet committed and indexed) is additionally treated as retriable so the pipeline's retry
        /// policy polls the entry URL, with backoff, until the committed receipt (200) is returned.
        /// </summary>
        private sealed class FollowedRedirectResponseClassifier : ResponseClassifier
        {
            public static readonly FollowedRedirectResponseClassifier Instance = new FollowedRedirectResponseClassifier();

            public override bool IsErrorResponse(HttpMessage message)
            {
                int status = message.Response.Status;
                return status < 200 || status >= 300;
            }

            public override bool IsRetriableResponse(HttpMessage message)
            {
                // A read of a not-yet-committed entry is answered with 302 Found (Location points back
                // at the same entry URL). Retry it so the pipeline polls until the entry is committed.
                return message.Response.Status == PendingEntryStatusCode || base.IsRetriableResponse(message);
            }
        }
    }
}
