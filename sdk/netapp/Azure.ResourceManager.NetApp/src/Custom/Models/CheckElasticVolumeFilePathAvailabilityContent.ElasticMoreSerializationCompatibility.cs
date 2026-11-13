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
    public partial class CheckElasticVolumeFilePathAvailabilityContent : IJsonModel<CheckElasticVolumeFilePathAvailabilityContent>, IPersistableModel<CheckElasticVolumeFilePathAvailabilityContent>
    {
        protected virtual CheckElasticVolumeFilePathAvailabilityContent PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new CheckElasticVolumeFilePathAvailabilityContent(default));
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        CheckElasticVolumeFilePathAvailabilityContent IPersistableModel<CheckElasticVolumeFilePathAvailabilityContent>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<CheckElasticVolumeFilePathAvailabilityContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<CheckElasticVolumeFilePathAvailabilityContent>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<CheckElasticVolumeFilePathAvailabilityContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        CheckElasticVolumeFilePathAvailabilityContent IJsonModel<CheckElasticVolumeFilePathAvailabilityContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual CheckElasticVolumeFilePathAvailabilityContent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new CheckElasticVolumeFilePathAvailabilityContent(default);
    }
}
