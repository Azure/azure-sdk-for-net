// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Dns
{
    /// <summary></summary>
    public partial class DnsTlsaRecordResource : IJsonModel<DnsTlsaRecordData>
    {
        private static IJsonModel<DnsTlsaRecordData> s_dataDeserializationInstance;

        private static IJsonModel<DnsTlsaRecordData> DataDeserializationInstance => s_dataDeserializationInstance ??= new DnsTlsaRecordData();

        /// <param name="writer"> The writer to serialize the model to. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<DnsTlsaRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DnsTlsaRecordData>)Data).Write(writer, options);

        /// <param name="reader"> The reader for deserializing the model. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsTlsaRecordData IJsonModel<DnsTlsaRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<DnsTlsaRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<DnsTlsaRecordData>(Data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="data"> The binary data to be processed. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsTlsaRecordData IPersistableModel<DnsTlsaRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DnsTlsaRecordData>(data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<DnsTlsaRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
