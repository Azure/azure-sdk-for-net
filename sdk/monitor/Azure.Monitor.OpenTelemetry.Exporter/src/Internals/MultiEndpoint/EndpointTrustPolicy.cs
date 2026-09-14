// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint
{
    /// <summary>
    /// Decides which ingestion endpoints may be addressed while the exporter holds an Entra ID
    /// credential. In multi-endpoint mode the destination comes from telemetry, so without this a
    /// token minted for the exporter's audience would be sent to any host an Activity names.
    /// </summary>
    /// <remarks>
    /// One token serves every destination: the scope identifies Azure Monitor in a cloud, not an
    /// individual component, so an identity holding the publisher role on each component can
    /// authenticate to all of them with the same header.
    /// </remarks>
    internal sealed class EndpointTrustPolicy
    {
        /// <summary>No credential, or routing is off: the destination is not a disclosure risk.</summary>
        internal static readonly EndpointTrustPolicy Unrestricted = new(enabled: false, ownIngestionEndpoint: null);

        private readonly string _ownIngestionHost;

        internal EndpointTrustPolicy(bool enabled, Uri? ownIngestionEndpoint)
        {
            Enabled = enabled;

            _ownIngestionHost = ownIngestionEndpoint != null && RedirectPolicyHelper.TryGetCanonicalHost(ownIngestionEndpoint, out var host)
                ? host
                : string.Empty;
        }

        internal bool Enabled { get; }

        internal bool IsTrusted(Uri uri)
            => !Enabled || (RedirectPolicyHelper.TryGetCanonicalHost(uri, out var host) && IsTrusted(host, uri.IsDefaultPort));

        /// <remarks>
        /// <paramref name="canonicalHost"/> is the lowercased IDN host produced by endpoint
        /// normalization.
        /// </remarks>
        internal bool IsTrusted(string canonicalHost, bool isDefaultPort)
        {
            if (!Enabled)
            {
                return true;
            }

            // The exporter's own endpoint comes from the connection string, so it is trusted on the
            // operator's word even when it is a private link or gateway host outside the suffix list.
            if (_ownIngestionHost.Length != 0 && string.Equals(canonicalHost, _ownIngestionHost, StringComparison.Ordinal))
            {
                return true;
            }

            return isDefaultPort && RedirectPolicyHelper.IsTrustedIngestionHost(canonicalHost);
        }
    }
}
