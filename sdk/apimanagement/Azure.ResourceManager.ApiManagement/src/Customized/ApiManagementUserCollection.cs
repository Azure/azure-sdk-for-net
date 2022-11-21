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
    /// A class representing a collection of <see cref="ApiManagementUserResource" /> and their operations.
    /// Each <see cref="ApiManagementUserResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementUserCollection" /> instance call the GetApiManagementUsers method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementUserCollection : ArmCollection, IEnumerable<ApiManagementUserResource>, IAsyncEnumerable<ApiManagementUserResource>
    {
        /// <summary>
        /// Lists a collection of registered users in the specified service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/users
        /// Operation Id: User_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| firstName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| lastName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| email | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;| registrationDate | filter | ge, le, eq, ne, gt, lt |     |&lt;/br&gt;| note | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| groups | expand |     |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="expandGroups"> Detailed Group in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementUserResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementUserResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, bool? expandGroups = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementUserResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementUserUserClientDiagnostics.CreateScope("ApiManagementUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementUserUserRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, expandGroups, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementUserResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementUserResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementUserUserClientDiagnostics.CreateScope("ApiManagementUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementUserUserRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, expandGroups, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementUserResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists a collection of registered users in the specified service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/users
        /// Operation Id: User_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| firstName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| lastName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| email | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;| registrationDate | filter | ge, le, eq, ne, gt, lt |     |&lt;/br&gt;| note | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| groups | expand |     |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="expandGroups"> Detailed Group in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementUserResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementUserResource> GetAll(string filter = null, int? top = null, int? skip = null, bool? expandGroups = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementUserResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementUserUserClientDiagnostics.CreateScope("ApiManagementUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementUserUserRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, expandGroups, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementUserResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementUserResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementUserUserClientDiagnostics.CreateScope("ApiManagementUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementUserUserRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, expandGroups, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementUserResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
