// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Security.ConfidentialLedger.Certificate;

namespace Azure.Security.ConfidentialLedger.Models
{
    public static partial class ConfidentialLedgerModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Certificate.LedgerIdentityInformation"/>. </summary>
        /// <param name="ledgerId"> Id for the ledger. </param>
        /// <param name="ledgerTlsCertificate"> PEM-encoded certificate used for TLS by the Confidential Ledger. </param>
        /// <returns> A new <see cref="Certificate.LedgerIdentityInformation"/> instance for mocking. </returns>
        public static LedgerIdentityInformation LedgerIdentityInformation(string ledgerId = default, string ledgerTlsCertificate = default) =>
            new LedgerIdentityInformation(ledgerId, ledgerTlsCertificate, new Dictionary<string, System.BinaryData>());
    }
}
