// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class MigrateToVirtualMachineScaleSetInput
    {
        /// <summary> Initializes a new instance of <see cref="MigrateToVirtualMachineScaleSetInput"/>. </summary>
        /// <param name="virtualMachineScaleSetFlexible"> Specifies information about the Virtual Machine Scale Set that the Availability Set should be migrated to. </param>
        public MigrateToVirtualMachineScaleSetInput(WritableSubResource virtualMachineScaleSetFlexible)
        {
            if (virtualMachineScaleSetFlexible != null)
            {
                VirtualMachineScaleSetFlexible = new ComputeWriteableSubResourceData { Id = virtualMachineScaleSetFlexible.Id };
            }
        }
    }
}
