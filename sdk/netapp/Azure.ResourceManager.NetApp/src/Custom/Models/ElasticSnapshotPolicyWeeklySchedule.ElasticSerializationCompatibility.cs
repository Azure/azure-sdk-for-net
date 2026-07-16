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
    public partial class ElasticSnapshotPolicyWeeklySchedule : IJsonModel<ElasticSnapshotPolicyWeeklySchedule>, IPersistableModel<ElasticSnapshotPolicyWeeklySchedule>
    {
        public ElasticSnapshotPolicyWeeklySchedule() { Days = new ChangeTrackingList<DayOfWeek>(); }
        protected virtual ElasticSnapshotPolicyWeeklySchedule PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticSnapshotPolicyWeeklySchedule());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticSnapshotPolicyWeeklySchedule IPersistableModel<ElasticSnapshotPolicyWeeklySchedule>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticSnapshotPolicyWeeklySchedule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticSnapshotPolicyWeeklySchedule>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticSnapshotPolicyWeeklySchedule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticSnapshotPolicyWeeklySchedule IJsonModel<ElasticSnapshotPolicyWeeklySchedule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticSnapshotPolicyWeeklySchedule JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticSnapshotPolicyWeeklySchedule();
    }
}
