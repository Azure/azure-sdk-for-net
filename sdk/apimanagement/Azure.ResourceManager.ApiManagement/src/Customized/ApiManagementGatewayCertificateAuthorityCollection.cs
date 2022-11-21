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
    /// A class representing a collection of <see cref="ApiManagementGatewayCertificateAuthorityResource" /> and their operations.
    /// Each <see cref="ApiManagementGatewayCertificateAuthorityResource" /> in the collection will belong to the same instance of <see cref="ApiManagementGatewayResource" />.
    /// To get an <see cref="ApiManagementGatewayCertificateAuthorityCollection" /> instance call the GetApiManagementGatewayCertificateAuthorities method from an instance of <see cref="ApiManagementGatewayResource" />.
    /// </summary>
    public partial class ApiManagementGatewayCertificateAuthorityCollection : ArmCollection, IEnumerable<ApiManagementGatewayCertificateAuthorityResource>, IAsyncEnumerable<ApiManagementGatewayCertificateAuthorityResource>
    {
        /// <summary>
        /// Lists the collection of Certificate Authorities for the specified Gateway entity.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/certificateAuthorities
        /// Operation Id: GatewayCertificateAuthority_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | eq, ne |  |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementGatewayCertificateAuthorityResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementGatewayCertificateAuthorityResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementGatewayCertificateAuthorityResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementGatewayCertificateAuthorityGatewayCertificateAuthorityClientDiagnostics.CreateScope("ApiManagementGatewayCertificateAuthorityCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementGatewayCertificateAuthorityGatewayCertificateAuthorityRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGatewayCertificateAuthorityResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementGatewayCertificateAuthorityResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementGatewayCertificateAuthorityGatewayCertificateAuthorityClientDiagnostics.CreateScope("ApiManagementGatewayCertificateAuthorityCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementGatewayCertificateAuthorityGatewayCertificateAuthorityRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGatewayCertificateAuthorityResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the collection of Certificate Authorities for the specified Gateway entity.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/certificateAuthorities
        /// Operation Id: GatewayCertificateAuthority_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | eq, ne |  |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementGatewayCertificateAuthorityResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementGatewayCertificateAuthorityResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementGatewayCertificateAuthorityResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementGatewayCertificateAuthorityGatewayCertificateAuthorityClientDiagnostics.CreateScope("ApiManagementGatewayCertificateAuthorityCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementGatewayCertificateAuthorityGatewayCertificateAuthorityRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGatewayCertificateAuthorityResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementGatewayCertificateAuthorityResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementGatewayCertificateAuthorityGatewayCertificateAuthorityClientDiagnostics.CreateScope("ApiManagementGatewayCertificateAuthorityCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementGatewayCertificateAuthorityGatewayCertificateAuthorityRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementGatewayCertificateAuthorityResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
