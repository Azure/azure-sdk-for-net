// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed CreateResourceIdentifier for direct construction of this resource
// ID. The generated TypeSpec resource does not emit that helper, so this shim preserves the
// public API and keeps the canonical ARM ID format in one place.

using System;
using Azure.Core;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public partial class ReservationDetailResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(Guid reservationOrderId, Guid reservationId)
            => new ResourceIdentifier($"/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}");
    }
}
