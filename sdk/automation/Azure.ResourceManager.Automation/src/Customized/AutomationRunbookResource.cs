// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Automation
{
    /// <summary>
    /// A Class representing an AutomationRunbook along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="AutomationRunbookResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetAutomationRunbookResource method.
    /// Otherwise you can get one from its parent resource <see cref="AutomationAccountResource" /> using the GetAutomationRunbook method.
    /// </summary>
    public partial class AutomationRunbookResource
    {
        /// <summary>
        /// Replaces the runbook draft content.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/runbooks/{runbookName}/draft/content</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RunbookDraft_ReplaceContent</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="runbookContent"> The runbook draft content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runbookContent"/> is null. </exception>
        public virtual async Task<ArmOperation> ReplaceContentRunbookDraftAsync(WaitUntil waitUntil, Stream runbookContent, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(runbookContent, nameof(runbookContent));

            using var scope = _runbookDraftClientDiagnostics.CreateScope("AutomationRunbookResource.ReplaceContentRunbookDraft");
            scope.Start();
            try
            {
                var response = await _runbookDraftRestClient.ReplaceContentAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, runbookContent, cancellationToken).ConfigureAwait(false);
                var operation = new AutomationArmOperation(_runbookDraftClientDiagnostics, Pipeline, _runbookDraftRestClient.CreateReplaceContentRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, runbookContent, true).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replaces the runbook draft content.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/runbooks/{runbookName}/draft/content</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RunbookDraft_ReplaceContent</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="runbookContent"> The runbook draft content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runbookContent"/> is null. </exception>
        public virtual ArmOperation ReplaceContentRunbookDraft(WaitUntil waitUntil, Stream runbookContent, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(runbookContent, nameof(runbookContent));

            using var scope = _runbookDraftClientDiagnostics.CreateScope("AutomationRunbookResource.ReplaceContentRunbookDraft");
            scope.Start();
            try
            {
                var response = _runbookDraftRestClient.ReplaceContent(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, runbookContent, cancellationToken);
                var operation = new AutomationArmOperation(_runbookDraftClientDiagnostics, Pipeline, _runbookDraftRestClient.CreateReplaceContentRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, runbookContent, true).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
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
