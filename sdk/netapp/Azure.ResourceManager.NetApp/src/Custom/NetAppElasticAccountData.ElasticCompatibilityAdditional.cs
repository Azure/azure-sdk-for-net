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
    public partial class NetAppElasticAccountData : IJsonModel<NetAppElasticAccountData>, IPersistableModel<NetAppElasticAccountData>
    {
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticAccountData(default);
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticAccountData(default);
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        NetAppElasticAccountData IJsonModel<NetAppElasticAccountData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetAppElasticAccountData)JsonModelCreateCore(ref reader, options);
        void IJsonModel<NetAppElasticAccountData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        NetAppElasticAccountData IPersistableModel<NetAppElasticAccountData>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetAppElasticAccountData)PersistableModelCreateCore(data, options);
        string IPersistableModel<NetAppElasticAccountData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetAppElasticAccountData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}
