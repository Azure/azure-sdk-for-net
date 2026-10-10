// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class AvailabilitySetPatch
    {
        // Backward compatibility: the generated Compute-local property is named VirtualMachineResources and uses
        // ComputeWriteableSubResourceData. Restore the old VirtualMachines property with ARM common WritableSubResource.
        /// <summary> A list of references to all virtual machines in the availability set. </summary>
        [Obsolete("This property is obsolete and no longer works. Use VirtualMachineResources instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        // Compatibility placeholder only; this property is not wired to VirtualMachineResources.
        public IList<WritableSubResource> VirtualMachines { get; set; }
    }
}
