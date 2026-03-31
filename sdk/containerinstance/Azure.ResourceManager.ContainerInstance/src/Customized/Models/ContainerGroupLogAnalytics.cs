// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for LogAnalytics. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupLogAnalytics : LogAnalytics,
        IJsonModel<ContainerGroupLogAnalytics>, IPersistableModel<ContainerGroupLogAnalytics>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupLogAnalytics"/>. </summary>
        public ContainerGroupLogAnalytics(string workspaceId, string workspaceKey) : base(workspaceId, workspaceKey) { }

        // backward-compat shim: old WorkspaceResourceId was ResourceIdentifier, new is string
        /// <summary> The workspace resource id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Azure.Core.ResourceIdentifier WorkspaceResourceId
        {
            get => base.WorkspaceResourceId != null ? new Azure.Core.ResourceIdentifier(base.WorkspaceResourceId) : null;
            set => base.WorkspaceResourceId = value?.ToString();
        }

        // backward-compat shim: old LogType was ContainerGroupLogAnalyticsLogType?, new is LogAnalyticsLogType?
        /// <summary> The log analytics log type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerGroupLogAnalyticsLogType? LogType
        {
            get => base.LogType.HasValue ? (ContainerGroupLogAnalyticsLogType)base.LogType.Value : null;
            set => base.LogType = value.HasValue ? (LogAnalyticsLogType)value.Value : null;
        }
        ContainerGroupLogAnalytics IJsonModel<ContainerGroupLogAnalytics>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use LogAnalytics directly.");
        void IJsonModel<ContainerGroupLogAnalytics>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<LogAnalytics>)this).Write(writer, options);
        ContainerGroupLogAnalytics IPersistableModel<ContainerGroupLogAnalytics>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use LogAnalytics directly.");
        string IPersistableModel<ContainerGroupLogAnalytics>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<LogAnalytics>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupLogAnalytics>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<LogAnalytics>)this).Write(options);
    }
}
