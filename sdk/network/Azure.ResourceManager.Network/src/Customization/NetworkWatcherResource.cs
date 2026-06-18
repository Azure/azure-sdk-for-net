// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkWatcherResource type. </summary>
    public partial class NetworkWatcherResource
    {
        /// <summary> Invokes the GetVmSecurityRules compatibility operation. </summary>
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.SecurityGroupViewResult> GetVmSecurityRules(global::Azure.WaitUntil p0, global::Azure.ResourceManager.Network.Models.SecurityGroupViewContent p1, global::System.Threading.CancellationToken p2) => default;
        /// <summary> Invokes the GetVmSecurityRulesAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.SecurityGroupViewResult>> GetVmSecurityRulesAsync(global::Azure.WaitUntil p0, global::Azure.ResourceManager.Network.Models.SecurityGroupViewContent p1, global::System.Threading.CancellationToken p2) => default;
    }
}
