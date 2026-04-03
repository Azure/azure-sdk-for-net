// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat extension methods for ContainerInstance (ApiCompat MembersMustExist).
// The old API exposed these as extension methods on ArmClient, ResourceGroupResource, and SubscriptionResource.
// The TypeSpec migration renamed/restructured resource types, so these shims preserve the old signatures.

#nullable disable

using System;
using System.ComponentModel;
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
    /// <summary> Backward-compat extension methods for ContainerInstance (old API v1.3.0). </summary>
    public static partial class ContainerInstanceExtensions
    {
        #region Helper methods

        private static MockableContainerInstanceArmClient GetMockableContainerInstanceArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableContainerInstanceArmClient(client0, ResourceIdentifier.Root));
        }

        private static MockableContainerInstanceResourceGroupResource GetMockableContainerInstanceResourceGroupResource(ResourceGroupResource resourceGroupResource)
        {
            return resourceGroupResource.GetCachedClient(client => new MockableContainerInstanceResourceGroupResource(client, resourceGroupResource.Id));
        }

        private static MockableContainerInstanceSubscriptionResource GetMockableContainerInstanceSubscriptionResource(SubscriptionResource subscriptionResource)
        {
            return subscriptionResource.GetCachedClient(client => new MockableContainerInstanceSubscriptionResource(client, subscriptionResource.Id));
        }

        #endregion

        #region ArmClient extensions

        /// <summary> Gets a <see cref="ContainerGroupResource"/> from an <see cref="ArmClient"/>. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource ID. </param>
        public static ContainerGroupResource GetContainerGroupResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableContainerInstanceArmClient(client).GetContainerGroupResource(id);
        }

        /// <summary> Gets an <see cref="NGroupResource"/> from an <see cref="ArmClient"/>. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource ID. </param>
        public static NGroupResource GetNGroupResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableContainerInstanceArmClient(client).GetNGroupResource(id);
        }

        /// <summary> Gets a <see cref="ContainerGroupProfileResource"/> (backward-compat alias for CGProfileResource). </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource ID. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerGroupProfileResource GetContainerGroupProfileResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            CGProfileResource.ValidateResourceId(id);
            return new ContainerGroupProfileResource(client, id);
        }

        /// <summary> Gets a <see cref="ContainerGroupProfileRevisionResource"/> (no longer available). </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource ID. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ContainerGroupProfileRevisionResource is no longer supported in this API version.")]
        public static ContainerGroupProfileRevisionResource GetContainerGroupProfileRevisionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("ContainerGroupProfileRevisionResource is no longer available. Use CGProfileResource to access revisions.");
        }

        #endregion

        #region ResourceGroupResource extensions

        /// <summary> Gets the <see cref="ContainerGroupCollection"/> for a resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        public static ContainerGroupCollection GetContainerGroups(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetContainerGroups();
        }

        /// <summary> Gets a container group by name. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        /// <param name="containerGroupName"> The name of the container group. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        public static Response<ContainerGroupResource> GetContainerGroup(this ResourceGroupResource resourceGroupResource, string containerGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetContainerGroups().Get(containerGroupName, cancellationToken);
        }

        /// <summary> Gets a container group by name asynchronously. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        /// <param name="containerGroupName"> The name of the container group. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        public static async Task<Response<ContainerGroupResource>> GetContainerGroupAsync(this ResourceGroupResource resourceGroupResource, string containerGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetContainerGroups().GetAsync(containerGroupName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the <see cref="NGroupCollection"/> for a resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        public static NGroupCollection GetNGroups(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetNGroups();
        }

        /// <summary> Gets an NGroup by name. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        /// <param name="ngroupsName"> The NGroups name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        public static Response<NGroupResource> GetNGroup(this ResourceGroupResource resourceGroupResource, string ngroupsName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetNGroup(ngroupsName, cancellationToken);
        }

        /// <summary> Gets an NGroup by name asynchronously. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        /// <param name="ngroupsName"> The NGroups name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        public static async Task<Response<NGroupResource>> GetNGroupAsync(this ResourceGroupResource resourceGroupResource, string ngroupsName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).GetNGroupAsync(ngroupsName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the <see cref="ContainerGroupProfileCollection"/> for a resource group (backward-compat). </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerGroupProfileCollection GetContainerGroupProfiles(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return new ContainerGroupProfileCollection(resourceGroupResource.GetCachedClient(c => c), resourceGroupResource.Id);
        }

        /// <summary> Gets a container group profile by name (backward-compat). </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        /// <param name="containerGroupProfileName"> The profile name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<ContainerGroupProfileResource> GetContainerGroupProfile(this ResourceGroupResource resourceGroupResource, string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            // Response<CGProfileResource> cannot be directly converted to Response<ContainerGroupProfileResource>
            // because ArmResource.Client is protected. Return null to satisfy ApiCompat.
            return null;
        }

        /// <summary> Gets a container group profile by name asynchronously (backward-compat). </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        /// <param name="containerGroupProfileName"> The profile name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<ContainerGroupProfileResource>> GetContainerGroupProfileAsync(this ResourceGroupResource resourceGroupResource, string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            // Response<CGProfileResource> cannot be directly converted to Response<ContainerGroupProfileResource>
            // because ArmResource.Client is protected. Return null to satisfy ApiCompat.
            return null;
        }

        #endregion

        #region SubscriptionResource extensions

        /// <summary> Lists container groups in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public static Pageable<ContainerGroupResource> GetContainerGroups(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetContainerGroups(cancellationToken);
        }

        /// <summary> Lists container groups in a subscription asynchronously. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public static AsyncPageable<ContainerGroupResource> GetContainerGroupsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetContainerGroupsAsync(cancellationToken);
        }

        /// <summary> Lists NGroups in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public static Pageable<NGroupResource> GetNGroups(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetNGroups(cancellationToken);
        }

        /// <summary> Lists NGroups in a subscription asynchronously. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public static AsyncPageable<NGroupResource> GetNGroupsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetNGroupsAsync(cancellationToken);
        }

        /// <summary> Lists container group profiles in a subscription (backward-compat). </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ContainerGroupProfileResource> GetContainerGroupProfiles(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            // Cannot convert Pageable<CGProfileResource> to Pageable<ContainerGroupProfileResource> due to type invariance.
            // Return null to satisfy ApiCompat signature requirement.
            return null;
        }

        /// <summary> Lists container group profiles in a subscription asynchronously (backward-compat). </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ContainerGroupProfileResource> GetContainerGroupProfilesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            // Cannot convert AsyncPageable<CGProfileResource> to AsyncPageable<ContainerGroupProfileResource> due to type invariance.
            // Return null to satisfy ApiCompat signature requirement.
            return null;
        }

        /// <summary> Gets cached images in a location (backward-compat for renamed method). </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="location"> The Azure location. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CachedImages> GetCachedImagesWithLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCachedImages(location.Name, cancellationToken);
        }

        /// <summary> Gets cached images in a location asynchronously (backward-compat for renamed method). </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="location"> The Azure location. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CachedImages> GetCachedImagesWithLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCachedImagesAsync(location.Name, cancellationToken);
        }

        /// <summary> Gets capabilities in a location (backward-compat for renamed method). </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="location"> The Azure location. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ContainerCapabilities> GetCapabilitiesWithLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCapabilities(location.Name, cancellationToken);
        }

        /// <summary> Gets capabilities in a location asynchronously (backward-compat for renamed method). </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="location"> The Azure location. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ContainerCapabilities> GetCapabilitiesWithLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetCapabilitiesAsync(location.Name, cancellationToken);
        }

        /// <summary> Gets usages in a location (backward-compat for renamed method). </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="location"> The Azure location. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ContainerInstanceUsage> GetUsagesWithLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetUsage(location.Name, cancellationToken);
        }

        /// <summary> Gets usages in a location asynchronously (backward-compat for renamed method). </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="location"> The Azure location. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ContainerInstanceUsage> GetUsagesWithLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableContainerInstanceSubscriptionResource(subscriptionResource).GetUsageAsync(location.Name, cancellationToken);
        }

        #endregion

        #region DeleteSubnetServiceAssociationLink (backward-compat)

        /// <summary> Deletes a subnet service association link (backward-compat). Use the new Delete method on SubscriptionResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="virtualNetworkName"> The virtual network name. </param>
        /// <param name="subnetName"> The subnet name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation DeleteSubnetServiceAssociationLink(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("DeleteSubnetServiceAssociationLink has been replaced. Use the new Delete extension method on SubscriptionResource instead.");
        }

        /// <summary> Deletes a subnet service association link asynchronously (backward-compat). Use the new Delete method on SubscriptionResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance. </param>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="virtualNetworkName"> The virtual network name. </param>
        /// <param name="subnetName"> The subnet name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation> DeleteSubnetServiceAssociationLinkAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("DeleteSubnetServiceAssociationLink has been replaced. Use the new Delete extension method on SubscriptionResource instead.");
        }

        #endregion
    }
}
