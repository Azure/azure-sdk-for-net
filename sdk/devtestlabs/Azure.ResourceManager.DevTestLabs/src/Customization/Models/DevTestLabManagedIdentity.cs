// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DevTestLabs.Models
{
    /// <summary> Properties of a managed identity. </summary>
    [CodeGenSerialization(nameof(Type), SerializationValueHook = nameof(SerializeTypeValue), DeserializationValueHook = nameof(DeserializeTypeValue))]
    public partial class DevTestLabManagedIdentity
    {
        /// <summary> Managed identity. </summary>
        public Azure.ResourceManager.Models.ManagedServiceIdentityType? Type { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeTypeValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            // this is the logic we would like to have for the value serialization
            writer.WriteStringValue(Type.Value.ToString());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeTypeValue(JsonProperty property, ref Azure.ResourceManager.Models.ManagedServiceIdentityType? type)
        {
            // this is the logic we would like to have for the value deserialization
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            type = new Azure.ResourceManager.Models.ManagedServiceIdentityType(property.Value.GetString());
        }
    }
}
