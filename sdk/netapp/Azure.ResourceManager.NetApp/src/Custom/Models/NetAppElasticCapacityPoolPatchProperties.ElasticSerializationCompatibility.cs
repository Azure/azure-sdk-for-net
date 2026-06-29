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
    public partial class NetAppElasticCapacityPoolPatchProperties : IJsonModel<NetAppElasticCapacityPoolPatchProperties>, IPersistableModel<NetAppElasticCapacityPoolPatchProperties>
    {
        public NetAppElasticCapacityPoolPatchProperties() { }
        protected virtual NetAppElasticCapacityPoolPatchProperties PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new NetAppElasticCapacityPoolPatchProperties());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        NetAppElasticCapacityPoolPatchProperties IPersistableModel<NetAppElasticCapacityPoolPatchProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<NetAppElasticCapacityPoolPatchProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<NetAppElasticCapacityPoolPatchProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<NetAppElasticCapacityPoolPatchProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        NetAppElasticCapacityPoolPatchProperties IJsonModel<NetAppElasticCapacityPoolPatchProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual NetAppElasticCapacityPoolPatchProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticCapacityPoolPatchProperties();
    }
}
