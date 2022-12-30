// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.DataShare.Models;

namespace Azure.ResourceManager.DataShare
{
    /// <summary>
    /// A Class representing a DataShare along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="DataShareResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetDataShareResource method.
    /// Otherwise you can get one from its parent resource <see cref="DataShareAccountResource" /> using the GetDataShare method.
    /// </summary>
    public partial class DataShareResource : ArmResource
    {
        /// <summary>
        /// List synchronization details
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/listSynchronizationDetails
        /// Operation Id: Shares_ListSynchronizationDetails
        /// </summary>
        /// <param name="shareSynchronization"> Share Synchronization payload. </param>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareSynchronization"/> is null. </exception>
        /// <returns> An async collection of <see cref="SynchronizationDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SynchronizationDetails> GetSynchronizationDetailsAsync(ShareSynchronization shareSynchronization, string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetSynchronizationDetailsAsync(new DataShareResourceGetSynchronizationDetailsOptions(shareSynchronization)
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List synchronization details
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/listSynchronizationDetails
        /// Operation Id: Shares_ListSynchronizationDetails
        /// </summary>
        /// <param name="shareSynchronization"> Share Synchronization payload. </param>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareSynchronization"/> is null. </exception>
        /// <returns> A collection of <see cref="SynchronizationDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SynchronizationDetails> GetSynchronizationDetails(ShareSynchronization shareSynchronization, string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetSynchronizationDetails(new DataShareResourceGetSynchronizationDetailsOptions(shareSynchronization)
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List synchronizations of a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/listSynchronizations
        /// Operation Id: Shares_ListSynchronizations
        /// </summary>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ShareSynchronization" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ShareSynchronization> GetSynchronizationsAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetSynchronizationsAsync(new DataShareResourceGetSynchronizationsOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List synchronizations of a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/listSynchronizations
        /// Operation Id: Shares_ListSynchronizations
        /// </summary>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ShareSynchronization" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ShareSynchronization> GetSynchronizations(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetSynchronizations(new DataShareResourceGetSynchronizationsOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);
    }
}
