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
    public partial class ElasticMountTargetProperties : IJsonModel<ElasticMountTargetProperties>, IPersistableModel<ElasticMountTargetProperties>
    {
        protected virtual ElasticMountTargetProperties PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticMountTargetProperties());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticMountTargetProperties IPersistableModel<ElasticMountTargetProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticMountTargetProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticMountTargetProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticMountTargetProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticMountTargetProperties IJsonModel<ElasticMountTargetProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticMountTargetProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticMountTargetProperties();
    }
}
