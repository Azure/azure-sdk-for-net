// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VirtualApplianceNetworkInterfaceConfiguration type. </summary>
    public partial class VirtualApplianceNetworkInterfaceConfiguration
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.VirtualApplianceIPConfiguration> VirtualApplianceNetworkInterfaceIPConfigurations { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.VirtualApplianceIPConfiguration>();
    }
}
