// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.StandbyPool.Models
{
    [CodeGenSerialization(nameof(SubnetIds), DeserializationValueHook = nameof(DeserializeSubnetIds))]
    public partial class StandbyContainerGroupProperties
    {
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
                if (item.ValueKind != JsonValueKind.Null)
                {
                    var writableSubResource = ModelReaderWriter.Read<WritableSubResource>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerStandbyPoolContext.Default);
                    array.Add(writableSubResource);
                }
            }
            subnetIds = array;
        }
    }
}