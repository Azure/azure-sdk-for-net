// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Batch.Models;

namespace Azure.ResourceManager.Batch
{
    /// <summary>
    /// A class representing a collection of <see cref="BatchAccountPoolResource" /> and their operations.
    /// Each <see cref="BatchAccountPoolResource" /> in the collection will belong to the same instance of <see cref="BatchAccountResource" />.
    /// To get a <see cref="BatchAccountPoolCollection" /> instance call the GetBatchAccountPools method from an instance of <see cref="BatchAccountResource" />.
    /// </summary>
    public partial class BatchAccountPoolCollection : ArmCollection, IEnumerable<BatchAccountPoolResource>, IAsyncEnumerable<BatchAccountPoolResource>
    {
        /// <summary>
        /// Lists all of the pools in the specified account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/pools
        /// Operation Id: Pool_ListByBatchAccount
        /// </summary>
        /// <param name="maxresults"> The maximum number of items to return in the response. </param>
        /// <param name="select"> Comma separated list of properties that should be returned. e.g. &quot;properties/provisioningState&quot;. Only top level properties under properties/ are valid for selection. </param>
        /// <param name="filter">
        /// OData filter expression. Valid properties for filtering are:
        ///
        ///  name
        ///  properties/allocationState
        ///  properties/allocationStateTransitionTime
        ///  properties/creationTime
        ///  properties/provisioningState
        ///  properties/provisioningStateTransitionTime
        ///  properties/lastModified
        ///  properties/vmSize
        ///  properties/interNodeCommunication
        ///  properties/scaleSettings/autoScale
        ///  properties/scaleSettings/fixedScale
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BatchAccountPoolResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BatchAccountPoolResource> GetAllAsync(int? maxresults = null, string select = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new BatchAccountPoolCollectionGetAllOptions
            {
                Maxresults = maxresults,
                Select = select,
                Filter = filter
            }, cancellationToken);

        /// <summary>
        /// Lists all of the pools in the specified account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/pools
        /// Operation Id: Pool_ListByBatchAccount
        /// </summary>
        /// <param name="maxresults"> The maximum number of items to return in the response. </param>
        /// <param name="select"> Comma separated list of properties that should be returned. e.g. &quot;properties/provisioningState&quot;. Only top level properties under properties/ are valid for selection. </param>
        /// <param name="filter">
        /// OData filter expression. Valid properties for filtering are:
        ///
        ///  name
        ///  properties/allocationState
        ///  properties/allocationStateTransitionTime
        ///  properties/creationTime
        ///  properties/provisioningState
        ///  properties/provisioningStateTransitionTime
        ///  properties/lastModified
        ///  properties/vmSize
        ///  properties/interNodeCommunication
        ///  properties/scaleSettings/autoScale
        ///  properties/scaleSettings/fixedScale
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BatchAccountPoolResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BatchAccountPoolResource> GetAll(int? maxresults = null, string select = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetAll(new BatchAccountPoolCollectionGetAllOptions
            {
                Maxresults = maxresults,
                Select = select,
                Filter = filter
            }, cancellationToken);
    }
}
