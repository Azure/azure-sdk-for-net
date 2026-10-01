// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// Holds the set of ledger identity TLS certificates that the client transport is allowed to pin
    /// against. A Confidential Ledger client may talk to more than one ledger: the primary ledger and,
    /// when a request fails, one or more failover ledgers. Each ledger is a distinct CCF network with
    /// its <b>own</b> identity TLS certificate, so a single pinned certificate is not sufficient.
    /// </summary>
    /// <remarks>
    /// The primary ledger's certificate is registered when the client is constructed. Failover ledger
    /// certificates are fetched from the (independently trusted) identity service and registered lazily
    /// the first time the client fails over to that ledger. Because every certificate in this store was
    /// obtained from the trusted identity service. Each endpoint-specific transport validates only
    /// against the certificate registered for that endpoint's ledger id, so adding a failover ledger
    /// does not widen the trust accepted for any other endpoint.
    /// <para>
    /// A CCF network periodically rotates its identity TLS certificate. When the certificate presented
    /// during the TLS handshake no longer chains to the pinned certificate, the store re-queries the
    /// (independently trusted) identity service for that ledger, replaces the pin with the freshly
    /// retrieved certificate, and re-validates once. Refreshing from the same trusted source that
    /// produced the original pin keeps validation strict: a man-in-the-middle certificate still fails
    /// because it cannot chain to the identity service's current certificate.
    /// </para>
    /// </remarks>
    internal sealed class ConfidentialLedgerCertificateTrustStore
    {
        // Minimum time between identity-service lookups for the same ledger. This throttles the refresh
        // so a persistently mismatched certificate (for example a man-in-the-middle) cannot force an
        // identity-service round trip on every TLS handshake.
        private static readonly TimeSpan DefaultRefreshCooldown = TimeSpan.FromSeconds(30);

        private readonly bool _verifyConnection;
        private readonly Func<Uri, X509Certificate2> _certificateRefresher;
        private readonly ConcurrentDictionary<string, X509Certificate2> _trustedCerts =
            new ConcurrentDictionary<string, X509Certificate2>(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, Uri> _ledgerEndpoints =
            new ConcurrentDictionary<string, Uri>(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, DateTimeOffset> _lastRefreshUtc =
            new ConcurrentDictionary<string, DateTimeOffset>(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, object> _refreshLocks =
            new ConcurrentDictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        /// <param name="verifyConnection"> Whether server certificate validation is enforced. </param>
        /// <param name="certificateRefresher">
        /// Optional callback that fetches the current identity TLS certificate for a ledger endpoint from
        /// the independently trusted identity service. When supplied, a validation miss triggers a single
        /// throttled refresh-and-revalidate. When <c>null</c>, the store validates only against the
        /// certificates registered via <see cref="Trust"/>.
        /// </param>
        public ConfidentialLedgerCertificateTrustStore(bool verifyConnection, Func<Uri, X509Certificate2> certificateRefresher = null)
        {
            _verifyConnection = verifyConnection;
            _certificateRefresher = certificateRefresher;
        }

        /// <summary>
        /// Minimum interval between identity-service refresh attempts for the same ledger. Exposed for
        /// testing; defaults to 30 seconds.
        /// </summary>
        internal TimeSpan RefreshCooldown { get; set; } = DefaultRefreshCooldown;

        /// <summary> Registers a ledger identity TLS certificate as trusted, keyed by ledger id. </summary>
        /// <param name="ledgerId"> The ledger id the certificate authenticates. </param>
        /// <param name="certificate"> The pinned identity TLS certificate. </param>
        /// <param name="endpoint">
        /// The ledger endpoint, recorded so the certificate can later be refreshed from the identity
        /// service if the ledger rotates it. When <c>null</c>, refresh is unavailable for this ledger.
        /// </param>
        public void Trust(string ledgerId, X509Certificate2 certificate, Uri endpoint = null)
        {
            if (certificate != null && !string.IsNullOrEmpty(ledgerId))
            {
                _trustedCerts.AddOrUpdate(ledgerId, certificate, (_, existing) =>
                    existing.RawData.SequenceEqual(certificate.RawData) ? existing : certificate);
                if (endpoint != null)
                {
                    _ledgerEndpoints[ledgerId] = endpoint;
                }
            }
        }

        /// <summary> Returns whether a certificate for the given ledger id has already been registered. </summary>
        public bool IsTrusted(string ledgerId) =>
            !string.IsNullOrEmpty(ledgerId) && _trustedCerts.ContainsKey(ledgerId);

        /// <summary>
        /// Validation callback used by an endpoint-specific transport. Returns <c>true</c> when the presented
        /// server certificate chain terminates in the certificate registered for <paramref name="ledgerId"/>. When
        /// connection verification is disabled the callback always succeeds.
        /// </summary>
        /// <remarks>
        /// If the presented certificate does not chain to the currently pinned certificate, the ledger may
        /// have rotated its identity certificate. In that case the store performs a single throttled refresh
        /// from the independently trusted identity service and re-validates against the refreshed certificate.
        /// </remarks>
        public bool Validate(string ledgerId, X509Certificate2 presented)
        {
            if (!_verifyConnection)
            {
                return true;
            }
            if (presented == null || string.IsNullOrEmpty(ledgerId))
            {
                return false;
            }
            if (_trustedCerts.TryGetValue(ledgerId, out X509Certificate2 trusted) && IsChainRootedIn(presented, trusted))
            {
                return true;
            }

            // The pinned certificate did not match. The ledger's identity certificate may have rotated, so
            // refresh it from the independently trusted identity service and re-validate once.
            return TryRefreshAndValidate(ledgerId, presented);
        }

        private bool TryRefreshAndValidate(string ledgerId, X509Certificate2 presented)
        {
            if (_certificateRefresher == null || !_ledgerEndpoints.TryGetValue(ledgerId, out Uri endpoint))
            {
                return false;
            }

            // Serialize refreshes per ledger so concurrent handshakes coalesce into a single identity-service
            // lookup instead of stampeding it.
            object gate = _refreshLocks.GetOrAdd(ledgerId, _ => new object());
            lock (gate)
            {
                // Another thread may have refreshed the pin while this one waited for the lock.
                if (_trustedCerts.TryGetValue(ledgerId, out X509Certificate2 current) && IsChainRootedIn(presented, current))
                {
                    return true;
                }

                // Throttle identity-service lookups so a persistently mismatched certificate cannot force a
                // refresh on every TLS handshake.
                if (_lastRefreshUtc.TryGetValue(ledgerId, out DateTimeOffset last) &&
                    DateTimeOffset.UtcNow - last < RefreshCooldown)
                {
                    return false;
                }

                try
                {
                    X509Certificate2 refreshed = _certificateRefresher(endpoint);
                    _lastRefreshUtc[ledgerId] = DateTimeOffset.UtcNow;
                    if (refreshed == null)
                    {
                        return false;
                    }
                    Trust(ledgerId, refreshed, endpoint);
                    return IsChainRootedIn(presented, refreshed);
                }
                catch
                {
                    // An identity-service lookup failure must not accept the connection; preserve the
                    // validation failure and record the attempt so the throttle applies.
                    _lastRefreshUtc[ledgerId] = DateTimeOffset.UtcNow;
                    return false;
                }
            }
        }

        private static bool IsChainRootedIn(X509Certificate2 presented, X509Certificate2 trusted)
        {
            if (presented.RawData.SequenceEqual(trusted.RawData))
            {
                return true;
            }
            using var certificateChain = new X509Chain();
            // Revocation is not required by CCF. Hence revocation checks must be skipped to avoid validation failing unnecessarily.
            certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            // Add the ledger identity TLS certificate to the ExtraStore.
            certificateChain.ChainPolicy.ExtraStore.Add(trusted);
            // AllowUnknownCertificateAuthority extends trust to the ExtraStore, which contains the trusted
            // ledger identity TLS certificate, so chains terminating in it can validate.
            certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            certificateChain.ChainPolicy.VerificationTime = DateTime.Now;

            if (!certificateChain.Build(presented))
            {
                return false;
            }

            // Ensure the chain is rooted in the trusted ledger identity TLS certificate (not merely chain-valid).
            X509Certificate2 rootCert = certificateChain.ChainElements[certificateChain.ChainElements.Count - 1].Certificate;
            return rootCert.RawData.SequenceEqual(trusted.RawData);
        }
    }
}
