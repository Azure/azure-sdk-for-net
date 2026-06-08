// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class DedicatedHostPatch
    {
        // Backward compatibility: the generated Compute-local property is named VirtualMachineResources and uses
        // ComputeSubResourceData. Restore the old VirtualMachines property with ARM common SubResource.
        /// <summary> A list of references to all virtual machines in the dedicated host. </summary>
        public IReadOnlyList<SubResource> VirtualMachines => VirtualMachineResources.ToSubResources();
    }
}
