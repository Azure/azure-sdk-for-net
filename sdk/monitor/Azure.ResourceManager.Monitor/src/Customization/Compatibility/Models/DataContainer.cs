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
    /// <summary> Legacy VM Insights data container. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is no longer supported.", false)]
    public partial class DataContainer : IJsonModel<DataContainer>, IPersistableModel<DataContainer>
    {
        internal DataContainer()
        {
        }

        /// <summary> The workspace. </summary>
        public DataContainerWorkspace Workspace { get; }

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<DataContainer>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DataContainer IJsonModel<DataContainer>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<DataContainer>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DataContainer IPersistableModel<DataContainer>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<DataContainer>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
