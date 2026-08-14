// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudKubernetesClusterFeatureCollection : ArmCollection, IEnumerable<NetworkCloudKubernetesClusterFeatureResource>, IAsyncEnumerable<NetworkCloudKubernetesClusterFeatureResource>
    {
        /// <summary>
        /// Create a new Kubernetes cluster feature or update properties of the Kubernetes cluster feature if it exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/features/{featureName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusterFeatures_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterFeatureResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="featureName"> The name of the feature. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="featureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="featureName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudKubernetesClusterFeatureResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string featureName, NetworkCloudKubernetesClusterFeatureData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, featureName, data, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create a new Kubernetes cluster feature or update properties of the Kubernetes cluster feature if it exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/features/{featureName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusterFeatures_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterFeatureResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="featureName"> The name of the feature. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="featureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="featureName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudKubernetesClusterFeatureResource> CreateOrUpdate(WaitUntil waitUntil, string featureName, NetworkCloudKubernetesClusterFeatureData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, featureName, data, null, cancellationToken);

        /// <summary>
        /// Get a list of features for the provided Kubernetes cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/features</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusterFeatures_ListByKubernetesCluster</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterFeatureResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetworkCloudKubernetesClusterFeatureResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetworkCloudKubernetesClusterFeatureResource> GetAllAsync(CancellationToken cancellationToken)
               => GetAllAsync(null, null, cancellationToken);

        /// <summary>
        /// Get a list of features for the provided Kubernetes cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/features</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusterFeatures_ListByKubernetesCluster</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterFeatureResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetworkCloudKubernetesClusterFeatureResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetworkCloudKubernetesClusterFeatureResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, null, cancellationToken);

        /// <summary>
        /// Create a new Kubernetes cluster feature or update properties of the Kubernetes cluster feature if it exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/features/{featureName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusterFeatures_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterFeatureResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="featureName"> The name of the feature. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="featureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="featureName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudKubernetesClusterFeatureResource> CreateOrUpdate(WaitUntil waitUntil, string featureName, NetworkCloudKubernetesClusterFeatureData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, featureName, data, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken);

        /// <summary>
        /// Create a new Kubernetes cluster feature or update properties of the Kubernetes cluster feature if it exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/features/{featureName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusterFeatures_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterFeatureResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="featureName"> The name of the feature. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="ifMatch"> The ETag of the transformation. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing resource. Other values will result in error from server as they are not supported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="featureName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="featureName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudKubernetesClusterFeatureResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string featureName, NetworkCloudKubernetesClusterFeatureData data, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, featureName, data, new MatchConditions { IfMatch = ifMatch != null ? new Azure.ETag(ifMatch) : default(Azure.ETag?), IfNoneMatch = ifNoneMatch != null ? new Azure.ETag(ifNoneMatch) : default(Azure.ETag?) }, cancellationToken).ConfigureAwait(false);
    }
}
