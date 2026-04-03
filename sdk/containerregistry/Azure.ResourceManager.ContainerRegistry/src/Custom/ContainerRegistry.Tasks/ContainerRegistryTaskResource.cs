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
    /// A class representing a Task along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="ContainerRegistryTaskResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource resource group using the GetTasks method.
    /// </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskResource : ArmResource, IJsonModel<ContainerRegistryTaskData>, IPersistableModel<ContainerRegistryTaskData>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryTaskResource"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryTaskResource"/> instance. </returns>
        ContainerRegistryTaskData IJsonModel<ContainerRegistryTaskData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryTaskResource"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryTaskData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryTaskResource"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryTaskResource"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryTaskData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryTaskResource"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryTaskResource"/> instance. </returns>
        ContainerRegistryTaskData IPersistableModel<ContainerRegistryTaskData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryTaskResource"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryTaskData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType;

        /// <summary> Initializes a new instance of <see cref="ContainerRegistryTaskResource"/> for mocking. </summary>
        protected ContainerRegistryTaskResource() : base() { }

        /// <summary> Gets the resource data for this task. </summary>
        [WirePath("")]
        public virtual ContainerRegistryTaskData Data { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> Gets a value indicating whether this resource has data. </summary>
        [WirePath("")]
        public virtual bool HasData { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="registryName"> The registryName. </param>
        /// <param name="taskName"> The taskName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskName) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ContainerRegistryTaskResource> Get(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<ContainerRegistryTaskResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Deletes a specified task.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Deletes a specified task.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Updates a task with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<ContainerRegistryTaskResource> Update(WaitUntil waitUntil, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Updates a task with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Task<ArmOperation<ContainerRegistryTaskResource>> UpdateAsync(WaitUntil waitUntil, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Updates a task with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future version. Use the Update(WaitUntil, ContainerRegistryTaskPatch, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerRegistryTaskResource> Update(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Updates a task with the specified parameters.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future version. Use the UpdateAsync(WaitUntil, ContainerRegistryTaskPatch, CancellationToken) overload instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerRegistryTaskResource>> UpdateAsync(ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<ContainerRegistryTaskResource> AddTag(string key, string value, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Task<Response<ContainerRegistryTaskResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<ContainerRegistryTaskResource> RemoveTag(string key, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Task<Response<ContainerRegistryTaskResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<ContainerRegistryTaskResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Task<Response<ContainerRegistryTaskResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Returns a task with extended information that includes all secrets.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}/listDetails. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_GetDetails. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ContainerRegistryTaskResource> GetDetails(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
        /// <summary>
        /// Returns a task with extended information that includes all secrets.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerRegistry/registries/{registryName}/tasks/{taskName}/listDetails. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Tasks_GetDetails. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ContainerRegistryTaskResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<ContainerRegistryTaskResource>> GetDetailsAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead."); }
    }
}
