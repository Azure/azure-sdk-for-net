// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerInstance.Mocking;
using Azure.ResourceManager.ContainerInstance.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerInstance
{
    public static partial class ContainerInstanceExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="ContainerGroupSandboxResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceArmClient.GetContainerGroupSandboxResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ContainerGroupSandboxResource"/> object. </returns>
        public static ContainerGroupSandboxResource GetContainerGroupSandboxResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableContainerInstanceArmClient(client).GetContainerGroupSandboxResource(id);
        }

        /// <summary>
        /// Gets a collection of ContainerGroupSandboxes in the <see cref="ResourceGroupResource"/>
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetContainerGroupSandboxes()"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of ContainerGroupSandboxes and their operations over a ContainerGroupSandboxResource. </returns>
        public static ContainerGroupSandboxCollection GetContainerGroupSandboxes(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetContainerGroupSandboxes();
        }

        /// <summary>
        /// Get a SandboxGroup
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetContainerGroupSandboxAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="sandboxGroupName"> The name of the SandboxGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ContainerGroupSandboxResource>> GetContainerGroupSandboxAsync(this ResourceGroupResource resourceGroupResource, string sandboxGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetContainerGroupSandboxAsync(sandboxGroupName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a SandboxGroup
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetContainerGroupSandbox(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="sandboxGroupName"> The name of the SandboxGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ContainerGroupSandboxResource> GetContainerGroupSandbox(this ResourceGroupResource resourceGroupResource, string sandboxGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetContainerGroupSandbox(sandboxGroupName, cancellationToken);
        }

        /// <summary>
        /// List SandboxGroup resources by subscription ID
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetContainerGroupSandboxesAsync(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="ContainerGroupSandboxResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ContainerGroupSandboxResource> GetContainerGroupSandboxesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetContainerGroupSandboxesAsync(cancellationToken);
        }

        /// <summary>
        /// List SandboxGroup resources by subscription ID
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetContainerGroupSandboxes(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="ContainerGroupSandboxResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ContainerGroupSandboxResource> GetContainerGroupSandboxes(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetContainerGroupSandboxes(cancellationToken);
        }
    }
}
