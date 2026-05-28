// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Resources;
using System.Threading;

namespace Azure.ResourceManager.Reservations.Mocking
{
    public partial class MockableReservationsSubscriptionResource : ArmResource
    {
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
        /// <returns> An async collection of <see cref="ReservationCatalog" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReservationCatalog> GetCatalogAsync(string reservedResourceType = null, AzureLocation? location = null, string publisherId = null, string offerId = null, string planId = null, CancellationToken cancellationToken = default)
        {
            SubscriptionResourceGetCatalogOptions options = new SubscriptionResourceGetCatalogOptions
            {
                ReservedResourceType = reservedResourceType,
                Location = location,
                PublisherId = publisherId,
                OfferId = offerId,
                PlanId = planId
            };
            return GetCatalogAsync(options, cancellationToken);
        }

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
        public virtual Pageable<ReservationCatalog> GetCatalog(string reservedResourceType = null, AzureLocation? location = null, string publisherId = null, string offerId = null, string planId = null, CancellationToken cancellationToken = default)
        {
            SubscriptionResourceGetCatalogOptions options = new SubscriptionResourceGetCatalogOptions
            {
                ReservedResourceType = reservedResourceType,
                Location = location,
                PublisherId = publisherId,
                OfferId = offerId,
                PlanId = planId
            };
            return GetCatalog(options, cancellationToken);
        }
    }
}
