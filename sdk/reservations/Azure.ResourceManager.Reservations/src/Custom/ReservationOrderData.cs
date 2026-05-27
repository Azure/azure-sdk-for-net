// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Reservations
{
    public partial class ReservationOrderData
    {
        // Customization is required to restore the GA public surface from the new generator's
        // flattened-properties IList<T> shape back to the previously exposed IReadOnlyList<T> shape.
        /// <summary> Gets the reservations. </summary>
        public IReadOnlyList<ReservationDetailData> Reservations
        {
            get
            {
                return Properties is null ? default : (IReadOnlyList<ReservationDetailData>)Properties.Reservations;
            }
        }
    }
}
