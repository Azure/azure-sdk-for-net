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
    /// A class representing a collection of <see cref="ApiManagementGatewayHostnameConfigurationResource" /> and their operations.
    /// Each <see cref="ApiManagementGatewayHostnameConfigurationResource" /> in the collection will belong to the same instance of <see cref="ApiManagementGatewayResource" />.
    /// To get an <see cref="ApiManagementGatewayHostnameConfigurationCollection" /> instance call the GetApiManagementGatewayHostnameConfigurations method from an instance of <see cref="ApiManagementGatewayResource" />.
    /// </summary>
    public partial class ApiManagementGatewayHostnameConfigurationCollection : ArmCollection, IEnumerable<ApiManagementGatewayHostnameConfigurationResource>, IAsyncEnumerable<ApiManagementGatewayHostnameConfigurationResource>
    {
        /// <summary>
        /// Lists the collection of hostname configurations for the specified gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/hostnameConfigurations
        /// Operation Id: GatewayHostnameConfiguration_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| hostname | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementGatewayHostnameConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementGatewayHostnameConfigurationResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementGatewayHostnameConfigurationResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementGatewayHostnameConfigurationGatewayHostnameConfigurationClientDiagnostics.CreateScope("ApiManagementGatewayHostnameConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementGatewayHostnameConfigurationGatewayHostnameConfigurationRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGatewayHostnameConfigurationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementGatewayHostnameConfigurationResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementGatewayHostnameConfigurationGatewayHostnameConfigurationClientDiagnostics.CreateScope("ApiManagementGatewayHostnameConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementGatewayHostnameConfigurationGatewayHostnameConfigurationRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGatewayHostnameConfigurationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the collection of hostname configurations for the specified gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/hostnameConfigurations
        /// Operation Id: GatewayHostnameConfiguration_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| hostname | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementGatewayHostnameConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementGatewayHostnameConfigurationResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementGatewayHostnameConfigurationResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementGatewayHostnameConfigurationGatewayHostnameConfigurationClientDiagnostics.CreateScope("ApiManagementGatewayHostnameConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementGatewayHostnameConfigurationGatewayHostnameConfigurationRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGatewayHostnameConfigurationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementGatewayHostnameConfigurationResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementGatewayHostnameConfigurationGatewayHostnameConfigurationClientDiagnostics.CreateScope("ApiManagementGatewayHostnameConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementGatewayHostnameConfigurationGatewayHostnameConfigurationRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGatewayHostnameConfigurationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
