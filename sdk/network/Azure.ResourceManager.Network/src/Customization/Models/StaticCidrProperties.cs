// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class StaticCidrProperties
    {
        // The service marks this read-only; retain the setter shipped in 1.17.
        /// <summary> Provisioning states of a resource. </summary>
        [CodeGenMember("ProvisioningState")]
        public NetworkProvisioningState? ProvisioningState { get; set; }
    }
}
