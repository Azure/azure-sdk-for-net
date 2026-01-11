// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerService
{
    /// <summary>
    /// A Class representing a ContainerServiceManagedCluster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ContainerServiceManagedClusterResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetContainerServiceManagedClusterResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetContainerServiceManagedCluster method.
    /// </summary>
    public partial class ContainerServiceManagedClusterResource : ArmResource
    {
        /// <summary>
        /// Deletes a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => await DeleteAsync(waitUntil, ifMatch:null, cancellationToken:cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Delete(waitUntil, ifMatch:null, cancellationToken:cancellationToken);

        /// <summary>
        /// Deletes a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ignorePodDisruptionBudget"> ignore-pod-disruption-budget=true to delete those pods on a node without considering Pod Disruption Budget. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? ignorePodDisruptionBudget, CancellationToken cancellationToken) => await DeleteAsync(waitUntil, ifMatch:null, cancellationToken:cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ignorePodDisruptionBudget"> ignore-pod-disruption-budget=true to delete those pods on a node without considering Pod Disruption Budget. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? ignorePodDisruptionBudget, CancellationToken cancellationToken) => Delete(waitUntil, ifMatch:null, cancellationToken:cancellationToken);

        /// <summary>
        /// Updates tags on a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_UpdateTags</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceManagedClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="containerServiceTagsObject"> Parameters supplied to the Update Managed Cluster Tags operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<ContainerServiceManagedClusterResource>> UpdateAsync(WaitUntil waitUntil, ContainerServiceTagsObject containerServiceTagsObject, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, containerServiceTagsObject, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates tags on a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_UpdateTags</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceManagedClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="containerServiceTagsObject"> Parameters supplied to the Update Managed Cluster Tags operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<ContainerServiceManagedClusterResource> Update(WaitUntil waitUntil, ContainerServiceTagsObject containerServiceTagsObject, CancellationToken cancellationToken)
            => Update(waitUntil, containerServiceTagsObject, null, cancellationToken);
    }
}
