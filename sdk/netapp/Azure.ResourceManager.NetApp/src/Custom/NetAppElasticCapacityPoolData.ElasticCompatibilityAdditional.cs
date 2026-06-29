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
    public partial class NetAppElasticCapacityPoolData : IJsonModel<NetAppElasticCapacityPoolData>, IPersistableModel<NetAppElasticCapacityPoolData>
    {
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticCapacityPoolData(default);
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticCapacityPoolData(default);
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        NetAppElasticCapacityPoolData IJsonModel<NetAppElasticCapacityPoolData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetAppElasticCapacityPoolData)JsonModelCreateCore(ref reader, options);
        void IJsonModel<NetAppElasticCapacityPoolData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        NetAppElasticCapacityPoolData IPersistableModel<NetAppElasticCapacityPoolData>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetAppElasticCapacityPoolData)PersistableModelCreateCore(data, options);
        string IPersistableModel<NetAppElasticCapacityPoolData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetAppElasticCapacityPoolData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}
