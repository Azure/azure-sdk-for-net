// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class IpamPoolProperties
    {
        // 1.15.0 and 1.17.0 shipped this setter. The native reader and read-only wire serializer still own this field.
        /// <summary> Gets or sets the provisioning state retained for compatibility. </summary>
        [CodeGenMember("ProvisioningState")]
        [WirePath("provisioningState")]
        public NetworkProvisioningState? ProvisioningState { get; set; }
    }
}
