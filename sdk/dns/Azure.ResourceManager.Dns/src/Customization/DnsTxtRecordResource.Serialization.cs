// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Dns
{
    /// <summary></summary>
    public partial class DnsTxtRecordResource : IJsonModel<DnsTxtRecordData>
    {
        private static IJsonModel<DnsTxtRecordData> s_dataDeserializationInstance;

        private static IJsonModel<DnsTxtRecordData> DataDeserializationInstance => s_dataDeserializationInstance ??= new DnsTxtRecordData();

        /// <param name="writer"> The writer to serialize the model to. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<DnsTxtRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DnsTxtRecordData>)Data).Write(writer, options);

        /// <param name="reader"> The reader for deserializing the model. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsTxtRecordData IJsonModel<DnsTxtRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<DnsTxtRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<DnsTxtRecordData>(Data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="data"> The binary data to be processed. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsTxtRecordData IPersistableModel<DnsTxtRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DnsTxtRecordData>(data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<DnsTxtRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
