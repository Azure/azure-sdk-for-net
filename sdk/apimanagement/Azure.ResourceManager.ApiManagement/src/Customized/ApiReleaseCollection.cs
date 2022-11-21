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
    /// A class representing a collection of <see cref="ApiReleaseResource" /> and their operations.
    /// Each <see cref="ApiReleaseResource" /> in the collection will belong to the same instance of <see cref="ApiResource" />.
    /// To get an <see cref="ApiReleaseCollection" /> instance call the GetApiReleases method from an instance of <see cref="ApiResource" />.
    /// </summary>
    public partial class ApiReleaseCollection : ArmCollection, IEnumerable<ApiReleaseResource>, IAsyncEnumerable<ApiReleaseResource>
    {
        /// <summary>
        /// Lists all releases of an API. An API release is created when making an API Revision current. Releases are also used to rollback to previous revisions. Results will be paged and can be constrained by the $top and $skip parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/releases
        /// Operation Id: ApiRelease_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| notes | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiReleaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiReleaseResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiReleaseResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiReleaseClientDiagnostics.CreateScope("ApiReleaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiReleaseRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiReleaseResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiReleaseResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiReleaseClientDiagnostics.CreateScope("ApiReleaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiReleaseRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiReleaseResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all releases of an API. An API release is created when making an API Revision current. Releases are also used to rollback to previous revisions. Results will be paged and can be constrained by the $top and $skip parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/releases
        /// Operation Id: ApiRelease_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| notes | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiReleaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiReleaseResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiReleaseResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiReleaseClientDiagnostics.CreateScope("ApiReleaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiReleaseRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiReleaseResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiReleaseResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiReleaseClientDiagnostics.CreateScope("ApiReleaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiReleaseRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiReleaseResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
