// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.CosmosDB.Models
{
    // MPG flattens MongoRoleDefinitionResource.type onto this wrapper; client.tsp @@clientName
    // renames it to RoleDefinitionType (matching MongoDBRoleDefinitionData). But 1.4.0 GA named it
    // DefinitionType *only* on this wrapper — TypeSpec cannot give one source field two csharp
    // names per containing model, so expose a back-compat alias here.
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
