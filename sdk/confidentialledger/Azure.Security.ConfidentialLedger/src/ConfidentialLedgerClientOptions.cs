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
        public bool VerifyConnection { get; set; } = true;

        /// <summary>
        /// Set to <c>true</c> when targeting the Confidential Ledger Web Frontend Gateway.
        /// When enabled, the client skips the CCF identity-service TLS bootstrap (using standard
        /// Azure PKI for TLS validation) and disables primary-node caching in the redirect policy
        /// (the Web FE may redirect to any healthy host, not a sticky primary). Authentication via
        /// client certificate (mTLS) is not supported in this mode; only bearer-token authentication
        /// is accepted by the gateway.
        /// </summary>
        /// <remarks>
        /// In Web Frontend mode, <c>POST /app/transactions</c> may return <c>202 Accepted</c> when
        /// the underlying CCF cluster is temporarily unreachable. The write is queued by the gateway
        /// (with a 24-hour TTL) and the SDK exposes the long-running operation via the Web FE
        /// operation id until it commits, at which point <see cref="Azure.Operation.Id"/> flips to
        /// the CCF transaction id. Because a queued operation may take hours to complete, callers
        /// are strongly encouraged to use <see cref="Azure.WaitUntil.Started"/>, persist
        /// <see cref="Azure.Operation.Id"/>, and resume polling later via
        /// <c>ConfidentialLedgerClient.RehydratePostLedgerEntryOperation</c>.
        /// </remarks>
        public bool UseWebFrontend { get; set; }

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
