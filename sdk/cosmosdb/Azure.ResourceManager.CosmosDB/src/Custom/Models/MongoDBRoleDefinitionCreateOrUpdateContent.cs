// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.CosmosDB;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // MPG flattens MongoRoleDefinitionResource.type onto this wrapper, and the
    // client.tsp @@clientName(MongoRoleDefinitionResource.type, "RoleDefinitionType", "csharp")
    // renames the flattened property to RoleDefinitionType (consistent with MongoDBRoleDefinitionData).
    // The baseline SDK historically named it DefinitionType *only* on this CreateOrUpdateContent
    // type — TypeSpec cannot give the same source field two different csharp names per
    // containing model, so we expose a back-compat alias here to satisfy ApiCompat.
    public partial class MongoDBRoleDefinitionCreateOrUpdateContent
    {
        /// <summary> Indicates whether the Role Definition was built-in or user created. </summary>
        [WirePath("properties.type")]
        public MongoDBRoleDefinitionType? DefinitionType
        {
            get => RoleDefinitionType;
            set => RoleDefinitionType = value;
        }
    }
}
