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
    /// A class representing a collection of <see cref="ApiManagementDiagnosticResource" /> and their operations.
    /// Each <see cref="ApiManagementDiagnosticResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementDiagnosticCollection" /> instance call the GetApiManagementDiagnostics method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementDiagnosticCollection : ArmCollection, IEnumerable<ApiManagementDiagnosticResource>, IAsyncEnumerable<ApiManagementDiagnosticResource>
    {
        /// <summary>
        /// Lists all diagnostics of the API Management service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/diagnostics
        /// Operation Id: Diagnostic_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementDiagnosticResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementDiagnosticResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementDiagnosticResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementDiagnosticDiagnosticClientDiagnostics.CreateScope("ApiManagementDiagnosticCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementDiagnosticDiagnosticRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementDiagnosticResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementDiagnosticResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementDiagnosticDiagnosticClientDiagnostics.CreateScope("ApiManagementDiagnosticCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementDiagnosticDiagnosticRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementDiagnosticResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all diagnostics of the API Management service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/diagnostics
        /// Operation Id: Diagnostic_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementDiagnosticResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementDiagnosticResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementDiagnosticResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementDiagnosticDiagnosticClientDiagnostics.CreateScope("ApiManagementDiagnosticCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementDiagnosticDiagnosticRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementDiagnosticResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementDiagnosticResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementDiagnosticDiagnosticClientDiagnostics.CreateScope("ApiManagementDiagnosticCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementDiagnosticDiagnosticRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementDiagnosticResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
