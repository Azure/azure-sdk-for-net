// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.WorkloadsSapVirtualInstance.Models
{
    [CodeGenSerialization(nameof(UserAssignedIdentities), DeserializationValueHook = nameof(DeserializeUserAssignedIdentities))]
    public partial class SapVirtualInstanceIdentity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeUserAssignedIdentities(JsonProperty property, ref IDictionary<string, UserAssignedIdentity> userAssignedIdentities)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }

            Dictionary<string, UserAssignedIdentity> dictionary = new Dictionary<string, UserAssignedIdentity>();
            foreach (var item in property.Value.EnumerateObject())
            {
                if (item.Value.ValueKind == JsonValueKind.Null)
                {
                    dictionary.Add(item.Name, null);
                }
                else
                {
                    dictionary.Add(item.Name, ModelReaderWriter.Read<UserAssignedIdentity>(new BinaryData(Encoding.UTF8.GetBytes(item.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerWorkloadsSapVirtualInstanceContext.Default));
                }
            }

            userAssignedIdentities = dictionary;
        }
    }
}
