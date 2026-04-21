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
    // The new API version changed action operation return types from generic result types
    // (StateUpdateCommonPostActionResult / DeviceUpdateCommonPostActionResult) to operation-specific types.
    // The generated methods were renamed via operationId directives (adding synonym-based renaming),
    // and these shims preserve the original v1.1.2 method signatures.
    public partial class NetworkTapResource
    {
        /// <summary> Backward-compatible shim for Resync. Use Synchronize instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> ResyncAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = await SynchronizeAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkTapResyncResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for Resync. Use Synchronize instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Resync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = Synchronize(waitUntil, cancellationToken);
            return new CompatArmOperation<NetworkTapResyncResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DeviceUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = await SetAdministrativeStateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DeviceUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = SetAdministrativeState(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
        }
    }
}
