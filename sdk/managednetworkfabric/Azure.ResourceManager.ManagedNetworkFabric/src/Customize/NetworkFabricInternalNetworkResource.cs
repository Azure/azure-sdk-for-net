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
    public partial class NetworkFabricInternalNetworkResource
    {
        /// <summary> Backward-compatible shim for UpdateBgpAdministrativeState. The parameter type changed in the new API version; use SetBgpAdministrativeState with InternalNetworkUpdateBgpAdministrativeStateContent instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use SetBgpAdministrativeState with InternalNetworkUpdateBgpAdministrativeStateContent instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateBgpAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var state = content?.State?.ToString() switch
            {
                "Enable" => BgpAdministrativeState.Enabled,
                "Disable" => BgpAdministrativeState.Disabled,
                var s when !string.IsNullOrEmpty(s) => new BgpAdministrativeState(s),
                _ => default(BgpAdministrativeState?)
            };
            var request = new InternalNetworkUpdateBgpAdministrativeStateContent
            {
                AdministrativeState = state,
            };
            var operation = await UpdateBgpAdministrativeStateAsync(waitUntil, request, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<InternalNetworkUpdateBgpAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateBgpAdministrativeState. The parameter type changed in the new API version; use SetBgpAdministrativeState with InternalNetworkUpdateBgpAdministrativeStateContent instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use SetBgpAdministrativeState with InternalNetworkUpdateBgpAdministrativeStateContent instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateBgpAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var state = content?.State?.ToString() switch
            {
                "Enable" => BgpAdministrativeState.Enabled,
                "Disable" => BgpAdministrativeState.Disabled,
                var s when !string.IsNullOrEmpty(s) => new BgpAdministrativeState(s),
                _ => default(BgpAdministrativeState?)
            };
            var request = new InternalNetworkUpdateBgpAdministrativeStateContent
            {
                AdministrativeState = state,
            };
            var operation = UpdateBgpAdministrativeState(waitUntil, request, cancellationToken);
            return new CompatArmOperation<InternalNetworkUpdateBgpAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }
    }
}
