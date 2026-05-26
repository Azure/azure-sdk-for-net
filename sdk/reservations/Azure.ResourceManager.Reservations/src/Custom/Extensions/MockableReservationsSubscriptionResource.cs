// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Reservations.Models;

namespace Azure.ResourceManager.Reservations.Mocking
{
    // Justification: GA exposed direct GetQuotaRequestDetail and GetCatalog overloads on the
    // mockable subscription extension resource, including shorter and options-bag catalog overloads.
    // The TypeSpec generator emits collection or long-parameter methods, so these forwarders preserve
    // the GA convenience surface and mocking target.
    public partial class MockableReservationsSubscriptionResource
    {    /// <summary>
        /// Get the regions and skus that are available for RI purchase for the specified Azure subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Capacity/catalogs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GetCatalog</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reservedResourceType"> The type of the resource for which the skus should be provided. </param>
        /// <param name="location"> Filters the skus based on the location specified in this parameter. This can be an azure region or global. </param>
        /// <param name="publisherId"> Publisher id used to get the third party products. </param>
        /// <param name="offerId"> Offer id used to get the third party products. </param>
        /// <param name="planId"> Plan id used to get the third party products. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ReservationCatalog" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Models.ReservationCatalog> GetCatalogAsync(string reservedResourceType = null, AzureLocation? location = null, string publisherId = null, string offerId = null, string planId = null, CancellationToken cancellationToken = default)
            => GetCatalogAsync(reservedResourceType, location, publisherId, offerId, planId, filter: default, skip: default, take: default, cancellationToken);

         /// <summary>
        /// Get the regions and skus that are available for RI purchase for the specified Azure subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Capacity/catalogs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GetCatalog</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reservedResourceType"> The type of the resource for which the skus should be provided. </param>
        /// <param name="location"> Filters the skus based on the location specified in this parameter. This can be an azure region or global. </param>
        /// <param name="publisherId"> Publisher id used to get the third party products. </param>
        /// <param name="offerId"> Offer id used to get the third party products. </param>
        /// <param name="planId"> Plan id used to get the third party products. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationCatalog" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Models.ReservationCatalog> GetCatalog(string reservedResourceType = null, AzureLocation? location = null, string publisherId = null, string offerId = null, string planId = null, CancellationToken cancellationToken = default)
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
