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
    /// A class representing a collection of <see cref="ApiVersionSetResource" /> and their operations.
    /// Each <see cref="ApiVersionSetResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiVersionSetCollection" /> instance call the GetApiVersionSets method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiVersionSetCollection : ArmCollection, IEnumerable<ApiVersionSetResource>, IAsyncEnumerable<ApiVersionSetResource>
    {
        /// <summary>
        /// Lists a collection of API Version Sets in the specified service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apiVersionSets
        /// Operation Id: ApiVersionSet_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiVersionSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiVersionSetResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiVersionSetResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiVersionSetClientDiagnostics.CreateScope("ApiVersionSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiVersionSetRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiVersionSetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiVersionSetResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiVersionSetClientDiagnostics.CreateScope("ApiVersionSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiVersionSetRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiVersionSetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists a collection of API Version Sets in the specified service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apiVersionSets
        /// Operation Id: ApiVersionSet_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiVersionSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiVersionSetResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiVersionSetResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiVersionSetClientDiagnostics.CreateScope("ApiVersionSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiVersionSetRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiVersionSetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiVersionSetResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiVersionSetClientDiagnostics.CreateScope("ApiVersionSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiVersionSetRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiVersionSetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
