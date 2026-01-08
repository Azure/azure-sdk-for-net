// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KeyVault.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Identity), SerializationValueHook = nameof(SerializeIdentity), DeserializationValueHook = nameof(DeserializeIdentity))]
    public partial class ManagedHsmPrivateLinkResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ManagedHsmPrivateLinkResourceData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public ManagedHsmPrivateLinkResourceData(AzureLocation location) : base(location)
        {
        }

        /// <summary> SKU details. </summary>
        [WirePath("sku")]
        public ManagedHsmSku Sku { get; set; }
        /// <summary> Managed service identity (system assigned and/or user assigned identities). </summary>
        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeIdentity(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ManagedServiceIdentity>)Identity).Write(writer, options);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeIdentity(JsonProperty property, ref ManagedServiceIdentity identity)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            identity = ModelReaderWriter.Read<ManagedServiceIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerKeyVaultContext.Default);
        }
    }
}
