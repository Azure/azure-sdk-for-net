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
    /// obtained from the trusted identity service, widening the set does not weaken certificate pinning:
    /// the transport still only accepts certificate chains that terminate in one of these explicitly
    /// trusted ledger identity certificates.
    /// </remarks>
    internal sealed class ConfidentialLedgerCertificateTrustStore
    {
        private readonly bool _verifyConnection;
        private readonly ConcurrentDictionary<string, X509Certificate2> _trustedCerts =
            new ConcurrentDictionary<string, X509Certificate2>(StringComparer.OrdinalIgnoreCase);

        public ConfidentialLedgerCertificateTrustStore(bool verifyConnection)
        {
            _verifyConnection = verifyConnection;
        }

        /// <summary> Registers a ledger identity TLS certificate as trusted, keyed by ledger id. </summary>
        public void Trust(string ledgerId, X509Certificate2 certificate)
        {
            if (certificate != null && !string.IsNullOrEmpty(ledgerId))
            {
                _trustedCerts.TryAdd(ledgerId, certificate);
            }
        }

        /// <summary> Returns whether a certificate for the given ledger id has already been registered. </summary>
        public bool IsTrusted(string ledgerId) =>
            !string.IsNullOrEmpty(ledgerId) && _trustedCerts.ContainsKey(ledgerId);

        /// <summary>
        /// Validation callback used by the transport. Returns <c>true</c> when the presented server
        /// certificate chain terminates in one of the trusted ledger identity certificates. When
        /// connection verification is disabled the callback always succeeds.
        /// </summary>
        public bool Validate(X509Certificate2 presented)
        {
            if (!_verifyConnection)
            {
                return true;
            }
            if (presented == null)
            {
                return false;
            }

            foreach (X509Certificate2 trusted in _trustedCerts.Values)
            {
                if (IsChainRootedIn(presented, trusted))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsChainRootedIn(X509Certificate2 presented, X509Certificate2 trusted)
        {
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
