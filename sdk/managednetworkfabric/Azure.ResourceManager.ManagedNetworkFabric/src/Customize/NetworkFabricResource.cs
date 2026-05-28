// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricResource
    {
        // 1. The TypeSpec patch models now keep the Swagger-compatible TagsUpdate base and the generated
        //    C# update operations accept renamed *PatchContent types.
        // 2. We keep obsolete overloads that accept the shipped *Patch types and serialize those legacy
        //    patch instances into the generated content shape before invoking the same REST operation.
        // 3. Without this custom code, only Update overloads accepting *PatchContent would be generated,
        //    removing the public Update overloads that existing callers use with the shipped patch types.
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkFabricPatchContent, CancellationToken) instead.")]
        public virtual async Task<ArmOperation<NetworkFabricResource>> UpdateAsync(WaitUntil waitUntil, NetworkFabricPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkFabricPatch.ToRequestContent(patch), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkFabricResource> operation = new ManagedNetworkFabricArmOperation<NetworkFabricResource>(
                    new NetworkFabricOperationSource(Client),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // 1. The TypeSpec patch models now keep the Swagger-compatible TagsUpdate base and the generated
        //    C# update operations accept renamed *PatchContent types.
        // 2. We keep obsolete overloads that accept the shipped *Patch types and serialize those legacy
        //    patch instances into the generated content shape before invoking the same REST operation.
        // 3. Without this custom code, only Update overloads accepting *PatchContent would be generated,
        //    removing the public Update overloads that existing callers use with the shipped patch types.
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkFabricPatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkFabricResource> Update(WaitUntil waitUntil, NetworkFabricPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _networkFabricsClientDiagnostics.CreateScope("NetworkFabricResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkFabricsRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkFabricPatch.ToRequestContent(patch), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkFabricResource> operation = new ManagedNetworkFabricArmOperation<NetworkFabricResource>(
                    new NetworkFabricOperationSource(Client),
                    _networkFabricsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // 1. The service API version changed action operation response models from shipped generic
        //    post-action result types to operation-specific result models.
        // 2. We keep obsolete overloads with the shipped method names and return types, delegating
        //    to the generated Start*/Set*/Get* methods and adapting their operation values back to the old result type.
        // 3. Without this custom code, only the generated renamed methods with operation-specific result types
        //    would exist, removing the shipped API surface.

        /// <summary> Backward-compatible shim for Deprovision. Use Deactivate instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use DeactivateAsync instead.")]
        public virtual async Task<ArmOperation<DeviceUpdateCommonPostActionResult>> DeprovisionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = await DeactivateAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => ToDeviceUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Deprovision. Use Deactivate instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Deactivate instead.")]
        public virtual ArmOperation<DeviceUpdateCommonPostActionResult> Deprovision(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = Deactivate(waitUntil, cancellationToken);
            return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => ToDeviceUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Provision. Use Activate instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use ActivateAsync instead.")]
        public virtual async Task<ArmOperation<DeviceUpdateCommonPostActionResult>> ProvisionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = await ActivateAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => ToDeviceUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Provision. Use Activate instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Activate instead.")]
        public virtual ArmOperation<DeviceUpdateCommonPostActionResult> Provision(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = Activate(waitUntil, cancellationToken);
            return new CompatArmOperation<OperationStatusResult, DeviceUpdateCommonPostActionResult>(operation, r => ToDeviceUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use ReloadConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use ReloadConfigurationAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RefreshConfigurationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = await ReloadConfigurationAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use ReloadConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use ReloadConfiguration instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> RefreshConfiguration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = ReloadConfiguration(waitUntil, cancellationToken);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for GetTopology. Use RetrieveTopology instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use RetrieveTopologyAsync instead.")]
        public virtual async Task<ArmOperation<ValidateConfigurationResult>> GetTopologyAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkFabricTopologyResult> operation = await RetrieveTopologyAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkFabricTopologyResult, ValidateConfigurationResult>(operation, r => ToValidateConfigurationResult(r.Error, r.GetTopologyResponseUri));
        }

        /// <summary> Backward-compatible shim for GetTopology. Use RetrieveTopology instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use RetrieveTopology instead.")]
        public virtual ArmOperation<ValidateConfigurationResult> GetTopology(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkFabricTopologyResult> operation = RetrieveTopology(waitUntil, cancellationToken);
            return new CompatArmOperation<NetworkFabricTopologyResult, ValidateConfigurationResult>(operation, r => ToValidateConfigurationResult(r.Error, r.GetTopologyResponseUri));
        }

        /// <summary> Backward-compatible shim for UpdateInfraManagementBfdConfiguration. Use SetInfraManagementBfdConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetInfraManagementBfdConfigurationAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateInfraManagementBfdConfigurationAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = await SetInfraManagementBfdConfigurationAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateInfraManagementBfdConfiguration. Use SetInfraManagementBfdConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetInfraManagementBfdConfiguration instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateInfraManagementBfdConfiguration(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = SetInfraManagementBfdConfiguration(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateWorkloadManagementBfdConfiguration. Use SetWorkloadManagementBfdConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetWorkloadManagementBfdConfigurationAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateWorkloadManagementBfdConfigurationAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = await SetWorkloadManagementBfdConfigurationAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateWorkloadManagementBfdConfiguration. Use SetWorkloadManagementBfdConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetWorkloadManagementBfdConfiguration instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateWorkloadManagementBfdConfiguration(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = SetWorkloadManagementBfdConfiguration(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Upgrade. Use Upgrade with UpgradeNetworkFabricProperties instead for richer request type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpgradeAsync(WaitUntil, UpgradeNetworkFabricProperties, CancellationToken) instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpgradeAsync(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = await UpgradeAsync(waitUntil, ToUpgradeNetworkFabricProperties(content), cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Upgrade. Use Upgrade with UpgradeNetworkFabricProperties instead for richer request type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Upgrade(WaitUntil, UpgradeNetworkFabricProperties, CancellationToken) instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Upgrade(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = Upgrade(waitUntil, ToUpgradeNetworkFabricProperties(content), cancellationToken);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        private static UpgradeNetworkFabricProperties ToUpgradeNetworkFabricProperties(NetworkFabricUpdateVersionContent content)
        {
            Argument.AssertNotNull(content, nameof(content));

            return new UpgradeNetworkFabricProperties(content.Version, additionalBinaryDataProperties: null, action: null);
        }

        private static StateUpdateCommonPostActionResult ToStateUpdateResult(ResponseError error)
            => new StateUpdateCommonPostActionResult(error, additionalBinaryDataProperties: null, configurationState: null);

        private static DeviceUpdateCommonPostActionResult ToDeviceUpdateResult(ResponseError error)
            => new DeviceUpdateCommonPostActionResult(error, additionalBinaryDataProperties: null, configurationState: null, successfulDevices: Array.Empty<string>(), failedDevices: Array.Empty<string>());

        private static ValidateConfigurationResult ToValidateConfigurationResult(ResponseError error, Uri uri)
            => new ValidateConfigurationResult(error, additionalBinaryDataProperties: null, configurationState: null, uri);
    }
}
