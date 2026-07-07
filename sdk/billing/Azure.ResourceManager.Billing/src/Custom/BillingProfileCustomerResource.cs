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
    public partial class BillingProfileCustomerResource
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingRequestResource> GetBillingRequestsAsync(BillingProfileCustomerResourceGetBillingRequestsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomerAsync(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingRequestResource> GetBillingRequests(BillingProfileCustomerResourceGetBillingRequestsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomer(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingSubscriptionData> GetBillingSubscriptionsAsync(BillingProfileCustomerResourceGetBillingSubscriptionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomerAsync(options?.IncludeDeleted, options?.Expand, options?.Filter, options?.OrderBy, options?.Top, options?.Skip, options?.Count, options?.Search, cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingSubscriptionData> GetBillingSubscriptions(BillingProfileCustomerResourceGetBillingSubscriptionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomer(options?.IncludeDeleted, options?.Expand, options?.Filter, options?.OrderBy, options?.Top, options?.Skip, options?.Count, options?.Search, cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingTransactionData> GetTransactionsAsync(BillingProfileCustomerResourceGetTransactionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomerAsync(options.PeriodStartDate, options.PeriodEndDate, options.Type, filter: options.Filter, orderBy: options.OrderBy, maxCount: options.Top, skip: options.Skip, count: options.Count, search: options.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingTransactionData> GetTransactions(BillingProfileCustomerResourceGetTransactionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByCustomer(options.PeriodStartDate, options.PeriodEndDate, options.Type, filter: options.Filter, orderBy: options.OrderBy, maxCount: options.Top, skip: options.Skip, count: options.Count, search: options.Search, cancellationToken: cancellationToken);
        }
    }
}
