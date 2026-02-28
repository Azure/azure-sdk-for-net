// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Hci.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    [CodeGenSuppress("ProvisioningState")]
    public partial class HciClusterSecuritySettingData
    {
        /// <summary> Provisioning state. </summary>
        [WirePath("properties.provisioningState")]
        public HciProvisioningState? ProvisioningState { get; set; }
    }
}
