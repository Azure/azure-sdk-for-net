// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    public partial class HybridRunbookWorkerResource
    {
        /// <summary>
        /// Create a hybrid runbook worker.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The create or update parameters for hybrid runbook worker. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<HybridRunbookWorkerResource>> UpdateAsync(WaitUntil waitUntil, HybridRunbookWorkerCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _hybridRunbookWorkerClientDiagnostics.CreateScope("HybridRunbookWorkerResource.Update");
            scope.Start();
            try
            {
                var response = await _hybridRunbookWorkerRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var uri = _hybridRunbookWorkerRestClient.CreateCreateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, content);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new AutomationArmOperation<HybridRunbookWorkerResource>(Response.FromValue(new HybridRunbookWorkerResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
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
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The create or update parameters for hybrid runbook worker. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]public virtual ArmOperation<HybridRunbookWorkerResource> Update(WaitUntil waitUntil, HybridRunbookWorkerCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _hybridRunbookWorkerClientDiagnostics.CreateScope("HybridRunbookWorkerResource.Update");
            scope.Start();
            try
            {
                var response = _hybridRunbookWorkerRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, content, cancellationToken);
                var uri = _hybridRunbookWorkerRestClient.CreateCreateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, content);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new AutomationArmOperation<HybridRunbookWorkerResource>(Response.FromValue(new HybridRunbookWorkerResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
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
