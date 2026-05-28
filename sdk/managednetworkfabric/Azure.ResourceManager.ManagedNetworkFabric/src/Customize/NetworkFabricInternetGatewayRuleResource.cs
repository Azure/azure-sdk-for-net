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
    public partial class NetworkFabricInternetGatewayRuleResource
    {
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkFabricInternetGatewayRulePatchContent, CancellationToken) instead.")]
        public virtual async Task<ArmOperation<NetworkFabricInternetGatewayRuleResource>> UpdateAsync(WaitUntil waitUntil, NetworkFabricInternetGatewayRulePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _internetGatewayRulesClientDiagnostics.CreateScope("NetworkFabricInternetGatewayRuleResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _internetGatewayRulesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkFabricInternetGatewayRulePatch.ToRequestContent(patch), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ManagedNetworkFabricArmOperation<NetworkFabricInternetGatewayRuleResource> operation = new ManagedNetworkFabricArmOperation<NetworkFabricInternetGatewayRuleResource>(
                    new NetworkFabricInternetGatewayRuleOperationSource(Client),
                    _internetGatewayRulesClientDiagnostics,
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

        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkFabricInternetGatewayRulePatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkFabricInternetGatewayRuleResource> Update(WaitUntil waitUntil, NetworkFabricInternetGatewayRulePatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _internetGatewayRulesClientDiagnostics.CreateScope("NetworkFabricInternetGatewayRuleResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _internetGatewayRulesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, NetworkFabricInternetGatewayRulePatch.ToRequestContent(patch), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ManagedNetworkFabricArmOperation<NetworkFabricInternetGatewayRuleResource> operation = new ManagedNetworkFabricArmOperation<NetworkFabricInternetGatewayRuleResource>(
                    new NetworkFabricInternetGatewayRuleOperationSource(Client),
                    _internetGatewayRulesClientDiagnostics,
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
    }
}
