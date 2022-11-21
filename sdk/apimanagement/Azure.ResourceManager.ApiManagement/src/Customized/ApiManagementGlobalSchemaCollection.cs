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
    /// A class representing a collection of <see cref="ApiManagementGlobalSchemaResource" /> and their operations.
    /// Each <see cref="ApiManagementGlobalSchemaResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementGlobalSchemaCollection" /> instance call the GetApiManagementGlobalSchemas method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementGlobalSchemaCollection : ArmCollection, IEnumerable<ApiManagementGlobalSchemaResource>, IAsyncEnumerable<ApiManagementGlobalSchemaResource>
    {
        /// <summary>
        /// Lists a collection of schemas registered with service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/schemas
        /// Operation Id: GlobalSchema_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementGlobalSchemaResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementGlobalSchemaResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementGlobalSchemaResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementGlobalSchemaGlobalSchemaClientDiagnostics.CreateScope("ApiManagementGlobalSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementGlobalSchemaGlobalSchemaRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGlobalSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementGlobalSchemaResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementGlobalSchemaGlobalSchemaClientDiagnostics.CreateScope("ApiManagementGlobalSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementGlobalSchemaGlobalSchemaRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGlobalSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists a collection of schemas registered with service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/schemas
        /// Operation Id: GlobalSchema_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementGlobalSchemaResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementGlobalSchemaResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementGlobalSchemaResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementGlobalSchemaGlobalSchemaClientDiagnostics.CreateScope("ApiManagementGlobalSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementGlobalSchemaGlobalSchemaRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGlobalSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementGlobalSchemaResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementGlobalSchemaGlobalSchemaClientDiagnostics.CreateScope("ApiManagementGlobalSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementGlobalSchemaGlobalSchemaRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGlobalSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
