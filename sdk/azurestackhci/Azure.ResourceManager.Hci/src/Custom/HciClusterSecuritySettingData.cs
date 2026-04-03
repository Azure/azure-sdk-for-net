// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Hci.Models;

namespace Azure.ResourceManager.Hci
{
    // Backward compat: the generator excludes ProvisioningState from SecuritySetting's
    // flattened properties. The old SDK exposed it as a read-write property.
    public partial class HciClusterSecuritySettingData
    {
        /// <summary> Provisioning state. </summary>
        [WirePath("properties.provisioningState")]
        public HciProvisioningState? ProvisioningState { get; set; }
    }
}
