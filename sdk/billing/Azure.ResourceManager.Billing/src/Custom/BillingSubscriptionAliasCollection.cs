// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers. Two distinct root causes:
    //   1. The MPG generator emits GetAll with individual query parameters
    //      (includeDeleted, filter, orderBy, top, skip, count, search); this
    //      shim forwards the GA Options aggregate to the generated method.
    //   2. The new GetAll added optional query parameters; ApiCompat treats the
    //      new signature as different from the GA parameter-less GetAll, so an
    //      explicit (CancellationToken) overload is required for source-compat.
    public partial class BillingSubscriptionAliasCollection
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingSubscriptionAliasResource> GetAllAsync(BillingSubscriptionAliasCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(count: options?.Count, filter: options?.Filter, includeDeleted: options?.IncludeDeleted, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingSubscriptionAliasResource> GetAll(BillingSubscriptionAliasCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAll(count: options?.Count, filter: options?.Filter, includeDeleted: options?.IncludeDeleted, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat parameterless overload for GA 1.2.2 callers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingSubscriptionAliasResource> GetAllAsync(CancellationToken cancellationToken)
        {
            return GetAllAsync(includeDeleted: default, filter: default, orderBy: default, maxCount: default, skip: default, count: default, search: default, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat parameterless overload for GA 1.2.2 callers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingSubscriptionAliasResource> GetAll(CancellationToken cancellationToken)
        {
            return GetAll(includeDeleted: default, filter: default, orderBy: default, maxCount: default, skip: default, count: default, search: default, cancellationToken: cancellationToken);
        }
    }
}
