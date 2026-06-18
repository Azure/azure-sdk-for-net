// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy VM Insights data container workspace. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class DataContainerWorkspace : IJsonModel<DataContainerWorkspace>, IPersistableModel<DataContainerWorkspace>
    {
        internal DataContainerWorkspace()
        {
        }

        /// <summary> The workspace id. </summary>
        public ResourceIdentifier Id { get; }

        /// <summary> The location. </summary>
        public AzureLocation Location { get; }

        /// <summary> The customer id. </summary>
        public string CustomerId { get; }

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<DataContainerWorkspace>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DataContainerWorkspace IJsonModel<DataContainerWorkspace>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<DataContainerWorkspace>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DataContainerWorkspace IPersistableModel<DataContainerWorkspace>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<DataContainerWorkspace>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
