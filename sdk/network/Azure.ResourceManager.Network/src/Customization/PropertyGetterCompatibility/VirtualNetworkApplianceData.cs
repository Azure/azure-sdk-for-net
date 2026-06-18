// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkApplianceData type. </summary>
    public partial class VirtualNetworkApplianceData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.VirtualNetworkApplianceIPConfiguration> IPConfigurations => default;
    }
}
