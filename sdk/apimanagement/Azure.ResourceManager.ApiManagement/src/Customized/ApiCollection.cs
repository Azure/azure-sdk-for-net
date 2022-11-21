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
    /// A class representing a collection of <see cref="ApiResource" /> and their operations.
    /// Each <see cref="ApiResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiCollection" /> instance call the GetApis method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiCollection : ArmCollection, IEnumerable<ApiResource>, IAsyncEnumerable<ApiResource>
    {
        /// <summary>
        /// Lists all APIs of the API Management service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis
        /// Operation Id: Api_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| serviceUrl | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| path | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| isCurrent | filter | eq, ne |  |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="tags"> Include tags in the response. </param>
        /// <param name="expandApiVersionSet"> Include full ApiVersionSet resource in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, string tags = null, bool? expandApiVersionSet = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiClientDiagnostics.CreateScope("ApiCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, tags, expandApiVersionSet, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiClientDiagnostics.CreateScope("ApiCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, tags, expandApiVersionSet, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all APIs of the API Management service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis
        /// Operation Id: Api_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| serviceUrl | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| path | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| isCurrent | filter | eq, ne |  |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="tags"> Include tags in the response. </param>
        /// <param name="expandApiVersionSet"> Include full ApiVersionSet resource in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiResource> GetAll(string filter = null, int? top = null, int? skip = null, string tags = null, bool? expandApiVersionSet = null, CancellationToken cancellationToken = default)
        {
            Page<ApiResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiClientDiagnostics.CreateScope("ApiCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, tags, expandApiVersionSet, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiClientDiagnostics.CreateScope("ApiCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, tags, expandApiVersionSet, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
