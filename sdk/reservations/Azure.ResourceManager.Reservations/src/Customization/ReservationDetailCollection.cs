// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed Guid-typed overloads for reservationId. The new TypeSpec-based generator
// emits string-typed parameters; these partial methods preserve the legacy Guid API surface by
// forwarding to the generated string-based methods. GetRevisions(Guid) was a collection-level entry
// point in GA but in the new SDK lives on ReservationDetailResource; we synthesize a resource here
// to invoke it without a network round-trip.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public partial class ReservationDetailCollection
    {
        public virtual Task<Response<ReservationDetailResource>> GetAsync(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => GetAsync(reservationId.ToString(), expand, cancellationToken);

        public virtual Response<ReservationDetailResource> Get(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => Get(reservationId.ToString(), expand, cancellationToken);

        public virtual Task<Response<bool>> ExistsAsync(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => ExistsAsync(reservationId.ToString(), expand, cancellationToken);

        public virtual Response<bool> Exists(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => Exists(reservationId.ToString(), expand, cancellationToken);

        public virtual Task<NullableResponse<ReservationDetailResource>> GetIfExistsAsync(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(reservationId.ToString(), expand, cancellationToken);

        public virtual NullableResponse<ReservationDetailResource> GetIfExists(Guid reservationId, string expand = default, CancellationToken cancellationToken = default)
            => GetIfExists(reservationId.ToString(), expand, cancellationToken);

        /// <summary> List revisions of a reservation. </summary>
        public virtual AsyncPageable<ReservationDetailResource> GetRevisionsAsync(Guid reservationId, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier detailId = ReservationDetailResource.CreateResourceIdentifier(Id.Name, reservationId.ToString());
            ReservationDetailResource detail = Client.GetReservationDetailResource(detailId);
            return detail.GetRevisionsAsync(cancellationToken);
        }

        /// <summary> List revisions of a reservation. </summary>
        public virtual Pageable<ReservationDetailResource> GetRevisions(Guid reservationId, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier detailId = ReservationDetailResource.CreateResourceIdentifier(Id.Name, reservationId.ToString());
            ReservationDetailResource detail = Client.GetReservationDetailResource(detailId);
            return detail.GetRevisions(cancellationToken);
        }
    }
}
