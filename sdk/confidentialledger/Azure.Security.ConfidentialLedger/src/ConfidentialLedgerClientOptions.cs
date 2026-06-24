// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

[assembly: CodeGenSuppressType("ConfidentialLedgerClientOptions")]
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
        public bool VerifyConnection { get; set; }

        /// <summary>
        /// When set to <c>true</c>, <see cref="ConfidentialLedgerClient.GetCurrentLedgerEntry(string, RequestContext)"/> (and its async
        /// variant) will automatically fall back to a historical range query when the requested collection's latest entry is no longer
        /// available in the live key-value store because it was archived (pruned) by the service. In that case the most recent entry for
        /// the collection is retrieved from the ledger history and returned as if it were the current entry.
        /// </summary>
        /// <remarks>
        /// This mirrors the service-side collection pruning feature: when a ledger is configured to prune (archive) old collections, the
        /// <c>GetCurrentLedgerEntry</c> endpoint returns <c>404 Not Found</c> for a pruned collection. With this option enabled the client
        /// transparently performs a historical query for the collection and returns its latest committed entry. Defaults to <c>false</c>
        /// so callers must explicitly opt in.
        /// </remarks>
        public bool EnableArchivedCollectionFallback { get; set; }

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
