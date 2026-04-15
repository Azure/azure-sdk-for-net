// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeQuotaRulePatch
    {
        /// <summary> Gets the provisioning state of the quota rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeQuotaRuleProvisioningState? VolumeQuotaRuleProvisioningState =>
            ProvisioningState.HasValue ? new NetAppVolumeQuotaRuleProvisioningState(ProvisioningState.Value.ToString()) : (NetAppVolumeQuotaRuleProvisioningState?)null;
    }
}
