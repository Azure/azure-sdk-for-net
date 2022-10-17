// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.CognitiveServices
{
    [CodeGenSuppress("GetDeletedAccountsAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("GetDeletedAccounts", typeof(SubscriptionResource), typeof(CancellationToken))]
    public static partial class CognitiveServicesExtensions
    {
        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/deletedAccounts
        /// Operation Id: DeletedAccounts_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CognitiveServicesDeletedAccountResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<CognitiveServicesDeletedAccountResource> GetDeletedAccountsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetDeletedAccountsAsync(cancellationToken);
        }

        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/deletedAccounts
        /// Operation Id: DeletedAccounts_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesDeletedAccountResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<CognitiveServicesDeletedAccountResource> GetDeletedAccounts(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetDeletedAccounts(cancellationToken);
        }
    }
}
