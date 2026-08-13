// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // The generated name combines the full REST operation group and action names, which makes the
    // generated file path exceed the repository path-length limit on Windows. Rename this internal
    // pageable implementation to keep generated paths short without changing the public API.
    [CodeGenType("VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressesGetVirtualMachineScaleSetVMPublicIPAddressesAsyncCollectionResultOfT")]
    internal partial class VmssVmPublicIPAddressesAsyncCollectionResultOfT
    {
    }
}
