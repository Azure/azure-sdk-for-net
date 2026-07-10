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
using Azure.ResourceManager.Search.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Search
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<SearchPrivateEndpointConnectionResource>.
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(SearchManagementRequestOptions), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(SearchManagementRequestOptions), typeof(CancellationToken))]
    public partial class SearchPrivateEndpointConnectionResource
    {
        /// <summary> Disconnects the private endpoint connection and deletes it from the search service. </summary>
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
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SearchArmOperation<SearchPrivateEndpointConnectionResource> operation = new SearchArmOperation<SearchPrivateEndpointConnectionResource>(Response.FromValue(new SearchPrivateEndpointConnectionResource(Client, Id), response), rehydrationToken);
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

        /// <summary> Disconnects the private endpoint connection and deletes it from the search service. </summary>
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
                Response response = Pipeline.ProcessMessage(message, context);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SearchArmOperation<SearchPrivateEndpointConnectionResource> operation = new SearchArmOperation<SearchPrivateEndpointConnectionResource>(Response.FromValue(new SearchPrivateEndpointConnectionResource(Client, Id), response), rehydrationToken);
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
