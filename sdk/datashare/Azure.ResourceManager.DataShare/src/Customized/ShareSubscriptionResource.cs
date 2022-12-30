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
    /// A Class representing a ShareSubscription along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ShareSubscriptionResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetShareSubscriptionResource method.
    /// Otherwise you can get one from its parent resource <see cref="DataShareAccountResource" /> using the GetShareSubscription method.
    /// </summary>
    public partial class ShareSubscriptionResource : ArmResource
    {
        /// <summary>
        /// List synchronization details
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions/{shareSubscriptionName}/listSynchronizationDetails
        /// Operation Id: ShareSubscriptions_ListSynchronizationDetails
        /// </summary>
        /// <param name="shareSubscriptionSynchronization"> Share Subscription Synchronization payload. </param>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareSubscriptionSynchronization"/> is null. </exception>
        /// <returns> An async collection of <see cref="SynchronizationDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SynchronizationDetails> GetSynchronizationDetailsAsync(ShareSubscriptionSynchronization shareSubscriptionSynchronization, string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetSynchronizationDetailsAsync(new ShareSubscriptionResourceGetSynchronizationDetailsOptions(shareSubscriptionSynchronization)
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List synchronization details
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions/{shareSubscriptionName}/listSynchronizationDetails
        /// Operation Id: ShareSubscriptions_ListSynchronizationDetails
        /// </summary>
        /// <param name="shareSubscriptionSynchronization"> Share Subscription Synchronization payload. </param>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareSubscriptionSynchronization"/> is null. </exception>
        /// <returns> A collection of <see cref="SynchronizationDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SynchronizationDetails> GetSynchronizationDetails(ShareSubscriptionSynchronization shareSubscriptionSynchronization, string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetSynchronizationDetails(new ShareSubscriptionResourceGetSynchronizationDetailsOptions(shareSubscriptionSynchronization)
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List synchronizations of a share subscription
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions/{shareSubscriptionName}/listSynchronizations
        /// Operation Id: ShareSubscriptions_ListSynchronizations
        /// </summary>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ShareSubscriptionSynchronization" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ShareSubscriptionSynchronization> GetSynchronizationsAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetSynchronizationsAsync(new ShareSubscriptionResourceGetSynchronizationsOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List synchronizations of a share subscription
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions/{shareSubscriptionName}/listSynchronizations
        /// Operation Id: ShareSubscriptions_ListSynchronizations
        /// </summary>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ShareSubscriptionSynchronization" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ShareSubscriptionSynchronization> GetSynchronizations(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetSynchronizations(new ShareSubscriptionResourceGetSynchronizationsOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);
    }
}
