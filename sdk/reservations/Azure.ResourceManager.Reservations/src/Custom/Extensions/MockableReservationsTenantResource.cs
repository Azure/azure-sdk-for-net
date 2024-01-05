// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.ResourceManager.Reservations.Models;

namespace Azure.ResourceManager.Reservations.Mocking
{
    public partial class MockableReservationsTenantResource : ArmResource
    {
        /// <summary>
        /// List the reservations and the roll up counts of reservations group by provisioning states that the user has access to in the current tenant.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Capacity/reservations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Reservation_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> May be used to filter by reservation properties. The filter supports &apos;eq&apos;, &apos;or&apos;, and &apos;and&apos;. It does not currently support &apos;ne&apos;, &apos;gt&apos;, &apos;le&apos;, &apos;ge&apos;, or &apos;not&apos;. Reservation properties include sku/name, properties/{appliedScopeType, archived, displayName, displayProvisioningState, effectiveDateTime, expiryDate, provisioningState, quantity, renew, reservedResourceType, term, userFriendlyAppliedScopeType, userFriendlyRenewState}. </param>
        /// <param name="orderby"> May be used to sort order by reservation properties. </param>
        /// <param name="refreshSummary"> To indicate whether to refresh the roll up counts of the reservations group by provisioning states. </param>
        /// <param name="skiptoken"> The number of reservations to skip from the list before returning results. </param>
        /// <param name="selectedState"> The selected provisioning state. </param>
        /// <param name="take"> To number of reservations to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReservationDetailResource> GetReservationDetailsAsync(string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = null, string selectedState = null, float? take = null, CancellationToken cancellationToken = default)
        {
            TenantResourceGetReservationDetailsOptions options = new TenantResourceGetReservationDetailsOptions();
            options.Filter = filter;
            options.Orderby = orderby;
            options.RefreshSummary = refreshSummary;
            options.Skiptoken = skiptoken;
            options.SelectedState = selectedState;
            options.Take = take;

            return GetReservationDetailsAsync(options, cancellationToken);
        }

        /// <summary>
        /// List the reservations and the roll up counts of reservations group by provisioning states that the user has access to in the current tenant.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Capacity/reservations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Reservation_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> May be used to filter by reservation properties. The filter supports &apos;eq&apos;, &apos;or&apos;, and &apos;and&apos;. It does not currently support &apos;ne&apos;, &apos;gt&apos;, &apos;le&apos;, &apos;ge&apos;, or &apos;not&apos;. Reservation properties include sku/name, properties/{appliedScopeType, archived, displayName, displayProvisioningState, effectiveDateTime, expiryDate, provisioningState, quantity, renew, reservedResourceType, term, userFriendlyAppliedScopeType, userFriendlyRenewState}. </param>
        /// <param name="orderby"> May be used to sort order by reservation properties. </param>
        /// <param name="refreshSummary"> To indicate whether to refresh the roll up counts of the reservations group by provisioning states. </param>
        /// <param name="skiptoken"> The number of reservations to skip from the list before returning results. </param>
        /// <param name="selectedState"> The selected provisioning state. </param>
        /// <param name="take"> To number of reservations to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReservationDetailResource> GetReservationDetails(string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = null, string selectedState = null, float? take = null, CancellationToken cancellationToken = default)
        {
            TenantResourceGetReservationDetailsOptions options = new TenantResourceGetReservationDetailsOptions();
            options.Filter = filter;
            options.Orderby = orderby;
            options.RefreshSummary = refreshSummary;
            options.Skiptoken = skiptoken;
            options.SelectedState = selectedState;
            options.Take = take;

            return GetReservationDetails(options, cancellationToken);
        }
    }
}
