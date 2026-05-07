// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Models;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    // The TypeSpec emitter misclassifies ReplicationJobsOperationGroup.export as a List operation
    // on the Job resource and emits it as the collection's GetAll(WaitUntil, content, ...). The
    // baseline exposed it as Export/ExportAsync on SiteRecoveryJobResource (the action ignores the
    // resource's own job name and operates at the vault scope). Restore that shape here.
    public partial class SiteRecoveryJobResource
    {
        /// <summary>
        /// The operation to export the details of the Azure Site Recovery jobs of the vault.
        /// <list type="bullet">
        /// <item><term> Request Path. </term><description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationJobs/export. </description></item>
        /// <item><term> Operation Id. </term><description> ReplicationJobsOperationGroup_Export. </description></item>
        /// <item><term> Default Api Version. </term><description> 2026-01-01. </description></item>
        /// <item><term> Resource. </term><description> <see cref="SiteRecoveryJobResource"/>. </description></item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<SiteRecoveryJobResource>> ExportAsync(WaitUntil waitUntil, SiteRecoveryJobQueryContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _replicationJobsClientDiagnostics.CreateScope("SiteRecoveryJobResource.Export");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _replicationJobsRestClient.CreateExportRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, SiteRecoveryJobQueryContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                RecoveryServicesSiteRecoveryArmOperation<SiteRecoveryJobResource> operation = new RecoveryServicesSiteRecoveryArmOperation<SiteRecoveryJobResource>(
                    new SiteRecoveryJobOperationSource(Client),
                    _replicationJobsClientDiagnostics,
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

        /// <summary>
        /// The operation to export the details of the Azure Site Recovery jobs of the vault.
        /// <list type="bullet">
        /// <item><term> Request Path. </term><description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationJobs/export. </description></item>
        /// <item><term> Operation Id. </term><description> ReplicationJobsOperationGroup_Export. </description></item>
        /// <item><term> Default Api Version. </term><description> 2026-01-01. </description></item>
        /// <item><term> Resource. </term><description> <see cref="SiteRecoveryJobResource"/>. </description></item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<SiteRecoveryJobResource> Export(WaitUntil waitUntil, SiteRecoveryJobQueryContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _replicationJobsClientDiagnostics.CreateScope("SiteRecoveryJobResource.Export");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _replicationJobsRestClient.CreateExportRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, SiteRecoveryJobQueryContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                RecoveryServicesSiteRecoveryArmOperation<SiteRecoveryJobResource> operation = new RecoveryServicesSiteRecoveryArmOperation<SiteRecoveryJobResource>(
                    new SiteRecoveryJobOperationSource(Client),
                    _replicationJobsClientDiagnostics,
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
