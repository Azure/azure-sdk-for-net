// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerService.Mocking;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.ContainerService. </summary>
    public static partial class ContainerServiceExtensions
    {
        /// <summary> Gets an object representing a OSOptionProfileResource along with the instance operations that can be performed on it in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of Azure region. </param>
        /// <returns> Returns a <see cref="OSOptionProfileResource" /> object. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OSOptionProfileResource GetOSOptionProfile(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            return GetMockableContainerServiceSubscriptionResource(subscriptionResource).GetOSOptionProfile(location);
        }

        /// <summary>
        /// Gets an object representing an <see cref="OSOptionProfileResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="OSOptionProfileResource.CreateResourceIdentifier" /> to create an <see cref="OSOptionProfileResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableContainerServiceArmClient.GetOSOptionProfileResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="OSOptionProfileResource"/> object. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OSOptionProfileResource GetOSOptionProfileResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableContainerServiceArmClient(client).GetOSOptionProfileResource(id);
        }

        /// <summary>
        /// Contains extra metadata on the version, including supported patch versions, capabilities, available upgrades, and details on preview status of the version
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ContainerService/locations/{location}/kubernetesVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_ListKubernetesVersions</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<KubernetesVersionListResult>> GetKubernetesVersionsManagedClusterAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetMockableContainerServiceSubscriptionResource(subscriptionResource).GetKubernetesVersionsManagedClusterAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Contains extra metadata on the version, including supported patch versions, capabilities, available upgrades, and details on preview status of the version
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ContainerService/locations/{location}/kubernetesVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_ListKubernetesVersions</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<KubernetesVersionListResult> GetKubernetesVersionsManagedCluster(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableContainerServiceSubscriptionResource(subscriptionResource).GetKubernetesVersionsManagedCluster(location, cancellationToken);
        }
    }
}
