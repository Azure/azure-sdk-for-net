// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Supply the missing create-body Options projection used by the legacy public API.
// Remove this customization when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
internal partial class CosmosDBSqlStoredProcedureProperties
{
    private CosmosDBSqlStoredProcedureResourceInfo _resource;
    private CosmosDBCreateUpdateConfig _options;

    // CUSTOMIZATION: The TypeSpec GET response uses ExtendedCosmosDBSqlStoredProcedureResourceInfo,
    // but the released CosmosDBSqlStoredProcedure.Resource property used
    // CosmosDBSqlStoredProcedureResourceInfo. Preserve the released type temporarily to avoid a
    // breaking change while response model flattening is fixed.
    /// <summary> Gets or sets the Resource. </summary>
    [CodeGenMember("Resource")]
    public global::Azure.Provisioning.CosmosDB.CosmosDBSqlStoredProcedureResourceInfo Resource
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
        _resource = DefineModelProperty<CosmosDBSqlStoredProcedureResourceInfo>(nameof(Resource), new string[] { "resource" });
        _options = DefineModelProperty<CosmosDBCreateUpdateConfig>(nameof(Options), new string[] { "options" });
    }
}
