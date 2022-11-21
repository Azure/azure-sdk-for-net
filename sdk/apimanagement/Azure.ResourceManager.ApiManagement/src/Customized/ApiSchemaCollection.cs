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
    /// A class representing a collection of <see cref="ApiSchemaResource" /> and their operations.
    /// Each <see cref="ApiSchemaResource" /> in the collection will belong to the same instance of <see cref="ApiResource" />.
    /// To get an <see cref="ApiSchemaCollection" /> instance call the GetApiSchemas method from an instance of <see cref="ApiResource" />.
    /// </summary>
    public partial class ApiSchemaCollection : ArmCollection, IEnumerable<ApiSchemaResource>, IAsyncEnumerable<ApiSchemaResource>
    {
        /// <summary>
        /// Get the schema configuration at the API level.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/schemas
        /// Operation Id: ApiSchema_ListByApi
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| contentType | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiSchemaResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiSchemaResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiSchemaResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiSchemaClientDiagnostics.CreateScope("ApiSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiSchemaRestClient.ListByApiAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiSchemaResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiSchemaClientDiagnostics.CreateScope("ApiSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiSchemaRestClient.ListByApiNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Get the schema configuration at the API level.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/schemas
        /// Operation Id: ApiSchema_ListByApi
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| contentType | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiSchemaResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiSchemaResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiSchemaResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiSchemaClientDiagnostics.CreateScope("ApiSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiSchemaRestClient.ListByApi(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiSchemaResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiSchemaClientDiagnostics.CreateScope("ApiSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiSchemaRestClient.ListByApiNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
