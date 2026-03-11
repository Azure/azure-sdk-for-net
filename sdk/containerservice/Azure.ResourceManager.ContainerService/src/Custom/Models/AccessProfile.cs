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
    [CodeGenSerialization(nameof(KubeConfig), SerializationValueHook = nameof(SerializeKubeConfig), DeserializationValueHook = nameof(DeserializeKubeConfig))]  // Apply custom serialization for KubeConfig to handle base64 encoding and decoding.
    internal partial class AccessProfile
    {
        /// <summary> Base64-encoded Kubernetes configuration file. </summary>
        [WirePath("kubeConfig")]
        public byte[] KubeConfig { get; set;}        // Make the KubeConfig settable for backward compatibility.

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeKubeConfig(JsonProperty property, ref byte[] KubeConfig)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            KubeConfig = property.Value.GetBytesFromBase64("D");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeKubeConfig(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WritePropertyName("kubeConfig"u8);
            writer.WriteBase64StringValue(KubeConfig, "D");
        }
    }
}
