// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers that pass an Options aggregate.
    // The new MPG generator emits methods with individual query parameters and
    // renamed scope-qualified names (Get*ByCustomer*); these shims forward the
    // aggregate to the generated method so existing call sites keep working.
    public partial class BillingCustomerResource
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingSubscriptionData> GetBillingSubscriptionsByCustomerAtBillingAccountAsync(BillingCustomerResourceGetBillingSubscriptionsByCustomerAtBillingAccountOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomerAtBillingAccountAsync(includeDeleted: options?.IncludeDeleted, expand: options?.Expand, filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingSubscriptionData> GetBillingSubscriptionsByCustomerAtBillingAccount(BillingCustomerResourceGetBillingSubscriptionsByCustomerAtBillingAccountOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomerAtBillingAccount(includeDeleted: options?.IncludeDeleted, expand: options?.Expand, filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingProductResource> GetProductsAsync(BillingCustomerResourceGetProductsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomerAsync(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingProductResource> GetProducts(BillingCustomerResourceGetProductsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomer(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }
    }
}
