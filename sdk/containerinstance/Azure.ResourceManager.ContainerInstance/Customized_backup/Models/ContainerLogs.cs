// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for Logs. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerLogs : Logs,
        IJsonModel<ContainerLogs>, IPersistableModel<ContainerLogs>
    {
        internal ContainerLogs() { }

        internal ContainerLogs(string content) : base(content, null) { }

        internal ContainerLogs(Logs logs) : base(logs.Content, null)
        {
        }
        ContainerLogs IJsonModel<ContainerLogs>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Logs directly.");
        void IJsonModel<ContainerLogs>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<Logs>)this).Write(writer, options);
        ContainerLogs IPersistableModel<ContainerLogs>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Logs directly.");
        string IPersistableModel<ContainerLogs>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<Logs>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerLogs>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<Logs>)this).Write(options);
    }
}
