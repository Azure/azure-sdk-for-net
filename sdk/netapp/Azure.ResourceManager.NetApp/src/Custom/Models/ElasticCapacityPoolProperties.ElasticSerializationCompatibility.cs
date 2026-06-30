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
    public partial class ElasticCapacityPoolProperties : IJsonModel<ElasticCapacityPoolProperties>, IPersistableModel<ElasticCapacityPoolProperties>
    {
        public ElasticCapacityPoolProperties(long size, ElasticServiceLevel serviceLevel, Azure.Core.ResourceIdentifier subnetResourceId)
        {
            Size = size;
            ServiceLevel = serviceLevel;
            SubnetResourceId = subnetResourceId;
        }
        protected virtual ElasticCapacityPoolProperties PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => ElasticCompatJson.Create(data, () => new ElasticCapacityPoolProperties(default, default, null));
        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => ElasticCompatJson.Write(options);
        ElasticCapacityPoolProperties IPersistableModel<ElasticCapacityPoolProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<ElasticCapacityPoolProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<ElasticCapacityPoolProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        void IJsonModel<ElasticCapacityPoolProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        ElasticCapacityPoolProperties IJsonModel<ElasticCapacityPoolProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        protected virtual ElasticCapacityPoolProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ElasticCapacityPoolProperties(default, default, null);
    }
}
