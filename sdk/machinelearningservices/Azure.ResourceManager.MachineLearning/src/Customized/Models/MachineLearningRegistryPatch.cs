// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserve the legacy ManagedServiceIdentity-typed patch identity.
    [CodeGenSerialization(nameof(Identity), SerializationValueHook = nameof(SerializeIdentity), DeserializationValueHook = nameof(DeserializeIdentity))]
    public partial class MachineLearningRegistryPatch
    {
        /// <summary> Managed service identity (system assigned and/or user assigned identities). </summary>
        [CodeGenMember("Identity")]
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

            identity = ModelReaderWriter.Read<ManagedServiceIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerMachineLearningContext.Default);
        }
    }
}
