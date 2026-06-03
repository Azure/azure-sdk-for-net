// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers that pass an Options aggregate.
    // The new MPG generator emits methods with individual query parameters and
    // renamed scope-qualified names (Get*ByBillingProfile*); these shims forward
    // the aggregate to the generated method so existing call sites keep working.
    //
    // Also: workaround for MPG generator bug #59540. The shared
    // ProductsGetProductsCollectionResultOfT ctor expects an invoiceSectionName
    // parameter (because the same operation is reachable from BillingInvoiceSection),
    // but the BillingProfile call site omits it (CS7036). The [CodeGenSuppress]-ed
    // GetProducts{Async}(filter, orderBy, ...) overloads are replaced below by
    // hand-written equivalents that pass null for invoiceSectionName.
    // TODO: remove the [CodeGenSuppress] attributes + replacement methods once
    //       #59540 ships and the next regen no longer emits the broken call.
    // Back-compat overloads for GA 1.2.2 callers that pass an Options aggregate.
    // The new MPG generator emits methods with individual query parameters and
    // renamed scope-qualified names (Get*ByBillingProfile*); these shims forward
    // the aggregate to the generated method so existing call sites keep working.
    //
    // Also: workaround for MPG generator bug #59540. The shared
    // ProductsGetProductsCollectionResultOfT ctor expects an invoiceSectionName
    // parameter (because the same operation is reachable from BillingInvoiceSection),
    // but the BillingProfile call site omits it (CS7036). The [CodeGenSuppress]-ed
    // GetProducts{Async}(filter, orderBy, ...) overloads are replaced below by
    // hand-written equivalents that pass null for invoiceSectionName.
    // TODO: remove the [CodeGenSuppress] attributes + replacement methods once
    //       #59540 ships and the next regen no longer emits the broken call.
    [CodeGenSuppress("GetProductsAsync", typeof(string), typeof(string), typeof(long?), typeof(long?), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetProducts", typeof(string), typeof(string), typeof(long?), typeof(long?), typeof(bool?), typeof(string), typeof(CancellationToken))]
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

        // ---------- Replacements for generator-emitted methods whose ctor call site
        //            for the shared ProductsGetProducts(Async)CollectionResultOfT
        //            omits the invoiceSectionName parameter (#59540).
        //            Bodies are byte-for-byte copies of the generator output with
        //            invoiceSectionName: null inserted between billingProfileName and filter.

        /// <summary> Lists the products for a billing profile. These don't include products billed based on usage. The operation is supported for billing accounts with agreement type Microsoft Customer Agreement or Microsoft Partner Agreement. </summary>
        public virtual AsyncPageable<BillingProductResource> GetProductsAsync(string filter = default, string orderBy = default, long? maxCount = default, long? skip = default, bool? count = default, string search = default, CancellationToken cancellationToken = default)
        {
            Azure.RequestContext context = new Azure.RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<BillingProductData, BillingProductResource>(new ProductsGetProductsAsyncCollectionResultOfT(
                _productsRestClient,
                Id.Parent.Name,
                Id.Name,
                null,
                filter,
                orderBy,
                maxCount,
                skip,
                count,
                search,
                context,
                "BillingProfileResource.GetProducts"), data => new BillingProductResource(Client, data));
        }

        /// <summary> Lists the products for a billing profile. These don't include products billed based on usage. The operation is supported for billing accounts with agreement type Microsoft Customer Agreement or Microsoft Partner Agreement. </summary>
        public virtual Pageable<BillingProductResource> GetProducts(string filter = default, string orderBy = default, long? maxCount = default, long? skip = default, bool? count = default, string search = default, CancellationToken cancellationToken = default)
        {
            Azure.RequestContext context = new Azure.RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<BillingProductData, BillingProductResource>(new ProductsGetProductsCollectionResultOfT(
                _productsRestClient,
                Id.Parent.Name,
                Id.Name,
                null,
                filter,
                orderBy,
                maxCount,
                skip,
                count,
                search,
                context,
                "BillingProfileResource.GetProducts"), data => new BillingProductResource(Client, data));
        }
    }
}
