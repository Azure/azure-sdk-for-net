// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    public partial class BillingAccountCollection
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingAccountResource> GetAllAsync(BillingAccountCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(expand: options?.Expand, filter: options?.Filter, includeAll: options?.IncludeAll, includeAllWithoutBillingProfiles: options?.IncludeAllWithoutBillingProfiles, includeDeleted: options?.IncludeDeleted, includePendingAgreement: options?.IncludePendingAgreement, includeResellee: options?.IncludeResellee, legalOwnerOID: options?.LegalOwnerOID, legalOwnerTID: options?.LegalOwnerTID, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingAccountResource> GetAll(BillingAccountCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAll(expand: options?.Expand, filter: options?.Filter, includeAll: options?.IncludeAll, includeAllWithoutBillingProfiles: options?.IncludeAllWithoutBillingProfiles, includeDeleted: options?.IncludeDeleted, includePendingAgreement: options?.IncludePendingAgreement, includeResellee: options?.IncludeResellee, legalOwnerOID: options?.LegalOwnerOID, legalOwnerTID: options?.LegalOwnerTID, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }
    }
}
