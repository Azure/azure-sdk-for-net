// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    /// <summary>
    /// A class representing a collection of <see cref="ContainerRegistryAgentPoolResource"/> and their operations.
    /// Each <see cref="ContainerRegistryAgentPoolResource"/> in the collection will belong to the same instance of resource group.
    /// To get a <see cref="ContainerRegistryAgentPoolCollection"/> instance call the GetAgentPools method from an instance of resource group.
    /// </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryAgentPoolCollection : ArmCollection, IEnumerable<ContainerRegistryAgentPoolResource>, IAsyncEnumerable<ContainerRegistryAgentPoolResource>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryAgentPoolCollection"/> for mocking. </summary>
        protected ContainerRegistryAgentPoolCollection() : base() { }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools/{agentPoolName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools/{agentPoolName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<Response<bool>> ExistsAsync(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets the detailed information for a given agent pool.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools/{agentPoolName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ContainerRegistryAgentPoolResource> Get(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets the detailed information for a given agent pool.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools/{agentPoolName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<Response<ContainerRegistryAgentPoolResource>> GetAsync(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Lists all the agent pools for a specified container registry.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerRegistryAgentPoolResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ContainerRegistryAgentPoolResource> GetAll(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Lists all the agent pools for a specified container registry.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerRegistryAgentPoolResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ContainerRegistryAgentPoolResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools/{agentPoolName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<ContainerRegistryAgentPoolResource> GetIfExists(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools/{agentPoolName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<NullableResponse<ContainerRegistryAgentPoolResource>> GetIfExistsAsync(string agentPoolName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Creates an agent pool for a container registry with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools/{agentPoolName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_Create. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="data"> The parameters of an agent pool that needs to scheduled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<ContainerRegistryAgentPoolResource> CreateOrUpdate(WaitUntil waitUntil, string agentPoolName, ContainerRegistryAgentPoolData data, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Creates an agent pool for a container registry with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/agentPools/{agentPoolName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AgentPools_Create. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="data"> The parameters of an agent pool that needs to scheduled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<ArmOperation<ContainerRegistryAgentPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string agentPoolName, ContainerRegistryAgentPoolData data, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        IEnumerator<ContainerRegistryAgentPoolResource> IEnumerable<ContainerRegistryAgentPoolResource>.GetEnumerator() { return GetAll().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetAll().GetEnumerator(); }
        IAsyncEnumerator<ContainerRegistryAgentPoolResource> IAsyncEnumerable<ContainerRegistryAgentPoolResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
    }
}
