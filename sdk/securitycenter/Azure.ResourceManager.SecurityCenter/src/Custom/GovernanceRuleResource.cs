// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Preserve the previously generated body parameter names for named-argument callers.
    [CodeGenSuppress("ExecuteAsync", typeof(WaitUntil), typeof(ExecuteGovernanceRuleParams), typeof(CancellationToken))]
    [CodeGenSuppress("Execute", typeof(WaitUntil), typeof(ExecuteGovernanceRuleParams), typeof(CancellationToken))]
    public partial class GovernanceRuleResource
    {
        /// <summary>
        /// Execute a governance rule
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{scope}/providers/Microsoft.Security/governanceRules/{ruleId}/execute. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GovernanceRules_Execute. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-01-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GovernanceRuleResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="executeGovernanceRuleParams"> Execute governance rule over a given scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> ExecuteAsync(WaitUntil waitUntil, ExecuteGovernanceRuleParams executeGovernanceRuleParams = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _governanceRulesClientDiagnostics.CreateScope("GovernanceRuleResource.Execute");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _governanceRulesRestClient.CreateExecuteRequest(Id.Parent.ToString(), Id.Name, ExecuteGovernanceRuleParams.ToRequestContent(executeGovernanceRuleParams), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                SecurityCenterArmOperation operation = new SecurityCenterArmOperation(_governanceRulesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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

        /// <summary>
        /// Execute a governance rule
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{scope}/providers/Microsoft.Security/governanceRules/{ruleId}/execute. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GovernanceRules_Execute. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-01-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GovernanceRuleResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="executeGovernanceRuleParams"> Execute governance rule over a given scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Execute(WaitUntil waitUntil, ExecuteGovernanceRuleParams executeGovernanceRuleParams = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _governanceRulesClientDiagnostics.CreateScope("GovernanceRuleResource.Execute");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _governanceRulesRestClient.CreateExecuteRequest(Id.Parent.ToString(), Id.Name, ExecuteGovernanceRuleParams.ToRequestContent(executeGovernanceRuleParams), context);
                Response response = Pipeline.ProcessMessage(message, context);
                SecurityCenterArmOperation operation = new SecurityCenterArmOperation(_governanceRulesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
    }
}
