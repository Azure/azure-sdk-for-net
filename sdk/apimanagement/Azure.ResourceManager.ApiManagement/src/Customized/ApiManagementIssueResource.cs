// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement
{
    // the core method should only take an intersection of the optional parameters on those common methods
    [CodeGenSuppress("GetCoreAsync", typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("GetCore", typeof(bool?), typeof(CancellationToken))]
    public partial class ApiManagementIssueResource : IssueContractResource
    {
        /// <summary>
        /// The core implementation for operation Get
        /// Gets API Management issue details
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/issues/{issueId}
        /// Operation Id: Issue_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        protected override async Task<Response<IssueContractResource>> GetCoreAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _apiManagementIssueIssueClientDiagnostics.CreateScope("ApiManagementIssueResource.Get");
            scope.Start();
            try
            {
                var response = await _apiManagementIssueIssueRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(GetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets API Management issue details
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/issues/{issueId}
        /// Operation Id: Issue_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual new async Task<Response<ApiManagementIssueResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await GetCoreAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue((ApiManagementIssueResource)result.Value, result.GetRawResponse());
        }

        /// <summary>
        /// The core implementation for operation Get
        /// Gets API Management issue details
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/issues/{issueId}
        /// Operation Id: Issue_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        protected override Response<IssueContractResource> GetCore(CancellationToken cancellationToken = default)
        {
            using var scope = _apiManagementIssueIssueClientDiagnostics.CreateScope("ApiManagementIssueResource.Get");
            scope.Start();
            try
            {
                var response = _apiManagementIssueIssueRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(GetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets API Management issue details
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/issues/{issueId}
        /// Operation Id: Issue_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual new Response<ApiManagementIssueResource> Get(CancellationToken cancellationToken = default)
        {
            var result = GetCore(cancellationToken);
            return Response.FromValue((ApiManagementIssueResource)result.Value, result.GetRawResponse());
        }
    }
}
