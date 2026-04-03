// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> The properties for updating the platform configuration. </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryPlatformUpdateContent : IJsonModel<ContainerRegistryPlatformUpdateContent>, IPersistableModel<ContainerRegistryPlatformUpdateContent>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryPlatformUpdateContent"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryPlatformUpdateContent"/> instance. </returns>
        ContainerRegistryPlatformUpdateContent IJsonModel<ContainerRegistryPlatformUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryPlatformUpdateContent"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryPlatformUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryPlatformUpdateContent"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryPlatformUpdateContent"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryPlatformUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryPlatformUpdateContent"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryPlatformUpdateContent"/> instance. </returns>
        ContainerRegistryPlatformUpdateContent IPersistableModel<ContainerRegistryPlatformUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryPlatformUpdateContent"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryPlatformUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the JSON representation of this instance to the provided writer. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("os")]
        public ContainerRegistryOS? OS { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("architecture")]
        public ContainerRegistryOSArchitecture? Architecture { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("variant")]
        public ContainerRegistryCpuVariant? Variant { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
    }
}
