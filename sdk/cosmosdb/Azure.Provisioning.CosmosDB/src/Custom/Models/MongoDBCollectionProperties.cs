// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Preserve the legacy CosmosDBCreateUpdateConfig type for MongoDBCollection.Options.
/// <summary>
/// The properties of an Azure Cosmos DB MongoDB collection.
/// </summary>
internal partial class MongoDBCollectionProperties
{
    private MongoDBCollectionResourceInfo _resource;
    private CosmosDBCreateUpdateConfig _options;

    // CUSTOMIZATION: The TypeSpec GET response uses ExtendedMongoDBCollectionResourceInfo, but the
    // released MongoDBCollection.Resource property used MongoDBCollectionResourceInfo. Preserve the
    // released type temporarily to avoid a breaking change while response model flattening is fixed.
    /// <summary> Gets or sets the Resource. </summary>
    [CodeGenMember("Resource")]
    public global::Azure.Provisioning.CosmosDB.MongoDBCollectionResourceInfo Resource
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
        _resource = DefineModelProperty<MongoDBCollectionResourceInfo>(nameof(Resource), new string[] { "resource" });
        _options = DefineModelProperty<CosmosDBCreateUpdateConfig>(nameof(Options), new string[] { "options" });
    }
}
