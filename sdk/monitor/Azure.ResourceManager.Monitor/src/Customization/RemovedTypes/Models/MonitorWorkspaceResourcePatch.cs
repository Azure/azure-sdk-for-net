// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy Azure Monitor workspace patch model. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
    public partial class MonitorWorkspaceResourcePatch : IJsonModel<MonitorWorkspaceResourcePatch>, IPersistableModel<MonitorWorkspaceResourcePatch>
    {
        /// <summary> Initializes a new instance of <see cref="MonitorWorkspaceResourcePatch"/>. </summary>
        public MonitorWorkspaceResourcePatch()
        {
        }

        /// <summary> Metrics settings. </summary>
        public MonitorWorkspaceMetricProperties Metrics { get; set; }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        void IJsonModel<MonitorWorkspaceResourcePatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        MonitorWorkspaceResourcePatch IJsonModel<MonitorWorkspaceResourcePatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        BinaryData IPersistableModel<MonitorWorkspaceResourcePatch>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        MonitorWorkspaceResourcePatch IPersistableModel<MonitorWorkspaceResourcePatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        string IPersistableModel<MonitorWorkspaceResourcePatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}