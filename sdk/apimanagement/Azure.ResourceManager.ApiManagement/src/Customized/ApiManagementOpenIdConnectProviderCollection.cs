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
    /// A class representing a collection of <see cref="ApiManagementOpenIdConnectProviderResource" /> and their operations.
    /// Each <see cref="ApiManagementOpenIdConnectProviderResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementOpenIdConnectProviderCollection" /> instance call the GetApiManagementOpenIdConnectProviders method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementOpenIdConnectProviderCollection : ArmCollection, IEnumerable<ApiManagementOpenIdConnectProviderResource>, IAsyncEnumerable<ApiManagementOpenIdConnectProviderResource>
    {
        /// <summary>
        /// Lists of all the OpenId Connect Providers.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/openidConnectProviders
        /// Operation Id: OpenIdConnectProvider_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementOpenIdConnectProviderResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementOpenIdConnectProviderResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementOpenIdConnectProviderResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementOpenIdConnectProviderOpenIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementOpenIdConnectProviderOpenIdConnectProviderRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementOpenIdConnectProviderResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementOpenIdConnectProviderResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementOpenIdConnectProviderOpenIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementOpenIdConnectProviderOpenIdConnectProviderRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementOpenIdConnectProviderResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists of all the OpenId Connect Providers.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/openidConnectProviders
        /// Operation Id: OpenIdConnectProvider_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementOpenIdConnectProviderResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementOpenIdConnectProviderResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementOpenIdConnectProviderResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementOpenIdConnectProviderOpenIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementOpenIdConnectProviderOpenIdConnectProviderRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementOpenIdConnectProviderResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementOpenIdConnectProviderResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementOpenIdConnectProviderOpenIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementOpenIdConnectProviderOpenIdConnectProviderRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementOpenIdConnectProviderResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
