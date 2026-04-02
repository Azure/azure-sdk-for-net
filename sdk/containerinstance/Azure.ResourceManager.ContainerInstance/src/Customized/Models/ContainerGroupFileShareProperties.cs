// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

// Backward-compat: type alias for renamed type (ApiCompat TypesMustExist + CannotRemoveBaseTypeOrInterface)
// Old name: ContainerGroupFileShareProperties, New name: FileShareProperties

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward compatibility alias for <see cref="FileShareProperties"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupFileShareProperties : FileShareProperties,
        IJsonModel<ContainerGroupFileShareProperties>,
        IPersistableModel<ContainerGroupFileShareProperties>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupFileShareProperties"/>. </summary>
        public ContainerGroupFileShareProperties()
        {
        }

        ContainerGroupFileShareProperties IJsonModel<ContainerGroupFileShareProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use FileShareProperties for deserialization.");

        void IJsonModel<ContainerGroupFileShareProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<FileShareProperties>)this).Write(writer, options);

        ContainerGroupFileShareProperties IPersistableModel<ContainerGroupFileShareProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use FileShareProperties for deserialization.");

        string IPersistableModel<ContainerGroupFileShareProperties>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<FileShareProperties>)this).GetFormatFromOptions(options);

        BinaryData IPersistableModel<ContainerGroupFileShareProperties>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<FileShareProperties>)this).Write(options);
    }
}
