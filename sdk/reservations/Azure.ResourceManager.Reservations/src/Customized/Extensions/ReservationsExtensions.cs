// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Reservations
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Reservations. </summary>
    public static partial class ReservationsExtensions
    {
        /// <summary>
        /// List the reservations and the roll up counts of reservations group by provisioning states that the user has access to in the current tenant.
        /// Request Path: /providers/Microsoft.Capacity/reservations
        /// Operation Id: Reservation_ListAll
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="filter"> May be used to filter by reservation properties. The filter supports &apos;eq&apos;, &apos;or&apos;, and &apos;and&apos;. It does not currently support &apos;ne&apos;, &apos;gt&apos;, &apos;le&apos;, &apos;ge&apos;, or &apos;not&apos;. Reservation properties include sku/name, properties/{appliedScopeType, archived, displayName, displayProvisioningState, effectiveDateTime, expiryDate, provisioningState, quantity, renew, reservedResourceType, term, userFriendlyAppliedScopeType, userFriendlyRenewState}. </param>
        /// <param name="orderby"> May be used to sort order by reservation properties. </param>
        /// <param name="refreshSummary"> To indicate whether to refresh the roll up counts of the reservations group by provisioning states. </param>
        /// <param name="skiptoken"> The number of reservations to skip from the list before returning results. </param>
        /// <param name="selectedState"> The selected provisioning state. </param>
        /// <param name="take"> To number of reservations to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ReservationDetailResource> GetReservationDetailsAsync(this TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = null, string selectedState = null, float? take = null, CancellationToken cancellationToken = default) =>
            GetReservationDetailsAsync(tenantResource, new ReservationsExtensionsGetReservationDetailsOptions
            {
                Filter = filter,
                Orderby = orderby,
                RefreshSummary = refreshSummary,
                Skiptoken = skiptoken,
                SelectedState = selectedState,
                Take = take
            }, cancellationToken);

        /// <summary>
        /// List the reservations and the roll up counts of reservations group by provisioning states that the user has access to in the current tenant.
        /// Request Path: /providers/Microsoft.Capacity/reservations
        /// Operation Id: Reservation_ListAll
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="filter"> May be used to filter by reservation properties. The filter supports &apos;eq&apos;, &apos;or&apos;, and &apos;and&apos;. It does not currently support &apos;ne&apos;, &apos;gt&apos;, &apos;le&apos;, &apos;ge&apos;, or &apos;not&apos;. Reservation properties include sku/name, properties/{appliedScopeType, archived, displayName, displayProvisioningState, effectiveDateTime, expiryDate, provisioningState, quantity, renew, reservedResourceType, term, userFriendlyAppliedScopeType, userFriendlyRenewState}. </param>
        /// <param name="orderby"> May be used to sort order by reservation properties. </param>
        /// <param name="refreshSummary"> To indicate whether to refresh the roll up counts of the reservations group by provisioning states. </param>
        /// <param name="skiptoken"> The number of reservations to skip from the list before returning results. </param>
        /// <param name="selectedState"> The selected provisioning state. </param>
        /// <param name="take"> To number of reservations to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ReservationDetailResource> GetReservationDetails(this TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = null, string selectedState = null, float? take = null, CancellationToken cancellationToken = default) =>
            GetReservationDetails(tenantResource, new ReservationsExtensionsGetReservationDetailsOptions
            {
                Filter = filter,
                Orderby = orderby,
                RefreshSummary = refreshSummary,
                Skiptoken = skiptoken,
                SelectedState = selectedState,
                Take = take
            }, cancellationToken);

        /// <summary>
        /// Get the regions and skus that are available for RI purchase for the specified Azure subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Capacity/catalogs
        /// Operation Id: GetCatalog
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="reservedResourceType"> The type of the resource for which the skus should be provided. </param>
        /// <param name="location"> Filters the skus based on the location specified in this parameter. This can be an azure region or global. </param>
        /// <param name="publisherId"> Publisher id used to get the third party products. </param>
        /// <param name="offerId"> Offer id used to get the third party products. </param>
        /// <param name="planId"> Plan id used to get the third party products. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ReservationCatalog" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ReservationCatalog> GetCatalogAsync(this SubscriptionResource subscriptionResource, string reservedResourceType = null, AzureLocation? location = null, string publisherId = null, string offerId = null, string planId = null, CancellationToken cancellationToken = default) =>
            GetCatalogAsync(subscriptionResource, new ReservationsExtensionsGetCatalogOptions
            {
                ReservedResourceType = reservedResourceType,
                Location = location,
                PublisherId = publisherId,
                OfferId = offerId,
                PlanId = planId
            }, cancellationToken);

        /// <summary>
        /// Get the regions and skus that are available for RI purchase for the specified Azure subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Capacity/catalogs
        /// Operation Id: GetCatalog
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="reservedResourceType"> The type of the resource for which the skus should be provided. </param>
        /// <param name="location"> Filters the skus based on the location specified in this parameter. This can be an azure region or global. </param>
        /// <param name="publisherId"> Publisher id used to get the third party products. </param>
        /// <param name="offerId"> Offer id used to get the third party products. </param>
        /// <param name="planId"> Plan id used to get the third party products. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationCatalog" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ReservationCatalog> GetCatalog(this SubscriptionResource subscriptionResource, string reservedResourceType = null, AzureLocation? location = null, string publisherId = null, string offerId = null, string planId = null, CancellationToken cancellationToken = default) =>
            GetCatalog(subscriptionResource, new ReservationsExtensionsGetCatalogOptions
            {
                ReservedResourceType = reservedResourceType,
                Location = location,
                PublisherId = publisherId,
                OfferId = offerId,
                PlanId = planId
            }, cancellationToken);
    }
}
