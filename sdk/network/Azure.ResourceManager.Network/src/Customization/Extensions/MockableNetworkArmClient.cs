// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkArmClient
    {
        // Retain the 1.15 virtual accessor for the custom VMSS facade, which the current generator no longer emits.
        // This constructs only a local resource handle; no HTTP request is made.
        /// <summary> Gets an object representing a virtual machine scale set with its network operations but no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetNetworkResource"/> object. </returns>
        public virtual VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(ResourceIdentifier id)
        {
            VirtualMachineScaleSetNetworkResource.ValidateResourceId(id);
            return new VirtualMachineScaleSetNetworkResource(Client, id);
        }

        // Retain the 1.15 virtual accessor for the custom VM facade, which the current generator no longer emits.
        // This constructs only a local resource handle; no HTTP request is made.
        /// <summary> Gets an object representing a virtual machine scale set virtual machine with its network operations but no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVmNetworkResource"/> object. </returns>
        public virtual VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(ResourceIdentifier id)
        {
            VirtualMachineScaleSetVmNetworkResource.ValidateResourceId(id);
            return new VirtualMachineScaleSetVmNetworkResource(Client, id);
        }
    }
}
