// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for FileShare. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupFileShare : FileShare,
        IJsonModel<ContainerGroupFileShare>, IPersistableModel<ContainerGroupFileShare>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupFileShare"/>. </summary>
        /// <param name="name"> The name of the file share. </param>
        public ContainerGroupFileShare(string name) : base() { Name = name; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupFileShare() : base() { }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerGroupFileShareProperties Properties
        {
            get => default;
            set => base.Properties = value;
        }
        ContainerGroupFileShare IJsonModel<ContainerGroupFileShare>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use FileShare directly.");
        void IJsonModel<ContainerGroupFileShare>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<FileShare>)this).Write(writer, options);
        ContainerGroupFileShare IPersistableModel<ContainerGroupFileShare>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use FileShare directly.");
        string IPersistableModel<ContainerGroupFileShare>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<FileShare>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupFileShare>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<FileShare>)this).Write(options);
    }
}
