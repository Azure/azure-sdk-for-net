// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class AvailabilitySetData
    {
        // Backward compatibility: the generated Compute-local property is named VirtualMachineResources and uses
        // ComputeWriteableSubResourceData. Restore the old VirtualMachines property with ARM common WritableSubResource.
        /// <summary> A list of references to all virtual machines in the availability set. </summary>
        [Obsolete("This property is obsolete and no longer works. Use VirtualMachineResources instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> VirtualMachines { get; set; }
    }
}
