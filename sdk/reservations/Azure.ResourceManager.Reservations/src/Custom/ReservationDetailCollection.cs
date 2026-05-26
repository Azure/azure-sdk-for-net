// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Reservations
{
    // Justification: GA exposed item-level Get/Exists/GetIfExists and GetRevisions(Guid) on
    // ReservationDetailCollection. The TypeSpec generator only emits list operations here and places
    // revisions on ReservationDetailResource, so these shims preserve the GA collection surface.
    public partial class ReservationDetailCollection
    {
        /// <summary> List revisions of a reservation. </summary>
        public virtual AsyncPageable<ReservationDetailResource> GetRevisionsAsync(Guid reservationId, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier detailId = new ResourceIdentifier($"{Id}/reservations/{reservationId}");
            ReservationDetailResource detail = Client.GetReservationDetailResource(detailId);
            return detail.GetRevisionsAsync(cancellationToken);
        }

        /// <summary> List revisions of a reservation. </summary>
        public virtual Pageable<ReservationDetailResource> GetRevisions(Guid reservationId, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier detailId = new ResourceIdentifier($"{Id}/reservations/{reservationId}");
            ReservationDetailResource detail = Client.GetReservationDetailResource(detailId);
            return detail.GetRevisions(cancellationToken);
        }
    }
}
