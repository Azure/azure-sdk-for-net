// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;

namespace Azure.ResourceManager.CognitiveServices.Mocking
{
    public partial class MockableCognitiveServicesSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/deletedAccounts. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DeletedAccounts_ListDeletedAccounts. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesDeletedAccountResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CognitiveServicesDeletedAccountResource> GetDeletedAccountsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<CognitiveServicesAccountData, CognitiveServicesDeletedAccountResource>(new DeletedAccountsGetCognitiveServicesDeletedAccountsAsyncCollectionResultOfT(DeletedAccountsRestClient, Id.SubscriptionId, context, "MockableCognitiveServicesSubscriptionResource.GetDeletedAccountsAsync"), data => new CognitiveServicesDeletedAccountResource(Client, data));
        }

        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/deletedAccounts. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DeletedAccounts_ListDeletedAccounts. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesDeletedAccountResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CognitiveServicesDeletedAccountResource> GetDeletedAccounts(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<CognitiveServicesAccountData, CognitiveServicesDeletedAccountResource>(new DeletedAccountsGetCognitiveServicesDeletedAccountsCollectionResultOfT(DeletedAccountsRestClient, Id.SubscriptionId, context, "MockableCognitiveServicesSubscriptionResource.GetDeletedAccounts"), data => new CognitiveServicesDeletedAccountResource(Client, data));
        }
    }
}
