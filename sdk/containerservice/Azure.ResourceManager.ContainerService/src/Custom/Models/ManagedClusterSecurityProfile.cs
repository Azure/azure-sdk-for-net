// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSerialization(nameof(CustomCATrustCertificates), DeserializationValueHook = nameof(DeserializeCustomCATrustCertificates))]
    public partial class ManagedClusterSecurityProfile
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeCustomCATrustCertificates(JsonProperty property, ref IList<byte[]> customCATrustCertificates)
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
            customCATrustCertificates = array;
        }
    }
}
