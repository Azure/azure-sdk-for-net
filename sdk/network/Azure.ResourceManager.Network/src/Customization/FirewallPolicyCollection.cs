// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class FirewallPolicyCollection
    {
        // Preserve the 1.15.0 signature; native generation adds optional afcManagedSync.
        // Require cancellationToken to avoid ambiguity with that overload, and forward the flag's default.
        /// <summary> Creates or updates the specified Firewall Policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<FirewallPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string firewallPolicyName, FirewallPolicyData data, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, firewallPolicyName, data, afcManagedSync: default, cancellationToken);

        // Preserve the synchronous 1.15.0 signature alongside the native afcManagedSync overload.
        // Require cancellationToken to avoid overload ambiguity, and forward the flag's default.
        /// <summary> Creates or updates the specified Firewall Policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<FirewallPolicyResource> CreateOrUpdate(WaitUntil waitUntil, string firewallPolicyName, FirewallPolicyData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, firewallPolicyName, data, afcManagedSync: default, cancellationToken);
    }
}
