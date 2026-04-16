// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkTapRuleResource
    {
        /// <summary> Backward-compatible shim for Resync. Use ResyncWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> ResyncAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = await ResyncWithTypedResultAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkTapRuleResyncResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for Resync. Use ResyncWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Resync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = ResyncWithTypedResult(waitUntil, cancellationToken);
            return new CompatArmOperation<NetworkTapRuleResyncResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }
    }
}
