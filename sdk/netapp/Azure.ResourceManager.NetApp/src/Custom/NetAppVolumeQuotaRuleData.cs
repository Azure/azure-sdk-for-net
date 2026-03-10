// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppVolumeQuotaRuleData
    {
        public Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? ProvisioningState =>
            Properties?.ProvisioningState;
    }
}
