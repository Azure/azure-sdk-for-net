// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSerialization(nameof(KubeConfig), SerializationValueHook = nameof(SerializeKubeConfig), DeserializationValueHook = nameof(DeserializeKubeConfig))]
    internal partial class AccessProfile
    {
        /// <summary> Base64-encoded Kubernetes configuration file. </summary>
        [WirePath("kubeConfig")]
        public byte[] KubeConfig { get; set;}

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
