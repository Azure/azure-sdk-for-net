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
    public partial class NetworkTapResource
    {
        // 1. The TypeSpec patch models now keep the Swagger-compatible TagsUpdate base and the generated
        //    C# update operations accept renamed *PatchContent types.
        // 2. We keep obsolete overloads that accept the shipped *Patch types and serialize those legacy
        //    patch instances into the generated content shape before invoking the same REST operation.
        // 3. Without this custom code, only Update overloads accepting *PatchContent would be generated,
        //    removing the public Update overloads that existing callers use with the shipped patch types.
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkTapPatchContent, CancellationToken) instead.")]
        public virtual async Task<ArmOperation<NetworkTapResource>> UpdateAsync(WaitUntil waitUntil, NetworkTapPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _networkTapsClientDiagnostics.CreateScope("NetworkTapResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkTapsRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkTapPatch.ToRequestContent(patch), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkTapResource> operation = new ManagedNetworkFabricArmOperation<NetworkTapResource>(
                    new NetworkTapOperationSource(Client),
                    _networkTapsClientDiagnostics,
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
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkTapPatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkTapResource> Update(WaitUntil waitUntil, NetworkTapPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _networkTapsClientDiagnostics.CreateScope("NetworkTapResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkTapsRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkTapPatch.ToRequestContent(patch), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkTapResource> operation = new ManagedNetworkFabricArmOperation<NetworkTapResource>(
                    new NetworkTapOperationSource(Client),
                    _networkTapsClientDiagnostics,
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
        //    to the generated Start*/Set* methods and adapting their operation values back to the old result type.
        // 3. Without this custom code, only the generated Start*/Set* methods with operation-specific result types
        //    would exist, removing the shipped API surface.

        /// <summary> Backward-compatible shim for Resync. Use StartResync instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartResyncAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> ResyncAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkTapResyncResult> operation = await StartResyncAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkTapResyncResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Resync. Use StartResync instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartResync instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Resync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkTapResyncResult> operation = StartResync(waitUntil, cancellationToken);
            return new CompatArmOperation<NetworkTapResyncResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeStateAsync instead.")]
        public virtual async Task<ArmOperation<DeviceUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = await SetAdministrativeStateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<UpdateAdministrativeStateResult, DeviceUpdateCommonPostActionResult>(operation, r => ToDeviceUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Use SetAdministrativeState instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use SetAdministrativeState instead.")]
        public virtual ArmOperation<DeviceUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            ArmOperation<UpdateAdministrativeStateResult> operation = SetAdministrativeState(waitUntil, content, cancellationToken);
            return new CompatArmOperation<UpdateAdministrativeStateResult, DeviceUpdateCommonPostActionResult>(operation, r => ToDeviceUpdateResult(r.Error));
        }

        private static StateUpdateCommonPostActionResult ToStateUpdateResult(ResponseError error)
            => new StateUpdateCommonPostActionResult(error, additionalBinaryDataProperties: null, configurationState: null);

        private static DeviceUpdateCommonPostActionResult ToDeviceUpdateResult(ResponseError error)
            => new DeviceUpdateCommonPostActionResult(error, additionalBinaryDataProperties: null, configurationState: null, successfulDevices: Array.Empty<string>(), failedDevices: Array.Empty<string>());
    }
}
