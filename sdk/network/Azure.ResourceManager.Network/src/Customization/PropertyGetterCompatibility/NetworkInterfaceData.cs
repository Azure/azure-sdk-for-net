// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkInterfaceData type. </summary>
    public partial class NetworkInterfaceData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.NetworkInterfaceIPConfigurationData> IPConfigurations => IpConfigurations;
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource VirtualMachine
        {
            get => VirtualMachineId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = VirtualMachineId };
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
