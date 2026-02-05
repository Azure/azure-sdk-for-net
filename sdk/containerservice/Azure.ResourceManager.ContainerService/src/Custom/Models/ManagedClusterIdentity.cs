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
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSerialization(nameof(UserAssignedIdentities), DeserializationValueHook = nameof(DeserializeUserAssignedIdentities))]
    public partial class ManagedClusterIdentity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeUserAssignedIdentities(JsonProperty property, ref IDictionary<ResourceIdentifier, UserAssignedIdentity> userAssignedIdentities)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            Dictionary<ResourceIdentifier, UserAssignedIdentity> dictionary = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
            foreach (var property0 in property.Value.EnumerateObject())
            {
                dictionary.Add(new ResourceIdentifier(property0.Name), ModelReaderWriter.Read<UserAssignedIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property0.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerContainerServiceContext.Default));
            }
            userAssignedIdentities = dictionary;
        }
    }
}
