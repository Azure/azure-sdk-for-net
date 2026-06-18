// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VirtualNetworkApplianceIPConfiguration type. </summary>
    public partial class VirtualNetworkApplianceIPConfiguration
    {
        /// <summary> Gets or sets the Primary compatibility property. </summary>
        public System.Nullable<System.Boolean> Primary { get; set; }

        /// <summary> Gets or sets the PrivateIPAddress compatibility property. </summary>
        public System.String PrivateIPAddress { get; set; }

        /// <summary> Gets or sets the PrivateIPAddressVersion compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkIPVersion> PrivateIPAddressVersion { get; set; }

        /// <summary> Gets or sets the PrivateIPAllocationMethod compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get; set; }
    }
}
