// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: GA exposed ProvisioningState. The spec now generates
    // VolumeQuotaRuleProvisioningState directly, so keep the old property as an alias.
    public partial class NetAppVolumeQuotaRulePatch
    {
        /// <summary> Gets the status of the VolumeQuotaRule at the time the operation was called. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppProvisioningState? ProvisioningState =>
            VolumeQuotaRuleProvisioningState.HasValue && Enum.TryParse<NetAppProvisioningState>(VolumeQuotaRuleProvisioningState.Value.ToString(), ignoreCase: true, out var provisioningState)
                ? provisioningState
                : null;
    }
}
