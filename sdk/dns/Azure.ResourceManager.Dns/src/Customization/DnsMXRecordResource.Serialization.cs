// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Dns
{
    /// <summary></summary>
    public partial class DnsMXRecordResource : IJsonModel<DnsMXRecordData>
    {
        private static IJsonModel<DnsMXRecordData> s_dataDeserializationInstance;

        private static IJsonModel<DnsMXRecordData> DataDeserializationInstance => s_dataDeserializationInstance ??= new DnsMXRecordData();

        /// <param name="writer"> The writer to serialize the model to. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<DnsMXRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DnsMXRecordData>)Data).Write(writer, options);

        /// <param name="reader"> The reader for deserializing the model. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsMXRecordData IJsonModel<DnsMXRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<DnsMXRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<DnsMXRecordData>(Data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="data"> The binary data to be processed. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DnsMXRecordData IPersistableModel<DnsMXRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DnsMXRecordData>(data, options, AzureResourceManagerDnsContext.Default);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<DnsMXRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}
