// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for ContainerAttachResponse. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerAttachResult : ContainerAttachResponse,
        IJsonModel<ContainerAttachResult>, IPersistableModel<ContainerAttachResult>
    {
        internal ContainerAttachResult() { }

        internal ContainerAttachResult(string webSocketUri, string password) : base(webSocketUri, password, null) { }

        internal ContainerAttachResult(ContainerAttachResponse response) : base(response.WebSocketUri, response.Password, null)
        {
        }

        // backward-compat shim: old property was Uri type, new is string
        /// <summary> The URI for the output stream from the attach. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Uri WebSocketUri => base.WebSocketUri != null ? new System.Uri(base.WebSocketUri) : null;
        ContainerAttachResult IJsonModel<ContainerAttachResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerAttachResponse directly.");
        void IJsonModel<ContainerAttachResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ContainerAttachResponse>)this).Write(writer, options);
        ContainerAttachResult IPersistableModel<ContainerAttachResult>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerAttachResponse directly.");
        string IPersistableModel<ContainerAttachResult>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerAttachResponse>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerAttachResult>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerAttachResponse>)this).Write(options);
    }
}
