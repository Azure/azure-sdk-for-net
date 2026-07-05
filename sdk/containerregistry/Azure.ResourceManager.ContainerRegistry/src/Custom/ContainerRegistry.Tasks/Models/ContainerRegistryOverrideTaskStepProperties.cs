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
    /// <summary> The ContainerRegistryOverrideTaskStepProperties. </summary>
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistry.Tasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryOverrideTaskStepProperties : IJsonModel<ContainerRegistryOverrideTaskStepProperties>, IPersistableModel<ContainerRegistryOverrideTaskStepProperties>
    {
        /// <summary> Creates an instance of <see cref="ContainerRegistryOverrideTaskStepProperties"/> from the provided JSON reader. </summary>
        /// <param name="reader"> The JSON reader containing the serialized model. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryOverrideTaskStepProperties"/> instance. </returns>
        ContainerRegistryOverrideTaskStepProperties IJsonModel<ContainerRegistryOverrideTaskStepProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the current <see cref="ContainerRegistryOverrideTaskStepProperties"/> instance to the provided JSON writer. </summary>
        /// <param name="writer"> The JSON writer to write to. </param>
        /// <param name="options"> The serialization options to use. </param>
        void IJsonModel<ContainerRegistryOverrideTaskStepProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Writes the current <see cref="ContainerRegistryOverrideTaskStepProperties"/> instance to a binary payload. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A binary representation of this <see cref="ContainerRegistryOverrideTaskStepProperties"/> instance. </returns>
        BinaryData IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Creates an instance of <see cref="ContainerRegistryOverrideTaskStepProperties"/> from the provided binary payload. </summary>
        /// <param name="data"> The serialized data to read from. </param>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> A deserialized <see cref="ContainerRegistryOverrideTaskStepProperties"/> instance. </returns>
        ContainerRegistryOverrideTaskStepProperties IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Gets the wire format used for this <see cref="ContainerRegistryOverrideTaskStepProperties"/> instance with the provided options. </summary>
        /// <param name="options"> The serialization options to use. </param>
        /// <returns> The format string used for persistence. </returns>
        string IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("Use the corresponding method in Azure.ResourceManager.ContainerRegistry instead.");
        /// <summary> Writes the JSON representation of this instance to the provided writer. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("contextPath")]
        public string ContextPath { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("file")]
        public string File { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("target")]
        public string Target { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("updateTriggerToken")]
        public string UpdateTriggerToken { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } set { } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
        /// <summary> Gets or sets the compatibility shim property value. </summary>
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException("Use the corresponding property in Azure.ResourceManager.ContainerRegistry instead."); } }
    }
}
