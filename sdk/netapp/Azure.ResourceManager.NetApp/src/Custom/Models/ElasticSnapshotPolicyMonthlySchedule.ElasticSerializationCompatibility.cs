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
    public partial class ElasticSnapshotPolicyMonthlySchedule : IJsonModel<ElasticSnapshotPolicyMonthlySchedule>, IPersistableModel<ElasticSnapshotPolicyMonthlySchedule>
    {
        public ElasticSnapshotPolicyMonthlySchedule() { DaysOfMonth = new ChangeTrackingList<int>(); }
        protected virtual ElasticSnapshotPolicyMonthlySchedule PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticSnapshotPolicyMonthlySchedule());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticSnapshotPolicyMonthlySchedule IPersistableModel<ElasticSnapshotPolicyMonthlySchedule>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticSnapshotPolicyMonthlySchedule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticSnapshotPolicyMonthlySchedule>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticSnapshotPolicyMonthlySchedule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticSnapshotPolicyMonthlySchedule IJsonModel<ElasticSnapshotPolicyMonthlySchedule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticSnapshotPolicyMonthlySchedule JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticSnapshotPolicyMonthlySchedule();
    }
}
