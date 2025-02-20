// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class CapacityReservationGroupData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<CapacityReservationInstanceViewWithName> InstanceViewCapacityReservations
        {
            get => InstanceView?.CapacityReservations;
        }
    }
}
