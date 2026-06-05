// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    [CodeGenSerialization(nameof(UserAssignedIdentities), DeserializationValueHook = nameof(DeserializeUserAssignedIdentities))]
    public partial class ManagedClusterIdentity
    {
        /// <summary> The type of identity used for the managed cluster. For more information see [use managed identities in AKS](https://docs.microsoft.com/azure/aks/use-managed-identity). </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceIdentityType ResourceIdentityType { get => IdentityType.Value; set => IdentityType = value; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeUserAssignedIdentities(JsonProperty property, ref IDictionary<Core.ResourceIdentifier, UserAssignedIdentity> UserAssignedIdentities)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            Dictionary<Core.ResourceIdentifier, UserAssignedIdentity> dictionary = new Dictionary<Core.ResourceIdentifier, UserAssignedIdentity>();
            foreach (var property0 in property.Value.EnumerateObject())
            {
                dictionary.Add(new Core.ResourceIdentifier(property0.Name), ModelReaderWriter.Read<UserAssignedIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property0.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerContainerServiceContext.Default));
            }
            UserAssignedIdentities = dictionary;
        }
    }
}
