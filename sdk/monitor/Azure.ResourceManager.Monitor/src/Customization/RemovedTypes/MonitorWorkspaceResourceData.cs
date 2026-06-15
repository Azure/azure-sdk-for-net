// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> An Azure Monitor Workspace resource data. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
    public partial class MonitorWorkspaceResourceData : TrackedResourceData, IJsonModel<MonitorWorkspaceResourceData>, IPersistableModel<MonitorWorkspaceResourceData>
    {
        private const string MovedMessage = "This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.";

        /// <summary> Initializes a new instance of <see cref="MonitorWorkspaceResourceData"/>. </summary>
        /// <param name="location"> The location. </param>
        public MonitorWorkspaceResourceData(AzureLocation location) : base(location)
        {
        }

        /// <summary> The immutable ID of the Azure Monitor Workspace. </summary>
        public string AccountId => throw new NotSupportedException(MovedMessage);

        /// <summary> The etag of the Azure Monitor Workspace. </summary>
        public ETag? ETag => throw new NotSupportedException(MovedMessage);

        /// <summary> Metrics settings for the Azure Monitor Workspace. </summary>
        public MonitorWorkspaceMetrics Metrics => throw new NotSupportedException(MovedMessage);

        /// <summary> Provisioning state of the Azure Monitor Workspace. </summary>
        public MonitorProvisioningState? ProvisioningState => throw new NotSupportedException(MovedMessage);

        /// <summary> Default ingestion settings for the Azure Monitor Workspace. </summary>
        public MonitorWorkspaceDefaultIngestionSettings DefaultIngestionSettings => throw new NotSupportedException(MovedMessage);

        /// <summary> Private endpoint connections for the Azure Monitor Workspace. </summary>
        public IReadOnlyList<MonitorWorkspacePrivateEndpointConnection> PrivateEndpointConnections => throw new NotSupportedException(MovedMessage);

        /// <summary> Public network access setting for the Azure Monitor Workspace. </summary>
        public MonitorWorkspacePublicNetworkAccess? PublicNetworkAccess => throw new NotSupportedException(MovedMessage);

        /// <inheritdoc/>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException(MovedMessage);

        void IJsonModel<MonitorWorkspaceResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException(MovedMessage);

        MonitorWorkspaceResourceData IJsonModel<MonitorWorkspaceResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException(MovedMessage);

        BinaryData IPersistableModel<MonitorWorkspaceResourceData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException(MovedMessage);

        MonitorWorkspaceResourceData IPersistableModel<MonitorWorkspaceResourceData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException(MovedMessage);

        string IPersistableModel<MonitorWorkspaceResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
