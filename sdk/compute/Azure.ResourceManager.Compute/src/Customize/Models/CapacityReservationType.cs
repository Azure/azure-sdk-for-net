// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Compute.Models
{
    public readonly partial struct CapacityReservationType
    {
        /// <summary> Converts a <see cref="CapacityReservationType"/> to a <see cref="ReservationType"/>. </summary>
        public static implicit operator ReservationType(CapacityReservationType value) => new ReservationType(value.ToString());

        /// <summary> Converts a <see cref="ReservationType"/> to a <see cref="CapacityReservationType"/>. </summary>
        public static implicit operator CapacityReservationType(ReservationType value) => new CapacityReservationType(value.ToString());
    }
}
