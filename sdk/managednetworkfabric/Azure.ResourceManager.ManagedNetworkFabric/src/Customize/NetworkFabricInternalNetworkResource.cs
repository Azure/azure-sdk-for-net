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
    // (StateUpdateCommonPostActionResult) to operation-specific types. The generated methods were renamed
    // via operationId directives (adding "WithTypedResult" suffix), and these shims preserve the
    // original v1.1.2 method signatures.
    public partial class NetworkFabricInternalNetworkResource
    {
        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use UpdateAdministrativeStateWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAdministrativeStateWithTypedResultAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use UpdateAdministrativeStateWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = UpdateAdministrativeStateWithTypedResult(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateBgpAdministrativeState. The parameter type changed in the new API version; use UpdateBgpAdministrativeStateWithTypedResult with InternalNetworkUpdateBgpAdministrativeStateContent instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use UpdateBgpAdministrativeStateWithTypedResult with InternalNetworkUpdateBgpAdministrativeStateContent instead.")]
        public virtual Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateBgpAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use UpdateBgpAdministrativeStateWithTypedResultAsync with InternalNetworkUpdateBgpAdministrativeStateContent instead.");
        }

        /// <summary> Backward-compatible shim for UpdateBgpAdministrativeState. The parameter type changed in the new API version; use UpdateBgpAdministrativeStateWithTypedResult with InternalNetworkUpdateBgpAdministrativeStateContent instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use UpdateBgpAdministrativeStateWithTypedResult with InternalNetworkUpdateBgpAdministrativeStateContent instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateBgpAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use UpdateBgpAdministrativeStateWithTypedResult with InternalNetworkUpdateBgpAdministrativeStateContent instead.");
        }

        /// <summary> Backward-compatible shim for UpdateStaticRouteBfdAdministrativeState. Use UpdateStaticRouteBfdAdministrativeStateWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateStaticRouteBfdAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateStaticRouteBfdAdministrativeStateWithTypedResultAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateStaticRouteBfdAdministrativeState. Use UpdateStaticRouteBfdAdministrativeStateWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateStaticRouteBfdAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = UpdateStaticRouteBfdAdministrativeStateWithTypedResult(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }
    }
}
