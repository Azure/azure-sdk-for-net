// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Batch.Models;

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
        public virtual AsyncPageable<BatchAccountCertificateResource> GetAllAsync(int? maxresults = null, string select = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new BatchAccountCertificateCollectionGetAllOptions
            {
                Maxresults = maxresults,
                Select = select,
                Filter = filter
            }, cancellationToken);

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
        public virtual Pageable<BatchAccountCertificateResource> GetAll(int? maxresults = null, string select = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetAll(new BatchAccountCertificateCollectionGetAllOptions
            {
                Maxresults = maxresults,
                Select = select,
                Filter = filter
            }, cancellationToken);
    }
}
