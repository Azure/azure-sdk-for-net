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
    // (StateUpdateCommonPostActionResult) to operation-specific types.
    // These shims preserve the original v1.1.2 method signatures. Removing them would drop the old
    // method names/return types.
    public partial class NetworkTapRuleResource
    {
        /// <summary> Backward-compatible shim for Resync. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> ResyncAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkTapRulesClientDiagnostics.CreateScope("NetworkTapRuleResource.Resync");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkTapRulesRestClient.CreateSynchronizeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkTapRuleResyncResult> operation = new ManagedNetworkFabricArmOperation<NetworkTapRuleResyncResult>(
                    new NetworkTapRuleResyncResultOperationSource(),
                    _networkTapRulesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return new CompatArmOperation<NetworkTapRuleResyncResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Backward-compatible shim for Resync. Preserves the previous SDK signature while calling the current REST action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Resync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _networkTapRulesClientDiagnostics.CreateScope("NetworkTapRuleResource.Resync");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkTapRulesRestClient.CreateSynchronizeRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkTapRuleResyncResult> operation = new ManagedNetworkFabricArmOperation<NetworkTapRuleResyncResult>(
                    new NetworkTapRuleResyncResultOperationSource(),
                    _networkTapRulesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return new CompatArmOperation<NetworkTapRuleResyncResult, StateUpdateCommonPostActionResult>(operation, r => new StateUpdateCommonPostActionResult(r.Error, null, null));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
