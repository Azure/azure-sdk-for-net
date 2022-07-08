// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    // This type is here to change the model name from VmssData to VirtualMachineScaleSetData
    [CodeGenType("VmssData")]
    public partial class VirtualMachineScaleSetData
    {
    }
}
