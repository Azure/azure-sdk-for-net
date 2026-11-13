// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
#pragma warning disable SA1402

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppElasticSnapshotPolicyData : IJsonModel<NetAppElasticSnapshotPolicyData>, IPersistableModel<NetAppElasticSnapshotPolicyData>
    {
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticSnapshotPolicyData(default);
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticSnapshotPolicyData(default);
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        NetAppElasticSnapshotPolicyData IJsonModel<NetAppElasticSnapshotPolicyData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetAppElasticSnapshotPolicyData)JsonModelCreateCore(ref reader, options);
        void IJsonModel<NetAppElasticSnapshotPolicyData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        NetAppElasticSnapshotPolicyData IPersistableModel<NetAppElasticSnapshotPolicyData>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetAppElasticSnapshotPolicyData)PersistableModelCreateCore(data, options);
        string IPersistableModel<NetAppElasticSnapshotPolicyData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetAppElasticSnapshotPolicyData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}
