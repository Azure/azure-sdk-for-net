// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSerialization(nameof(CustomCATrustCertificates), SerializationValueHook = nameof(SerializeCustomCATrustCertificates), DeserializationValueHook = nameof(DeserializeCustomCATrustCertificates))]
    public partial class ManagedClusterSecurityProfile
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeCustomCATrustCertificates(JsonProperty property, ref IList<byte[]> CustomCATrustCertificates)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<byte[]> array = new List<byte[]>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(item.GetBytesFromBase64("D"));
            }
            CustomCATrustCertificates = array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeCustomCATrustCertificates(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WritePropertyName("customCATrustCertificates"u8);
            writer.WriteStartArray();
            foreach (var item in CustomCATrustCertificates)
            {
                writer.WriteBase64StringValue(item, "D");
            }
            writer.WriteEndArray();
        }
    }
}
