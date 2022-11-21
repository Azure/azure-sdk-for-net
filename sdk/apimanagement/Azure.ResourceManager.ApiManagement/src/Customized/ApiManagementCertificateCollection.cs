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
    /// A class representing a collection of <see cref="ApiManagementCertificateResource" /> and their operations.
    /// Each <see cref="ApiManagementCertificateResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementCertificateCollection" /> instance call the GetApiManagementCertificates method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementCertificateCollection : ArmCollection, IEnumerable<ApiManagementCertificateResource>, IAsyncEnumerable<ApiManagementCertificateResource>
    {
        /// <summary>
        /// Lists a collection of all certificates in the specified service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/certificates
        /// Operation Id: Certificate_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| subject | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| thumbprint | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| expirationDate | filter | ge, le, eq, ne, gt, lt |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="isKeyVaultRefreshFailed"> When set to true, the response contains only certificates entities which failed refresh. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementCertificateResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementCertificateResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, bool? isKeyVaultRefreshFailed = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiManagementCertificateResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementCertificateCertificateClientDiagnostics.CreateScope("ApiManagementCertificateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementCertificateCertificateRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, isKeyVaultRefreshFailed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementCertificateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiManagementCertificateResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementCertificateCertificateClientDiagnostics.CreateScope("ApiManagementCertificateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiManagementCertificateCertificateRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, isKeyVaultRefreshFailed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementCertificateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists a collection of all certificates in the specified service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/certificates
        /// Operation Id: Certificate_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| subject | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| thumbprint | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| expirationDate | filter | ge, le, eq, ne, gt, lt |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="isKeyVaultRefreshFailed"> When set to true, the response contains only certificates entities which failed refresh. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementCertificateResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementCertificateResource> GetAll(string filter = null, int? top = null, int? skip = null, bool? isKeyVaultRefreshFailed = null, CancellationToken cancellationToken = default)
        {
            Page<ApiManagementCertificateResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiManagementCertificateCertificateClientDiagnostics.CreateScope("ApiManagementCertificateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementCertificateCertificateRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, isKeyVaultRefreshFailed, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementCertificateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiManagementCertificateResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiManagementCertificateCertificateClientDiagnostics.CreateScope("ApiManagementCertificateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiManagementCertificateCertificateRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, skip, isKeyVaultRefreshFailed, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiManagementCertificateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
