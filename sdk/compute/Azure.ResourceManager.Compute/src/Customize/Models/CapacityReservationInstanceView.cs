// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class CapacityReservationInstanceView
    {
        /// <summary> A list of all virtual machines resource ids allocated against the capacity reservation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<SubResource> UtilizationInfoVirtualMachinesAllocated
        {
            get => UtilizationInfo?.VirtualMachinesAllocated;
        }
    }
}
