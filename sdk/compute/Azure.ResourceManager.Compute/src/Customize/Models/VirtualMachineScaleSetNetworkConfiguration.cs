// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Compute.Models
{
    // Backward compatibility: this model previously inherited ComputeWriteableSubResourceData and its virtual Id property.
    // Without this base type, ApiCompat reports the removed base class and missing inherited Id accessors.
    public partial class VirtualMachineScaleSetNetworkConfiguration : ComputeWriteableSubResourceData
    {
    }
}
