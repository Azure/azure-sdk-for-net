// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
#pragma warning disable SA1402

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppElasticVolumeData : IJsonModel<NetAppElasticVolumeData>, IPersistableModel<NetAppElasticVolumeData>
    {
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticVolumeData(default);
        protected virtual ResourceData PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticVolumeData(default);
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => System.BinaryData.FromString("{}");

        NetAppElasticVolumeData IJsonModel<NetAppElasticVolumeData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetAppElasticVolumeData)JsonModelCreateCore(ref reader, options);
        void IJsonModel<NetAppElasticVolumeData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        NetAppElasticVolumeData IPersistableModel<NetAppElasticVolumeData>.Create(System.BinaryData data, ModelReaderWriterOptions options) => (NetAppElasticVolumeData)PersistableModelCreateCore(data, options);
        string IPersistableModel<NetAppElasticVolumeData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<NetAppElasticVolumeData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}
