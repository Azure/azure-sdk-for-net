// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Supply the missing create-body Options projection used by the legacy public API.
// Remove this customization when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
internal partial class CosmosDBSqlUserDefinedFunctionProperties
{
    private CosmosDBCreateUpdateConfig _options;

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
