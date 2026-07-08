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
    public partial class ElasticEncryption : IJsonModel<ElasticEncryption>, IPersistableModel<ElasticEncryption>
    {
        public ElasticEncryption() { }
        protected virtual ElasticEncryption PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticEncryption());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticEncryption IPersistableModel<ElasticEncryption>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticEncryption>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticEncryption>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticEncryption>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticEncryption IJsonModel<ElasticEncryption>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticEncryption JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticEncryption();
    }
}
