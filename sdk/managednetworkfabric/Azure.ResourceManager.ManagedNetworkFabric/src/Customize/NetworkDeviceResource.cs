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
    public partial class NetworkDeviceResource
    {
        // 1. The TypeSpec patch models now keep the Swagger-compatible TagsUpdate base and the generated
        //    C# update operations accept renamed *PatchContent types.
        // 2. We keep obsolete overloads that accept the shipped *Patch types and serialize those legacy
        //    patch instances into the generated content shape before invoking the same REST operation.
        // 3. Without this custom code, only Update overloads accepting *PatchContent would be generated,
        //    removing the public Update overloads that existing callers use with the shipped patch types.
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkDevicePatchContent, CancellationToken) instead.")]
        public virtual async Task<ArmOperation<NetworkDeviceResource>> UpdateAsync(WaitUntil waitUntil, NetworkDevicePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkDevicePatch.ToRequestContent(patch), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkDeviceResource> operation = new ManagedNetworkFabricArmOperation<NetworkDeviceResource>(
                    new NetworkDeviceOperationSource(Client),
                    _networkDevicesClientDiagnostics,
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
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkDevicePatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkDeviceResource> Update(WaitUntil waitUntil, NetworkDevicePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkDevicePatch.ToRequestContent(patch), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkDeviceResource> operation = new ManagedNetworkFabricArmOperation<NetworkDeviceResource>(
                    new NetworkDeviceOperationSource(Client),
                    _networkDevicesClientDiagnostics,
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

        // 1. The service API version changed action operation response models from the shipped
        //    StateUpdateCommonPostActionResult to operation-specific result models.
        // 2. We keep obsolete overloads with the shipped method names and return types, delegating
        //    to the generated Start*/Set* methods and adapting their operation values back to the old result type.
        // 3. Without this custom code, only the generated Start*/Set* methods with operation-specific result types
        //    would exist, removing the shipped API surface.

        /// <summary> Backward-compatible shim for Reboot. Use StartReboot instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartRebootAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RebootAsync(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = await StartRebootAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Reboot. Use StartReboot instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartReboot instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Reboot(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<OperationStatusResult> operation = StartReboot(waitUntil, content, cancellationToken);
            return new CompatArmOperation<OperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use StartRefreshConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartRefreshConfigurationAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RefreshConfigurationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceRefreshConfigurationResult> operation = await StartRefreshConfigurationAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkDeviceRefreshConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use StartRefreshConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartRefreshConfiguration instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> RefreshConfiguration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceRefreshConfigurationResult> operation = StartRefreshConfiguration(waitUntil, cancellationToken);
            return new CompatArmOperation<NetworkDeviceRefreshConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeStateAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateDeviceAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceUpdateAdministrativeStateResult> operation = await SetAdministrativeStateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkDeviceUpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeState instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateDeviceAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceUpdateAdministrativeStateResult> operation = SetAdministrativeState(waitUntil, content, cancellationToken);
            return new CompatArmOperation<NetworkDeviceUpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Upgrade. Use StartUpgrade instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartUpgradeAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpgradeAsync(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceUpgradeResult> operation = await StartUpgradeAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkDeviceUpgradeResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Upgrade. Use StartUpgrade instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartUpgrade instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Upgrade(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceUpgradeResult> operation = StartUpgrade(waitUntil, content, cancellationToken);
            return new CompatArmOperation<NetworkDeviceUpgradeResult, StateUpdateCommonPostActionResult>(operation, r => CompatArmOperationConversions.ToStateUpdateResult(r.Error));
        }
    }
}
