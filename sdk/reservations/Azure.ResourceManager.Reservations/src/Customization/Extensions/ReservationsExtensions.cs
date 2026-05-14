// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed Guid-typed overloads for reservation order id and quota request id
// on the ReservationsExtensions class. The new TypeSpec-based generator emits only string-typed
// overloads; these partial methods preserve the legacy Guid API surface by forwarding to the
// generated string-based methods.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public static partial class ReservationsExtensions
    {
        [ForwardsClientCalls]
        public static Task<Response<QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(this SubscriptionResource subscriptionResource, string providerId, AzureLocation location, Guid id, CancellationToken cancellationToken = default)
            => GetQuotaRequestDetailAsync(subscriptionResource, providerId, location, id.ToString(), cancellationToken);

        [ForwardsClientCalls]
        public static Response<QuotaRequestDetailResource> GetQuotaRequestDetail(this SubscriptionResource subscriptionResource, string providerId, AzureLocation location, Guid id, CancellationToken cancellationToken = default)
            => GetQuotaRequestDetail(subscriptionResource, providerId, location, id.ToString(), cancellationToken);

        [ForwardsClientCalls]
        public static Task<Response<ReservationOrderResource>> GetReservationOrderAsync(this TenantResource tenantResource, Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationOrderAsync(tenantResource, reservationOrderId.ToString(), expand, cancellationToken);

        [ForwardsClientCalls]
        public static Response<ReservationOrderResource> GetReservationOrder(this TenantResource tenantResource, Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationOrder(tenantResource, reservationOrderId.ToString(), expand, cancellationToken);

        public static AsyncPageable<Models.ReservationCatalog> GetCatalogAsync(this SubscriptionResource subscriptionResource, string reservedResourceType, AzureLocation? location, string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
            => GetCatalogAsync(subscriptionResource, reservedResourceType, location, publisherId, offerId, planId, filter: default, skip: default, take: default, cancellationToken);

        public static Pageable<Models.ReservationCatalog> GetCatalog(this SubscriptionResource subscriptionResource, string reservedResourceType, AzureLocation? location, string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
            => GetCatalog(subscriptionResource, reservedResourceType, location, publisherId, offerId, planId, filter: default, skip: default, take: default, cancellationToken);

        public static AsyncPageable<Models.ReservationCatalog> GetCatalogAsync(this SubscriptionResource subscriptionResource, Models.SubscriptionResourceGetCatalogOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.SubscriptionResourceGetCatalogOptions();
            return GetCatalogAsync(subscriptionResource, options.ReservedResourceType, options.Location, options.PublisherId, options.OfferId, options.PlanId, options.Filter, options.Skip, options.Take, cancellationToken);
        }

        public static Pageable<Models.ReservationCatalog> GetCatalog(this SubscriptionResource subscriptionResource, Models.SubscriptionResourceGetCatalogOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.SubscriptionResourceGetCatalogOptions();
            return GetCatalog(subscriptionResource, options.ReservedResourceType, options.Location, options.PublisherId, options.OfferId, options.PlanId, options.Filter, options.Skip, options.Take, cancellationToken);
        }

        public static AsyncPageable<ReservationDetailResource> GetReservationDetailsAsync(this TenantResource tenantResource, Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.TenantResourceGetReservationDetailsOptions();
            return GetReservationDetailsAsync(tenantResource, options.Filter, options.Orderby, options.RefreshSummary, options.Skiptoken, options.SelectedState, options.Take, cancellationToken);
        }

        public static Pageable<ReservationDetailResource> GetReservationDetails(this TenantResource tenantResource, Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.TenantResourceGetReservationDetailsOptions();
            return GetReservationDetails(tenantResource, options.Filter, options.Orderby, options.RefreshSummary, options.Skiptoken, options.SelectedState, options.Take, cancellationToken);
        }
    }
}
