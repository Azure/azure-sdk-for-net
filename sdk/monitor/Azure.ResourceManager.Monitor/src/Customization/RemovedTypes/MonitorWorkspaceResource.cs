// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A class representing a MonitorWorkspace resource and its operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
    public partial class MonitorWorkspaceResource : ArmResource, IJsonModel<MonitorWorkspaceResourceData>, IPersistableModel<MonitorWorkspaceResourceData>
    {
        private const string MovedMessage = "This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.";

        /// <summary> The resource type for MonitorWorkspace resources. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Monitor/accounts";

        /// <summary> Initializes a new instance of the <see cref="MonitorWorkspaceResource"/> class for mocking. </summary>
        protected MonitorWorkspaceResource()
        {
        }

        /// <summary> Gets the resource data. </summary>
        public virtual MonitorWorkspaceResourceData Data => throw new NotSupportedException(MovedMessage);

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData => throw new NotSupportedException(MovedMessage);

        /// <summary> Creates a resource identifier for a MonitorWorkspace resource. </summary>
        /// <param name="subscriptionId"> The subscription id. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <returns> A resource identifier. </returns>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureMonitorWorkspaceName) => throw new NotSupportedException(MovedMessage);

        /// <summary> Gets the MonitorWorkspace resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        public virtual Response<MonitorWorkspaceResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Gets the MonitorWorkspace resource. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        public virtual Task<Response<MonitorWorkspaceResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Deletes the MonitorWorkspace resource. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation. </returns>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Deletes the MonitorWorkspace resource. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation. </returns>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Updates the MonitorWorkspace resource. </summary>
        /// <param name="patch"> The MonitorWorkspace patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated MonitorWorkspace resource. </returns>
        public virtual Response<MonitorWorkspaceResource> Update(BinaryData patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Updates the MonitorWorkspace resource. </summary>
        /// <param name="patch"> The MonitorWorkspace patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated MonitorWorkspace resource. </returns>
        public virtual Task<Response<MonitorWorkspaceResource>> UpdateAsync(BinaryData patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Adds a tag to the MonitorWorkspace resource. </summary>
        public virtual Response<MonitorWorkspaceResource> AddTag(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Adds a tag to the MonitorWorkspace resource. </summary>
        public virtual Task<Response<MonitorWorkspaceResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Removes a tag from the MonitorWorkspace resource. </summary>
        public virtual Response<MonitorWorkspaceResource> RemoveTag(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Removes a tag from the MonitorWorkspace resource. </summary>
        public virtual Task<Response<MonitorWorkspaceResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Replaces tags on the MonitorWorkspace resource. </summary>
        public virtual Response<MonitorWorkspaceResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Replaces tags on the MonitorWorkspace resource. </summary>
        public virtual Task<Response<MonitorWorkspaceResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Updates the MonitorWorkspace resource. </summary>
        public virtual Response<MonitorWorkspaceResource> Update(MonitorWorkspaceResourcePatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        /// <summary> Updates the MonitorWorkspace resource. </summary>
        public virtual Task<Response<MonitorWorkspaceResource>> UpdateAsync(MonitorWorkspaceResourcePatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(MovedMessage);

        void IJsonModel<MonitorWorkspaceResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException(MovedMessage);

        MonitorWorkspaceResourceData IJsonModel<MonitorWorkspaceResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException(MovedMessage);

        BinaryData IPersistableModel<MonitorWorkspaceResourceData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException(MovedMessage);

        MonitorWorkspaceResourceData IPersistableModel<MonitorWorkspaceResourceData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException(MovedMessage);

        string IPersistableModel<MonitorWorkspaceResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}