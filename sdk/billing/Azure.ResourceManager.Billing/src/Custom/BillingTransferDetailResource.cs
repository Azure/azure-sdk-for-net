// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    public partial class BillingTransferDetailResource
    {
        /// <summary>
        /// Update by full resource data is not supported by the service; transfer details
        /// are only mutated through the Initiate and Cancel actions. This overload exists to
        /// satisfy the auto-generated tag boilerplate.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<BillingTransferDetailResource>> UpdateAsync(WaitUntil waitUntil, BillingTransferDetailData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Updating BillingTransferDetailResource via the resource data envelope is not supported. Use Initiate or Cancel instead.");
        }

        /// <summary>
        /// Update by full resource data is not supported by the service; transfer details
        /// are only mutated through the Initiate and Cancel actions. This overload exists to
        /// satisfy the auto-generated tag boilerplate.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingTransferDetailResource> Update(WaitUntil waitUntil, BillingTransferDetailData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Updating BillingTransferDetailResource via the resource data envelope is not supported. Use Initiate or Cancel instead.");
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="BillingTransferDetailCreateOrUpdateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingTransferDetailResource>> UpdateAsync(WaitUntil waitUntil, BillingTransferDetailCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            var request = new InitiateTransferRequest { RecipientEmailId = content?.RecipientEmailId };
            return await UpdateAsync(waitUntil, request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="BillingTransferDetailCreateOrUpdateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingTransferDetailResource> Update(WaitUntil waitUntil, BillingTransferDetailCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            var request = new InitiateTransferRequest { RecipientEmailId = content?.RecipientEmailId };
            return Update(waitUntil, request, cancellationToken);
        }
    }
}
