// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable SA1649
#pragma warning disable CS1591

using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ElasticEncryptionIdentity : IJsonModel<ElasticEncryptionIdentity>, IPersistableModel<ElasticEncryptionIdentity>
    {
        public ElasticEncryptionIdentity() { }

        protected virtual ElasticEncryptionIdentity PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticEncryptionIdentity());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticEncryptionIdentity IPersistableModel<ElasticEncryptionIdentity>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticEncryptionIdentity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticEncryptionIdentity>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticEncryptionIdentity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticEncryptionIdentity IJsonModel<ElasticEncryptionIdentity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticEncryptionIdentity JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticEncryptionIdentity();
    }
}
