// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EdgeOrder.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    // Add an Update method whose parameter ifMatch is of type ETag;
    // this method needs to be removed after the generator issue is fixed.
    // Related issues: https://github.com/Azure/azure-sdk-for-net/issues/55024
    public partial class EdgeOrderItemResource
    {
        /// <summary>
        /// Updates the properties of an existing order item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/orderItems/{orderItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateOrderItem</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EdgeOrderItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> order item update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the order on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<EdgeOrderItemResource>> UpdateAsync(WaitUntil waitUntil, EdgeOrderItemPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, patch, new ETag(ifMatch), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the properties of an existing order item.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/orderItems/{orderItemName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateOrderItem</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EdgeOrderItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> order item update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the order on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<EdgeOrderItemResource> Update(WaitUntil waitUntil, EdgeOrderItemPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, patch, new ETag(ifMatch), cancellationToken);
        }

        /// <summary>
        /// Update the properties of an existing order item.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/orderItems/{orderItemName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> OrderItemResources_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-02-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="EdgeOrderItemResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Order item update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the order on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<ArmOperation<EdgeOrderItemResource>> UpdateAsync(WaitUntil waitUntil, EdgeOrderItemPatch patch, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _orderItemResourcesClientDiagnostics.CreateScope("EdgeOrderItemResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _orderItemResourcesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, EdgeOrderItemPatch.ToRequestContent(patch), ifMatch, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                EdgeOrderArmOperation<EdgeOrderItemResource> operation = new EdgeOrderArmOperation<EdgeOrderItemResource>(
                    new EdgeOrderItemOperationSource(Client),
                    _orderItemResourcesClientDiagnostics,
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
        /// Update the properties of an existing order item.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/orderItems/{orderItemName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> OrderItemResources_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-02-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="EdgeOrderItemResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Order item update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the order on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<EdgeOrderItemResource> Update(WaitUntil waitUntil, EdgeOrderItemPatch patch, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _orderItemResourcesClientDiagnostics.CreateScope("EdgeOrderItemResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _orderItemResourcesRestClient.CreateUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, EdgeOrderItemPatch.ToRequestContent(patch), ifMatch, context);
                Response response = Pipeline.ProcessMessage(message, context);
                EdgeOrderArmOperation<EdgeOrderItemResource> operation = new EdgeOrderArmOperation<EdgeOrderItemResource>(
                    new EdgeOrderItemOperationSource(Client),
                    _orderItemResourcesClientDiagnostics,
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
