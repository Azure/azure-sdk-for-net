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
    public partial class NetworkTapRuleResource
    {
        // 1. The TypeSpec patch models now keep the Swagger-compatible TagsUpdate base and the generated
        //    C# update operations accept renamed *PatchContent types.
        // 2. We keep obsolete overloads that accept the shipped *Patch types and serialize those legacy
        //    patch instances into the generated content shape before invoking the same REST operation.
        // 3. Without this custom code, only Update overloads accepting *PatchContent would be generated,
        //    removing the public Update overloads that existing callers use with the shipped patch types.
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkTapRulePatchContent, CancellationToken) instead.")]
        public virtual async Task<ArmOperation<NetworkTapRuleResource>> UpdateAsync(WaitUntil waitUntil, NetworkTapRulePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _networkTapRulesClientDiagnostics.CreateScope("NetworkTapRuleResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkTapRulesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkTapRulePatch.ToRequestContent(patch), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkTapRuleResource> operation = new ManagedNetworkFabricArmOperation<NetworkTapRuleResource>(
                    new NetworkTapRuleOperationSource(Client),
                    _networkTapRulesClientDiagnostics,
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
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkTapRulePatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkTapRuleResource> Update(WaitUntil waitUntil, NetworkTapRulePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _networkTapRulesClientDiagnostics.CreateScope("NetworkTapRuleResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _networkTapRulesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkTapRulePatch.ToRequestContent(patch), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkTapRuleResource> operation = new ManagedNetworkFabricArmOperation<NetworkTapRuleResource>(
                    new NetworkTapRuleOperationSource(Client),
                    _networkTapRulesClientDiagnostics,
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

        // 1. The service API version changed the action operation response model from the shipped
        //    StateUpdateCommonPostActionResult to an operation-specific result model.
        // 2. We keep obsolete overloads with the shipped Resync method name and return type, delegating
        //    to the generated StartResync methods and adapting their operation values back to the old result type.
        // 3. Without this custom code, only the generated StartResync methods with operation-specific result types
        //    would exist, removing the shipped Resync API surface.

        /// <summary> Backward-compatible shim for Resync. Use StartResync instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartResyncAsync instead.")]
        public virtual async Task<ArmOperation<StateUpdateCommonPostActionResult>> ResyncAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkTapRuleResyncResult> operation = await StartResyncAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new CompatArmOperation<NetworkTapRuleResyncResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        /// <summary> Backward-compatible shim for Resync. Use StartResync instead for richer result type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use StartResync instead.")]
        public virtual ArmOperation<StateUpdateCommonPostActionResult> Resync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            ArmOperation<NetworkTapRuleResyncResult> operation = StartResync(waitUntil, cancellationToken);
            return new CompatArmOperation<NetworkTapRuleResyncResult, StateUpdateCommonPostActionResult>(operation, r => ToStateUpdateResult(r.Error));
        }

        // The generated method was renamed to StartResync; keep the shipped Synchronize name as an alias.
        /// <summary> Implements the operation to the underlying resources. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation<NetworkTapRuleResyncResult>> SynchronizeAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => StartResyncAsync(waitUntil, cancellationToken);

        // The generated method was renamed to StartResync; keep the shipped Synchronize name as an alias.
        /// <summary> Implements the operation to the underlying resources. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<NetworkTapRuleResyncResult> Synchronize(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => StartResync(waitUntil, cancellationToken);

        private static StateUpdateCommonPostActionResult ToStateUpdateResult(ResponseError error)
            => new StateUpdateCommonPostActionResult(error, additionalBinaryDataProperties: null, configurationState: null);
    }
}
