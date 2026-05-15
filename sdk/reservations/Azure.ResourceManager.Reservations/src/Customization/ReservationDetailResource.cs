// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
