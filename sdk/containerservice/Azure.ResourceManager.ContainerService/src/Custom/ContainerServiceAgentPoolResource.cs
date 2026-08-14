// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService
{
    public partial class ContainerServiceAgentPoolResource : ArmResource
    {
        /// <summary>
        /// Deletes an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => await DeleteAsync(waitUntil, null, (ETag?)null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken) => Delete(waitUntil, null, (ETag?)null, cancellationToken);

        /// <summary>
        /// Deletes an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ignorePodDisruptionBudget"> ignore-pod-disruption-budget=true to delete those pods on a node without considering Pod Disruption Budget. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? ignorePodDisruptionBudget, CancellationToken cancellationToken) => await DeleteAsync(waitUntil, ignorePodDisruptionBudget, (ETag?)null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ignorePodDisruptionBudget"> ignore-pod-disruption-budget=true to delete those pods on a node without considering Pod Disruption Budget. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? ignorePodDisruptionBudget, CancellationToken cancellationToken) => Delete(waitUntil, ignorePodDisruptionBudget, (ETag?)null, cancellationToken);

        /// <summary>
        /// Creates or updates an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The agent pool to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ContainerServiceAgentPoolResource>> UpdateAsync(WaitUntil waitUntil, ContainerServiceAgentPoolData data, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, data, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates or updates an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The agent pool to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerServiceAgentPoolResource> Update(WaitUntil waitUntil, ContainerServiceAgentPoolData data, CancellationToken cancellationToken)
            => Update(waitUntil, data, null, cancellationToken);

        /// <summary>
        /// Deletes an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Delete</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ignorePodDisruptionBudget"> ignore-pod-disruption-budget=true to delete those pods on a node without considering Pod Disruption Budget. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? ignorePodDisruptionBudget, string ifMatch, CancellationToken cancellationToken)
            => await DeleteAsync(waitUntil, ignorePodDisruptionBudget, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-10-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ignorePodDisruptionBudget"> ignore-pod-disruption-budget=true to delete those pods on a node without considering Pod Disruption Budget. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? ignorePodDisruptionBudget, string ifMatch, CancellationToken cancellationToken)
            => Delete(waitUntil, ignorePodDisruptionBudget, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken);

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerServiceAgentPoolResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerServiceAgentPoolResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerServiceAgentPoolResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerServiceAgentPoolResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerServiceAgentPoolResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerServiceAgentPoolResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            // Don't need to implement tags operations here since it's not a real tags, check this issue https://github.com/Azure/autorest.csharp/issues/5096
            throw new NotSupportedException("This method is no longer supported because the resource does not have a tags property.");
        }

        /// <summary>
        /// Creates or updates an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The agent pool to create or update. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ContainerServiceAgentPoolResource>> UpdateAsync(WaitUntil waitUntil, ContainerServiceAgentPoolData data, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, data, new MatchConditions { IfMatch = ifMatch != null ? new ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates or updates an agent pool in the specified managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerServiceAgentPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The agent pool to create or update. </param>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ContainerServiceAgentPoolResource> Update(WaitUntil waitUntil, ContainerServiceAgentPoolData data, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, new MatchConditions { IfMatch = ifMatch != null ? new ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken);
    }
}
