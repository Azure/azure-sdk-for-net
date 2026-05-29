// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers that pass BillingTransferDetailCreateOrUpdateContent.
    // The new MPG generator renamed the payload to InitiateTransferRequest; this shim translates the
    // GA aggregate to the generated request type and forwards.
    public partial class BillingTransferDetailCollection
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="BillingTransferDetailCreateOrUpdateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingTransferDetailResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string transferName, BillingTransferDetailCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            var request = new InitiateTransferRequest { RecipientEmailId = content?.RecipientEmailId };
            return await CreateOrUpdateAsync(waitUntil, transferName, request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="BillingTransferDetailCreateOrUpdateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingTransferDetailResource> CreateOrUpdate(WaitUntil waitUntil, string transferName, BillingTransferDetailCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            var request = new InitiateTransferRequest { RecipientEmailId = content?.RecipientEmailId };
            return CreateOrUpdate(waitUntil, transferName, request, cancellationToken);
        }
    }
}
