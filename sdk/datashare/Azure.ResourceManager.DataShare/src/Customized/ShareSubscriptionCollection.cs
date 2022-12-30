// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DataShare.Models;

namespace Azure.ResourceManager.DataShare
{
    /// <summary>
    /// A class representing a collection of <see cref="ShareSubscriptionResource" /> and their operations.
    /// Each <see cref="ShareSubscriptionResource" /> in the collection will belong to the same instance of <see cref="DataShareAccountResource" />.
    /// To get a <see cref="ShareSubscriptionCollection" /> instance call the GetShareSubscriptions method from an instance of <see cref="DataShareAccountResource" />.
    /// </summary>
    public partial class ShareSubscriptionCollection : ArmCollection, IEnumerable<ShareSubscriptionResource>, IAsyncEnumerable<ShareSubscriptionResource>
    {
        /// <summary>
        /// List share subscriptions in an account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions
        /// Operation Id: ShareSubscriptions_ListByAccount
        /// </summary>
        /// <param name="skipToken"> Continuation Token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ShareSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ShareSubscriptionResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ShareSubscriptionCollectionGetAllOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List share subscriptions in an account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions
        /// Operation Id: ShareSubscriptions_ListByAccount
        /// </summary>
        /// <param name="skipToken"> Continuation Token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ShareSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ShareSubscriptionResource> GetAll(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new ShareSubscriptionCollectionGetAllOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);
    }
}
