// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Reservations
{
    // Justification: These public extension methods mirror the mockable-resource customizations so
    // SubscriptionResource and TenantResource keep the GA shortcut and options-bag overloads while
    // still forwarding through mockable resources for testability.
    public static partial class ReservationsExtensions
    {
        /// <summary>
        /// Get the details of a `ReservationOrder`.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ReservationOrder_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-11-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="reservationOrderId"> Order Id of the reservation. </param>
        /// <param name="expand"> May be used to expand planInformation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static Task<Response<ReservationOrderResource>> GetReservationOrderAsync(this TenantResource tenantResource, Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableReservationsTenantResource(tenantResource).GetReservationOrderAsync(reservationOrderId, expand, cancellationToken);
        }

        /// <summary>
        /// Get the details of a `ReservationOrder`.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ReservationOrder_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-11-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="reservationOrderId"> Order Id of the reservation. </param>
        /// <param name="expand"> May be used to expand planInformation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static Response<ReservationOrderResource> GetReservationOrder(this TenantResource tenantResource, Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableReservationsTenantResource(tenantResource).GetReservationOrder(reservationOrderId, expand, cancellationToken);
        }

        /// <summary>
        /// Get the regions and skus that are available for RI purchase for the specified Azure subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.Capacity/catalogs. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Reservations_GetCatalog. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-11-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="reservedResourceType"> The type of the resource for which the skus should be provided. </param>
        /// <param name="location"> Filters the skus based on the location specified in this parameter. This can be an azure region or global. </param>
        /// <param name="publisherId"> Publisher id used to get the third party products. </param>
        /// <param name="offerId"> Offer id used to get the third party products. </param>
        /// <param name="planId"> Plan id used to get the third party products. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Azure.ResourceManager.Reservations.Models.ReservationCatalog" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<Models.ReservationCatalog> GetCatalogAsync(this SubscriptionResource subscriptionResource, string reservedResourceType, AzureLocation? location, string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableReservationsSubscriptionResource(subscriptionResource).GetCatalogAsync(reservedResourceType, location, publisherId, offerId, planId, cancellationToken);
        }

        /// <summary>
        /// Get the regions and skus that are available for RI purchase for the specified Azure subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.Capacity/catalogs. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Reservations_GetCatalog. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-11-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="reservedResourceType"> The type of the resource for which the skus should be provided. </param>
        /// <param name="location"> Filters the skus based on the location specified in this parameter. This can be an azure region or global. </param>
        /// <param name="publisherId"> Publisher id used to get the third party products. </param>
        /// <param name="offerId"> Offer id used to get the third party products. </param>
        /// <param name="planId"> Plan id used to get the third party products. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Azure.ResourceManager.Reservations.Models.ReservationCatalog" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<Models.ReservationCatalog> GetCatalog(this SubscriptionResource subscriptionResource, string reservedResourceType, AzureLocation? location, string publisherId, string offerId, string planId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableReservationsSubscriptionResource(subscriptionResource).GetCatalog(reservedResourceType, location, publisherId, offerId, planId, cancellationToken);
        }

        /// <summary>
        /// Get the regions and skus that are available for RI purchase for the specified Azure subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.Capacity/catalogs. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Reservations_GetCatalog. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-11-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="options"> The options to apply to the catalog request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Azure.ResourceManager.Reservations.Models.ReservationCatalog" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<Models.ReservationCatalog> GetCatalogAsync(this SubscriptionResource subscriptionResource, Models.SubscriptionResourceGetCatalogOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableReservationsSubscriptionResource(subscriptionResource).GetCatalogAsync(options, cancellationToken);
        }

        /// <summary>
        /// Get the regions and skus that are available for RI purchase for the specified Azure subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.Capacity/catalogs. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Reservations_GetCatalog. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-11-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="options"> The options to apply to the catalog request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Azure.ResourceManager.Reservations.Models.ReservationCatalog" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<Models.ReservationCatalog> GetCatalog(this SubscriptionResource subscriptionResource, Models.SubscriptionResourceGetCatalogOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableReservationsSubscriptionResource(subscriptionResource).GetCatalog(options, cancellationToken);
        }

        /// <summary>
        /// List the reservations and the roll up counts of reservations group by provisioning states that the user has access to in the current tenant.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Capacity/reservations. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ReservationOperationGroup_ListAll. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-11-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="options"> The options to apply to the reservation details request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ReservationDetailResource> GetReservationDetailsAsync(this TenantResource tenantResource, Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableReservationsTenantResource(tenantResource).GetReservationDetailsAsync(options, cancellationToken);
        }

        /// <summary>
        /// List the reservations and the roll up counts of reservations group by provisioning states that the user has access to in the current tenant.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Capacity/reservations. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ReservationOperationGroup_ListAll. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-11-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="options"> The options to apply to the reservation details request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ReservationDetailResource> GetReservationDetails(this TenantResource tenantResource, Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableReservationsTenantResource(tenantResource).GetReservationDetails(options, cancellationToken);
        }
    }
}
