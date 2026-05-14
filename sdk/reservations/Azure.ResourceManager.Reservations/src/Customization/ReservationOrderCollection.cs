// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed Guid-typed overloads for reservationOrderId on the
// ReservationOrderCollection (Get/Exists/GetIfExists/CreateOrUpdate). The new TypeSpec-based
// generator emits string-typed parameters; these partial methods preserve the legacy Guid API
// surface by forwarding to the generated string-based methods.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Reservations.Models;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public partial class ReservationOrderCollection
    {
        public virtual Task<ArmOperation<ReservationOrderResource>> CreateOrUpdateAsync(WaitUntil waitUntil, Guid reservationOrderId, ReservationPurchaseContent content, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, reservationOrderId.ToString(), content, cancellationToken);

        public virtual ArmOperation<ReservationOrderResource> CreateOrUpdate(WaitUntil waitUntil, Guid reservationOrderId, ReservationPurchaseContent content, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, reservationOrderId.ToString(), content, cancellationToken);

        public virtual Task<Response<ReservationOrderResource>> GetAsync(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetAsync(reservationOrderId.ToString(), expand, cancellationToken);

        public virtual Response<ReservationOrderResource> Get(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => Get(reservationOrderId.ToString(), expand, cancellationToken);

        public virtual Task<Response<bool>> ExistsAsync(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => ExistsAsync(reservationOrderId.ToString(), expand, cancellationToken);

        public virtual Response<bool> Exists(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => Exists(reservationOrderId.ToString(), expand, cancellationToken);

        public virtual Task<NullableResponse<ReservationOrderResource>> GetIfExistsAsync(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(reservationOrderId.ToString(), expand, cancellationToken);

        public virtual NullableResponse<ReservationOrderResource> GetIfExists(Guid reservationOrderId, string expand = default, CancellationToken cancellationToken = default)
            => GetIfExists(reservationOrderId.ToString(), expand, cancellationToken);
    }
}
