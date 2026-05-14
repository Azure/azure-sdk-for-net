// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed CreateResourceIdentifier(Guid reservationOrderId, Guid reservationId).
// The new TypeSpec-based generator emits only the string-typed overload; this partial method
// preserves the legacy Guid API surface.

using System;
using Azure.Core;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    public partial class ReservationDetailResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(Guid reservationOrderId, Guid reservationId)
            => CreateResourceIdentifier(reservationOrderId.ToString(), reservationId.ToString());
    }
}
