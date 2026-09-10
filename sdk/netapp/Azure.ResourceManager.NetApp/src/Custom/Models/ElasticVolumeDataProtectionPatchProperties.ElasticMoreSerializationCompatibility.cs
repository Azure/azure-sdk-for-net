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
    public partial class ElasticVolumeDataProtectionPatchProperties : IJsonModel<ElasticVolumeDataProtectionPatchProperties>, IPersistableModel<ElasticVolumeDataProtectionPatchProperties>
    {
        protected virtual ElasticVolumeDataProtectionPatchProperties PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticVolumeDataProtectionPatchProperties());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticVolumeDataProtectionPatchProperties IPersistableModel<ElasticVolumeDataProtectionPatchProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticVolumeDataProtectionPatchProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticVolumeDataProtectionPatchProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticVolumeDataProtectionPatchProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticVolumeDataProtectionPatchProperties IJsonModel<ElasticVolumeDataProtectionPatchProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticVolumeDataProtectionPatchProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticVolumeDataProtectionPatchProperties();
    }
}
