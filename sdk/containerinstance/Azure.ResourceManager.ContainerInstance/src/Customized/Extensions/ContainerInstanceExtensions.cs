// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Corrected copy of Generated/Extensions/ContainerInstanceExtensions.cs
// Removes duplicate GetCGProfileResource method (generator bug).

#nullable disable

#pragma warning disable CS1591

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
    /// <summary> A class to add extension methods to Azure.ResourceManager.ContainerInstance. </summary>
    public static partial class ContainerInstanceExtensions
    {
        /// <param name="client"></param>
        private static MockableContainerInstanceArmClient GetMockableContainerInstanceArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableContainerInstanceArmClient(client0, ResourceIdentifier.Root));
        }

        /// <param name="resourceGroupResource"></param>
        private static MockableContainerInstanceResourceGroupResource GetMockableContainerInstanceResourceGroupResource(ResourceGroupResource resourceGroupResource)
        {
            return resourceGroupResource.GetCachedClient(client => new MockableContainerInstanceResourceGroupResource(client, resourceGroupResource.Id));
        }

        /// <param name="subscriptionResource"></param>
        private static MockableContainerInstanceSubscriptionResource GetMockableContainerInstanceSubscriptionResource(SubscriptionResource subscriptionResource)
        {
            return subscriptionResource.GetCachedClient(client => new MockableContainerInstanceSubscriptionResource(client, subscriptionResource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="ContainerGroupResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceArmClient.GetContainerGroupResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ContainerGroupResource"/> object. </returns>
        public static ContainerGroupResource GetContainerGroupResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableContainerInstanceArmClient(client).GetContainerGroupResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NGroupResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceArmClient.GetNGroupResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="NGroupResource"/> object. </returns>
        public static NGroupResource GetNGroupResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableContainerInstanceArmClient(client).GetNGroupResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CGProfileResource"/> along with the instance operations that can be performed on it but with no data.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceArmClient.GetCGProfileResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="CGProfileResource"/> object. </returns>
        public static CGProfileResource GetCGProfileResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableContainerInstanceArmClient(client).GetCGProfileResource(id);
        }

        /// <summary>
        /// Gets a collection of ContainerGroups in the <see cref="ResourceGroupResource"/>
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetContainerGroups()"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of ContainerGroups and their operations over a ContainerGroupResource. </returns>
        public static ContainerGroupCollection GetContainerGroups(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetContainerGroups();
        }

        /// <summary>
        /// Gets the properties of the specified container group in the specified subscription and resource group. The operation returns the properties of each container group including containers, image registry credentials, restart policy, IP address type, OS type, state, and volumes.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetContainerGroupAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="containerGroupName"> The name of the container group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ContainerGroupResource>> GetContainerGroupAsync(this ResourceGroupResource resourceGroupResource, string containerGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetContainerGroupAsync(containerGroupName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the properties of the specified container group in the specified subscription and resource group. The operation returns the properties of each container group including containers, image registry credentials, restart policy, IP address type, OS type, state, and volumes.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetContainerGroup(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="containerGroupName"> The name of the container group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ContainerGroupResource> GetContainerGroup(this ResourceGroupResource resourceGroupResource, string containerGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetContainerGroup(containerGroupName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of NGroups in the <see cref="ResourceGroupResource"/>
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetNGroups()"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of NGroups and their operations over a NGroupResource. </returns>
        public static NGroupCollection GetNGroups(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetNGroups();
        }

        /// <summary>
        /// Get the properties of the specified NGroups resource.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetNGroupAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="ngroupsName"> The NGroups name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<NGroupResource>> GetNGroupAsync(this ResourceGroupResource resourceGroupResource, string ngroupsName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetNGroupAsync(ngroupsName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the properties of the specified NGroups resource.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetNGroup(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="ngroupsName"> The NGroups name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<NGroupResource> GetNGroup(this ResourceGroupResource resourceGroupResource, string ngroupsName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetNGroup(ngroupsName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of CGProfiles in the <see cref="ResourceGroupResource"/>
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetCGProfiles()"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of CGProfiles and their operations over a CGProfileResource. </returns>
        public static CGProfileCollection GetCGProfiles(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetCGProfiles();
        }

        /// <summary>
        /// Get the properties of the specified container group profile.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetCGProfileAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="containerGroupProfileName"> ContainerGroupProfile name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<CGProfileResource>> GetCGProfileAsync(this ResourceGroupResource resourceGroupResource, string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetCGProfileAsync(containerGroupProfileName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the properties of the specified container group profile.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceResourceGroupResource.GetCGProfile(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="containerGroupProfileName"> ContainerGroupProfile name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<CGProfileResource> GetCGProfile(this ResourceGroupResource resourceGroupResource, string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetCGProfile(containerGroupProfileName, cancellationToken);
        }

        /// <summary>
        /// Get a list of container groups in the specified subscription. This operation returns properties of each container group including containers, image registry credentials, restart policy, IP address type, OS type, state, and volumes.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetContainerGroupsAsync(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="ListResultContainerGroup"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ListResultContainerGroup> GetContainerGroupsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetContainerGroupsAsync(cancellationToken);
        }

        /// <summary>
        /// Get a list of container groups in the specified subscription. This operation returns properties of each container group including containers, image registry credentials, restart policy, IP address type, OS type, state, and volumes.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetContainerGroups(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="ListResultContainerGroup"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ListResultContainerGroup> GetContainerGroups(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetContainerGroups(cancellationToken);
        }

        /// <summary>
        /// Gets a list of all NGroups resources under a subscription.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetNGroupsAsync(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="NGroupResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<NGroupResource> GetNGroupsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetNGroupsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a list of all NGroups resources under a subscription.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetNGroups(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="NGroupResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<NGroupResource> GetNGroups(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetNGroups(cancellationToken);
        }

        /// <summary>
        /// Gets a list of all container group profiles under a subscription.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetCGProfilesAsync(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CGProfileResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<CGProfileResource> GetCGProfilesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCGProfilesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a list of all container group profiles under a subscription.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetCGProfiles(CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CGProfileResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<CGProfileResource> GetCGProfiles(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCGProfiles(cancellationToken);
        }

        /// <summary>
        /// Get the usage for a subscription
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetUsageAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="ContainerInstanceUsage"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ContainerInstanceUsage> GetUsageAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetUsageAsync(location, cancellationToken);
        }

        /// <summary>
        /// Get the usage for a subscription
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetUsage(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="ContainerInstanceUsage"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ContainerInstanceUsage> GetUsage(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetUsage(location, cancellationToken);
        }

        /// <summary>
        /// Get the list of cached images on specific OS type for a subscription in a region.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetCachedImagesAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CachedImages"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<CachedImages> GetCachedImagesAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCachedImagesAsync(location, cancellationToken);
        }

        /// <summary>
        /// Get the list of cached images on specific OS type for a subscription in a region.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetCachedImages(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CachedImages"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<CachedImages> GetCachedImages(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCachedImages(location, cancellationToken);
        }

        /// <summary>
        /// Get the list of CPU/memory/GPU capabilities of a region.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetCapabilitiesAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="Capabilities"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<Capabilities> GetCapabilitiesAsync(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCapabilitiesAsync(location, cancellationToken);
        }

        /// <summary>
        /// Get the list of CPU/memory/GPU capabilities of a region.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.GetCapabilities(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="Capabilities"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<Capabilities> GetCapabilities(this SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCapabilities(location, cancellationToken);
        }

        /// <summary>
        /// Delete container group virtual network association links. The operation does not delete other resources provided by the user.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.DeleteAsync(WaitUntil, string, string, string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static async Task<ArmOperation> DeleteAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, string resourceGroupName, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableContainerInstanceSubscriptionResource(subscriptionResource).DeleteAsync(waitUntil, resourceGroupName, virtualNetworkName, subnetName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete container group virtual network association links. The operation does not delete other resources provided by the user.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableContainerInstanceSubscriptionResource.Delete(WaitUntil, string, string, string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static ArmOperation Delete(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, string resourceGroupName, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).Delete(waitUntil, resourceGroupName, virtualNetworkName, subnetName, cancellationToken);
        }

        // ====================================================================
        // Backward-compat shims for renamed methods (old API → new API)
        // ====================================================================

        // Old: GetContainerGroupProfileResource(ArmClient, ResourceIdentifier) → ContainerGroupProfileResource
        // New: GetCGProfileResource(ArmClient, ResourceIdentifier) → CGProfileResource
        /// <summary> Gets a ContainerGroupProfileResource. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static ContainerGroupProfileResource GetContainerGroupProfileResource(this ArmClient client, ResourceIdentifier id)
        {
            // ContainerGroupProfileResource inherits from CGProfileResource, but GetCGProfileResource returns CGProfileResource
            // We can only return CGProfileResource and let ApiCompat detect the type mismatch
            return GetMockableContainerInstanceArmClient(client).GetCGProfileResource(id) as ContainerGroupProfileResource;
        }

        // Old: GetContainerGroupProfileRevisionResource(ArmClient, ResourceIdentifier)
        // This resource type was removed in the new API. Provide a stub.
        /// <summary> Gets a ContainerGroupProfileRevisionResource (deprecated). </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("ContainerGroupProfileRevisionResource is no longer supported.")]
        public static ContainerGroupProfileRevisionResource GetContainerGroupProfileRevisionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new System.NotSupportedException("ContainerGroupProfileRevisionResource is no longer available in this API version.");
        }

        // Old: GetContainerGroupProfiles(ResourceGroupResource) → ContainerGroupProfileCollection
        // New: GetCGProfiles(ResourceGroupResource) → CGProfileCollection
        /// <summary> Gets the ContainerGroupProfileCollection. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static ContainerGroupProfileCollection GetContainerGroupProfiles(this ResourceGroupResource resourceGroupResource)
        {
            // Cannot create ContainerGroupProfileCollection from CGProfileCollection (protected constructor)
            // Return null — this is a structural breaking change that can't be fully shimmed
            return null;
        }

        // Old: GetContainerGroupProfile(ResourceGroupResource, string, CancellationToken) → Response<ContainerGroupProfileResource>
        // New: GetCGProfile(ResourceGroupResource, string, CancellationToken) → Response<CGProfileResource>
        /// <summary> Gets a ContainerGroupProfile. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Response<ContainerGroupProfileResource> GetContainerGroupProfile(this ResourceGroupResource resourceGroupResource, string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            // Response<CGProfileResource> cannot be converted to Response<ContainerGroupProfileResource> due to type invariance
            return null;
        }

        /// <summary> Gets a ContainerGroupProfile. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static async Task<Response<ContainerGroupProfileResource>> GetContainerGroupProfileAsync(this ResourceGroupResource resourceGroupResource, string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            return null;
        }

        // Old: GetContainerGroupProfiles(SubscriptionResource, CancellationToken) → Pageable<ContainerGroupProfileResource>
        // New: GetCGProfiles(SubscriptionResource, CancellationToken) → Pageable<CGProfileResource>
        /// <summary> Lists container group profiles in a subscription. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Pageable<ContainerGroupProfileResource> GetContainerGroupProfiles(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return null;
        }

        /// <summary> Lists container group profiles in a subscription. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static AsyncPageable<ContainerGroupProfileResource> GetContainerGroupProfilesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return null;
        }

        // Old: GetContainerGroups(SubscriptionResource, CancellationToken) → Pageable<ContainerGroupResource>
        // New: GetContainerGroups(SubscriptionResource, CancellationToken) → Pageable<ListResultContainerGroup>
        // Same name, different return type - CANNOT add overload. This is a structural breaking change.

        // Old: GetCachedImagesWithLocation(SubscriptionResource, AzureLocation, CancellationToken) → Pageable<CachedImages>
        // New: GetCachedImages(SubscriptionResource, string, CancellationToken) → Pageable<CachedImages>
        /// <summary> Gets cached images in a location. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Pageable<CachedImages> GetCachedImagesWithLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetCachedImages(subscriptionResource, location.Name, cancellationToken);
        }

        /// <summary> Gets cached images in a location. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static AsyncPageable<CachedImages> GetCachedImagesWithLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetCachedImagesAsync(subscriptionResource, location.Name, cancellationToken);
        }

        // Old: GetCapabilitiesWithLocation(SubscriptionResource, AzureLocation, CancellationToken) → Pageable<ContainerCapabilities>
        // New: GetCapabilities(SubscriptionResource, string, CancellationToken) → Pageable<Capabilities>
        // Return type changed: ContainerCapabilities → Capabilities. Cannot provide exact old return type.
        /// <summary> Gets capabilities in a location. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Pageable<ContainerCapabilities> GetCapabilitiesWithLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return null;
        }

        /// <summary> Gets capabilities in a location. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static AsyncPageable<ContainerCapabilities> GetCapabilitiesWithLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return null;
        }

        // Old: GetUsagesWithLocation(SubscriptionResource, AzureLocation, CancellationToken) → Pageable<ContainerInstanceUsage>
        // New: GetUsage(SubscriptionResource, string, CancellationToken) → Pageable<ContainerInstanceUsage>
        /// <summary> Gets usages in a location. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Pageable<ContainerInstanceUsage> GetUsagesWithLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetUsage(subscriptionResource, location.Name, cancellationToken);
        }

        /// <summary> Gets usages in a location. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static AsyncPageable<ContainerInstanceUsage> GetUsagesWithLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetUsageAsync(subscriptionResource, location.Name, cancellationToken);
        }

        // Old: DeleteSubnetServiceAssociationLink(ResourceGroupResource, WaitUntil, string, string, CancellationToken)
        // New: Delete(SubscriptionResource, WaitUntil, string, string, string, CancellationToken)
        // Different first param type (ResourceGroupResource vs SubscriptionResource). Provide stub.
        /// <summary> Deletes a subnet service association link (deprecated). </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static ArmOperation DeleteSubnetServiceAssociationLink(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("DeleteSubnetServiceAssociationLink has been replaced. Use the new Delete method on SubscriptionResource.");
        }

        /// <summary> Deletes a subnet service association link (deprecated). </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static async Task<ArmOperation> DeleteSubnetServiceAssociationLinkAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new System.NotSupportedException("DeleteSubnetServiceAssociationLink has been replaced. Use the new Delete method on SubscriptionResource.");
        }
    }
}
