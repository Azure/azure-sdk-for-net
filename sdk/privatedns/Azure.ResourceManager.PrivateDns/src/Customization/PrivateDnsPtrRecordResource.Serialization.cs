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
    public partial class PrivateDnsPtrRecordResource : IJsonModel<PrivateDnsPtrRecordData>
    {
        private static IJsonModel<PrivateDnsPtrRecordData> s_dataDeserializationInstance;

        private static IJsonModel<PrivateDnsPtrRecordData> DataDeserializationInstance => s_dataDeserializationInstance ??= new PrivateDnsPtrRecordData();

        /// <param name="writer"> The writer to serialize the model to. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<PrivateDnsPtrRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<PrivateDnsPtrRecordData>)Data).Write(writer, options);

        /// <param name="reader"> The reader for deserializing the model. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsPtrRecordData IJsonModel<PrivateDnsPtrRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<PrivateDnsPtrRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<PrivateDnsPtrRecordData>(Data, options, AzureResourceManagerPrivateDnsContext.Default);

        /// <param name="data"> The binary data to be processed. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsPtrRecordData IPersistableModel<PrivateDnsPtrRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<PrivateDnsPtrRecordData>(data, options, AzureResourceManagerPrivateDnsContext.Default);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<PrivateDnsPtrRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
