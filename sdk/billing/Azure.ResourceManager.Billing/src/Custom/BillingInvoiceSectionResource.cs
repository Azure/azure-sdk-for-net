// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers that pass an Options aggregate.
    // The new MPG generator emits methods with individual query parameters and
    // renamed scope-qualified names (Get*ByInvoiceSection*); these shims forward
    // the aggregate to the generated method so existing call sites keep working.
    public partial class BillingInvoiceSectionResource
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingRequestResource> GetBillingRequestsAsync(BillingInvoiceSectionResourceGetBillingRequestsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByInvoiceSectionAsync(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingRequestResource> GetBillingRequests(BillingInvoiceSectionResourceGetBillingRequestsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByInvoiceSection(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingSubscriptionData> GetBillingSubscriptionsAsync(BillingInvoiceSectionResourceGetBillingSubscriptionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByInvoiceSectionAsync(options?.IncludeDeleted, options?.Expand, options?.Filter, options?.OrderBy, options?.Top, options?.Skip, options?.Count, options?.Search, cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingSubscriptionData> GetBillingSubscriptions(BillingInvoiceSectionResourceGetBillingSubscriptionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByInvoiceSection(options?.IncludeDeleted, options?.Expand, options?.Filter, options?.OrderBy, options?.Top, options?.Skip, options?.Count, options?.Search, cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingProductResource> GetProductsAsync(BillingInvoiceSectionResourceGetProductsOptions options, CancellationToken cancellationToken = default)
        {
            return GetProductsAsync(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingProductResource> GetProducts(BillingInvoiceSectionResourceGetProductsOptions options, CancellationToken cancellationToken = default)
        {
            return GetProducts(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingTransactionData> GetTransactionsAsync(BillingInvoiceSectionResourceGetTransactionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByInvoiceSectionAsync(options.PeriodStartDate, options.PeriodEndDate, options.Type, filter: options.Filter, orderBy: options.OrderBy, maxCount: options.Top, skip: options.Skip, count: options.Count, search: options.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingTransactionData> GetTransactions(BillingInvoiceSectionResourceGetTransactionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByInvoiceSection(options.PeriodStartDate, options.PeriodEndDate, options.Type, filter: options.Filter, orderBy: options.OrderBy, maxCount: options.Top, skip: options.Skip, count: options.Count, search: options.Search, cancellationToken: cancellationToken);
        }
    }
}
