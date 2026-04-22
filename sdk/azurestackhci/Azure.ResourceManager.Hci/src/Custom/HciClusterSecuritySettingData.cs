// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Hci.Models;

namespace Azure.ResourceManager.Hci
{
    // The old SDK exposed it as a read-write property, the property is marked as read-only in TypeSpec.
    public partial class HciClusterSecuritySettingData
    {
        /// <summary> Provisioning state. </summary>
        [WirePath("properties.provisioningState")]
        public HciProvisioningState? ProvisioningState { get; set; }
    }
}
