// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Azure.ResourceManager.DevTestLabs.Models
{
    /// <summary> Properties of a managed identity. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(ManagedIdentityType), SerializationValueHook = nameof(SerializeTypeValue), DeserializationValueHook = nameof(DeserializeTypeValue))]
    public partial class DevTestLabManagedIdentity
    {
        /// <summary> Managed identity. </summary>
        public Azure.ResourceManager.Models.ManagedServiceIdentityType ManagedIdentityType { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeTypeValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            // this is the logic we would like to have for the value serialization
            writer.WriteStringValue(ManagedIdentityType.ToString());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeTypeValue(JsonProperty property, ref Azure.ResourceManager.Models.ManagedServiceIdentityType ManagedIdentityType)
        {
            // this is the logic we would like to have for the value deserialization
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            ManagedIdentityType = new Azure.ResourceManager.Models.ManagedServiceIdentityType(property.Value.GetString());
        }
    }
}
