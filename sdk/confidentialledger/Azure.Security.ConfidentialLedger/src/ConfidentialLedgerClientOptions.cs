// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.ConfidentialLedger
{
    public partial class ConfidentialLedgerClientOptions : ClientOptions
    {
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
    }
}
