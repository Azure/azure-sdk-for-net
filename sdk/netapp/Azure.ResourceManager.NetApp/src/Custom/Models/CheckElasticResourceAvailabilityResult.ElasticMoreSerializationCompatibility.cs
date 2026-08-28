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
    public partial class CheckElasticResourceAvailabilityResult : IJsonModel<CheckElasticResourceAvailabilityResult>, IPersistableModel<CheckElasticResourceAvailabilityResult>
    {
        protected virtual CheckElasticResourceAvailabilityResult PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new CheckElasticResourceAvailabilityResult(default, default, default));
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        CheckElasticResourceAvailabilityResult IPersistableModel<CheckElasticResourceAvailabilityResult>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<CheckElasticResourceAvailabilityResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<CheckElasticResourceAvailabilityResult>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<CheckElasticResourceAvailabilityResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        CheckElasticResourceAvailabilityResult IJsonModel<CheckElasticResourceAvailabilityResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual CheckElasticResourceAvailabilityResult JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new CheckElasticResourceAvailabilityResult(default, default, default);
    }
}
