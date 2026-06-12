// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class NetworkWatcherResource
    {
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.SecurityGroupViewResult> GetVmSecurityRules(global::Azure.WaitUntil p0, global::Azure.ResourceManager.Network.Models.SecurityGroupViewContent p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.SecurityGroupViewResult>> GetVmSecurityRulesAsync(global::Azure.WaitUntil p0, global::Azure.ResourceManager.Network.Models.SecurityGroupViewContent p1, global::System.Threading.CancellationToken p2) => default;
    }
}
