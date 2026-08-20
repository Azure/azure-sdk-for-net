// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.CosmosDB;

public partial class MongoDBRoleDefinition
{
    /// <summary>
    /// Indicates whether the Role Definition was built-in or user created.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<MongoDBRoleDefinitionType> DefinitionType
    {
        get => RoleDefinitionType;
        set => RoleDefinitionType = value;
    }
}
