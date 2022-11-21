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
    /// A class representing a collection of <see cref="ApiManagementPortalRevisionResource" /> and their operations.
    /// Each <see cref="ApiManagementPortalRevisionResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementPortalRevisionCollection" /> instance call the GetApiManagementPortalRevisions method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementPortalRevisionCollection : ArmCollection, IEnumerable<ApiManagementPortalRevisionResource>, IAsyncEnumerable<ApiManagementPortalRevisionResource>
    {
        /// <summary>
        /// Lists developer portal&apos;s revisions.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/portalRevisions
        /// Operation Id: PortalRevision_ListByService
        /// </summary>
        /// <param name="filter">
        /// | Field       | Supported operators    | Supported functions               |
        /// |-------------|------------------------|-----------------------------------|
        ///
        /// |name | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith|
        /// |description | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith|
        /// |isCurrent | eq, ne |    |
        ///
        /// </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementPortalRevisionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementPortalRevisionResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementPortalRevisionResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementPortalRevisionPortalRevisionClientDiagnostics.CreateScope("ApiManagementPortalRevisionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementPortalRevisionPortalRevisionRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementPortalRevisionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementPortalRevisionResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementPortalRevisionPortalRevisionClientDiagnostics.CreateScope("ApiManagementPortalRevisionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementPortalRevisionPortalRevisionRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementPortalRevisionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists developer portal&apos;s revisions.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/portalRevisions
        /// Operation Id: PortalRevision_ListByService
        /// </summary>
        /// <param name="filter">
        /// | Field       | Supported operators    | Supported functions               |
        /// |-------------|------------------------|-----------------------------------|
        ///
        /// |name | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith|
        /// |description | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith|
        /// |isCurrent | eq, ne |    |
        ///
        /// </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementPortalRevisionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementPortalRevisionResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementPortalRevisionResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementPortalRevisionPortalRevisionClientDiagnostics.CreateScope("ApiManagementPortalRevisionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementPortalRevisionPortalRevisionRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementPortalRevisionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementPortalRevisionResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementPortalRevisionPortalRevisionClientDiagnostics.CreateScope("ApiManagementPortalRevisionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementPortalRevisionPortalRevisionRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementPortalRevisionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
