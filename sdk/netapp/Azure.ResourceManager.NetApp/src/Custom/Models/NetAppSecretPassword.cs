// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppSecretPassword : IJsonModel<NetAppSecretPassword>, IPersistableModel<NetAppSecretPassword>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public NetAppSecretPassword()
        {
        }

        internal NetAppSecretPassword(NetAppSecretPasswordKeyVaultPatchProperties keyVaultProperties, NetAppSecretPasswordIdentity identity, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            KeyVaultProperties = keyVaultProperties;
            Identity = identity;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public NetAppSecretPasswordKeyVaultPatchProperties KeyVaultProperties { get; set; }

        public NetAppSecretPasswordIdentity Identity { get; set; }

        protected virtual NetAppSecretPassword PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return System.BinaryData.FromString("{}");
        }

        NetAppSecretPassword IPersistableModel<NetAppSecretPassword>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<NetAppSecretPassword>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<NetAppSecretPassword>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<NetAppSecretPassword>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        NetAppSecretPassword IJsonModel<NetAppSecretPassword>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        protected virtual NetAppSecretPassword JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new NetAppSecretPassword();
        }
    }
}
