// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: GA exposed VolumeQuotaRuleProvisioningState (the legacy struct in
    // VolumeQuotaRuleProvisioningState.cs). The spec emits ProvisioningState (a unified
    // enum) so we forward the legacy property to it. Spec can't fix this because the two
    // names refer to *different* CLR types (a deprecated shim struct vs. the unified enum);
    // @@clientName cannot project a property to a different return type.
    public partial class NetAppVolumeQuotaRulePatch
    {
        /// <summary> Gets the provisioning state of the quota rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeQuotaRuleProvisioningState? VolumeQuotaRuleProvisioningState =>
            ProvisioningState.HasValue ? new NetAppVolumeQuotaRuleProvisioningState(ProvisioningState.Value.ToString()) : (NetAppVolumeQuotaRuleProvisioningState?)null;
    }
}
