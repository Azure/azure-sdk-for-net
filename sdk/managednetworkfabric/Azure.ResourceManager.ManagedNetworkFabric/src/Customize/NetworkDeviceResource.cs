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
                    new NetworkDeviceResourceOperationSource(Client),
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
                    new NetworkDeviceResourceOperationSource(Client),
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

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeStateAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateDeviceAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceUpdateAdministrativeStateResult> operation = await SetAdministrativeStateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkDeviceUpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeState instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateDeviceAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceUpdateAdministrativeStateResult> operation = SetAdministrativeState(waitUntil, content, cancellationToken);
            return new CompatArmOperation<NetworkDeviceUpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Reboot. Use Restart instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use RestartAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RebootAsync(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkFabricOperationStatusResult> operation = await RestartAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkFabricOperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Reboot. Use Restart instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Restart instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Reboot(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkFabricOperationStatusResult> operation = Restart(waitUntil, content, cancellationToken);
            return new CompatArmOperation<NetworkFabricOperationStatusResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        // The generated method has the same parameters but returns the shared ARM OperationStatusResult.
        // Keep this custom same-signature method to preserve the shipped NetworkFabricOperationStatusResult return type.
        /// <summary> Reboot the Network Device. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkFabricOperationStatusResult>> RestartAsync(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.Restart");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateRestartRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkDeviceRebootContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkFabricOperationStatusResult> operation = new ManagedNetworkFabricArmOperation<NetworkFabricOperationStatusResult>(
                    new NetworkFabricOperationStatusResultOperationSource(),
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

        // The generated method has the same parameters but returns the shared ARM OperationStatusResult.
        // Keep this custom same-signature method to preserve the shipped NetworkFabricOperationStatusResult return type.
        /// <summary> Reboot the Network Device. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<NetworkFabricOperationStatusResult> Restart(WaitUntil waitUntil, NetworkDeviceRebootContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkDevicesClientDiagnostics.CreateScope("NetworkDeviceResource.Restart");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkDevicesRestClient.CreateRestartRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkDeviceRebootContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkFabricOperationStatusResult> operation = new ManagedNetworkFabricArmOperation<NetworkFabricOperationStatusResult>(
                    new NetworkFabricOperationStatusResultOperationSource(),
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

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use ReloadConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use ReloadConfigurationAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> RefreshConfigurationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceRefreshConfigurationResult> operation = await ReloadConfigurationAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkDeviceRefreshConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for RefreshConfiguration. Use ReloadConfiguration instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use ReloadConfiguration instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> RefreshConfiguration(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceRefreshConfigurationResult> operation = ReloadConfiguration(waitUntil, cancellationToken);
            return new CompatArmOperation<NetworkDeviceRefreshConfigurationResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Upgrade. Use Upgrade overload with <see cref="NetworkDeviceUpgradeContent"/> instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with NetworkDeviceUpgradeContent instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpgradeAsync(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceUpgradeResult> operation = await UpgradeAsync(waitUntil, ToNetworkDeviceUpgradeContent(content), cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkDeviceUpgradeResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Upgrade. Use Upgrade overload with <see cref="NetworkDeviceUpgradeContent"/> instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload uses a parameter type from a previous API version. Use Upgrade with NetworkDeviceUpgradeContent instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Upgrade(WaitUntil waitUntil, NetworkFabricUpdateVersionContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkDeviceUpgradeResult> operation = Upgrade(waitUntil, ToNetworkDeviceUpgradeContent(content), cancellationToken);
            return new CompatArmOperation<NetworkDeviceUpgradeResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        private static StateUpdateCommonPostActionResult ToStateUpdateResult(ResponseError error)
            => new StateUpdateCommonPostActionResult(error, additionalBinaryDataProperties: null, configurationState: null);

        private static NetworkDeviceUpgradeContent ToNetworkDeviceUpgradeContent(NetworkFabricUpdateVersionContent content)
            => new NetworkDeviceUpgradeContent(content.Version, rwDeviceConfigUri: null, additionalBinaryDataProperties: null);
    }
}
