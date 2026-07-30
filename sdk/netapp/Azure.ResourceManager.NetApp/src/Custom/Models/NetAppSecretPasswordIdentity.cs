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
    public partial class NetAppSecretPasswordIdentity : IJsonModel<NetAppSecretPasswordIdentity>, IPersistableModel<NetAppSecretPasswordIdentity>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        public NetAppSecretPasswordIdentity()
        {
        }

        internal NetAppSecretPasswordIdentity(string principalId, string userAssignedIdentity, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            PrincipalId = principalId;
            UserAssignedIdentity = userAssignedIdentity;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string PrincipalId { get; }

        public string UserAssignedIdentity { get; set; }

        protected virtual NetAppSecretPasswordIdentity PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return System.BinaryData.FromString("{}");
        }

        NetAppSecretPasswordIdentity IPersistableModel<NetAppSecretPasswordIdentity>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<NetAppSecretPasswordIdentity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<NetAppSecretPasswordIdentity>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<NetAppSecretPasswordIdentity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        NetAppSecretPasswordIdentity IJsonModel<NetAppSecretPasswordIdentity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        protected virtual NetAppSecretPasswordIdentity JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new NetAppSecretPasswordIdentity();
        }
    }
}
