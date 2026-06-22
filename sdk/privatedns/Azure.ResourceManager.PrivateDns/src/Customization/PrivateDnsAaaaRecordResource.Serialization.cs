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
    public partial class PrivateDnsAaaaRecordResource : IJsonModel<PrivateDnsAaaaRecordData>
    {
        private static IJsonModel<PrivateDnsAaaaRecordData> s_dataDeserializationInstance;

        private static IJsonModel<PrivateDnsAaaaRecordData> DataDeserializationInstance => s_dataDeserializationInstance ??= new PrivateDnsAaaaRecordData();

        /// <param name="writer"> The writer to serialize the model to. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<PrivateDnsAaaaRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<PrivateDnsAaaaRecordData>)Data).Write(writer, options);

        /// <param name="reader"> The reader for deserializing the model. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsAaaaRecordData IJsonModel<PrivateDnsAaaaRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<PrivateDnsAaaaRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<PrivateDnsAaaaRecordData>(Data, options, AzureResourceManagerPrivateDnsContext.Default);

        /// <param name="data"> The binary data to be processed. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsAaaaRecordData IPersistableModel<PrivateDnsAaaaRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<PrivateDnsAaaaRecordData>(data, options, AzureResourceManagerPrivateDnsContext.Default);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<PrivateDnsAaaaRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
