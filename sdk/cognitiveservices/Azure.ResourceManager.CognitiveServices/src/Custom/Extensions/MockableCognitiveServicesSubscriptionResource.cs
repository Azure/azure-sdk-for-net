// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CognitiveServices.Mocking
{
    [CodeGenSuppress("GetCognitiveServicesAccounts", typeof(CancellationToken))]        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
    [CodeGenSuppress("GetCognitiveServicesAccountsAsync", typeof(CancellationToken))]   // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
    public partial class MockableCognitiveServicesSubscriptionResource : ArmResource
    {
        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/accounts. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Accounts_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesAccountResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CognitiveServicesAccountResource> GetCognitiveServicesAccountsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<CognitiveServicesAccountData, CognitiveServicesAccountResource>(new AccountsGetCognitiveServicesAccountsAsyncCollectionResultOfT(AccountsRestClient, Id.SubscriptionId, context, "MockableCognitiveServicesSubscriptionResource.GetCognitiveServicesAccounts"), data => new CognitiveServicesAccountResource(Client, data));
        }

        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/accounts. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Accounts_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesAccountResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CognitiveServicesAccountResource> GetCognitiveServicesAccounts(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<CognitiveServicesAccountData, CognitiveServicesAccountResource>(new AccountsGetCognitiveServicesAccountsCollectionResultOfT(AccountsRestClient, Id.SubscriptionId, context, "MockableCognitiveServicesSubscriptionResource.GetCognitiveServicesAccounts"), data => new CognitiveServicesAccountResource(Client, data));
        }

        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
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
            return new AsyncPageableWrapper<CognitiveServicesAccountData, CognitiveServicesDeletedAccountResource>(new DeletedAccountsGetDeletedAccountsAsyncCollectionResultOfT(DeletedAccountsRestClient, Id.SubscriptionId, context, "MockableCognitiveServicesSubscriptionResource.GetDeletedAccountsAsync"), data => new CognitiveServicesDeletedAccountResource(Client, data));
        }

        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
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
            return new PageableWrapper<CognitiveServicesAccountData, CognitiveServicesDeletedAccountResource>(new DeletedAccountsGetDeletedAccountsCollectionResultOfT(DeletedAccountsRestClient, Id.SubscriptionId, context, "MockableCognitiveServicesSubscriptionResource.GetDeletedAccounts"), data => new CognitiveServicesDeletedAccountResource(Client, data));
        }
    }
}
