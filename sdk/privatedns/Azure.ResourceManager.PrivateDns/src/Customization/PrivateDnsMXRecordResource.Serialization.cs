// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec generates a shared record-set data model and record-type parameters; these partials preserve the shipped per-record data and fixed-record-type APIs.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary></summary>
    public partial class PrivateDnsMXRecordResource : IJsonModel<PrivateDnsMXRecordData>
    {
        private static IJsonModel<PrivateDnsMXRecordData> s_dataDeserializationInstance;

        private static IJsonModel<PrivateDnsMXRecordData> DataDeserializationInstance => s_dataDeserializationInstance ??= new PrivateDnsMXRecordData();

        /// <param name="writer"> The writer to serialize the model to. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<PrivateDnsMXRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<PrivateDnsMXRecordData>)Data).Write(writer, options);

        /// <param name="reader"> The reader for deserializing the model. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsMXRecordData IJsonModel<PrivateDnsMXRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<PrivateDnsMXRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<PrivateDnsMXRecordData>(Data, options, AzureResourceManagerPrivateDnsContext.Default);

        /// <param name="data"> The binary data to be processed. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsMXRecordData IPersistableModel<PrivateDnsMXRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<PrivateDnsMXRecordData>(data, options, AzureResourceManagerPrivateDnsContext.Default);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<PrivateDnsMXRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
