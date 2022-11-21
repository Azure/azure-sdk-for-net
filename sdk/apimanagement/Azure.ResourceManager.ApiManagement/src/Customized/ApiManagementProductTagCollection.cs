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
    /// A class representing a collection of <see cref="ApiManagementProductTagResource" /> and their operations.
    /// Each <see cref="ApiManagementProductTagResource" /> in the collection will belong to the same instance of <see cref="ApiManagementProductResource" />.
    /// To get an <see cref="ApiManagementProductTagCollection" /> instance call the GetApiManagementProductTags method from an instance of <see cref="ApiManagementProductResource" />.
    /// </summary>
    public partial class ApiManagementProductTagCollection : ArmCollection, IEnumerable<ApiManagementProductTagResource>, IAsyncEnumerable<ApiManagementProductTagResource>
    {
        /// <summary>
        /// Lists all Tags associated with the Product.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/tags
        /// Operation Id: Tag_ListByProduct
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementProductTagResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementProductTagResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementProductTagResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementProductTagTagClientDiagnostics.CreateScope("ApiManagementProductTagCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementProductTagTagRestClient.ListByProductAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementProductTagResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementProductTagResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementProductTagTagClientDiagnostics.CreateScope("ApiManagementProductTagCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementProductTagTagRestClient.ListByProductNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementProductTagResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all Tags associated with the Product.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/tags
        /// Operation Id: Tag_ListByProduct
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementProductTagResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementProductTagResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementProductTagResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementProductTagTagClientDiagnostics.CreateScope("ApiManagementProductTagCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementProductTagTagRestClient.ListByProduct(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementProductTagResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementProductTagResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementProductTagTagClientDiagnostics.CreateScope("ApiManagementProductTagCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementProductTagTagRestClient.ListByProductNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementProductTagResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
