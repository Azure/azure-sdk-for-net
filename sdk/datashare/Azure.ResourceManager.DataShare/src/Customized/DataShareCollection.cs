// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DataShare.Models;

namespace Azure.ResourceManager.DataShare
{
    /// <summary>
    /// A class representing a collection of <see cref="DataShareResource" /> and their operations.
    /// Each <see cref="DataShareResource" /> in the collection will belong to the same instance of <see cref="DataShareAccountResource" />.
    /// To get a <see cref="DataShareCollection" /> instance call the GetDataShares method from an instance of <see cref="DataShareAccountResource" />.
    /// </summary>
    public partial class DataShareCollection : ArmCollection, IEnumerable<DataShareResource>, IAsyncEnumerable<DataShareResource>
    {
        /// <summary>
        /// List shares in an account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares
        /// Operation Id: Shares_ListByAccount
        /// </summary>
        /// <param name="skipToken"> Continuation Token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataShareResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataShareResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DataShareCollectionGetAllOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List shares in an account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares
        /// Operation Id: Shares_ListByAccount
        /// </summary>
        /// <param name="skipToken"> Continuation Token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataShareResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataShareResource> GetAll(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new DataShareCollectionGetAllOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);
    }
}
