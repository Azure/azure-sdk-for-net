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
    public partial class NetAppElasticSnapshotPolicyPatch : IJsonModel<NetAppElasticSnapshotPolicyPatch>, IPersistableModel<NetAppElasticSnapshotPolicyPatch>
    {
        public NetAppElasticSnapshotPolicyPatch() { Tags = new ChangeTrackingDictionary<string, string>(); }
        protected virtual NetAppElasticSnapshotPolicyPatch PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new NetAppElasticSnapshotPolicyPatch());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        NetAppElasticSnapshotPolicyPatch IPersistableModel<NetAppElasticSnapshotPolicyPatch>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<NetAppElasticSnapshotPolicyPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<NetAppElasticSnapshotPolicyPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<NetAppElasticSnapshotPolicyPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        NetAppElasticSnapshotPolicyPatch IJsonModel<NetAppElasticSnapshotPolicyPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual NetAppElasticSnapshotPolicyPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticSnapshotPolicyPatch();
    }
}
