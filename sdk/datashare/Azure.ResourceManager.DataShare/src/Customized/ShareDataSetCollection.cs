// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DataShare.Models;

namespace Azure.ResourceManager.DataShare
{
    /// <summary>
    /// A class representing a collection of <see cref="ShareDataSetResource" /> and their operations.
    /// Each <see cref="ShareDataSetResource" /> in the collection will belong to the same instance of <see cref="DataShareResource" />.
    /// To get a <see cref="ShareDataSetCollection" /> instance call the GetShareDataSets method from an instance of <see cref="DataShareResource" />.
    /// </summary>
    public partial class ShareDataSetCollection : ArmCollection, IEnumerable<ShareDataSetResource>, IAsyncEnumerable<ShareDataSetResource>
    {
        /// <summary>
        /// List DataSets in a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/dataSets
        /// Operation Id: DataSets_ListByShare
        /// </summary>
        /// <param name="skipToken"> continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ShareDataSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ShareDataSetResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ShareDataSetCollectionGetAllOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List DataSets in a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/dataSets
        /// Operation Id: DataSets_ListByShare
        /// </summary>
        /// <param name="skipToken"> continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ShareDataSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ShareDataSetResource> GetAll(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new ShareDataSetCollectionGetAllOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);
    }
}
