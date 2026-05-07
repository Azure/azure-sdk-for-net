// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.CognitiveServices.Mocking;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices
{
    [CodeGenSuppress("GetCognitiveServicesAccounts", typeof(string), typeof(CancellationToken))]        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
    [CodeGenSuppress("GetCognitiveServicesAccountsAsync", typeof(string), typeof(CancellationToken))]   // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
    public static partial class CognitiveServicesExtensions
    {
        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableCognitiveServicesSubscriptionResource.GetCognitiveServicesAccountsAsync(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CognitiveServicesAccountResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<CognitiveServicesAccountResource> GetCognitiveServicesAccountsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableCognitiveServicesSubscriptionResource(subscriptionResource).GetCognitiveServicesAccountsAsync(cancellationToken);
        }

        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableCognitiveServicesSubscriptionResource.GetCognitiveServicesAccounts(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CognitiveServicesAccountResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<CognitiveServicesAccountResource> GetCognitiveServicesAccounts(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableCognitiveServicesSubscriptionResource(subscriptionResource).GetCognitiveServicesAccounts(cancellationToken);
        }

        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableCognitiveServicesSubscriptionResource.GetDeletedAccountsAsync(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CognitiveServicesDeletedAccountResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<CognitiveServicesDeletedAccountResource> GetDeletedAccountsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableCognitiveServicesSubscriptionResource(subscriptionResource).GetDeletedAccountsAsync(cancellationToken);
        }

        // TODO: The CodeGen force renames the list method of a resource which cause duplicate methode name in extension class. This customization code should be removed after CodeGen fix the issue https://github.com/Azure/azure-sdk-for-net/issues/58210.
        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableCognitiveServicesSubscriptionResource.GetDeletedAccounts(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CognitiveServicesDeletedAccountResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<CognitiveServicesDeletedAccountResource> GetDeletedAccounts(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableCognitiveServicesSubscriptionResource(subscriptionResource).GetDeletedAccounts(cancellationToken);
        }

        // This method is used to support the mitigation solution of using a single data model for both CapabilityHost and ProjectCapabilityHost resources.
        /// <summary>
        /// Gets an object representing a <see cref="CognitiveServicesProjectCapabilityHostResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CognitiveServicesProjectCapabilityHostResource.CreateResourceIdentifier" /> to create a <see cref="CognitiveServicesProjectCapabilityHostResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableCognitiveServicesArmClient.GetCognitiveServicesProjectCapabilityHostResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="CognitiveServicesProjectCapabilityHostResource"/> object. </returns>
        public static CognitiveServicesProjectCapabilityHostResource GetCognitiveServicesProjectCapabilityHostResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableCognitiveServicesArmClient(client).GetCognitiveServicesProjectCapabilityHostResource(id);
        }
    }
}
