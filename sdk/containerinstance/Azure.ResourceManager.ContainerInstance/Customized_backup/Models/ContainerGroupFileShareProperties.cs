// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for FileShareProperties. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupFileShareProperties : FileShareProperties,
        IJsonModel<ContainerGroupFileShareProperties>, IPersistableModel<ContainerGroupFileShareProperties>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupFileShareProperties"/>. </summary>
        public ContainerGroupFileShareProperties() : base() { }
        ContainerGroupFileShareProperties IJsonModel<ContainerGroupFileShareProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use FileShareProperties directly.");
        void IJsonModel<ContainerGroupFileShareProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<FileShareProperties>)this).Write(writer, options);
        ContainerGroupFileShareProperties IPersistableModel<ContainerGroupFileShareProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use FileShareProperties directly.");
        string IPersistableModel<ContainerGroupFileShareProperties>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<FileShareProperties>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupFileShareProperties>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<FileShareProperties>)this).Write(options);
    }
}
