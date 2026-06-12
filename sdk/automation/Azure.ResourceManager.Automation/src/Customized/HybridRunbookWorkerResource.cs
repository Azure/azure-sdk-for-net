// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    // Compatibility shim preserving the GA Update signature backed by the service PUT create operation.
    public partial class HybridRunbookWorkerResource
    {
        /// <summary>
        /// Create a hybrid runbook worker.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/hybridRunbookWorkerGroups/{hybridRunbookWorkerGroupName}/hybridRunbookWorkers/{hybridRunbookWorkerId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> HybridRunbookWorkers_Create. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The create or update parameters for hybrid runbook worker. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<HybridRunbookWorkerResource>> UpdateAsync(WaitUntil waitUntil, HybridRunbookWorkerCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _hybridRunbookWorkersClientDiagnostics.CreateScope("HybridRunbookWorkerResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _hybridRunbookWorkersRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, HybridRunbookWorkerCreateOrUpdateContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<HybridRunbookWorkerData> response = Response.FromValue(HybridRunbookWorkerData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                AutomationArmOperation<HybridRunbookWorkerResource> operation = new AutomationArmOperation<HybridRunbookWorkerResource>(Response.FromValue(new HybridRunbookWorkerResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// Create a hybrid runbook worker.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/hybridRunbookWorkerGroups/{hybridRunbookWorkerGroupName}/hybridRunbookWorkers/{hybridRunbookWorkerId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> HybridRunbookWorkers_Create. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The create or update parameters for hybrid runbook worker. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<HybridRunbookWorkerResource> Update(WaitUntil waitUntil, HybridRunbookWorkerCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _hybridRunbookWorkersClientDiagnostics.CreateScope("HybridRunbookWorkerResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _hybridRunbookWorkersRestClient.CreateCreateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, HybridRunbookWorkerCreateOrUpdateContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<HybridRunbookWorkerData> response = Response.FromValue(HybridRunbookWorkerData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                AutomationArmOperation<HybridRunbookWorkerResource> operation = new AutomationArmOperation<HybridRunbookWorkerResource>(Response.FromValue(new HybridRunbookWorkerResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
