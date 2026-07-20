// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// Encapsulates the trust-boundary rules that decide whether the client may follow a redirect
    /// (303/307/308) or poll a pending-entry (302) <c>Location</c> returned by a Code Transparency
    /// Service node.
    /// </summary>
    /// <remarks>
    /// A target is trusted only when it is an absolute HTTPS URI, on the same port as the configured
    /// endpoint, whose host is either the configured endpoint host or a subdomain of it. This is the
    /// same rule that governs Authorization-header preservation on redirects, and it prevents
    /// credential and request-body leakage — and, for polling, entry-status probing — against
    /// attacker-controlled hosts. The logic is shared by <see cref="CodeTransparencyRedirectPolicy"/>
    /// and the entry-polling long-running operation so both apply identical checks.
    /// </remarks>
    internal sealed class CodeTransparencyTrustBoundary
    {
        private readonly string _ledgerHostname;
        private readonly int _ledgerPort;

        /// <summary>
        /// Creates a new trust boundary anchored on the specified endpoint.
        /// </summary>
        /// <param name="endpoint">The configured service endpoint used as the trust anchor.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="endpoint"/> is not an absolute URI.</exception>
        public CodeTransparencyTrustBoundary(Uri endpoint)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            if (!endpoint.IsAbsoluteUri)
            {
                throw new ArgumentException("Endpoint must be an absolute URI.", nameof(endpoint));
            }

            _ledgerHostname = CanonicalHostname(endpoint.IdnHost);
            _ledgerPort = endpoint.IsDefaultPort ? GetDefaultPort(endpoint.Scheme) : endpoint.Port;
        }

        /// <summary>
        /// Returns <c>true</c> when <paramref name="target"/> is within the endpoint's trust boundary:
        /// an absolute HTTPS URI on the same port whose host equals the endpoint host or is a subdomain of it.
        /// </summary>
        public bool IsTrusted(Uri target)
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

        /// <summary>
        /// Resolves a (possibly relative) <c>Location</c> header value against the supplied request URI.
        /// </summary>
        public static Uri BuildAbsoluteUri(Uri requestUri, string location)
        {
            Uri redirectUri = new Uri(location, UriKind.RelativeOrAbsolute);
            if (!redirectUri.IsAbsoluteUri && requestUri != null)
            {
                redirectUri = new Uri(requestUri, redirectUri);
            }

            return redirectUri;
        }

        /// <summary>
        /// Formats the scheme/host/port origin of a URI for use in diagnostic messages.
        /// </summary>
        public static string FormatOrigin(Uri uri)
        {
            if (uri == null || !uri.IsAbsoluteUri)
            {
                return "<invalid>";
            }

            return uri.IsDefaultPort
                ? $"{uri.Scheme}://{uri.Host}"
                : $"{uri.Scheme}://{uri.Host}:{uri.Port}";
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
    }
}
