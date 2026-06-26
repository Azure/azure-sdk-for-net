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
    public partial class NetAppSecretPasswordKeyVaultPatchProperties : IJsonModel<NetAppSecretPasswordKeyVaultPatchProperties>, IPersistableModel<NetAppSecretPasswordKeyVaultPatchProperties>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public NetAppSecretPasswordKeyVaultPatchProperties(Uri keyVaultUri, string secretName)
        {
            KeyVaultUri = keyVaultUri;
            SecretName = secretName;
        }

        internal NetAppSecretPasswordKeyVaultPatchProperties(Uri keyVaultUri, string secretName, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            KeyVaultUri = keyVaultUri;
            SecretName = secretName;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public Uri KeyVaultUri { get; set; }

        public string SecretName { get; set; }

        protected virtual NetAppSecretPasswordKeyVaultPatchProperties PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return System.BinaryData.FromString("{}");
        }

        NetAppSecretPasswordKeyVaultPatchProperties IPersistableModel<NetAppSecretPasswordKeyVaultPatchProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<NetAppSecretPasswordKeyVaultPatchProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<NetAppSecretPasswordKeyVaultPatchProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<NetAppSecretPasswordKeyVaultPatchProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        NetAppSecretPasswordKeyVaultPatchProperties IJsonModel<NetAppSecretPasswordKeyVaultPatchProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        protected virtual NetAppSecretPasswordKeyVaultPatchProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new NetAppSecretPasswordKeyVaultPatchProperties(new Uri("http://localhost"), string.Empty);
        }
    }
}
