// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class NetworkInterfaceData
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.NetworkInterfaceIPConfigurationData> IPConfigurations => IpConfigurations;
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource VirtualMachine
        {
            get => VirtualMachineId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = VirtualMachineId };
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
