// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    // Justification: GA exposed a ReservationRefundResult model factory entry. The new generator
    // no longer surfaces the underlying RefundResponse body type so this shim adds the missing
    // factory method.
    public static partial class ArmReservationsModelFactory
    {
        public static ReservationRefundResult ReservationRefundResult(string id = default, ReservationRefundResponseProperties properties = default)
        {
            return new ReservationRefundResult(id, properties);
        }
    }
}
