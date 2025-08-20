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

namespace Azure.ResourceManager.NetworkCloud
 {
    /// <summary>
    /// A class representing a collection of <see cref="NetworkCloudAgentPoolResource"/> and their operations.
    /// Each <see cref="NetworkCloudAgentPoolResource"/> in the collection will belong to the same instance of <see cref="NetworkCloudKubernetesClusterResource"/>.
    /// To get a <see cref="NetworkCloudAgentPoolCollection"/> instance call the GetNetworkCloudAgentPools method from an instance of <see cref="NetworkCloudKubernetesClusterResource"/>.
    /// </summary>
    public partial class NetworkCloudAgentPoolCollection : ArmCollection, IEnumerable<NetworkCloudAgentPoolResource>, IAsyncEnumerable<NetworkCloudAgentPoolResource>
    {
    /// <summary>
    /// Create a new Kubernetes cluster agent pool or update the properties of the existing one.
    /// <list type="bullet">
    /// <item>
    /// <term>Request Path</term>
    /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools/{agentPoolName}</description>
    /// </item>
    /// <item>
    /// <term>Operation Id</term>
    /// <description>AgentPools_CreateOrUpdate</description>
    /// </item>
    /// <item>
    /// <term>Default Api Version</term>
    /// <description>2025-02-01</description>
    /// </item>
    /// <item>
    /// <term>Resource</term>
    /// <description><see cref="NetworkCloudAgentPoolResource"/></description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
    /// <param name="agentPoolName"> The name of the Kubernetes cluster agent pool. </param>
    /// <param name="data"> The request body. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> or <paramref name="data"/> is null. </exception>
    public virtual ArmOperation<NetworkCloudAgentPoolResource> CreateOrUpdate(WaitUntil waitUntil, string agentPoolName, NetworkCloudAgentPoolData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, agentPoolName, data, null, null, cancellationToken);
        }

    /// <summary>
    /// Create a new Kubernetes cluster agent pool or update the properties of the existing one.
    /// <list type="bullet">
    /// <item>
    /// <term>Request Path</term>
    /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools/{agentPoolName}</description>
    /// </item>
    /// <item>
    /// <term>Operation Id</term>
    /// <description>AgentPools_CreateOrUpdate</description>
    /// </item>
    /// <item>
    /// <term>Default Api Version</term>
    /// <description>2025-02-01</description>
    /// </item>
    /// <item>
    /// <term>Resource</term>
    /// <description><see cref="NetworkCloudAgentPoolResource"/></description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
    /// <param name="agentPoolName"> The name of the Kubernetes cluster agent pool. </param>
    /// <param name="data"> The request body. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> or <paramref name="data"/> is null. </exception>
    public virtual async Task<ArmOperation<NetworkCloudAgentPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string agentPoolName, NetworkCloudAgentPoolData data, CancellationToken cancellationToken) {
        return await CreateOrUpdateAsync(waitUntil, agentPoolName, data, null, null, cancellationToken).ConfigureAwait(false);
        }
    }
 }