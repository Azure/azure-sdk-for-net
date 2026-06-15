// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy Azure Monitor workspace private endpoint connection. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
    public partial class MonitorWorkspacePrivateEndpointConnection : ResourceData, IJsonModel<MonitorWorkspacePrivateEndpointConnection>, IPersistableModel<MonitorWorkspacePrivateEndpointConnection>
    {
        /// <summary> Initializes a new instance of <see cref="MonitorWorkspacePrivateEndpointConnection"/>. </summary>
        public MonitorWorkspacePrivateEndpointConnection()
        {
        }

        /// <summary> Connection state. </summary>
        public MonitorPrivateLinkServiceConnectionState ConnectionState { get; set; }

        /// <summary> Group IDs. </summary>
        public IReadOnlyList<string> GroupIds { get; }

        /// <summary> Private endpoint ID. </summary>
        public ResourceIdentifier PrivateEndpointId { get; }

        /// <summary> Provisioning state. </summary>
        public MonitorPrivateEndpointConnectionProvisioningState? ProvisioningState { get; }

        /// <inheritdoc/>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        void IJsonModel<MonitorWorkspacePrivateEndpointConnection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        MonitorWorkspacePrivateEndpointConnection IJsonModel<MonitorWorkspacePrivateEndpointConnection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        BinaryData IPersistableModel<MonitorWorkspacePrivateEndpointConnection>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        MonitorWorkspacePrivateEndpointConnection IPersistableModel<MonitorWorkspacePrivateEndpointConnection>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        string IPersistableModel<MonitorWorkspacePrivateEndpointConnection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}