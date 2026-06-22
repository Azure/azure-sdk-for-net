// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.ResourceManager.Reservations
{
    // Justification: GA exposed CreateResourceIdentifier for direct construction of this resource
    // ID. The generated TypeSpec resource does not emit that helper, so this shim preserves the
    // public API and keeps the canonical ARM ID format in one place.
    public partial class ReservationDetailResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ReservationDetailResource"/> instance. </summary>
        /// <param name="reservationOrderId"> The reservationOrderId. </param>
        /// <param name="reservationId"> The reservationId. </param>
        public static ResourceIdentifier CreateResourceIdentifier(Guid reservationOrderId, Guid reservationId)
            => new ResourceIdentifier($"/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}");
    }
}
