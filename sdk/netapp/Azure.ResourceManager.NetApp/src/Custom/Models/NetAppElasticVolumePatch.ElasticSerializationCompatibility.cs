// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable SA1649
#pragma warning disable CS1591

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppElasticVolumePatch : IJsonModel<NetAppElasticVolumePatch>, IPersistableModel<NetAppElasticVolumePatch>
    {
        public NetAppElasticVolumePatch() { Tags = new ChangeTrackingDictionary<string, string>(); }
        protected virtual NetAppElasticVolumePatch PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new NetAppElasticVolumePatch());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        NetAppElasticVolumePatch IPersistableModel<NetAppElasticVolumePatch>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<NetAppElasticVolumePatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<NetAppElasticVolumePatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<NetAppElasticVolumePatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        NetAppElasticVolumePatch IJsonModel<NetAppElasticVolumePatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual NetAppElasticVolumePatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticVolumePatch();
    }
}
