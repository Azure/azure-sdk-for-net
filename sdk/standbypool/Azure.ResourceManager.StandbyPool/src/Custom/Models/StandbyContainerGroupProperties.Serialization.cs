// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.StandbyPool.Models
{
    [CodeGenSerialization(nameof(SubnetIds), DeserializationValueHook = nameof(DeserializeSubnetIds))]
    public partial class StandbyContainerGroupProperties
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
        internal static void DeserializeSubnetIds(JsonProperty property, ref IList<WritableSubResource> subnetIds)
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
            subnetIds = array;
        }
    }
}