// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Search.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Search
{
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(SearchManagementRequestOptions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(SearchManagementRequestOptions), typeof(CancellationToken))]

    public partial class SearchPrivateEndpointConnectionResource
    {
        /// <summary>
        /// Disconnects the private endpoint connection and deletes it from the search service.
        /// Returns 200 (OK) with the deleted connection details on successful deletion, or 404 (Not Found) if the connection does not exist.
        /// NOTE: The behavior of returning 404 is inconsistent with ARM guidelines. Clients should expect a 204 response in future versions and avoid new dependencies on the 404 response.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Search/searchServices/{searchServiceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SearchPrivateEndpointConnectionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="searchManagementRequestOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<SearchPrivateEndpointConnectionResource>> DeleteAsync(WaitUntil waitUntil, SearchManagementRequestOptions searchManagementRequestOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _privateEndpointConnectionsClientDiagnostics.CreateScope("SearchPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _privateEndpointConnectionsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, default, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<SearchPrivateEndpointConnectionData> response = Response.FromValue(SearchPrivateEndpointConnectionData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SearchArmOperation<SearchPrivateEndpointConnectionResource> operation = new SearchArmOperation<SearchPrivateEndpointConnectionResource>(Response.FromValue(new SearchPrivateEndpointConnectionResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// Disconnects the private endpoint connection and deletes it from the search service.
        /// Returns 200 (OK) with the deleted connection details on successful deletion, or 404 (Not Found) if the connection does not exist.
        /// NOTE: The behavior of returning 404 is inconsistent with ARM guidelines. Clients should expect a 204 response in future versions and avoid new dependencies on the 404 response.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Search/searchServices/{searchServiceName}/privateEndpointConnections/{privateEndpointConnectionName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SearchPrivateEndpointConnectionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="searchManagementRequestOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<SearchPrivateEndpointConnectionResource> Delete(WaitUntil waitUntil, SearchManagementRequestOptions searchManagementRequestOptions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _privateEndpointConnectionsClientDiagnostics.CreateScope("SearchPrivateEndpointConnectionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _privateEndpointConnectionsRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, default, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<SearchPrivateEndpointConnectionData> response = Response.FromValue(SearchPrivateEndpointConnectionData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SearchArmOperation<SearchPrivateEndpointConnectionResource> operation = new SearchArmOperation<SearchPrivateEndpointConnectionResource>(Response.FromValue(new SearchPrivateEndpointConnectionResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
