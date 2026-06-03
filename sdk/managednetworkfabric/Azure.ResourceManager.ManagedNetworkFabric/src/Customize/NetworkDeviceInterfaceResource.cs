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
    public partial class NetworkDeviceInterfaceResource
    {
        // 1. The service API version changed the action operation response model from the shipped
        //    StateUpdateCommonPostActionResult to an operation-specific result model.
        // 2. We keep obsolete overloads with the shipped Update* method name and return type, delegating
        //    to the generated Set* methods and adapting their operation values back to the old result type.
        // 3. Without this custom code, only the generated Set* methods with operation-specific result types
        //    would exist, removing the shipped Update* API surface.

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeStateAsync instead.")]
        public virtual Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeStateAsync instead.");
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeState instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeState instead.");
        }

        private static StateUpdateCommonPostActionResult ToStateUpdateResult(ResponseError error)
            => new StateUpdateCommonPostActionResult(error, additionalBinaryDataProperties: null, configurationState: null);
    }
}
