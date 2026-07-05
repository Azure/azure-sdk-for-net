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
    public partial class NetAppElasticVolumePatchProperties : IJsonModel<NetAppElasticVolumePatchProperties>, IPersistableModel<NetAppElasticVolumePatchProperties>
    {
        public NetAppElasticVolumePatchProperties() { ExportRules = new ChangeTrackingList<ElasticExportPolicyRule>(); }
        protected virtual NetAppElasticVolumePatchProperties PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new NetAppElasticVolumePatchProperties());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        NetAppElasticVolumePatchProperties IPersistableModel<NetAppElasticVolumePatchProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<NetAppElasticVolumePatchProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<NetAppElasticVolumePatchProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<NetAppElasticVolumePatchProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        NetAppElasticVolumePatchProperties IJsonModel<NetAppElasticVolumePatchProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual NetAppElasticVolumePatchProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticVolumePatchProperties();
    }
}
