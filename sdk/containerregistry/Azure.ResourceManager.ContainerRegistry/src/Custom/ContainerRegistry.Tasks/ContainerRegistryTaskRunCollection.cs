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
    /// A class representing a collection of <see cref="ContainerRegistryTaskRunResource"/> and their operations.
    /// Each <see cref="ContainerRegistryTaskRunResource"/> in the collection will belong to the same instance of resource group.
    /// To get a <see cref="ContainerRegistryTaskRunCollection"/> instance call the GetTaskRuns method from an instance of resource group.
    /// </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskRunCollection : ArmCollection, IEnumerable<ContainerRegistryTaskRunResource>, IAsyncEnumerable<ContainerRegistryTaskRunResource>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryTaskRunCollection"/> for mocking. </summary>
        protected ContainerRegistryTaskRunCollection() : base() { }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns/{taskRunName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskRunName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskRunName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns/{taskRunName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskRunName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskRunName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<Response<bool>> ExistsAsync(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets the detailed information for a given task run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns/{taskRunName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskRunName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskRunName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ContainerRegistryTaskRunResource> Get(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Gets the detailed information for a given task run.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns/{taskRunName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskRunName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskRunName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<Response<ContainerRegistryTaskRunResource>> GetAsync(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Lists all the task runs for a specified container registry.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerRegistryTaskRunResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ContainerRegistryTaskRunResource> GetAll(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Lists all the task runs for a specified container registry.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerRegistryTaskRunResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ContainerRegistryTaskRunResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns/{taskRunName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskRunName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskRunName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<ContainerRegistryTaskRunResource> GetIfExists(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns/{taskRunName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskRunName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskRunName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<NullableResponse<ContainerRegistryTaskRunResource>> GetIfExistsAsync(string taskRunName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Creates a task run for a container registry with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns/{taskRunName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_Create. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="data"> The parameters of a run that needs to scheduled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskRunName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskRunName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<ContainerRegistryTaskRunResource> CreateOrUpdate(WaitUntil waitUntil, string taskRunName, ContainerRegistryTaskRunData data, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Creates a task run for a container registry with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/taskRuns/{taskRunName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> TaskRuns_Create. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="taskRunName"> The name of the task run. </param>
        /// <param name="data"> The parameters of a run that needs to scheduled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskRunName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskRunName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<ArmOperation<ContainerRegistryTaskRunResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string taskRunName, ContainerRegistryTaskRunData data, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }

        IEnumerator<ContainerRegistryTaskRunResource> IEnumerable<ContainerRegistryTaskRunResource>.GetEnumerator() { return GetAll().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetAll().GetEnumerator(); }
        IAsyncEnumerator<ContainerRegistryTaskRunResource> IAsyncEnumerable<ContainerRegistryTaskRunResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
    }
}
