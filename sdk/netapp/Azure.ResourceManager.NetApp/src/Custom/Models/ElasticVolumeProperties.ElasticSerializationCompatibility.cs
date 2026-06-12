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
    public partial class ElasticVolumeProperties : IJsonModel<ElasticVolumeProperties>, IPersistableModel<ElasticVolumeProperties>
    {
        public ElasticVolumeProperties(string filePath, long size, IEnumerable<ElasticProtocolType> protocolTypes) : this(filePath, size, exportRules: default, protocolTypes: protocolTypes) { }
        public ElasticVolumeProperties() { ProtocolTypes = new ChangeTrackingList<ElasticProtocolType>(); ExportRules = new ChangeTrackingList<ElasticExportPolicyRule>(); MountTargets = new ChangeTrackingList<ElasticMountTargetProperties>(); }
        protected virtual ElasticVolumeProperties PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticVolumeProperties());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticVolumeProperties IPersistableModel<ElasticVolumeProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticVolumeProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticVolumeProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticVolumeProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticVolumeProperties IJsonModel<ElasticVolumeProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticVolumeProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticVolumeProperties();
    }
}
