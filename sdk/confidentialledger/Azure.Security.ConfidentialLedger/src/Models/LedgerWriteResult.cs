// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.ConfidentialLedger.Models
{
    public partial class LedgerWriteResult
    {
        /// <summary>
        /// Deserializes a create-ledger-entry response. The service returns the transaction id in the
        /// <c>x-ms-ccf-transaction-id</c> response header rather than in the body, so it is read from there.
        /// </summary>
        internal static LedgerWriteResult FromResponse(Response response)
        {
            LedgerWriteResult result = (LedgerWriteResult)response;
            response.Headers.TryGetValue(ConfidentialLedgerConstants.TransactionIdHeaderName, out string transactionId);
            return result.With(transactionId ?? result.TransactionId, result.CollectionId, result.State);
        }

        /// <summary>
        /// Attempts to deserialize a create-ledger-entry response body. Returns <see langword="null"/> when the
        /// response does not carry a write result (for example, an HTTP 202 from the Ledger Gateway).
        /// </summary>
        internal static LedgerWriteResult TryFromResponse(Response response)
        {
            if (response == null || response.Status != 200 || response.Content == null || response.Content.ToMemory().Length == 0)
            {
                return null;
            }

            try
            {
                return FromResponse(response);
            }
            catch (Exception e) when (e is JsonException || e is InvalidOperationException)
            {
                return null;
            }
        }

        internal LedgerWriteResult With(string transactionId, string collectionId, TransactionState state) =>
            new LedgerWriteResult(transactionId, collectionId, Receipt, state, ApplicationClaims, _additionalBinaryDataProperties);
    }
}
