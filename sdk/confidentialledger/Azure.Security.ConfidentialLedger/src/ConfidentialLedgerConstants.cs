// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// Constant values for Confidential Ledger.
    /// </summary>
    internal static class ConfidentialLedgerConstants
    {
        /// <summary>
        /// The header value containing the ledger transaction Id.
        /// </summary>
        public const string TransactionIdHeaderName = "x-ms-ccf-transaction-id";

        /// <summary>
        /// The header value containing the Web Frontend Gateway operation Id returned on a 202 Accepted
        /// response from <c>POST /app/transactions</c> when the write has been queued.
        /// </summary>
        public const string OperationIdHeaderName = "x-ms-webfe-operation-id";
    }
}
