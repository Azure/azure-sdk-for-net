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
    /// A class representing a collection of <see cref="ApiManagementProductResource" /> and their operations.
    /// Each <see cref="ApiManagementProductResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementProductCollection" /> instance call the GetApiManagementProducts method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementProductCollection : ArmCollection, IEnumerable<ApiManagementProductResource>, IAsyncEnumerable<ApiManagementProductResource>
    {
        /// <summary>
        /// Lists a collection of products in the specified service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products
        /// Operation Id: Product_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| terms | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;| groups | expand |     |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="expandGroups"> When set to true, the response contains an array of groups that have visibility to the product. The default is false. </param>
        /// <param name="tags"> Products which are part of a specific tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementProductResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementProductResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, bool? expandGroups = null, string tags = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementProductResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementProductProductClientDiagnostics.CreateScope("ApiManagementProductCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementProductProductRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, expandGroups, tags, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementProductResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementProductResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementProductProductClientDiagnostics.CreateScope("ApiManagementProductCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementProductProductRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, expandGroups, tags, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementProductResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists a collection of products in the specified service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products
        /// Operation Id: Product_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| terms | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;| groups | expand |     |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="expandGroups"> When set to true, the response contains an array of groups that have visibility to the product. The default is false. </param>
        /// <param name="tags"> Products which are part of a specific tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementProductResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementProductResource> GetAll(string filter = null, int? top = null, int? skip = null, bool? expandGroups = null, string tags = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementProductResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementProductProductClientDiagnostics.CreateScope("ApiManagementProductCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementProductProductRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, expandGroups, tags, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementProductResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementProductResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementProductProductClientDiagnostics.CreateScope("ApiManagementProductCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementProductProductRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, expandGroups, tags, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementProductResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
