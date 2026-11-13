// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers that pass an Options aggregate.
    // The new MPG generator emits methods with individual query parameters and
    // renamed scope-qualified names (Get*ByBillingProfile*); these shims forward
    // the aggregate to the generated method so existing call sites keep working.
    public partial class BillingProfileResource
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingRequestResource> GetBillingRequestsAsync(BillingProfileResourceGetBillingRequestsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingProfileAsync(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingRequestResource> GetBillingRequests(BillingProfileResourceGetBillingRequestsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingProfile(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingInvoiceData> GetInvoicesAsync(BillingProfileResourceGetInvoicesOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingProfileAsync(options?.PeriodStartDate, options?.PeriodEndDate, options?.Filter, options?.OrderBy, options?.Top, options?.Skip, options?.Count, options?.Search, cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingInvoiceData> GetInvoices(BillingProfileResourceGetInvoicesOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingProfile(options?.PeriodStartDate, options?.PeriodEndDate, options?.Filter, options?.OrderBy, options?.Top, options?.Skip, options?.Count, options?.Search, cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingProductResource> GetProductsAsync(BillingProfileResourceGetProductsOptions options, CancellationToken cancellationToken = default)
        {
            return GetProductsAsync(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingProductResource> GetProducts(BillingProfileResourceGetProductsOptions options, CancellationToken cancellationToken = default)
        {
            return GetProducts(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingReservationResource> GetReservationsAsync(BillingProfileResourceGetReservationsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingProfileAsync(filter: options?.Filter, orderBy: options?.OrderBy, skiptoken: options?.Skiptoken, refreshSummary: options?.RefreshSummary, selectedState: options?.SelectedState, take: options?.Take, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingReservationResource> GetReservations(BillingProfileResourceGetReservationsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingProfile(filter: options?.Filter, orderBy: options?.OrderBy, skiptoken: options?.Skiptoken, refreshSummary: options?.RefreshSummary, selectedState: options?.SelectedState, take: options?.Take, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingTransactionData> GetTransactionsAsync(BillingProfileResourceGetTransactionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingProfileAsync(options.PeriodStartDate, options.PeriodEndDate, options.Type, filter: options.Filter, orderBy: options.OrderBy, maxCount: options.Top, skip: options.Skip, count: options.Count, search: options.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingTransactionData> GetTransactions(BillingProfileResourceGetTransactionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingProfile(options.PeriodStartDate, options.PeriodEndDate, options.Type, filter: options.Filter, orderBy: options.OrderBy, maxCount: options.Top, skip: options.Skip, count: options.Count, search: options.Search, cancellationToken: cancellationToken);
        }
    }
}
