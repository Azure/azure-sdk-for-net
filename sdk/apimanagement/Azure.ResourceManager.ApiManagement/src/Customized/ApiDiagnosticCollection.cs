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
    /// A class representing a collection of <see cref="ApiDiagnosticResource" /> and their operations.
    /// Each <see cref="ApiDiagnosticResource" /> in the collection will belong to the same instance of <see cref="ApiResource" />.
    /// To get an <see cref="ApiDiagnosticCollection" /> instance call the GetApiDiagnostics method from an instance of <see cref="ApiResource" />.
    /// </summary>
    public partial class ApiDiagnosticCollection : ArmCollection, IEnumerable<ApiDiagnosticResource>, IAsyncEnumerable<ApiDiagnosticResource>
    {
        /// <summary>
        /// Lists all diagnostics of an API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/diagnostics
        /// Operation Id: ApiDiagnostic_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiDiagnosticResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiDiagnosticResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiDiagnosticResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiDiagnosticClientDiagnostics.CreateScope("ApiDiagnosticCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiDiagnosticRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiDiagnosticResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiDiagnosticResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiDiagnosticClientDiagnostics.CreateScope("ApiDiagnosticCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiDiagnosticRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiDiagnosticResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all diagnostics of an API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/diagnostics
        /// Operation Id: ApiDiagnostic_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiDiagnosticResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiDiagnosticResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiDiagnosticResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiDiagnosticClientDiagnostics.CreateScope("ApiDiagnosticCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiDiagnosticRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiDiagnosticResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiDiagnosticResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiDiagnosticClientDiagnostics.CreateScope("ApiDiagnosticCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiDiagnosticRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiDiagnosticResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
