// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkDeviceResource
    {
        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use UpdateAdministrativeStateWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateDeviceAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAdministrativeStateWithTypedResultAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkDeviceUpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use UpdateAdministrativeStateWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateDeviceAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = UpdateAdministrativeStateWithTypedResult(waitUntil, content, cancellationToken);
            return new CompatArmOperation<NetworkDeviceUpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for Reboot. Use RebootWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RebootAsync(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            var operation = await RebootWithTypedResultAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for Reboot. Use RebootWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Reboot(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            var operation = RebootWithTypedResult(waitUntil, content, cancellationToken);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use RefreshConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RefreshConfigurationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = await RefreshConfigurationWithTypedResultAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkDeviceRefreshConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use RefreshConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> RefreshConfiguration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = RefreshConfigurationWithTypedResult(waitUntil, cancellationToken);
            return new CompatArmOperation<NetworkDeviceRefreshConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with NetworkDeviceUpgradeContent instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with NetworkDeviceUpgradeContent instead.")]
        public virtual Task<ArmOperation<StateUpdateCommonPostActionResult>> UpgradeAsync(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use UpgradeAsync with NetworkDeviceUpgradeContent instead.");
        }

        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with NetworkDeviceUpgradeContent instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with NetworkDeviceUpgradeContent instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Upgrade(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use Upgrade with NetworkDeviceUpgradeContent instead.");
        }
    }
}
