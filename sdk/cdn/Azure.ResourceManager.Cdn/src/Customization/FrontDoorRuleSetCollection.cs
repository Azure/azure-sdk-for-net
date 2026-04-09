// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Cdn
{
    // Custom: Adds CreateOrUpdate/CreateOrUpdateAsync methods that are missing because
    // the TypeSpec uses Legacy.CustomPatchAsync instead of ArmResourceCreateOrReplaceSync,
    // causing the generator to omit these methods.
    public partial class FrontDoorRuleSetCollection
    {
        /// <summary>
        /// Creates a new rule set within the specified profile.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RuleSets_Create. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<FrontDoorRuleSetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using DiagnosticScope scope = _ruleSetsClientDiagnostics.CreateScope("FrontDoorRuleSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _ruleSetsRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, ruleSetName, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                CdnArmOperation<FrontDoorRuleSetResource> operation = new CdnArmOperation<FrontDoorRuleSetResource>(
                    new FrontDoorRuleSetOperationSource(Client),
                    _ruleSetsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.OriginalUri);
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

        /// <summary>
        /// Creates a new rule set within the specified profile.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RuleSets_Create. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<FrontDoorRuleSetResource> CreateOrUpdate(WaitUntil waitUntil, string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using DiagnosticScope scope = _ruleSetsClientDiagnostics.CreateScope("FrontDoorRuleSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _ruleSetsRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, ruleSetName, context);
                Response response = Pipeline.ProcessMessage(message, context);
                CdnArmOperation<FrontDoorRuleSetResource> operation = new CdnArmOperation<FrontDoorRuleSetResource>(
                    new FrontDoorRuleSetOperationSource(Client),
                    _ruleSetsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.OriginalUri);
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
