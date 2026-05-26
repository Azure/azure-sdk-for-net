// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Reservations.Mocking
{
    // Justification: GA exposed direct GetReservationOrder and options-bag GetReservationDetails
    // overloads on the mockable tenant extension resource. The TypeSpec generator emits collection
    // or long-parameter methods, so these forwarders preserve the GA convenience surface.
    public partial class MockableReservationsTenantResource
    {
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
        /// <param name="options"> The options to apply to the reservation details request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationDetailResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReservationDetailResource> GetReservationDetailsAsync(Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.TenantResourceGetReservationDetailsOptions();
            return GetReservationDetailsAsync(options.Filter, options.Orderby, options.RefreshSummary, options.Skiptoken, options.SelectedState, options.Take, cancellationToken);
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
        /// <param name="options"> The options to apply to the reservation details request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationDetailResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReservationDetailResource> GetReservationDetails(Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.TenantResourceGetReservationDetailsOptions();
            return GetReservationDetails(options.Filter, options.Orderby, options.RefreshSummary, options.Skiptoken, options.SelectedState, options.Take, cancellationToken);
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
        /// <param name="reservationOrderId"> Order Id of the reservation. </param>
        /// <param name="expand"> May be used to expand planInformation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Task<Response<ReservationOrderResource>> GetReservationOrderAsync(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationOrders().GetAsync(reservationOrderId, expand, cancellationToken);

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
        /// <param name="reservationOrderId"> Order Id of the reservation. </param>
        /// <param name="expand"> May be used to expand planInformation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<ReservationOrderResource> GetReservationOrder(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationOrders().Get(reservationOrderId, expand, cancellationToken);
    }
}
