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
    public partial class ElasticSnapshotPolicyDailySchedule : IJsonModel<ElasticSnapshotPolicyDailySchedule>, IPersistableModel<ElasticSnapshotPolicyDailySchedule>
    {
        public ElasticSnapshotPolicyDailySchedule() { }
        protected virtual ElasticSnapshotPolicyDailySchedule PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticSnapshotPolicyDailySchedule());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticSnapshotPolicyDailySchedule IPersistableModel<ElasticSnapshotPolicyDailySchedule>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticSnapshotPolicyDailySchedule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticSnapshotPolicyDailySchedule>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticSnapshotPolicyDailySchedule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticSnapshotPolicyDailySchedule IJsonModel<ElasticSnapshotPolicyDailySchedule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticSnapshotPolicyDailySchedule JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticSnapshotPolicyDailySchedule();
    }
}
