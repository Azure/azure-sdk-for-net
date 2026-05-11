// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeQuotaRulePatch
    {
        public NetAppProvisioningState? ProvisioningState =>
            VolumeQuotaRuleProvisioningState.HasValue
                ? (NetAppProvisioningState?)System.Enum.Parse(typeof(NetAppProvisioningState), VolumeQuotaRuleProvisioningState.Value.ToString())
                : null;
    }
}
