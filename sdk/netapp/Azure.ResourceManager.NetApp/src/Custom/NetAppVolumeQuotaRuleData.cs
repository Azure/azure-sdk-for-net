// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppVolumeQuotaRuleData
    {
        /// <summary> Gets the provisioning state of the quota rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeQuotaRuleProvisioningState? VolumeQuotaRuleProvisioningState =>
            ProvisioningState.HasValue ? new NetAppVolumeQuotaRuleProvisioningState(ProvisioningState.Value.ToString()) : (NetAppVolumeQuotaRuleProvisioningState?)null;
    }
}
