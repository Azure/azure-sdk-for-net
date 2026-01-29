// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Mocking;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;

namespace Azure.ResourceManager.ServiceFabricManagedClusters
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.ServiceFabricManagedClusters. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(nameof(GetManagedClusterVersionsByEnvironmentAsync), typeof(AzureLocation), typeof(ManagedClusterVersionEnvironment), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(nameof(GetManagedClusterVersionsByEnvironment), typeof(AzureLocation), typeof(ManagedClusterVersionEnvironment), typeof(CancellationToken))]
    public static partial class ServiceFabricManagedClustersExtensions
    {
        /// <summary>
        /// Gets all available code versions for Service Fabric cluster resources by environment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/environments/{environment}/managedClusterVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusterVersion_ListByEnvironment</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableServiceFabricManagedClustersSubscriptionResource.GetManagedClusterVersionsByEnvironment(AzureLocation,ManagedClusterVersionEnvironment,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for the cluster code versions. This is different from cluster location. </param>
        /// <param name="environment"> The operating system of the cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="ServiceFabricManagedClusterVersion"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironmentAsync(this SubscriptionResource subscriptionResource, AzureLocation location, ManagedClusterVersionEnvironment environment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableServiceFabricManagedClustersSubscriptionResource(subscriptionResource).GetManagedClusterVersionsByEnvironmentAsync(location, environment, cancellationToken);
        }

        /// <summary>
        /// Gets all available code versions for Service Fabric cluster resources by environment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/environments/{environment}/managedClusterVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusterVersion_ListByEnvironment</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableServiceFabricManagedClustersSubscriptionResource.GetManagedClusterVersionsByEnvironment(AzureLocation,ManagedClusterVersionEnvironment,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for the cluster code versions. This is different from cluster location. </param>
        /// <param name="environment"> The operating system of the cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="ServiceFabricManagedClusterVersion"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironment(this SubscriptionResource subscriptionResource, AzureLocation location, ManagedClusterVersionEnvironment environment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableServiceFabricManagedClustersSubscriptionResource(subscriptionResource).GetManagedClusterVersionsByEnvironment(location, environment, cancellationToken);
        }

        /// <summary>
        /// Gets all available code versions for Service Fabric cluster resources by location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/managedClusterVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusterVersion_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableServiceFabricManagedClustersSubscriptionResource.GetManagedClusterVersions(AzureLocation,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for the cluster code versions. This is different from cluster location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="ServiceFabricManagedClusterVersion"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ServiceFabricManagedClusterVersion> GetManagedClusterVersionsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableServiceFabricManagedClustersSubscriptionResource(subscriptionResource).GetManagedClusterVersionsAsync(location, cancellationToken);
        }

        /// <summary>
        /// Gets all available code versions for Service Fabric cluster resources by location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/managedClusterVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusterVersion_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableServiceFabricManagedClustersSubscriptionResource.GetManagedClusterVersions(AzureLocation,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location for the cluster code versions. This is different from cluster location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="ServiceFabricManagedClusterVersion"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ServiceFabricManagedClusterVersion> GetManagedClusterVersions(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableServiceFabricManagedClustersSubscriptionResource(subscriptionResource).GetManagedClusterVersions(location, cancellationToken);
        }
    }
}
