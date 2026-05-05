// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class CapacityReservationGroupPatch
    {
        /// <summary> A list of all capacity reservation instance views. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<CapacityReservationInstanceViewWithName> InstanceViewCapacityReservations
        {
            get => InstanceView?.CapacityReservations;
        }
    }
}
