// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Batch
{
    /// <summary>
    /// A class representing a collection of <see cref="BatchAccountCertificateResource" /> and their operations.
    /// Each <see cref="BatchAccountCertificateResource" /> in the collection will belong to the same instance of <see cref="BatchAccountResource" />.
    /// To get a <see cref="BatchAccountCertificateCollection" /> instance call the GetBatchAccountCertificates method from an instance of <see cref="BatchAccountResource" />.
    /// </summary>
    public partial class BatchAccountCertificateCollection : ArmCollection, IEnumerable<BatchAccountCertificateResource>, IAsyncEnumerable<BatchAccountCertificateResource>
    {
        /// <summary>
        /// Warning: This operation is deprecated and will be removed after February, 2024. Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/certificates
        /// Operation Id: Certificate_ListByBatchAccount
        /// </summary>
        /// <param name="maxresults"> The maximum number of items to return in the response. </param>
        /// <param name="select"> Comma separated list of properties that should be returned. e.g. &quot;properties/provisioningState&quot;. Only top level properties under properties/ are valid for selection. </param>
        /// <param name="filter"> OData filter expression. Valid properties for filtering are &quot;properties/provisioningState&quot;, &quot;properties/provisioningStateTransitionTime&quot;, &quot;name&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BatchAccountCertificateResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BatchAccountCertificateResource> GetAllAsync(int? maxresults = null, string select = null, string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<BatchAccountCertificateResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _batchAccountCertificateCertificateClientDiagnostics.CreateScope("BatchAccountCertificateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _batchAccountCertificateCertificateRestClient.ListByBatchAccountAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, maxresults, select, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BatchAccountCertificateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<BatchAccountCertificateResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _batchAccountCertificateCertificateClientDiagnostics.CreateScope("BatchAccountCertificateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _batchAccountCertificateCertificateRestClient.ListByBatchAccountNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, maxresults, select, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BatchAccountCertificateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Warning: This operation is deprecated and will be removed after February, 2024. Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/certificates
        /// Operation Id: Certificate_ListByBatchAccount
        /// </summary>
        /// <param name="maxresults"> The maximum number of items to return in the response. </param>
        /// <param name="select"> Comma separated list of properties that should be returned. e.g. &quot;properties/provisioningState&quot;. Only top level properties under properties/ are valid for selection. </param>
        /// <param name="filter"> OData filter expression. Valid properties for filtering are &quot;properties/provisioningState&quot;, &quot;properties/provisioningStateTransitionTime&quot;, &quot;name&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BatchAccountCertificateResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BatchAccountCertificateResource> GetAll(int? maxresults = null, string select = null, string filter = null, CancellationToken cancellationToken = default)
        {
            Page<BatchAccountCertificateResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _batchAccountCertificateCertificateClientDiagnostics.CreateScope("BatchAccountCertificateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _batchAccountCertificateCertificateRestClient.ListByBatchAccount(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, maxresults, select, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BatchAccountCertificateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<BatchAccountCertificateResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _batchAccountCertificateCertificateClientDiagnostics.CreateScope("BatchAccountCertificateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _batchAccountCertificateCertificateRestClient.ListByBatchAccountNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, maxresults, select, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BatchAccountCertificateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
