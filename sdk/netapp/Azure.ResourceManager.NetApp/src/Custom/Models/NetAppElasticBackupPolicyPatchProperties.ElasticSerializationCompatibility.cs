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
    public partial class NetAppElasticBackupPolicyPatchProperties : IJsonModel<NetAppElasticBackupPolicyPatchProperties>, IPersistableModel<NetAppElasticBackupPolicyPatchProperties>
    {
        public NetAppElasticBackupPolicyPatchProperties() { }
        protected virtual NetAppElasticBackupPolicyPatchProperties PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new NetAppElasticBackupPolicyPatchProperties());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        NetAppElasticBackupPolicyPatchProperties IPersistableModel<NetAppElasticBackupPolicyPatchProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<NetAppElasticBackupPolicyPatchProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<NetAppElasticBackupPolicyPatchProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<NetAppElasticBackupPolicyPatchProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        NetAppElasticBackupPolicyPatchProperties IJsonModel<NetAppElasticBackupPolicyPatchProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual NetAppElasticBackupPolicyPatchProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticBackupPolicyPatchProperties();
    }
}
