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
    /// One token serves every destination in a cloud: the scope identifies Azure Monitor in that
    /// cloud, not an individual component, so an identity holding the publisher role on each
    /// component can authenticate to all of them with the same header.
    /// </remarks>
    internal sealed class EndpointTrustPolicy
    {
        /// <summary>No credential, or routing is off: the destination is not a disclosure risk.</summary>
        internal static readonly EndpointTrustPolicy Unrestricted = new(enabled: false, ownIngestionEndpoint: null, aadAudience: null);

        private readonly string _ownIngestionHost;
        private readonly int _ownIngestionPort;
        private readonly string[] _allowedSuffixes;

        /// <remarks>
        /// An absent <paramref name="aadAudience"/> means the public cloud, matching
        /// <see cref="ConnectionString.AadHelper.GetScope"/>. Guessing wrong only ever rejects a
        /// destination, never widens what the token can reach.
        /// </remarks>
        internal EndpointTrustPolicy(bool enabled, Uri? ownIngestionEndpoint, string? aadAudience = null)
        {
            Enabled = enabled;

            if (ownIngestionEndpoint != null && RedirectPolicyHelper.TryGetCanonicalHost(ownIngestionEndpoint, out var host))
            {
                _ownIngestionHost = host;
                _ownIngestionPort = ownIngestionEndpoint.Port;
            }
            else
            {
                _ownIngestionHost = string.Empty;
                _ownIngestionPort = -1;
            }

            _allowedSuffixes = RedirectPolicyHelper.GetIngestionSuffixesForAudience(aadAudience);
        }

        internal bool Enabled { get; }

        internal bool IsTrusted(Uri uri)
            => !Enabled || (RedirectPolicyHelper.TryGetCanonicalHost(uri, out var host) && IsTrusted(host, uri.IsDefaultPort, uri.Port));

        /// <remarks>
        /// <paramref name="canonicalHost"/> is the lowercased IDN host produced by endpoint
        /// normalization.
        /// </remarks>
        internal bool IsTrusted(string canonicalHost, bool isDefaultPort, int port)
        {
            if (!Enabled)
            {
                return true;
            }

            // The exporter's own endpoint comes from the connection string, so it is trusted on the
            // operator's word even when it is a private link or gateway host outside the suffix
            // list. The port is part of that word: another port on the same host is another service.
            if (_ownIngestionHost.Length != 0
                && port == _ownIngestionPort
                && string.Equals(canonicalHost, _ownIngestionHost, StringComparison.Ordinal))
            {
                return true;
            }

            return isDefaultPort && RedirectPolicyHelper.IsTrustedIngestionHost(canonicalHost, _allowedSuffixes);
        }
    }
}
