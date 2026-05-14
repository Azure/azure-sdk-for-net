// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed ReservationOrderData.Reservations as
// IReadOnlyList<ReservationDetailData>. The new generator emits IList<T> via the flattened
// ReservationOrderProperties; this shim restores the read-only collection surface.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    [CodeGenSuppress("Reservations")]
    public partial class ReservationOrderData
    {
        public IReadOnlyList<ReservationDetailData> Reservations
        {
            get
            {
                return Properties is null ? default : (IReadOnlyList<ReservationDetailData>)Properties.Reservations;
            }
        }
    }
}
