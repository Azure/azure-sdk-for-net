// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Dns
{
    /// <summary></summary>
    public partial class DnsPtrRecordResource : IJsonModel<DnsPtrRecordData>
    {
        private static IJsonModel<DnsPtrRecordData> s_dataDeserializationInstance;

        private static IJsonModel<DnsPtrRecordData> DataDeserializationInstance => s_dataDeserializationInstance ??= new DnsPtrRecordData();

        /// <param name="writer"> The writer to serialize the model to. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<DnsPtrRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DnsPtrRecordData>)Data).Write(writer, options);

        /// <param name="reader"> The reader for deserializing the model. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsPtrRecordData IJsonModel<DnsPtrRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<DnsPtrRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<DnsPtrRecordData>(Data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="data"> The binary data to be processed. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsPtrRecordData IPersistableModel<DnsPtrRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DnsPtrRecordData>(data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<DnsPtrRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
