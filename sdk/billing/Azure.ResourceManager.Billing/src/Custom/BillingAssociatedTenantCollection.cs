// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    public partial class BillingAssociatedTenantCollection
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingAssociatedTenantResource> GetAllAsync(BillingAssociatedTenantCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(count: options?.Count, filter: options?.Filter, includeRevoked: options?.IncludeRevoked, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingAssociatedTenantResource> GetAll(BillingAssociatedTenantCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAll(count: options?.Count, filter: options?.Filter, includeRevoked: options?.IncludeRevoked, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }
    }
}
