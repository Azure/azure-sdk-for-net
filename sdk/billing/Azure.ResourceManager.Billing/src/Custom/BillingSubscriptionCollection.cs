// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers. Two distinct root causes:
    //   1. The new MPG generator emits GetAll with individual query parameters; this
    //      shim forwards the GA Options aggregate to the generated method.
    //   2. The new MPG generator added an optional `expand` parameter to Get/Exists/
    //      GetIfExists and a host of query parameters to GetAll; ApiCompat treats the
    //      new optional-param signatures as different members, so explicit overloads
    //      matching the GA shape are required for source-compat (no behavior change).
    public partial class BillingSubscriptionCollection
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingSubscriptionResource> GetAllAsync(BillingSubscriptionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(count: options?.Count, expand: options?.Expand, filter: options?.Filter, includeDeleted: options?.IncludeDeleted, includeFailed: options?.IncludeFailed, includeTenantSubscriptions: options?.IncludeTenantSubscriptions, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingSubscriptionResource> GetAll(BillingSubscriptionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAll(count: options?.Count, expand: options?.Expand, filter: options?.Filter, includeDeleted: options?.IncludeDeleted, includeFailed: options?.IncludeFailed, includeTenantSubscriptions: options?.IncludeTenantSubscriptions, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }
    }
}
