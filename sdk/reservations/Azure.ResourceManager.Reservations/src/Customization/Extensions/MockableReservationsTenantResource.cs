// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed Guid-typed overloads on the mockable tenant resource
// (GetReservationOrder(Guid, ...)). The new TypeSpec-based generator emits only the string-typed
// overload; this partial method preserves the legacy Guid API surface.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Mocking
{
    public partial class MockableReservationsTenantResource
    {
        [ForwardsClientCalls]
        public virtual Task<Response<ReservationOrderResource>> GetReservationOrderAsync(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationOrderAsync(reservationOrderId.ToString(), expand, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<ReservationOrderResource> GetReservationOrder(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetReservationOrder(reservationOrderId.ToString(), expand, cancellationToken);

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
