// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.DataBox.Models;

namespace Azure.ResourceManager.DataBox
{
    public partial class DataBoxJobResource
    {
        /// <summary>
        /// Updates the properties of an existing job.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBox/jobs/{jobName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobResources_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-07-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DataBoxJobResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Job update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the job on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataBoxJobResource>> UpdateAsync(WaitUntil waitUntil, DataBoxJobPatch patch, string ifMatch, CancellationToken cancellationToken)
        {
            ETag? ifMatchETag = ifMatch != null ? new ETag(ifMatch) : null;
            return await UpdateAsync(waitUntil, patch, ifMatchETag, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the properties of an existing job.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBox/jobs/{jobName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobResources_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-07-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DataBoxJobResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Job update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the job on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataBoxJobResource> Update(WaitUntil waitUntil, DataBoxJobPatch patch, string ifMatch, CancellationToken cancellationToken)
        {
            ETag? ifMatchETag = ifMatch != null ? new ETag(ifMatch) : null;
            return Update(waitUntil, patch, ifMatchETag, cancellationToken);
        }

        /// <summary>
        /// Updates the properties of an existing job.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBox/jobs/{jobName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobResources_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-07-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DataBoxJobResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Job update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the job on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<ArmOperation<DataBoxJobResource>> UpdateAsync(WaitUntil waitUntil, DataBoxJobPatch patch, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _jobResourcesClientDiagnostics.CreateScope("DataBoxJobResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobResourcesRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, DataBoxJobPatch.ToRequestContent(patch), ifMatch, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                DataBoxArmOperation<DataBoxJobResource> operation = new DataBoxArmOperation<DataBoxJobResource>(
                    new DataBoxJobOperationSource(Client),
                    _jobResourcesClientDiagnostics,
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
        /// Updates the properties of an existing job.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBox/jobs/{jobName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> JobResources_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-07-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DataBoxJobResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Job update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the job on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<DataBoxJobResource> Update(WaitUntil waitUntil, DataBoxJobPatch patch, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _jobResourcesClientDiagnostics.CreateScope("DataBoxJobResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _jobResourcesRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, DataBoxJobPatch.ToRequestContent(patch), ifMatch, context);
                Response response = Pipeline.ProcessMessage(message, context);
                DataBoxArmOperation<DataBoxJobResource> operation = new DataBoxArmOperation<DataBoxJobResource>(
                    new DataBoxJobOperationSource(Client),
                    _jobResourcesClientDiagnostics,
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
