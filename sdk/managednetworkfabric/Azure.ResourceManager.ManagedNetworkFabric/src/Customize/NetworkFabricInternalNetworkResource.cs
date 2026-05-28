// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricInternalNetworkResource
    {
        // 1. The service API version changed action operation response models from the shipped
        //    StateUpdateCommonPostActionResult to operation-specific result models.
        // 2. We keep obsolete overloads with the shipped Update* method names and return types, delegating
        //    to the generated Set* methods and adapting their operation values back to the old result type.
        // 3. Without this custom code, only the generated Set* methods with operation-specific result types
        //    would exist, removing the shipped Update* API surface.

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeStateAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = await SetAdministrativeStateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeState instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = SetAdministrativeState(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateBgpAdministrativeState. Use SetBgpAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetBgpAdministrativeStateAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateBgpAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<InternalNetworkUpdateBgpAdministrativeStateResult> operation = await SetBgpAdministrativeStateAsync(waitUntil, ToBgpAdministrativeStateContent(content), cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<InternalNetworkUpdateBgpAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateBgpAdministrativeState. Use SetBgpAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetBgpAdministrativeState instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateBgpAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<InternalNetworkUpdateBgpAdministrativeStateResult> operation = SetBgpAdministrativeState(waitUntil, ToBgpAdministrativeStateContent(content), cancellationToken);
            return new CompatArmOperation<InternalNetworkUpdateBgpAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        private static InternalNetworkUpdateBgpAdministrativeStateContent ToBgpAdministrativeStateContent(UpdateAdministrativeStateContent content)
        {
            Argument.AssertNotNull(content, nameof(content));

            BgpAdministrativeState? administrativeState = content.State.HasValue
                ? content.State.Value == AdministrativeEnableState.Enable
                    ? BgpAdministrativeState.Enabled
                    : content.State.Value == AdministrativeEnableState.Disable
                        ? BgpAdministrativeState.Disabled
                        : new BgpAdministrativeState(content.State.Value.ToString())
                : null;

            return new InternalNetworkUpdateBgpAdministrativeStateContent(neighborAddress: null, administrativeState, additionalBinaryDataProperties: null);
        }

        /// <summary> Backward-compatible shim for UpdateStaticRouteBfdAdministrativeState. Use SetStaticRouteBfdAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetStaticRouteBfdAdministrativeStateAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateStaticRouteBfdAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = await SetStaticRouteBfdAdministrativeStateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateStaticRouteBfdAdministrativeState. Use SetStaticRouteBfdAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetStaticRouteBfdAdministrativeState instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateStaticRouteBfdAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = SetStaticRouteBfdAdministrativeState(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }
    }
}
