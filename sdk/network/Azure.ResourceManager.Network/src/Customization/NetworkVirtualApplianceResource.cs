// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVirtualApplianceResource type. </summary>
    public partial class NetworkVirtualApplianceResource
    {
        /// <summary> Invokes the CreateOrUpdateInboundSecurityRule compatibility operation. </summary>
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.InboundSecurityRule> CreateOrUpdateInboundSecurityRule(global::Azure.WaitUntil p0, global::System.String p1, global::Azure.ResourceManager.Network.Models.InboundSecurityRule p2, global::System.Threading.CancellationToken p3) => default;
        /// <summary> Invokes the CreateOrUpdateInboundSecurityRuleAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.InboundSecurityRule>> CreateOrUpdateInboundSecurityRuleAsync(global::Azure.WaitUntil p0, global::System.String p1, global::Azure.ResourceManager.Network.Models.InboundSecurityRule p2, global::System.Threading.CancellationToken p3) => default;
    }
}
