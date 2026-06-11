// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Dns
{
    /// <summary></summary>
    public partial class DnsCnameRecordResource : IJsonModel<DnsBaseRecordData>
    {
        private static IJsonModel<DnsBaseRecordData> s_dataDeserializationInstance;

        private static IJsonModel<DnsBaseRecordData> DataDeserializationInstance => s_dataDeserializationInstance ??= new DnsBaseRecordData();

        /// <param name="writer"> The writer to serialize the model to. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<DnsBaseRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DnsBaseRecordData>)Data).Write(writer, options);

        /// <param name="reader"> The reader for deserializing the model. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsBaseRecordData IJsonModel<DnsBaseRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<DnsBaseRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<DnsBaseRecordData>(Data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="data"> The binary data to be processed. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsBaseRecordData IPersistableModel<DnsBaseRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DnsBaseRecordData>(data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<DnsBaseRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
