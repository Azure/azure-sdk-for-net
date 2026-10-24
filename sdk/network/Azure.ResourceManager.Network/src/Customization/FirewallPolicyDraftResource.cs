// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class FirewallPolicyDraftResource
    {
        // Generated async tag helpers call UpdateAsync, but this singleton generates only CreateOrUpdateAsync.
        // Removing this forwarder produces CS1061; keep it hidden until the generator mismatch is fixed.
        /// <summary> Updates a draft Firewall Policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Parameters supplied to the update Firewall Policy Draft operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<FirewallPolicyDraftResource>> UpdateAsync(WaitUntil waitUntil, FirewallPolicyDraftData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, data, cancellationToken);

        // Generated synchronous tag helpers call Update, but this singleton generates only CreateOrUpdate.
        // Removing this forwarder produces CS1061; keep it hidden until the generator mismatch is fixed.
        /// <summary> Updates a draft Firewall Policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Parameters supplied to the update Firewall Policy Draft operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<FirewallPolicyDraftResource> Update(WaitUntil waitUntil, FirewallPolicyDraftData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, data, cancellationToken);
    }
}
