// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Preserve the legacy CosmosDBCreateUpdateConfig type for CosmosDBSqlContainer.Options.
/// <summary>
/// The properties of an Azure Cosmos DB container.
/// </summary>
internal partial class CosmosDBSqlContainerProperties
{
    private CosmosDBSqlContainerResourceInfo _resource;
    private CosmosDBCreateUpdateConfig _options;

    // CUSTOMIZATION: The TypeSpec GET response uses ExtendedCosmosDBSqlContainerResourceInfo, but
    // the released CosmosDBSqlContainer.Resource property used CosmosDBSqlContainerResourceInfo.
    // Preserve the released type temporarily to avoid a breaking change while response model flattening is fixed.
    /// <summary> Gets or sets the Resource. </summary>
    [CodeGenMember("Resource")]
    public global::Azure.Provisioning.CosmosDB.CosmosDBSqlContainerResourceInfo Resource
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
        _resource = DefineModelProperty<CosmosDBSqlContainerResourceInfo>(nameof(Resource), new string[] { "resource" });
        _options = DefineModelProperty<CosmosDBCreateUpdateConfig>(nameof(Options), new string[] { "options" });
    }
}
