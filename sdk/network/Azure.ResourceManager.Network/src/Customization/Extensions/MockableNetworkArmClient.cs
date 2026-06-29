// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Mocking
{
    /// <summary> Compatibility declaration for the MockableNetworkArmClient type. </summary>
    public partial class MockableNetworkArmClient
    {
        /// <summary> Invokes the GetVirtualMachineScaleSetNetworkResource compatibility operation. </summary>
        public virtual global::Azure.ResourceManager.Network.VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(global::Azure.Core.ResourceIdentifier p0)
            => new global::Azure.ResourceManager.Network.VirtualMachineScaleSetNetworkResource(Client, p0);
        /// <summary> Invokes the GetVirtualMachineScaleSetVmNetworkResource compatibility operation. </summary>
        public virtual global::Azure.ResourceManager.Network.VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(global::Azure.Core.ResourceIdentifier p0)
            => new global::Azure.ResourceManager.Network.VirtualMachineScaleSetVmNetworkResource(Client, p0);
    }
}
