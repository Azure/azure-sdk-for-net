// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // TypeSpec models userAssignedIdentities as Record<UserIdentity>, but GA exposed the shared ARM
    // UserAssignedIdentity type. Preserve that property type and deserialize through a hook.
    [CodeGenSerialization(nameof(UserAssignedIdentities), DeserializationValueHook = nameof(ReadUserAssignedIdentities))]
    public partial class PostgreSqlFlexibleServerUserAssignedIdentity
    {
        /// <summary> Map of user assigned managed identities. </summary>
        [CodeGenMember("UserAssignedIdentities")]
        public IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get; }

        private static void ReadUserAssignedIdentities(JsonProperty property, ref IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities)
        {
            Dictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> dictionary = new Dictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity>();
            foreach (var item in property.Value.EnumerateObject())
            {
                dictionary.Add(item.Name, ((IPersistableModel<Azure.ResourceManager.Models.UserAssignedIdentity>)new Azure.ResourceManager.Models.UserAssignedIdentity()).Create(BinaryData.FromString(item.Value.GetRawText()), ModelSerializationExtensions.WireOptions));
            }
            userAssignedIdentities = dictionary;
        }
    }
}
