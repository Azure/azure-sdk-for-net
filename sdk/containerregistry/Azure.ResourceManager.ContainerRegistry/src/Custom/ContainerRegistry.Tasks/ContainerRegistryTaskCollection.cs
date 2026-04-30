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
    /// A class representing a collection of <see cref="ContainerRegistryTaskResource"/> and their operations.
    /// Each <see cref="ContainerRegistryTaskResource"/> in the collection will belong to the same instance of resource group.
    /// To get a <see cref="ContainerRegistryTaskCollection"/> instance call the GetTasks method from an instance of resource group.
    /// </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskCollection : ArmCollection, IEnumerable<ContainerRegistryTaskResource>, IAsyncEnumerable<ContainerRegistryTaskResource>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryTaskCollection"/> for mocking. </summary>
        protected ContainerRegistryTaskCollection() : base() { }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<Response<bool>> ExistsAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Get the properties of a specified task.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ContainerRegistryTaskResource> Get(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Get the properties of a specified task.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<Response<ContainerRegistryTaskResource>> GetAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Lists all the tasks for a specified container registry.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerRegistryTaskResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ContainerRegistryTaskResource> GetAll(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Lists all the tasks for a specified container registry.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_List. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContainerRegistryTaskResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ContainerRegistryTaskResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<ContainerRegistryTaskResource> GetIfExists(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Get. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<NullableResponse<ContainerRegistryTaskResource>> GetIfExistsAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Creates a task for a container registry with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Create. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="data"> The parameters for creating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<ContainerRegistryTaskResource> CreateOrUpdate(WaitUntil waitUntil, string taskName, ContainerRegistryTaskData data, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Creates a task for a container registry with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Create. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="data"> The parameters for creating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="taskName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Task<ArmOperation<ContainerRegistryTaskResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string taskName, ContainerRegistryTaskData data, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }

        IEnumerator<ContainerRegistryTaskResource> IEnumerable<ContainerRegistryTaskResource>.GetEnumerator() { return GetAll().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetAll().GetEnumerator(); }
        IAsyncEnumerator<ContainerRegistryTaskResource> IAsyncEnumerable<ContainerRegistryTaskResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
    }
}
