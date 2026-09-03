// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant
{
    /// <summary>
    /// Reads the destination an <see cref="System.Diagnostics.Activity"/> was stamped with. The
    /// application resolves the tenant upstream, so this is pure synchronous validation with no
    /// network calls and no blocking lookups.
    /// </summary>
    internal static class TenantRouting
    {
        /// <summary>
        /// The connection string parser imposes no format on an instrumentation key, so neither does
        /// this. A bound is applied only to reject obvious garbage.
        /// </summary>
        private const int MaxInstrumentationKeyLength = 200;

        private const int MaxEndpointLength = 2048;

        /// <summary>
        /// Bounds the cache so a caller stamping many distinct endpoints cannot grow it without
        /// limit. The check is not atomic with the insert, so concurrent misses can overshoot by the
        /// number of racing threads. Past the bound, normalization still succeeds, it just is not
        /// memoised.
        /// </summary>
        private const int MaxCachedEndpoints = 256;

        private static readonly ConcurrentDictionary<string, string> s_normalizedEndpoints = new(StringComparer.Ordinal);

        // Tracked separately because ConcurrentDictionary.Count locks the whole table.
        private static int s_cachedEndpointCount;

        internal static bool TryGetRoute(
            ref AzMonList mappedTags,
            [NotNullWhen(true)] out string? instrumentationKey,
            [NotNullWhen(true)] out string? ingestionEndpoint)
        {
            ingestionEndpoint = null;

            // Only a string is accepted: ToString() on an array-valued tag yields "System.String[]",
            // which would become a tenant of its own.
            var rawKey = mappedTags[SemanticSlot.MicrosoftInstrumentationKey] as string;
            var trimmedKey = rawKey != null && rawKey.Length <= MaxInstrumentationKeyLength ? rawKey.Trim() : null;
            if (trimmedKey == null || trimmedKey.Length == 0)
            {
                instrumentationKey = null;
                return false;
            }

            instrumentationKey = trimmedKey;

            var rawEndpoint = mappedTags[SemanticSlot.MicrosoftIngestionEndpoint] as string;
            if (rawEndpoint == null || (ingestionEndpoint = NormalizeEndpoint(rawEndpoint)) == null)
            {
                instrumentationKey = null;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates an application-supplied endpoint and reduces it to the canonical form used as a
        /// grouping key.
        /// </summary>
        /// <remarks>
        /// The endpoint is resolved upstream from the same trusted source as a connection string, so
        /// this applies no host allow-list. It rejects only what cannot be a valid ingestion target:
        /// a non-HTTP scheme, or credentials, a query, or a fragment, all of which would corrupt the
        /// URI the REST client builds by appending the API path.
        /// </remarks>
        internal static string? NormalizeEndpoint(string rawEndpoint)
        {
            if (rawEndpoint.Length > MaxEndpointLength)
            {
                return null;
            }

            if (s_normalizedEndpoints.TryGetValue(rawEndpoint, out var cached))
            {
                return cached;
            }

            if (!Uri.TryCreate(rawEndpoint, UriKind.Absolute, out var uri)
                || !string.Equals(uri.Scheme, Uri.UriSchemeHttps, StringComparison.Ordinal)
                || uri.UserInfo.Length != 0
                || uri.Query.Length != 0
                || uri.Fragment.Length != 0
                || !TryGetCanonicalHost(uri, out var canonicalHost))
            {
                // Rejections are deliberately not memoised. Caching them would let a misconfigured
                // caller fill the cache with values that never work and crowd out the ones that do.
                return null;
            }

            var port = uri.IsDefaultPort ? string.Empty : ":" + uri.Port.ToString(CultureInfo.InvariantCulture);

            // Rebuilt rather than taken from AbsoluteUri, which keeps trailing dots and non-ASCII
            // host spellings and would split one region into several POSTs.
            var normalized = string.Concat(uri.Scheme, "://", canonicalHost, port, uri.AbsolutePath.TrimEnd('/'), "/");

            // Everything downstream turns this key back into a Uri, so a key that cannot be parsed
            // would fail far from here, after validation has already accepted the endpoint.
            if (!Uri.TryCreate(normalized, UriKind.Absolute, out _))
            {
                return null;
            }

            if (Volatile.Read(ref s_cachedEndpointCount) < MaxCachedEndpoints
                && s_normalizedEndpoints.TryAdd(rawEndpoint, normalized))
            {
                Interlocked.Increment(ref s_cachedEndpointCount);
            }

            return normalized;
        }

        /// <remarks>
        /// <see cref="Uri.IdnHost"/> throws for a malformed <c>xn--</c> label, and strips the brackets
        /// from an IPv6 literal, which would produce a host that cannot be parsed back into a
        /// <see cref="Uri"/>. A host that cannot be canonicalized cannot be grouped consistently, so
        /// it is rejected.
        /// </remarks>
        private static bool TryGetCanonicalHost(Uri uri, out string canonicalHost)
        {
            try
            {
                canonicalHost = uri.HostNameType == UriHostNameType.IPv6
                    ? uri.Host
                    : uri.IdnHost.TrimEnd('.').ToLowerInvariant();
            }
            catch (UriFormatException)
            {
                canonicalHost = string.Empty;
                return false;
            }

            return canonicalHost.Length != 0;
        }
    }
}
