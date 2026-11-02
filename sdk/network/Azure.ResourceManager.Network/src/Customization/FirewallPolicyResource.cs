// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class FirewallPolicyResource
    {
        // Preserve the 1.15.0 name from FirewallPolicyDeployments_Deploy.
        // TypeSpec's FirewallPolicies.deploy generates DeployAsync on the same POST /deploy route.
        /// <summary> Deploys the firewall policy draft and child rule collection group drafts. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation> DeployFirewallPolicyDeploymentAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => DeployAsync(waitUntil, cancellationToken);

        // Preserve the 1.15.0 name from FirewallPolicyDeployments_Deploy.
        // TypeSpec's FirewallPolicies.deploy generates Deploy on the same POST /deploy route.
        /// <summary> Deploys the firewall policy draft and child rule collection group drafts. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation DeployFirewallPolicyDeployment(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => Deploy(waitUntil, cancellationToken);

        // This obsolete overload exists in 1.15.0 custom code, not its generated source.
        // Preserve its metadata and behavior by forwarding to the native collection PUT operation.
        /// <summary> Creates or updates the specified Firewall Policy. </summary>
        /// <param name="waitUntil"> Whether to wait for the operation to complete. </param>
        /// <param name="data"> Parameters supplied to the create or update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<FirewallPolicyResource>> UpdateAsync(WaitUntil waitUntil, FirewallPolicyData data, CancellationToken cancellationToken = default)
            => new FirewallPolicyCollection(Client, Id.Parent).CreateOrUpdateAsync(waitUntil, Id.Name, data, cancellationToken);

        // Preserve the synchronous obsolete overload from 1.15.0 custom code.
        // The native collection PUT operation supplies the original create/update behavior.
        /// <summary> Creates or updates the specified Firewall Policy. </summary>
        /// <param name="waitUntil"> Whether to wait for the operation to complete. </param>
        /// <param name="data"> Parameters supplied to the create or update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<FirewallPolicyResource> Update(WaitUntil waitUntil, FirewallPolicyData data, CancellationToken cancellationToken = default)
            => new FirewallPolicyCollection(Client, Id.Parent).CreateOrUpdate(waitUntil, Id.Name, data, cancellationToken);
    }
}
