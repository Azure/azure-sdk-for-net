// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Preserve the legacy CosmosDBCreateUpdateConfig type for MongoDBDatabase.Options.
/// <summary>
/// The properties of an Azure Cosmos DB MongoDB database.
/// </summary>
internal partial class MongoDBDatabaseProperties
{
    private MongoDBDatabaseResourceInfo _resource;
    private CosmosDBCreateUpdateConfig _options;

    // CUSTOMIZATION: The TypeSpec GET response uses ExtendedMongoDBDatabaseResourceInfo, but the
    // released MongoDBDatabase.Resource property used MongoDBDatabaseResourceInfo. Preserve the
    // released type temporarily to avoid a breaking change while response model flattening is fixed.
    /// <summary> Gets or sets the Resource. </summary>
    [CodeGenMember("Resource")]
    public global::Azure.Provisioning.CosmosDB.MongoDBDatabaseResourceInfo Resource
    {
        get
        {
            Initialize();
            return _resource;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _resource, value);
        }
    }

    /// <summary> Gets or sets the Options. </summary>
    [CodeGenMember("Options")]
    public CosmosDBCreateUpdateConfig Options
    {
        get
        {
            Initialize();
            return _options;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _options, value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _resource = DefineModelProperty<MongoDBDatabaseResourceInfo>(nameof(Resource), new string[] { "resource" });
        _options = DefineModelProperty<CosmosDBCreateUpdateConfig>(nameof(Options), new string[] { "options" });
    }
}
