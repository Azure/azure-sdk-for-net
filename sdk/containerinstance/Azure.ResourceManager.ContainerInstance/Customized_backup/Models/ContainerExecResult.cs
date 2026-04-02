// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for ContainerExecResponse. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerExecResult : ContainerExecResponse,
        IJsonModel<ContainerExecResult>, IPersistableModel<ContainerExecResult>
    {
        internal ContainerExecResult() { }

        internal ContainerExecResult(string webSocketUri, string password) : base(webSocketUri, password, null) { }

        internal ContainerExecResult(ContainerExecResponse response) : base(response.WebSocketUri, response.Password, null)
        {
        }

        // backward-compat shim: old property was Uri type, new is string
        /// <summary> The URI for the output stream from the exec. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Uri WebSocketUri => base.WebSocketUri != null ? new System.Uri(base.WebSocketUri) : null;
        ContainerExecResult IJsonModel<ContainerExecResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerExecResponse directly.");
        void IJsonModel<ContainerExecResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ContainerExecResponse>)this).Write(writer, options);
        ContainerExecResult IPersistableModel<ContainerExecResult>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerExecResponse directly.");
        string IPersistableModel<ContainerExecResult>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerExecResponse>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerExecResult>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerExecResponse>)this).Write(options);
    }
}
