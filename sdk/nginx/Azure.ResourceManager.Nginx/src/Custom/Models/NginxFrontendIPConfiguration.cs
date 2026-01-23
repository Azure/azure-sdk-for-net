// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Nginx.Models
{
    /// <summary> Nginx Frontend IP Configuration. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(PublicIPAddresses), DeserializationValueHook = nameof(DeserializePublicIPAddresses))]      // CodeGen issue, should be removed when fixed
    public partial class NginxFrontendIPConfiguration
    {
        internal static WritableSubResource DeserializeWritableSubResource(JsonElement element)
        {
            ResourceIdentifier id = null;
            foreach (JsonProperty item in element.EnumerateObject())
            {
                if (item.NameEquals("id") && item.Value.ValueKind != JsonValueKind.Null)
                {
                    id = new ResourceIdentifier(item.Value.GetString());
                }
            }

            return new WritableSubResource() { Id = id };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializePublicIPAddresses(JsonProperty property, ref IList<WritableSubResource> publicIPAddresses)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<WritableSubResource> array = new List<WritableSubResource>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(DeserializeWritableSubResource(item));
            }
            publicIPAddresses = array;
        }
    }
}
