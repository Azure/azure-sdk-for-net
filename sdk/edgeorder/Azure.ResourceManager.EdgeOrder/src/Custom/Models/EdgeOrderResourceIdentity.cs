// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // Justification: the generator's default read path for the IDictionary<string, UserAssignedIdentity>
    // property currently emits an invalid call to UserAssignedIdentity.DeserializeUserAssignedIdentity
    // (CS0117). Provide a property-level deserialization hook that reads each value via
    // ModelReaderWriter.Read<UserAssignedIdentity> until the generator is fixed.
    // TODO: remove this customization once https://github.com/Azure/azure-sdk-for-net/issues/58426 is fixed.
    [CodeGenSerialization(nameof(UserAssignedIdentities), DeserializationValueHook = nameof(DeserializeUserAssignedIdentities))]
    public partial class EdgeOrderResourceIdentity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeUserAssignedIdentities(JsonProperty property, ref IDictionary<string, UserAssignedIdentity> userAssignedIdentities)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }

            Dictionary<string, UserAssignedIdentity> dictionary = new Dictionary<string, UserAssignedIdentity>();
            foreach (JsonProperty item in property.Value.EnumerateObject())
            {
                if (item.Value.ValueKind == JsonValueKind.Null)
                {
                    dictionary.Add(item.Name, null);
                }
                else
                {
                    dictionary.Add(item.Name, ModelReaderWriter.Read<UserAssignedIdentity>(new BinaryData(Encoding.UTF8.GetBytes(item.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerEdgeOrderContext.Default));
                }
            }

            userAssignedIdentities = dictionary;
        }
    }
}
