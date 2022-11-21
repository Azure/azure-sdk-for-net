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
    /// A class representing a collection of <see cref="ApiManagementTagResource" /> and their operations.
    /// Each <see cref="ApiManagementTagResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementTagCollection" /> instance call the GetApiManagementTags method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementTagCollection : ArmCollection, IEnumerable<ApiManagementTagResource>, IAsyncEnumerable<ApiManagementTagResource>
    {
        /// <summary>
        /// Lists a collection of tags defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tags
        /// Operation Id: Tag_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="scope"> Scope like &apos;apis&apos;, &apos;products&apos; or &apos;apis/{apiId}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementTagResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementTagResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, string scope = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementTagResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope0 = _apiManagementTagTagClientDiagnostics.CreateScope("ApiManagementTagCollection.GetAll");
                scope0.Start();
                try
                {
                    var response = await _apiManagementTagTagRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, scope, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementTagResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementTagResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope0 = _apiManagementTagTagClientDiagnostics.CreateScope("ApiManagementTagCollection.GetAll");
                scope0.Start();
                try
                {
                    var response = await _apiManagementTagTagRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, scope, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementTagResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists a collection of tags defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tags
        /// Operation Id: Tag_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="scope"> Scope like &apos;apis&apos;, &apos;products&apos; or &apos;apis/{apiId}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementTagResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementTagResource> GetAll(string filter = null, int? top = null, int? skip = null, string scope = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementTagResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope0 = _apiManagementTagTagClientDiagnostics.CreateScope("ApiManagementTagCollection.GetAll");
                scope0.Start();
                try
                {
                    var response = _apiManagementTagTagRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, scope, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementTagResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementTagResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope0 = _apiManagementTagTagClientDiagnostics.CreateScope("ApiManagementTagCollection.GetAll");
                scope0.Start();
                try
                {
                    var response = _apiManagementTagTagRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, scope, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementTagResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope0.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
