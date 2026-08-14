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
    /// <summary>
    /// Base properties for updating any task step.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="ContainerRegistryDockerBuildStepUpdateContent"/>, <see cref="ContainerRegistryFileTaskStepUpdateContent"/>, and <see cref="ContainerRegistryEncodedTaskStepUpdateContent"/>.
    /// </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PersistableModelProxy(typeof(UnknownTaskStepUpdateParameters))]
    public abstract partial class ContainerRegistryTaskStepUpdateContent : IJsonModel<ContainerRegistryTaskStepUpdateContent>, IPersistableModel<ContainerRegistryTaskStepUpdateContent>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryTaskStepUpdateContent"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryTaskStepUpdateContent"/> instance. </returns>
        ContainerRegistryTaskStepUpdateContent IJsonModel<ContainerRegistryTaskStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryTaskStepUpdateContent"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryTaskStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryTaskStepUpdateContent"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryTaskStepUpdateContent"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryTaskStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryTaskStepUpdateContent"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryTaskStepUpdateContent"/> instance. </returns>
        ContainerRegistryTaskStepUpdateContent IPersistableModel<ContainerRegistryTaskStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryTaskStepUpdateContent"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryTaskStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Initializes a new instance of this compatibility shim type. </summary>
        protected ContainerRegistryTaskStepUpdateContent() { }
        /// <summary> Writes the JSON representation of this instance to the provided writer. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("contextPath")]
        public string ContextPath { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("contextAccessToken")]
        public string ContextAccessToken { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
    }
}
