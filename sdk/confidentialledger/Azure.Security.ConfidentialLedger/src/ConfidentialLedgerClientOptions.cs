// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary> Client options for ConfidentialLedger library clients. </summary>
    public partial class ConfidentialLedgerClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2024_12_09_Preview;
        internal string Version { get; }

        /// <summary>
        /// The Identity Service URL. If not provided, the default endpoint "https://identity.confidential-ledger.core.azure.com" will be used.
        /// </summary>
        /// <value></value>
        public Uri CertificateEndpoint { get; set; }

        /// <summary>
        /// Boolean determining whether certificate validation will be performed to verify the ledger identity TLS certificate is valid.
        /// </summary>
        /// <value></value>
        public bool VerifyConnection { get; set; } = true;

        /// <summary>
        /// Set to <c>true</c> when targeting the Confidential Ledger Gateway.
        /// When enabled, the client skips the CCF identity-service TLS bootstrap (using standard
        /// Azure PKI for TLS validation) and disables primary-node caching in the redirect policy
        /// (the gateway may redirect to any healthy host, not a sticky primary). Authentication via
        /// client certificate (mTLS) is not supported in this mode; only bearer-token authentication
        /// is accepted by the gateway.
        /// </summary>
        /// <remarks>
        /// In Ledger Gateway mode, <c>POST /app/transactions</c> may return <c>202 Accepted</c> when
        /// the underlying CCF cluster is temporarily unreachable. The write is queued by the gateway
        /// (retained for the gateway's operation-record retention period) and the SDK exposes the long-running operation via the gateway
        /// operation id until it commits, at which point <see cref="Azure.Operation.Id"/> flips to
        /// the CCF transaction id. Because a queued operation may take hours to complete, callers
        /// are strongly encouraged to use <see cref="Azure.WaitUntil.Started"/>, persist
        /// <see cref="Azure.Operation.Id"/>, and resume polling later via
        /// <c>ConfidentialLedgerClient.RehydratePostLedgerEntryOperation</c>.
        /// </remarks>
        public bool UseLedgerGateway { get; set; }

        /// <summary>
        /// Controls whether a current-entry read transparently falls back to ledger history when a
        /// collection's live entry has been archived by collection pruning. Defaults to <c>false</c>.
        /// </summary>
        /// <remarks>
        /// This mirrors the service-side collection pruning feature: when a ledger is configured to prune (archive) old collections, the
        /// <c>GetCurrentLedgerEntry</c> endpoint returns <c>404 Not Found</c> for a pruned collection. With this option enabled the client
        /// transparently performs a historical query for the collection and returns its latest committed entry. Defaults to <c>false</c>
        /// because the service returns the same 404 for a pruned collection and a collection that never existed, and a historical query
        /// can be expensive on a ledger with a long transaction history. Set this option to <c>true</c> only when transparent access to
        /// archived collections is required.
        /// </remarks>
        public bool EnableArchivedCollectionFallback { get; set; }

        /// <summary>
        /// Controls the order in which a read request is retried against the ledger's failover endpoints
        /// when the primary ledger returns a transient failure. Defaults to <see cref="FailoverSelection.Ordered"/>,
        /// which preserves the order reported by the identity service. Use <see cref="FailoverSelection.Random"/>
        /// to shuffle the candidate endpoints and spread load across failover ledgers.
        /// </summary>
        public FailoverSelection Failover { get; set; } = FailoverSelection.Ordered;

        /// <summary>
        /// Optional per-attempt network timeout applied to each failover request. When set, every failover
        /// attempt is granted this network timeout, so that time already spent on the failed primary attempt
        /// does not consume the failover budget. When <c>null</c> the normal
        /// <see cref="Azure.Core.RetryOptions.NetworkTimeout"/> applies. Defaults to <c>null</c>.
        /// </summary>
        public TimeSpan? FailoverNetworkTimeout { get; set; }

        /// <summary> Strategy for ordering the failover endpoints that a read request is retried against. </summary>
        public enum FailoverSelection
        {
            /// <summary> Try failover endpoints in the order reported by the identity service (priority order). </summary>
            Ordered = 0,
            /// <summary> Try failover endpoints in a randomized order to spread load across failover ledgers. </summary>
            Random = 1,
        }

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2022-05-13". </summary>
            V2022_05_13 = 1,
            /// <summary> Service version "2024-01-26-preview". </summary>
            V2024_01_26_Preview = 2,
            /// <summary> Service version "2024-08-22-preview". </summary>
            V2024_08_22_Preview = 3,
            /// <summary> Service version "2024-12-09-preview". </summary>
            V2024_12_09_Preview = 4,
        }

        /// <summary> Initializes new instance of ConfidentialLedgerClientOptions. </summary>
        public ConfidentialLedgerClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2022_05_13 => "2022-05-13",
                ServiceVersion.V2024_01_26_Preview => "2024-01-26-preview",
                ServiceVersion.V2024_08_22_Preview => "2024-08-22-preview",
                ServiceVersion.V2024_12_09_Preview => "2024-12-09-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
