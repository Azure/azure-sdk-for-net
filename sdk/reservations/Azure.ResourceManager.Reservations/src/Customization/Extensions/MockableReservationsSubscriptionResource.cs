// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Mocking
{
    // Justification: GA exposed direct GetQuotaRequestDetail and GetCatalog overloads on the
    // mockable subscription extension resource, including shorter and options-bag catalog overloads.
    // The TypeSpec generator emits collection or long-parameter methods, so these forwarders preserve
    // the GA convenience surface and mocking target.
    public partial class MockableReservationsSubscriptionResource
    {
        [ForwardsClientCalls]
        public virtual Task<Response<QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(string providerId, AzureLocation location, Guid id, CancellationToken cancellationToken = default)
            => GetQuotaRequestDetails(providerId, location).GetAsync(id, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<QuotaRequestDetailResource> GetQuotaRequestDetail(string providerId, AzureLocation location, Guid id, CancellationToken cancellationToken = default)
            => GetQuotaRequestDetails(providerId, location).Get(id, cancellationToken);

        public virtual AsyncPageable<Models.ReservationCatalog> GetCatalogAsync(string reservedResourceType, AzureLocation? location, string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
            => GetCatalogAsync(reservedResourceType, location, publisherId, offerId, planId, filter: default, skip: default, take: default, cancellationToken);

        public virtual Pageable<Models.ReservationCatalog> GetCatalog(string reservedResourceType, AzureLocation? location, string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
            => GetCatalog(reservedResourceType, location, publisherId, offerId, planId, filter: default, skip: default, take: default, cancellationToken);

        public virtual AsyncPageable<Models.ReservationCatalog> GetCatalogAsync(Models.SubscriptionResourceGetCatalogOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.SubscriptionResourceGetCatalogOptions();
            return GetCatalogAsync(options.ReservedResourceType, options.Location, options.PublisherId, options.OfferId, options.PlanId, options.Filter, options.Skip, options.Take, cancellationToken);
        }

        public virtual Pageable<Models.ReservationCatalog> GetCatalog(Models.SubscriptionResourceGetCatalogOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.SubscriptionResourceGetCatalogOptions();
            return GetCatalog(options.ReservedResourceType, options.Location, options.PublisherId, options.OfferId, options.PlanId, options.Filter, options.Skip, options.Take, cancellationToken);
        }
    }
}
