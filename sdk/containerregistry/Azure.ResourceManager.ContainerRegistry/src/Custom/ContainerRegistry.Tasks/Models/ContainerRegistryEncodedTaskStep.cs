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
    /// <summary> The properties of a encoded task step. </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryEncodedTaskStep : ContainerRegistryTaskStepProperties, IJsonModel<ContainerRegistryEncodedTaskStep>, IPersistableModel<ContainerRegistryEncodedTaskStep>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryEncodedTaskStep"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryEncodedTaskStep"/> instance. </returns>
        ContainerRegistryEncodedTaskStep IJsonModel<ContainerRegistryEncodedTaskStep>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryEncodedTaskStep"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryEncodedTaskStep>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryEncodedTaskStep"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryEncodedTaskStep"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryEncodedTaskStep>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryEncodedTaskStep"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryEncodedTaskStep"/> instance. </returns>
        ContainerRegistryEncodedTaskStep IPersistableModel<ContainerRegistryEncodedTaskStep>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryEncodedTaskStep"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryEncodedTaskStep>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Initializes a new instance of this compatibility shim type. </summary>
        public ContainerRegistryEncodedTaskStep(string encodedTaskContent) { }
        /// <summary> Writes the JSON representation of this instance to the provided writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("encodedTaskContent")]
        public string EncodedTaskContent { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("encodedValuesContent")]
        public string EncodedValuesContent { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
    }
}
