// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the IpamPoolProperties type. </summary>
    public partial class IpamPoolProperties
    {
        /// <summary> Gets or sets the ProvisioningState compatibility property. </summary>
        public System.Nullable<Azure.ResourceManager.Network.Models.NetworkProvisioningState> ProvisioningState { get; set; }
    }
}
