// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.HDInsight.Models;

namespace Azure.ResourceManager.HDInsight
{
    // The GetAzureAsyncOperationStatus method was suppressed during TypeSpec migration
    // via @@scope(..., "!csharp") because the /azureasyncoperations/{operationId} path
    // segment creates a phantom sub-resource in the generated code.
    // It is re-implemented here as custom code for backward compatibility.
    public partial class HDInsightApplicationResource
    {
        private string GetApiVersion()
        {
            TryGetApiVersion(ResourceType, out string apiVersion);
            return apiVersion ?? "2025-01-15-preview";
        }

        /// <summary>
        /// Gets the async operation status.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/applications/{applicationName}/azureasyncoperations/{operationId}
        /// </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        public virtual async Task<Response<HDInsightAsyncOperationResult>> GetAzureAsyncOperationStatusAsync(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _applicationsClientDiagnostics.CreateScope("HDInsightApplicationResource.GetAzureAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreateGetAzureAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, operationId, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                HDInsightAsyncOperationResult result = HDInsightAsyncOperationResult.FromResponse(response);
                return Response.FromValue(result, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the async operation status.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HDInsight/clusters/{clusterName}/applications/{applicationName}/azureasyncoperations/{operationId}
        /// </summary>
        /// <param name="operationId"> The long running operation id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        public virtual Response<HDInsightAsyncOperationResult> GetAzureAsyncOperationStatus(string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using DiagnosticScope scope = _applicationsClientDiagnostics.CreateScope("HDInsightApplicationResource.GetAzureAsyncOperationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreateGetAzureAsyncOperationStatusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, operationId, context);
                Response response = Pipeline.ProcessMessage(message, context);
                HDInsightAsyncOperationResult result = HDInsightAsyncOperationResult.FromResponse(response);
                return Response.FromValue(result, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateGetAzureAsyncOperationStatusRequest(string subscriptionId, string resourceGroupName, string clusterName, string applicationName, string operationId, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(Endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.HDInsight/clusters/", false);
            uri.AppendPath(clusterName, true);
            uri.AppendPath("/applications/", false);
            uri.AppendPath(applicationName, true);
            uri.AppendPath("/azureasyncoperations/", false);
            uri.AppendPath(operationId, true);
            uri.AppendQuery("api-version", GetApiVersion(), true);
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }
    }
}
