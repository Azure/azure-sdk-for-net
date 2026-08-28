// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers that pass an Options aggregate.
    // The MPG generator emits GetAll with individual query parameters (filter,
    // orderBy, top, skip, count, search) per the OData query convention; these
    // hand-written shims forward the GA Options instance to the generated method
    // so existing call sites keep working.
    public partial class BillingRequestCollection
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingRequestResource> GetAllAsync(BillingRequestCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(count: options?.Count, filter: options?.Filter, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingRequestResource> GetAll(BillingRequestCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAll(count: options?.Count, filter: options?.Filter, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }
    }
}
