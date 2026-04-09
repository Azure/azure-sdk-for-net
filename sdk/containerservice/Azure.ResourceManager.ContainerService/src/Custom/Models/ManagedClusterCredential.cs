// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSerialization(nameof(Value), SerializationValueHook = nameof(SerializeValue), DeserializationValueHook = nameof(DeserializeValue))]
    public partial class ManagedClusterCredential
    {
        /// <summary> Base64-encoded Kubernetes configuration file.</summary>
        [WirePath("value")]
        public byte[] Value { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeValue(JsonProperty property, ref byte[] Value)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            Value = property.Value.GetBytesFromBase64("D");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WritePropertyName("value"u8);
            writer.WriteBase64StringValue(Value, "D");
        }
    }
}
