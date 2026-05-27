// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.Reservations
{
    // Justification: GA exposed item-level GetRevisions(Guid) on ReservationDetailCollection.
    // The TypeSpec generator only emits revisions on ReservationDetailResource, so these shims preserve the GA collection surface.
    public partial class ReservationDetailCollection
    {
         /// <summary>
        /// List of all the revisions for the `Reservation`.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}/revisions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Reservation_ListRevisions</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ReservationDetailResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reservationId"> Id of the reservation item. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ReservationDetailResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReservationDetailResource> GetRevisionsAsync(Guid reservationId, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier detailId = new ResourceIdentifier($"{Id}/reservations/{reservationId}");
            ReservationDetailResource detail = Client.GetReservationDetailResource(detailId);
            return detail.GetRevisionsAsync(cancellationToken);
        }

        /// <summary>
        /// List of all the revisions for the `Reservation`.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}/revisions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Reservation_ListRevisions</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ReservationDetailResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="reservationId"> Id of the reservation item. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ReservationDetailResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReservationDetailResource> GetRevisions(Guid reservationId, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier detailId = new ResourceIdentifier($"{Id}/reservations/{reservationId}");
            ReservationDetailResource detail = Client.GetReservationDetailResource(detailId);
            return detail.GetRevisions(cancellationToken);
        }
    }
}
