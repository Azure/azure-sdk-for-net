// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Security.ConfidentialLedger.Models;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary> The ConfidentialLedger service client. </summary>
    public partial class ConfidentialLedgerClient
    {
        /// <summary> Gets the status of an entry identified by a transaction id. </summary>

        public virtual async Task<Response<TransactionReceipt>> GetReceiptValueAsync(string transactionId, CancellationToken cancellationToken = default)
        {
            Response response = await GetReceiptAsync(transactionId, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);

            TransactionReceipt value = TransactionReceipt.FromResponse(response);

            return Response.FromValue(value, response);
        }

        /// <summary> Gets the status of an entry identified by a transaction id. </summary>
        public virtual Response<TransactionReceipt> GetReceiptValue(string transactionId, CancellationToken cancellationToken = default)
        {
            Response response = GetReceipt(transactionId, new RequestContext { CancellationToken = cancellationToken });

            TransactionReceipt value = TransactionReceipt.FromResponse(response);

            return Response.FromValue(value, response);
        }
    }
}
