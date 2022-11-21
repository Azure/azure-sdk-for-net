// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiManagementAuthorizationServerResource" /> and their operations.
    /// Each <see cref="ApiManagementAuthorizationServerResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementAuthorizationServerCollection" /> instance call the GetApiManagementAuthorizationServers method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementAuthorizationServerCollection : ArmCollection, IEnumerable<ApiManagementAuthorizationServerResource>, IAsyncEnumerable<ApiManagementAuthorizationServerResource>
    {
        /// <summary>
        /// Lists a collection of authorization servers defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/authorizationServers
        /// Operation Id: AuthorizationServer_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementAuthorizationServerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementAuthorizationServerResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementAuthorizationServerResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementAuthorizationServerAuthorizationServerClientDiagnostics.CreateScope("ApiManagementAuthorizationServerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementAuthorizationServerAuthorizationServerRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementAuthorizationServerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementAuthorizationServerResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementAuthorizationServerAuthorizationServerClientDiagnostics.CreateScope("ApiManagementAuthorizationServerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementAuthorizationServerAuthorizationServerRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementAuthorizationServerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists a collection of authorization servers defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/authorizationServers
        /// Operation Id: AuthorizationServer_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementAuthorizationServerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementAuthorizationServerResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementAuthorizationServerResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementAuthorizationServerAuthorizationServerClientDiagnostics.CreateScope("ApiManagementAuthorizationServerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementAuthorizationServerAuthorizationServerRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementAuthorizationServerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementAuthorizationServerResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementAuthorizationServerAuthorizationServerClientDiagnostics.CreateScope("ApiManagementAuthorizationServerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementAuthorizationServerAuthorizationServerRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementAuthorizationServerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
