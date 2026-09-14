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

        private const string UnknownService = "unknown_service";

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
            [NotNullWhen(true)] out string? ingestionEndpoint,
            out RoutingRejectionReason reason)
        {
            // Only a string is accepted: ToString() on an array-valued tag yields "System.String[]",
            // which would become a tenant of its own.
            return TryGetRoute(
                mappedTags[SemanticSlot.MicrosoftInstrumentationKey] as string,
                mappedTags[SemanticSlot.MicrosoftIngestionEndpoint] as string,
                out instrumentationKey,
                out ingestionEndpoint,
                out reason);
        }

        /// <summary>
        /// Validates raw routing values and reduces them to the canonical instrumentation key and
        /// ingestion endpoint used to group telemetry. Signal-neutral: traces resolve the raw values
        /// from an <see cref="AzMonList"/>, logs from <see cref="System.Diagnostics.Activity"/>-free
        /// <c>LogRecord.Attributes</c>, but both share this validation core.
        /// </summary>
        /// <remarks>
        /// A non-string value is rejected by the caller passing <see langword="null"/>: an
        /// array-valued attribute stringified to "System.String[]" would otherwise become a tenant
        /// of its own.
        /// </remarks>
        internal static bool TryGetRoute(
            string? rawInstrumentationKey,
            string? rawIngestionEndpoint,
            [NotNullWhen(true)] out string? instrumentationKey,
            [NotNullWhen(true)] out string? ingestionEndpoint)
            => TryGetRoute(rawInstrumentationKey, rawIngestionEndpoint, out instrumentationKey, out ingestionEndpoint, out _);

        internal static bool TryGetRoute(
            string? rawInstrumentationKey,
            string? rawIngestionEndpoint,
            [NotNullWhen(true)] out string? instrumentationKey,
            [NotNullWhen(true)] out string? ingestionEndpoint,
            out RoutingRejectionReason reason)
        {
            ingestionEndpoint = null;
            reason = RoutingRejectionReason.None;

            var trimmedKey = rawInstrumentationKey != null && rawInstrumentationKey.Length <= MaxInstrumentationKeyLength ? rawInstrumentationKey.Trim() : null;
            if (trimmedKey == null || trimmedKey.Length == 0)
            {
                reason = rawInstrumentationKey != null && rawInstrumentationKey.Length > MaxInstrumentationKeyLength
                    ? RoutingRejectionReason.InstrumentationKeyTooLong
                    : RoutingRejectionReason.MissingInstrumentationKey;
                instrumentationKey = null;
                return false;
            }

            instrumentationKey = trimmedKey;

            if (rawIngestionEndpoint == null)
            {
                reason = RoutingRejectionReason.MissingIngestionEndpoint;
                instrumentationKey = null;
                return false;
            }

            if ((ingestionEndpoint = NormalizeEndpoint(rawIngestionEndpoint, out reason)) == null)
            {
                instrumentationKey = null;
                return false;
            }

            return true;
        }

        internal static string GetTenantCloudRole(ref AzMonList mappedTags)
        {
            return GetTenantCloudRole(mappedTags[SemanticSlot.MicrosoftMultiEndpointCloudRole] as string);
        }

        internal static string GetTenantCloudRole(string? cloudRole)
            => string.IsNullOrWhiteSpace(cloudRole) ? UnknownService : cloudRole!.Trim();

        /// <summary>
        /// Validates an application-supplied endpoint and reduces it to the canonical form used as a
        /// grouping key.
        /// </summary>
        /// <remarks>
        /// The endpoint is resolved upstream from the same trusted source as a connection string, so
        /// this applies no host allow-list. It rejects anything that cannot be a valid ingestion
        /// target: a scheme other than HTTPS, or credentials, a query, or a fragment, all of which
        /// would corrupt the URI the REST client builds by appending the API path.
        /// </remarks>
        internal static string? NormalizeEndpoint(string rawEndpoint) => NormalizeEndpoint(rawEndpoint, out _);

        internal static string? NormalizeEndpoint(string rawEndpoint, out RoutingRejectionReason reason)
        {
            reason = RoutingRejectionReason.None;

            if (rawEndpoint.Length > MaxEndpointLength)
            {
                reason = RoutingRejectionReason.IngestionEndpointTooLong;
                return null;
            }

            if (s_normalizedEndpoints.TryGetValue(rawEndpoint, out var cached))
            {
                return cached;
            }

            if (!Uri.TryCreate(rawEndpoint, UriKind.Absolute, out var uri))
            {
                reason = RoutingRejectionReason.IngestionEndpointMalformed;
                return null;
            }

            if (!string.Equals(uri.Scheme, Uri.UriSchemeHttps, StringComparison.Ordinal))
            {
                reason = RoutingRejectionReason.IngestionEndpointNotHttps;
                return null;
            }

            if (uri.UserInfo.Length != 0)
            {
                reason = RoutingRejectionReason.IngestionEndpointHasCredentials;
                return null;
            }

            if (uri.Query.Length != 0 || uri.Fragment.Length != 0)
            {
                reason = RoutingRejectionReason.IngestionEndpointHasQueryOrFragment;
                return null;
            }

            if (!TryGetCanonicalHost(uri, out var canonicalHost))
            {
                // Rejections are deliberately not memoised. Caching them would let a misconfigured
                // caller fill the cache with values that never work and crowd out the ones that do.
                reason = RoutingRejectionReason.IngestionEndpointHostInvalid;
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
                reason = RoutingRejectionReason.IngestionEndpointHostInvalid;
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
