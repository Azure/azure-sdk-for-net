// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the FirewallPolicyCollection type. </summary>
    [CodeGenSuppress("CreateOrUpdateAsync", typeof(WaitUntil), typeof(string), typeof(FirewallPolicyData), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdate", typeof(WaitUntil), typeof(string), typeof(FirewallPolicyData), typeof(CancellationToken))]
    public partial class FirewallPolicyCollection
    {
        /// <summary> Creates or updates the specified Firewall Policy. </summary>
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<FirewallPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string firewallPolicyName, FirewallPolicyData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, firewallPolicyName, data, afcManagedSync: default, cancellationToken);

        /// <summary> Creates or updates the specified Firewall Policy. </summary>
        [ForwardsClientCalls]
        public virtual ArmOperation<FirewallPolicyResource> CreateOrUpdate(WaitUntil waitUntil, string firewallPolicyName, FirewallPolicyData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, firewallPolicyName, data, afcManagedSync: default, cancellationToken);
    }
}
