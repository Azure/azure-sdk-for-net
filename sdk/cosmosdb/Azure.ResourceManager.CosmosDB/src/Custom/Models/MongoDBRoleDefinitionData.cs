// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.ResourceManager.CosmosDB
{
    [CodeGenSerialization(nameof(RoleDefinitionType), DeserializationValueHook = nameof(ReadRoleDefinitionType))]
    public partial class MongoDBRoleDefinitionData
    {
        /// <summary> Indicates whether the Role Definition was built-in or user created. </summary>
        public MongoDBRoleDefinitionType? RoleDefinitionType { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadRoleDefinitionType(JsonProperty property, ref Optional<MongoDBRoleDefinitionType> type)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            if (property.Value.ValueKind == JsonValueKind.Number)
            {
                type = property.Value.GetInt32().ToMongoDBRoleDefinitionType();
                return;
            }
            if (property.Value.ValueKind == JsonValueKind.String)
            {
                type = property.Value.GetString().ToMongoDBRoleDefinitionType();
                return;
            }
        }
    }
}
