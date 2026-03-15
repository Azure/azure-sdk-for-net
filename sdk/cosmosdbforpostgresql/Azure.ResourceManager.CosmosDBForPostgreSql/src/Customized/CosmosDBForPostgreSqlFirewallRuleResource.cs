// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    // Backward-compat: baseline autorest Delete returned non-generic ArmOperation (Swagger had no response body).
    // The TypeSpec spec overrides LroHeaders with FinalResult=FirewallRule on the delete operation:
    //   LroHeaders = ArmAsyncOperationHeader<FinalResult = FirewallRule> & ArmLroLocationHeader<FinalResult = FirewallRule>
    // This causes @finalLocation(FinalResult) to flow into tspCodeModel as lroMetadata.finalResponse.bodyType,
    // which makes the C# generator produce ArmOperation<CosmosDBForPostgreSqlFirewallRuleResource>.
    // Suppress the typed version and replace with non-generic ArmOperation to preserve backward-compat.
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class CosmosDBForPostgreSqlFirewallRuleResource
    {
        /// <summary> Deletes a cluster firewall rule. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _firewallRulesClientDiagnostics.CreateScope("CosmosDBForPostgreSqlFirewallRuleResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _firewallRulesRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                CosmosDBForPostgreSqlArmOperation operation = new CosmosDBForPostgreSqlArmOperation(
                    _firewallRulesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a cluster firewall rule. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _firewallRulesClientDiagnostics.CreateScope("CosmosDBForPostgreSqlFirewallRuleResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _firewallRulesRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                CosmosDBForPostgreSqlArmOperation operation = new CosmosDBForPostgreSqlArmOperation(
                    _firewallRulesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
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
