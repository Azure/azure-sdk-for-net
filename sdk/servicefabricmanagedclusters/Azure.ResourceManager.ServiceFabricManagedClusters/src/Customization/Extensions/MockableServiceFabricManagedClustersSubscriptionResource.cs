// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Mocking
{
    /// <summary> A class to add extension methods to <see cref="SubscriptionResource"/>. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(nameof(GetManagedClusterVersionsByEnvironmentAsync), typeof(AzureLocation), typeof(ManagedClusterVersionEnvironment), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(nameof(GetManagedClusterVersionsByEnvironment), typeof(AzureLocation), typeof(ManagedClusterVersionEnvironment), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(nameof(GetManagedClusterVersionsAsync), typeof(AzureLocation), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(nameof(GetManagedClusterVersions), typeof(AzureLocation), typeof(CancellationToken))]
    public partial class MockableServiceFabricManagedClustersSubscriptionResource : ArmResource
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
        /// </summary>
        /// <param name="location"> The location for the cluster code versions. This is different from cluster location. </param>
        /// <param name="environment"> The operating system of the cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServiceFabricManagedClusterVersion"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironmentAsync(AzureLocation location, ManagedClusterVersionEnvironment environment, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
        /// </summary>
        /// <param name="location"> The location for the cluster code versions. This is different from cluster location. </param>
        /// <param name="environment"> The operating system of the cluster. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceFabricManagedClusterVersion"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceFabricManagedClusterVersion> GetManagedClusterVersionsByEnvironment(AzureLocation location, ManagedClusterVersionEnvironment environment, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
        /// </summary>
        /// <param name="location"> The location for the cluster code versions. This is different from cluster location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServiceFabricManagedClusterVersion"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceFabricManagedClusterVersion> GetManagedClusterVersionsAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
        /// </summary>
        /// <param name="location"> The location for the cluster code versions. This is different from cluster location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceFabricManagedClusterVersion"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceFabricManagedClusterVersion> GetManagedClusterVersions(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
