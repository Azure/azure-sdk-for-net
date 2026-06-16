// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class CapacityReservationPatch
    {
        // Backward compatibility: the generated Compute-local property is named AssociatedVirtualMachineResources and
        // uses ComputeSubResourceData. Restore the old VirtualMachinesAssociated property with ARM common SubResource.
        /// <summary> A list of all virtual machine resource ids that are associated with the capacity reservation. </summary>
        public IReadOnlyList<SubResource> VirtualMachinesAssociated => AssociatedVirtualMachineResources?.Select(value => ResourceManagerModelFactory.SubResource(value.Id)).ToArray();
    }
}
