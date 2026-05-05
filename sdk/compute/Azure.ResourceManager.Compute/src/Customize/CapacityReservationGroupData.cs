// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute
{
    public partial class CapacityReservationGroupData
    {
        /// <summary> A list of all capacity reservation instance views. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<Models.CapacityReservationInstanceViewWithName> InstanceViewCapacityReservations
        {
            get => InstanceView?.CapacityReservations;
        }
    }
}
