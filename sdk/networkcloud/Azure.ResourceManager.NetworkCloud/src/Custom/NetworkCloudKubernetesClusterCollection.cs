// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing a collection of <see cref="NetworkCloudKubernetesClusterResource"/> and their operations.
    /// Each <see cref="NetworkCloudKubernetesClusterResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="NetworkCloudKubernetesClusterCollection"/> instance call the GetNetworkCloudKubernetesClusters method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class NetworkCloudKubernetesClusterCollection : ArmCollection, IEnumerable<NetworkCloudKubernetesClusterResource>, IAsyncEnumerable<NetworkCloudKubernetesClusterResource>
    {
        /// <summary>
        /// Create a new Kubernetes cluster or update the properties of the existing one.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusters_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="kubernetesClusterName"> The name of the Kubernetes cluster. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="kubernetesClusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="kubernetesClusterName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkCloudKubernetesClusterResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string kubernetesClusterName, NetworkCloudKubernetesClusterData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, kubernetesClusterName, data, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create a new Kubernetes cluster or update the properties of the existing one.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>KubernetesClusters_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudKubernetesClusterResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="kubernetesClusterName"> The name of the Kubernetes cluster. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="kubernetesClusterName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="kubernetesClusterName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NetworkCloudKubernetesClusterResource> CreateOrUpdate(WaitUntil waitUntil, string kubernetesClusterName, NetworkCloudKubernetesClusterData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, kubernetesClusterName, data, null, null, cancellationToken);
    }
}
