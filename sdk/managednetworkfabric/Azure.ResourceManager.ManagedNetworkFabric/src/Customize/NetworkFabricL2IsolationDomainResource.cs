// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricL2IsolationDomainResource
    {
        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use UpdateAdministrativeStateWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DeviceUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAdministrativeStateWithTypedResultAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use UpdateAdministrativeStateWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DeviceUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = UpdateAdministrativeStateWithTypedResult(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
        }
    }
}
