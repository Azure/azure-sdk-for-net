// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: the new generator emits `ProvisioningState` (a unified enum) as the
    // primary, public, generated property — it is NOT hidden and NOT customized here.
    //
    // The shim below keeps the legacy v1.15 GA name `VolumeQuotaRuleProvisioningState`
    // (which used a deprecated string-struct, NetAppVolumeQuotaRuleProvisioningState in
    // VolumeQuotaRuleProvisioningState.cs) reachable for source-compat, but marks it
    // [EditorBrowsable(Never)] so IntelliSense steers callers to the better generated
    // `ProvisioningState` property. @@clientName cannot help because the two names refer
    // to *different* CLR types (legacy struct vs. unified enum) and projecting via
    // clientName would change the return type.
    public partial class NetAppVolumeQuotaRulePatch
    {
        /// <summary> Gets the provisioning state of the quota rule (legacy alias of <see cref="ProvisioningState"/>; prefer the latter). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeQuotaRuleProvisioningState? VolumeQuotaRuleProvisioningState =>
            ProvisioningState.HasValue ? new NetAppVolumeQuotaRuleProvisioningState(ProvisioningState.Value.ToString()) : (NetAppVolumeQuotaRuleProvisioningState?)null;
    }
}
