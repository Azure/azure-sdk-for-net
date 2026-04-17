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
    // (StateUpdateCommonPostActionResult / DeviceUpdateCommonPostActionResult / ValidateConfigurationResult)
    // to operation-specific types. The generated methods were renamed via operationId directives
    // (adding "WithTypedResult" suffix), and these shims preserve the original v1.1.2 method signatures.
    public partial class NetworkFabricResource
    {
        /// <summary> Backward-compatible shim for CommitConfiguration. Use CommitConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> CommitConfigurationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = await CommitConfigurationWithTypedResultAsync(waitUntil, null, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<CommitConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for CommitConfiguration. Use CommitConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> CommitConfiguration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = CommitConfigurationWithTypedResult(waitUntil, null, cancellationToken);
            return new CompatArmOperation<CommitConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for Deprovision. Use DeprovisionWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DeviceUpdateCommonPostActionResult>> DeprovisionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = await DeprovisionWithTypedResultAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
        }

        /// <summary> Backward-compatible shim for Deprovision. Use DeprovisionWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DeviceUpdateCommonPostActionResult> Deprovision(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = DeprovisionWithTypedResult(waitUntil, cancellationToken);
            return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
        }

        /// <summary> Backward-compatible shim for Provision. Use ProvisionWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DeviceUpdateCommonPostActionResult>> ProvisionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = await ProvisionWithTypedResultAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
        }

        /// <summary> Backward-compatible shim for Provision. Use ProvisionWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DeviceUpdateCommonPostActionResult> Provision(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = ProvisionWithTypedResult(waitUntil, cancellationToken);
            return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => new DeviceUpdateCommonPostActionResult(r.Error, null, null, Array.Empty<string>(), Array.Empty<string>()));
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use RefreshConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RefreshConfigurationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = await RefreshConfigurationWithTypedResultAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use RefreshConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> RefreshConfiguration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = RefreshConfigurationWithTypedResult(waitUntil, cancellationToken);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateInfraManagementBfdConfiguration. Use UpdateInfraManagementBfdConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateInfraManagementBfdConfigurationAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateInfraManagementBfdConfigurationWithTypedResultAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateInfraManagementBfdConfiguration. Use UpdateInfraManagementBfdConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateInfraManagementBfdConfiguration(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = UpdateInfraManagementBfdConfigurationWithTypedResult(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateWorkloadManagementBfdConfiguration. Use UpdateWorkloadManagementBfdConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateWorkloadManagementBfdConfigurationAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateWorkloadManagementBfdConfigurationWithTypedResultAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for UpdateWorkloadManagementBfdConfiguration. Use UpdateWorkloadManagementBfdConfigurationWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateWorkloadManagementBfdConfiguration(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            var operation = UpdateWorkloadManagementBfdConfigurationWithTypedResult(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
        }

        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with UpgradeNetworkFabricProperties instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with UpgradeNetworkFabricProperties instead.")]
        public virtual Task<ArmOperation<StateUpdateCommonPostActionResult>> UpgradeAsync(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use UpgradeAsync with UpgradeNetworkFabricProperties instead.");
        }

        /// <summary> Backward-compatible shim for Upgrade. The parameter type changed in the new API version; use Upgrade with UpgradeNetworkFabricProperties instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with UpgradeNetworkFabricProperties instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Upgrade(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use Upgrade with UpgradeNetworkFabricProperties instead.");
        }

        /// <summary> Backward-compatible shim for GetTopology. Use GetTopologyWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ValidateConfigurationResult>> GetTopologyAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = await GetTopologyWithTypedResultAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<GetTopologyResult, ValidateConfigurationResult>(operation, r => new ValidateConfigurationResult(r.Error, null, null, null));
        }

        /// <summary> Backward-compatible shim for GetTopology. Use GetTopologyWithTypedResult instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ValidateConfigurationResult> GetTopology(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            var operation = GetTopologyWithTypedResult(waitUntil, cancellationToken);
            return new CompatArmOperation<GetTopologyResult, ValidateConfigurationResult>(operation, r => new ValidateConfigurationResult(r.Error, null, null, null));
        }
    }
}
