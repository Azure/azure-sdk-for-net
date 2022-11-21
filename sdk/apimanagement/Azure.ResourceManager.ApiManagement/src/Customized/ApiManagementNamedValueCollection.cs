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
    /// A class representing a collection of <see cref="ApiManagementNamedValueResource" /> and their operations.
    /// Each <see cref="ApiManagementNamedValueResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementNamedValueCollection" /> instance call the GetApiManagementNamedValues method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementNamedValueCollection : ArmCollection, IEnumerable<ApiManagementNamedValueResource>, IAsyncEnumerable<ApiManagementNamedValueResource>
    {
        /// <summary>
        /// Lists a collection of named values defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/namedValues
        /// Operation Id: NamedValue_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| tags | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith, any, all |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="isKeyVaultRefreshFailed"> When set to true, the response contains only named value entities which failed refresh. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementNamedValueResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementNamedValueResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, bool? isKeyVaultRefreshFailed = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementNamedValueResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementNamedValueNamedValueClientDiagnostics.CreateScope("ApiManagementNamedValueCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementNamedValueNamedValueRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, isKeyVaultRefreshFailed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementNamedValueResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementNamedValueResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementNamedValueNamedValueClientDiagnostics.CreateScope("ApiManagementNamedValueCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementNamedValueNamedValueRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, isKeyVaultRefreshFailed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementNamedValueResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists a collection of named values defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/namedValues
        /// Operation Id: NamedValue_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| tags | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith, any, all |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="isKeyVaultRefreshFailed"> When set to true, the response contains only named value entities which failed refresh. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementNamedValueResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementNamedValueResource> GetAll(string filter = null, int? top = null, int? skip = null, bool? isKeyVaultRefreshFailed = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementNamedValueResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementNamedValueNamedValueClientDiagnostics.CreateScope("ApiManagementNamedValueCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementNamedValueNamedValueRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, isKeyVaultRefreshFailed, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementNamedValueResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementNamedValueResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementNamedValueNamedValueClientDiagnostics.CreateScope("ApiManagementNamedValueCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementNamedValueNamedValueRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, isKeyVaultRefreshFailed, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementNamedValueResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
