// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the FirewallPolicyDraftResource type. </summary>
    public partial class FirewallPolicyDraftResource
    {
        /// <summary> Updates a draft Firewall Policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Parameters supplied to the update Firewall Policy Draft operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation<FirewallPolicyDraftResource>> UpdateAsync(WaitUntil waitUntil, FirewallPolicyDraftData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdateAsync(waitUntil, data, cancellationToken);
        }

        /// <summary> Updates a draft Firewall Policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Parameters supplied to the update Firewall Policy Draft operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<FirewallPolicyDraftResource> Update(WaitUntil waitUntil, FirewallPolicyDraftData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, data, cancellationToken);
        }
    }
}
