// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Network
{
    public partial class FirewallPolicyDraftResource
    {
        // Generated async tag helpers call UpdateAsync, but this singleton generates only CreateOrUpdateAsync.
        // This implementation helper was not a public API in 1.15.0.
        /// <summary> Updates a draft Firewall Policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Parameters supplied to the update Firewall Policy Draft operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private Task<ArmOperation<FirewallPolicyDraftResource>> UpdateAsync(WaitUntil waitUntil, FirewallPolicyDraftData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, data, cancellationToken);

        // Generated synchronous tag helpers call Update, but this singleton generates only CreateOrUpdate.
        // Keep the generator workaround private rather than adding a new public API.
        /// <summary> Updates a draft Firewall Policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Parameters supplied to the update Firewall Policy Draft operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private ArmOperation<FirewallPolicyDraftResource> Update(WaitUntil waitUntil, FirewallPolicyDraftData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, data, cancellationToken);
    }
}
