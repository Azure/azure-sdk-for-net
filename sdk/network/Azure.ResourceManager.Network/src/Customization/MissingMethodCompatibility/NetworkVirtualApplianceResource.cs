// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVirtualApplianceResource
    {
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.InboundSecurityRule> CreateOrUpdateInboundSecurityRule(global::Azure.WaitUntil p0, global::System.String p1, global::Azure.ResourceManager.Network.Models.InboundSecurityRule p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.InboundSecurityRule>> CreateOrUpdateInboundSecurityRuleAsync(global::Azure.WaitUntil p0, global::System.String p1, global::Azure.ResourceManager.Network.Models.InboundSecurityRule p2, global::System.Threading.CancellationToken p3) => default;
    }
}
