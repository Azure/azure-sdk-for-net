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
    public partial class ElasticSnapshotPolicyHourlySchedule : IJsonModel<ElasticSnapshotPolicyHourlySchedule>, IPersistableModel<ElasticSnapshotPolicyHourlySchedule>
    {
        public ElasticSnapshotPolicyHourlySchedule() { }
        protected virtual ElasticSnapshotPolicyHourlySchedule PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticSnapshotPolicyHourlySchedule());
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticSnapshotPolicyHourlySchedule IPersistableModel<ElasticSnapshotPolicyHourlySchedule>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticSnapshotPolicyHourlySchedule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticSnapshotPolicyHourlySchedule>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticSnapshotPolicyHourlySchedule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticSnapshotPolicyHourlySchedule IJsonModel<ElasticSnapshotPolicyHourlySchedule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticSnapshotPolicyHourlySchedule JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticSnapshotPolicyHourlySchedule();
    }
}
