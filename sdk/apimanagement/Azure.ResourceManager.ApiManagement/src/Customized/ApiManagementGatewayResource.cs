// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A Class representing an ApiManagementGateway along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="ApiManagementGatewayResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetApiManagementGatewayResource method.
    /// Otherwise you can get one from its parent resource <see cref="ApiManagementServiceResource" /> using the GetApiManagementGateway method.
    /// </summary>
    public partial class ApiManagementGatewayResource : ArmResource
    {
        /// <summary>
        /// Lists a collection of the APIs associated with a gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/apis
        /// Operation Id: GatewayApi_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GatewayApiData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GatewayApiData> GetGatewayApisByServiceAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<GatewayApiData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _gatewayApiClientDiagnostics.CreateScope("ApiManagementGatewayResource.GetGatewayApisByService");
                scope.Start();
                try
                {
                    var response = await _gatewayApiRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<GatewayApiData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _gatewayApiClientDiagnostics.CreateScope("ApiManagementGatewayResource.GetGatewayApisByService");
                scope.Start();
                try
                {
                    var response = await _gatewayApiRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists a collection of the APIs associated with a gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/apis
        /// Operation Id: GatewayApi_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GatewayApiData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GatewayApiData> GetGatewayApisByService(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<GatewayApiData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _gatewayApiClientDiagnostics.CreateScope("ApiManagementGatewayResource.GetGatewayApisByService");
                scope.Start();
                try
                {
                    var response = _gatewayApiRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<GatewayApiData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _gatewayApiClientDiagnostics.CreateScope("ApiManagementGatewayResource.GetGatewayApisByService");
                scope.Start();
                try
                {
                    var response = _gatewayApiRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
