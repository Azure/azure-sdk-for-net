// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable SA1649
#pragma warning disable CS1591

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ChangeZoneContent : IJsonModel<ChangeZoneContent>, IPersistableModel<ChangeZoneContent>
    {
        protected virtual ChangeZoneContent PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ChangeZoneContent(default));
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ChangeZoneContent IPersistableModel<ChangeZoneContent>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ChangeZoneContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ChangeZoneContent>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ChangeZoneContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ChangeZoneContent IJsonModel<ChangeZoneContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ChangeZoneContent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ChangeZoneContent(default);
    }
}
