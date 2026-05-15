// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public static partial class ReservationsExtensions
    {
        [ForwardsClientCalls]
        public static Task<Response<QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(this SubscriptionResource subscriptionResource, string providerId, AzureLocation location, Guid id, CancellationToken cancellationToken = default)
            => GetMockableReservationsSubscriptionResource(subscriptionResource).GetQuotaRequestDetailAsync(providerId, location, id, cancellationToken);

        [ForwardsClientCalls]
        public static Response<QuotaRequestDetailResource> GetQuotaRequestDetail(this SubscriptionResource subscriptionResource, string providerId, AzureLocation location, Guid id, CancellationToken cancellationToken = default)
            => GetMockableReservationsSubscriptionResource(subscriptionResource).GetQuotaRequestDetail(providerId, location, id, cancellationToken);

        [ForwardsClientCalls]
        public static Task<Response<ReservationOrderResource>> GetReservationOrderAsync(this TenantResource tenantResource, Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetMockableReservationsTenantResource(tenantResource).GetReservationOrderAsync(reservationOrderId, expand, cancellationToken);

        [ForwardsClientCalls]
        public static Response<ReservationOrderResource> GetReservationOrder(this TenantResource tenantResource, Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetMockableReservationsTenantResource(tenantResource).GetReservationOrder(reservationOrderId, expand, cancellationToken);

        public static AsyncPageable<Models.ReservationCatalog> GetCatalogAsync(this SubscriptionResource subscriptionResource, string reservedResourceType, AzureLocation? location, string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
            => GetMockableReservationsSubscriptionResource(subscriptionResource).GetCatalogAsync(reservedResourceType, location, publisherId, offerId, planId, cancellationToken);

        public static Pageable<Models.ReservationCatalog> GetCatalog(this SubscriptionResource subscriptionResource, string reservedResourceType, AzureLocation? location, string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
            => GetMockableReservationsSubscriptionResource(subscriptionResource).GetCatalog(reservedResourceType, location, publisherId, offerId, planId, cancellationToken);

        public static AsyncPageable<Models.ReservationCatalog> GetCatalogAsync(this SubscriptionResource subscriptionResource, Models.SubscriptionResourceGetCatalogOptions options, CancellationToken cancellationToken = default)
        {
            return GetMockableReservationsSubscriptionResource(subscriptionResource).GetCatalogAsync(options, cancellationToken);
        }

        public static Pageable<Models.ReservationCatalog> GetCatalog(this SubscriptionResource subscriptionResource, Models.SubscriptionResourceGetCatalogOptions options, CancellationToken cancellationToken = default)
        {
            return GetMockableReservationsSubscriptionResource(subscriptionResource).GetCatalog(options, cancellationToken);
        }

        public static AsyncPageable<ReservationDetailResource> GetReservationDetailsAsync(this TenantResource tenantResource, Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            return GetMockableReservationsTenantResource(tenantResource).GetReservationDetailsAsync(options, cancellationToken);
        }

        public static Pageable<ReservationDetailResource> GetReservationDetails(this TenantResource tenantResource, Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            return GetMockableReservationsTenantResource(tenantResource).GetReservationDetails(options, cancellationToken);
        }
    }
}
