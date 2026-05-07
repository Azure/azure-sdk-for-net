// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shims for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // Keep only overloads where parameter types changed between API versions.
    public partial class NetworkFabricResource
    {
        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with UpgradeNetworkFabricProperties instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with UpgradeNetworkFabricProperties instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpgradeAsync(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            var operation = await UpgradeAsync(waitUntil, new UpgradeNetworkFabricProperties { Version = content?.Version }, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkFabricUpgradeResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with UpgradeNetworkFabricProperties instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with UpgradeNetworkFabricProperties instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Upgrade(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            var operation = Upgrade(waitUntil, new UpgradeNetworkFabricProperties { Version = content?.Version }, cancellationToken);
            return new CompatArmOperation<NetworkFabricUpgradeResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }
    }
}
