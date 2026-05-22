// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    // Backward compatibility shims for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version changed action operation return types from generic result types
    // (StateUpdateCommonPostActionResult) to operation-specific types. The generated methods were renamed
    // via operationId directives (adding synonym-based renaming), and these shims preserve the
    // original v1.1.2 method signatures.
    public partial class NetworkDeviceInterfaceResource
    {
        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkInterfacesClientDiagnostics.CreateScope("NetworkDeviceInterfaceResource.UpdateAdministrativeState");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkInterfacesRestClient.CreateSetAdministrativeStateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, UpdateAdministrativeStateContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult> operation = new ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult>(
                    new UpdateAdministrativeStateResultOperationSource(),
                    _networkInterfacesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for UpdateAdministrativeState. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> UpdateAdministrativeState(WaitUntil waitUntil, UpdateAdministrativeStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _networkInterfacesClientDiagnostics.CreateScope("NetworkDeviceInterfaceResource.UpdateAdministrativeState");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkInterfacesRestClient.CreateSetAdministrativeStateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, UpdateAdministrativeStateContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult> operation = new ManagedNetworkFabricArmOperation<UpdateAdministrativeStateResult>(
                    new UpdateAdministrativeStateResultOperationSource(),
                    _networkInterfacesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<UpdateAdministrativeStateResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
