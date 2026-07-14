// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppActiveDirectoryConfigData : TrackedResourceData, IJsonModel<NetAppActiveDirectoryConfigData>, IPersistableModel<NetAppActiveDirectoryConfigData>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public NetAppActiveDirectoryConfigData(AzureLocation location) : base(location)
        {
        }

        internal NetAppActiveDirectoryConfigData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ActiveDirectoryConfigProperties properties, ETag? eTag, ManagedServiceIdentity identity, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            ETag = eTag;
            Identity = identity;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public ActiveDirectoryConfigProperties Properties { get; set; }

        public ETag? ETag { get; }

        public ManagedServiceIdentity Identity { get; set; }

        internal NetAppActiveDirectoryConfigData()
        {
        }

        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return BinaryData.FromString("{}");
        }

        NetAppActiveDirectoryConfigData IPersistableModel<NetAppActiveDirectoryConfigData>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetAppActiveDirectoryConfigData)PersistableModelCreateCore(data, options);

        string IPersistableModel<NetAppActiveDirectoryConfigData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<NetAppActiveDirectoryConfigData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<NetAppActiveDirectoryConfigData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        NetAppActiveDirectoryConfigData IJsonModel<NetAppActiveDirectoryConfigData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetAppActiveDirectoryConfigData)JsonModelCreateCore(ref reader, options);

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            base.JsonModelWriteCore(writer, options);
        }

        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new NetAppActiveDirectoryConfigData();
        }
    }
}
