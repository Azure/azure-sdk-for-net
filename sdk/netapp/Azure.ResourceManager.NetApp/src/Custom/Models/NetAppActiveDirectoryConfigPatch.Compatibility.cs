// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppActiveDirectoryConfigPatch : IJsonModel<NetAppActiveDirectoryConfigPatch>, IPersistableModel<NetAppActiveDirectoryConfigPatch>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public NetAppActiveDirectoryConfigPatch()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        internal NetAppActiveDirectoryConfigPatch(ManagedServiceIdentity identity, IDictionary<string, string> tags, NetAppActiveDirectoryConfigPatchProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Identity = identity;
            Tags = tags;
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public ManagedServiceIdentity Identity { get; set; }

        public IDictionary<string, string> Tags { get; }

        public NetAppActiveDirectoryConfigPatchProperties Properties { get; set; }

        protected virtual NetAppActiveDirectoryConfigPatch PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return System.BinaryData.FromString("{}");
        }

        NetAppActiveDirectoryConfigPatch IPersistableModel<NetAppActiveDirectoryConfigPatch>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<NetAppActiveDirectoryConfigPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<NetAppActiveDirectoryConfigPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<NetAppActiveDirectoryConfigPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        NetAppActiveDirectoryConfigPatch IJsonModel<NetAppActiveDirectoryConfigPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        protected virtual NetAppActiveDirectoryConfigPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new NetAppActiveDirectoryConfigPatch();
        }
    }
}
