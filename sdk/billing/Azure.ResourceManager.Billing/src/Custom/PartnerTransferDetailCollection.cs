// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers that pass PartnerTransferDetailCreateOrUpdateContent.
    // The new MPG generator renamed the payload to PartnerInitiateTransferRequest; this shim translates
    // the GA aggregate to the generated request type and forwards.
    public partial class PartnerTransferDetailCollection
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="PartnerTransferDetailCreateOrUpdateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<PartnerTransferDetailResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string transferName, PartnerTransferDetailCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            var request = new PartnerInitiateTransferRequest
            {
                RecipientEmailId = content?.RecipientEmailId,
                ResellerId = content?.ResellerId,
            };
            return await CreateOrUpdateAsync(waitUntil, transferName, request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass <see cref="PartnerTransferDetailCreateOrUpdateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PartnerTransferDetailResource> CreateOrUpdate(WaitUntil waitUntil, string transferName, PartnerTransferDetailCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            var request = new PartnerInitiateTransferRequest
            {
                RecipientEmailId = content?.RecipientEmailId,
                ResellerId = content?.ResellerId,
            };
            return CreateOrUpdate(waitUntil, transferName, request, cancellationToken);
        }
    }
}
