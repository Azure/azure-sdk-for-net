// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkArmClient
    {
        public virtual global::Azure.ResourceManager.Network.VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(global::Azure.Core.ResourceIdentifier p0)
            => new global::Azure.ResourceManager.Network.VirtualMachineScaleSetNetworkResource(Client, p0);
        public virtual global::Azure.ResourceManager.Network.VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(global::Azure.Core.ResourceIdentifier p0)
            => new global::Azure.ResourceManager.Network.VirtualMachineScaleSetVmNetworkResource(Client, p0);
    }
}
