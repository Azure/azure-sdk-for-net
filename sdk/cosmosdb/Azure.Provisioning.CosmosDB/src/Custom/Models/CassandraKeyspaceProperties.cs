// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Preserve the legacy CosmosDBCreateUpdateConfig type for CassandraKeyspace.Options.
/// <summary>
/// The properties of an Azure Cosmos DB Cassandra keyspace.
/// </summary>
internal partial class CassandraKeyspaceProperties
{
    private CosmosDBCreateUpdateConfig _options;

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
        _options = DefineModelProperty<CosmosDBCreateUpdateConfig>(nameof(Options), new string[] { "options" });
    }
}
