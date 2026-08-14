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
    // Backward compatibility: Trigger-related model types (BaseImageDependency, BaseImageTrigger,
    // SourceTrigger, TimerTrigger, TriggerProperties, TriggerUpdateContent, and related enums) have been
    // moved to Azure.ResourceManager.ContainerRegistry.Tasks. These deprecated stubs preserve the old API
    // surface with [Obsolete] attributes and NotSupportedException implementations so existing code compiles
    // but directs users to the new package.

    /// <summary> Properties that describe a base image dependency. </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryBaseImageDependency : IJsonModel<ContainerRegistryBaseImageDependency>, IPersistableModel<ContainerRegistryBaseImageDependency>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryBaseImageDependency"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryBaseImageDependency"/> instance. </returns>
        ContainerRegistryBaseImageDependency IJsonModel<ContainerRegistryBaseImageDependency>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryBaseImageDependency"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryBaseImageDependency>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryBaseImageDependency"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryBaseImageDependency"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryBaseImageDependency>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryBaseImageDependency"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryBaseImageDependency"/> instance. </returns>
        ContainerRegistryBaseImageDependency IPersistableModel<ContainerRegistryBaseImageDependency>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryBaseImageDependency"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryBaseImageDependency>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the JSON representation of this instance to the provided writer. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        internal ContainerRegistryBaseImageDependency() { }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("type")]
        public ContainerRegistryBaseImageDependencyType? DependencyType { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("digest")]
        public string Digest { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("registry")]
        public string Registry { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("repository")]
        public string Repository { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("tag")]
        public string Tag { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
    }
}
