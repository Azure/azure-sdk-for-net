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
    // Justification: GA exposed direct GetReservationOrder and options-bag GetReservationDetails
    // overloads on the mockable tenant extension resource. The TypeSpec generator emits collection
    // or long-parameter methods, so these forwarders preserve the GA convenience surface.
    public partial class MockableReservationsTenantResource
    {
        [ForwardsClientCalls]
        public virtual Task<Response<ReservationOrderResource>> GetReservationOrderAsync(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationOrders().GetAsync(reservationOrderId, expand, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<ReservationOrderResource> GetReservationOrder(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationOrders().Get(reservationOrderId, expand, cancellationToken);

        public virtual AsyncPageable<ReservationDetailResource> GetReservationDetailsAsync(Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.TenantResourceGetReservationDetailsOptions();
            return GetReservationDetailsAsync(options.Filter, options.Orderby, options.RefreshSummary, options.Skiptoken, options.SelectedState, options.Take, cancellationToken);
        }

        public virtual Pageable<ReservationDetailResource> GetReservationDetails(Models.TenantResourceGetReservationDetailsOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new Models.TenantResourceGetReservationDetailsOptions();
            return GetReservationDetails(options.Filter, options.Orderby, options.RefreshSummary, options.Skiptoken, options.SelectedState, options.Take, cancellationToken);
        }
    }
}
