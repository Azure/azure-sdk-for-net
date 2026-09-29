// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVirtualApplianceConnectionData type. </summary>
    public partial class NetworkVirtualApplianceConnectionData
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.RoutingConfiguration ConnectionRoutingConfiguration { get; set; }
    }
}
